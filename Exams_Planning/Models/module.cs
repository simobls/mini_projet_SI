using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class module
    {
        private string nom;
        private enseignant prof;
        private niveau niveau;

        public string Nom { get { return nom; } set { nom = value; } }
        public enseignant Prof { get { return prof; } set {  prof = value; } }
        public niveau Niveau { get { return niveau; } set {  niveau = value; } }
    }
}
