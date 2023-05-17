using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Library_Login_System.Views
{
    public partial class library_register : System.Web.UI.Page
    {
        //Sql Connection
        SqlConnection db_con = new SqlConnection("Data Source=ECCLESIASTES\\SQLEXPRESS;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Check if the current time is outside the allowed hours (7am - 5pm)
                DateTime currentTime = DateTime.Now;
                TimeSpan startTime = new TimeSpan(7, 0, 0); // 7am
                TimeSpan endTime = new TimeSpan(17, 0, 0); // 5pm

                if (currentTime.TimeOfDay < startTime || currentTime.TimeOfDay > endTime)
                {
                    // Redirect the user to another page or show a message indicating that access is restricted
                    Response.Redirect("library-close.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        protected void img_home_button_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("library-home.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("library-login.aspx");
        }


        //This method toggles the read-only property of several textboxes on and off based on their current state when the "btnEdit" button is clicked.
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            bool isReadOnly = !(txtLastName.ReadOnly && txtFirstName.ReadOnly && txtCourse.ReadOnly && txtYear.ReadOnly && txtMajor.ReadOnly);
            txtLastName.ReadOnly = isReadOnly;
            txtFirstName.ReadOnly = isReadOnly;
            txtCourse.ReadOnly = isReadOnly;
            txtYear.ReadOnly = isReadOnly;
            txtMajor.ReadOnly = isReadOnly;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            // SQL query to select an existing registration with matching Last Name, First Name, Course, School Year and Major
            string query = "SELECT Id_no FROM registration WHERE Last_name = @Last_name AND First_name = @First_name AND Course = @Course AND School_year = @School_year AND Major = @Major";

            // SqlCommand object that executes the SQL query with a SqlConnection object
            SqlCommand cmd = new SqlCommand(query, db_con);
            try
            {
                // SqlParameter objects that are added to the SqlCommand object to pass values to the SQL query
                cmd.Parameters.AddWithValue("@Last_name", txtLastName.Text);
                cmd.Parameters.AddWithValue("@First_name", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@School_year", txtYear.Text);
                cmd.Parameters.AddWithValue("@Major", txtMajor.Text);

                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");

                // Executes the SQL query and returns the first column of the first row in the result set
                object result = cmd.ExecuteScalar();

                // Checks if an existing registration was found and displays the existing account details
                if (result != null)
                {
                    // Code to display existing account details and disable editing of fields
                    int existingId = Convert.ToInt32(result);
                    register_notify.Text = "ACCOUNT EXISTS";
                    register_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    txtId.Text = existingId.ToString();
                    txtPhoto.Text = existingId.ToString();

                    txtId.ReadOnly = true;
                    txtId.Text = existingId.ToString();
                    txtLastName.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtCourse.ReadOnly = true;
                    txtYear.ReadOnly = true;
                    txtMajor.ReadOnly = true;
                    txtPhoto.ReadOnly = true;
                    txtPhoto.Text = existingId.ToString();

                    return;
                }
                else // If no existing registration found, insert a new registration into the database
                {

                    // SQL query to insert a new registration into the database and return the new Id_no value

                    // Reuse the SqlCommand object with a new SQL query and SqlParameter objects
                    cmd.Parameters.Clear();
                    query = "INSERT INTO registration (Last_name, First_name, Course, School_year, Major) VALUES (@Last_name, @First_name, @Course, @School_year, @Major); SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(query, db_con);
                    cmd.Parameters.AddWithValue("@Last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@First_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                    cmd.Parameters.AddWithValue("@School_year", txtYear.Text);
                    cmd.Parameters.AddWithValue("@Major", txtMajor.Text);

                    // Executes the SQL query and returns the new Id_no value
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    // Code to display success message and new account details
                    register_notify.Text = "SUCCESSFULLY REGISTERED";
                    register_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00ff00");

                    txtId.Text = id.ToString();
                    txtPhoto.Text = id.ToString();
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Database Error Occured: " + sqlex);
            }
            finally
            {
                // Disposes of the SqlCommand and SqlConnection objects used
                cmd.Dispose();
                if (db_con.State != System.Data.ConnectionState.Closed)
                {
                    db_con.Close();
                }
                db_con.Dispose();
            }
        }

        // Clear all text fields
        protected void btnClear_Click(object sender, EventArgs e)
        {
            register_notify.Text = "";
            txtId.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtCourse.Text = "";
            txtYear.Text = "";
            txtMajor.Text = "";
            txtPhoto.Text = "";
        }

        protected void imgbtnhome_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("library-home.aspx");
        }

        protected void imgbtnregister_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("library-register.aspx");
        }

        protected void imgbtnlogin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("library-login.aspx");
        }
    }
}