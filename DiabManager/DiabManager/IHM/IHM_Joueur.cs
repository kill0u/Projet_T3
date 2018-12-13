using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabManager.Metiers;

namespace DiabManager.IHM
{
    /**
     * La classe IHM_Joueur permet de faire le lien entre l'interface et la classe Joueur.
     * @version 1.0
     * @author Léo Krebs
     */
    class IHM_Joueur
    {
        private static Joueur m_j; /**<Le joueur courant. */

        /// <summary>
        /// Référence vers le formulaire de jeu
        /// </summary>
        private static frmJeu m_frm;

        public static void setForm(frmJeu frm)
        {
            m_frm = frm;
        }

        /**
         * Cette procédure permet de lier le joueur courant avec le joueur donné en paramètres.
         * @param j Le joueur.
         */
        public static void addJoueur(Joueur j)
        {
            m_j = j;
        }

        /// <summary>
        /// L'accesseur permettant de récupérer le joueur courant.
        /// </summary>
        /// <returns>
        /// Le joueur actuel, type Joueur.
        /// </returns>
        public static Joueur getJoueur()
        {
            return m_j;
        }

        /**
         * Cette fonction permet de récupérer toutes les informations du joueur courant.
         * Les informations sont récupérées avec les accesseurs de la classe Joueur.
         * 
         * @return infos[] Un tableau de string contenant toutes les informations au format string.
         */ 
        public static string[] getInfos()
        {
            string[] infos = new string[12];
            infos[0] = m_j.Nom;
            infos[1] = m_j.Prenom;
            infos[2] = m_j.Poids.ToString("F2");
            infos[3] = m_j.Taille.ToString();
            infos[4] = m_j.Sexe.ToString();
            infos[5] = m_j.Age.ToString();
            infos[6] = m_j.ProfilPhysique;
            infos[7] = m_j.GlycemieObjectifBas.ToString("F2") +" - "+m_j.GlycemieObjectifHaut;
            infos[8] = "";
            infos[9] = m_j.GlycemieCourante.ToString("F2");
            infos[10] = m_j.Stress.ToString();
            infos[11] = m_j.Energie.ToString();
            return infos;
        }

        /// <summary>
        /// Fonction qui permet de mettre à jour les informations affichées dans le formulaire jeu
        /// </summary>
        /// Cette fonction récupère les informations avec la fonction getInfos, puis la transmets dans le formulaire jeu.
        public static void Update()
        {
            ///faire tous les calculs avant de récupérer toutes les infos.
            string[] infos = getInfos();
            m_frm.setInfosJoueur(infos);
            

        }

        /// <summary>
        /// Mets à jour les informations du graphique avec les informations du joueur
        /// </summary>
        public static void UpdateGraph()
        {
            m_frm.BeginInvoke((Action)(() => {

                var chart1 = m_frm.getGraphe();
                if (chart1.Series[0].Points.Count == 50)
                {
                    chart1.Series[0].Points.RemoveAt(0);
                    chart1.Series[1].Points.RemoveAt(0);
                    chart1.Series[2].Points.RemoveAt(0);
                    chart1.Series[3].Points.RemoveAt(0);
                    chart1.Series[4].Points.RemoveAt(0);
                }
                chart1.Series[0].Points.AddY(Temps.getInstance().gMax);
                chart1.Series[1].Points.AddY(Temps.getInstance().gMin);
                chart1.Series[2].Points.AddY(double.Parse(getInfos()[7].Split('-')[1]));
                chart1.Series[3].Points.AddY(double.Parse(getInfos()[7].Split('-')[0]));
                chart1.Series[4].Points.AddY(double.Parse(getInfos()[9]));
                //chart1.ChartAreas[0].AxisX.CustomLabels[0].Text = Temps.getInstance().getHeureJournee().ToString();


            }));
            
        }
    }
}
