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
        /// Décrit si l'action est bloquante (one ne peut pas faire d'autre actions pendant ce temps) ou non
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
        public EvenementsAleatoire(string nom, string description, TimeSpan duree, double[] etatInitial, double[] etatFinal, double chanceInit, bool bloquant, params TimeSpan[] values): base(nom, description, duree, etatInitial, etatFinal, values)
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
                if (m_etatFinal[i + 4] != 2) //on ne change l'etat du joueur que s'il le faut
                    IHM.IHM_Joueur.getJoueur().Etat[i] = m_etatFinal[i + 4];
            }

        }

        /// <summary>
        /// Fonction se déclenchant tant que l'événement est actif
        /// </summary>
        /// Cette fonction met à jour le taux de glycémie du joueur et également son stress.
      /*  public void duringEvenement()
        {
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(m_etatFinal[2], m_etatFinal[1]), m_etatFinal[3]);
            IHM.IHM_Joueur.getJoueur().calculStress(m_etatFinal[3]);
            IHM.IHM_Joueur.getJoueur().calculEnergie(m_etatFinal[0]);
        }*/

        public new static EvenementsAleatoire readAction(string[] fields)
        {
            TimeSpan[] plageHoraire = new TimeSpan[30];
            int j = 0;
            for (int i = 7; i < fields.Length; i++)
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

            double[] etatFinal = new double[7];
            string ef = Regex.Replace(fields[6], @"[\[\]]+", string.Empty);
            string[] efS = ef.Split(',');
            for (int i = 0; i < efS.Length; i++)
                etatFinal[i] = double.Parse(efS[i], CultureInfo.InvariantCulture);

            double chance = double.Parse(fields[3], CultureInfo.InvariantCulture);
            bool bloquant = bool.Parse(fields[4]);

            return new EvenementsAleatoire(nom, desc, duree, etatInital, etatFinal, chance, bloquant, plageHoraire);
        }
    }
}
