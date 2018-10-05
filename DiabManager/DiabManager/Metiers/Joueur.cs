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
        private float m_imc; /**<L'IMC du joueur. L'indice de masse corporelle (IMC=poids/(taille^2)). */
        public float Imc
        {
            get { return m_imc; }
            set { this.m_imc = value; }
        }
        private float m_glycemieMatin; /**<Le taux de glycémie du joueur mesurée au matin. */
        public float GlycemieMatin
        {
            get { return m_glycemieMatin; }
            set { this.m_glycemieMatin = value; }
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
    }
}
