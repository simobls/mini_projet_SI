using Exams_Planning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exams_Planning.Views
{
    public partial class modulePage : Form
    {
        public string connectionString = "Data Source=DESKTOP-LV5REMR\\SQLEXPRESS;Initial Catalog=GESTION_EXAMS;Integrated Security=True;";
        enseignant selectedProfessor;
        niveau selectedNiveau;
        public modulePage()
        {
            InitializeComponent();
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;
            dataGridView1.DataSource = GetAll();
        }
        private void modulePage_Load(object sender, EventArgs e)
        {
            profList_add();
            niveauList_add();
        }
        public class ModuleDisplayInfo
        {
            public string Nom_Module { get; set; }
            public string Prof { get; set; }
            public string Niveau { get; set; }
        }
        public BindingList<ModuleDisplayInfo> GetAll()
        {
            string query = "SELECT Module.nom_Module, Enseignant.nom_Enseignant, Enseignant.prenom_Enseignant, Niveau.Name " +
                           "FROM Module " +
                           "JOIN Enseignant ON Module.Id_Enseignant = Enseignant.Id_Enseignant " +
                           "JOIN Niveau ON Module.NiveauId = Niveau.NiveauId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                BindingList<ModuleDisplayInfo> moduleList = new BindingList<ModuleDisplayInfo>();

                while (reader.Read())
                {
                    ModuleDisplayInfo displayInfo = new ModuleDisplayInfo
                    {
                        Nom_Module = reader["nom_Module"].ToString(),
                        Prof = $"{reader["nom_Enseignant"]} {reader["prenom_Enseignant"]}",
                        Niveau = reader["Name"].ToString()
                    };

                    moduleList.Add(displayInfo);
                }

                return moduleList;
            }
        }
        private void profList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profList.SelectedIndex != -1)
            {
                string selectedProfessorFullName = profList.SelectedItem.ToString();

                string[] parts = selectedProfessorFullName.Split(' ');

                selectedProfessor = new enseignant { Nom = parts[0], Prenom = parts[1] };
            }
        }
        private void niveauList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (niveauList.SelectedIndex != -1)
            {
                selectedNiveau = new niveau { Name = niveauList.SelectedItem.ToString() };
            }
        }
        public void profList_add()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from Enseignant";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    enseignant prof = new enseignant()
                    {
                        Nom = reader["nom_Enseignant"].ToString(),
                        Prenom = reader["prenom_Enseignant"].ToString()
                    };
                    profList.Items.Add(prof.FullName());
                }
            }
        }
        public void niveauList_add()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from Niveau";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    niveauList.Items.Add(reader[1].ToString());
                }
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string nom = textMod.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Module (nom_Module, Id_Enseignant, NiveauId)
                                 VALUES (
                                         @Nom_Module,
                                         (SELECT Id_Enseignant FROM Enseignant WHERE Nom_Enseignant = @Nom AND Prenom_Enseignant = @Prenom),
                                         (SELECT NiveauId FROM Niveau WHERE Name = @Name)
                                )";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom_Module", nom);
                command.Parameters.AddWithValue("@Nom", selectedProfessor.Nom);
                command.Parameters.AddWithValue("@Prenom", selectedProfessor.Prenom);
                command.Parameters.AddWithValue("@Name", selectedNiveau.Name);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Module added successfully!");
                    dataGridView1.DataSource = GetAll();
                }
                else
                {
                    MessageBox.Show("Failed to add module. Please check your input.");
                }
            }
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //double click to modify
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string oldNom = selectedRow.Cells["Nom_Module"].Value.ToString();
                string oldProf = selectedRow.Cells["Prof"].Value.ToString();
                string oldNiveau = selectedRow.Cells["Niveau"].Value.ToString();

                tabControl1.SelectedTab = tabControl1.TabPages[1];

                textMod.Text = oldNom;
                profList.SelectedItem = oldProf;
                niveauList.SelectedItem = oldNiveau;
            }
        }
        private void modBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string oldNom_Module = selectedRow.Cells["Nom_Module"].Value.ToString();
                connection.Open();
                
                string query = @"UPDATE Module
                             SET nom_Module = @NewNom_Module,
                                 Id_Enseignant = (SELECT Id_Enseignant FROM Enseignant WHERE Nom_Enseignant = @NewNom AND Prenom_Enseignant = @NewPrenom),
                                 NiveauId = (SELECT NiveauId FROM Niveau WHERE Name = @NewName)
                             WHERE nom_Module = @OldNom_Module";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewNom_Module", textMod.Text);
                command.Parameters.AddWithValue("@OldNom_Module", oldNom_Module);
                command.Parameters.AddWithValue("@NewNom", selectedProfessor.Nom);
                command.Parameters.AddWithValue("@NewPrenom", selectedProfessor.Prenom);
                command.Parameters.AddWithValue("@NewName", selectedNiveau.Name);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Module modified successfully!");
                    dataGridView1.DataSource = GetAll();
                }
                else
                {
                    MessageBox.Show("Failed to modify module. Please check your input.");
                }
            }
        }
    }
}
