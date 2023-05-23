using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Login_System.Style.Admin_Styles
{
    public partial class admin_graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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