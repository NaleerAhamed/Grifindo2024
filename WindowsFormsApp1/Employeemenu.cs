using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Employeemenu : Form
    {
        public Employeemenu()
        {
            InitializeComponent();
        }

        private void button_leavedetails_Click(object sender, EventArgs e)
        {
            Leavedetails leavedetails = new Leavedetails();
            leavedetails.Show();
            this.Hide();
        }

        private void button_applyforleave_Click(object sender, EventArgs e)
        {
            Applyforleave applyleave = new Applyforleave();
            applyleave.Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are you sure want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                // MessageBox.Show("Enter your username and password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }
    }
}
