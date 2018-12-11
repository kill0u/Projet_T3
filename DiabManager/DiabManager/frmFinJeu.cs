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

        private void frmFinJeu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmMenu sistema = new frmMenu();
            //sistema.ShowDialog();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
