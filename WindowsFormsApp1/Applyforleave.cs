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
    public partial class Applyforleave : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SIEET30\SQLEXPRESS;Initial Catalog=Grifindo2024;Integrated Security=True");
        SqlCommand cmd;
        public Applyforleave()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string search = "SELECT * FROM Leave WHERE Employee_number='" + textbox_employeenumber.Text + "'";
                cmd = new SqlCommand(search, conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    textBox_LI.Text = dr["Leave_id"].ToString();
                    textBox_firstname.Text = dr["First_name"].ToString();
                    textBox_lastname.Text = dr["Last_name"].ToString();
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
                MessageBox.Show("Records not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
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

        private void button_applyleave_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                conn.Open();

                // Prepare the SQL query with specified columns (excluding Applied_date and Status)
                string insert = "INSERT INTO Leave2 (Employee_number, Leave_id, First_name, Last_name, Leave_type, Start_date, End_date) " +
                                "VALUES (@EmployeeNumber, @LeaveId, @FirstName, @LastName, @LeaveType, @StartDate, @EndDate)";

                // Create the SQL command
                cmd = new SqlCommand(insert, conn);

                // Add parameters to prevent SQL injection and pass user inputs
                cmd.Parameters.AddWithValue("@EmployeeNumber", textbox_employeenumber.Text);
                cmd.Parameters.AddWithValue("@LeaveId", textBox_LI.Text);
                cmd.Parameters.AddWithValue("@FirstName", textBox_firstname.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox_lastname.Text);
                cmd.Parameters.AddWithValue("@LeaveType", textBox_leavetype.Text);
                cmd.Parameters.AddWithValue("@StartDate", dateTimePicker_startdate.Value.Date);
                cmd.Parameters.AddWithValue("@EndDate", datetimepicker_enddate.Value.Date);

                // Execute the command
                cmd.ExecuteNonQuery();

                // Show success message
                MessageBox.Show("Leave Applied Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error message if an exception occurs
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the database connection
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textbox_employeenumber.Clear();
            textBox_firstname.Clear();
            textBox_lastname.Clear();
            textBox_leavetype.Clear();
            dateTimePicker_startdate.Text = "";
            datetimepicker_enddate.Text = "";
           
            textbox_employeenumber.Focus();
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
            dataGridView3.DataSource = dt;
            conn.Close();
        }
    }
}
