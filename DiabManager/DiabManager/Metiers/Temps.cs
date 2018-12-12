using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DiabManager.Metiers
{
    /** La classe définissant le temps qui passe.
     * Cette classe définit le temps de la journée et le fait défiler automatiquement (via un timer)
     * @author Geoffrey Kugelmann
     * @version 1.1
     */ 
    class Temps
    {
        /**Singleton de la classe Temps.
         * Garde la référence à la classe Temps active (afin de n'avoir qu'une instance de temps en même temps)
         */ 
        private static Temps m_tempsInstance;

        private const int dureeTemps = 10000;

        /** Heure de la journée. Heure:minutes:secondes de la journée actuelle
         */
        private TimeSpan m_time;

        /// <summary>
        /// Heure de fin de l'action (ou évènement) en cours
        /// </summary>
        private TimeSpan m_destTime = new TimeSpan(-1,0,0);
        

        private bool m_actionEnCours = false;
        public bool isActionEnCours
        {
            get { return m_actionEnCours; }
        }

        /** Récupère l'instance de la partie actuelle.
         * Permet de savoir à quel partie se réfère le temps actuel (la partie s'initialise lors de la mise en marche du timer)
         */
        private Partie m_partie;


        /**Timer pour faire passer le temps.
         Le Timer qui fait défiler automatiquement le temps, et lance un event à chaque tick*/
        private Timer m_dayTimer;

        private TimeSpan m_tempsHorsPlage = new TimeSpan(0);


        private TimeSpan m_tempsDansPlage = new TimeSpan(0);
        private int m_creditTempsDansPlage = 12;

        private double m_gMin = 0.5;
        public double gMin
        {
            get { return m_gMin; }
        }

        private double m_gMax = 2;
        public double gMax
        {
            get { return m_gMax; }
        }


        /// <summary>
        /// Coefficient de changement de vitesse (pour le déroulement du jeu)
        /// </summary>
        private double m_coeffVitesse = 1;
        public double CoeffVitesse
        {
            get { return m_coeffVitesse; }
        }
    

        /**Constructeur: initialise les infos importantes.
         * Initiliase l'heure de la journée et initialise le timer
         * @see SetTimer()
         */ 
        private Temps()
        {
            //Une journée commence à 07h00
            m_time = new TimeSpan(7, 0, 0);

            //Mise en place du timer
            SetTimer();
        }

       


        /** Mets en place le timer.
         */
        private void SetTimer()
        {
            //Le timer tick toutes les 10 s
            m_dayTimer = new Timer(dureeTemps);

            m_dayTimer.Elapsed += TickEvent;
            m_dayTimer.AutoReset = true;
        }

        /// <summary>Change l'etat du jeu (en cours ou en pause)</summary>
        /// <returns>Etat actuel du jeu (false = pause)</returns>
        public bool PlayPause()
        {
            m_dayTimer.AutoReset = !m_dayTimer.AutoReset;
            return m_dayTimer.AutoReset;
        }


        /// <summary>Change la vitesse de défilement du jeu</summary>
        /// <param name="coeff">Coeffcient de changement de vitesse </param>
        public void changeSpeed(double coeff)
        {
            if (m_destTime.Hours < 0) //on ne peut changer la vitesse que si on est en jeu normal
            {
                m_coeffVitesse = coeff;
                m_dayTimer.Interval = dureeTemps / m_coeffVitesse;
            }
            
        }


        /// <summary>
        /// Démarre le timer et enregistre la partie actuelle
        /// </summary>
        /// <param name="p">Référence vers la partie en cours</param>
        public void StartTime(Partie p)
        {
            m_partie = p;

            m_dayTimer.Start();
        }

        private Boolean m_matin = true;
        private Boolean m_matinInter = true;
        private Boolean m_midi = true;
        private Boolean m_midiInter = true;
        private Boolean m_soir = true;
        private Boolean m_soirInter = true;

        /**Evènements lancé à chaque tick du timer.
         * Fonction à exécuté à chaque tick du timer, mettre à jour l'heure
         */
        private void TickEvent(Object source, ElapsedEventArgs e)
        {
            //On ne fait l'action que si le timer est en cours
            if(m_dayTimer.AutoReset)
            {
                //On ajoute le temps 
                m_time = m_time.Add(new TimeSpan(0, 10, 0));

                //Modification de la glyémie via piqure lente
                IHM.IHM_Joueur.getJoueur().GlycemieCourante -= (0.1 * IHM.IHM_Joueur.getJoueur().Stylo.dose) / (24 * 6);

                if (getHeureJournee().Hours == 8 && getHeureJournee().Minutes == 30)
                {
                    if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu == 0) IHM.IHM_Joueur.getJoueur().Stylo.DoseActu = IHM.IHM_Joueur.getJoueur().Stylo.DoseMax;
                    PlayPause();
                    frmPiqure pik = new frmPiqure();
                    pik.ShowDialog();
                }
                if (getHeureJournee().Hours < 12 && getHeureJournee().Minutes == 0 &&
                    m_matin && m_matinInter)
                {
                    //open = false;
                    m_partie.j.setFond("matin");
                    /*this.m_jeu.Gp.ColorTop = Color.Plum;
                    this.m_jeu.Gp.ColorBottom = Color.Orchid;*/
                    //this.m_jeu.Invoke(new MethodInvoker(delegate { this.m_jeu.Refresh(); }));
                    m_matin = false;
                    m_matinInter = false;
                    m_midiInter = false;
                    m_soirInter = false;
                    m_midi = true;
                }
                if (getHeureJournee().Hours == 12)
                {
                    m_midiInter = true;
                }
                if(getHeureJournee().Hours == 20)
                {
                    m_soirInter = true;
                }
                if(getHeureJournee().Hours == 7)
                {
                    m_matinInter = true;
                }
                if (getHeureJournee().Hours < 20 && getHeureJournee().Minutes == 0 &&
                    m_midi && m_midiInter)
                {
                    m_partie.j.setFond("midi");
                    /*this.m_jeu.Gp.ColorTop = Color.LightSteelBlue;
                    this.m_jeu.Gp.ColorBottom = Color.MediumSpringGreen;*/
                    //this.m_jeu.Invoke(new MethodInvoker(delegate { this.m_jeu.Refresh(); }));
                    m_midi = false;
                    m_soir = true;
                    m_matinInter = false;
                    m_midiInter = false;
                    m_soirInter = false;
                }
                if (getHeureJournee().Hours <= 23 && getHeureJournee().Minutes <= 59 && getHeureJournee().Minutes == 0 &&
                    m_soir && m_soirInter|| getHeureJournee().Hours >= 0 && getHeureJournee().Hours < 6 && m_soirInter)
                {
                    m_partie.j.setFond("soir");
                    /*this.m_jeu.Gp.ColorTop = Color.Indigo;
                    this.m_jeu.Gp.ColorBottom = Color.MidnightBlue;*/
                    //this.m_jeu.Invoke(new MethodInvoker(delegate { this.m_jeu.Refresh(); }));
                    m_soir = false;
                    m_matin = true;
                    m_matinInter = false;
                    m_midiInter = false;
                    m_soirInter = false;
                }

                //On regarde si le joueur est en dehors des taux possibles pendant plus de 6 heures
                if (IHM.IHM_Joueur.getJoueur().GlycemieCourante < m_gMin)
                {
                    m_tempsHorsPlage = m_tempsHorsPlage.Add(new TimeSpan(0, 10, 0));
                }
                else if (IHM.IHM_Joueur.getJoueur().GlycemieCourante > m_gMax)
                {
                    m_tempsHorsPlage = m_tempsHorsPlage.Add(new TimeSpan(0, 10, 0));
                }
                else
                {
                    m_tempsHorsPlage = new TimeSpan(0);
                }

                if (m_tempsHorsPlage.Hours >= 6)
                {
                    m_partie.Fin(false);
                }

                //On regarde si le joueur reste suffisamment de temps dans la zone
                double objBas = double.Parse(IHM.IHM_Joueur.getInfos()[7].Split('-')[0]);
                double objHaut = double.Parse(IHM.IHM_Joueur.getInfos()[7].Split('-')[1]);
                if (double.Parse(IHM.IHM_Joueur.getInfos()[9]) > objBas && double.Parse(IHM.IHM_Joueur.getInfos()[9]) < objHaut)
                {
                    m_tempsDansPlage = m_tempsDansPlage.Add(new TimeSpan(0, 10, 0));
                 
                }
                else
                {
                    if (m_creditTempsDansPlage > 0)
                    {
                        m_creditTempsDansPlage--;
                        m_tempsDansPlage = m_tempsDansPlage.Add(new TimeSpan(0, 10, 0));
                    }
                    else
                    {
                        m_tempsDansPlage = new TimeSpan(0);
                    }
                }

                if (m_tempsDansPlage.Days >= 3)
                {
                    m_partie.Fin(true);
                }
            }

            
            //si on dépasse un jour
            if(m_time.Hours == 0 && m_time.Minutes == 0 && m_time.Seconds == 0)
            {

                //On ajoute un jour sur la partie
                m_partie.AddDay();

                //On réautorise à quitter la zone de glycémie pour 2h dans toute la journée
                m_creditTempsDansPlage = 12;

            }


            //On mets à jour les actions disponibles (vues que l'heure à changé)
            Gestionnaires.ActionControlleur.getInstance().UpdateAction(m_time);

            //On regarde si une action est en cours, et si oui, on fait son effet
            Gestionnaires.ActionControlleur.getInstance().DuringAction();

            //On déclenche potentiellement des événements aléatoires
            Gestionnaires.ActionControlleur.getInstance().CalcEvenement(m_time);

            //On regarde si des événement aléatoires sont en cours
            Gestionnaires.ActionControlleur.getInstance().UpdateEvenement();

            //On update le graph
            IHM.IHM_Joueur.UpdateGraph();

            //On update le temps de l'affichage
            IHM.IHM_Actions.updateTemps(m_time);
        }

        /**Retourne l'heure actuelle.
         * Retourne l'heure du jours actuelle 
         */ 
        public TimeSpan getHeureJournee()
        {
            return m_time;
        }


        /// <summary>
        /// Fonction permettant d'ajouter du temps (en le faisant défiler)
        /// </summary>
        /// <param name="temps">Temps à ajouté</param>
        public void addTime(TimeSpan temps)
        {

           

            m_destTime = m_time.Add(temps);

        }

        public void swapAction()
        {
            if (m_actionEnCours) //On vient de finir notre action
            {
                m_actionEnCours = false;
                changeSpeed(m_coeffVitesse);
                IHM.IHM_Actions.RemoveAction();
            }
            else //On vient de commencer une action
            {
                m_dayTimer.Interval = 200;
                m_actionEnCours = true;
            }
        }

        /** Renvoie l'instance de temps actuel
        * @return instance du controleur
        */
        public static Temps getInstance()
        {
            if (m_tempsInstance == null)
                m_tempsInstance = new Temps();
            return m_tempsInstance;
        }

        /// <summary>
        /// Détruit l'instance de temps (pour pouvoir redemarré)
        /// </summary>
        public static void destroyInstance()
        {
            m_tempsInstance = null;
        }

        public void endTimer()
        {
            m_dayTimer.Stop();
            m_dayTimer.Close();
        }
    }
}
