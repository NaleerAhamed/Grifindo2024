using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Step one is here

namespace WindowsFormsApp1
{
    public partial class RegisterEmployee : Form
    {
        //connecting to database
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SIEET30\SQLEXPRESS;Initial Catalog=Grifindo2024;Integrated Security=True");
        SqlCommand cmd;
        string Gender;
        public RegisterEmployee()
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

        // Here is the Search buttons codes
       private void button_search_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string serach = "SELECT * FROM Employee_tb WHERE Employee_number='" + textbox_employeenumber.Text + "'";
                cmd = new SqlCommand(serach, conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    textBox_firstname.Text = dr["First_name"].ToString();
                    textBox_lastname.Text = dr["Last_name"].ToString();
                    Gender = dr["Gender"].ToString();
                    if(Gender == "Male")
                    {
                        radiobutton_male.Checked = true;
                    }
                    else
                    {
                        radiobutton_female.Checked = true;
                    } 
                    datetimepicker_dob.Text = dr["Date_of_birth"].ToString();
                    textBox_address.Text = dr["Address"].ToString();
                    textBox_contactno.Text = dr["Contact_no"].ToString();
                    MessageBox.Show("Records found!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //dateTimePicker_workstarttime.Text = dr["Work_start_time"].ToString();
                    //dateTimePicker_workendtime.Text = dr["Work_end_time"].ToString();
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

        private void button_Update_Click(object sender, EventArgs e)
        {
            conn.Open();
            string update = "UPDATE Employee_tb SET First_name='" + textBox_firstname.Text + "',Last_name='" + textBox_lastname.Text + "',Gender='" + Gender + "',Date_of_birth='" + datetimepicker_dob.Text + "',Address='" + textBox_address.Text + "',Contact_no='" + textBox_contactno.Text + "' WHERE Employee_number='" + textbox_employeenumber.Text + "'";
            cmd = new SqlCommand(update, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Records updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "DELETE from Employee_tb WHERE Employee_number = '" + textbox_employeenumber.Text + "'";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Records deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are you sure want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textbox_employeenumber.Clear();
            textBox_firstname.Clear();
            textBox_lastname.Clear();
            radiobutton_male.Checked = false;
            radiobutton_female.Checked = false;
            datetimepicker_dob.Text = "";
            textBox_address.Clear();
            textBox_contactno.Clear();
            textbox_employeenumber.Focus();
        }
        
        private void button_register_Click(object sender, EventArgs e)
        {
            try
            {
                datetimepicker_dob.Format = DateTimePickerFormat.Custom;
                datetimepicker_dob.CustomFormat = "yyyy/MM/dd";

                // Set Gender based on radio button selection, if not already set
                if (radiobutton_male.Checked)
                {
                    Gender = "Male";
                }
                else if (radiobutton_female.Checked)
                {
                    Gender = "Female";
                }

                conn.Open();
                string insert = "INSERT INTO Employee_tb (Employee_number, First_name, Last_name, Gender, Date_of_birth, Address, Contact_no) " +
                                "VALUES (@Employee_number, @First_name, @Last_name, @Gender, @Date_of_birth, @Address, @Contact_no)";

                cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@Employee_number", textbox_employeenumber.Text);
                cmd.Parameters.AddWithValue("@First_name", textBox_firstname.Text);
                cmd.Parameters.AddWithValue("@Last_name", textBox_lastname.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender ?? ""); // Use a default empty string if Gender is null
                cmd.Parameters.AddWithValue("@Date_of_birth", datetimepicker_dob.Text);
                cmd.Parameters.AddWithValue("@Address", textBox_address.Text);
                cmd.Parameters.AddWithValue("@Contact_no", textBox_contactno.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Records inserted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable datatable = new DataTable();
            SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM Employee_tb", conn);
            dataadapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
            conn.Close();
        }
    }
}
