using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers
{
    class Partie
    {
        //Attributs
        private static Joueur m_j;

        private DateTime m_d = new DateTime(); /**< Date de la partie */

        private Stylo m_s = new Stylo(); /**< Stylo d'insuline */
        public Stylo s
        {
            get { return m_s; }
            set { m_s = value; }
        }

        private Gestionnaires.ActionControlleur m_ac;

        private Temps m_t; /**< Temps de la journée */

        


       //Fonctions

        public void AddDay()
        {
            m_d.AddDays(1);
        }

        public void EffectuerAction(string nom)
        {
            Actions actu;
            foreach(Actions a in m_ac.ListActions()) {
                if (a.Nom() == nom)
                {
                    actu = a;
                    break;
                }
            }
        }

        public void Demarrer()
        {
            //Met en place le temps.
            m_t = Temps.getInstance();
            m_t.StartTime(this);
            //Met en place les actions.
            //m_ac = Gestionnaires.ActionControlleur.getInstance();
            IHM.IHM_Joueur.setJoueur(m_j);
        }

    }
}
