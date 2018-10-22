using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiabManager.Metiers;

namespace DiabManager
{
    public partial class frmJeu : Form
    {
        public frmJeu()
        {
            InitializeComponent();
 
        }

        public void setActiveButton(Object listActions)
        {
            this.BeginInvoke((Action)(() => {
                pnlActions.Controls.Clear();
            }));

            Dictionary<Actions, bool> liste = (Dictionary<Actions, bool>)listActions;
            Point p = new Point(10, 10);
            foreach(var a in liste)
            {
                if (a.Value)
                {

                    Button b = creerButton(a.Key.Nom, a.Key.Nom, p, new Size(100, 50));
                    b.Click += new System.EventHandler(boutonClick);
                   
                    //Etant donné que cette fonction est appelé depuis un timer (=thread), il faut utiliser une fonction qui va déléguer ca au thread principal pour pouvoir utilisé controls
                    this.BeginInvoke((Action)(() => {
                        pnlActions.Controls.Add(b);
                    }));
                        
                    
                    p.X += 110;

                    if(p.X + 100 >= pnlActions.Width)
                    {
                        p.X = 10;
                        p.Y += 60;
                    }
                }
            }
        }

        public void setInfosJoueur(string[] infos)
        {

            this.BeginInvoke((Action)(() => {
                lblNom.Text = infos[1] + " " + infos[0];

                lblGlycemie.Text = infos[9];
            }));
            
        }

        public void setTemps(TimeSpan temps)
        {
            this.BeginInvoke((Action)(() => {
                lblTemps.Text = temps.ToString();

            }));
        }

        private void boutonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            IHM.IHM_Actions.EffectuerAction(b.Name);
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

        

        private void btnDiminuer_Click(object sender, EventArgs e)
        {
            if (IHM.IHM_Joueur.getJoueur().Stylo.dose != 0)
            {
                IHM.IHM_Joueur.getJoueur().Stylo.dose--;
                modifStyloInsuline();
            }

        }

        private void btnAugmenter_Click(object sender, EventArgs e)
        {
            if (IHM.IHM_Joueur.getJoueur().Stylo.dose != IHM.IHM_Joueur.getJoueur().Stylo.DoseMax)
            {
                IHM.IHM_Joueur.getJoueur().Stylo.dose++;
                modifStyloInsuline();
            }

        }
        /// <summary>
        /// Fonction qui modifie les informations affichés du stylo d'insuline.
        /// </summary>
        private void modifStyloInsuline()
        {
            if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu != 0)
            {
                progressBarInsuline.Value = IHM.IHM_Joueur.getJoueur().Stylo.dose * 100 / IHM.IHM_Joueur.getJoueur().Stylo.DoseActu;
            }
            else { progressBarInsuline.Value = 0; }
            lblDose.Text = "Dose à injecter : " + IHM.IHM_Joueur.getJoueur().Stylo.dose;
            lblDoseActu.Text = "dose restante : " + IHM.IHM_Joueur.getJoueur().Stylo.DoseActu;
        }

        private void btnPiqure_Click(object sender, EventArgs e)
        {
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(-0.1 * IHM.IHM_Joueur.getJoueur().Stylo.dose, 1));
            IHM.IHM_Joueur.getJoueur().Stylo.DoseActu -= IHM.IHM_Joueur.getJoueur().Stylo.dose;
            if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu < IHM.IHM_Joueur.getJoueur().Stylo.dose) { IHM.IHM_Joueur.getJoueur().Stylo.dose = IHM.IHM_Joueur.getJoueur().Stylo.DoseActu; }
            modifStyloInsuline();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (Temps.getInstance().PlayPause())
            {
                btnPause.Text = "❚❚";
            }
            else
            {
                btnPause.Text = "▶";
            }
        }

        private void btnAvanceeTemps_Click(object sender, EventArgs e)
        {
            Temps.getInstance().changeSpeed(Temps.getInstance().CoeffVitesse * 2);
            lblVitesse.Text = Temps.getInstance().CoeffVitesse + "x";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Temps.getInstance().changeSpeed(Temps.getInstance().CoeffVitesse / 2);
            lblVitesse.Text = Temps.getInstance().CoeffVitesse + "x";
        }
    }
}
