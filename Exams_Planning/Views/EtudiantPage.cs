using Exams_Planning.Models;
using System.Globalization;
using System.Windows.Forms;
using System;

namespace Exams_Planning.Views
{
    public partial class EtudiantPage : Form
    {
        private DateTime currentDate;

        public EtudiantPage()
        {
            InitializeComponent();
            Load += EtudiantPage_Load;
        }

        public etudiant LoggedInEtudiant { get; set; }

        private void EtudiantPage_Load(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            DisplayDays(currentDate.Year, currentDate.Month);

            if (LoggedInEtudiant != null)
            {
                label10.Text = $"Student Info: Apogee - {LoggedInEtudiant.Apogee}, Name: {LoggedInEtudiant.Nom} {LoggedInEtudiant.Prenom}, Niveau: {LoggedInEtudiant.Niveau.Name}";
            }
        }

        private void DisplayDays(int year, int month)
        {
            daycontainer.Controls.Clear();
            string monthName = DateTimeFormatInfo.CurrentInfo.MonthNames[month - 1];
            label8.Text = $"{monthName} {year}";

            DateTime monthStart = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayOfWeek = (int)monthStart.DayOfWeek;

            for (int i = 1; i < dayOfWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                daycontainer.Controls.Add(ucBlank);
            }

            for (int i = 1; i <= days; i++)
            {
                DayUserControl ucDays = new DayUserControl();
                ucDays.days(i);
                bool isToday = (DateTime.Today.Year == year && DateTime.Today.Month == month && i == DateTime.Today.Day);
                ucDays.HighlightToday(isToday);
                daycontainer.Controls.Add(ucDays);
            }
        }

        private void prevbtn_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayDays(currentDate.Year, currentDate.Month);
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayDays(currentDate.Year, currentDate.Month);
        }
    }
}
