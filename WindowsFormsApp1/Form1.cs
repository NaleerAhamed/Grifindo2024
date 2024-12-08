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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_admin_Click(object sender, EventArgs e)
        {
            Form2 Admin = new Form2();
            Admin.Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are You Sure Want to Exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button_employee_Click(object sender, EventArgs e)
        {
            Employee Employ = new Employee();
            Employ.Show();
            this.Hide();
        }
    }
}
