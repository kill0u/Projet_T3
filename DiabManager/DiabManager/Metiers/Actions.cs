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

        /** Temps pris par l'action.
         * Chaque action prends du temps à se faire
         */ 
        private TimeSpan m_temps;

        /** L'action modifie la glycémie d'un certain montant
         */ 
        private float m_modifGlycemie;



        public Actions(string nom, string description, TimeSpan temps, float modifGlycemie) //plage horaire
        {
            m_nom = nom;
            m_description = description;
            m_temps = temps;
            m_modifGlycemie = modifGlycemie;
        }
    }
}
