﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Metiers;
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
         * Liste les actions possibles pour l'utilisateurs, avec pour valeur si l'utilisateur peut les faire
         */ 
        private Dictionary<Actions, bool> m_listActions = new Dictionary<Actions, bool>();
        public Dictionary<Actions, bool> ListActions
        {
            get { return new Dictionary<Actions, bool>(m_listActions); }
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

        /// <summary>Charge toutes les actions disponibles</summary>
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
                        for(int i = 6; i < fields.Length;i++)
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

                        AddAction(new Actions(nom, desc, duree, new Tuple<double, double>(addGlyc, foisGlyc), plageHoraire));
                    }
                }
            }


            //AddAction(new Actions("Manger", "Aller manger", new TimeSpan(0, 30, 0), new Tuple<double,double>(0.2, 1), new TimeSpan(7, 0, 0), new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), new TimeSpan(18, 0, 0), new TimeSpan(22, 0, 0)));
            //AddAction(new Actions("Sport", "Faire du sport", new TimeSpan(1, 30, 0), new Tuple<double, double>(-0.2, 1), new TimeSpan(0, 0, 0), new TimeSpan(23, 0, 0)));


            IHM.IHM_Actions.LoadAction();
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
