using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class etudiant
    {
        private int apogee;
        private string prenom;
        private string nom;
        private string password;
        private string email;
        private niveau niveau;

        public int Apogee {  get { return apogee; } set { apogee = value; } }
        public string Prenom { get { return prenom; } set {  prenom = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public niveau Niveau { get { return niveau; } set { niveau = value; } }
    }
}
