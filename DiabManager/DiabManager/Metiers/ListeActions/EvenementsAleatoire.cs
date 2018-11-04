using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers.ListeActions
{
    /// <summary>
    /// 
    /// </summary>
    class EvenementsAleatoire
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
            get { return m_description; }
        }

        /** Temps pris par l'action.
         * Chaque action prends du temps à se faire
         */
        private TimeSpan m_duree;

        private TimeSpan m_endTime;
        public TimeSpan EndTime {  get { return m_endTime; } }


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
        /// Probabilité que l'évènement apparaisse
        /// </summary>
        private double m_chanceInit;
        public double ChanceInit
        {
            get { return m_chanceInit; }
        }

        private bool m_bloquant;



        /// <summary>
        /// Constructeur de la classe EvenementsAleatoire
        /// </summary>
        /// <param name="nom">Nom de l'évènement</param>
        /// <param name="description">Desciption de l'évènement</param>
        /// <param name="duree">Durée de l'évènements (ex: sortie au bar --&gt; 5h)</param>
        /// <param name="glycemie">Tuple de modification de la glycémie (1: de combien on ajoute, 2: de combien on multiplie)</param>
        /// <param name="chanceInit">Le pourcentage de chance que l'évènements se déclenche initialement</param>
        /// <param name="bloquant">Si l'évènement lancé bloque toutes les autres actions possibles</param>
        /// Cette classe comporte tous les effets qui peuvent agir le joueur
        public EvenementsAleatoire(string nom, string description, TimeSpan duree, Tuple<double, double> glycemie, double chanceInit, bool bloquant)
        {
            m_nom = nom;
            m_description = description;
            m_duree = duree;
            m_modifGlycemie = glycemie.Item2;
            m_addGlycemie = glycemie.Item1;
            m_chanceInit = chanceInit;
            m_bloquant = bloquant;
        }


        /// <summary>
        /// Fonction se déclenchant lorsque l'évènement est lancé
        /// </summary>
        public void makeEvenement(TimeSpan start)
        {
            m_endTime = start.Add(m_duree);
            //Si l'évènement est bloquant, on passe en vitesse élevé, comme si il s'agissait d'une action
            if(m_bloquant)
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
