// adminDashboard.cs
using Exams_Planning.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Exams_Planning.Views
{
    public partial class adminDashboard : Form
    {
        private DateTime currentDate;
        public adminDashboard()
        {
            InitializeComponent();
            Load += adminDashboard_Load;
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            DisplayDays(currentDate.Year, currentDate.Month);
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

        private void nextbtn_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayDays(currentDate.Year, currentDate.Month);
        }

        private void prevbtn_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayDays(currentDate.Year, currentDate.Month);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
