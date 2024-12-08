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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void btn_signin_Click(object sender, EventArgs e)
        {
            if (txtun.Text == "Admin" && txtpw.Text == "1234")
            {
                MessageBox.Show("Successfully logged in", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin_Menu Adminmenupage = new Admin_Menu();
                Adminmenupage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtun.Clear();
            txtpw.Clear();
            txtun.Focus();
        }

        private void btn_exit_Click(object sender, EventArgs e)
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
