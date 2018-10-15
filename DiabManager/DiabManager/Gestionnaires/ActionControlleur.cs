using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Metiers;

namespace DiabManager.Gestionnaires
{
    /**Classe controllant les actions disponibles.
     * Cette classe stocke toutes les actions possibles, et fait le lien avec le temps (autorise notamment certaines actions à certains moments)
     * @author Geoffrey Kugelmann
     * @version 1
     */
    class ActionControlleur
    {
        /**Singleton de la classe ActionControlleur.
         * Garde la référence à la classe ActionControlleur active (afin de n'avoir qu'une instance de temps en même temps)
         */
        private static ActionControlleur m_actionControlleurInstance = new ActionControlleur();

        /** Liste de toutes les actions lancés actuellement.
         * Liste les actions possibles pour l'utilisateurs, avec pour valeur si l'utilisateur peut les faire
         */ 
        private Dictionary<Actions, bool> m_listActions = new Dictionary<Actions, bool>();
        public Dictionary<Actions, bool> ListActions
        {
            get { return new Dictionary<Actions, bool>(m_listActions); }
        }

        /// <summary>
        /// Référence vers la classe temps
        /// </summary>
        private Temps m_temps = Temps.getInstance();

        private ActionControlleur()
        {

        }


        /** Ajoute une action.
         * Chaque action possible pour l'utilisateur doit être ajouter dans le controlleur
         * @param a Action possible pour l'utilisateur
         */ 
        public void AddAction(Actions a)
        {
            m_listActions.Add(a, false);
        }

        /// <summary>
        /// Mets à jour les actions disponibles
        /// </summary>
        /// Les actions disponibles dépendent des heures de la journée, cette fonction regarde toutes les actions, et mets à jour m_listActions
        public void UpdateAction(TimeSpan temps)
        {
            foreach(var a in m_listActions)
            {
                if(a.Key.isTempsDansPlage(temps))
                {
                    m_listActions[a.Key] = true;
                }
                else
                {
                    m_listActions[a.Key] = false;
                }
            }
        }


        /** Renvoie l'instance ddu controlleur actuel
         * @return instance du controlleur
         */
        public static ActionControlleur getInstance()
        {
            return m_actionControlleurInstance;
        }




    }
}
