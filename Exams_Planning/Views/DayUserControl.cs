using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exams_Planning.Models
{
    public partial class DayUserControl : UserControl
    {
        public DayUserControl()
        {
            InitializeComponent();
        }

        private void DayUserControl_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }
        public void HighlightToday(bool isToday)
        {
            if (isToday)
            {
                BackColor = Color.FromArgb(255, 196, 54);
            }
            else
            {
                BackColor = Color.White;
            }
        }

        private void lbdays_Click(object sender, EventArgs e)
        {

        }
    }
}
