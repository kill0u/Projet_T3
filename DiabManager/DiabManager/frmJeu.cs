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
        /// <summary>
        /// Constructeur du jeu, initialise certaines valeurs
        /// </summary>
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
        /// Transforme la liste d'actions en boutons
        /// </summary>
        /// <param name="liste">Liste de toutes les actions disponibles</param>
        /// <param name="lt">Liste des onglets d'actions</param>
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
                //Étant donné que cette fonction est appelée depuis un timer (=thread), il faut utiliser une fonction qui va la déléguer au thread principal pour pouvoir utiliser controls
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

                if (double.Parse(infos[10]) >= 0 && double.Parse(infos[10]) < 21)
                {
                    lblStress.Text = "Vous n'êtes pas stressé(e)";
                }
                if (double.Parse(infos[10]) >= 21 && double.Parse(infos[10]) < 61)
                {
                    lblStress.Text = "Vous êtes stressé(e)";
                }
                if (double.Parse(infos[10]) >= 61)
                {
                    lblStress.Text = "Vous êtes très stressé(e)";
                }

                if (double.Parse(infos[10]) >= 90)
                {
                    lblStress.Text = "Burnout";
                }
                

                //Infos de glycémie
                lblGlycemie.Text = infos[9];

                //Infos d'énergie
                double energie = double.Parse(infos[11]);

                if (energie < 21)
                {
                    lblEnergie.Text = "Vous êtes épuisé(e)";
                }
                else if (energie < 41)
                {
                    lblEnergie.Text = "Vous êtes fatigué(e)";
                }
                else if (energie < 61)
                {
                    lblEnergie.Text = "Vous êtes un peu fatigué(e)";
                }
                else if (energie < 81)
                {
                    lblEnergie.Text = "Vous vous sentez légèrement fatigué(e)";
                }
                else
                {
                    lblEnergie.Text = "Vous êtes en pleine forme";
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

        /// <summary>
        /// Change le fond du jeu
        /// </summary>
        /// <param name="s">Nom du fond</param>
        public void setFond(String s)
        {
            if (s.ToLower() == "matin")
            {
                this.BackgroundImage = global::DiabManager.Properties.Resources.matin;
            }
            if(s.ToLower() == "midi")
            {
                this.BackgroundImage = global::DiabManager.Properties.Resources.midi;
            }
            if(s.ToLower() == "soir")
            {
                this.BackgroundImage = global::DiabManager.Properties.Resources.nuit;
            }
        }

        /// <summary>
        /// Enlève une action de l'affichage
        /// </summary>
        public void removeAction()
        {
            this.BeginInvoke((Action)(() => {
                if (pnlAction.Controls.OfType<ActionPanel>().Any())
                    pnlAction.Controls.OfType<ActionPanel>().First().Dispose();

            }));
        }

        /// <summary>
        /// Met à jour l'(es) évènement(s) en cours
        /// </summary>
        /// <param name="desc">Nom et description du(des) évènement(s)</param>
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

        //Nombre de doses restantes pour la piqûre rapide.
        private int m_nbDose=3;
        public int dose
        {
            get { return m_nbDose; }
            set { m_nbDose = value; }
        }

        //Action à effectuer pour la piqûre rapide lors du nouveau jour (renouvellement des stocks)
        public void newDay() {
            dose = 3;
            this.BeginInvoke((Action)(() => {
                progressBar1.Value=100;
                progressBar2.Value = 100;
                progressBarInsuline.Value = 100;
            }));
        }

        /// <summary>
        /// La fonction permettant de cliquer sur le bouton piqûre
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Bouton de pause
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Bouton pour accélerer le temps
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAvanceeTemps_Click(object sender, EventArgs e)
        {
            if (Temps.getInstance().CoeffVitesse < 32)
            {
                Temps.getInstance().changeSpeed(Temps.getInstance().CoeffVitesse * 2);
                lblVitesse.Text = Temps.getInstance().CoeffVitesse + "x";
            }

        }

        /// <summary>
        /// Bouton pour ralentir
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (Temps.getInstance().CoeffVitesse > 0.25)
            {
                Temps.getInstance().changeSpeed(Temps.getInstance().CoeffVitesse / 2);
                lblVitesse.Text = Temps.getInstance().CoeffVitesse + "x"; 
            }
        }

        /// <summary>
        /// Fonction de la mise en place du jeu
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Accesseur du graphe
        /// </summary>
        /// <returns>Le graphe de la glycémie</returns>
        public System.Windows.Forms.DataVisualization.Charting.Chart getGraphe()
        {
            return GraphiqueGlycemie;
        }

        /// <summary>
        /// Fonction de customisation du graphe
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GraphiqueGlycemie_Customize(object sender, EventArgs e)
        {
            // Do nothing because of X and Y.
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
        /// Ajoute au journal une action ou un événement
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
