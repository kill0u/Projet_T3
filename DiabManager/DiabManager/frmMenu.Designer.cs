namespace DiabManager
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.cdPicker = new System.Windows.Forms.ColorDialog();
            this.BONJOUR = new System.Windows.Forms.Label();
            this.toolTipGlyc = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipHaut = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBas = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // BONJOUR
            // 
            this.BONJOUR.AutoSize = true;
            this.BONJOUR.Font = new System.Drawing.Font("Myanmar Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BONJOUR.ForeColor = System.Drawing.Color.Aqua;
            this.BONJOUR.Location = new System.Drawing.Point(113, 129);
            this.BONJOUR.Name = "BONJOUR";
            this.BONJOUR.Size = new System.Drawing.Size(117, 37);
            this.BONJOUR.TabIndex = 0;
            this.BONJOUR.Text = "BONJOUR";
            this.BONJOUR.Visible = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(951, 390);
            this.Controls.Add(this.BONJOUR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog cdPicker;
        private System.Windows.Forms.Label BONJOUR;
        private System.Windows.Forms.ToolTip toolTipGlyc;
        private System.Windows.Forms.ToolTip toolTipHaut;
        private System.Windows.Forms.ToolTip toolTipBas;
    }
}

