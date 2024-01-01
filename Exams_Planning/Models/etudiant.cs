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
        private string password;
        private string email;
        

        public int Apogee {  get { return apogee; } set { apogee = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        
    }
}
