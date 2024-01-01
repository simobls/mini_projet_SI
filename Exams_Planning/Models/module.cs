using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class module
    {
        private int nom;
        private enseignant prof;

        public int Nom { get { return nom; } set { nom = value; } }
        public enseignant Prof { get { return prof; } set {  prof = value; } }
    }
}
