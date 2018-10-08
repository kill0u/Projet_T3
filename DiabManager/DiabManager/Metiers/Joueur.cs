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
        public double Poids /**<Le poids du joueur. L'accesseur du poids du joueur. */
        {
            get { return m_poids; }
            set { this.m_poids = value; }
        }
        private int m_taille; /**<La taille du joueur. La taille du joueur exprimée en cm (type int). */
        public int Taille /**<La taille du joueur. L'accesseur de la taille du joueur */
        {
            get { return m_taille; }
            set { this.m_taille = value; }
        }
        private float m_glycemieMatin; /**<Le taux de glycémie du joueur mesurée au matin. */
        public float GlycemieMatin /**<Le taux de glycémie au matin du joueur. L'accesseur permettant du taux de glycémie au matin. */
        {
            get { return m_glycemieMatin; }
        }
        private float m_glycemieCourante; /**<Le taux de glycémie courant du joueur. */
        public float GlycemieCourante /**<Le taux de glycémie courant du joueur. L'accesseur du taux de glycémie courant. */
        {
            get { return m_glycemieCourante; }
        }
        private float m_glycemieObjectif; /**<L'objectif du taux de glycémie du joueur. */
        public float GlycemieObjectif /**<L'objectif du taux de glycémie du joueur. L'accesseur de l'objectif du taux de glycémie.*/
        {
            get { return m_glycemieObjectif; }
            set { this.m_glycemieObjectif = value; }
        }
        private char m_sexe; /**<Le sexe du joueur. Le sexe du joueur (type char).*/
        public char Sexe /**<Le sexe du joueur. L'accesseur du sexe du joueur*/
        {
            get { return m_sexe; }
            set { this.m_sexe = value; }
        }
        private string m_profilPhysique; /**<Le profil physique du joueur. Le profil physique du joueur permet de connaître les attitudes et/ou la situation physique du joueur (sportif, agé, enceinte, ...). */
        public string ProfilPhysique /**<Le profil physique du joueur. L'accesseur du profil physique du joueur.*/
        {
            get { return m_profilPhysique; }
            set { this.m_profilPhysique = value; }
        }
        private int m_age; /**<L'age du joueur. L'age du joueur (type int).*/
        public int Age /**<L'age du joueur. L'accesseur de l'age du joueur.*/
        {
            get { return m_age; }
            set { this.m_age = value; }
        }

        /**
         * Fonction permettant de calculer l'IMC du joueur en fonction de son poids et de sa taille.
         * @param poids Le poids du joueur, type double.
         * @param taille La taille du joueur, type int.
         * 
         * @return imc L'IMC du joueur, en float.
         */
        private float getImc(double poids, int taille)
        {
            return (float)poids / (taille * taille);
        }

        /**
         * Fonction permettant de calculer le taux de glycémie du joueur au matin.
         * @param poids Le poids du joueur, type double.
         * @param taille La taille du joueur, type int.
         * @param ??? ???
         * 
         * @return glycemieMatin Le taux de glycémie du joueur au matin.
         */ 
        private float calculGlycemieMatin(double poids, int taille)
        {
            return -1;
        }

        /**
         * Fonction permettant de calculer le taux de glycémie du joueur au courant de la journée.
         * @param poids Le poids du joueur, type double.
         * @param taille La taille du joueur, type int.
         * 
         * @return glycemieCourante Le taux de glycémie courante du joueur.
         */ 
        private float calculGlycemieCourante(double poids, int taille)
        {
            return -1;
        }
    }
}
