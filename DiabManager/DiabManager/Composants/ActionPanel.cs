﻿using DiabManager.Metiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabManager.Composants
{
    /// <summary>
    /// Composants permettant d'affiché une action
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public partial class ActionPanel : Panel
    {
        public ActionPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur de l'Action Panel, construit autour des informations d'une action
        /// </summary>
        /// <param name="a">Action à présenter</param>
        public ActionPanel(Actions a)
        {
            InitializeComponent();

            this.Name = a.Nom;
            this.Size = new Size(200, 200);
            this.Click += new System.EventHandler(boutonClick);


            Label l = new Label();
            l.Text = a.Nom;
            l.Location = new Point(5, 5);
            l.MaximumSize = new Size(190, 30);
            l.AutoSize = true;
            l.Click += new EventHandler(componentClick);
            l.Font = new Font(FontFamily.GenericSansSerif, 8);

            Label l2 = new Label();
            l2.Text = a.Desc;
            l2.Location = new Point(5, 25);
            l2.MaximumSize = new Size(190, 40);
            l2.AutoSize = true;
            l2.Click += new EventHandler(componentClick);
            l2.Font = new Font(FontFamily.GenericSansSerif, 8);

            if (a.Url != "")
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.ImageLocation = a.Url;

                pb.Size = new Size(190, 140);
                pb.Location = new Point(5, 65);

                this.Controls.Add(pb);
                pb.Click += new EventHandler(componentClick);
            }


            this.Controls.Add(l);
            this.Controls.Add(l2);



        }

        public ActionPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Action a effectué lors du click sur le bouton
        /// </summary>
        /// <param name="sender">Bouton sur lequel on appuie</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void boutonClick(object sender, EventArgs e)
        {
            Panel b = (Panel)sender;
            IHM.IHM_Actions.EffectuerAction(b.Name);
        }

        /// <summary>
        /// Action a effectué lors du click sur le bouton
        /// </summary>
        /// <param name="sender">Bouton sur lequel on appuie</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void componentClick(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            Panel b = (Panel)c.Parent;
            IHM.IHM_Actions.EffectuerAction(b.Name);
        }
    }
}
