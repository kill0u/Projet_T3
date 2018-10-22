using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers
{
    class Stylo
    {
        private bool m_disponible;
        public bool Disponible
        {
            get { return m_disponible; }
            set { m_disponible = value; }
        }
        /// <summary>
        /// dose maximale du stylo d'insuline
        /// </summary>
        private const int m_doseMax = 80;
        public int DoseMax
        {
            get { return m_doseActu; }
            set { m_doseActu = value; }
        }
        /// <summary>
        /// dose maximale du stylo d'insuline
        /// </summary>
        private int m_doseActu = 80;
        public int DoseActu
        {
            get { return m_doseActu; }
            set { m_doseActu = value; }
        }
        /// <summary>
        /// dose a injecter du stylo d'insuline
        /// </summary>
        private int m_dose;
        public int dose
        {
            get { return m_dose; }
            set { m_dose = value; }
        }

        /// <summary>
        /// Constructeur du Stylo
        /// </summary>
        public Stylo()
        {
            m_dose = 5;
            m_doseActu = m_doseMax;
        }
        /// <summary>
        /// Fonction resetStylo qui remet a disposition l'injection pour ce jour. 
        /// </summary>
        public void resetStylo()
        {
            //TODO calcul de la prochaine dose à injecter conseillée.
            m_disponible = true;
        }
        /// <summary>
        /// Fonction qui recharge le stylo d'insuline à sa dose maximale.
        /// </summary>
        public void rechargerStylo()
        {
            m_doseActu = m_doseMax;
        }
    }
}
