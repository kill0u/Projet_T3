﻿using System;
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
        /// Le main de l'application DiabManager
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult dr = DialogResult.OK;

            while (dr == DialogResult.OK)
            {
                frmMenu Menu = new frmMenu();
                Application.Run(Menu);
                dr = Menu.MenuExit;
                //IHM_Joueur.addJoueur(new Metiers.Joueur("Krebs",21,"leo", 'H', 180, 65.5, 2.5, 0.8, 1.3)); //Doit etre fait dans le menu avec les infos entrées
                if (Menu.MenuExit == DialogResult.OK)
                {
                    IHM_Joueur.getJoueur();
                    //On créer la fenetre de jeu et on la lance
                    frmJeu jeu = new frmJeu();

                    IHM_Actions.setForm(jeu);
                    IHM_Joueur.setForm(jeu);

                    //On créé la partie
                    Partie partie = new Partie();
                    partie.Demarrer(jeu);

                    jeu.ShowDialog();
                    dr = jeu.DialogResult;

                    Temps.destroyInstance();
                    Gestionnaires.ActionControlleur.destroyInstance();
                } 
            }

        }
    }
}
