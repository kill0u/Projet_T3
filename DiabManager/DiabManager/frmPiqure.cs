using DiabManager.Metiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabManager
{
    public partial class frmPiqure : Form
    {
        /// <summary>
        /// Initialisation du formulaire piqûre
        /// </summary>
        public frmPiqure()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire piqûre
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmPiqure_Load(object sender, EventArgs e)
        {
            modifStyloInsuline();
            lblConseil.Text = lblConseil.Text + (double.Parse(IHM.IHM_Joueur.getInfos()[2]) / 10).ToString();
        }

        /// <summary>
        /// Fonction qui modifie les informations affichées du stylo d'insuline.
        /// </summary>
        public void modifStyloInsuline()
        {
            this.BeginInvoke((Action)(() => {
                if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu != 0)
                {
                    progressBarInsuline.Value = IHM.IHM_Joueur.getJoueur().Stylo.dose * 100 / IHM.IHM_Joueur.getJoueur().Stylo.DoseActu;
                }
                else { progressBarInsuline.Value = 0; }
                lblDose.Text = "Dose à injecter : " + IHM.IHM_Joueur.getJoueur().Stylo.dose;
                lblDoseActu.Text = "dose restante : " + IHM.IHM_Joueur.getJoueur().Stylo.DoseActu;
            }));
        }

        /// <summary>
        /// Fonction que permet de diminuer la dose à s'injecter.
        /// </summary>
        private void btnDiminuer_Click(object sender, EventArgs e)
        {
            if (IHM.IHM_Joueur.getJoueur().Stylo.dose != 0)
            {
                IHM.IHM_Joueur.getJoueur().Stylo.dose--;
                modifStyloInsuline();
            }
        }

        /// <summary>
        /// Fonction que permet d'augmenter la dose à s'injecter.
        /// </summary>
        private void btnAugmenter_Click(object sender, EventArgs e)
        {
            if (IHM.IHM_Joueur.getJoueur().Stylo.dose != IHM.IHM_Joueur.getJoueur().Stylo.DoseMax)
            {
                IHM.IHM_Joueur.getJoueur().Stylo.dose++;
                modifStyloInsuline();
            }
        }

        /// <summary>
        /// Déclenche la piqûre sur la personne pour la journée
        /// </summary>
        private void btnPiqure_Click(object sender, EventArgs e)
        {
            IHM.IHM_Joueur.getJoueur().Stylo.DoseActu -= IHM.IHM_Joueur.getJoueur().Stylo.dose;
            if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu < IHM.IHM_Joueur.getJoueur().Stylo.dose) { IHM.IHM_Joueur.getJoueur().Stylo.dose = IHM.IHM_Joueur.getJoueur().Stylo.DoseActu; }
            modifStyloInsuline();
            Temps.getInstance().PlayPause();
            this.Close();
        }
    }
}
