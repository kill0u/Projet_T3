namespace DiabManager
{
    partial class frmTuto
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
            this.pbTuto = new System.Windows.Forms.PictureBox();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.lblExplication = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTuto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTuto
            // 
            this.pbTuto.BackgroundImage = global::DiabManager.Properties.Resources.tuto;
            this.pbTuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTuto.Location = new System.Drawing.Point(28, 12);
            this.pbTuto.Name = "pbTuto";
            this.pbTuto.Size = new System.Drawing.Size(891, 377);
            this.pbTuto.TabIndex = 0;
            this.pbTuto.TabStop = false;
            this.pbTuto.BackgroundImageChanged += new System.EventHandler(this.pbTuto_BackgroundImageChanged);
            // 
            // btnSuivant
            // 
            this.btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuivant.Location = new System.Drawing.Point(781, 603);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(138, 51);
            this.btnSuivant.TabIndex = 1;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // lblExplication
            // 
            this.lblExplication.AutoSize = true;
            this.lblExplication.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplication.ForeColor = System.Drawing.Color.Aqua;
            this.lblExplication.Location = new System.Drawing.Point(28, 406);
            this.lblExplication.Name = "lblExplication";
            this.lblExplication.Size = new System.Drawing.Size(186, 29);
            this.lblExplication.TabIndex = 2;
            this.lblExplication.Tag = "0";
            this.lblExplication.Text = "Voici l\'interface du jeu";
            // 
            // frmTuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(958, 677);
            this.Controls.Add(this.lblExplication);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.pbTuto);
            this.Name = "frmTuto";
            this.Text = "frmTuto";
            ((System.ComponentModel.ISupportInitialize)(this.pbTuto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTuto;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Label lblExplication;
    }
}