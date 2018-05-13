using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public partial class TeacherHomepage : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"]==null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
            conn = new MySqlConnection(constr);
            conn.Open();
            cmd = new MySqlCommand("SELECT *  FROM Teachers where Email= '" + Session["Email"].ToString() + "' ", conn) ;           
            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                lblWelcome.Text = rd.GetString("Name") + " " + rd.GetString("Surname");
                conn.Close();
                rd.Close();
            }   
                     
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx");
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