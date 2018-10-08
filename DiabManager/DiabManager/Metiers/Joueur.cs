using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabManager.Metiers
{
    /**
     * La classe Joueur représente le personnage joué par l'utilisateur.
     * @version 1.0
     * @author Léo Krebs
     */
    class Joueur
    {
        private double m_poids; /**<Le poids du joueur. Le poids du joueur en kg (type double). */
        public double Poids
        {
            get { return m_poids; }
            set { this.m_poids = value; }
        }
        private int m_taille; /**<La taille du joueur. La taille du joueur exprimée en cm (type int). */
        public int Taille
        {
            get { return m_taille; }
            set { this.m_taille = value; }
        }
        private float m_glycemieMatin; /**<Le taux de glycémie du joueur mesurée au matin. */
        public float GlycemieMatin
        {
            get { return m_glycemieMatin; }
            set { this.m_glycemieMatin = value; }
        }
        private float m_glycemieCourante; /**<Le taux de glycémie courant du joueur. */
        public float GlycemieCourante
        {
            get { return m_glycemieCourante; }
            set { this.m_glycemieCourante = value; }
        }
        private float m_glycemieObjectif; /**<L'objectif du taux de glycémie du joueur. */
        public float GlycemieObjectif
        {
            get { return m_glycemieObjectif; }
            set { this.m_glycemieObjectif = value; }
        }
        private char m_sexe; /**<Le sexe du joueur. Le sexe du joueur (type char).*/
        public char Sexe
        {
            get { return m_sexe; }
            set { this.m_sexe = value; }
        }
        private string m_profilPhysique; /**<Le profil physique du joueur. Le profil physique du joueur permet de connaître les attitudes et/ou la situation physique du joueur (sportif, agé, enceinte, ...). */
        public string ProfilPhysique
        {
            get { return m_profilPhysique; }
            set { this.m_profilPhysique = value; }
        }
        private int m_age; /**<L'age du joueur. L'age du joueur (type int). */
        public int Age
        {
            get { return m_age; }
            set { this.m_age = value; }
        }

        /**
         * Fonction permettant de calcumer l'IMC du joueur en fonction de son poids et de sa taille.
         * @param poids Le poids du joueur, type double.
         * @param taille La taille du joueur, type int.
         * 
         * @return imc L'IMC du joueur, en float.
         */
        private float getImc(double poids, int taille)
        {
            return (float)poids / (taille * taille);
        }

        private float calculGlycemieMatin(double poids, int taille)
        {
            return -1;
        }

        private float calculGlycemieCourante(double poids, int taille)
        {
            return -1;
        }
    }
}
