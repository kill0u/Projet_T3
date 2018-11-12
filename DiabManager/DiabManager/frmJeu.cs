using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
            PrivateFontCollection f = new PrivateFontCollection();
            String path = Application.ExecutablePath;
            path = Directory.GetParent(path).ToString();
            path = path + @"\digital-7.ttf";
            f.AddFontFile(path);
            lblAffTemps.Font = new Font(f.Families[0], 26,FontStyle.Bold);
            lblTemps.Font = new Font(f.Families[0], 26, FontStyle.Bold);
        }

        /// <summary>
        /// Transforme la liste d'action en bouton 
        /// </summary>
        /// <param name="liste">Liste de toutes les actions disponibles</param>
        public void loadActions(Object liste)
        {
            Dictionary<Actions, bool> listeActions = (Dictionary<Actions, bool>)liste;
            Point p = new Point(10, 10);
            ToolTip tt = new ToolTip();
            foreach(var a in listeActions)
            {
                Button b = new Button();
                b.Location = p;
                b.Text = a.Key.Nom;
                b.Name = a.Key.Nom;
                b.Size = new Size(100, 50);
                b.Click += new System.EventHandler(boutonClick);

                tt.SetToolTip(b, a.Key.Desc);

                pnlActions.Controls.Add(b);

                p.X += 110;

                if (p.X + 100 >= pnlActions.Width)
                {
                    p.X = 10;
                    p.Y += 60;
                }
            }
        }

        /// <summary>
        /// Active ou désactive les boutons des actions (selon si les actions sont possibles à faire)
        /// </summary>
        /// <param name="listActions">Liste de toutes les actions disponibles</param>
        public void setActiveButton(Object listActions)
        {
            Dictionary<Actions, bool> liste = (Dictionary<Actions, bool>)listActions;
            foreach(var a in liste)
            {
                            
                //Etant donné que cette fonction est appelé depuis un timer (=thread), il faut utiliser une fonction qui va déléguer ca au thread principal pour pouvoir utilisé controls
                this.BeginInvoke((Action)(() => {

                    Control[] l = pnlActions.Controls.Find(a.Key.Nom, true);
                    if (l.Length != 0)
                    {
                        Button b = (Button)l[0];
                        b.Enabled = a.Value;
                    }
                    

                }));
                        
                
            }
        }

        /// <summary>
        /// Met à jour les informations du joueur
        /// </summary>
        /// <param name="infos">Tableau rassemblant les infos du joueur (<see cref="Joueur"/>: nom, glycemie, etc.)</param>
        public void setInfosJoueur(string[] infos)
        {

            this.BeginInvoke((Action)(() => {
                lblNom.Text = infos[1] + " " + infos[0];
                if (infos[4] == "H")
                {
                    if (int.Parse(infos[10]) >= 0 && int.Parse(infos[10]) < 21)
                    {
                        lblStress.Text = "Vous etes pas stressé - "+infos[10];
                    }
                    if (int.Parse(infos[10]) >= 21 && int.Parse(infos[10]) < 61)
                    {
                        lblStress.Text = "Vous etes stressé - " + infos[10];
                    }
                    if (int.Parse(infos[10]) >= 61)
                    {
                        lblStress.Text = "Vous etes beaucoup stressé - " + infos[10];
                    }
                }
                else
                {
                    if (int.Parse(infos[10]) >= 0 && int.Parse(infos[10]) < 21)
                    {
                        lblStress.Text = "Vous etes pas stressée - " + infos[10];
                    }
                    if (int.Parse(infos[10]) >= 21 && int.Parse(infos[10]) < 61)
                    {
                        lblStress.Text = "Vous etes stressée - " + infos[10];
                    }
                    if (int.Parse(infos[10]) >= 61)
                    {
                        lblStress.Text = "Vous etes beaucoup stressée - " + infos[10];
                    }
                }
                if (int.Parse(infos[10]) >=90)
                {
                    lblStress.Text = "Burnout - " + infos[10];
                }
                lblGlycemie.Text = infos[9];
            }));
            
        }

        /// <summary>
        /// Met à jour l'heure de la journée
        /// </summary>
        /// <param name="temps">Heure de la journée</param>
        public void setTemps(TimeSpan temps)
        {
            this.BeginInvoke((Action)(() => {
                lblTemps.Text = temps.Hours + ":" + temps.Minutes;

            }));
        }

        /// <summary>
        /// Action a effectué lors du click sur le bouton
        /// </summary>
        /// <param name="sender">Bouton sur lequel on appuie</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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


        /// <summary>
        /// Met à jour l'action en cours
        /// </summary>
        /// <param name="desc">Nom et description de l'action</param>
        public void setAction(string desc)
        {
            this.BeginInvoke((Action)(() => {
                lblActions.Text = desc;

            }));
        }

        /// <summary>
        /// Met à jour l'(es) évènement(s) en cours
        /// </summary>
        /// <param name="desc">Nom et description d'(es) évènement(s)</param>
        public void setEvenement(string desc)
        {
            this.BeginInvoke((Action)(() => {
                lblEvents.Text = desc;
            }));
        }


        private void btnPiqure_Click(object sender, EventArgs e)
        {
            IHM.IHM_Joueur.getJoueur().calculGlycemieCourante(new Tuple<double, double>(-0.1 * IHM.IHM_Joueur.getJoueur().Stylo.dose, 1), IHM.IHM_Joueur.getJoueur().Stress);
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
        public System.Windows.Forms.DataVisualization.Charting.Chart getGraphe()
        {
            return GraphiqueGlycemie;
        }

        private void GraphiqueGlycemie_Customize(object sender, EventArgs e)
        {
            
        }
    }
}
