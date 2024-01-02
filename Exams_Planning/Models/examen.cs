using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Models
{
    public class examen
    {
        private int id;
        private DateTime date;
        private module module;
        private lieu lieu;
        private ICollection<enseignant> enseignants;

        public int Id { get { return id; } set {  id = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public module Module { get { return module; } set { module = value; } }
        public lieu Lieu { get {  return lieu; } set {  lieu = value; } }
        public ICollection<enseignant> Enseignants { get { return enseignants; } set { enseignants = value; } }
    }
}
