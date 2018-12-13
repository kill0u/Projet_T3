using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Composants;
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
                SetAction(new ActionPanel(action));
                //On notifie action controlleur qu'un action s'est lancé
                m_actionControlleur.ActionActive = action;
                //Réalise le code de l'action
                action.makeAction(Temps.getInstance().getHeureJournee());
            }
        }

        /// <summary>
        /// Met à jour l'évènement actuel
        /// </summary>
        /// <param name="desc">The desc.</param>
        public static void SetEvenement(List<ActionPanel> pan)
        {
            m_frm.setEvenement(pan);
        }

        /// <summary>
        /// Met à jour l'action actuelle
        /// </summary>
        /// <param name="desc">The desc.</param>
        public static void SetAction(ActionPanel pan)
        {
            m_frm.setAction(pan);
        }

        /// <summary>
        /// Enlève l'action active
        /// </summary>
        public static void RemoveAction()
        {
            m_frm.removeAction();
        }

        /// <summary>
        /// Charge les boutons de toutes les actions
        /// </summary>
        public static void LoadAction(Dictionary< Actions, string> listTab)
        {
            m_frm.loadActions(m_actionControlleur.ListActions, listTab);
        }

        /// <summary>
        /// Met à jour l'heure de la journée
        /// </summary>
        /// <param name="temps">Heure actuelle de la journée</param>
        public static void updateTemps(TimeSpan temps)
        {
            m_frm.setTemps(temps);
        }

        /// <summary>
        /// Ajoute l'action ou l'évènement au journal
        /// </summary>
        /// <param name="l">Description de l'action</param>
        public static void addLog(string l)
        {
            m_frm.addLog(l);
        }
    }
}
