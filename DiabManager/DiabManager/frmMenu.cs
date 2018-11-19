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
     * @version 1.7
     */
    public partial class frmMenu : Form
    {
        #region variables local
        private Boolean m_difficulte; /**<La Difficulté du jeu, si true Difficulté difficile sinon facile */
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="frmMenu"/> is difficulte.
        /// </summary>
        /// <value>
        ///   <c>true</c> if difficulte; otherwise, <c>false</c>.
        /// </value>
        public Boolean difficulte /**<La Difficulté du jeu . L'accesseur de la Difficulté du jeu. */
        {
            get { return m_difficulte; }
            set { this.m_difficulte = value; }
        }
        private DialogResult Exit;
        /// <summary>
        /// Gets the menu exit.
        /// </summary>
        /// <value>
        /// The menu exit.
        /// </value>
        public DialogResult MenuExit /**<Vérification si le fenetre menu c'est bien fermé */
        {
            get { return Exit; }
        }

        Color couleurOrigin = Color.Aqua;
        private Point p = new Point(280, 35);
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
        private Button btnProfil1;
        private Button btnProfil2;
        private Button btnProfil3;
        private GroupBox grbSexe;
        private RadioButton rdbSfem;
        private RadioButton rdbSmasc;
        private TextBox txtPrenom;
        private Label lblPrenom;
        private TextBox txtNom;
        private Label lblNom;
        private TextBox txtAge;
        private Label lblAge;
        private TextBox txtPoid;
        private Label lblPoid;
        private TextBox txtTaille;
        private Label lblTaille;
        private TextBox txtGlyc;
        private Label lblGlyc;
        private TextBox txtObjGlycHaut;
        private Label lblObjGlycHaut;
        private TextBox txtObjGlycBas;
        private Label lblObjGlycBas;
        private Button btnValider;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="frmMenu"/> class.
        /// </summary>
        public frmMenu()
        {
            InitializeComponent();
            #region Titre
            //creation du Titre
            Titre = new Label();
            Titre.AutoSize = true;
            Titre.BackColor = System.Drawing.Color.Transparent;
            Titre.Font = new System.Drawing.Font("Harlow Solid Italic", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Titre.ForeColor = couleurOrigin;
            Titre.Location = p;
            Titre.Name = "lblTitre";
            Titre.Size = s;
            Titre.TabIndex = 1;
            Titre.Text = "DiabManager";
            Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            ajoutEvClick(Titre, new EventHandler(Titre_Click));
            #endregion

            p = new Point(360, 173);
            s = new Size(244, 52);
            //creation du bouton de lancement de partie
            btnLancePart = creerButton("Lancer Partie", "btnPartie",p,s);
            ajoutEvClick(btnLancePart, new EventHandler(LancerPart_Click));

            p = new Point(360, 240);
            //creation du bouton de lancement de tuto
            btnLancerTuto = creerButton("Lancer Tutoriel", "btnTuto",p,s);
            ajoutEvClick(btnLancerTuto, new EventHandler(btnLancerTuto_Click));

            s = new Size(154, 32);
            p = new Point(408, 310);
            //creation du bouton retour
            btnRetour = creerButton("Retour", "btnRetour", p, s);
            ajoutEvClick(btnRetour, new EventHandler(btnRetour_Click));
            this.Controls.Add(btnRetour);
            btnRetour.Visible = false;
            p.X += 165;
            //creation du bouton valider
            btnValider = creerButton("Valider", "btnValider", p, s);
            ajoutEvClick(btnValider, new EventHandler(btnValider_Click));
            this.Controls.Add(btnValider);
            btnValider.Visible = false;

            this.Controls.Add(Titre);
            this.Controls.Add(btnLancePart);
            this.Controls.Add(btnLancerTuto);
        }



        #region evenements
        //events
        /// <summary>
        /// Handles the Click event of the Titre control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Titre_Click(object sender, EventArgs e)
        {
            changercolor();
        }
        /// <summary>
        /// Handles the Click event of the LancerPart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void LancerPart_Click(object sender, EventArgs e)
        {
            affDifficulte();
        }
        /// <summary>
        /// Handles the Click event of the btnLancerTuto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLancerTuto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("fonction non codé pour le moment");
        }
        /// <summary>
        /// Handles the Click event of the btnRetour control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRetour_Click(object sender, EventArgs e)
        {
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
                foreach (Label c in this.Controls.OfType<Label>())
                {
                    if(c != Titre)
                        c.Visible = false;
                }
                btnProfil1.Visible = false;
                btnProfil2.Visible = false;
                btnProfil3.Visible = false;
                btnValider.Visible = false;
                btndDifficile.Visible = true;
                btndFacile.Visible = true;
            }
        }
        /// <summary>
        /// Handles the Click event of the btndFacile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btndFacile_Click(object sender, EventArgs e)
        {
            affFormJoueur();
            m_difficulte = false;
        }
        /// <summary>
        /// Handles the Click event of the btndDifficile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btndDifficile_Click(object sender, EventArgs e)
        {
            affFormJoueur();
            m_difficulte = true;
        }
        /// <summary>
        /// Handles the Click event of the btnProfils control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnProfils_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Text== "Profil 1")
            {
                remplirFormulaireJoueur("Anne", 18, "Metzger", 'F', 160, 55, 2.5, 0.8, 1.3);
            }
            else if(b.Text == "Profil 2")
            {
                remplirFormulaireJoueur("Jean", 10, "Holler", 'H', 130, 30, 2.8, 1.8, 2.3);
            }
            else
            {
                remplirFormulaireJoueur("Camille", 26, "Muller", 'F', 150, 50, 2.3, 1.7, 2);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnValider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (checkFormulaire())
            {
                creerJoueur();
                Exit = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Chaque champ doit être renseigné");
            }
        }

        //les keypress
        /// <summary>
        /// Handles the keyPress event of the NoLetter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoLetter_keyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || (char.IsSymbol(e.KeyChar)))
            {
                e.Handled = true; // On interdit les lettres
            }
        }
        /// <summary>
        /// Handles the keyPress event of the NoDigit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoDigit_keyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || (char.IsSymbol(e.KeyChar)))
            {
                e.Handled = true; //On interdit les nombres
            }
        }
        /// <summary>
        /// Handles the KeyPress event of the NoLetterOneComma control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoLetterOneComma_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || (char.IsSymbol(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',') // Si l'utilisateur appuie sur la touche virgule
            {
                if (txtPoid.Text.Contains(","))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                } 
            }
        }
        #endregion

        #region fonctions
        /// <summary>
        /// Changercolors this instance.
        /// </summary>
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
                foreach (Label l in this.Controls.OfType<Label>())
                {
                    l.ForeColor = cdPicker.Color;
                }
                Titre.ForeColor = cdPicker.Color;
            }
        }
        /// <summary>
        /// Affs the difficulte.
        /// </summary>
        private void affDifficulte()
        {
            foreach(Button c in this.Controls.OfType<Button>())
            {
                c.Visible = false;
            }
            p = new Point(360, 173);
            s = new Size(244, 52);
            btndFacile = creerButton("Facile", "btnFacile", p, s);
            ajoutEvClick(btndFacile, new EventHandler(btndFacile_Click));
            btndFacile.BackColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            p = new Point(360, 240);
            btndDifficile = creerButton("Difficile", "btnDifficile", p, s);
            ajoutEvClick(btndDifficile, new EventHandler(btndDifficile_Click));
            btndDifficile.BackColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            this.Controls.Add(btndFacile);
            this.Controls.Add(btndDifficile);
            btnRetour.Visible = true;

        }
        /// <summary>
        /// Affs the form joueur.
        /// </summary>
        private void affFormJoueur()
        {
            btndDifficile.Visible = false;
            btndFacile.Visible = false;
            int x = 350;
            int y = 140;
            p = new Point(706, 149);
            s = new Size(110, 132);
            #region creation du group box
            grbSexe = creerGroupbox("Sexe", "grbSexe", p, s);
            grbSexe.ForeColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            p = new Point(x, y);
            s = new Size(100, 30);
            #endregion
            #region creation des label et des textbox
            txtAge = creerTextbox("txtAge", p, s);
            ajoutEvKeypress(txtAge, new KeyPressEventHandler(NoLetter_keyPress));
            p.Y += 30;
            txtNom = creerTextbox("txtNom", p, s);
            ajoutEvKeypress(txtNom, new KeyPressEventHandler(NoDigit_keyPress));
            p.Y += 30;
            txtPoid = creerTextbox("txtPoid", p, s);
            ajoutEvKeypress(txtPoid, new KeyPressEventHandler(NoLetterOneComma_KeyPress));
            p.Y += 30;
            txtPrenom = creerTextbox("txtPrenom", p, s);
            ajoutEvKeypress(txtPrenom, new KeyPressEventHandler(NoDigit_keyPress));
            p.Y += 30;
            txtTaille = creerTextbox("txtTaille", p, s);
            ajoutEvKeypress(txtTaille, new KeyPressEventHandler(NoLetter_keyPress));
            p.Y = y+30;
            p.X = x+250;
            txtGlyc = creerTextbox("txtGlyc", p, s);
            ajoutEvKeypress(txtGlyc, new KeyPressEventHandler(NoLetter_keyPress));
            p.Y += 30;
            txtObjGlycHaut = creerTextbox("txtObjGlycHaut", p, s);
            ajoutEvKeypress(txtObjGlycHaut, new KeyPressEventHandler(NoLetter_keyPress));
            p.Y += 30;
            txtObjGlycBas = creerTextbox("txtObjGlycBas", p, s);
            ajoutEvKeypress(txtObjGlycBas, new KeyPressEventHandler(NoLetter_keyPress));
            #endregion
            #region creation des label
            x = 210;
            y = 140;
            p = new Point(x, y);
            s = new Size(140, 20);
            lblAge = creerLabel("Age", "lblAge", p, s);
            p.Y += 30;
            lblNom = creerLabel("Nom","lblNom",p,s);
            p.Y += 30;
            lblPoid = creerLabel("Poids","lblPoid",p,s);
            p.Y += 30;
            lblPrenom = creerLabel("Prenom","lblPrenom",p,s);
            p.Y += 30;
            lblTaille = creerLabel("Taille (en cm)","lblTaille",p,s);
            p.Y = y + 30;
            p.X = x + 250;
            lblGlyc = creerLabel("Glycémie","txtGlyc", p, s);
            p.Y += 30;
            lblObjGlycHaut = creerLabel("Objectif max","txtObjGlycHaut", p, s);
            p.Y += 30;
            lblObjGlycBas = creerLabel("Objectif min","txtObjGlycBas", p, s);
            #endregion
            #region creation des buttons profils
            p = new Point(50, 140);
            s = new Size(150, 40);
            btnProfil1 = creerButton("Profil 1", "btnProfil1", p, s);
            ajoutEvClick(btnProfil1, new EventHandler(btnProfils_Click));
            btnProfil1.BackColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            p.Y += 50;
            btnProfil2 = creerButton("Profil 2", "btnProfil2", p, s);
            ajoutEvClick(btnProfil2, new EventHandler(btnProfils_Click));
            btnProfil2.BackColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            p.Y += 50;
            btnProfil3 = creerButton("Profil 3", "btnProfil3", p, s);
            ajoutEvClick(btnProfil3, new EventHandler(btnProfils_Click));
            btnProfil3.BackColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            #endregion
            #region ajout des objets au panel
            this.Controls.Add(grbSexe);
            this.Controls.Add(txtAge);
            this.Controls.Add(txtNom);
            this.Controls.Add(txtPoid);
            this.Controls.Add(txtPrenom);
            this.Controls.Add(txtTaille);
            this.Controls.Add(txtGlyc);
            this.Controls.Add(txtObjGlycHaut);
            this.Controls.Add(txtObjGlycBas);

            this.Controls.Add(lblAge);
            this.Controls.Add(lblNom);
            this.Controls.Add(lblPoid);
            this.Controls.Add(lblPrenom);
            this.Controls.Add(lblTaille);
            this.Controls.Add(lblGlyc);
            this.Controls.Add(lblObjGlycHaut);
            this.Controls.Add(lblObjGlycBas);

            this.Controls.Add(btnProfil1);
            this.Controls.Add(btnProfil2);
            this.Controls.Add(btnProfil3);
            #endregion

            grbSexe.Visible = true;
            btnValider.Visible = true;
            btnProfil1.Visible = true;
            btnProfil2.Visible = true;
            btnProfil3.Visible = true;
        }
        /// <summary>
        /// RDBs the cocher.
        /// </summary>
        /// <returns></returns>
        private String rdbCocher()
        {
            string res = "";
            foreach (RadioButton r in this.grbSexe.Controls.OfType<RadioButton>())
            {
                if (r.Checked)
                {
                    res = r.Text;
                }
            }
            return res;
        }

        /// <summary>
        /// Creers the joueur.
        /// </summary>
        private void creerJoueur()
        {
            string prenom = txtPrenom.Text;
            int age = int.Parse(txtAge.Text);
            string nom = txtNom.Text;
            char sex = char.Parse(rdbCocher());
            int taille = int.Parse(txtTaille.Text);
            double poids = double.Parse(txtPoid.Text);
            double glycemie = double.Parse(txtGlyc.Text);
            double glycemieObjBas = double.Parse(txtObjGlycBas.Text);
            double glycemieObjHaut = double.Parse(txtObjGlycHaut.Text);

            IHM.IHM_Joueur.addJoueur(new Metiers.Joueur(prenom, age, nom, sex, taille, poids, glycemie, glycemieObjBas, glycemieObjHaut,20.0));
        }
        /// <summary>
        /// Checks the formulaire.
        /// </summary>
        /// <returns></returns>
        private Boolean checkFormulaire()
        {
            Boolean check = true;
            foreach (TextBox t in this.Controls.OfType<TextBox>())
            {
                if (t.Text == string.Empty)
                {
                    check = false;
                }
            }
            return check;
        }
        /// <summary>
        /// Remplirs the formulaire joueur.
        /// </summary>
        /// <param name="prenom">The prenom.</param>
        /// <param name="age">The age.</param>
        /// <param name="nom">The nom.</param>
        /// <param name="sex">The sex.</param>
        /// <param name="taille">The taille.</param>
        /// <param name="poids">The poids.</param>
        /// <param name="glyc">The glycémie.</param>
        /// <param name="glycObBas">The objectif glycémique bas.</param>
        /// <param name="glycObHaut">The objectif glycémique haut.</param>
        private void remplirFormulaireJoueur(string prenom, int age, string nom, char sex, int taille, double poids, double glyc, double glycObBas, double glycObHaut)
        {
            /*foreach (TextBox c in this.Controls.OfType<TextBox>())
            {
                c.Text = "";
            }*/
            txtAge.Text = age.ToString();
            txtNom.Text = nom;
            txtPrenom.Text = prenom;
            txtPoid.Text = poids.ToString();
            txtGlyc.Text = glyc.ToString();
            txtObjGlycBas.Text = glycObBas.ToString();
            txtObjGlycHaut.Text = glycObHaut.ToString();
            txtTaille.Text = taille.ToString();
            if (sex == 'H')
            {
                rdbSmasc.Checked = true;
                rdbSfem.Checked = false;
            }
            else
            {
                rdbSmasc.Checked = false;
                rdbSfem.Checked = true;
            }
        }
        #endregion

        #region fonction génération dynamique de composant
        /// <summary>
        /// Creers the label.
        /// </summary>
        /// <param name="texte">The texte.</param>
        /// <param name="nomlabel">The nomlabel.</param>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private Label creerLabel(String texte,String nomlabel,Point location, Size size)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.ForeColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            lbl.Location = location;
            lbl.Name = nomlabel;
            lbl.Size = size;
            lbl.Text = texte;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            return lbl;
        }

        /// <summary>
        /// Creers the button.
        /// </summary>
        /// <param name="texte">The texte.</param>
        /// <param name="nombutton">The nombutton.</param>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creers the groupbox.
        /// </summary>
        /// <param name="texte">The texte.</param>
        /// <param name="nomGroupbox">The nom groupbox.</param>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private GroupBox creerGroupbox(String texte, String nomGroupbox, Point location, Size size)
        {
            GroupBox grbx = new GroupBox();
            p = new Point(21, 86);
            s = new Size(110, 21);
            rdbSfem = creerRadioButton("F", "rdbFem", p, s,0);
            rdbSfem.Checked = true;
            p = new Point(21, 35);
            rdbSmasc = creerRadioButton("H", "rdbMasc", p, s, 1);
            grbx.Controls.Add(rdbSfem);
            grbx.Controls.Add(rdbSmasc);
            grbx.ForeColor = couleurOrigin;
            grbx.Location = location;
            grbx.Name = nomGroupbox;
            grbx.Size = size;
            grbx.TabIndex = 0;
            grbx.TabStop = false;
            grbx.Text = texte;
            return grbx;
        }

        /// <summary>
        /// Creers the RadioButton.
        /// </summary>
        /// <param name="texte">The texte.</param>
        /// <param name="nomRdb">The nom RDB.</param>
        /// <param name="loc">The loc.</param>
        /// <param name="size">The size.</param>
        /// <param name="tabind">The tabind.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creers the textbox.
        /// </summary>
        /// <param name="nomTxt">The nom text.</param>
        /// <param name="loc">The loc.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private TextBox creerTextbox(String nomTxt, Point loc, Size size)
        {
            TextBox txt = new TextBox();
            txt.Location = loc;
            txt.Name = nomTxt;
            txt.Size = size;
            txt.TabIndex = 0;
            return txt;
        }
        
        private void ajoutEvClick(Control c,EventHandler eHand) {
            c.Click += eHand;
        }

        /// <summary>
        /// Ajouts the ev keypress.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="eHand">The e hand.</param>
        private void ajoutEvKeypress(Control c,KeyPressEventHandler eHand)
        {
            c.KeyPress += eHand;
        }

        #endregion

    }
}
