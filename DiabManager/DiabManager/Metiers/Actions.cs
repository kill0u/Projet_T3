using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers
{
    /** La classe définissant les actions disponibles.
     * Cette classe définit les composants de base pour une action. Cette classe sera hérité par d'autre actions pour une définition plus rigoureuse
     * @author Geoffrey Kugelmann
     * @version 1
     */
    class Actions
    {
        /** Nom de l'action.
         * Le nom de l'action, la décrivant, et permettant de la décrire
         */ 
        private string m_nom;
        public string Nom
        {
            get { return m_nom; }
        }

        /** Description sur l'action.
         * Description longue de l'action
         */ 
        private string m_description;
        public string Desc
        {
            get { return m_description;  }
        }

        /** Temps pris par l'action.
         * Chaque action prends du temps à se faire
         */ 
        private TimeSpan m_duree;

        /** L'action modifie la glycémie d'un certain montant
         * Multiplie la glycémie par ce nombre
         */ 
        private double m_modifGlycemie;
        public double ModifGlycemie
        {
            get { return m_modifGlycemie; }
        }

        /** L'action modifie la glycémie d'un certain montant
         * additionne la glycémie par ce nombre
         */
        private double m_addGlycemie;
        public double AddGlycemie
        {
            get { return m_addGlycemie; }
        }

        /// <summary>
        /// Définit la plage horaire de disponibilités pour une action
        /// </summary>
        /// La plage horaire est définit sur un tableau à deux dimensions, la premiere pour le nombre de plage possible, et la deuxième de taille 2 pour avoir deux bornes
        private TimeSpan[,] m_plageHoraire;

        /// <summary>
        /// Définit le nombre de plage horaire pour l'action 
        /// </summary>
        private int m_nbHoraire;


        /// <summary>
        /// Constructeur d'une action
        /// </summary>
        /// <param name="nom">Nom de l'action</param>
        /// <param name="description">Description longue de l'action</param>
        /// <param name="duree">Durée de l'action</param>
        /// <param name="glycemie">Modification de la glycémie (addition et multiplication)</param>
        /// <param name="values">Plage horaire, couple de valeurs</param>
        /// Déclarer une action (nom, description, durée, modif de glycémie, plage horaire, composée de 2 valeurs)
        public Actions(string nom, string description, TimeSpan duree, Tuple<double, double> glycemie, params TimeSpan[] values) 
        {
            m_nom = nom;
            m_description = description;
            m_duree = duree;
            m_modifGlycemie = glycemie.Item2;
            m_addGlycemie = glycemie.Item1;

            m_nbHoraire = values.Length / 2;

            m_plageHoraire = new TimeSpan[m_nbHoraire, 2];
            int j = 0;
            for(int i = 0; i < m_nbHoraire; i++)
            {
                m_plageHoraire[i, 0] = values[j];
                j++;
                m_plageHoraire[i, 1] = values[j];
                j++;
            }
        }

        /// <summary>
        /// Regarde si une heure est compris dans une plage horaire
        /// </summary>
        /// <param name="temps">Heure actuelle de la journée</param>
        /// <returns>
        /// L'heure actuelle est dans la plage horaire (true) ou non (false)
        /// </returns>
        /// Parcourt la plage horaire de l'action, et pour chacune, regarde si l'heure actuelle correspond
        public bool isTempsDansPlage(TimeSpan temps)
        {
            TimeSpan heure = new TimeSpan(temps.Hours, temps.Minutes, temps.Seconds);
            for (int i = 0; i < m_nbHoraire; i++)
            {
                if (heure >= m_plageHoraire[i, 0] && heure < m_plageHoraire[i, 1])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Effectue l'action
        /// </summary>
        /// Lorsqu'on clique sur un bouton, on effectue l'action correspondante, dépendant du type de l'action
        public void makeAction()
        {

            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(m_addGlycemie, m_modifGlycemie));
            Temps.getInstance().addTime(m_duree);

        }
    }
}
