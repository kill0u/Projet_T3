using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DiabManager.Metiers
{
    /// <summary>
    /// Classe définissant la partie (mise en place, courant, et fin)
    /// </summary>
    class Partie
    {
        //Attributs
        /// <summary>
        /// Joueur de la partie.
        /// </summary>
        private static Joueur m_j;

        /// <summary>
        /// Timer pour actualiser le formulaire de Jeu.
        /// </summary>
        private System.Timers.Timer m_updateTimer;

        /// <summary>
        /// Date de la partie.
        /// </summary>
        private DateTime m_d = new DateTime();

        /// <summary>
        /// Gestionnaire des Actions.
        /// </summary>
        private Gestionnaires.ActionControlleur m_ac;

        /// <summary>
        /// Temps de la Journée.
        /// </summary>
        private Temps m_t;

        private int m_jobj = 0;
        public int jobj
        {
            get { return m_jobj; }
            set { m_jobj = value; }
        }

        private int m_tfin = 0;
        public int tfin
        {
            get { return m_tfin; }
            set { m_tfin = value; }
        }

        private frmJeu m_jeu= new frmJeu();
        public frmJeu j
        {
            get { return m_jeu; }
            set { m_jeu = value; }
        }


        //Fonctions
        /// <summary>
        /// Fonction d'ajout d'un jour dans la partie.
        /// </summary>
        public void AddDay()
        {
            m_d.AddDays(1);
            IHM.IHM_Joueur.getJoueur().Stylo.resetStylo();
            double objBas= double.Parse(IHM.IHM_Joueur.getInfos()[7].Split('-')[0]);
            double objHaut= double.Parse(IHM.IHM_Joueur.getInfos()[7].Split('-')[1]);
            if (double.Parse(IHM.IHM_Joueur.getInfos()[9])>objBas && double.Parse(IHM.IHM_Joueur.getInfos()[9])<objHaut)
            {
                jobj++;
                if (jobj==3) { Fin(true); }
            }
        }
        
        /// <summary>
        /// Fonction qui permet de démarrer la partie.
        /// </summary>
        public void Demarrer(frmJeu Jeu1)
        {
            this.m_jeu = Jeu1;
            m_ac = Gestionnaires.ActionControlleur.getInstance();
            m_ac.chargerAction();
            m_ac.chargerEvenement();
            //Met en place le temps.
            m_t = Temps.getInstance();
            m_t.StartTime(this);
            //Met en place les actions.

            //Le timer tick toutes les 500 ms
            m_updateTimer = new System.Timers.Timer(500);

            m_updateTimer.Elapsed += JeuEnCours;
            m_updateTimer.AutoReset = true;

            m_updateTimer.Start();
            
        }

        

        /**Evènements lancé à chaque tick du timer.
         * Fonction à exécuté à chaque tick du timer, mettre à jour les infos.
         */
         public void JeuEnCours(Object source, ElapsedEventArgs e)
        {
            IHM.IHM_Actions.Update();
            IHM.IHM_Joueur.Update();
            if (double.Parse(IHM.IHM_Joueur.getInfos()[9])> double.Parse(IHM.IHM_Joueur.getInfos()[7].Split('-')[1]) || double.Parse(IHM.IHM_Joueur.getInfos()[9]) < double.Parse(IHM.IHM_Joueur.getInfos()[7].Split('-')[0])) { jobj = 0; }
            if (Temps.getInstance().getHeureJournee().Hours == 7 && Temps.getInstance().getHeureJournee().Minutes == 0)
            {
                this.m_jeu.Gp.ColorTop = Color.Plum;
                this.m_jeu.Gp.ColorBottom = Color.Orchid;
                this.m_jeu.Gp.Invoke(new MethodInvoker(delegate { this.m_jeu.Gp.Refresh(); }));
            }
            if (Temps.getInstance().getHeureJournee().Hours == 12 && Temps.getInstance().getHeureJournee().Minutes == 0)
            {
                this.m_jeu.Gp.ColorTop = Color.LightSteelBlue;
                this.m_jeu.Gp.ColorBottom = Color.MediumSpringGreen;
                this.m_jeu.Gp.Invoke(new MethodInvoker(delegate { this.m_jeu.Gp.Refresh(); }));
            }
            if (Temps.getInstance().getHeureJournee().Hours == 20 && Temps.getInstance().getHeureJournee().Minutes == 0)
            {
                this.m_jeu.Gp.ColorTop = Color.Indigo;
                this.m_jeu.Gp.ColorBottom = Color.MidnightBlue;
                this.m_jeu.Gp.Invoke(new MethodInvoker(delegate { this.m_jeu.Gp.Refresh(); }));
            }
            
        }

        /// <summary>
        /// Fonction qui fini la partie.
        /// </summary>
        public void Fin(bool res)
        {
            m_updateTimer.Stop();
            frmFinJeu finjeu = new frmFinJeu();
            finjeu.ShowDialog();
        }
    }
}
