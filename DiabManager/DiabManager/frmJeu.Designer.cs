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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPiqure = new System.Windows.Forms.Button();
            this.btnAugmenter = new System.Windows.Forms.Button();
            this.btnDiminuer = new System.Windows.Forms.Button();
            this.progressBarInsuline = new System.Windows.Forms.ProgressBar();
            this.lblDoseActu = new System.Windows.Forms.Label();
            this.lblDose = new System.Windows.Forms.Label();
            this.pnlInfos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlActions
            // 
            this.pnlActions.Location = new System.Drawing.Point(136, 90);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(327, 235);
            this.pnlActions.TabIndex = 0;
            // 
            // pnlInfos
            // 
            this.pnlInfos.Controls.Add(this.lblNom);
            this.pnlInfos.Controls.Add(this.lblAffNom);
            this.pnlInfos.Controls.Add(this.lblGlycemie);
            this.pnlInfos.Controls.Add(this.lblAffGlycemie);
            this.pnlInfos.Location = new System.Drawing.Point(536, 90);
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
            this.lblAffTemps.Location = new System.Drawing.Point(536, 13);
            this.lblAffTemps.Name = "lblAffTemps";
            this.lblAffTemps.Size = new System.Drawing.Size(42, 13);
            this.lblAffTemps.TabIndex = 2;
            this.lblAffTemps.Text = "Heure: ";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Location = new System.Drawing.Point(575, 13);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(31, 13);
            this.lblTemps.TabIndex = 3;
            this.lblTemps.Text = "0:0:0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDose);
            this.panel1.Controls.Add(this.lblDoseActu);
            this.panel1.Controls.Add(this.btnPiqure);
            this.panel1.Controls.Add(this.btnAugmenter);
            this.panel1.Controls.Add(this.btnDiminuer);
            this.panel1.Controls.Add(this.progressBarInsuline);
            this.panel1.Location = new System.Drawing.Point(536, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 114);
            this.panel1.TabIndex = 4;
            // 
            // btnPiqure
            // 
            this.btnPiqure.Location = new System.Drawing.Point(82, 84);
            this.btnPiqure.Name = "btnPiqure";
            this.btnPiqure.Size = new System.Drawing.Size(75, 23);
            this.btnPiqure.TabIndex = 3;
            this.btnPiqure.Text = "SE PIQUER !";
            this.btnPiqure.UseVisualStyleBackColor = true;
            this.btnPiqure.Click += new System.EventHandler(this.btnPiqure_Click);
            // 
            // btnAugmenter
            // 
            this.btnAugmenter.Location = new System.Drawing.Point(163, 55);
            this.btnAugmenter.Name = "btnAugmenter";
            this.btnAugmenter.Size = new System.Drawing.Size(75, 23);
            this.btnAugmenter.TabIndex = 2;
            this.btnAugmenter.Text = "Augmenter";
            this.btnAugmenter.UseVisualStyleBackColor = true;
            this.btnAugmenter.Click += new System.EventHandler(this.btnAugmenter_Click);
            // 
            // btnDiminuer
            // 
            this.btnDiminuer.Location = new System.Drawing.Point(3, 55);
            this.btnDiminuer.Name = "btnDiminuer";
            this.btnDiminuer.Size = new System.Drawing.Size(75, 23);
            this.btnDiminuer.TabIndex = 1;
            this.btnDiminuer.Text = "Diminuer";
            this.btnDiminuer.UseVisualStyleBackColor = true;
            this.btnDiminuer.Click += new System.EventHandler(this.btnDiminuer_Click);
            // 
            // progressBarInsuline
            // 
            this.progressBarInsuline.Location = new System.Drawing.Point(3, 22);
            this.progressBarInsuline.Name = "progressBarInsuline";
            this.progressBarInsuline.Size = new System.Drawing.Size(235, 27);
            this.progressBarInsuline.TabIndex = 0;
            this.progressBarInsuline.Value = 5;
            // 
            // lblDoseActu
            // 
            this.lblDoseActu.AutoSize = true;
            this.lblDoseActu.Location = new System.Drawing.Point(10, 6);
            this.lblDoseActu.Name = "lblDoseActu";
            this.lblDoseActu.Size = new System.Drawing.Size(35, 13);
            this.lblDoseActu.TabIndex = 4;
            this.lblDoseActu.Text = "label1";
            // 
            // lblDose
            // 
            this.lblDose.AutoSize = true;
            this.lblDose.Location = new System.Drawing.Point(84, 60);
            this.lblDose.Name = "lblDose";
            this.lblDose.Size = new System.Drawing.Size(35, 13);
            this.lblDose.TabIndex = 5;
            this.lblDose.Text = "label1";
            // 
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTemps);
            this.Controls.Add(this.lblAffTemps);
            this.Controls.Add(this.pnlInfos);
            this.Controls.Add(this.pnlActions);
            this.Name = "frmJeu";
            this.Text = "frmJeu";
            this.pnlInfos.ResumeLayout(false);
            this.pnlInfos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPiqure;
        private System.Windows.Forms.Button btnAugmenter;
        private System.Windows.Forms.Button btnDiminuer;
        private System.Windows.Forms.ProgressBar progressBarInsuline;
        private System.Windows.Forms.Label lblDoseActu;
        private System.Windows.Forms.Label lblDose;
    }
}