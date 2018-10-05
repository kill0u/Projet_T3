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
     */ 
    class Temps
    {
        /** Heure de la journée. Heure:minutes:secondes de la journée actuelle
         */
        private TimeSpan m_time;


        /** Coefficient de conversion du temps. 
            Coefficient définissant le lien entre le temps réel (vu par l'utilisateur) et le temps vu depuis le jeu (10mins dans le jeu = 30s)*/
        //private double m_timeCoeff;

        /**Timer pour faire passer le temps.
         Le Timer qui fait défiler automatiquement le temps, et lance un event à chaque tick*/
        private Timer m_dayTimer; 
    

        /**Constructeur: initialise les infos importantes.
         * Initiliase l'heure de la journée et initialise le timer
         * @see SetTimer()
         */ 
        public Temps()
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
            m_dayTimer = new Timer(30000);

            m_dayTimer.Elapsed += TickEvent;
            m_dayTimer.AutoReset = true;
        }


        /**Démarre le timer
         */ 
        public void StartTime()
        {
            m_dayTimer.Start();
        }

        /**Evènements lancé à chaque tick du timer.
         * Fonction à exécuté à chaque tick du timer, mettre à jour l'heure
         */ 
        private void TickEvent(Object source, ElapsedEventArgs e)
        {
            //On ajoute le temps au panel
            m_time = m_time.Add(new TimeSpan(0, 10, 0));

            //si on dépasse un jour, on réinitialise
            if(m_time.Days > 0)
            {
                m_time = new TimeSpan(0, 0, 0);
            }

            Console.WriteLine(m_time.ToString());
        }


    }
}
