using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Defineroaster : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SIEET30\SQLEXPRESS;Initial Catalog=Grifindo2024;Integrated Security=True");
        SqlCommand cmd;
        public Defineroaster()
        {
            InitializeComponent();
        }

    

        private void button_back_Click(object sender, EventArgs e)
        {

            var back = MessageBox.Show("Would you like to go back?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (back == DialogResult.Yes)
            {
                Admin_Menu adminmenu = new Admin_Menu();
                adminmenu.Show();
                this.Hide();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textbox_employeenumber.Clear();
            textBox_firstname.Clear();
            textBox_lastname.Clear();
            dateTimePicker_workstarttime.Text = "";
            datetimepicker_workendtime.Text = "";
            textbox_employeenumber.Focus();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are you sure want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string search = "SELECT * FROM Employee_tb WHERE Employee_number='" + textbox_employeenumber.Text + "'";
                cmd = new SqlCommand(search, conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox_firstname.Text = dr["First_name"].ToString();
                    textBox_lastname.Text = dr["Last_name"].ToString();
                    dateTimePicker_workstarttime.Text = dr["Work_start_time"].ToString();
                    datetimepicker_workendtime.Text = dr["Work_end_time"].ToString();
                    
                    MessageBox.Show("Records found!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Records not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void Defineroaster_Load(object sender, EventArgs e)
        {

        }
    }
}
