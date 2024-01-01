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
        DateTime now = DateTime.Now;
        public adminDashboard()
        {
            InitializeComponent();
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {
            int Month = now.Month;
            int Year = now.Year;
            displayDays(Year, Month);
        }

        private void displayDays(int year, int month)
        {
            daycontainer.Controls.Clear();
            string monthName = DateTimeFormatInfo.CurrentInfo.MonthNames[month - 1];
            label8.Text = monthName + " " + year;

            //first day of the month
            DateTime monthStart = new DateTime(year, month, 1);

            //count of days
            int days = DateTime.DaysInMonth(year, month);

            //monthstart to int
            int dayOfWeek = (int)monthStart.DayOfWeek; // Day of the week for the first day

            // Add blank user controls for days before the start of the month
            for (int i = 1; i < dayOfWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                daycontainer.Controls.Add(ucBlank);
            }

            // Day user control for each day in the month
            for (int i = 1; i <= days; i++)
            {
                DayUserControl ucdays = new DayUserControl();
                ucdays.days(i);
                bool isToday = (DateTime.Now.Year == year && DateTime.Now.Month == month && i == DateTime.Now.Day);
                ucdays.HighlightToday(isToday);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            int month = now.Month + 1;
            int year = now.Year;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            now = new DateTime(year, month, 1);
            displayDays(year, month);
        }

        private void prevbtn_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            int month = now.Month - 1;
            int year = now.Year;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            now = new DateTime(year, month, 1);
            displayDays(year, month);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
