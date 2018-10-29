using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Metiers;

namespace DiabManager.IHM
{
    /**Classe faisant le lien entre les actions et la fenetre.
     * Cette classe définit les fonctions faisant le lien entre la fenetre du jeu et les actions, ou le controleur d'actions
     * @author Geoffrey Kugelmann
     * @version 1
     */
    class IHM_Actions
    {
        private static Gestionnaires.ActionControlleur m_actionControlleur = Gestionnaires.ActionControlleur.getInstance();

        private static frmJeu m_frm;

        public static void setForm(frmJeu frm)
        {
            m_frm = frm;
        }

        public static void Update()
        {
        }

        public static void UpdateButton()
        {
            m_frm.setActiveButton(m_actionControlleur.ListActions);
        }

        public static void EffectuerAction(string nom)
        {
            IHM_Joueur.Update();

            Actions action = null;
            foreach (var a in m_actionControlleur.ListActions)
            {
                if (a.Key.Nom == nom)
                {
                    action = a.Key;
                    break;
                }
            }
            //Réalise le code de l'action
            action.makeAction();
        }

        public static void LoadAction()
        {
            m_frm.loadActions(m_actionControlleur.ListActions);
        }

        public static void updateTemps(TimeSpan temps)
        {
            m_frm.setTemps(temps);
        }
    }
}
