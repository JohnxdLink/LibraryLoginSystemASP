using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Login_System.Views
{
    public partial class Library_close : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
    
        }
    }
}