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
        public frmTuto()
        {
            InitializeComponent();
        }

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
                lblExplication.Text = "Les actions sont regrouper par groupe: sport, manger, sortie, autre et travail." +
                    Environment.NewLine + "- Sport : fait baisser votre glycémie et votre stress mais vous fatigue(augmente le stress pour les gourmand)" +
                    Environment.NewLine + "-Manger : fait augmenter votre glycémie, baisse votre stress, redonne de l'énergie" +
                    Environment.NewLine + "- Sortie : fait augmenter ou baisser votre glycémie et votre stress et baisse votre énergie" +
                    Environment.NewLine + "- Autre : baisse votre glycémie et votre stress, vous redonne de l'énergie" +
                    Environment.NewLine + "- Travail : peux vous faire stresser, baisse votre énergie et n'affecte pas votre glycémie";
                lblExplication.Tag = 3;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 3)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutoEvenAlea;
                lblExplication.Text = "Évènement :" +
                    Environment.NewLine + "-Vous pouvez avoir des évènements qui vont influencé le taux de glycémie et les actions disponible" +
                    Environment.NewLine + "-Certains évènements dépendent de votre personnalité";

                lblExplication.Tag = 4;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 4)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutopiqurelente;
                lblExplication.Text = "Piqure lente:"+
                    Environment.NewLine+"-Permet de gérer son taux de glycémie sur la journée";
                lblExplication.Tag = 5;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 5)
            {
                pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tutoResucrage_PRapide;
                lblExplication.Text= "Piqure rapide: (3 dose par jour)" +
                    Environment.NewLine + "- Permet de baisser votre glycémie rapidement (par exemple si vous allez manger comme un roi)"+
                    Environment.NewLine + "Resucrage:" +
                    Environment.NewLine + "En cas d'hypoglycémie, remontre votre taux de glycémie";
                lblExplication.Tag = 6;
            }
            else if (int.Parse(lblExplication.Tag.ToString()) == 6)
            {
                this.Close();
            }
        }

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
