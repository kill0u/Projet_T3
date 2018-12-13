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
using DiabManager.Composants;
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
            int screenheigt = Screen.PrimaryScreen.Bounds.Height;
            int screenwidht = Screen.PrimaryScreen.Bounds.Height;
            this.Height = screenheigt;
            this.Width = screenwidht;
            path = Directory.GetParent(path).ToString();
            path = path + @"\digital-7.ttf";
            f.AddFontFile(path);
            lblAffTemps.Font = new Font(f.Families[0], 26,FontStyle.Bold);
            lblTemps.Font = new Font(f.Families[0], 26, FontStyle.Bold);
            setFond("matin");
        }

        /// <summary>
        /// Transforme la liste d'action en bouton
        /// </summary>
        /// <param name="liste">Liste de toutes les actions disponibles</param>
        public void loadActions(Object liste, Object lt)
        {
            Dictionary<Actions, bool> listeActions = (Dictionary<Actions, bool>)liste;
            Point p = new Point(10, 10);
            ToolTip tt = new ToolTip();

            Dictionary<Actions, string> listTab = (Dictionary<Actions, string>)lt;
            Dictionary<string, Point> listPos = new Dictionary<string, Point>();

            foreach(var tab in listTab.Values)
            {
                if(!tcActions.TabPages.ContainsKey(tab))
                {
                    TabPage tp = new TabPage(tab);
                    tp.Name = tab;
                    tp.AutoScroll = true;
                    tcActions.TabPages.Add(tp);
                    listPos.Add(tab, p);
                }
            }

            foreach (var a in listeActions)
            {

                ActionPanel pan = new ActionPanel(a.Key);

                Point pa = listPos[listTab[a.Key]];

                pan.Location = pa;

                tt.SetToolTip(pan, a.Key.Desc);

                tcActions.TabPages[listTab[a.Key]].Controls.Add(pan);

                pa.X += 210;

                if (pa.X + 210 >= tcActions.Width)
                {
                    pa.X = 10;
                    pa.Y += 210;
                }
                listPos[listTab[a.Key]] = pa;
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
                        ActionPanel p = (ActionPanel)l[0];
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
        /// Met à jour les informations du joueur
        /// </summary>
        /// <param name="infos">Tableau rassemblant les infos du joueur (<see cref="Joueur"/>: nom, glycemie, etc.)</param>
        public void setInfosJoueur(string[] infos)
        {

            this.BeginInvoke((Action)(() => {
                //Infos du joueur
                lblNom.Text = infos[1] + " " + infos[0];
                Joueur Jcourant = IHM.IHM_Joueur.getJoueur();
                //Infos du stress
                if(Jcourant.Sexe == 'H')
                {
                    if (double.Parse(infos[10]) >= 0 && double.Parse(infos[10]) < 21)
                    {
                        lblStress.Text = "Vous n'êtes pas stressé";
                    }
                    if (double.Parse(infos[10]) >= 21 && double.Parse(infos[10]) < 61)
                    {
                        lblStress.Text = "Vous êtes stressé";
                    }
                    if (double.Parse(infos[10]) >= 61)
                    {
                        lblStress.Text = "Vous êtes très stressé";
                    }

                    if (double.Parse(infos[10]) >= 90)
                    {
                        lblStress.Text = "Burnout";
                    }
                }
                else
                {
                    if (double.Parse(infos[10]) >= 0 && double.Parse(infos[10]) < 21)
                    {
                        lblStress.Text = "Vous n'êtes pas stressée";
                    }
                    if (double.Parse(infos[10]) >= 21 && double.Parse(infos[10]) < 61)
                    {
                        lblStress.Text = "Vous êtes stressée";
                    }
                    if (double.Parse(infos[10]) >= 61)
                    {
                        lblStress.Text = "Vous êtes très stressée";
                    }

                    if (double.Parse(infos[10]) >= 90)
                    {
                        lblStress.Text = "Burnout";
                    }
                }
                

                //Infos de glycémie
                lblGlycemie.Text = infos[9];

                //Infos d'energie
                double energie = double.Parse(infos[11]);
                
                if (Jcourant.Sexe == 'H')
                {
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
                }
                else
                {
                    if (energie < 21)
                    {
                        lblEnergie.Text = "Vous êtes épuisée";
                    }
                    else if (energie < 41)
                    {
                        lblEnergie.Text = "Vous êtes fatiguée";
                    }
                    else if (energie < 61)
                    {
                        lblEnergie.Text = "Vous êtes un peu fatiguée";
                    }
                    else if (energie < 81)
                    {
                        lblEnergie.Text = "Vous vous sentez légèrement fatiguée";
                    }
                    else
                    {
                        lblEnergie.Text = "Vous êtes en pleine forme";
                    }
                }

                //Mise à jour du poids
                lblPoids.Text = infos[2];
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
        /// Met à jour l'action en cours
        /// </summary>
        /// <param name="desc">Nom et description de l'action</param>
        public void setAction(ActionPanel pan)
        {
            pan.Location = new Point(5, 20);
            this.BeginInvoke((Action)(() => {
                pnlAction.Controls.Add(pan);

            }));
        }

        public void setFond(String s)
        {
            if (s.ToLower() == "matin")
            {
                this.BackgroundImage = global::DiabManager.Properties.Resources.matin;
                //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            if(s.ToLower() == "midi")
            {
                this.BackgroundImage = global::DiabManager.Properties.Resources.midi;
                //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            if(s.ToLower() == "soir")
            {
                this.BackgroundImage = global::DiabManager.Properties.Resources.nuit;
                //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
        }

        public void removeAction()
        {
            this.BeginInvoke((Action)(() => {
                if (pnlAction.Controls.OfType<ActionPanel>().Count() > 0)
                    pnlAction.Controls.OfType<ActionPanel>().First().Dispose();

            }));
        }

        /// <summary>
        /// Met à jour l'(es) évènement(s) en cours
        /// </summary>
        /// <param name="desc">Nom et description d'(es) évènement(s)</param>
        public void setEvenement(List<ActionPanel> pan)
        {
            this.BeginInvoke((Action)(() => {
                List<ActionPanel> suppr = new List<ActionPanel>();
                
                suppr.AddRange(pnlEvent.Controls.OfType<ActionPanel>());
                foreach (var sup in suppr)
                {
                    sup.Dispose();
                }
                Point p = new Point(5, 20);
                foreach (var add in pan)
                {
                    add.Location = p;

                    pnlEvent.Controls.Add(add);

                    p.X += 210;

                    if (p.X + 210 >= pnlActions.Width)
                    {
                        p.X = 10;
                        p.Y += 210;
                    }
                }

            }));
        }

        // nombre de doses restantes pour la piqure rapide.
        private int m_nbDose=3;
        public int dose
        {
            get { return m_nbDose; }
            set { m_nbDose = value; }
        }

        // action a effectuer pour la piqure rapide lors du nouveau jour (renouvellement de stock)
        public void newDay() {
            dose = 3;
            this.BeginInvoke((Action)(() => {
                progressBar1.Value=100;
                progressBar2.Value = 100;
                progressBarInsuline.Value = 100;
            }));
        }

        // Piqure rapide
        private void btnPiqure_Click(object sender, EventArgs e)
        {
            IHM.IHM_Joueur.getJoueur().GlycemieCourante-=0.6;

            m_nbDose--;
            if (dose== 0)
            {
                btnPiqure.Enabled = false;
                progressBarInsuline.Value = 0;
            }
            else if (dose == 1) progressBar2.Value = 0;
            else progressBar1.Value = 0;
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

            for (int i = 0; i < 50; i++)
            {
                IHM.IHM_Joueur.UpdateGraph();
            }
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
            this.BeginInvoke((Action)(() => {
                lblAffJour.Text = j;
                txtJournal.Text += "======================" + j + "======================" + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Ajoute au journal une action ou évènement
        /// </summary>
        /// <param name="l">Description de l'action</param>
        public void addLog(string l)
        {
            this.BeginInvoke((Action)(() => {
                txtJournal.Text += l;
            }));
        }

        /// <summary>
        /// Récupère le journal d'activité
        /// </summary>
        /// <returns>Le journal d'activité</returns>
        public string getLog()
        {
            return txtJournal.Text;
        }

        /// <summary>
        /// Bouton de resucrage de la personne
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            IHM.IHM_Joueur.getJoueur().GlycemieCourante += 0.4;
            if (IHM.IHM_Joueur.getJoueur().GlycemieCourante > Temps.getInstance().gMax)

                MessageBox.Show("Vous avez pris du sucre, mais ce n'était pas la meilleure idée");
            else
                MessageBox.Show("Vous avez pris du sucre, vous allez mieux");
        }
    }
}
