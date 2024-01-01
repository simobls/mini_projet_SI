using Exams_Planning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exams_Planning.Views
{
    public partial class EtudiantPage : Form
    {
        public EtudiantPage()
        {
            InitializeComponent();
            Load += EtudiantPage_Load;
        }
        public etudiant LoggedInEtudiant { get; set; }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void EtudiantPage_Load(object sender, EventArgs e)
        {
            // Check if a student is logged in
            if (LoggedInEtudiant != null)
            {
                // Display student information in label1
                label1.Text = $"Student Info: Apogee - {LoggedInEtudiant.Apogee}, Niveau - {LoggedInEtudiant.Niveau}";
            }
        }

    }
}
