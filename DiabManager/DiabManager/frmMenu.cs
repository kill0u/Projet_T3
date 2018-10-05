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
    public partial class frmMenu : Form
    {
        private Point p = new Point(116, 35);
        private Size s = new Size(520, 101);
        private Label Titre;
        private Button LancePart;
        private Button LancerTuto;

        public frmMenu()
        {
            InitializeComponent();

            Titre = creerLabel("DiabManager", "lblTitre", p, s);
            p = new Point(303, 173);
            s = new Size(284, 68);
            LancePart = creerButton("Lancer Partie", "btnPartie",p,s);
            ajoutEvClickLbl(Titre, new EventHandler(Titre_Click));
            this.Controls.Add(Titre);
            this.Controls.Add(LancePart);
        }

        private void Titre_Click(object sender, EventArgs e)
        {
            DialogResult result = cdPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                Titre.ForeColor = cdPicker.Color;
                LancePart.BackColor = cdPicker.Color;
                btnTuto.BackColor = cdPicker.Color;
            }
        }

        #region fonction génération dynamique de composant
        private Label creerLabel(String texte,String nomlabel,Point location, Size size)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.Font = new System.Drawing.Font("Harlow Solid Italic", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.ForeColor = System.Drawing.Color.Aqua;
            lbl.Location = location;
            lbl.Name = nomlabel;
            lbl.Size = size;
            lbl.TabIndex = 1;
            lbl.Text = texte;
            lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            return lbl;
        }
        private Button creerButton(String texte, String nombutton, Point location, Size size)
        {
            Button btn = new Button();
            btn.BackColor = System.Drawing.Color.Aqua;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn.Font = new System.Drawing.Font("Harlow Solid Italic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            btn.Location = location;
            btn.Name = nombutton;
            btn.Size = size;
            btn.TabIndex = 0;
            btn.Text = texte;
            btn.UseVisualStyleBackColor = false;
            return btn;
        }
        private void ajoutEvClickLbl(Label l,EventHandler eh) {
            l.Click += eh;
        }
        #endregion
    }
}
