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
    /**
     * @author Killian Matter
     * @version 1.1
     */
    public partial class frmMenu : Form
    {
        private Point p = new Point(116, 35);
        private Size s = new Size(520, 101);
        private Label Titre;
        private Button LancePart;
        private Button LancerTuto;
        private Button dFacile;
        private Button dDifficile;
        private Button Retour;

        public frmMenu()
        {
            InitializeComponent();

            Titre = creerLabel("DiabManager", "lblTitre", p, s);//creation du label Titre
            ajoutEvClick(Titre, new EventHandler(Titre_Click));

            p = new Point(210, 173);
            s = new Size(244, 52);
            LancePart = creerButton("Lancer Partie", "btnPartie",p,s);//creation du bouton de lancement de partie
            ajoutEvClick(LancePart, new EventHandler(LancerPart_Click));

            p = new Point(210, 240);
            LancerTuto = creerButton("Lancer Tutoriel", "btnTuto",p,s);//creation du bouton de lancement de tuto

            s = new Size(154, 32);
            p = new Point(258, 310);
            Retour = creerButton("Retour", "btnRetour", p, s);
            ajoutEvClick(Retour, new EventHandler(Retour_Click));
            this.Controls.Add(Retour);
            Retour.Visible = false;

            this.Controls.Add(Titre);
            this.Controls.Add(LancePart);
            this.Controls.Add(LancerTuto);
        }

        private void Titre_Click(object sender, EventArgs e)
        {
            DialogResult result = cdPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach(Button b in this.Controls.OfType<Button>())
                {
                    b.BackColor = cdPicker.Color;
                }
                Titre.ForeColor = cdPicker.Color;
            }
        }
        private void LancerPart_Click(object sender, EventArgs e)
        {
            affDifficulte();
        }
        private void Retour_Click(object sender, EventArgs e)
        {
            foreach (Button c in this.Controls.OfType<Button>())
            {
                c.Visible = false;
            }
            LancePart.Visible = true;
            LancerTuto.Visible = true;
        }

        private void affDifficulte()
        {
            foreach(Button c in this.Controls.OfType<Button>())
            {
                c.Visible = false;
            }
            p = new Point(210, 173);
            s = new Size(244, 52);
            dFacile = creerButton("Facile", "btnFacile", p, s);
            dFacile.BackColor = cdPicker.Color == Color.Black ? Color.Aqua : cdPicker.Color;
            p = new Point(210, 240);
            dDifficile = creerButton("Difficile", "btnDifficile", p, s);
            dDifficile.BackColor = cdPicker.Color == Color.Black ? Color.Aqua : cdPicker.Color;
            this.Controls.Add(dFacile);
            this.Controls.Add(dDifficile);
            Retour.Visible = true;

        }
        

        #region fonction génération dynamique de composant
        /** Création dynamique de label.
         * Fonction permetant la création dynamique d'un label
         *  @param texte : texte du label
         *  @param nomlabel : nom du label
         *  @param location : position du label
         *  @param size : taille du label
         */
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
        /** Création dynamique d'un bouton.
         * Fonction permetant la création dynamique d'un label
         *  @param texte : texte du buton
         *  @param nombutton : nom du bouton
         *  @param location : position du buton
         *  @param size : taille du buton
         */
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
        /** Ajout dynamique d'évenement click
         * Fonction ajoutant un evenement dynamiquement
         * @param c : controleur auquel on ajoute l'évenement
         * @param eHand : evenement ajouté
         */
        private void ajoutEvClick(Control c,EventHandler eHand) {
            c.Click += eHand;
        }
        #endregion

       
    }
}
