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

    public partial class frmTuto : Form
    {
        Color couleur;
        Color basec ;

        /// <summary>
        /// Initialisation du formulaire tutoriel
        /// </summary>
        /// <param name="c">The source of the event.</param>
        /// <param name="basecol">The <see cref="EventArgs"/> instance containing the event data.</param>
        public frmTuto(Color c,Color basecol)
        {
            InitializeComponent();
            couleur = c;
            basec = basecol;
            lblExplication.ForeColor = couleur == Color.Black ? basec : couleur;
            btnSuivant.BackColor = couleur==Color.Black ? basec : couleur;
            btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnSuivant.Font = new System.Drawing.Font("Myanmar Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSuivant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        }

        /// <summary>
        /// Le bouton qui permet de passer à la page suivante du tutoriel
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblExplication.Tag.ToString())==0)
            {
                lblExplication.Text = "Sur le graphique, la ligne rose est votre taux de glycémie; " +
                "il ne faut pas dépasser les lignes rouges,"+Environment.NewLine+" rester entre les lignes vertes.";
                lblExplication.Tag=1;
            }
            else if(int.Parse(lblExplication.Tag.ToString()) == 1)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutoDonnee;
                lblExplication.Text = "Ici les données du Joueur : le taux de glycémie, le stress, la fatigue (l'énergie), le poids" +
                    " et le nom du joueur";
                lblExplication.Tag = 2;
            }
            else if(int.Parse(lblExplication.Tag.ToString()) == 2)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutoAction;
                lblExplication.Text = "Les actions sont regroupées par groupe: sport, manger, sortie, travail et autre." +
                    Environment.NewLine + "- Sport : fait baisser votre glycémie et votre stress mais vous fatigue(augmente le stress pour les gourmands)" +
                    Environment.NewLine + "- Manger : fait augmenter votre glycémie, baisser votre stress et redonne de l'énergie" +
                    Environment.NewLine + "- Sortie : fait augmenter ou baisser votre glycémie et votre stress et baisse votre énergie" +
                    Environment.NewLine + "- Travail : peux vous faire stresser, baisse votre énergie et n'affecte pas votre glycémie" +
                    Environment.NewLine + "- Autre : baisse votre glycémie et votre stress, vous redonne de l'énergie";
                lblExplication.Tag = 3;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 3)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutoEvenAlea;
                lblExplication.Text = "Évènement :" +
                    Environment.NewLine + "- Vous pouvez avoir des évènements qui vont influencer le taux de glycémie et les actions disponibles" +
                    Environment.NewLine + "- Certains événements dépendent de votre personnalité";

                lblExplication.Tag = 4;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 4)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutopiqurelente;
                lblExplication.Text = "Piqûre lente:"+
                    Environment.NewLine+"- Permet de gérer son taux de glycémie sur la journée";
                lblExplication.Tag = 5;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 5)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutoResucrage_PRapide;
                lblExplication.Text= "Piqûre rapide: (3 dose par jour)" +
                    Environment.NewLine + "- Permet de baisser votre glycémie rapidement (par exemple si vous allez manger comme un roi)"+
                    Environment.NewLine + "Resucrage:" +
                    Environment.NewLine + "- En cas d'hypoglycémie, remontre votre taux de glycémie";
                lblExplication.Tag = 6;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 6)
            {
                this.Close();
            }
        }

        /// <summary>
        /// La fonction qui permet de changer l'image du tutoriel
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pbTuto_BackgroundImageChanged(object sender, EventArgs e)
        {
            
            if (pbTuto.BackgroundImage == global::DiabManager.Properties.Resources.tutoEvenAlea)
            {
                lblExplication.Text = "";
            }
            if (pbTuto.BackgroundImage == global::DiabManager.Properties.Resources.tutopiqurelente)
            {
                lblExplication.Text = "";
            }
            if (pbTuto.BackgroundImage == global::DiabManager.Properties.Resources.tutoResucrage_PRapide)
            {
                lblExplication.Text = "";
            }
        }
    }
}
