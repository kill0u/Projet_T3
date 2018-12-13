using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiabManager.Metiers.ListeActions
{
    /// <summary>
    /// Classe gérant les évènements aléatoires se produisant dans le jeu
    /// </summary>
    class EvenementsAleatoire : Actions
    {

        /// <summary>
        /// Pour chaque personnalité du personnage, les chances spéciales qu'apparaissent cette évènement
        /// </summary>
        /// Prends le dessus sur la probabilité basique qu'un évènement apparaisse si la personne possède cette attribut
        /// Pour le tableau de tuple, la première valeur corresponds au taux recherché (glycémie, stress, ...) 
        /// avec un - devant si la valeur doit être inférieur à ce taux pour prendre en compte la nouvelle proba.
        /// Une valeur supérieur à 100 est ignoré.
        /// La deuxième valeur du tuple représente la nouvelle probabilité
        /// Case 0: Energie
        /// Case 1: Stress
        /// Case 2: Glycémie
        private Dictionary<string, Tuple<double, double>[]> m_chanceCharac = new Dictionary<string, Tuple<double, double>[]>();
        public Dictionary<string, Tuple<double, double>[]> ChanceCharac { get { return m_chanceCharac; }   }


        /// <summary>
        /// Probabilité que l'évènement apparaisse
        /// </summary>
        private double m_chanceInit;
        public double ChanceInit
        {
            get { return m_chanceInit; }
        }


        /// <summary>
        /// Décrit si l'action est bloquante (on ne peut pas faire d'autre actions pendant ce temps) ou non
        /// </summary>
        private bool m_bloquant;
        public bool isBloquant { get { return m_bloquant; } }




        /// <summary>
        /// Constructeur de la classe EvenementsAleatoire
        /// </summary>
        /// <param name="nom">Nom de l'évènement</param>
        /// <param name="description">Desciption de l'évènement</param>
        /// <param name="duree">Durée de l'évènements (ex: sortie au bar --&gt; 5h)</param>
        /// <param name="etatInitial">Etat initial nécessaire pour l'action</param>
        /// <param name="etatFinal">Etat du joueur après l'action</param>
        /// <param name="chanceCharac">The chance charac.</param>
        /// <param name="chanceInit">Le pourcentage de chance que l'évènements se déclenche initialement</param>
        /// <param name="bloquant">Si l'évènement lancé bloque toutes les autres actions possibles</param>
        /// <param name="jours">Jours ou l'évènement aléatoire est actif</param>
        /// <param name="url">URL de l'image</param>
        /// <param name="values">Plage horaire</param>
        /// Cette classe comporte tous les effets qui peuvent agir le joueur
        public EvenementsAleatoire(string nom, string description, TimeSpan duree, double[] etatInitial, Dictionary<string,double[]> etatFinal, Dictionary<string, Tuple<double, double>[]> chanceCharac, double chanceInit, bool bloquant,bool[] jours , string url, params TimeSpan[] values): base(nom, description, duree, etatInitial, etatFinal, jours, url, values)
        {

            m_chanceInit = chanceInit;
            m_bloquant = bloquant;

            m_chanceCharac = chanceCharac;
        }



        /// <summary>
        /// Fonction se déclenchant lorsque l'évènement est lancé
        /// </summary>
        /// <param name="start">Heure de début de l'évènement</param>
       public new void makeAction(TimeSpan start)
        {

            //On ajoute au log
            string log = Temps.getInstance().getHeureJournee().Hours + "h" + Temps.getInstance().getHeureJournee().Minutes + "mins ---------------------------------" + Environment.NewLine;
            log += m_nom + ":" + Environment.NewLine;
            log += m_description + Environment.NewLine;
            log += "Durée: " + m_duree.ToString() + Environment.NewLine;
            log += "Glycémie actuelle: " + IHM.IHM_Joueur.getJoueur().GlycemieCourante + Environment.NewLine;
            log += "---------------------------------------------" + Environment.NewLine;

            IHM.IHM_Actions.addLog(log);

            m_endTime = start.Add(m_duree);

            //Si l'évènement est bloquant, on passe en vitesse élevé, comme si il s'agissait d'une action
            if (m_bloquant)
            {
                if (Temps.getInstance().isActionEnCours) //si il y a deja une action, on la remplace
                {
                    Temps.getInstance().swapAction();
                }
                    
                Temps.getInstance().swapAction();

            }


            //On mets à jour son etat
            for (int i = 0; i < IHM.IHM_Joueur.getJoueur().Etat.Length; i++)
            {
                
                if (m_etatFinalCharac["all"][i + 4] != 2) //on ne change l'etat du joueur que s'il le faut
                    IHM.IHM_Joueur.getJoueur().Etat[i] = m_etatFinalCharac["all"][i + 4];
                
            }

        }

        /// <summary>
        /// Cette fonction s'effectue pendant qu'un évènement aléatoire est actif
        /// </summary>
        public new void duringAction()
        {
            //On modifie les données du joueur 
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(m_etatFinalCharac["all"][2], m_etatFinalCharac["all"][1]));
            IHM.IHM_Joueur.getJoueur().calculStress(m_etatFinalCharac["all"][3]);
            IHM.IHM_Joueur.getJoueur().calculEnergie(m_etatFinalCharac["all"][0]);
        }


        /// <summary>
        /// Lit et crée un évènement aléatories dans un fichier
        /// </summary>
        /// <param name="fields">La ligne du fichier concernée</param>
        /// <returns>L'évènement aléatoire</returns>
        public new static EvenementsAleatoire readAction(string[] fields)
        {

            Dictionary<string, double[]> etatFinal = new Dictionary<string, double[]>();
            //On lit les informations sur l'état final
            string nomCharac = fields[6].Split(':')[0];
            string ef = Regex.Replace(fields[6].Split(':')[1], @"[\[\]]+", string.Empty);
            string[] efS = ef.Split(',');
            double[] carac = new double[efS.Length];
            for (int i = 0; i < efS.Length; i++)
                carac[i] = double.Parse(efS[i], CultureInfo.InvariantCulture);
            etatFinal.Add(nomCharac, carac);

            ef = Regex.Replace(fields[7], @"[\[\]]+", string.Empty);
            efS = ef.Split(',');
            bool[] jours = new bool[7];
            for (int i = 0; i < efS.Length; i++)
                jours[i] = efS[i] == "1";

            string url = fields[8];

            Dictionary<string, Tuple<double, double>[]> chanceCharac = new Dictionary<string, Tuple<double, double>[]>();
            int k = 9;
            while (fields[k].Contains(":["))
            {
                nomCharac = fields[k].Split(':')[0];
                ef = Regex.Replace(fields[k].Split(':')[1], @"[\[\]]+", string.Empty);
                efS = ef.Split('/');
                Tuple<double, double>[] car = new Tuple<double, double>[efS.Length];
                for (int i = 0; i < efS.Length; i++)
                {
                    car[i] = new Tuple<double, double>(double.Parse(efS[i].Split(',')[0], CultureInfo.InvariantCulture), double.Parse(efS[i].Split(',')[1], CultureInfo.InvariantCulture));
                }
                chanceCharac.Add(nomCharac, car);
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
            string nom = fields[0];
            string desc = fields[1];
            TimeSpan duree = TimeSpan.Parse(fields[2]);
            //On lit les deux tableaux (etat initial et final)
            double[] etatInital = new double[4];
            string ei = Regex.Replace(fields[5], @"[\[\]]+", string.Empty);
            string[] eiS = ei.Split(',');
            for (int i = 0; i < eiS.Length; i++)
                etatInital[i] = double.Parse(eiS[i], CultureInfo.InvariantCulture);

           

            double chance = double.Parse(fields[3], CultureInfo.InvariantCulture);
            bool bloquant = bool.Parse(fields[4]);

            return new EvenementsAleatoire(nom, desc, duree, etatInital, etatFinal, chanceCharac, chance, bloquant,jours, url, plageHoraire);
        }
    }
}
