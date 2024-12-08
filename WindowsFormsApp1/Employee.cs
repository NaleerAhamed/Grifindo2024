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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void check_password_CheckedChanged(object sender, EventArgs e)
        {

            if (check_password.Checked == true)
            {
                txtpw.UseSystemPasswordChar = true;
            }
            else
            {
                txtpw.UseSystemPasswordChar = false;
            }
        }

        private void button_signin_Click(object sender, EventArgs e)
        {
            if (txtun.Text =="Employee" && txtpw.Text == "1234")
            {
                MessageBox.Show("Successfully logged in", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Employeemenu employeemenupage = new Employeemenu();
                employeemenupage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txtun.Clear();
            txtpw.Clear();
            txtun.Focus();
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
                MessageBox.Show("Enter your username and password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
