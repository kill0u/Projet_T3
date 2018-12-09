using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiabManager.Metiers.ListeActions
{
    class Nourriture : Actions
    {
        /// <summary>
        /// La valeur de poids qui modifie le poids du joueur après avoir manger.
        /// </summary>
        private double m_poids;
        public double Poids
        {
            get { return m_poids; }
        }

        /// <summary>
        /// Constructeur de la classe EvenementsAleatoire
        /// </summary>
        /// <param name="nom">Nom de l'évènement</param>
        /// <param name="description">Desciption de l'évènement</param>
        /// <param name="duree">Durée de l'évènements (ex: sortie au bar --&gt; 5h)</param>
        /// <param name="etatInitial">Etat initial nécessaire pour l'action</param>
        /// <param name="etatFinal">Etat du joueur après l'action</param>
        /// <param name="poids">Le poids a ajouter au joueur après avoir manger</param>
        /// <param name="values">Plage horaire</param>
        /// Cette classe comporte tous les effets qui peuvent agir le joueur
        public Nourriture(string nom, string description, TimeSpan duree, double[] etatInitial, Dictionary<string,double[]> etatFinal, double poids, bool[] jours, string url, params TimeSpan[] values) : base(nom, description, duree, etatInitial, etatFinal, jours, url, values)
        {
            m_poids = poids;
        }

        public new void makeAction(TimeSpan temps)
        {
            base.makeAction(temps);
            if (IHM.IHM_Joueur.getJoueur().Poids+m_poids > 30 && IHM.IHM_Joueur.getJoueur().Poids < 500)
            {
                IHM.IHM_Joueur.getJoueur().Poids += m_poids;
            }
        }

        /// <summary>
        /// Charge l'action depuis un la ligne du fichier
        /// </summary>
        /// <param name="fields">Ligne du fichier</param>
        /// <returns>L'action créée</returns>
        public static new Nourriture readAction(string[] fields)
        {

            string ef = Regex.Replace(fields[6], @"[\[\]]+", string.Empty);
            string[] efS = ef.Split(',');
            bool[] jours = new bool[7];
            for (int i = 0; i < efS.Length; i++)
                jours[i] = efS[i] == "1";

            string url = fields[7];

            Dictionary<string, double[]> etatFinal = new Dictionary<string, double[]>();
            int k = 8;
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

            double poids = double.Parse(fields[5], CultureInfo.InvariantCulture);


            return new Nourriture(nom, desc, duree, etatInital, etatFinal, poids,jours, url, plageHoraire);
        }
    }
}
