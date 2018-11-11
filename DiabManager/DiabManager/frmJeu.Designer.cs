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
            this.pnlActions = new System.Windows.Forms.Panel();
            this.pnlInfos = new System.Windows.Forms.Panel();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblAffNom = new System.Windows.Forms.Label();
            this.lblGlycemie = new System.Windows.Forms.Label();
            this.lblAffGlycemie = new System.Windows.Forms.Label();
            this.lblAffTemps = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            this.pnlGestionTemps = new System.Windows.Forms.Panel();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAvanceeTemps = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnlPiqure = new System.Windows.Forms.Panel();
            this.lblDose = new System.Windows.Forms.Label();
            this.btnPiqure = new System.Windows.Forms.Button();
            this.btnAugmenter = new System.Windows.Forms.Button();
            this.btnDiminuer = new System.Windows.Forms.Button();
            this.progressBarInsuline = new System.Windows.Forms.ProgressBar();
            this.lblDoseActu = new System.Windows.Forms.Label();
            this.pnlHeure = new System.Windows.Forms.Panel();
            this.pnlInfosEvent = new System.Windows.Forms.Panel();
            this.lblAffEvent = new System.Windows.Forms.Label();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.lblAffActions = new System.Windows.Forms.Label();
            this.pnlInfos.SuspendLayout();
            this.pnlGestionTemps.SuspendLayout();
            this.pnlPiqure.SuspendLayout();
            this.pnlHeure.SuspendLayout();
            this.pnlInfosEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlActions.Location = new System.Drawing.Point(12, 159);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1632, 870);
            this.pnlActions.TabIndex = 0;
            // 
            // pnlInfos
            // 
            this.pnlInfos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlInfos.Controls.Add(this.lblNom);
            this.pnlInfos.Controls.Add(this.lblAffNom);
            this.pnlInfos.Controls.Add(this.lblGlycemie);
            this.pnlInfos.Controls.Add(this.lblAffGlycemie);
            this.pnlInfos.Location = new System.Drawing.Point(1650, 75);
            this.pnlInfos.Name = "pnlInfos";
            this.pnlInfos.Size = new System.Drawing.Size(242, 235);
            this.pnlInfos.TabIndex = 1;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(10, 202);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(27, 13);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "nom";
            // 
            // lblAffNom
            // 
            this.lblAffNom.AutoSize = true;
            this.lblAffNom.Location = new System.Drawing.Point(7, 185);
            this.lblAffNom.Name = "lblAffNom";
            this.lblAffNom.Size = new System.Drawing.Size(82, 13);
            this.lblAffNom.TabIndex = 2;
            this.lblAffNom.Text = "Nom du joueur: ";
            // 
            // lblGlycemie
            // 
            this.lblGlycemie.AutoSize = true;
            this.lblGlycemie.Location = new System.Drawing.Point(4, 21);
            this.lblGlycemie.Name = "lblGlycemie";
            this.lblGlycemie.Size = new System.Drawing.Size(16, 13);
            this.lblGlycemie.TabIndex = 1;
            this.lblGlycemie.Text = "0 ";
            // 
            // lblAffGlycemie
            // 
            this.lblAffGlycemie.AutoSize = true;
            this.lblAffGlycemie.Location = new System.Drawing.Point(4, 4);
            this.lblAffGlycemie.Name = "lblAffGlycemie";
            this.lblAffGlycemie.Size = new System.Drawing.Size(56, 13);
            this.lblAffGlycemie.TabIndex = 0;
            this.lblAffGlycemie.Text = "Glycémie: ";
            // 
            // lblAffTemps
            // 
            this.lblAffTemps.AutoSize = true;
            this.lblAffTemps.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffTemps.ForeColor = System.Drawing.Color.Red;
            this.lblAffTemps.Location = new System.Drawing.Point(-2, 3);
            this.lblAffTemps.Name = "lblAffTemps";
            this.lblAffTemps.Size = new System.Drawing.Size(111, 32);
            this.lblAffTemps.TabIndex = 2;
            this.lblAffTemps.Text = "Heure: ";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemps.ForeColor = System.Drawing.Color.Red;
            this.lblTemps.Location = new System.Drawing.Point(115, 3);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(79, 32);
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
            this.pnlGestionTemps.Location = new System.Drawing.Point(-1, -1);
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
            // pnlPiqure
            // 
            this.pnlPiqure.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlPiqure.Controls.Add(this.lblDose);
            this.pnlPiqure.Controls.Add(this.btnPiqure);
            this.pnlPiqure.Controls.Add(this.btnAugmenter);
            this.pnlPiqure.Controls.Add(this.btnDiminuer);
            this.pnlPiqure.Controls.Add(this.progressBarInsuline);
            this.pnlPiqure.Controls.Add(this.lblDoseActu);
            this.pnlPiqure.Location = new System.Drawing.Point(1657, 523);
            this.pnlPiqure.Name = "pnlPiqure";
            this.pnlPiqure.Size = new System.Drawing.Size(242, 100);
            this.pnlPiqure.TabIndex = 5;
            // 
            // lblDose
            // 
            this.lblDose.AutoSize = true;
            this.lblDose.Location = new System.Drawing.Point(83, 55);
            this.lblDose.Name = "lblDose";
            this.lblDose.Size = new System.Drawing.Size(35, 13);
            this.lblDose.TabIndex = 5;
            this.lblDose.Text = "label1";
            // 
            // btnPiqure
            // 
            this.btnPiqure.Location = new System.Drawing.Point(83, 74);
            this.btnPiqure.Name = "btnPiqure";
            this.btnPiqure.Size = new System.Drawing.Size(75, 23);
            this.btnPiqure.TabIndex = 4;
            this.btnPiqure.Text = "SE PIQUER !";
            this.btnPiqure.UseVisualStyleBackColor = true;
            this.btnPiqure.Click += new System.EventHandler(this.btnPiqure_Click);
            // 
            // btnAugmenter
            // 
            this.btnAugmenter.Location = new System.Drawing.Point(164, 50);
            this.btnAugmenter.Name = "btnAugmenter";
            this.btnAugmenter.Size = new System.Drawing.Size(75, 23);
            this.btnAugmenter.TabIndex = 3;
            this.btnAugmenter.Text = "Augmenter";
            this.btnAugmenter.UseVisualStyleBackColor = true;
            this.btnAugmenter.Click += new System.EventHandler(this.btnAugmenter_Click);
            // 
            // btnDiminuer
            // 
            this.btnDiminuer.Location = new System.Drawing.Point(4, 50);
            this.btnDiminuer.Name = "btnDiminuer";
            this.btnDiminuer.Size = new System.Drawing.Size(75, 23);
            this.btnDiminuer.TabIndex = 2;
            this.btnDiminuer.Text = "Diminuer";
            this.btnDiminuer.UseVisualStyleBackColor = true;
            this.btnDiminuer.Click += new System.EventHandler(this.btnDiminuer_Click);
            // 
            // progressBarInsuline
            // 
            this.progressBarInsuline.Location = new System.Drawing.Point(4, 21);
            this.progressBarInsuline.Name = "progressBarInsuline";
            this.progressBarInsuline.Size = new System.Drawing.Size(235, 23);
            this.progressBarInsuline.TabIndex = 1;
            // 
            // lblDoseActu
            // 
            this.lblDoseActu.AutoSize = true;
            this.lblDoseActu.Location = new System.Drawing.Point(7, 4);
            this.lblDoseActu.Name = "lblDoseActu";
            this.lblDoseActu.Size = new System.Drawing.Size(35, 13);
            this.lblDoseActu.TabIndex = 0;
            this.lblDoseActu.Text = "label1";
            // 
            // pnlHeure
            // 
            this.pnlHeure.BackColor = System.Drawing.Color.Black;
            this.pnlHeure.Controls.Add(this.lblAffTemps);
            this.pnlHeure.Controls.Add(this.lblTemps);
            this.pnlHeure.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlHeure.Location = new System.Drawing.Point(1686, 10);
            this.pnlHeure.Name = "pnlHeure";
            this.pnlHeure.Size = new System.Drawing.Size(206, 44);
            this.pnlHeure.TabIndex = 6;
            // 
            // pnlInfosEvent
            // 
            this.pnlInfosEvent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlInfosEvent.Controls.Add(this.lblAffEvent);
            this.pnlInfosEvent.Controls.Add(this.lblEvents);
            this.pnlInfosEvent.Controls.Add(this.lblActions);
            this.pnlInfosEvent.Controls.Add(this.lblAffActions);
            this.pnlInfosEvent.Location = new System.Drawing.Point(175, 3);
            this.pnlInfosEvent.Name = "pnlInfosEvent";
            this.pnlInfosEvent.Size = new System.Drawing.Size(1469, 150);
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
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnlInfosEvent);
            this.Controls.Add(this.pnlHeure);
            this.Controls.Add(this.pnlPiqure);
            this.Controls.Add(this.pnlGestionTemps);
            this.Controls.Add(this.pnlInfos);
            this.Controls.Add(this.pnlActions);
            this.Name = "frmJeu";
            this.Text = "frmJeu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmJeu_Shown);
            this.pnlInfos.ResumeLayout(false);
            this.pnlInfos.PerformLayout();
            this.pnlGestionTemps.ResumeLayout(false);
            this.pnlGestionTemps.PerformLayout();
            this.pnlPiqure.ResumeLayout(false);
            this.pnlPiqure.PerformLayout();
            this.pnlHeure.ResumeLayout(false);
            this.pnlHeure.PerformLayout();
            this.pnlInfosEvent.ResumeLayout(false);
            this.pnlInfosEvent.PerformLayout();
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
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblAffEvent;
    }
}