using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Login_System.Views.Admins
{
    public partial class admin_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Calls the method to update the time and date
                Update_time();
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
            // Implement your logic to determine if the system is online.
            // You can check connectivity or any other criteria specific to your system.
            // For demonstration purposes, let's assume the system is always online.
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