using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeacherHomepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];
        lblWelcome.Visible = true;
        lblWelcome.Text = teacher.Name + " " + teacher.Surname;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditTimetable.aspx");
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllAnnouncements.aspx");
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inbox.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}