using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabManager.MiniJeu
{
    public partial class JeuCaPousse : Form
    {
        int compteur = 0;
        public JeuCaPousse()
        {
            InitializeComponent();
        }

        private void JeuCaPousse_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile(@"Ressources\Images\CaPousse\ImageBase.png");
            // Set the PictureBox image property to this image.
            // ... Then, adjust its height and width properties.
            pctDiarrhee.Image = image;
            pctDiarrhee.Height = image.Height;
            pctDiarrhee.Width = image.Width;

            pctDiarrhee.Controls.Add(pctTete);
            pctTete.Location = new Point(0, 0);

            Image i = Image.FromFile(@"Ressources\Images\CaPousse\Tete.png");
            // Set the PictureBox image property to this image.
            // ... Then, adjust its height and width properties.
            pctTete.Image = i;
            pctTete.Height = i.Height;
            pctTete.Width = i.Width;
            pctTete.BackColor = Color.Transparent;
        }

        private void JeuCaPousse_KeyDown(object sender, KeyEventArgs e)
        {
            pousser();
        }

        private void JeuCaPousse_KeyUp(object sender, KeyEventArgs e)
        {
            compteur = 0;
        }

        private void btnPousser_Click(object sender, EventArgs e)
        {
            pousser();
        }

        private void pousser()
        {
            compteur++;
            /*Console.WriteLine(compteur);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color gotColor = bmp.GetPixel(x, y);
                    gotColor = Color.FromArgb(r, gotColor.G, gotColor.B);
                    bmp.SetPixel(x, y, gotColor);
                }
            }*/
        }
    }
}
