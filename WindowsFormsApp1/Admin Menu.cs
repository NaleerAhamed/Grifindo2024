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
    public partial class Admin_Menu : Form
    {
        public Admin_Menu()
        {
            InitializeComponent();
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
            var back = MessageBox.Show("Would you like to go back?","Back",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (back == DialogResult.Yes)
            {
                Form2 Form = new Form2();
                Form.Show();
                this.Hide();
            }
        }

        private void button_Employeeleavedetails_Click(object sender, EventArgs e)
        {
            EmployeeDeatails employee = new EmployeeDeatails();
            employee.Show();
            this.Hide();
        }

        private void button_Defineroastertime_Click(object sender, EventArgs e)
        {
            Defineroaster defineroaster = new Defineroaster();
            defineroaster.Show();
            this.Hide();
        }

        private void button_RegisterNewEmployee_Click(object sender, EventArgs e)
        {
            RegisterEmployee registeremployee = new RegisterEmployee();
            registeremployee.Show();
            this.Hide();
        }
    }
}
