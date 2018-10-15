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
        //premier affichage
        private Label Titre;
        private Button btnLancePart;
        private Button btnLancerTuto;
        //deuxieme affichage
        private Button btndFacile;
        private Button btndDifficile;
        private Button btnRetour;
        //troixieme affichage
        private GroupBox grbSexe;
        private RadioButton rdbSfem;
        private RadioButton rdbSmasc;
        private TextBox txtPrenom;
        private TextBox txtNom;
        private TextBox txtAge;
        private TextBox txtPoid;
        private TextBox txtTaille;
        private TextBox txtGlyc;
        private TextBox txtObjGlycHaut;
        private TextBox txtObjGlycBas;
        private Button btnValider;

        public frmMenu()
        {
            InitializeComponent();

            Titre = creerLabel("DiabManager", "lblTitre", p, s);//creation du label Titre
            ajoutEvClick(Titre, new EventHandler(Titre_Click));

            p = new Point(210, 173);
            s = new Size(244, 52);
            btnLancePart = creerButton("Lancer Partie", "btnPartie",p,s);//creation du bouton de lancement de partie
            ajoutEvClick(btnLancePart, new EventHandler(LancerPart_Click));

            p = new Point(210, 240);
            btnLancerTuto = creerButton("Lancer Tutoriel", "btnTuto",p,s);//creation du bouton de lancement de tuto
            ajoutEvClick(btnLancerTuto, new EventHandler(btnLancerTuto_Click));

            s = new Size(154, 32);
            p = new Point(258, 310);
            btnRetour = creerButton("Retour", "btnRetour", p, s);
            ajoutEvClick(btnRetour, new EventHandler(btnRetour_Click));
            this.Controls.Add(btnRetour);
            btnRetour.Visible = false;
            p.X += 165;
            btnValider = creerButton("Valider", "btnValider", p, s);
            this.Controls.Add(btnValider);
            btnValider.Visible = false;

            

            this.Controls.Add(Titre);
            this.Controls.Add(btnLancePart);
            this.Controls.Add(btnLancerTuto);
        }

        private void Titre_Click(object sender, EventArgs e)
        {
            changercolor();
        }
        private void LancerPart_Click(object sender, EventArgs e)
        {
            affDifficulte();
        }
        private void btnLancerTuto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("fonction non codé pour le moment");
        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            /*foreach (Button c in this.Controls.OfType<Button>())
            {
                c.Visible = false;
            }
            btnLancePart.Visible = true;
            btnLancerTuto.Visible = true;*/
            if (!btnLancerTuto.Visible && btndFacile.Visible)
            {
                btndFacile.Visible = false;
                btndDifficile.Visible = false;
                btnLancerTuto.Visible = true;
                btnLancePart.Visible = true;
                btnRetour.Visible = false;
            }
            if(!btnLancerTuto.Visible && !btndFacile.Visible)
            {
                grbSexe.Visible = false;
                foreach (TextBox c in this.Controls.OfType<TextBox>())
                {
                    c.Visible = false;
                }
                btnValider.Visible = false;
                btndDifficile.Visible = true;
                btndFacile.Visible = true;
            }
        }
        private void btndFacile_Click(object sender, EventArgs e)
        {
            affDifFacile();
        }

        private void changercolor()
        {
            DialogResult result = cdPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (Button b in this.Controls.OfType<Button>())
                {
                    b.BackColor = cdPicker.Color;
                }
                foreach(GroupBox g in this.Controls.OfType<GroupBox>())
                {
                    g.ForeColor = cdPicker.Color;
                }
                Titre.ForeColor = cdPicker.Color;
            }
        }
        private void affDifficulte()
        {
            foreach(Button c in this.Controls.OfType<Button>())
            {
                c.Visible = false;
            }
            p = new Point(210, 173);
            s = new Size(244, 52);
            btndFacile = creerButton("Facile", "btnFacile", p, s);
            ajoutEvClick(btndFacile, new EventHandler(btndFacile_Click));
            btndFacile.BackColor = cdPicker.Color == Color.Black ? Color.Aqua : cdPicker.Color;
            p = new Point(210, 240);
            btndDifficile = creerButton("Difficile", "btnDifficile", p, s);
            btndDifficile.BackColor = cdPicker.Color == Color.Black ? Color.Aqua : cdPicker.Color;
            this.Controls.Add(btndFacile);
            this.Controls.Add(btndDifficile);
            btnRetour.Visible = true;

        }
        private void affDifFacile()
        {
            btndDifficile.Visible = false;
            btndFacile.Visible = false;
            p = new Point(506, 149);
            s = new Size(110, 132);
            grbSexe = creerGroupbox("Sexe", "grbSexe", p, s);
            grbSexe.ForeColor = cdPicker.Color == Color.Black ? Color.Aqua : cdPicker.Color;
            p = new Point(60, 130);
            s = new Size(200, 30);
            txtAge = creerTextbox("txtAge", p, s);
            p.Y += 30;
            txtNom = creerTextbox("txtNom", p, s);
            p.Y += 30;
            txtPoid = creerTextbox("txtPoid", p, s);
            p.Y += 30;
            txtPrenom = creerTextbox("txtPrenom", p, s);
            p.Y += 30;
            txtTaille = creerTextbox("txtTaille", p, s);
            p.Y = 130+30;
            p.X = 280;
            txtGlyc = creerTextbox("txtGlyc", p, s);
            p.Y += 30;
            txtObjGlycHaut = creerTextbox("txtObjGlycHaut", p, s);
            p.Y += 30;
            txtObjGlycBas = creerTextbox("txtObjGlycBas", p, s);
            this.Controls.Add(grbSexe);
            this.Controls.Add(txtAge);
            this.Controls.Add(txtNom);
            this.Controls.Add(txtPoid);
            this.Controls.Add(txtPrenom);
            this.Controls.Add(txtTaille);
            this.Controls.Add(txtGlyc);
            this.Controls.Add(txtObjGlycHaut);
            this.Controls.Add(txtObjGlycBas);
            grbSexe.Visible = true;
            btnValider.Visible = true;
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
         * Fonction permetant la création dynamique d'un bouton
         *  @param texte : texte du bouton
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
        /** Création dynamique d'un groupbox.
         * Fonction permetant la création dynamique d'un groupbox
         *  @param texte : texte du groupbox
         *  @param nomGroupbox : nom du groupbox
         *  @param location : position du groupbox
         *  @param size : taille du groupbox
         */
        private GroupBox creerGroupbox(String texte, String nomGroupbox, Point location, Size size)
        {
            GroupBox grbx = new GroupBox();
            p = new Point(21, 86);
            s = new Size(110, 21);
            rdbSfem = creerRadioButton("F", "rdbFem", p, s,0);
            p = new Point(21, 35);
            rdbSmasc = creerRadioButton("M", "rdbMasc", p, s, 1);
            grbx.Controls.Add(rdbSfem);
            grbx.Controls.Add(rdbSmasc);
            grbx.ForeColor = System.Drawing.Color.Aqua;
            grbx.Location = location;
            grbx.Name = nomGroupbox;
            grbx.Size = size;
            grbx.TabIndex = 0;
            grbx.TabStop = false;
            grbx.Text = texte;
            return grbx;
        }
        /** Création dynamique d'un radiobutton.
        * Fonction permetant la création dynamique d'un radiobutton
        *  @param texte : texte du radiobutton
        *  @param nomRdb : nom du radiobutton
        *  @param loc : position du radiobutton
        *  @param size : taille du radiobutton
        *  @param tabind : index du radiobutton afin de l'identifier
        */
        private RadioButton creerRadioButton(String texte, String nomRdb, Point loc, Size size,int tabind)
        {
            RadioButton rdb = new RadioButton();
            rdb.AutoSize = true;
            rdb.Location = loc;
            rdb.Name = nomRdb;
            rdb.Size = size;
            rdb.TabIndex = tabind;
            rdb.TabStop = true;
            rdb.Text = texte;
            rdb.UseVisualStyleBackColor = true;
            return rdb;
        }

        private TextBox creerTextbox(String nomTxt, Point loc, Size size)
        {
            TextBox txt = new TextBox();
            txt.Location = loc;
            txt.Name = nomTxt;
            txt.Size = size;
            txt.TabIndex = 0;
            return txt;
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
