using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        protected string m_nom;
        public string Nom
        {
            get { return m_nom; }
        }

        /** Description sur l'action.
         * Description longue de l'action
         */ 
        protected string m_description;
        public string Desc
        {
            get { return m_description;  }
        }

        /** Temps pris par l'action.
         * Chaque action prends du temps à se faire
         */ 
        protected TimeSpan m_duree;


        /// <summary>
        /// Heure de fin de l'action (calculer en additionnant la durée et l'heure de début de l'évènement)
        /// </summary>
        protected TimeSpan m_endTime;
        public TimeSpan EndTime { get { return m_endTime; } }


        /// <summary>
        /// Définit la plage horaire de disponibilités pour une action
        /// </summary>
        /// La plage horaire est définit sur un tableau à deux dimensions, la premiere pour le nombre de plage possible, et la deuxième de taille 2 pour avoir deux bornes
        protected TimeSpan[,] m_plageHoraire;

        /// <summary>
        /// Définit le nombre de plage horaire pour l'action 
        /// </summary>
        protected int m_nbHoraire;



        /// <summary>
        /// Etat nécessaire pour réaliser l'action
        /// </summary>
        /// Case 0: Energie nécessaire
        /// Pour le reste des cases, on a : 
        /// - 0 --> le joueur ne doit pas avoir cette caractéristique active
        /// - 1 --> le joueur peut avoir cette caractéristique active
        /// - 2 --> le joueur doit avoir cette caractéristique active
        /// Case 1: Ne fais rien
        /// Case 2: Est malade
        /// Case 3: Est au travail
        protected double[] m_etatInitial = new double[4];


        /// <summary>
        /// Etat final après avoir réalisé l'action
        /// </summary>
        /// Case 0: Perte d'énergie (entre -100 et 100 --> -100 on augmente de 100 l'énergie, et 100 on diminue de 100)
        /// Case 1: Glycémie --> Multiplie la glycémie par ce nombre
        /// Case 2: Glycémie --> Additionne la glycémie par ce nombre
        /// Case 3: Stress --> Additionne le stress par ce nombre
        /// Pour le reste des cases, on a : 
        /// - 0 --> le joueur n'est pas dans cette état
        /// - 1 --> le joueur est dans cette état
        /// - 2 --> le joueur reste dans l'état dans lequel il était avant
        /// Case 4: Ne fais rien
        /// Case 5: Est malade
        /// Case 6: Est au travail
        protected Dictionary<string, double[]> m_etatFinalCharac = new Dictionary<string, double[]>();
        public Dictionary<string, double[]> EtatFinalCharac
        {
            get { return m_etatFinalCharac; }
        }


        /// <summary>
        /// Les jours où l'évènement peut se passer
        /// </summary>
        /// 0 --> lundi
        /// 1 --> mardi
        /// 2 --> mercredi
        /// 3 --> jeudi
        /// 4 --> vendredi
        /// 5 --> samedi
        /// 6 --> dimanche
        protected bool[] m_jour = new bool[7];

        protected string m_url = "";
        public string Url { get { return m_url; } }

        /// <summary>
        /// Constructeur d'une action
        /// </summary>
        /// <param name="nom">Nom de l'action</param>
        /// <param name="description">Description longue de l'action</param>
        /// <param name="duree">Durée de l'action</param>
        /// <param name="etatInitial">Etat initial nécessaire pour l'action</param>
        /// <param name="etatFinal">Etat du joueur après l'action</param>
        /// <param name="values">Plage horaire, couple de valeurs</param>
        /// Déclarer une action (nom, description, durée, modif de glycémie, stress, plage horaire, composée de 2 valeurs)
        public Actions(string nom, string description, TimeSpan duree, double[] etatInitial,Dictionary<string, double[]> etatFinal, bool[] jours, string url, params TimeSpan[] values) 
        {
            m_nom = nom;
            m_description = description;
            m_duree = duree;

            m_etatInitial = etatInitial;

            m_etatFinalCharac = etatFinal;

            m_nbHoraire = values.Length / 2;

            m_plageHoraire = new TimeSpan[m_nbHoraire, 2];
            int j = 0;
            for(int i = 0; i < m_nbHoraire; i++)
            {
                m_plageHoraire[i, 0] = values[j];
                j++;
                m_plageHoraire[i, 1] = values[j];
                j++;
            }

            m_jour = jours;

            m_url = url;
        }

        /// <summary>
        /// Regarde si une heure est compris dans une plage horaire et si le jours correspond
        /// </summary>
        /// <param name="temps">Heure actuelle de la journée</param>
        /// <returns>
        /// L'heure actuelle est dans la plage horaire (true) ou non (false)
        /// </returns>
        /// Parcourt la plage horaire de l'action, et pour chacune, regarde si l'heure actuelle correspond
        public bool isTempsDansPlage(TimeSpan temps)
        {
            for (int i = 0; i < m_jour.Length; i++)
            {
                if (!m_jour[i] && temps.Days % 7 == i)
                    return false;
            }
            TimeSpan heure = new TimeSpan(temps.Hours, temps.Minutes, temps.Seconds);
            for (int i = 0; i < m_nbHoraire; i++)
            {
                if (heure >= m_plageHoraire[i, 0] && heure < m_plageHoraire[i, 1])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Effectue l'action
        /// </summary>
        /// Lorsqu'on clique sur un bouton, on effectue l'action correspondante, dépendant du type de l'action
        public void makeAction(TimeSpan start)
        {
            m_endTime = start.Add(m_duree);

            
            //On mets à jour son etat
            for (int i = 0; i < IHM.IHM_Joueur.getJoueur().Etat.Length; i++)
            {
                foreach (var charac in IHM.IHM_Joueur.getJoueur().Personalite)
                {

                    if (m_etatFinalCharac.ContainsKey(charac))
                    {
                        if (m_etatFinalCharac[charac][i + 4] != 2) //on ne change l'etat du joueur que s'il le faut
                            IHM.IHM_Joueur.getJoueur().Etat[i] = m_etatFinalCharac[charac][i + 4]; 
                    }

                }
            }
            //On ajoute au log
            string log = "---------------------------------------------" + Environment.NewLine;
            log += m_nom + ":" + Environment.NewLine;
            log += m_description + Environment.NewLine;
            log += "Durée: " + m_duree.ToString() + Environment.NewLine;
            log += "---------------------------------------------" + Environment.NewLine;

            IHM.IHM_Actions.addLog(log);

            Temps.getInstance().swapAction();

        }

        public bool isFinished(TimeSpan temps)
        {
            return m_endTime < temps;
                
        }

        public void duringAction()
        {
            double mGlycAdd = 0;
            double mGlycMult = 0;
            double mStress= 0 ;
            double mEnergie = 0;
            //On calcule la moyenne selon son charactère
            foreach (var charac in IHM.IHM_Joueur.getJoueur().Personalite)
            {
                mEnergie += m_etatFinalCharac[charac][0];
                mGlycMult += m_etatFinalCharac[charac][1];
                mGlycAdd += m_etatFinalCharac[charac][2];
                mStress += m_etatFinalCharac[charac][3];
            }

            mEnergie /= IHM.IHM_Joueur.getJoueur().Personalite.Length;
            mGlycMult /= IHM.IHM_Joueur.getJoueur().Personalite.Length;
            mGlycAdd /= IHM.IHM_Joueur.getJoueur().Personalite.Length;
            mStress /= IHM.IHM_Joueur.getJoueur().Personalite.Length;

            //On modifie les données du joueur 
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(mGlycAdd, mGlycMult));
            IHM.IHM_Joueur.getJoueur().calculStress(mStress);
            IHM.IHM_Joueur.getJoueur().calculEnergie(mEnergie);

        }

        /// <summary>
        /// Charge l'action depuis un la ligne du fichier
        /// </summary>
        /// <param name="fields">Ligne du fichier</param>
        /// <returns>L'action créée</returns>
        public static Actions readAction(string[] fields)
        {

            string ef = Regex.Replace(fields[5], @"[\[\]]+", string.Empty);
            string[] efS = ef.Split(',');
            bool[] jours = new bool[7];
            for (int i = 0; i < efS.Length; i++)
                jours[i] = efS[i] == "1";

            string url = fields[6];

            Dictionary<string, double[]> etatFinal = new Dictionary<string, double[]>();
            int k = 7;
            while (fields[k].Contains(":["))
            {            
                string nomCharac = fields[k].Split(':')[0];
                ef = Regex.Replace(fields[k].Split(':')[1], @"[\[\]]+", string.Empty);
                efS = ef.Split(',');
                double[] carac = new double[efS.Length];
                for (int i = 0; i < efS.Length; i++)
                     carac[i] = double.Parse(efS[i], CultureInfo.InvariantCulture);
                etatFinal.Add(nomCharac, carac);
                k++;
            }

            TimeSpan[] plageHoraire = new TimeSpan[30];
            int j = 0;
            for (int i = k; i < fields.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(fields[j]))
                {
                    plageHoraire[j] = TimeSpan.Parse(fields[i]);
                    j++;
                }
            }
            string nom = fields[1];
            string desc = fields[2];
            TimeSpan duree = TimeSpan.Parse(fields[3]);

            //On lit les deux tableaux (etat initial et final)
            double[] etatInital = new double[4];
            string ei = Regex.Replace(fields[4], @"[\[\]]+", string.Empty);
            string[] eiS = ei.Split(',');
            for (int i = 0; i < eiS.Length; i++)
                etatInital[i] = double.Parse(eiS[i], CultureInfo.InvariantCulture);

            

            
            
                

            return new Actions(nom, desc, duree, etatInital, etatFinal, jours, url, plageHoraire);
        }

        public bool isCompatible(Joueur j)
        {
            if (m_etatInitial[0] > j.Energie) //Vérifie l'energie
                return false;
            for(int i = 0; i < j.Etat.Length; i++) //Vérifie tous les états du joueur
            {
                if ((m_etatInitial[i+1] == 0 && j.Etat[i] == 1) || (m_etatInitial[i+1] == 2 && j.Etat[i] == 0))
                    return false;
            }
            

            return true;
        }
    }
}
