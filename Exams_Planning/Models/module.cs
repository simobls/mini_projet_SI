using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Module")]
        public string Nom { get { return nom; } set { nom = value; } }

        [DisplayName("Prof")]
        public enseignant Prof { get { return prof; } set {  prof = value; } }

        [DisplayName("Niveau")]
        public niveau Niveau { get { return niveau; } set {  niveau = value; } }
    }
}
