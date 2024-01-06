using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class niveau
    {
        private int id;
        private string name;
        private ICollection<etudiant> etudiants;
        private ICollection<module> modules;

        public int Id { get { return id; } set {  id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public ICollection<etudiant> Etudiants { get { return etudiants; } set { etudiants = value; } }
        public ICollection<module> Modules { get {  return modules; } set { modules = value; } }
    }
}
