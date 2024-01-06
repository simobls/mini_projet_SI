using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exams_Planning
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-FRALV82\\SQLEXPRESS;Initial Catalog =GESTION_EXAMS; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.MidnightBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string module = comboBox2.GetItemText(comboBox2.SelectedItem);
                string lieu = comboBox5.GetItemText(comboBox5.SelectedItem);
                string enseignant = comboBox3.GetItemText(comboBox2.SelectedItem);
            string niveau = comboBox4.GetItemText(comboBox4.SelectedItem);
            string id1 = textBox2.Text;

                 DateTime date = dateTimePicker1.Value.Date;
             

            // Puoi utilizzare soloData come una variabile di tipo DateTime con solo la parte della data


            TimeSpan heure;
                TimeSpan.TryParse(textBox4.Text, out heure);
            TimeSpan duree;
            TimeSpan.TryParse(textBox3.Text, out duree);
            int i = 0;
            conn.Open();
            SqlCommand cmdinsert;
                SqlCommand check;
            check = conn.CreateCommand();
            check.CommandText = "SELECT date_Examen, heure_Examen, id_Lieu FROM GESTION_EXAMS.dbo.Examen WHERE date_Examen = @Data AND heure_Examen BETWEEN @Ora AND DATEADD(MINUTE, @Duree, heure_Examen) AND id_Lieu = @IdLieu";
            // Aggiungi i parametri alla query
            check.Parameters.AddWithValue("@Data", date);
            check.Parameters.AddWithValue("@Ora", heure);
            check.Parameters.AddWithValue("@Duree", duree.TotalMinutes);
            check.Parameters.AddWithValue("@IdLieu", lieu);
            SqlDataReader myReader = check.ExecuteReader();
            bool bo = myReader.Read();
            myReader.Close();
            conn.Close();
            if (textBox3.Text == "" || textBox4.Text == "" || textBox2.Text == "") {
                MessageBox.Show("il faut remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            conn.Open();
            SqlCommand count;
            count = conn.CreateCommand();
            count.CommandText = "SELECT count(nom_Module) FROM GESTION_EXAMS.dbo.Examen WHERE nom_Module=@nom_Module ";
            count.Parameters.AddWithValue("@nom_Module", module);
             string scaler = count.ExecuteScalar().ToString();
            int s =Convert.ToInt32(scaler);
            if (s > 2) { MessageBox.Show("Examan deja ajute deux fois");i++; }
            conn.Close();
            if (!bo)
            {
                conn.Open();
                cmdinsert = conn.CreateCommand();
                cmdinsert.CommandText = "INSERT INTO GESTION_EXAMS.dbo.Examen (id_Examen, date_Examen, heure_Examen, nom_Module, id_Lieu, Enseignant,duree,niveau) " +
                    "VALUES(@id_Examen, @date_Examen, @heure_Examen, @nom_Module, @id_Lieu, @Enseignant,@duree,@niveau)";

                // Aggiungi parametri al comando
                cmdinsert.Parameters.AddWithValue("@id_Examen", id1);
                cmdinsert.Parameters.AddWithValue("@date_Examen", date.Date);
                cmdinsert.Parameters.AddWithValue("@heure_Examen", heure);
                cmdinsert.Parameters.AddWithValue("@nom_Module", module);
                cmdinsert.Parameters.AddWithValue("@id_Lieu", lieu);
                cmdinsert.Parameters.AddWithValue("@Enseignant", enseignant);
                cmdinsert.Parameters.AddWithValue("@duree", duree);
                cmdinsert.Parameters.AddWithValue("@niveau", niveau);

                // Esegui il comando SQL
                cmdinsert.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Examen bien ajoutee");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                affichage();
            }
            else 
            {
                MessageBox.Show("lieu non disponible");
          
            }
                




            
           






        }

        private void Form1_Load(object sender, EventArgs e)
        {


            comboBox2_Selected();
            comboBox3_Selected();
            comboBox4_Selected();
            comboBox5_Selected();
               
            dataGridView1_Selected();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FILL(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_Selected()
        {
            conn.Open();
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select id_Examen,nom_Module,FORMAT(date_Examen, 'yyyy-MM-dd'), heure_Examen,duree, id_Lieu,niveau from GESTION_EXAMS.dbo.Examen ORDER BY CONVERT(DATETIME, CONVERT(VARCHAR, date_Examen, 112) + ' ' + CONVERT(VARCHAR, heure_Examen, 108), 113) ASC;";
            SqlDataReader myReader = cmd.ExecuteReader();
            // remplir la listebox par le résultat de la requête
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "IDENTIFICATEUR";
            dataGridView1.Columns[1].Name = "MODULE";
            dataGridView1.Columns[2].Name = "DATE";
            dataGridView1.Columns[3].Name = "HEURE";
            dataGridView1.Columns[4].Name = "DUREE";
            dataGridView1.Columns[5].Name = "LIEU";
            dataGridView1.Columns[6].Name = "NIVEAU";
            /*DataGridViewCheckBoxColumn colonnaSelect = new DataGridViewCheckBoxColumn();
            colonnaSelect.Name = "SELECT";
            colonnaSelect.HeaderText = "SELECT";
            dataGridView1.Columns.Add(colonnaSelect);*/

            while (myReader.Read())
                dataGridView1.Rows.Add(myReader[0], myReader[1], myReader[2], myReader[3], myReader[4], myReader[5], myReader[6]);
            myReader.Close();
            conn.Close();
           
        }
        private void affichage()
        {
            conn.Open();
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select id_Examen,nom_Module,FORMAT(date_Examen, 'yyyy-MM-dd'), heure_Examen,duree, id_Lieu,niveau from GESTION_EXAMS.dbo.Examen ORDER BY CONVERT(DATETIME, CONVERT(VARCHAR, date_Examen, 112) + ' ' + CONVERT(VARCHAR, heure_Examen, 108), 113) ASC;";
            SqlDataReader myReader = cmd.ExecuteReader();
            // remplir la listebox par le résultat de la requête
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "IDENTIFICATEUR";
            dataGridView1.Columns[1].Name = "MODULE";
            dataGridView1.Columns[2].Name = "DATE";
            dataGridView1.Columns[3].Name = "HEURE";
            dataGridView1.Columns[4].Name = "DUREE";
            dataGridView1.Columns[5].Name = "LIEU";
            dataGridView1.Columns[6].Name = "NIVEAU";
            /*DataGridViewCheckBoxColumn colonnaSelect = new DataGridViewCheckBoxColumn();
            colonnaSelect.Name = "SELECT";
            colonnaSelect.HeaderText = "SELECT";
            dataGridView1.Columns.Add(colonnaSelect);*/
            while (myReader.Read())
                dataGridView1.Rows.Add(myReader[0], myReader[1], myReader[2], myReader[3], myReader[4], myReader[5], myReader[6]);
            myReader.Close();
            conn.Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void comboBox2_Selected()
        {
            conn.Open();
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select nom_Module from GESTION_EXAMS.dbo.Module";
            SqlDataReader myReader = cmd.ExecuteReader();
            // remplir la listebox par le résultat de la requête
            while (myReader.Read())
                comboBox2.Items.Add(myReader.GetString(0));
            myReader.Close();
            conn.Close();

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void comboBox5_Selected()
        {
            conn.Open();
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select id_Lieu from GESTION_EXAMS.dbo.Lieu";
            SqlDataReader myReader = cmd.ExecuteReader();
            // remplir la listebox par le résultat de la requête
            while (myReader.Read())
                comboBox5.Items.Add(myReader.GetValue(0));
            myReader.Close();
            conn.Close();

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_Selected()
        {
            conn.Open();
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select nom_Enseignant from GESTION_EXAMS.dbo.Enseignant";
            SqlDataReader myReader = cmd.ExecuteReader();
            // remplir la listebox par le résultat de la requête
            while (myReader.Read())
                comboBox3.Items.Add(myReader.GetValue(0));
            myReader.Close();
            conn.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
          
           

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string test = textBox4.Text;
            if (!IsFormatoOraValido(test))
            {
                MessageBox.Show("Format incorrect HH:mm.", "Erreur de Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Annulla l'evento Validating per impedire alla TextBox di perdere il focus
                e.Cancel = true;
            }
        }
        private bool IsFormatoOraValido(string test)
        {
            // Specifica i formati di ora consentiti
            string[] formatiOra = { "HH:mm", "H:mm" };

            // Verifica se il testo della TextBox è un formato di ora valido
            return DateTime.TryParseExact(test, formatiOra, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
           
            string test = textBox3.Text;
            if (!IsFormatoOraValido(test))
            {
                MessageBox.Show("Format incorrect HH:mm.", "Erreur de Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Annulla l'evento Validating per impedire alla TextBox di perdere il focus
                e.Cancel = true;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Ottieni il valore dell'IDENTIFICATEUR della riga selezionata
                string id = dataGridView1.Rows[rowIndex].Cells["IDENTIFICATEUR"].Value.ToString();

                // Esegui l'eliminazione nel database
                conn.Open();
                SqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM GESTION_EXAMS.dbo.Examen WHERE id_Examen=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();

                // Rimuovi la riga selezionata dalla DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Aggiorna la visualizzazione dei dati
                affichage();
            }
            else
            {
                MessageBox.Show("Seleziona una riga", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox4_Selected()
        {
            conn.Open();
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "select Name from GESTION_EXAMS.dbo.Niveau";
            SqlDataReader myReader = cmd.ExecuteReader();
            // remplir la listebox par le résultat de la requête
            while (myReader.Read())
                comboBox4.Items.Add(myReader.GetValue(0));
            myReader.Close();
            conn.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.MidnightBlue;
            e.CellStyle.ForeColor = Color.Orange;

            
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
        }

        private void dataGridView1_ColumnDefaultCellStyleChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }
    }
}
