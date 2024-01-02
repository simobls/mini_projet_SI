using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class enseignant
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string password;
        private string tel;
        private module module;

        public int Id { get { return id; } set {  id = value; } }
        public string Name { get { return nom; } set { nom = value; } }
        public string Prenom { get {  return prenom; } set {  prenom = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Tel { get { return tel; } set {  tel = value; } }
        public module Module { get { return module; } set {  module = value; } }
    }
}
