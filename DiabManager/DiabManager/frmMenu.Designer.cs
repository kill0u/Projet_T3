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
            this.btnTuto = new System.Windows.Forms.Button();
            this.cdPicker = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // btnTuto
            // 
            this.btnTuto.BackColor = System.Drawing.Color.Aqua;
            this.btnTuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTuto.Font = new System.Drawing.Font("Harlow Solid Italic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTuto.Location = new System.Drawing.Point(303, 296);
            this.btnTuto.Name = "btnTuto";
            this.btnTuto.Size = new System.Drawing.Size(284, 68);
            this.btnTuto.TabIndex = 2;
            this.btnTuto.Text = "Lancer Tutoriel";
            this.btnTuto.UseVisualStyleBackColor = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.btnTuto);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTuto;
        private System.Windows.Forms.ColorDialog cdPicker;
    }
}

