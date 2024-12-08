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
    public partial class Leavedetails : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SIEET30\SQLEXPRESS;Initial Catalog=Grifindo2024;Integrated Security=True");
        SqlCommand cmd;
        public Leavedetails()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string search = "SELECT * FROM Leave2 WHERE Employee_number='" + textbox_employeenumber.Text + "'";
                cmd = new SqlCommand(search, conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    textBox_leavetype.Text = dr["Leave_type"].ToString();
                    dateTimePicker_startdate.Text = dr["Start_date"].ToString();
                    datetimepicker_enddate.Text = dr["End_date"].ToString();
                    

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

        private void button_deleteleave_Click(object sender, EventArgs e)
        {
            conn.Open();
            string delete = "DELETE FROM Leave2 WHERE Employee_number='" + textbox_employeenumber.Text + "'";
            cmd = new SqlCommand(delete, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Records deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textbox_employeenumber.Clear();
            textBox_leavetype.Clear();
            dateTimePicker_startdate.Text = "";
            datetimepicker_enddate.Text = "";
            textbox_employeenumber.Focus();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            var back = MessageBox.Show("Would you like to go back?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (back == DialogResult.Yes)
            {
                Employeemenu employeemenu = new Employeemenu();
                employeemenu.Show();
                this.Hide();
            }
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

        private void button_approveorreject_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Leave2", conn);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }
    }
    
}
