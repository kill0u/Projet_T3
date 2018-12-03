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


        /// <summary>
        /// Constructeur de la classe EvenementsAleatoire
        /// </summary>
        /// <param name="nom">Nom de l'évènement</param>
        /// <param name="description">Desciption de l'évènement</param>
        /// <param name="duree">Durée de l'évènements (ex: sortie au bar --&gt; 5h)</param>
        /// <param name="etatInitial">Etat initial nécessaire pour l'action</param>
        /// <param name="etatFinal">Etat du joueur après l'action</param>
        /// <param name="chanceInit">Le pourcentage de chance que l'évènements se déclenche initialement</param>
        /// <param name="bloquant">Si l'évènement lancé bloque toutes les autres actions possibles</param>
        /// <param name="values">Plage horaire</param>
        /// Cette classe comporte tous les effets qui peuvent agir le joueur
        public EvenementsAleatoire(string nom, string description, TimeSpan duree, double[] etatInitial, Dictionary<string,double[]> etatFinal, double chanceInit, bool bloquant, params TimeSpan[] values): base(nom, description, duree, etatInitial, etatFinal, values)
        {

            m_chanceInit = chanceInit;
            m_bloquant = bloquant;
        }



        /// <summary>
        /// Fonction se déclenchant lorsque l'évènement est lancé
        /// </summary>
        /// <param name="start">Heure de début de l'évènement</param>
       public new void makeAction(TimeSpan start)
        {
            m_endTime = start.Add(m_duree);

            //Si l'évènement est bloquant, on passe en vitesse élevé, comme si il s'agissait d'une action
            if (m_bloquant)
            {
                Temps.getInstance().swapAction();

            }


            //On mets à jour son etat
            for (int i = 0; i < IHM.IHM_Joueur.getJoueur().Etat.Length; i++)
            {
                foreach (var charac in IHM.IHM_Joueur.getJoueur().Personalite)
                {
                    if (m_etatFinalCharac[charac][i + 4] != 2) //on ne change l'etat du joueur que s'il le faut
                        IHM.IHM_Joueur.getJoueur().Etat[i] = m_etatFinalCharac[charac][i + 4];
                }
            }

        }


        public new static EvenementsAleatoire readAction(string[] fields)
        {

            Dictionary<string, double[]> etatFinal = new Dictionary<string, double[]>();
            int k = 6;
            while (fields[k].Contains(":["))
            {
                string nomCharac = fields[k].Split(':')[0];
                string ef = Regex.Replace(fields[k].Split(':')[1], @"[\[\]]+", string.Empty);
                string[] efS = ef.Split(',');
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

            return new EvenementsAleatoire(nom, desc, duree, etatInital, etatFinal, chance, bloquant, plageHoraire);
        }
    }
}
