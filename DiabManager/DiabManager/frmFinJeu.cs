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
    public partial class frmFinJeu : Form
    {
        public frmFinJeu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur, met à jour le texte et le journal
        /// </summary>
        /// <param name="res">Si le joueur a gagné ou non</param>
        /// <param name="log">Journal</param>
        public frmFinJeu(bool res, string log)
        {
            InitializeComponent();
            if (res)
            {
                label1.Text = "Bien joué ! Vous avez gérer votre glycémie comme il se doit !";
            }
            else
            {
                label1.Text = "Raté ! Vous êtes rester trop longtemps dans des valeurs de glycémie éxcessives !";
            }

            txtJournal.Text = log;
        }

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <param name="sender">La source</param>
        /// <param name="e">e</param>
        private void frmFinJeu_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Événement pour quitter le jeu
        /// </summary>
        /// <param name="sender">La source</param>
        /// <param name="e">e</param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
