using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers
{
    class Stylo
    {
        private int m_dose = 80; /**< Dose d'insuline */
        public int dose
        {
            get { return m_dose; }
            set { m_dose = value; }
        }
    }
}
