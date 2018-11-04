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

        public void loadActions(Object liste)
        {
            Dictionary<Actions, bool> listeActions = (Dictionary<Actions, bool>)liste;
            Point p = new Point(10, 10);
            foreach(var a in listeActions)
            {
                Button b = new Button();
                b.Location = p;
                b.Text = a.Key.Nom;
                b.Name = a.Key.Nom;
                b.Size = new Size(100, 50);
                b.Click += new System.EventHandler(boutonClick);


                pnlActions.Controls.Add(b);

                p.X += 110;

                if (p.X + 100 >= pnlActions.Width)
                {
                    p.X = 10;
                    p.Y += 60;
                }
            }
        }

        public void setActiveButton(Object listActions)
        {
            Dictionary<Actions, bool> liste = (Dictionary<Actions, bool>)listActions;
            foreach(var a in liste)
            {
                            
                //Etant donné que cette fonction est appelé depuis un timer (=thread), il faut utiliser une fonction qui va déléguer ca au thread principal pour pouvoir utilisé controls
                this.BeginInvoke((Action)(() => {

                    Control[] l = pnlActions.Controls.Find(a.Key.Nom, true);
                    Button b = (Button)l[0];
                    b.Enabled = a.Value;

                }));
                        
                
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
        public void modifStyloInsuline()
        {
            this.BeginInvoke((Action)(() => {
                if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu != 0)
                {
                    progressBarInsuline.Value = IHM.IHM_Joueur.getJoueur().Stylo.dose * 100 / IHM.IHM_Joueur.getJoueur().Stylo.DoseActu;
                }
                else { progressBarInsuline.Value = 0; }
                lblDose.Text = "Dose à injecter : " + IHM.IHM_Joueur.getJoueur().Stylo.dose;
                lblDoseActu.Text = "dose restante : " + IHM.IHM_Joueur.getJoueur().Stylo.DoseActu;
                if (!IHM.IHM_Joueur.getJoueur().Stylo.Disponible) { btnPiqure.Enabled = false; }
                else { btnPiqure.Enabled = true; }
            }));
            

        }


        public void setAction(string desc)
        {
            lblActions.Text = desc;
        }

        public void setEvenement(string desc)
        {
            lblEvents.Text = desc;
        }


        private void btnPiqure_Click(object sender, EventArgs e)
        {
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(-0.1 * IHM.IHM_Joueur.getJoueur().Stylo.dose, 1));
            IHM.IHM_Joueur.getJoueur().Stylo.DoseActu -= IHM.IHM_Joueur.getJoueur().Stylo.dose;
            if (IHM.IHM_Joueur.getJoueur().Stylo.DoseActu < IHM.IHM_Joueur.getJoueur().Stylo.dose) { IHM.IHM_Joueur.getJoueur().Stylo.dose = IHM.IHM_Joueur.getJoueur().Stylo.DoseActu; }
            IHM.IHM_Joueur.getJoueur().Stylo.Disponible = false;
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

        private void frmJeu_Shown(object sender, EventArgs e)
        {
            //Mise en place du jeu
            IHM.IHM_Actions.Update();
            IHM.IHM_Actions.updateTemps(Temps.getInstance().getHeureJournee());
            IHM.IHM_Joueur.Update();
            Gestionnaires.ActionControlleur.getInstance().UpdateAction(Temps.getInstance().getHeureJournee());
            modifStyloInsuline();
        }
    }
}
