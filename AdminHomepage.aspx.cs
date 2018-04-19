using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHomepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Admins admin = (Admins)Session["Admin"];
        lblWelcome.Visible = true;
        lblWelcome.Text = admin.Name + " " + admin.Surname;
    }



    protected void btnVerify_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerifyDevice.aspx");
    }

    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddTeacher.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}