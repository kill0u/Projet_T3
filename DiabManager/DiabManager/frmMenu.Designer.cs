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
            this.toolTipGlyc = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipHaut = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBas = new System.Windows.Forms.ToolTip(this.components);
            this.lblNouvelles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNouvelles
            // 
            this.lblNouvelles.AutoSize = true;
            this.lblNouvelles.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNouvelles.ForeColor = System.Drawing.Color.Aqua;
            this.lblNouvelles.Location = new System.Drawing.Point(172, 226);
            this.lblNouvelles.Name = "lblNouvelles";
            this.lblNouvelles.Size = new System.Drawing.Size(60, 29);
            this.lblNouvelles.TabIndex = 0;
            this.lblNouvelles.Text = "label1";
            this.lblNouvelles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNouvelles.Visible = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(951, 390);
            this.Controls.Add(this.lblNouvelles);
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
        private System.Windows.Forms.ToolTip toolTipGlyc;
        private System.Windows.Forms.ToolTip toolTipHaut;
        private System.Windows.Forms.ToolTip toolTipBas;
        private System.Windows.Forms.Label lblNouvelles;
    }
}

