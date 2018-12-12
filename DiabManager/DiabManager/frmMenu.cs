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
        private Label lblText;
        private Button btnRetour;
        private Button btnSuite;
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
        private Label lblPersonalite;
        private CheckedListBox clboxPersonnalite;
        private Button btnBonneNouv;
        private Button btnMauvaiseNouv;
        private int compt ;
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
            //creation bouton suite
            btnSuite = creerButton("Suite", "btnSuite", p, s);
            ajoutEvClick(btnSuite, new EventHandler(btnSuite_Click));
            this.Controls.Add(btnSuite);
            btnSuite.Visible = false;
            //creation bouton bonne nouvelle
            s.Width = 200;
            btnBonneNouv = creerButton("Bonne nouvelle", "btnBon", p, s);
            this.Controls.Add(btnBonneNouv);
            btnBonneNouv.Visible = false;
            p.X -= 375;
            btnMauvaiseNouv = creerButton("Mauvaise nouvelle", "btnMauv", p, s);
            this.Controls.Add(btnMauvaiseNouv);
            btnMauvaiseNouv.Visible = false;
            ajoutEvClick(btnBonneNouv, new EventHandler(btnNouv_Click));
            ajoutEvClick(btnMauvaiseNouv, new EventHandler(btnNouv_Click));
            compt = 2;
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
            //affFormJoueur();
            affDifficulte();
        }
        private void btnNouv_Click(object sender, EventArgs e)
        {
            
            Button bu = (Button)sender;
            if (bu.Text == "Bonne nouvelle")
            {
                MessageBox.Show("Votre visite est entièrement remboursée à 90% par la Sécurité Sociale.");
                bu.Enabled = false;
                compt --;
            }
            else
            {
                MessageBox.Show("Vous êtes diabétique, vous allez donc devoirs faire attention a votre taux de glycémie, " +
                    "a ce que vous mangerais et à ce que vous allez faire.");
                bu.Enabled = false;
                compt--;
            }
            if (compt == 0)
            {
                Exit = DialogResult.OK;
                this.Close();
            }
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
            /*if (!btnLancerTuto.Visible && btndFacile.Visible)
            {
                btndFacile.Visible = false;
                btndDifficile.Visible = false;
                btnLancerTuto.Visible = true;
                btnLancePart.Visible = true;
                btnRetour.Visible = false;
            }*/
            if(!btnLancerTuto.Visible /*&& !btndFacile.Visible*/)
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
                clboxPersonnalite.Visible = false;
                //btndDifficile.Visible = true;
                //btndFacile.Visible = true;
                btnLancerTuto.Visible = true;
                btnLancePart.Visible = true;
                btnRetour.Visible = false;
                btnBonneNouv.Visible = false;

                btnMauvaiseNouv.Visible = false;
                compt = 2;
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

            //{"Sportif","Gourmand","VideoGamer","Social","Studieux","Dépressif","Peureux"}
            nettoyage();
            if (b.Text== "Profil 1")
            {
                remplirFormulaireJoueur("Anne", new string[] { "Social", "Studieux" }, 18, "Metzger", 'F', 160, 55, 2.5, 0.8, 1.3);
            }
            else if(b.Text == "Profil 2")
            {
                remplirFormulaireJoueur("Jean",new string[]{"Gourmand","VideoGamer"}, 10, "Holler", 'H', 130, 30, 2.8, 1.8, 2.3);
            }
            else
            {
                remplirFormulaireJoueur("Camille",new string[] {"Peureux","Sportif"}, 26, "Muller", 'F', 150, 50, 2.3, 1.7, 2);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnValider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtAge.Visible)
            {
                if (checkFormulaire())
                {
                    creerJoueur();
                    affResultDiag();
                }
                else
                {
                    MessageBox.Show("Chaque champ doit être renseigné");
                }
            }
            
        }

        private void btnSuite_Click(object sender, EventArgs e)
        {
            btnSuite.Visible = false;
            affFormJoueur();
        }

        //les keypress
        /// <summary>
        /// Handles the keyPress event of the NoLetter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoLetter_keyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if(t.Text.Length < 3)
            {
                if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || (char.IsSymbol(e.KeyChar)))
                {
                    e.Handled = true; // On interdit les lettres
                }
            }
            else
            {
                e.Handled = false;
            }
            
        }
        /// <summary>
        /// Handles the keyPress event of the NoDigit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoDigit_keyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text.Length < 20)
            {
                if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || (char.IsSymbol(e.KeyChar)))
                {
                    e.Handled = true; //On interdit les nombres
                }
            }
            else
            {
                e.Handled = false;
            }
            
        }
        /// <summary>
        /// Handles the KeyPress event of the NoLetterOneComma control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoLetterOneComma_KeyPress(Object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if(t.Text.Length < 3) {
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
            else
            {
                e.Handled = false;
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
            Point p = new System.Drawing.Point(173, 125);
            Size s = new System.Drawing.Size(600, 100);
            lblText = creerLabel("Bienvenue dans notre Laboratoire DiabManager ! " +
                "Si vous êtes ici c'est pour un diagnostique pour le Diabète n'est ce pas ? " +
                "Veuillez remplir le formulaire suivant afin de mener à bien votre diagnostic",
                "txtTextHisto",p,s);
            lblText.Visible = true;
            this.Controls.Add(lblText);
            btnSuite.Visible = true;

        }
        
        private void affResultDiag()
        {
            grbSexe.Visible = false;
            foreach (TextBox c in this.Controls.OfType<TextBox>())
            {
                c.Visible = false;
            }
            foreach (Label c in this.Controls.OfType<Label>())
            {
                if (c != Titre)
                    c.Visible = false;
            }
            btnProfil1.Visible = false;
            btnProfil2.Visible = false;
            btnProfil3.Visible = false;
            btnValider.Visible = false;
            clboxPersonnalite.Visible = false;
            Point p = new System.Drawing.Point(173, 125);
            Size s = new System.Drawing.Size(600, 100);
            lblText = creerLabel("Bien J'ai ici vos résultats de votre Diagnostique, " +
                "j'ai une bonne et une mauvaise nouvelle, laquelle voulais vous entendre en premier ?","txtdiag", p, s);
            lblText.Visible = true;
            this.Controls.Add(lblText);
            p.Y += 40;
            s = new System.Drawing.Size(154, 32);
            
            btnBonneNouv.Visible = true;
            btnMauvaiseNouv.Visible = true;
        }
        /// <summary>
        /// Affs the form joueur.
        /// </summary>
        private void affFormJoueur()
        {
            //btndDifficile.Visible = false;
            //btndFacile.Visible = false;
            //btnLancePart.Visible = false;
            //btnLancerTuto.Visible = false;
            lblText.Visible = false;
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
            #region creation des textbox
            txtNom = creerTextbox("txtNom", p, s);
            ajoutEvKeypress(txtNom, new KeyPressEventHandler(NoDigit_keyPress));
            p.Y += 30;
            txtPrenom = creerTextbox("txtPrenom", p, s);
            ajoutEvKeypress(txtPrenom, new KeyPressEventHandler(NoDigit_keyPress));
            p.Y += 30;
            txtAge = creerTextbox("txtAge", p, s);
            ajoutEvKeypress(txtAge, new KeyPressEventHandler(NoLetter_keyPress));
            p.Y += 30;
            txtTaille = creerTextbox("txtTaille", p, s);
            ajoutEvKeypress(txtTaille, new KeyPressEventHandler(NoLetter_keyPress));
            p.Y += 30;
            txtPoid = creerTextbox("txtPoid", p, s);
            ajoutEvKeypress(txtPoid, new KeyPressEventHandler(NoLetterOneComma_KeyPress));
            p.Y = y+30;
            p.X = x+250;
            clboxPersonnalite = creerCheckList("Personalite", p);
            p.Y += 30;
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
            lblNom = creerLabel("Nom", "lblNom", p, s);
            p.Y += 30;
            lblPrenom = creerLabel("Prenom", "lblPrenom", p, s);
            p.Y += 30;
            lblAge = creerLabel("Age", "lblAge", p, s);
            p.Y += 30;
            lblTaille = creerLabel("Taille (en cm)", "lblTaille", p, s);
            p.Y += 30;
            lblPoid = creerLabel("Poids", "lblPoid", p, s);
            p.Y = y +0;
            p.X = x + 250;
            lblPersonalite = creerLabel("Personnalité", "txtpersonal", p, s);
            p.Y += 60;
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
            this.Controls.Add(lblPersonalite);
            lblPersonalite.Visible = true;

            this.Controls.Add(lblAge);
            this.Controls.Add(lblNom);
            this.Controls.Add(lblPoid);
            this.Controls.Add(lblPrenom);
            this.Controls.Add(lblTaille);
            this.Controls.Add(lblGlyc);
            this.Controls.Add(lblObjGlycHaut);
            this.Controls.Add(lblObjGlycBas);
            this.Controls.Add(clboxPersonnalite);
            clboxPersonnalite.Visible = true;

            this.Controls.Add(btnProfil1);
            this.Controls.Add(btnProfil2);
            this.Controls.Add(btnProfil3);
            #endregion

            grbSexe.Visible = true;
            btnRetour.Visible = true;
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
            string[] personalitee = new string[clboxPersonnalite.CheckedItems.Count];
            for(int i = 0; i < clboxPersonnalite.CheckedItems.Count; i++)
            {
                personalitee[i] = clboxPersonnalite.CheckedItems[i].ToString();
            }
            
            if (glycemieObjBas > glycemieObjHaut)
            {
                double it = glycemieObjBas;
                glycemieObjBas = glycemieObjHaut;
                glycemieObjHaut = it;
            }

            IHM.IHM_Joueur.addJoueur(new Metiers.Joueur(nom, age, personalitee,prenom, sex, taille, poids, glycemie, glycemieObjBas, glycemieObjHaut,20.0));
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
                if (t.Text == "")
                {
                    check = false;
                }
            }
            if (clboxPersonnalite.CheckedItems.Count == 0)
            {
                check = false;
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
        private void remplirFormulaireJoueur(string prenom, string[]pers,int age, string nom, char sex, int taille, double poids, double glyc, double glycObBas, double glycObHaut)
        {
            
            /*for(int i = 0; i < clboxPersonnalite.Items.Count; i++)
            {
                clboxPersonnalite.SetItemChecked(i, false);
            }*/
            txtAge.Text = age.ToString();
            txtNom.Text = nom;
            txtPrenom.Text = prenom;
            txtPoid.Text = poids.ToString();
            txtGlyc.Text = glyc.ToString();
            txtObjGlycBas.Text = glycObBas.ToString();
            txtObjGlycHaut.Text = glycObHaut.ToString();
            txtTaille.Text = taille.ToString();
            foreach(string s in pers)
            {
                clboxPersonnalite.SetItemChecked(recherche(clboxPersonnalite, s), true);
            }
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

        private int recherche(CheckedListBox clb, string s)
        {
            int res =0;
            for(int i = 0; i < clb.Items.Count; i++)
            {
                if (s == clb.Items[i].ToString())
                {
                    res =i;
                    break;
                }
            }
            return res;
        }

        private void nettoyage()
        {
            string[] tab = { "Sportif", "Gourmand", "VideoGamer", "Social", "Studieux", "Dépressif", "Peureux" };
            foreach (TextBox c in this.Controls.OfType<TextBox>())
            {
                c.Text = "";
            }
            for (int i = 0; i < clboxPersonnalite.Items.Count; i++)
            {
                clboxPersonnalite.SetItemChecked(i, false);
            }
            foreach(RadioButton r in grbSexe.Controls)
            {
                r.Checked = false;
            }
            clboxPersonnalite.Items.Clear();
            foreach(String s in tab)
            {
                clboxPersonnalite.Items.Add(s);
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
            lbl.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private CheckedListBox creerCheckList(string nom, Point Point)
        {
            CheckedListBox clbox1 = new CheckedListBox();
            clbox1.FormattingEnabled = true;
            clbox1.Items.AddRange(new object[] {
            "Sportif",
            "Gourmand",
            "VideoGamer",
            "Social",
            "Studieux",
            "Dépressif",
            "Peureux"});
            clbox1.Location = new System.Drawing.Point(599, 144);
            clbox1.Name = nom;
            clbox1.Size = new System.Drawing.Size(101, 49);
            clbox1.TabIndex = 1;
            return clbox1;
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
