﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace DiabManager
{
    /**
     * @author Killian Matter
     * @version 1.7
     */
    public partial class frmMenu : Form
    {
        #region variables local       
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

        Color couleurOrigin = Color.Cyan;
        string text;
        private Point p = new Point(280, 35);
        private Size s = new Size(520, 101);
        //Premier affichage
        private Label Titre;
        private Button btnLancePart;
        private Button btnLancerTuto;
        //Deuxième affichage
        private Label lblText;
        private Button btnLancerJeu;
        private Button btnSuite;
        //Troixième affichage
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
        /// Création d'une instance de la classe frmMenu
        /// </summary>
        public frmMenu()
        {
            InitializeComponent();
            #region Titre
            //Création du titre
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
            //Création du bouton de lancement de partie
            btnLancePart = creerButton("Lancer Partie", "btnPartie",p,s);
            ajoutEvClick(btnLancePart, new EventHandler(LancerPart_Click));

            p = new Point(360, 240);
            //Création du bouton de lancement de tuto
            btnLancerTuto = creerButton("Lancer Tutoriel", "btnTuto",p,s);
            ajoutEvClick(btnLancerTuto, new EventHandler(btnLancerTuto_Click));

            s = new Size(154, 32);
            p = new Point(408, 310);
            //Création du bouton retour
            btnLancerJeu = creerButton("Lancer jeu", "btnLancerJeu", p, s);
            ajoutEvClick(btnLancerJeu, new EventHandler(btnLancerJeu_Click));
            this.Controls.Add(btnLancerJeu);
            btnLancerJeu.Visible = false;
            p.X += 165;
            //Création du bouton valider
            btnValider = creerButton("Valider", "btnValider", p, s);
            ajoutEvClick(btnValider, new EventHandler(btnValider_Click));
            this.Controls.Add(btnValider);
            btnValider.Visible = false;
            //Création bouton suite
            btnSuite = creerButton("Suite", "btnSuite", p, s);
            ajoutEvClick(btnSuite, new EventHandler(btnSuite_Click));
            this.Controls.Add(btnSuite);
            btnSuite.Visible = false;
            //Création bouton bonne nouvelle
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

        //Événements

        /// <summary>
        /// Fonction qui gère le clic sur le titre
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Titre_Click(object sender, EventArgs e)
        {
            changercolor();
        }

        /// <summary>
        /// Fonction qui démarre la fenêtre de scénario
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void LancerPart_Click(object sender, EventArgs e)
        {
            affScenario();
        }

        /// <summary>
        /// Fonction qui gère le clic sur le bouton nouveau
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNouv_Click(object sender, EventArgs e)
        {
            Button bu = (Button)sender;
            if (bu.Text == "Bonne nouvelle")
            {
                if (!lblNouvelles.Visible)
                {
                    lblNouvelles.ForeColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
                    lblNouvelles.Visible = true;
                }
                lblNouvelles.Text = "Votre visite est remboursée à 90% par la Sécurité Sociale.";
                bu.Enabled = false;
                compt --;
            }
            else
            {
                if (!lblNouvelles.Visible)
                {
                    lblNouvelles.ForeColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
                    lblNouvelles.Visible = true;
                }
                lblNouvelles.Text = "Vous êtes diabétique, vous allez donc devoirs faire attention a votre taux de glycémie, " +
                    Environment.NewLine+"a ce que vous mangerez et à ce que vous allez faire.";
                bu.Enabled = false;
                compt--;
            }
            if (compt == 0)
            {
                btnLancerJeu.Visible = true;
            }
        }

        /// <summary>
        /// Fonction qui gère le clic sur le bouton Lancer tuto
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLancerTuto_Click(object sender, EventArgs e)
        {
            frmTuto frm = new frmTuto(cdPicker.Color,couleurOrigin);
            frm.ShowDialog();
        }

        /// <summary>
        /// Fonction qui gère le clic sur le bouton Lancer jeu
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLancerJeu_Click(object sender, EventArgs e)
        {
            Exit = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Fonction qui gère le clic sur le bouton Profils
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
                remplirFormulaireJoueur("Anne", new string[] { "Social", "Studieux" }, 18, "Metzger", 'F', 160, 55, 1, 0.9,1.8 );
            }
            else if(b.Text == "Profil 2")
            {
                remplirFormulaireJoueur("Jean",new string[]{"Gourmand","VideoGamer"}, 10, "Holler", 'H', 130, 30, 0.7, 1, 1.8);
            }
            else
            {
                remplirFormulaireJoueur("Camille",new string[] {"Peureux","Sportif"}, 26, "Muller", 'F', 150, 50, 2.1, 1.4, 1.8);
            }
        }

        /// <summary>
        /// Fonction qui gère le clic sur le bouton valider
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

        /// <summary>
        /// Fonction qui gère le clic sur le bouton suite
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSuite_Click(object sender, EventArgs e)
        {
            btnSuite.Visible = false;
            affFormJoueur();
        }

        //Les keypress
        /// <summary>
        /// Fonction qui interdit l'entrée de lettres
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
        /// Fonction qui interdit l'entrée de nombres
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
        /// Fonction qui gère l'entrée des virgules
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void NoLetterOneComma_KeyPress(Object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || (char.IsSymbol(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',') // Si l'utilisateur appuie sur la touche virgule
            {
                if (t.Text.Contains(","))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            if (!t.Text.Contains(','))
            {
                t.MaxLength = 3;
            }
            else
            {
                t.MaxLength = 5;
            }
        }

        #endregion

        #region fonctions

        /// <summary>
        /// Fonction qui permet de changer la couleur (easter egg)
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
        /// Affichage des scénarios
        /// </summary>
        private void affScenario()
        {
            foreach(Button c in this.Controls.OfType<Button>())
            {
                c.Visible = false;
            }
            Point p = new System.Drawing.Point(173, 125);
            Size s = new System.Drawing.Size(600, 100);
            lblText = creerLabel("Bienvenue dans notre Laboratoire DiabManager ! " +
                "Si vous êtes ici c'est pour un diagnostic pour le Diabète n'est ce pas ? " +
                "Veuillez remplir le formulaire suivant afin de mener à bien votre diagnostic",
                "txtTextHisto",p,s);
            lblText.Visible = true;
            this.Controls.Add(lblText);
            btnSuite.Visible = true;

        }

        /// <summary>
        /// Affichage du résultat du dialogue
        /// </summary>
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
            lblText = creerLabel("Bien, j'ai ici vos résultats de votre diagnostic, " +
                "j'ai une bonne et une mauvaise nouvelle, laquelle voulez vous entendre en premier ?","txtdiag", p, s);
            lblText.Visible = true;
            text = lblText.Text;
            this.Controls.Add(lblText);
            p.Y += 40;
            s = new System.Drawing.Size(154, 32);
            
            btnBonneNouv.Visible = true;
            btnMauvaiseNouv.Visible = true;
        }
        
        /// <summary>
        /// Affichage du formulaire joueur
        /// </summary>
        private void affFormJoueur()
        {
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
            ajoutEvKeypress(txtGlyc, new KeyPressEventHandler(NoLetterOneComma_KeyPress));
            toolTipGlyc.SetToolTip(txtGlyc, "Glycémie de départ");
            p.Y += 30;
            txtObjGlycHaut = creerTextbox("txtObjGlycHaut", p, s);
            ajoutEvKeypress(txtObjGlycHaut, new KeyPressEventHandler(NoLetterOneComma_KeyPress));
            toolTipHaut.SetToolTip(txtObjGlycHaut, "Votre glycémie devra rester en dessous de cette valeur");
            p.Y += 30;
            txtObjGlycBas = creerTextbox("txtObjGlycBas", p, s);
            ajoutEvKeypress(txtObjGlycBas, new KeyPressEventHandler(NoLetterOneComma_KeyPress));
            toolTipBas.SetToolTip(txtObjGlycBas, "Votre glycémie devra rester en dessous de cette valeur");
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
            lblPoid = creerLabel("Poids (kg)", "lblPoid", p, s);
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

            txtPrenom.MaxLength = 20;
            txtNom.MaxLength = 20;
            txtAge.MaxLength = 3;
            txtPoid.MaxLength = 3;
            txtTaille.MaxLength = 3;
            txtGlyc.MaxLength = 3;
            txtObjGlycHaut.MaxLength = 3;
            txtObjGlycBas.MaxLength = 3;

            grbSexe.Visible = true;
            btnLancerJeu.Visible = false;
            btnValider.Visible = true;
            btnProfil1.Visible = true;
            btnProfil2.Visible = true;
            btnProfil3.Visible = true;
        }
        
        /// <summary>
        /// Radiobutton du sexe du joueur
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
        /// Créer le joueur
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
            if (glycemie <= 0)
            {
                glycemie = 0.4;
            }
            if(glycemie >= 3)
            {
                glycemie = 2.2;
            }
            if (glycemieObjBas <= 0.5)
            {
                glycemieObjBas = 0.7;
            }
            if(glycemieObjHaut >= 2)
            {
                glycemieObjHaut = 1.8;
            }

            IHM.IHM_Joueur.addJoueur(new Metiers.Joueur(nom, age, personalitee,prenom, sex, taille, poids, glycemie, glycemieObjBas, glycemieObjHaut,20.0));
        }
        
        /// <summary>
        /// Personnalités du joueur
        /// </summary>
        /// <returns>Si la personnalité est cochée</returns>
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
        /// Replissage du formulaire du joueur
        /// </summary>
        /// <param name="prenom">Le prenom.</param>
        /// <param name="age">L'âge.</param>
        /// <param name="nom">Le nom.</param>
        /// <param name="sex">Le sexe.</param>
        /// <param name="taille">La taille.</param>
        /// <param name="poids">Le poids.</param>
        /// <param name="glyc">La glycémie.</param>
        /// <param name="glycObBas">L'objectif glycémique bas.</param>
        /// <param name="glycObHaut">L'objectif glycémique haut.</param>
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
        
        /// <summary>
        /// Recherches the specified CLB.
        /// </summary>
        /// <param name="clb">The checkedlistbox searched.</param>
        /// <param name="s">The string searched in the checkedlistbox</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Nettoyage des cases à cocher
        /// </summary>
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
        /// Creer un label
        /// </summary>
        /// <param name="texte">Le texte.</param>
        /// <param name="nomlabel">Le nom du label.</param>
        /// <param name="location">La location.</param>
        /// <param name="size">La taille.</param>
        /// <returns>Le label</returns>
        private Label creerLabel(String texte,String nomlabel,Point location, Size size)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.ForeColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            lbl.Location = location;
            lbl.Name = nomlabel;
            lbl.Size = size;
            lbl.Text = texte;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            return lbl;
        }

        /// <summary>
        /// Creer un bouton
        /// </summary>
        /// <param name="texte">Le texte.</param>
        /// <param name="nombutton">Le nom du button.</param>
        /// <param name="location">La location.</param>
        /// <param name="size">La taille.</param>
        /// <returns>Le bouton</returns>
        private Button creerButton(String texte, String nombutton, Point location, Size size)
        {
            Button btn = new Button();
            btn.BackColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn.Font = new System.Drawing.Font("Myanmar Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        /// Creer un groupbox
        /// </summary>
        /// <param name="texte">Le texte.</param>
        /// <param name="nomGroupbox">Le nom du groupbox.</param>
        /// <param name="location">La location.</param>
        /// <param name="size">La taille.</param>
        /// <returns>Le groupbox</returns>
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
            grbx.ForeColor = cdPicker.Color == Color.Black ? couleurOrigin : cdPicker.Color;
            grbx.Location = location;
            grbx.Name = nomGroupbox;
            grbx.Size = size;
            grbx.TabIndex = 0;
            grbx.TabStop = false;
            grbx.Text = texte;
            return grbx;
        }

        /// <summary>
        /// Creer un radiobutton
        /// </summary>
        /// <param name="texte">Le texte.</param>
        /// <param name="nomRdb">Le nom du radiobutton.</param>
        /// <param name="loc">La location</param>
        /// <param name="size">La size.</param>
        /// <param name="tabind">Le tabind.</param>
        /// <returns>Le radiobutton</returns>
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
        /// Creer un textbox
        /// </summary>
        /// <param name="nomTxt">Le nom du textbox.</param>
        /// <param name="loc">La location.</param>
        /// <param name="size">La taille.</param>
        /// <returns>Le textbox</returns>
        private TextBox creerTextbox(String nomTxt, Point loc, Size size)
        {
            TextBox txt = new TextBox();
            txt.Location = loc;
            txt.Name = nomTxt;
            txt.Size = size;
            txt.TabIndex = 0;
            return txt;
        }
        /// <summary>
        /// Creer un checkedlistbox
        /// </summary>
        /// <param name="nom">Le nom.</param>
        /// <param name="Point">Le point.</param>
        /// <returns>Le checkedlistbox</returns>
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
        /// <summary>
        /// Ajouter un événement clic
        /// </summary>
        /// <param name="c">Le contrôle.</param>
        /// <param name="eHand">Le handler</param>
        private void ajoutEvClick(Control c,EventHandler eHand) {
            c.Click += eHand;
        }

        /// <summary>
        /// Ajouter un événement keypress
        /// </summary>
        /// <param name="c">Le cotntrôle.</param>
        /// <param name="eHand">Le handler.</param>
        private void ajoutEvKeypress(Control c,KeyPressEventHandler eHand)
        {
            c.KeyPress += eHand;
        }

        #endregion
    }
}
