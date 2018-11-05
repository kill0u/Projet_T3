using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers.ListeActions
{
    /// <summary>
    /// Classe gérant les évènements aléatoires se produisant dans le jeu
    /// </summary>
    class EvenementsAleatoire
    {
        /** Nom de l'évènement.
         * Le nom de l'évènement permettant de le décrire
         */
        private string m_nom;
        public string Nom
        {
            get { return m_nom; }
        }

        /** Description sur l'évènement.
         * Description longue de l'évènement
         */
        private string m_description;
        public string Desc
        {
            get { return m_description; }
        }

        /** Temps pris par l'évènement.
         * Chaque évènement prends du temps à se faire
         */
        private TimeSpan m_duree;

        /// <summary>
        /// Heure de fin de l'action (calculer en additionnant la durée et l'heure de début de l'évènement)
        /// </summary>
        private TimeSpan m_endTime;
        public TimeSpan EndTime {  get { return m_endTime; } }


        /** L'évènement modifie la glycémie d'un certain montant
         * Multiplie la glycémie par ce nombre
         */
        private double m_modifGlycemie;
        public double ModifGlycemie
        {
            get { return m_modifGlycemie; }
        }

        /** L'évènement modifie la glycémie d'un certain montant
         * additionne la glycémie par ce nombre
         */
        private double m_addGlycemie;
        public double AddGlycemie
        {
            get { return m_addGlycemie; }
        }


        /// <summary>
        /// Probabilité que l'évènement apparaisse
        /// </summary>
        private double m_chanceInit;
        public double ChanceInit
        {
            get { return m_chanceInit; }
        }

        /// <summary>
        /// Décrit si l'action est bloquante (one ne peut pas faire d'autre actions pendant ce temps) ou non
        /// </summary>
        private bool m_bloquant;

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
        /// Constructeur de la classe EvenementsAleatoire
        /// </summary>
        /// <param name="nom">Nom de l'évènement</param>
        /// <param name="description">Desciption de l'évènement</param>
        /// <param name="duree">Durée de l'évènements (ex: sortie au bar --&gt; 5h)</param>
        /// <param name="glycemie">Tuple de modification de la glycémie (1: de combien on ajoute, 2: de combien on multiplie)</param>
        /// <param name="chanceInit">Le pourcentage de chance que l'évènements se déclenche initialement</param>
        /// <param name="bloquant">Si l'évènement lancé bloque toutes les autres actions possibles</param>
        /// <param name="values">Plage horaire</param>
        /// Cette classe comporte tous les effets qui peuvent agir le joueur
        public EvenementsAleatoire(string nom, string description, TimeSpan duree, Tuple<double, double> glycemie, double chanceInit, bool bloquant, params TimeSpan[] values)
        {
            m_nom = nom;
            m_description = description;
            m_duree = duree;
            m_modifGlycemie = glycemie.Item2;
            m_addGlycemie = glycemie.Item1;
            m_chanceInit = chanceInit;
            m_bloquant = bloquant;
            m_nbHoraire = values.Length / 2;

            m_plageHoraire = new TimeSpan[m_nbHoraire, 2];
            int j = 0;
            for (int i = 0; i < m_nbHoraire; i++)
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
        /// Parcourt la plage horaire de l'évènement, et pour chacune, regarde si l'heure actuelle correspond
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
        /// Fonction se déclenchant lorsque l'évènement est lancé
        /// </summary>
        /// <param name="start">Heure de début de l'évènement</param>
        public void makeEvenement(TimeSpan start)
        {
            m_endTime = start.Add(m_duree);

            //Si l'évènement est bloquant, on passe en vitesse élevé, comme si il s'agissait d'une action
            if (m_bloquant)
                Temps.getInstance().addTime(m_duree);
        }

        /// <summary>
        /// Fonction se déclenchant tant que l'événement est actif
        /// </summary>
        public void duringEvenement()
        {
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(m_addGlycemie, m_modifGlycemie));
        }
    }
}
