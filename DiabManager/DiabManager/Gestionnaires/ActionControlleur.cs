﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Metiers;
using DiabManager.Metiers.ListeActions;
using System.IO;
using System.Globalization;

namespace DiabManager.Gestionnaires
{
    /**Classe controllant les actions disponibles.
     * Cette classe stocke toutes les actions possibles, et fait le lien avec le temps (autorise notamment certaines actions à certains moments)
     * @author Geoffrey Kugelmann
     * @version 1
     */
    class ActionControlleur
    {
        /**Singleton de la classe ActionControlleur.
         * Garde la référence à la classe ActionControlleur active (afin de n'avoir qu'une instance de temps en même temps)
         */
        private static ActionControlleur m_actionControlleurInstance = new ActionControlleur();

        /** Liste de toutes les actions lancés actuellement.
         * Liste les actions possibles pour l'utilisateur, avec pour valeur vrai si l'utilisateur peut les faire
         */ 
        private Dictionary<Actions, bool> m_listActions = new Dictionary<Actions, bool>();
        public Dictionary<Actions, bool> ListActions
        {
            get { return new Dictionary<Actions, bool>(m_listActions); }
        }


        /** Liste de toutes les événements possibles pour le joueur actuellement.
         * Liste les évènements possibles pour l'utilisateur <see cref="EvenementsAleatoires"/>, avec pour valeur vrai si l'évènement est possible pour le joueur
         */
        private Dictionary<EvenementsAleatoire, bool> m_listEvent = new Dictionary<EvenementsAleatoire, bool>();
        public Dictionary<EvenementsAleatoire, bool> listEvent
        {
            get { return new Dictionary<EvenementsAleatoire, bool>(m_listEvent); }
        }

        /// <summary>
        /// Référence vers la classe temps
        /// </summary>
        private Temps m_temps = Temps.getInstance();

        /// <summary>
        /// Constructeur privé, pour éviter une instanciation de <see cref="ActionControlleur"/> .
        /// </summary>
        private ActionControlleur()
        {

        }


        /** Ajoute une action.
         * Chaque action possible pour l'utilisateur doit être ajouter dans le controlleur
         * @param a Action possible pour l'utilisateur
         */ 
        public void AddAction(Actions a)
        {
            m_listActions.Add(a, false);
        }

        /// <summary>
        /// Mets à jour les actions disponibles
        /// </summary>
        /// <param name="temps">The temps.</param>
        /// Les actions disponibles dépendent des heures de la journée, cette fonction regarde toutes les actions, et mets à jour m_listActions
        public void UpdateAction(TimeSpan temps)
        {

            for(int i = 0; i < m_listActions.Count; i++)
            {
                var a = m_listActions.ElementAt(i);
                if(a.Key.isTempsDansPlage(temps))
                {
                    m_listActions[a.Key] = true;
                }
                else
                {
                    m_listActions[a.Key] = false;
                }
            }

            IHM.IHM_Actions.UpdateButton();

        }

        /// <summary>
        /// Charge toutes les actions disponibles, depuis un fichier de configuration
        /// </summary>
        public void chargerAction()
        {
            //Forme du chargement :
            //TYPE; NOM; DESCRIPTION; ETAT; DUREE; ADD, FOIS; HEURE1; HEURE2; HEUREN
            //etat[travail, matin, midi, soir, dormir]
            var path = @"actions.csv"; 
            using (var reader = new StreamReader(path))
            {


                while (!reader.EndOfStream)
                {
                    // Read current line fields, pointer moves to the next line.
                    string line = reader.ReadLine();
                    if(!string.IsNullOrWhiteSpace(line)) { 
                        string[] fields = line.Split(';');
                        TimeSpan[] plageHoraire = new TimeSpan[30];
                        int j = 0;
                        for(int i = 7; i < fields.Length;i++)
                        {
                            if (!string.IsNullOrWhiteSpace(fields[j]))
                            {
                                plageHoraire[j] = TimeSpan.Parse(fields[i]);
                                j++; 
                            }
                        }
                        string nom = fields[1];
                        string desc = fields[2];
                        TimeSpan duree = TimeSpan.Parse(fields[4]);
                        double addGlyc = double.Parse(fields[5].Split(',')[0], CultureInfo.InvariantCulture);
                        double foisGlyc = double.Parse(fields[5].Split(',')[1], CultureInfo.InvariantCulture);
                        double stress = double.Parse(fields[6], CultureInfo.InvariantCulture);

                        AddAction(new Actions(nom, desc, duree, new Tuple<double, double>(addGlyc, foisGlyc), stress,plageHoraire));
                    }
                }
            }


           
            IHM.IHM_Actions.LoadAction();
        }


        /// <summary>
        /// Charge tous les évènements possible
        /// </summary>
        public void chargerEvenement()
        {

            //Forme du chargement :
            //NOM; DESCRIPTION; ETAT; DUREE; ADD, FOIS; CHANCE; BLOQUANT; HEURE1; HEURE2; HEUREN
            //etat[travail, matin, midi, soir, dormir]
            var path = @"events.csv";
            using (var reader = new StreamReader(path))
            {


                while (!reader.EndOfStream)
                {
                    // Read current line fields, pointer moves to the next line.
                    string line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split(';');
                        TimeSpan[] plageHoraire = new TimeSpan[30];
                        int j = 0;
                        for (int i = 8; i < fields.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(fields[j]))
                            {
                                plageHoraire[j] = TimeSpan.Parse(fields[i]);
                                j++;
                            }
                        }
                        string nom = fields[0];
                        string desc = fields[1];
                        TimeSpan duree = TimeSpan.Parse(fields[3]);
                        double addGlyc = double.Parse(fields[4].Split(',')[0], CultureInfo.InvariantCulture);
                        double foisGlyc = double.Parse(fields[4].Split(',')[1], CultureInfo.InvariantCulture);

                        double chance = double.Parse(fields[5], CultureInfo.InvariantCulture);
                        bool bloquant = bool.Parse(fields[6]);
                        double stress = double.Parse(fields[7], CultureInfo.InvariantCulture);

                        m_listEvent.Add(new EvenementsAleatoire(nom, desc, duree, new Tuple<double, double>(addGlyc, foisGlyc), chance, bloquant, stress,plageHoraire), false);
                    }
                }
            }
            
        }





        /// <summary>
        /// On regarde si des évènements aléatoires sont en cours, si oui on effectue leur action
        /// </summary>
        public void UpdateEvenement()
        {
            string descActive = "";
            foreach (var e in m_listEvent)
            {
                if(e.Value)
                {
                    e.Key.duringEvenement();
                    descActive += e.Key.Nom + ": " + e.Key.Desc + "\n";
                }
            }
            IHM.IHM_Actions.SetEvenement(descActive);
        }



        /// <summary>
        /// On regarde si de nouveaux évènements doivent se lancer ou si d'anciens doivent s'arreter
        /// </summary>
        /// <param name="temps">Heure actuel</param>
        public void CalcEvenement(TimeSpan temps)
        {
            Random r = new Random();
            for (int i = 0; i < m_listEvent.Count; i++)
            {
                var e = m_listEvent.ElementAt(i);

                if (!e.Value) //Si l'évènement n'est pas encore lancé
                {
                    if (e.Key.isTempsDansPlage(temps))
                    {

                        int ra = r.Next(0, 10001);
                        Console.WriteLine(e.Key.Nom + ": " + ra) ;
                        if (ra <= e.Key.ChanceInit* 100)//on fait un aléatoire
                        {
                            //On lance l'évènement
                            m_listEvent[e.Key] = true;
                            e.Key.makeEvenement(temps);
                        }
                    }
                }
                else //sinon on regarde si il faut l'arreter
                {
                    if(temps > e.Key.EndTime)
                    {
                        m_listEvent[e.Key] = false;
                    }
                }
            }
        }




        /// <summary>
        /// Renvoie l'instance du controlleur actuel
        /// </summary>
        /// <returns>instance du controlleur</returns>
        public static ActionControlleur getInstance()
        {
            return m_actionControlleurInstance;
        }




    }
}
