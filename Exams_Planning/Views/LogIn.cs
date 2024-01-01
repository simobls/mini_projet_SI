using Exams_Planning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exams_Planning.Views
{
    public partial class LogIn : Form, ILogin
    {
        public string connectionString = "Data Source=DESKTOP-LV5REMR\\SQLEXPRESS;Initial Catalog=GESTION_EXAMS;Integrated Security=True;";
        private readonly ErrorProvider errorProvider = new ErrorProvider();
        public LogIn()
        {
            InitializeComponent();
            textPassword.UseSystemPasswordChar = true;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public string email { get => textEmail.Text; set => email = textEmail.Text; }
        public string password { get => textPassword.Text; set => password = textPassword.Text; }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateEmail())
            {
                MessageBox.Show("Enter a valid email.");
            }
            else
            {
                if (radioAdmin.Checked || radioEtud.Checked || radioEnseign.Checked)
                {
                    using (var connection = new SqlConnection(connectionString))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;

                        int i = 0;

                        if (radioAdmin.Checked)
                        {
                            command.CommandText = "SELECT * FROM admin WHERE email_admin = @Email AND mdp_admin = @Password";
                            i = 1;
                        }
                        else if (radioEtud.Checked)
                        {
                            command.CommandText = "SELECT * FROM Etudiant WHERE email_Etudiant = @Email AND mdp_Etudiant = @Password";
                            i = 2;
                        }
                        else if (radioEnseign.Checked)
                        {
                            command.CommandText = "SELECT * FROM Enseignant WHERE email_Enseignant = @Email AND mdp_Enseignant = @Password";
                            i = 3;
                        }

                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (i == 1)
                                {
                                    adminDashboard dash = new adminDashboard();
                                    dash.Show();
                                    this.Hide();
                                }
                                else if (i == 2)
                                {
                                    if (reader.Read())
                                    {
                                        EtudiantPage etudiantp = new EtudiantPage();
                                        etudiantp.LoggedInEtudiant = new etudiant
                                        {
                                            Apogee = (int)reader[0],

                                        };
                                        etudiantp.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid login credentials");
                                    }
                                }
                                else if (i == 3)
                                {
                                    //enseignant page 
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid login credentials");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Choose a category before attempting to log in.");
                }
            }
        }
        private bool ValidateEmail()
        {
            string email = textEmail.Text.Trim();
            string emailPattern = @"^\S+@\S+\.\S+$";
            Regex regex = new Regex(emailPattern);

            if (regex.IsMatch(email))
            {
                // Clear any previous error
                errorProvider.SetError(textEmail, "");
                return true;
            }
            else
            {
                // Display an error message and set the error
                errorProvider.SetError(textEmail, "Please enter a valid email address.");
                return false;
            }
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
