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
        /// <summary>
        /// Référence vers le gestionnaire d'action
        /// </summary>
        private static Gestionnaires.ActionControlleur m_actionControlleur = Gestionnaires.ActionControlleur.getInstance();

        /// <summary>
        /// Référence vers le formulaire de jeu
        /// </summary>
        private static frmJeu m_frm;

        /// <summary>
        /// Met à jour le formulaire utilisé actuellement
        /// </summary>
        /// <param name="frm">le formulaire</param>
        public static void setForm(frmJeu frm)
        {
            m_frm = frm;
        }

        /// <summary>
        /// Met à jour les informations des actions
        /// </summary>
        public static void Update()
        {
        }

        /// <summary>
        /// Met à jour l'affichage des boutons des actions
        /// </summary>
        public static void UpdateButton()
        {
            m_frm.setActiveButton(m_actionControlleur.ListActions);
        }

        /// <summary>
        /// Transforme le nom de l'action (du bouton) en l'action en question
        /// </summary>
        /// <param name="nom">Nom de l'action</param>
        public static void EffectuerAction(string nom)
        {
            //on regarde qu'il n'y est pas déjà une action en cours
            if(!Temps.getInstance().isActionEnCours)
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
                SetAction(action.Nom + ": " + action.Desc);
                //Réalise le code de l'action
                action.makeAction();
            }
        }

        /// <summary>
        /// Met à jour l'évènement actuel
        /// </summary>
        /// <param name="desc">The desc.</param>
        public static void SetEvenement(string desc)
        {
            m_frm.setEvenement(desc);
        }

        /// <summary>
        /// Met à jour l'action actuelle
        /// </summary>
        /// <param name="desc">The desc.</param>
        public static void SetAction(string desc)
        {
            m_frm.setAction(desc);
        }

        /// <summary>
        /// Charge les boutons de toutes les actions
        /// </summary>
        public static void LoadAction()
        {
            m_frm.loadActions(m_actionControlleur.ListActions);
        }

        /// <summary>
        /// Met à jour l'heure de la journée
        /// </summary>
        /// <param name="temps">Heure actuelle de la journée</param>
        public static void updateTemps(TimeSpan temps)
        {
            m_frm.setTemps(temps);
        }
    }
}
