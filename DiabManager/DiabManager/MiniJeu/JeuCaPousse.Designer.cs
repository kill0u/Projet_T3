namespace DiabManager.MiniJeu
{
    partial class JeuCaPousse
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
            this.pctDiarrhee = new System.Windows.Forms.PictureBox();
            this.pctTete = new System.Windows.Forms.PictureBox();
            this.btnPousser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctDiarrhee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTete)).BeginInit();
            this.SuspendLayout();
            // 
            // pctDiarrhee
            // 
            this.pctDiarrhee.Location = new System.Drawing.Point(2, 3);
            this.pctDiarrhee.Name = "pctDiarrhee";
            this.pctDiarrhee.Size = new System.Drawing.Size(429, 411);
            this.pctDiarrhee.TabIndex = 0;
            this.pctDiarrhee.TabStop = false;
            // 
            // pctTete
            // 
            this.pctTete.Location = new System.Drawing.Point(2, 3);
            this.pctTete.Name = "pctTete";
            this.pctTete.Size = new System.Drawing.Size(429, 411);
            this.pctTete.TabIndex = 1;
            this.pctTete.TabStop = false;
            // 
            // btnPousser
            // 
            this.btnPousser.Location = new System.Drawing.Point(479, 333);
            this.btnPousser.Name = "btnPousser";
            this.btnPousser.Size = new System.Drawing.Size(345, 70);
            this.btnPousser.TabIndex = 2;
            this.btnPousser.Text = "Pousser";
            this.btnPousser.UseVisualStyleBackColor = true;
            this.btnPousser.Click += new System.EventHandler(this.btnPousser_Click);
            // 
            // JeuCaPousse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 415);
            this.Controls.Add(this.btnPousser);
            this.Controls.Add(this.pctTete);
            this.Controls.Add(this.pctDiarrhee);
            this.Name = "JeuCaPousse";
            this.Text = "Ca pousse";
            this.Load += new System.EventHandler(this.JeuCaPousse_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JeuCaPousse_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.JeuCaPousse_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pctDiarrhee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctDiarrhee;
        private System.Windows.Forms.PictureBox pctTete;
        private System.Windows.Forms.Button btnPousser;
    }
}