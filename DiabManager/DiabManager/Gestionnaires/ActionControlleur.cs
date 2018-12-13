using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Metiers;
using DiabManager.Metiers.ListeActions;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using DiabManager.Composants;

namespace DiabManager.Gestionnaires
{
    /**Classe contrôlant les actions disponibles.
     * Cette classe stocke toutes les actions possibles, et fait le lien avec le temps (autorise notamment certaines actions à certains moments)
     * @author Geoffrey Kugelmann
     * @version 1
     */
    class ActionControlleur
    {
        /**Singleton de la classe ActionControlleur.
         * Garde la référence à la classe ActionControlleur active (afin de n'avoir qu'une instance de temps en même temps)
         */
        private static ActionControlleur m_actionControlleurInstance;

        /**Liste de toutes les actions lancées actuellement.
         * Liste les actions possibles pour l'utilisateur, avec pour valeur vrai si l'utilisateur peut les faire
         */ 
        private Dictionary<Actions, bool> m_listActions = new Dictionary<Actions, bool>();
        public Dictionary<Actions, bool> ListActions
        {
            get { return new Dictionary<Actions, bool>(m_listActions); }
        }

        /**Liste de toutes les événements possibles pour le joueur actuellement.
         * Liste les évènements possibles pour l'utilisateur <see cref="EvenementsAleatoires"/>, avec pour valeur vrai si l'évènement est possible pour le joueur
         */
        private Dictionary<EvenementsAleatoire, bool> m_listEvent = new Dictionary<EvenementsAleatoire, bool>();
        public Dictionary<EvenementsAleatoire, bool> listEvent
        {
            get { return new Dictionary<EvenementsAleatoire, bool>(m_listEvent); }
        }

        /// <summary>
        /// Référence vers la classe temps
        /// </summary>
        private Temps m_temps = Temps.getInstance();

        /// <summary>
        /// Référence vers l'action active en ce moment
        /// </summary>
        private Actions m_actionActive = null;
        public Actions ActionActive { set { m_actionActive = value; } }

        /// <summary>
        /// Constructeur privé, pour éviter une instanciation de <see cref="ActionControlleur"/> .
        /// </summary>
        private ActionControlleur()
        {

        }

        /**Ajoute une action.
         * Chaque action possible pour l'utilisateur doit être ajoutée dans le controlleur
         * @param a Action possible pour l'utilisateur
         */ 
        public void AddAction(Actions a)
        {
            m_listActions.Add(a, false);
        }

        /// <summary>
        /// Met à jour les actions disponibles
        /// </summary>
        /// <param name="temps">Le temps.</param>
        /// Les actions disponibles dépendent des heures de la journée, cette fonction regarde toutes les actions, et met à jour m_listActions
        public void UpdateAction(TimeSpan temps)
        {

            for(int i = 0; i < m_listActions.Count; i++)
            {
                var a = m_listActions.ElementAt(i);

                if (a.Key.isCompatible(IHM.IHM_Joueur.getJoueur())) //On vérifie que l'état le permet
                {
                    if (a.Key.isTempsDansPlage(temps)) //On vérifie si le temps est compatible
                    {
                        m_listActions[a.Key] = true;
                    }
                    else
                    {
                        m_listActions[a.Key] = false;
                    }
                } 
            }

            IHM.IHM_Actions.UpdateButton();

        }

        /// <summary>
        /// On regarde si une action est en cours, si oui on effectue son effet
        /// </summary>
        public void DuringAction()
        {
            if (m_actionActive != null)
            {
                m_actionActive.duringAction();

                if (m_actionActive.isFinished(m_temps.getHeureJournee())) //On regarde si l'action est finie
                {
                    m_actionActive = null;
                    m_temps.swapAction();
                }
                   
            }
               
        }

        /// <summary>
        /// Charge toutes les actions disponibles, depuis un fichier de configuration
        /// </summary>
        public void chargerAction()
        {
            Dictionary< Actions, string> listTab = new Dictionary<Actions, string>();
            //Forme du chargement :
            //TYPE; NOM; DESCRIPTION; ETAT; DUREE; ADD, FOIS; HEURE1; HEURE2; HEUREN
            //etat[travail, matin, midi, soir, dormir]
            var path = @"actions.csv"; 
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    //Lecture de la ligne courante
                    string line = reader.ReadLine();
                    if(!string.IsNullOrWhiteSpace(line)) { 
                        string[] fields = line.Split(';');
                        Actions a;
                        if (fields[0] == "Nourriture")
                        {
                            a = Nourriture.readAction(fields);
                            AddAction(a);
                            
                        }
                        else if(fields[0] == "Sport")
                        {
                            a = Sport.readAction(fields);
                            AddAction(a);
                        }
                        else
                        {
                            a = Actions.readAction(fields);
                            AddAction(a);
                        }
                        listTab.Add(a, fields[0]);
                    }
                }
            }
            IHM.IHM_Actions.LoadAction(listTab);
        }

        /// <summary>
        /// Charge tous les évènements possible
        /// </summary>
        public void chargerEvenement()
        {

            //Forme du chargement :
            //NOM; DESCRIPTION; ETAT; DUREE; ADD, FOIS; CHANCE; BLOQUANT; HEURE1; HEURE2; HEUREN
            //etat[travail, matin, midi, soir, dormir]
            var path = @"events.csv";
            using (var reader = new StreamReader(path))
            {


                while (!reader.EndOfStream)
                {
                    //Lecture de la ligne courante
                    string line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split(';');
                        

                        m_listEvent.Add(EvenementsAleatoire.readAction(fields), false);
                    }
                }
            }
            
        }

        /// <summary>
        /// On regarde si des évènements aléatoires sont en cours, si oui on effectue leur action
        /// </summary>
        public void UpdateEvenement()
        {
            List<ActionPanel> list = new List<ActionPanel>();
            foreach (var e in m_listEvent)
            {
                if(e.Value)
                {
                    e.Key.duringAction();
                    list.Add(new ActionPanel(e.Key));
                }
            }
            IHM.IHM_Actions.SetEvenement(list);
        }
        
        /// <summary>
        /// On regarde si de nouveaux évènements doivent se lancer ou si d'anciens doivent s'arrêter
        /// </summary>
        /// <param name="temps">Heure actuelle</param>
        public void CalcEvenement(TimeSpan temps)
        {
            Random r = new Random();
            for (int i = 0; i < m_listEvent.Count; i++)
            {
                var e = m_listEvent.ElementAt(i);

                if (!e.Value) //Si l'évènement n'est pas encore lancé
                {
                    //Si l'etat le permet
                    if(e.Key.isCompatible(IHM.IHM_Joueur.getJoueur()))
                    {
                        if (e.Key.isTempsDansPlage(temps))
                        {

                            int ra = r.Next(0, 10001);
                            double chance = e.Key.ChanceInit * 100f;
                            //On regarde la personnalité du joueur, et on adapte les chances des évènements selon les stats actuelles du joueur
                            foreach (var charac in IHM.IHM_Joueur.getJoueur().Personalite)
                            {
                                if (e.Key.ChanceCharac.ContainsKey(charac))
                                {
                                    var tuple = e.Key.ChanceCharac[charac];
                                    //Case 0 --> Energie
                                    if (tuple[0].Item1 < 101)
                                        if ((tuple[0].Item1 < 0 && tuple[0].Item1 > IHM.IHM_Joueur.getJoueur().Energie) || (tuple[0].Item1 > 0 && tuple[0].Item1 < IHM.IHM_Joueur.getJoueur().Energie) )
                                            if (tuple[0].Item2 * 100 > chance)
                                                chance = tuple[0].Item2 * 100;
                                    //Case 1 --> Stress
                                    if (tuple[1].Item1 < 101)
                                        if ((tuple[1].Item1 < 0 && tuple[1].Item1 > IHM.IHM_Joueur.getJoueur().Stress) || (tuple[1].Item1 > 0 && tuple[1].Item1 < IHM.IHM_Joueur.getJoueur().Stress))
                                            if (tuple[1].Item2 * 100 > chance)
                                                chance = tuple[1].Item2 * 100;
                                    //Case 2 --> Glycémie
                                    if (tuple[2].Item1 < 101)
                                        if ((tuple[2].Item1 < 0 && tuple[2].Item1 > IHM.IHM_Joueur.getJoueur().GlycemieCourante) || (tuple[2].Item1 > 0 && tuple[2].Item1 < IHM.IHM_Joueur.getJoueur().GlycemieCourante))
                                            if (tuple[2].Item2 * 100 > chance)
                                                chance = tuple[2].Item2 * 100;
                                }
                            }

                            if (ra <= chance)//on fait un aléatoire
                            {
                                //On lance l'évènement
                                m_listEvent[e.Key] = true;
                                e.Key.makeAction(temps);
                            }
                        }
                    }
                    
                }
                else //sinon on regarde si il faut l'arreter
                {
                    if(temps > e.Key.EndTime) //Si le temps est fini
                    {
                        m_listEvent[e.Key] = false;
                        //Si on arrête un event, on enlève le statut de maladie si il y est encore
                        if (IHM.IHM_Joueur.getJoueur().Etat[1] == 1)
                            IHM.IHM_Joueur.getJoueur().Etat[1] = 0;

                        //si l'événement est bloquant
                        if (e.Key.isBloquant)
                        {
                            m_temps.swapAction();
                        }
                    }
                    //Si la personne est soignée après une maladie
                    if(IHM.IHM_Joueur.getJoueur().Etat[1] == 0 && e.Key.EtatFinalCharac.First().Value[5] == 1)
                    {
                        m_listEvent[e.Key] = false;
                    }

                }
            }
        }

        /// <summary>
        /// Renvoie l'instance du contrôleur actuel
        /// </summary>
        /// <returns>Instance du contrôleur</returns>
        public static ActionControlleur getInstance()
        {
            if (m_actionControlleurInstance == null)
                m_actionControlleurInstance = new ActionControlleur();
            return m_actionControlleurInstance;
        }

        /// <summary>
        /// Détruit le contrôleur (pour pouvoir redémarrer)
        /// </summary>
        public static void destroyInstance()
        {
            m_actionControlleurInstance = null;
        }
    }
}
