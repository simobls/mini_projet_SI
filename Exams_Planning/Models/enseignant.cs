using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public int Id { get { return id; } set {  id = value; } }

        [DisplayName("Name")]
        [Required(ErrorMessage = "name is required")]
        public string Name { get { return nom; } set { nom = value; } }

        [DisplayName("Lastname")]
        [Required(ErrorMessage = "Lastname is required")]
        public string Prenom { get {  return prenom; } set {  prenom = value; } }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get { return email; } set { email = value; } }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get { return password; } set { password = value; } }

        [DisplayName("Phone")]
        [Required(ErrorMessage = "Phone is required")]
        public string Tel { get { return tel; } set {  tel = value; } }
    }
}
