using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class lieu
    {
        private int id;
        private string name;
        private int capacite;
        private string type;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Capacite { get {  return capacite; } set {  capacite = value; } }
        public string Type { get { return type; } set { type = value; } }
    }
}
