using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        /// <summary>
        /// Référence vers le formulaire de jeu
        /// </summary>
        private frmJeu m_jeu;
        public frmJeu j
        {
            get { return m_jeu; }
            set { m_jeu = value; }
        }

        /// <summary>
        /// Fonction d'ajout d'un jour dans la partie.
        /// </summary>
        public void AddDay()
        {
            m_d.AddDays(1);

            j.newDay();
            
            //On change le jour
            switch (Temps.getInstance().getHeureJournee().Days%7) 
            {
                case 6:
                    m_jeu.setJour("Dimanche");
                    break;
                case 0:
                    m_jeu.setJour("Lundi");
                    break;
                case 1:
                    m_jeu.setJour("Mardi");
                    break;
                case 2:
                    m_jeu.setJour("Mercredi");
                    break;
                case 3:
                    m_jeu.setJour("Jeudi");
                    break;
                case 4:
                    m_jeu.setJour("Vendredi");
                    break;
                case 5:
                    m_jeu.setJour("Samedi");
                    break;
                default:
                    m_jeu.setJour("Lundi");
                    break;
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
            //Met en place le temps
            m_t = Temps.getInstance();
            m_t.StartTime(this);
            //Met en place les actions

            //Le timer tick toutes les 500 ms
            m_updateTimer = new System.Timers.Timer(500);

            m_updateTimer.Elapsed += JeuEnCours;
            m_updateTimer.AutoReset = true;

            m_updateTimer.Start();
        }
        
        /**Événements lancés à chaque tick du timer.
         * Fonction à exécuter à chaque tick du timer, mettre à jour les infos.
         */
        public void JeuEnCours(Object source, ElapsedEventArgs e)
        {
            IHM.IHM_Actions.Update();
            IHM.IHM_Joueur.Update();
        }

        /// <summary>
        /// Fonction qui finit la partie.
        /// </summary>
        public void Fin(bool res)
        {
            m_updateTimer.Stop();
            Temps.getInstance().endTimer();
            m_jeu.BeginInvoke((Action)(() => {
                m_jeu.Hide();
                frmFinJeu finJeu = new frmFinJeu(res, m_jeu.getLog());
                finJeu.ShowDialog();
                m_jeu.DialogResult = finJeu.DialogResult;
                m_jeu.Close();
            }));
            
        }
    }
}
