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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblAffTemps = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            this.pnlGestionTemps = new System.Windows.Forms.Panel();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAvanceeTemps = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnlHeure = new System.Windows.Forms.Panel();
            this.pnlInfosEvent = new System.Windows.Forms.Panel();
            this.lblAffEvent = new System.Windows.Forms.Label();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.lblAffActions = new System.Windows.Forms.Label();
            this.gplFond = new DiabManager.Composants.GradientPanel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.pnlInfos = new System.Windows.Forms.Panel();
            this.lblEnergie = new System.Windows.Forms.Label();
            this.lblAffEnergie = new System.Windows.Forms.Label();
            this.pnlPiqure = new System.Windows.Forms.Panel();
            this.lblDose = new System.Windows.Forms.Label();
            this.btnPiqure = new System.Windows.Forms.Button();
            this.btnAugmenter = new System.Windows.Forms.Button();
            this.btnDiminuer = new System.Windows.Forms.Button();
            this.progressBarInsuline = new System.Windows.Forms.ProgressBar();
            this.lblDoseActu = new System.Windows.Forms.Label();
            this.GraphiqueGlycemie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStress = new System.Windows.Forms.Label();
            this.lblAffStress = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblAffNom = new System.Windows.Forms.Label();
            this.lblGlycemie = new System.Windows.Forms.Label();
            this.lblAffGlycemie = new System.Windows.Forms.Label();
            this.pnlGestionTemps.SuspendLayout();
            this.pnlHeure.SuspendLayout();
            this.pnlInfosEvent.SuspendLayout();
            this.gplFond.SuspendLayout();
            this.pnlInfos.SuspendLayout();
            this.pnlPiqure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphiqueGlycemie)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAffTemps
            // 
            this.lblAffTemps.AutoSize = true;
            this.lblAffTemps.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffTemps.ForeColor = System.Drawing.Color.Red;
            this.lblAffTemps.Location = new System.Drawing.Point(3, 11);
            this.lblAffTemps.Name = "lblAffTemps";
            this.lblAffTemps.Size = new System.Drawing.Size(139, 39);
            this.lblAffTemps.TabIndex = 2;
            this.lblAffTemps.Text = "Heure: ";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.Color.Red;
            this.lblTemps.Location = new System.Drawing.Point(138, 11);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(99, 39);
            this.lblTemps.TabIndex = 3;
            this.lblTemps.Text = "0:0:0";
            // 
            // pnlGestionTemps
            // 
            this.pnlGestionTemps.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlGestionTemps.Controls.Add(this.lblVitesse);
            this.pnlGestionTemps.Controls.Add(this.button2);
            this.pnlGestionTemps.Controls.Add(this.btnAvanceeTemps);
            this.pnlGestionTemps.Controls.Add(this.btnPause);
            this.pnlGestionTemps.Location = new System.Drawing.Point(1, 3);
            this.pnlGestionTemps.Name = "pnlGestionTemps";
            this.pnlGestionTemps.Size = new System.Drawing.Size(169, 27);
            this.pnlGestionTemps.TabIndex = 4;
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(127, 4);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(18, 13);
            this.lblVitesse.TabIndex = 3;
            this.lblVitesse.Text = "1x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "◀ ◀";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAvanceeTemps
            // 
            this.btnAvanceeTemps.Location = new System.Drawing.Point(80, 1);
            this.btnAvanceeTemps.Name = "btnAvanceeTemps";
            this.btnAvanceeTemps.Size = new System.Drawing.Size(40, 23);
            this.btnAvanceeTemps.TabIndex = 1;
            this.btnAvanceeTemps.Text = "▶▶";
            this.btnAvanceeTemps.UseVisualStyleBackColor = true;
            this.btnAvanceeTemps.Click += new System.EventHandler(this.btnAvanceeTemps_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(49, 1);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(25, 23);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "❚❚";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pnlHeure
            // 
            this.pnlHeure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeure.BackColor = System.Drawing.Color.Black;
            this.pnlHeure.Controls.Add(this.lblAffTemps);
            this.pnlHeure.Controls.Add(this.lblTemps);
            this.pnlHeure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlHeure.Location = new System.Drawing.Point(1545, 10);
            this.pnlHeure.Name = "pnlHeure";
            this.pnlHeure.Size = new System.Drawing.Size(347, 58);
            this.pnlHeure.TabIndex = 6;
            // 
            // pnlInfosEvent
            // 
            this.pnlInfosEvent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlInfosEvent.BackColor = System.Drawing.Color.Transparent;
            this.pnlInfosEvent.Controls.Add(this.lblAffEvent);
            this.pnlInfosEvent.Controls.Add(this.lblEvents);
            this.pnlInfosEvent.Controls.Add(this.lblActions);
            this.pnlInfosEvent.Controls.Add(this.lblAffActions);
            this.pnlInfosEvent.Location = new System.Drawing.Point(172, 3);
            this.pnlInfosEvent.Name = "pnlInfosEvent";
            this.pnlInfosEvent.Size = new System.Drawing.Size(1117, 150);
            this.pnlInfosEvent.TabIndex = 7;
            // 
            // lblAffEvent
            // 
            this.lblAffEvent.AutoSize = true;
            this.lblAffEvent.Location = new System.Drawing.Point(4, 25);
            this.lblAffEvent.Name = "lblAffEvent";
            this.lblAffEvent.Size = new System.Drawing.Size(113, 13);
            this.lblAffEvent.TabIndex = 3;
            this.lblAffEvent.Text = "Vous êtes en train de :";
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.Location = new System.Drawing.Point(4, 38);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(10, 13);
            this.lblEvents.TabIndex = 2;
            this.lblEvents.Text = " ";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Location = new System.Drawing.Point(118, 7);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(10, 13);
            this.lblActions.TabIndex = 1;
            this.lblActions.Text = " ";
            // 
            // lblAffActions
            // 
            this.lblAffActions.AutoSize = true;
            this.lblAffActions.Location = new System.Drawing.Point(4, 7);
            this.lblAffActions.Name = "lblAffActions";
            this.lblAffActions.Size = new System.Drawing.Size(108, 13);
            this.lblAffActions.TabIndex = 0;
            this.lblAffActions.Text = "Vous avez choisi de :";
            // 
            // gplFond
            // 
            this.gplFond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gplFond.ColorBottom = System.Drawing.Color.Indigo;
            this.gplFond.ColorTop = System.Drawing.Color.MidnightBlue;
            this.gplFond.Controls.Add(this.pnlInfosEvent);
            this.gplFond.Controls.Add(this.pnlGestionTemps);
            this.gplFond.Controls.Add(this.pnlActions);
            this.gplFond.Controls.Add(this.pnlInfos);
            this.gplFond.Location = new System.Drawing.Point(2, -1);
            this.gplFond.Name = "gplFond";
            this.gplFond.Size = new System.Drawing.Size(1905, 1048);
            this.gplFond.TabIndex = 8;
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlActions.Location = new System.Drawing.Point(1295, 74);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(594, 955);
            this.pnlActions.TabIndex = 0;
            // 
            // pnlInfos
            // 
            this.pnlInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlInfos.BackColor = System.Drawing.Color.Transparent;
            this.pnlInfos.Controls.Add(this.lblEnergie);
            this.pnlInfos.Controls.Add(this.lblAffEnergie);
            this.pnlInfos.Controls.Add(this.pnlPiqure);
            this.pnlInfos.Controls.Add(this.GraphiqueGlycemie);
            this.pnlInfos.Controls.Add(this.lblStress);
            this.pnlInfos.Controls.Add(this.lblAffStress);
            this.pnlInfos.Controls.Add(this.lblNom);
            this.pnlInfos.Controls.Add(this.lblAffNom);
            this.pnlInfos.Controls.Add(this.lblGlycemie);
            this.pnlInfos.Controls.Add(this.lblAffGlycemie);
            this.pnlInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInfos.Location = new System.Drawing.Point(58, 159);
            this.pnlInfos.Name = "pnlInfos";
            this.pnlInfos.Size = new System.Drawing.Size(1217, 870);
            this.pnlInfos.TabIndex = 1;
            // 
            // lblEnergie
            // 
            this.lblEnergie.AutoSize = true;
            this.lblEnergie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergie.Location = new System.Drawing.Point(270, 110);
            this.lblEnergie.Name = "lblEnergie";
            this.lblEnergie.Size = new System.Drawing.Size(107, 31);
            this.lblEnergie.TabIndex = 8;
            this.lblEnergie.Text = "Energie";
            // 
            // lblAffEnergie
            // 
            this.lblAffEnergie.AutoSize = true;
            this.lblAffEnergie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffEnergie.Location = new System.Drawing.Point(270, 79);
            this.lblAffEnergie.Name = "lblAffEnergie";
            this.lblAffEnergie.Size = new System.Drawing.Size(197, 31);
            this.lblAffEnergie.TabIndex = 7;
            this.lblAffEnergie.Text = "Etat de fatigue:";
            // 
            // pnlPiqure
            // 
            this.pnlPiqure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPiqure.BackColor = System.Drawing.Color.Transparent;
            this.pnlPiqure.Controls.Add(this.lblDose);
            this.pnlPiqure.Controls.Add(this.btnPiqure);
            this.pnlPiqure.Controls.Add(this.btnAugmenter);
            this.pnlPiqure.Controls.Add(this.btnDiminuer);
            this.pnlPiqure.Controls.Add(this.progressBarInsuline);
            this.pnlPiqure.Controls.Add(this.lblDoseActu);
            this.pnlPiqure.Location = new System.Drawing.Point(13, 588);
            this.pnlPiqure.Name = "pnlPiqure";
            this.pnlPiqure.Size = new System.Drawing.Size(242, 269);
            this.pnlPiqure.TabIndex = 5;
            // 
            // lblDose
            // 
            this.lblDose.AutoSize = true;
            this.lblDose.Location = new System.Drawing.Point(5, 120);
            this.lblDose.Name = "lblDose";
            this.lblDose.Size = new System.Drawing.Size(86, 31);
            this.lblDose.TabIndex = 5;
            this.lblDose.Text = "label1";
            // 
            // btnPiqure
            // 
            this.btnPiqure.Location = new System.Drawing.Point(5, 212);
            this.btnPiqure.Name = "btnPiqure";
            this.btnPiqure.Size = new System.Drawing.Size(234, 41);
            this.btnPiqure.TabIndex = 4;
            this.btnPiqure.Text = "SE PIQUER !";
            this.btnPiqure.UseVisualStyleBackColor = true;
            this.btnPiqure.Click += new System.EventHandler(this.btnPiqure_Click);
            // 
            // btnAugmenter
            // 
            this.btnAugmenter.Location = new System.Drawing.Point(5, 154);
            this.btnAugmenter.Name = "btnAugmenter";
            this.btnAugmenter.Size = new System.Drawing.Size(163, 38);
            this.btnAugmenter.TabIndex = 3;
            this.btnAugmenter.Text = "Augmenter";
            this.btnAugmenter.UseVisualStyleBackColor = true;
            this.btnAugmenter.Click += new System.EventHandler(this.btnAugmenter_Click);
            // 
            // btnDiminuer
            // 
            this.btnDiminuer.Location = new System.Drawing.Point(5, 80);
            this.btnDiminuer.Name = "btnDiminuer";
            this.btnDiminuer.Size = new System.Drawing.Size(163, 37);
            this.btnDiminuer.TabIndex = 2;
            this.btnDiminuer.Text = "Diminuer";
            this.btnDiminuer.UseVisualStyleBackColor = true;
            this.btnDiminuer.Click += new System.EventHandler(this.btnDiminuer_Click);
            // 
            // progressBarInsuline
            // 
            this.progressBarInsuline.Location = new System.Drawing.Point(4, 38);
            this.progressBarInsuline.Name = "progressBarInsuline";
            this.progressBarInsuline.Size = new System.Drawing.Size(235, 23);
            this.progressBarInsuline.TabIndex = 1;
            // 
            // lblDoseActu
            // 
            this.lblDoseActu.AutoSize = true;
            this.lblDoseActu.Location = new System.Drawing.Point(7, 4);
            this.lblDoseActu.Name = "lblDoseActu";
            this.lblDoseActu.Size = new System.Drawing.Size(86, 31);
            this.lblDoseActu.TabIndex = 0;
            this.lblDoseActu.Text = "label1";
            // 
            // GraphiqueGlycemie
            // 
            this.GraphiqueGlycemie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphiqueGlycemie.BackColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea2.BackColor = System.Drawing.Color.Gray;
            chartArea2.Name = "ChartArea1";
            this.GraphiqueGlycemie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.GraphiqueGlycemie.Legends.Add(legend2);
            this.GraphiqueGlycemie.Location = new System.Drawing.Point(276, 153);
            this.GraphiqueGlycemie.Name = "GraphiqueGlycemie";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.Legend = "Legend1";
            series6.Name = "Glycémie Maximale";
            series6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "Glycémie Minimale";
            series7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Lime;
            series8.Legend = "Legend1";
            series8.Name = "Objectif Maximal";
            series8.ShadowColor = System.Drawing.Color.Lime;
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Lime;
            series9.Legend = "Legend1";
            series9.Name = "Objectif Minimal";
            series9.ShadowColor = System.Drawing.Color.Lime;
            series10.BorderWidth = 5;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Fuchsia;
            series10.Legend = "Legend1";
            series10.Name = "Glycémie Courante";
            series10.ShadowColor = System.Drawing.Color.Fuchsia;
            this.GraphiqueGlycemie.Series.Add(series6);
            this.GraphiqueGlycemie.Series.Add(series7);
            this.GraphiqueGlycemie.Series.Add(series8);
            this.GraphiqueGlycemie.Series.Add(series9);
            this.GraphiqueGlycemie.Series.Add(series10);
            this.GraphiqueGlycemie.Size = new System.Drawing.Size(938, 704);
            this.GraphiqueGlycemie.TabIndex = 6;
            this.GraphiqueGlycemie.Text = "chart1";
            this.GraphiqueGlycemie.Customize += new System.EventHandler(this.GraphiqueGlycemie_Customize);
            // 
            // lblStress
            // 
            this.lblStress.AutoSize = true;
            this.lblStress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStress.Location = new System.Drawing.Point(270, 35);
            this.lblStress.Name = "lblStress";
            this.lblStress.Size = new System.Drawing.Size(92, 31);
            this.lblStress.TabIndex = 5;
            this.lblStress.Text = "Stress";
            // 
            // lblAffStress
            // 
            this.lblAffStress.AutoSize = true;
            this.lblAffStress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffStress.Location = new System.Drawing.Point(270, 4);
            this.lblAffStress.Name = "lblAffStress";
            this.lblAffStress.Size = new System.Drawing.Size(107, 31);
            this.lblAffStress.TabIndex = 4;
            this.lblAffStress.Text = "Stress: ";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(12, 110);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(66, 31);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "nom";
            // 
            // lblAffNom
            // 
            this.lblAffNom.AutoSize = true;
            this.lblAffNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffNom.Location = new System.Drawing.Point(11, 79);
            this.lblAffNom.Name = "lblAffNom";
            this.lblAffNom.Size = new System.Drawing.Size(205, 31);
            this.lblAffNom.TabIndex = 2;
            this.lblAffNom.Text = "Nom du joueur: ";
            // 
            // lblGlycemie
            // 
            this.lblGlycemie.AutoSize = true;
            this.lblGlycemie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlycemie.Location = new System.Drawing.Point(12, 35);
            this.lblGlycemie.Name = "lblGlycemie";
            this.lblGlycemie.Size = new System.Drawing.Size(36, 31);
            this.lblGlycemie.TabIndex = 1;
            this.lblGlycemie.Text = "0 ";
            // 
            // lblAffGlycemie
            // 
            this.lblAffGlycemie.AutoSize = true;
            this.lblAffGlycemie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffGlycemie.Location = new System.Drawing.Point(11, 4);
            this.lblAffGlycemie.Name = "lblAffGlycemie";
            this.lblAffGlycemie.Size = new System.Drawing.Size(142, 31);
            this.lblAffGlycemie.TabIndex = 0;
            this.lblAffGlycemie.Text = "Glycémie: ";
            // 
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnlHeure);
            this.Controls.Add(this.gplFond);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmJeu";
            this.Text = "frmJeu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmJeu_Shown);
            this.pnlGestionTemps.ResumeLayout(false);
            this.pnlGestionTemps.PerformLayout();
            this.pnlHeure.ResumeLayout(false);
            this.pnlHeure.PerformLayout();
            this.pnlInfosEvent.ResumeLayout(false);
            this.pnlInfosEvent.PerformLayout();
            this.gplFond.ResumeLayout(false);
            this.pnlInfos.ResumeLayout(false);
            this.pnlInfos.PerformLayout();
            this.pnlPiqure.ResumeLayout(false);
            this.pnlPiqure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphiqueGlycemie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlInfos;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblAffNom;
        private System.Windows.Forms.Label lblGlycemie;
        private System.Windows.Forms.Label lblAffGlycemie;
        private System.Windows.Forms.Label lblAffTemps;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.Panel pnlGestionTemps;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAvanceeTemps;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.Panel pnlPiqure;
        private System.Windows.Forms.Button btnPiqure;
        private System.Windows.Forms.Button btnAugmenter;
        private System.Windows.Forms.Button btnDiminuer;
        private System.Windows.Forms.ProgressBar progressBarInsuline;
        private System.Windows.Forms.Label lblDoseActu;
        private System.Windows.Forms.Label lblDose;
        private System.Windows.Forms.Panel pnlHeure;
        private System.Windows.Forms.Panel pnlInfosEvent;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Label lblAffActions;
        private GradientPanel gplFond;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblAffEvent;
        private System.Windows.Forms.Label lblStress;
        private System.Windows.Forms.Label lblAffStress;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraphiqueGlycemie;
        private System.Windows.Forms.Label lblEnergie;
        private System.Windows.Forms.Label lblAffEnergie;
    }
}