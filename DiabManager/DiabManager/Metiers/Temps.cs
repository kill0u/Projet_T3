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
    

        /**Constructeur: initialise les infos importantes.
         * Initiliase l'heure de la journée et initialise le timer
         * @see SetTimer()
         */ 
        private Temps()
        {
            //Une journée commence à 00h00
            m_time = new TimeSpan(0, 0, 0);

            //Mise en place du timer
            SetTimer();
        }

       


        /** Mets en place le timer.
         */
        private void SetTimer()
        {
            //Le timer tick toutes les 30 s
            m_dayTimer = new Timer(1000);

            m_dayTimer.Elapsed += TickEvent;
            m_dayTimer.AutoReset = true;
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
            IHM.IHM_Actions.UpdateButton();


            //On mets à jour les actions disponibles (vues que l'heure à changé)
            Gestionnaires.ActionControlleur.getInstance().UpdateAction(m_time);
        }

        /**Retourne l'heure actuelle.
         * Retourne l'heure du jours actuelle 
         */ 
        public TimeSpan getHeureJournee()
        {
            return m_time;
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
