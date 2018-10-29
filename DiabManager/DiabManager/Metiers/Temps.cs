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
        private static Temps m_tempsInstance = new Temps();

        private const int dureeTemps = 10000;

        /** Heure de la journée. Heure:minutes:secondes de la journée actuelle
         */
        private TimeSpan m_time;


        /** Récupère l'instance de la partie actuelle.
         * Permet de savoir à quel partie se réfère le temps actuel (la partie s'initialise lors de la mise en marche du timer)
         */ 
        private Partie m_partie;


        /**Timer pour faire passer le temps.
         Le Timer qui fait défiler automatiquement le temps, et lance un event à chaque tick*/
        private Timer m_dayTimer;

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
            //Le timer tick toutes les 30 s
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
            m_coeffVitesse = coeff;
            m_dayTimer.Interval = dureeTemps / m_coeffVitesse;
        }

        /**Démarre le timer et enregistre la partie actuelle
         */ 
        public void StartTime(Partie p)
        {
            m_partie = p;

            m_dayTimer.Start();
        }

        /**Evènements lancé à chaque tick du timer.
         * Fonction à exécuté à chaque tick du timer, mettre à jour l'heure
         */ 
        private void TickEvent(Object source, ElapsedEventArgs e)
        {
            //On ne fait l'action que si le timer est en cours
            if(m_dayTimer.AutoReset)
                //On ajoute le temps 
                m_time = m_time.Add(new TimeSpan(0, 10, 0));

            
            //si on dépasse un jour
            if(m_time.Days > 0)
            {
                //on réinitialise
                m_time = new TimeSpan(0, 0, 0);

                //On ajoute un jour sur la partie
                m_partie.AddDay();


            }


            //On mets à jour les actions disponibles (vues que l'heure à changé)
            Gestionnaires.ActionControlleur.getInstance().UpdateAction(m_time);

            IHM.IHM_Actions.updateTemps(m_time);
        }

        /**Retourne l'heure actuelle.
         * Retourne l'heure du jours actuelle 
         */ 
        public TimeSpan getHeureJournee()
        {
            return m_time;
        }


        public void addTime(TimeSpan temps)
        {

            m_time = m_time.Add(temps);



            //si on dépasse un jour
            if (m_time.Days > 0)
            {
                //on réinitialise
                m_time = new TimeSpan(0, 0, 0);

                //On ajoute un jour sur la partie
                m_partie.AddDay();


            }
            //On mets à jour les actions disponibles (vues que l'heure à changé)
            Gestionnaires.ActionControlleur.getInstance().UpdateAction(m_time);

            IHM.IHM_Actions.updateTemps(m_time);

        }

        /** Renvoie l'instance de temps actuel
        * @return instance du controleur
        */
        public static Temps getInstance()
        {
            return m_tempsInstance;
        }
    }
}
