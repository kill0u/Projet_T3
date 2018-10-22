using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiabManager.IHM;
using DiabManager.Metiers;

namespace DiabManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());
            IHM_Joueur.addJoueur(new Metiers.Joueur("Krebs", "leo", 'H', 180, 65.5, 2.5, 0.8, 1.3)); //Doit etre fait dans le menu avec les infos entré

            //On créer la partie
            Partie partie = new Partie();
            partie.Demarrer();

            //On créer la fenetre de jeu et on la lance
            frmJeu jeu = new frmJeu();

            IHM_Actions.setForm(jeu);
            IHM_Joueur.setForm(jeu);

            jeu.ShowDialog();
        }
    }
}
