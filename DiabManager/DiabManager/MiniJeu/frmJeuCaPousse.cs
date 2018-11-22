using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabManager.MiniJeu
{
    public partial class frmJeuCaPousse : Form
    {
        int compteur = 0;
        public frmJeuCaPousse()
        {
            InitializeComponent();
        }

        private void frmJeuCaPousse_Load(object sender, EventArgs e)
        {
            Image normal = Image.FromFile(@"Ressources/Images/CaPousse/ImageBase.png");
            pbNormal.Image = normal;
            pbNormal.Size = normal.Size;

            pbNormal.Controls.Add(pbTete);

            pbTete.BackColor = Color.Transparent;

            Image tete = Image.FromFile(@"Ressources/Images/CaPousse/Tete.png");
            pbTete.Image = tete;
            pbTete.Size = tete.Size;
        }

        private void pousser()
        {
            compteur++;
            Console.WriteLine(compteur);
            Color color = Color.Red; //Your desired colour

            byte r = color.R; //For Red colour

            using (Bitmap bmp = new Bitmap(pbTete.Image))
            {
                
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color gotColor = bmp.GetPixel(x, y);
                        gotColor = Color.FromArgb(r, gotColor.G, gotColor.B);
                        bmp.SetPixel(x, y, gotColor);
                    }
                } 
            }
        }

        private void btnPousser_Click(object sender, EventArgs e)
        {
            pousser();
        }
    }
}
