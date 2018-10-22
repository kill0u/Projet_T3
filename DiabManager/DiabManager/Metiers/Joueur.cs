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
        private string m_nom; /**<Le nom du joueur (type string). */
        public string Nom /**<Le nom du joueur. L'accesseur du nom du joueur. */
        {
            get { return m_nom; }
            set { this.m_nom = value; }
        }
        private string m_prenom; /**<Le prénom du joueur (type string). */
        public string Prenom /**<Le prénom du joueur. L'accesseur du prénom du joueur. */
        {
            get { return m_prenom; }
            set { this.m_prenom = value; }
        }
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
        private double m_glycemieMatin; /**<Le taux de glycémie du joueur mesurée au matin. */
        public double GlycemieMatin /**<Le taux de glycémie au matin du joueur. L'accesseur permettant du taux de glycémie au matin. */
        {
            get { return m_glycemieMatin; }
        }
        private double m_glycemieCourante; /**<Le taux de glycémie courant du joueur. */
        public double GlycemieCourante /**<Le taux de glycémie courant du joueur. L'accesseur du taux de glycémie courant. */
        {
            get { return m_glycemieCourante; }
        }
        private double m_glycemieObjectifBas; /**<L'objectif bas du taux de glycémie du joueur. */
        public double GlycemieObjectifBas /**<L'objectif bas du taux de glycémie du joueur. L'accesseur de l'objectif bas du taux de glycémie.*/
        {
            get { return m_glycemieObjectifBas; }
            set { this.m_glycemieObjectifBas = value; }
        }
        private double m_glycemieObjectifHaut; /**<L'objectif haut du taux de glycémie du joueur. */
        public double GlycemieObjectifHaut /**<L'objectif haut du taux de glycémie du joueur. L'accesseur de l'objectif haut du taux de glycémie.*/
        {
            get { return m_glycemieObjectifHaut; }
            set { this.m_glycemieObjectifHaut = value; }
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
        private int m_stress; /**<Le stress du joueur. Le stress du joueur va modifier son taux de glycémie. */
        public int Stress /**<Le stress du joueur. L'accesseur du stress du joueur. */
        {
            get { return m_stress; }
            set { this.m_stress = value; }
        }

        /// <summary>
        /// Le constructeur d'un joueur.
        /// </summary>
        /// <param name="nom">Le nom de famille du joueur. En string.</param>
        /// <param name="prenom">Le prénom du joueur. En string.</param>
        /// <param name="sexe">Le sexe du joueur. En char.</param>
        /// <param name="taille">La taille du joueur. En int.</param>
        /// <param name="poids">Le poids du joueur. En double.</param>
        /// <param name="glycemie">Le taux de glycemie du joueur, quand il démarre la partie. En double.</param>
        /// <param name="glycemieObjectifBas">La valeur basse de l'objectif du taux de glycémie du joueur. En double.</param>
        /// <param name="glycemieObjectifHaut">La valeur haute de l'objectif du taux de glycémie du joueur. En double.</param>
        public Joueur(string nom, string prenom, char sexe, int taille, double poids, double glycemie, double glycemieObjectifBas, double glycemieObjectifHaut)
        {
            this.m_nom = nom;
            this.m_prenom = prenom;
            this.m_sexe = sexe;
            this.m_taille = taille;
            this.m_poids = poids;
            this.m_glycemieCourante = glycemie;
            this.m_glycemieObjectifBas = glycemieObjectifBas;
            this.m_glycemieObjectifHaut = glycemieObjectifHaut;
        }

        /**
         * Fonction permettant de calculer l'IMC du joueur en fonction de son poids et de sa taille.
         * @param poids Le poids du joueur, type double.
         * @param taille La taille du joueur, type int.
         * 
         * @return imc L'IMC du joueur, type double.
         */
        private double getImc(double poids, int taille)
        {
            return poids / (taille * taille);
        }

        /**
         * Fonction permettant de calculer le taux de glycémie du joueur au matin.
         * @param ??? ???
         *
         */ 
        private void calculGlycemieMatin(double poids, int taille)
        {

        }

        /**
         * Fonction permettant de calculer le taux de glycémie du joueur régulièrement au courant de la journée.
         * @param coeff Le coefficient de l'action, qui permet de modifier la glycémie courante en fonction de l'action
         * 
         */ 
        public void calculGlycemieCourante(double coeff)
        {
            this.m_glycemieCourante = this.m_glycemieCourante * coeff;
        }
    }
}
