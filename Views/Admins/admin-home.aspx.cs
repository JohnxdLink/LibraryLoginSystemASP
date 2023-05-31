using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace Library_Login_System.Views.Admins
{
    public partial class admin_home : System.Web.UI.Page
    {

        //Sql Connection
        SqlConnection db_con = new SqlConnection("Data Source=ECCLESIASTES\\SQLEXPRESS;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Calls the method to update the time and date, tmelog in & out, registered count and monthly
                Update_time();
                Updated_user_Timelogin();
                Updated_user_Timelogout();
                Registered_count();
                Monthly_count();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        // This method is executed periodically and performs various tasks related to updating time, user timelogin, user timelogout, registered count, and monthly count.
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Calls the method to update the time and date
                Update_time();
                Updated_user_Timelogin();
                Updated_user_Timelogout();
                Registered_count();
                Monthly_count();
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex);
            }
        }

        private void Update_time()
        {
            var now = DateTime.Now;
            var time = now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            var date = now.ToString("dddd, MMMM dd, yyyy", CultureInfo.InvariantCulture).ToUpper();
            var ampm = time.Substring(time.Length - 2);
            ampm = ampm.ToLowerInvariant().ToUpper()[0] + ampm.ToUpperInvariant().Substring(1);
            time = time.Substring(0, time.Length - 2) + ampm;

            Lbl_current_time.Text = time;
            Lbl_current_date.Text = date;

            bool isOnline = IsSystemOnline(now);

            // Enable/disable the login and register buttons based on the time
            if (isOnline && IsWithinWorkingHours(now))
            {
                Lbl_library_status.Text = "SYSTEM ONLINE";
                Lbl_library_status.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00ff00");
            }
            else
            {
                Lbl_library_status.Text = "SYSTEM OFFLINE";
                Lbl_library_status.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            }
        }

        private bool IsSystemOnline(DateTime now)
        {

            return true;
        }

        private bool IsWithinWorkingHours(DateTime now)
        {
            // Define the working hours (7am to 5pm)
            TimeSpan startWorkingHours = new TimeSpan(7, 0, 0);
            TimeSpan endWorkingHours = new TimeSpan(17, 0, 0);

            // Check if the current time is within the working hours
            TimeSpan currentTime = now.TimeOfDay;
            return currentTime >= startWorkingHours && currentTime <= endWorkingHours;
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin-home.aspx");
        }

        protected void Img_browse_id_Click(object sender, ImageClickEventArgs e)
        {
            // SQL query to retrieve student information
            string sqlQuery = "SELECT Id_no, Last_name, First_name, Course, School_year, Major FROM registration WHERE Id_no = @Id_no;";

            // Execute the query to get the count of Time_out entries for the given Id_no
            string sqltimelogid = "SELECT COUNT(Time_out) FROM timelog WHERE Id_no = @Id_no";

            // Execute the query to retrieve Timelog_id, Time_in, and Time_out for the given Id_no
            string sqlshowtbl = "SELECT Timelog_id, Time_in, Time_out FROM timelog WHERE Id_no = @Id_no";

            SqlCommand cmd = new SqlCommand(sqlQuery, db_con);
            cmd.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            SqlCommand sqltimelog = new SqlCommand(sqltimelogid, db_con);
            sqltimelog.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            SqlCommand sqltable = new SqlCommand(sqlshowtbl, db_con);
            sqltable.Parameters.Add("@Id_no", SqlDbType.NVarChar, 50).Value = Txb_search_id.Text;

            try
            {
                // Open the database connection
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");
                SqlDataReader sqlreader = cmd.ExecuteReader();

                if (sqlreader.Read())
                {
                    Img_student.ImageUrl = "~/Images/Student Images/" + sqlreader["Id_no"].ToString() + ".JPG";

                    Lbl_std_id.Text = sqlreader["Id_no"].ToString();
                    Lbl_std_id.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f5d7db");
                    Lbl_std_name.Text = sqlreader["Last_name"].ToString() + " " + sqlreader["First_name"].ToString();
                    Lbl_std_course.Text = sqlreader["Course"].ToString();

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

                    Lbl_std_year.Text = yearDisplay;

                    Lbl_std_major.Text = sqlreader["Major"].ToString();

                    Lbl_last_name.Text = sqlreader["Last_name"].ToString() + " TIMELOG";

                    // Close the SqlDataReader
                    sqlreader.Close();

                    object usertimelog = sqltimelog.ExecuteScalar();

                    if (usertimelog != null)
                    {
                        Timelog_icon_dsply.ImageUrl = "~/Images/Icons/timelog.png";

                        int count = Convert.ToInt32(usertimelog);
                        Lbl_std_timelog.Text = count.ToString();
                    }

                    sqltimelog.Dispose();

                    // Initialize a SqlDataReader variable to store the query results
                    SqlDataReader dt_reader = null;

                    try
                    {
                        // Execute the query and store the results in the SqlDataReader
                        dt_reader = sqltable.ExecuteReader();

                        // Initialize a DataTable to store the query results
                        DataTable dataTable = new DataTable();

                        // Load the data from the SqlDataReader into the DataTable
                        dataTable.Load(dt_reader);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Access the data in each row
                            string timeIn = row["Time_in"].ToString();
                            string timeOut = row["Time_out"].ToString();
                        }
                   
                        // Set the DataTable as the data source for the GridView
                        GridView1.DataSource = dataTable;

                        // Bind the DataTable to the GridView for displaying the data
                        GridView1.DataBind();
                    }
                    finally
                    {
                        // Close the SqlDataReader and SqlConnection in the finally block
                        if (dt_reader != null)
                        {
                            dt_reader.Close();
                        }

                        if (db_con.State != ConnectionState.Closed)
                        {
                            db_con.Close();
                        }
                    }

                }
                else
                {
                    Lbl_std_id.Text = "STUDENT DOES NOT EXISTS";
                    Lbl_std_id.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");

                    Lbl_std_name.Text = "";
                    Lbl_std_course.Text = "";
                    Lbl_std_year.Text = "";
                    Lbl_std_major.Text = "";

                    Lbl_std_timelog.Text = "";

                    sqlreader.Close();

                }

                // Close the database connection
                db_con.Close();

            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex);
            }

            finally
            {
                // Dispose the SqlCommand
                cmd.Dispose();
                sqltimelog.Dispose();

                if (db_con.State != System.Data.ConnectionState.Closed)
                {
                    db_con.Close(); // Close the database connection if it is still open
                }
                db_con.Dispose(); // Dispose the SqlConnection
            }
        }

        protected void Updated_user_Timelogin()
        {
            string sqlLatestTimelog = "SELECT TOP 1 Id_no, Time_in FROM timelog ORDER BY Timelog_id DESC";

            SqlCommand cmdtimelog = null;
            SqlDataReader dataReader = null;

            try
            {
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");

                cmdtimelog = new SqlCommand(sqlLatestTimelog, db_con);

                dataReader = cmdtimelog.ExecuteReader();

                if (dataReader.Read())
                {
                    Img_view_id_login.ImageUrl = "~/Images/Student Images/" + dataReader["Id_no"].ToString() + ".JPG";
                    Lbl_view_id_login.Text = dataReader["Id_no"].ToString();
                    Lbl_view_status_login.Text = "LOGGED IN";
                    Lbl_view_status_login.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00ff00");
                    Lbl_check_login.ImageUrl = "~/Images/Icons/status-login.png";
                }

                dataReader.Close();

                db_con.Close();
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex);
            }
            finally
            {
                // Ensure resources are properly closed and disposed
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }

                if (cmdtimelog != null)
                {
                    cmdtimelog.Dispose();
                }

                if (db_con != null && db_con.State != ConnectionState.Closed)
                {
                    db_con.Close();
                    db_con.Dispose();
                }
            }
        }

        protected void Updated_user_Timelogout()
        {
            string sqlLatestTimelog = "SELECT TOP 1 Id_no, Time_in, Time_out FROM timelog WHERE Time_out IS NOT NULL ORDER BY Timelog_id DESC";

            SqlCommand cmdtimelog = null;
            SqlDataReader dataReader = null;

            try
            {
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");

                cmdtimelog = new SqlCommand(sqlLatestTimelog, db_con);

                dataReader = cmdtimelog.ExecuteReader();

                if (dataReader.Read())
                {
                    // User has already logged out
                    Img_view_id_logout.ImageUrl = "~/Images/Student Images/" + dataReader["Id_no"].ToString() + ".JPG";
                    Lbl_view_id_logout.Text = dataReader["Id_no"].ToString();
                    Lbl_view_status_logout.Text = "LOGGED OUT";
                    Lbl_view_status_logout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    Lbl_check_logout.ImageUrl = "~/Images/Icons/status-logout.png";
                }

                dataReader.Close();
                db_con.Close();
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex);
            }
            finally
            {
                // Ensure resources are properly closed and disposed
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }

                if (cmdtimelog != null)
                {
                    cmdtimelog.Dispose();
                }

                if (db_con != null && db_con.State != ConnectionState.Closed)
                {
                    db_con.Close();
                    db_con.Dispose();
                }
            }
        }

        protected void Registered_count()
        {
            // SQL query to count the number of rows in the "registration" table
            string sqlcount = "SELECT COUNT(*) FROM registration";

            SqlCommand cmdcount = new SqlCommand(sqlcount, db_con);

            try
            {
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");

                // Execute the query and retrieve the count as a scalar value
                int count = (int)cmdcount.ExecuteScalar();

                // Convert the count to a string and display it in the "Lbl_num_registered" label
                Lbl_num_registered.Text = count.ToString();
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex);
            }

            db_con.Close();
        }

        protected void Monthly_count()
        {
            // Get the current date and time
            DateTime currentDate = DateTime.Now;

            // Get the current month as an integer
            int currentMonth = currentDate.Month;

            // Convert the current month to a string.
            string nummonth = currentMonth.ToString();

            // SQL query to count the number of rows in the "timelog" table for the current month
            string sqlcount = "SELECT COUNT(*) FROM timelog WHERE MONTH(Date_log) = " + nummonth + ";";

            SqlCommand cmdcount = new SqlCommand(sqlcount, db_con);

            try
            {
                db_con.Open();
                db_con.ChangeDatabase("Library_Login_Db");

                // Execute the query and retrieve the count as a scalar value
                int count = (int)cmdcount.ExecuteScalar();

                // Convert the count to a string and display it in the "Lbl_num_timelog" label
                Lbl_num_timelog.Text = count.ToString();
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex);
            }

            db_con.Close();
        }


        protected void btn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin-register.aspx");
        }

        protected void btn_timelog_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin-timelog.aspx");
        }

        protected void btn_graph_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin-graph.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/library-home.aspx");
        }


    }
}