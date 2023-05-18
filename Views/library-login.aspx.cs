using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Library_Login_System.Views
{
    public partial class library_login : System.Web.UI.Page
    {

        //Sql Connection
        SqlConnection db_con = new SqlConnection("Data Source=ECCLESIASTES\\SQLEXPRESS;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Call the time
                Update_time();

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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Calls the method to update the time and date
                Update_time();

            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex);
            }
        }

        /*
         Timer1_Tick updates time & date by calling UpdateTime method, which formats the current time using ToString method, and refreshes the labels.
         */

        private void Update_time()
        {
            var now = DateTime.Now; // Get the current date and time

            // Format the time as "hh:mm:ss tt"
            var time = now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);

            // Format the date as "dddd, MMMM dd, yyyy" and convert it to uppercase
            var date = now.ToString("dddd, MMMM dd, yyyy", CultureInfo.InvariantCulture).ToUpper();

            // Convert the first character of the AM/PM portion to uppercase and concatenate it with the remaining characters
            var ampm = time.Substring(time.Length - 2);

            // Replace the AM/PM portion of the time with the modified AM/PM string
            ampm = ampm.ToLowerInvariant().ToUpper()[0] + ampm.ToUpperInvariant().Substring(1);
            time = time.Substring(0, time.Length - 2) + ampm;

            Lbl_current_time.Text = time;
            Lbl_current_date.Text = date;

        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {

            // SQL query to retrieve student information
            string sqlQuery = "SELECT Id_no, Last_name, First_name, Course, School_year, Major FROM registration WHERE Id_no = @Id_no;";

            // SQL query to update time in or insert a new time log entry
            string sqlTimein = "IF EXISTS (SELECT * FROM timelog WHERE Id_no = @Id_no AND Date_log = CONVERT(date, GETDATE())) " +
                   "BEGIN " +
                   "UPDATE timelog SET Time_in = CONVERT(varchar(8), GETDATE(), 108) WHERE Id_no = @Id_no AND Date_log = CONVERT(date, GETDATE()); " +
                   "SELECT Time_in FROM timelog WHERE Id_no = @Id_no AND Date_log = CONVERT(date, GETDATE()) " +
                   "END " +
                   "ELSE " +
                   "BEGIN " +
                   "INSERT INTO timelog (Id_no, Time_in, Date_log) VALUES (@Id_no, CONVERT(varchar(8), GETDATE(), 108), CONVERT(date, GETDATE())); " +
                   "SELECT Time_in FROM timelog WHERE Id_no = @Id_no AND Date_log = CONVERT(date, GETDATE()) " +
                   "END;";

            SqlCommand cmd = new SqlCommand(sqlQuery, db_con);
            cmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            SqlCommand timeincmd = new SqlCommand(sqlTimein, db_con);
            timeincmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            try
            {
                // Open the database connection
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");
                SqlDataReader sqlreader = cmd.ExecuteReader();

                if (sqlreader.Read())
                {
                    Lbl_notify.Text = "ACCESS GRANTED";
                    Lbl_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00ff00");

                    Status_Login_Notify.ImageUrl = "~/Images/Icons/status-login.png";
                    Lbl_status.Text = "LOGGED IN";

                    // Set the image URL based 
                    Img_Login.ImageUrl = "~/Images/Student Images/" + sqlreader["Id_no"].ToString() + ".JPG";
                    Lbl_id_login.Text = sqlreader["Id_no"].ToString();
                    Lbl_name_login.Text = sqlreader["Last_name"].ToString() + " " + sqlreader["First_name"].ToString();
                    Lbl_course_login.Text = sqlreader["Course"].ToString() + " " + sqlreader["Major"].ToString();

                    // Convert the school year value to a displayable format
                    string schoolYear = sqlreader["School_year"].ToString();
                    string yearDisplay;
                    switch (schoolYear)
                    {
                        case "1":
                            yearDisplay = "1st Year";
                            break;
                        case "2":
                            yearDisplay = "2nd Year";
                            break;
                        case "3":
                            yearDisplay = "3rd Year";
                            break;
                        default:
                            yearDisplay = schoolYear + "th Year";
                            break;
                    }

                    Lbl_year_login.Text = yearDisplay;

                    // Close the SqlDataReader
                    sqlreader.Close();

                    // Execute the SQL query to update time in or insert a new time log entry and retrieve the Time_in value
                    object objTimein = timeincmd.ExecuteScalar();


                    if (objTimein != null)
                    {
                        // Set the Time_in label to display the retrieved value
                        Login_timelog_Notify.ImageUrl = "~/Images/Icons/login-timelog.png";
                        Lbl_timein.Text = objTimein.ToString();
                    }
                }
                else
                {
                    Lbl_notify.Text = "STUDENT NOT FOUND";
                    Lbl_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");

                    // Close the SqlDataReader
                    sqlreader.Close();
                }

                // Close the database connection
                db_con.Close();
            }
            catch (SqlException sqlex)
            {
                Response.Write("Database Error Occured: " + sqlex);
            }
            finally
            {

                // Dispose the SqlCommand
                cmd.Dispose();

                if (db_con.State != System.Data.ConnectionState.Closed)
                {
                    db_con.Close(); // Close the database connection if it is still open
                }
                db_con.Dispose(); // Dispose the SqlConnection
            }
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            // Check if a time-in entry exists for the current date
            string sqlCheckTimeIn = "SELECT Time_in FROM timelog WHERE Id_no = @Id_no AND Date_log = CONVERT(date, GETDATE());";

            // Update the time-out value for the current date
            string sqlUpdateTimeout = "UPDATE timelog SET Time_out = CONVERT(varchar(8), GETDATE(), 108) WHERE Id_no = @Id_no AND Date_log = CONVERT(date, GETDATE());";

            // Insert a new time log entry with time-in and time-out values
            string sqlInsertTimeLog = "INSERT INTO timelog (Id_no, Time_in, Time_out, Date_log) VALUES (@Id_no, CONVERT(varchar(8), GETDATE(), 108), CONVERT(varchar(8), GETDATE(), 108), CONVERT(date, GETDATE()));";

            // Parameterize the Id_no value 
            SqlCommand checkTimeInCmd = new SqlCommand(sqlCheckTimeIn, db_con);
            checkTimeInCmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            SqlCommand updateTimeoutCmd = new SqlCommand(sqlUpdateTimeout, db_con);
            updateTimeoutCmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            SqlCommand insertTimeLogCmd = new SqlCommand(sqlInsertTimeLog, db_con);
            insertTimeLogCmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            try
            {
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");

                SqlDataReader timeInReader = checkTimeInCmd.ExecuteReader();

                if (timeInReader.Read())
                {
                    string timeIn = timeInReader["Time_in"].ToString();
                    timeInReader.Close();

                    string sqlQuery = "SELECT Id_no, Last_name, First_name, Course, School_year, Major FROM registration WHERE Id_no = @Id_no;";

                    // SqlCommand to insert new time log entry
                    SqlCommand cmd = new SqlCommand(sqlQuery, db_con);

                    // Parameterize the Id_no value
                    cmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

                    SqlDataReader sqlreader = cmd.ExecuteReader();

                    if (sqlreader.Read())
                    {
                        // If a time-in entry exists
                        Status_Logout_Notify.ImageUrl = "~/Images/Icons/status-logout.png";
                        Lbl_notify.Text = "SIGNING OUT";
                        Lbl_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");

                        Lbl_recent_status.Text = "LOGGED OUT";
                        Img_Logout.ImageUrl = "~/Images/Student Images/" + sqlreader["Id_no"].ToString() + ".JPG";
                        Lbl_recent_id.Text = sqlreader["Id_no"].ToString();
                        Lbl_recent_name.Text = sqlreader["Last_name"].ToString() + " " + sqlreader["First_name"].ToString();
                        Lbl_recent_course.Text = sqlreader["Course"].ToString() + " " + sqlreader["Major"].ToString();
                        string schoolYear = sqlreader["School_year"].ToString();
                        string yearDisplay;
                        switch (schoolYear)
                        {
                            case "1":
                                yearDisplay = "1st Year";
                                break;
                            case "2":
                                yearDisplay = "2nd Year";
                                break;
                            case "3":
                                yearDisplay = "3rd Year";
                                break;
                            default:
                                yearDisplay = schoolYear + "th Year";
                                break;
                        }
                        Lbl_recent_year.Text = yearDisplay;
                        sqlreader.Close();

                        updateTimeoutCmd.ExecuteNonQuery();
                        Logout_timelog_Notify.ImageUrl = "~/Images/Icons/logout-recent-timelog.png";
                        Lbl_timeout.Text = DateTime.Now.ToString("HH:mm:ss");
                    }
                    else
                    {
                        Lbl_notify.Text = "ACCESS DENIED";
                        Lbl_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");

                        // Insert a new row in timelog for the logged out user
                        insertTimeLogCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    Lbl_notify.Text = "ACCESS DENIED";
                    Lbl_notify.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Database Error Occured: " + sqlex);
            }
            finally
            {
                checkTimeInCmd.Dispose();
                updateTimeoutCmd.Dispose();
                insertTimeLogCmd.Dispose();

                if (db_con.State != System.Data.ConnectionState.Closed)
                {
                    db_con.Close();
                }
                db_con.Dispose();
            }
        }

        protected void Btn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("library-register.aspx");
        }

        protected void Btn_exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("library-home.aspx");
        }
    }
}