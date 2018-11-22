namespace DiabManager.MiniJeu
{
    partial class frmJeuCaPousse
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
            this.pbNormal = new System.Windows.Forms.PictureBox();
            this.pbTete = new System.Windows.Forms.PictureBox();
            this.btnPousser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTete)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNormal
            // 
            this.pbNormal.Location = new System.Drawing.Point(-1, 0);
            this.pbNormal.Name = "pbNormal";
            this.pbNormal.Size = new System.Drawing.Size(396, 438);
            this.pbNormal.TabIndex = 0;
            this.pbNormal.TabStop = false;
            // 
            // pbTete
            // 
            this.pbTete.Location = new System.Drawing.Point(-1, 0);
            this.pbTete.Name = "pbTete";
            this.pbTete.Size = new System.Drawing.Size(396, 438);
            this.pbTete.TabIndex = 1;
            this.pbTete.TabStop = false;
            // 
            // btnPousser
            // 
            this.btnPousser.Location = new System.Drawing.Point(469, 271);
            this.btnPousser.Name = "btnPousser";
            this.btnPousser.Size = new System.Drawing.Size(272, 91);
            this.btnPousser.TabIndex = 2;
            this.btnPousser.Text = "Pousser";
            this.btnPousser.UseVisualStyleBackColor = true;
            this.btnPousser.Click += new System.EventHandler(this.btnPousser_Click);
            // 
            // frmJeuCaPousse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPousser);
            this.Controls.Add(this.pbTete);
            this.Controls.Add(this.pbNormal);
            this.Name = "frmJeuCaPousse";
            this.Text = "frmJeuCaPousse";
            this.Load += new System.EventHandler(this.frmJeuCaPousse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNormal;
        private System.Windows.Forms.PictureBox pbTete;
        private System.Windows.Forms.Button btnPousser;
    }
}