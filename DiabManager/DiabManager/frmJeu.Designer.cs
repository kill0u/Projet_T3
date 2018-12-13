using DiabManager.Composants;

namespace DiabManager
{
    partial class frmJeu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJeu));
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.lblAffEvent = new System.Windows.Forms.Label();
            this.pnlHeure = new System.Windows.Forms.Panel();
            this.lblAffJour = new System.Windows.Forms.Label();
            this.lblAffTemps = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.lblAffActions = new System.Windows.Forms.Label();
            this.pnlGestionTemps = new System.Windows.Forms.Panel();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAvanceeTemps = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.tcActions = new System.Windows.Forms.TabControl();
            this.pnlInfos = new System.Windows.Forms.Panel();
            this.lblPoids = new System.Windows.Forms.Label();
            this.lblAffPoids = new System.Windows.Forms.Label();
            this.tabGraphJournal = new System.Windows.Forms.TabControl();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.GraphiqueGlycemie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabJournal = new System.Windows.Forms.TabPage();
            this.txtJournal = new System.Windows.Forms.TextBox();
            this.lblEnergie = new System.Windows.Forms.Label();
            this.lblAffEnergie = new System.Windows.Forms.Label();
            this.pnlPiqure = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnPiqure = new System.Windows.Forms.Button();
            this.progressBarInsuline = new System.Windows.Forms.ProgressBar();
            this.lblDoseActu = new System.Windows.Forms.Label();
            this.lblStress = new System.Windows.Forms.Label();
            this.lblAffStress = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblAffNom = new System.Windows.Forms.Label();
            this.lblGlycemie = new System.Windows.Forms.Label();
            this.lblAffGlycemie = new System.Windows.Forms.Label();
            this.pnlEvent.SuspendLayout();
            this.pnlHeure.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.pnlGestionTemps.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlInfos.SuspendLayout();
            this.tabGraphJournal.SuspendLayout();
            this.tabGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphiqueGlycemie)).BeginInit();
            this.tabJournal.SuspendLayout();
            this.pnlPiqure.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEvent
            // 
            this.pnlEvent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlEvent.AutoScroll = true;
            this.pnlEvent.BackColor = System.Drawing.Color.Silver;
            this.pnlEvent.Controls.Add(this.lblAffEvent);
            this.pnlEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlEvent.Location = new System.Drawing.Point(830, 28);
            this.pnlEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(964, 311);
            this.pnlEvent.TabIndex = 8;
            // 
            // lblAffEvent
            // 
            this.lblAffEvent.AutoSize = true;
            this.lblAffEvent.Location = new System.Drawing.Point(4, 6);
            this.lblAffEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffEvent.Name = "lblAffEvent";
            this.lblAffEvent.Size = new System.Drawing.Size(167, 20);
            this.lblAffEvent.TabIndex = 3;
            this.lblAffEvent.Text = "Evènements en cours:";
            // 
            // pnlHeure
            // 
            this.pnlHeure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeure.BackColor = System.Drawing.Color.Black;
            this.pnlHeure.Controls.Add(this.lblAffJour);
            this.pnlHeure.Controls.Add(this.lblAffTemps);
            this.pnlHeure.Controls.Add(this.lblTemps);
            this.pnlHeure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlHeure.Location = new System.Drawing.Point(1765, 29);
            this.pnlHeure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeure.Name = "pnlHeure";
            this.pnlHeure.Size = new System.Drawing.Size(813, 89);
            this.pnlHeure.TabIndex = 6;
            // 
            // lblAffJour
            // 
            this.lblAffJour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAffJour.AutoSize = true;
            this.lblAffJour.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffJour.ForeColor = System.Drawing.Color.Red;
            this.lblAffJour.Location = new System.Drawing.Point(558, 17);
            this.lblAffJour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffJour.Name = "lblAffJour";
            this.lblAffJour.Size = new System.Drawing.Size(160, 58);
            this.lblAffJour.TabIndex = 4;
            this.lblAffJour.Text = "Lundi";
            // 
            // lblAffTemps
            // 
            this.lblAffTemps.AutoSize = true;
            this.lblAffTemps.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffTemps.ForeColor = System.Drawing.Color.Red;
            this.lblAffTemps.Location = new System.Drawing.Point(4, 17);
            this.lblAffTemps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffTemps.Name = "lblAffTemps";
            this.lblAffTemps.Size = new System.Drawing.Size(204, 58);
            this.lblAffTemps.TabIndex = 2;
            this.lblAffTemps.Text = "Heure: ";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.Color.Red;
            this.lblTemps.Location = new System.Drawing.Point(207, 17);
            this.lblTemps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(147, 58);
            this.lblTemps.TabIndex = 3;
            this.lblTemps.Text = "0:0:0";
            // 
            // pnlAction
            // 
            this.pnlAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlAction.AutoScroll = true;
            this.pnlAction.BackColor = System.Drawing.Color.Silver;
            this.pnlAction.Controls.Add(this.lblAffActions);
            this.pnlAction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlAction.Location = new System.Drawing.Point(260, 28);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(561, 311);
            this.pnlAction.TabIndex = 7;
            // 
            // lblAffActions
            // 
            this.lblAffActions.AutoSize = true;
            this.lblAffActions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAffActions.Location = new System.Drawing.Point(4, 6);
            this.lblAffActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffActions.Name = "lblAffActions";
            this.lblAffActions.Size = new System.Drawing.Size(127, 20);
            this.lblAffActions.TabIndex = 0;
            this.lblAffActions.Text = "Action en cours: ";
            // 
            // pnlGestionTemps
            // 
            this.pnlGestionTemps.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlGestionTemps.Controls.Add(this.lblVitesse);
            this.pnlGestionTemps.Controls.Add(this.button2);
            this.pnlGestionTemps.Controls.Add(this.btnAvanceeTemps);
            this.pnlGestionTemps.Controls.Add(this.btnPause);
            this.pnlGestionTemps.Location = new System.Drawing.Point(18, 28);
            this.pnlGestionTemps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlGestionTemps.Name = "pnlGestionTemps";
            this.pnlGestionTemps.Size = new System.Drawing.Size(254, 42);
            this.pnlGestionTemps.TabIndex = 11;
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(190, 6);
            this.lblVitesse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(25, 20);
            this.lblVitesse.TabIndex = 3;
            this.lblVitesse.Text = "1x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "◀ ◀";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAvanceeTemps
            // 
            this.btnAvanceeTemps.Location = new System.Drawing.Point(120, 2);
            this.btnAvanceeTemps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAvanceeTemps.Name = "btnAvanceeTemps";
            this.btnAvanceeTemps.Size = new System.Drawing.Size(60, 35);
            this.btnAvanceeTemps.TabIndex = 1;
            this.btnAvanceeTemps.Text = "▶▶";
            this.btnAvanceeTemps.UseVisualStyleBackColor = true;
            this.btnAvanceeTemps.Click += new System.EventHandler(this.btnAvanceeTemps_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(74, 2);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(38, 35);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "❚❚";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.AutoScroll = true;
            this.pnlActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlActions.Controls.Add(this.tcActions);
            this.pnlActions.Location = new System.Drawing.Point(1765, 120);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(798, 1383);
            this.pnlActions.TabIndex = 0;
            // 
            // tcActions
            // 
            this.tcActions.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tcActions.Location = new System.Drawing.Point(4, 5);
            this.tcActions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcActions.Multiline = true;
            this.tcActions.Name = "tcActions";
            this.tcActions.SelectedIndex = 0;
            this.tcActions.Size = new System.Drawing.Size(794, 1369);
            this.tcActions.TabIndex = 0;
            // 
            // pnlInfos
            // 
            this.pnlInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlInfos.BackColor = System.Drawing.Color.Transparent;
            this.pnlInfos.Controls.Add(this.lblPoids);
            this.pnlInfos.Controls.Add(this.lblAffPoids);
            this.pnlInfos.Controls.Add(this.tabGraphJournal);
            this.pnlInfos.Controls.Add(this.lblEnergie);
            this.pnlInfos.Controls.Add(this.lblAffEnergie);
            this.pnlInfos.Controls.Add(this.pnlPiqure);
            this.pnlInfos.Controls.Add(this.lblStress);
            this.pnlInfos.Controls.Add(this.lblAffStress);
            this.pnlInfos.Controls.Add(this.lblNom);
            this.pnlInfos.Controls.Add(this.lblAffNom);
            this.pnlInfos.Controls.Add(this.lblGlycemie);
            this.pnlInfos.Controls.Add(this.lblAffGlycemie);
            this.pnlInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInfos.Location = new System.Drawing.Point(96, 422);
            this.pnlInfos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlInfos.Name = "pnlInfos";
            this.pnlInfos.Size = new System.Drawing.Size(1826, 1268);
            this.pnlInfos.TabIndex = 1;
            // 
            // lblPoids
            // 
            this.lblPoids.AutoSize = true;
            this.lblPoids.BackColor = System.Drawing.Color.Silver;
            this.lblPoids.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoids.Location = new System.Drawing.Point(20, 314);
            this.lblPoids.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPoids.Name = "lblPoids";
            this.lblPoids.Size = new System.Drawing.Size(116, 46);
            this.lblPoids.TabIndex = 11;
            this.lblPoids.Text = "poids";
            // 
            // lblAffPoids
            // 
            this.lblAffPoids.AutoSize = true;
            this.lblAffPoids.BackColor = System.Drawing.Color.Silver;
            this.lblAffPoids.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffPoids.Location = new System.Drawing.Point(18, 266);
            this.lblAffPoids.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffPoids.Name = "lblAffPoids";
            this.lblAffPoids.Size = new System.Drawing.Size(132, 46);
            this.lblAffPoids.TabIndex = 10;
            this.lblAffPoids.Text = "Poids:";
            // 
            // tabGraphJournal
            // 
            this.tabGraphJournal.Controls.Add(this.tabGraph);
            this.tabGraphJournal.Controls.Add(this.tabJournal);
            this.tabGraphJournal.Location = new System.Drawing.Point(400, 222);
            this.tabGraphJournal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGraphJournal.Name = "tabGraphJournal";
            this.tabGraphJournal.SelectedIndex = 0;
            this.tabGraphJournal.Size = new System.Drawing.Size(1353, 925);
            this.tabGraphJournal.TabIndex = 9;
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.GraphiqueGlycemie);
            this.tabGraph.Location = new System.Drawing.Point(4, 55);
            this.tabGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGraph.Size = new System.Drawing.Size(1345, 866);
            this.tabGraph.TabIndex = 0;
            this.tabGraph.Text = "Graphique";
            this.tabGraph.UseVisualStyleBackColor = true;
            // 
            // GraphiqueGlycemie
            // 
            this.GraphiqueGlycemie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphiqueGlycemie.BackColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.GraphiqueGlycemie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.GraphiqueGlycemie.Legends.Add(legend1);
            this.GraphiqueGlycemie.Location = new System.Drawing.Point(-54, -17);
            this.GraphiqueGlycemie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GraphiqueGlycemie.Name = "GraphiqueGlycemie";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.Legend = "Legend1";
            series1.Name = "Glycémie Maximale";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Glycémie Minimale";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "Objectif Maximal";
            series3.ShadowColor = System.Drawing.Color.Lime;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Lime;
            series4.Legend = "Legend1";
            series4.Name = "Objectif Minimal";
            series4.ShadowColor = System.Drawing.Color.Lime;
            series5.BorderWidth = 5;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Fuchsia;
            series5.Legend = "Legend1";
            series5.Name = "Glycémie Courante";
            series5.ShadowColor = System.Drawing.Color.Fuchsia;
            this.GraphiqueGlycemie.Series.Add(series1);
            this.GraphiqueGlycemie.Series.Add(series2);
            this.GraphiqueGlycemie.Series.Add(series3);
            this.GraphiqueGlycemie.Series.Add(series4);
            this.GraphiqueGlycemie.Series.Add(series5);
            this.GraphiqueGlycemie.Size = new System.Drawing.Size(1414, 911);
            this.GraphiqueGlycemie.TabIndex = 6;
            this.GraphiqueGlycemie.Text = "chart1";
            this.GraphiqueGlycemie.Customize += new System.EventHandler(this.GraphiqueGlycemie_Customize);
            // 
            // tabJournal
            // 
            this.tabJournal.Controls.Add(this.txtJournal);
            this.tabJournal.Location = new System.Drawing.Point(4, 55);
            this.tabJournal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabJournal.Name = "tabJournal";
            this.tabJournal.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabJournal.Size = new System.Drawing.Size(1345, 866);
            this.tabJournal.TabIndex = 1;
            this.tabJournal.Text = "Journal";
            this.tabJournal.UseVisualStyleBackColor = true;
            // 
            // txtJournal
            // 
            this.txtJournal.AcceptsReturn = true;
            this.txtJournal.Location = new System.Drawing.Point(0, 5);
            this.txtJournal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJournal.Multiline = true;
            this.txtJournal.Name = "txtJournal";
            this.txtJournal.ReadOnly = true;
            this.txtJournal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJournal.Size = new System.Drawing.Size(1388, 1009);
            this.txtJournal.TabIndex = 0;
            // 
            // lblEnergie
            // 
            this.lblEnergie.AutoSize = true;
            this.lblEnergie.BackColor = System.Drawing.Color.Silver;
            this.lblEnergie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergie.Location = new System.Drawing.Point(405, 169);
            this.lblEnergie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnergie.Name = "lblEnergie";
            this.lblEnergie.Size = new System.Drawing.Size(157, 46);
            this.lblEnergie.TabIndex = 8;
            this.lblEnergie.Text = "Energie";
            // 
            // lblAffEnergie
            // 
            this.lblAffEnergie.AutoSize = true;
            this.lblAffEnergie.BackColor = System.Drawing.Color.Silver;
            this.lblAffEnergie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffEnergie.Location = new System.Drawing.Point(405, 122);
            this.lblAffEnergie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffEnergie.Name = "lblAffEnergie";
            this.lblAffEnergie.Size = new System.Drawing.Size(287, 46);
            this.lblAffEnergie.TabIndex = 7;
            this.lblAffEnergie.Text = "Etat de fatigue:";
            // 
            // pnlPiqure
            // 
            this.pnlPiqure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPiqure.BackColor = System.Drawing.Color.Transparent;
            this.pnlPiqure.Controls.Add(this.button1);
            this.pnlPiqure.Controls.Add(this.label1);
            this.pnlPiqure.Controls.Add(this.progressBar2);
            this.pnlPiqure.Controls.Add(this.progressBar1);
            this.pnlPiqure.Controls.Add(this.btnPiqure);
            this.pnlPiqure.Controls.Add(this.progressBarInsuline);
            this.pnlPiqure.Controls.Add(this.lblDoseActu);
            this.pnlPiqure.Location = new System.Drawing.Point(34, 705);
            this.pnlPiqure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlPiqure.Name = "pnlPiqure";
            this.pnlPiqure.Size = new System.Drawing.Size(363, 414);
            this.pnlPiqure.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 65);
            this.button1.TabIndex = 8;
            this.button1.Text = "Sucre";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Resucrage";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(123, 282);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(112, 35);
            this.progressBar2.TabIndex = 6;
            this.progressBar2.Value = 100;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(244, 282);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 35);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 100;
            // 
            // btnPiqure
            // 
            this.btnPiqure.Location = new System.Drawing.Point(8, 326);
            this.btnPiqure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPiqure.Name = "btnPiqure";
            this.btnPiqure.Size = new System.Drawing.Size(351, 63);
            this.btnPiqure.TabIndex = 4;
            this.btnPiqure.Text = "SE PIQUER !";
            this.btnPiqure.UseVisualStyleBackColor = true;
            this.btnPiqure.Click += new System.EventHandler(this.btnPiqure_Click);
            // 
            // progressBarInsuline
            // 
            this.progressBarInsuline.Location = new System.Drawing.Point(4, 282);
            this.progressBarInsuline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarInsuline.Name = "progressBarInsuline";
            this.progressBarInsuline.Size = new System.Drawing.Size(112, 35);
            this.progressBarInsuline.TabIndex = 1;
            this.progressBarInsuline.Value = 100;
            // 
            // lblDoseActu
            // 
            this.lblDoseActu.AutoSize = true;
            this.lblDoseActu.BackColor = System.Drawing.Color.Silver;
            this.lblDoseActu.Location = new System.Drawing.Point(10, 229);
            this.lblDoseActu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoseActu.Name = "lblDoseActu";
            this.lblDoseActu.Size = new System.Drawing.Size(277, 46);
            this.lblDoseActu.TabIndex = 0;
            this.lblDoseActu.Text = "Insuline rapide";
            // 
            // lblStress
            // 
            this.lblStress.AutoSize = true;
            this.lblStress.BackColor = System.Drawing.Color.Silver;
            this.lblStress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStress.Location = new System.Drawing.Point(405, 54);
            this.lblStress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStress.Name = "lblStress";
            this.lblStress.Size = new System.Drawing.Size(133, 46);
            this.lblStress.TabIndex = 5;
            this.lblStress.Text = "Stress";
            // 
            // lblAffStress
            // 
            this.lblAffStress.AutoSize = true;
            this.lblAffStress.BackColor = System.Drawing.Color.Silver;
            this.lblAffStress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffStress.Location = new System.Drawing.Point(405, 6);
            this.lblAffStress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffStress.Name = "lblAffStress";
            this.lblAffStress.Size = new System.Drawing.Size(155, 46);
            this.lblAffStress.TabIndex = 4;
            this.lblAffStress.Text = "Stress: ";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.BackColor = System.Drawing.Color.Silver;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(18, 169);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(98, 46);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "nom";
            // 
            // lblAffNom
            // 
            this.lblAffNom.AutoSize = true;
            this.lblAffNom.BackColor = System.Drawing.Color.Silver;
            this.lblAffNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffNom.Location = new System.Drawing.Point(16, 122);
            this.lblAffNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffNom.Name = "lblAffNom";
            this.lblAffNom.Size = new System.Drawing.Size(305, 46);
            this.lblAffNom.TabIndex = 2;
            this.lblAffNom.Text = "Nom du joueur: ";
            // 
            // lblGlycemie
            // 
            this.lblGlycemie.AutoSize = true;
            this.lblGlycemie.BackColor = System.Drawing.Color.Silver;
            this.lblGlycemie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlycemie.Location = new System.Drawing.Point(18, 54);
            this.lblGlycemie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGlycemie.Name = "lblGlycemie";
            this.lblGlycemie.Size = new System.Drawing.Size(53, 46);
            this.lblGlycemie.TabIndex = 1;
            this.lblGlycemie.Text = "0 ";
            // 
            // lblAffGlycemie
            // 
            this.lblAffGlycemie.AutoSize = true;
            this.lblAffGlycemie.BackColor = System.Drawing.Color.Silver;
            this.lblAffGlycemie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffGlycemie.Location = new System.Drawing.Point(16, 6);
            this.lblAffGlycemie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAffGlycemie.Name = "lblAffGlycemie";
            this.lblAffGlycemie.Size = new System.Drawing.Size(209, 46);
            this.lblAffGlycemie.TabIndex = 0;
            this.lblAffGlycemie.Text = "Glycémie: ";
            // 
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::DiabManager.Properties.Resources.matin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2822, 1478);
            this.Controls.Add(this.pnlEvent);
            this.Controls.Add(this.pnlHeure);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.pnlGestionTemps);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlInfos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmJeu";
            this.Text = "DiabManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmJeu_Shown);
            this.pnlEvent.ResumeLayout(false);
            this.pnlEvent.PerformLayout();
            this.pnlHeure.ResumeLayout(false);
            this.pnlHeure.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.pnlGestionTemps.ResumeLayout(false);
            this.pnlGestionTemps.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlInfos.ResumeLayout(false);
            this.pnlInfos.PerformLayout();
            this.tabGraphJournal.ResumeLayout(false);
            this.tabGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GraphiqueGlycemie)).EndInit();
            this.tabJournal.ResumeLayout(false);
            this.tabJournal.PerformLayout();
            this.pnlPiqure.ResumeLayout(false);
            this.pnlPiqure.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.Label lblAffEvent;
        private System.Windows.Forms.Panel pnlHeure;
        private System.Windows.Forms.Label lblAffJour;
        private System.Windows.Forms.Label lblAffTemps;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Label lblAffActions;
        private System.Windows.Forms.Panel pnlGestionTemps;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAvanceeTemps;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.TabControl tcActions;
        private System.Windows.Forms.Panel pnlInfos;
        private System.Windows.Forms.TabControl tabGraphJournal;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraphiqueGlycemie;
        private System.Windows.Forms.TabPage tabJournal;
        private System.Windows.Forms.TextBox txtJournal;
        private System.Windows.Forms.Label lblEnergie;
        private System.Windows.Forms.Label lblAffEnergie;
        private System.Windows.Forms.Panel pnlPiqure;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnPiqure;
        private System.Windows.Forms.ProgressBar progressBarInsuline;
        private System.Windows.Forms.Label lblDoseActu;
        private System.Windows.Forms.Label lblStress;
        private System.Windows.Forms.Label lblAffStress;
        private System.Windows.Forms.Label lblPoids;
        private System.Windows.Forms.Label lblAffPoids;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblAffNom;
        private System.Windows.Forms.Label lblGlycemie;
        private System.Windows.Forms.Label lblAffGlycemie;
    }
}