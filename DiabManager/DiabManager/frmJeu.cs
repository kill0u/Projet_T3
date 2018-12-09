using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public Composants.GradientPanel g;
        public Composants.GradientPanel Gp
        {
            get
            {
                return g;
            }
        }

        public frmJeu()
        {
            InitializeComponent();
            PrivateFontCollection f = new PrivateFontCollection();
            String path = Application.ExecutablePath;
            int screenheigt = Screen.PrimaryScreen.Bounds.Height;
            int screenwidht = Screen.PrimaryScreen.Bounds.Height;
            this.Height = screenheigt;
            this.Width = screenwidht;
            path = Directory.GetParent(path).ToString();
            path = path + @"\digital-7.ttf";
            f.AddFontFile(path);
            lblAffTemps.Font = new Font(f.Families[0], 26,FontStyle.Bold);
            lblTemps.Font = new Font(f.Families[0], 26, FontStyle.Bold);
            g = gplFond;
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

                Panel pan = new Panel();
                pan.Location = p;
                pan.Name = a.Key.Nom;
                pan.Size = new Size(200, 200);
                pan.Click += new System.EventHandler(boutonClick);
                tt.SetToolTip(pan, a.Key.Desc);

                Label l = new Label();
                l.Text = a.Key.Nom;
                l.Location = new Point(5, 5);

                Label l2 = new Label();
                l2.Text = a.Key.Desc;
                l2.Location = new Point(5, 25);
                l2.MaximumSize = new Size(190, 120);
                l2.AutoSize = true;

                pan.Controls.Add(l);
                pan.Controls.Add(l2);

                pnlActions.Controls.Add(pan);

                p.X += 210;

                if (p.X + 210 >= pnlActions.Width)
                {
                    p.X = 10;
                    p.Y += 210;
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
                        Panel p = (Panel)l[0];
                        if (a.Value)
                            p.BackColor = Color.Green;
                        else
                            p.BackColor = Color.Red;
                        p.Enabled = a.Value;
                    }
                    

                }));
                        
                
            }
        }

        /// <summary>
        /// Action a effectué lors du click sur le bouton
        /// </summary>
        /// <param name="sender">Bouton sur lequel on appuie</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void boutonClick(object sender, EventArgs e)
        {
            Panel b = (Panel)sender;
            IHM.IHM_Actions.EffectuerAction(b.Name);
        }

        /// <summary>
        /// Met à jour les informations du joueur
        /// </summary>
        /// <param name="infos">Tableau rassemblant les infos du joueur (<see cref="Joueur"/>: nom, glycemie, etc.)</param>
        public void setInfosJoueur(string[] infos)
        {

            this.BeginInvoke((Action)(() => {
                //Infos du joueur
                lblNom.Text = infos[1] + " " + infos[0];

                //Infos du stress
               
                if (double.Parse(infos[10]) >= 0 && double.Parse(infos[10]) < 21)
                {
                    lblStress.Text = "Vous n'etes pas stressée";
                }
                if (double.Parse(infos[10]) >= 21 && double.Parse(infos[10]) < 61)
                {
                    lblStress.Text = "Vous etes stressée";
                }
                if (double.Parse(infos[10]) >= 61)
                {
                    lblStress.Text = "Vous etes beaucoup stressée";
                }
                
                if (double.Parse(infos[10]) >=90)
                {
                    lblStress.Text = "Burnout";
                }

                //Infos de glycémie
                lblGlycemie.Text = infos[9];

                //Infos d'energie
                double energie = double.Parse(infos[11]);
                if (energie < 21)
                {
                    lblEnergie.Text = "Vous êtes épuisé";
                }
                else if (energie < 41)
                {
                    lblEnergie.Text = "Vous êtes fatigué";
                }
                else if (energie < 61)
                {
                    lblEnergie.Text = "Vous êtes un peu fatigué";
                }
                else if (energie < 81)
                {
                    lblEnergie.Text = "Vous vous sentez légèrement fatigué";
                }
                else
                {
                    lblEnergie.Text = "Vous êtes en pleine forme";
                }
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
            if (Temps.getInstance().CoeffVitesse < 32)
            {
                Temps.getInstance().changeSpeed(Temps.getInstance().CoeffVitesse * 2);
                lblVitesse.Text = Temps.getInstance().CoeffVitesse + "x";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Temps.getInstance().CoeffVitesse > 0.25)
            {
                Temps.getInstance().changeSpeed(Temps.getInstance().CoeffVitesse / 2);
                lblVitesse.Text = Temps.getInstance().CoeffVitesse + "x"; 
            }
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

        /// <summary>
        /// Affiche le jour de la semaine
        /// </summary>
        /// <param name="j">jour</param>
        public void setJour(string j)
        {
            lblAffJour.Text = j;
        }

        /// <summary>
        /// Ajoute au journal une action ou évènement
        /// </summary>
        /// <param name="l">Description de l'action</param>
        public void addLog(string l)
        {
            txtJournal.Text += l;
        }

        
    }
}
