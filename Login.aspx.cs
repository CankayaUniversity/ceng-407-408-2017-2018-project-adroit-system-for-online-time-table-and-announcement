using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
public partial class Login : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlCommand deneme;
    MySql.Data.MySqlClient.MySqlConnection conndeneme;
    String queryStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Text = Request.Cookies["Email"].Value;
                txtPassword.Text = Request.Cookies["Password"].Value;
            }

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        remember();
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Teachers where Email='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'";
        cmd.ExecuteNonQuery();


        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        da.Fill(dt);
        foreach(DataRow dr in dt.Rows)
        {
            Session["Email"] = dr["Email"].ToString();
            Response.Redirect("TeacherHomepage.aspx");
            
        }
        conn.Close();

        String connStringdeneme = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
        conndeneme = new MySql.Data.MySqlClient.MySqlConnection(connStringdeneme);
        conndeneme.Open();
        deneme = conndeneme.CreateCommand();
        deneme.CommandType = CommandType.Text;
        deneme.CommandText = "select * from Admins where Email='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'";
        deneme.ExecuteNonQuery();
        DataTable dtdeneme = new DataTable();
        MySqlDataAdapter dadeneme = new MySqlDataAdapter(deneme);
        dadeneme.Fill(dtdeneme);
        foreach (DataRow drdeneme in dtdeneme.Rows)
        {
            Session["Email"] = drdeneme["Email"].ToString();
            Response.Redirect("AdminHomepage.aspx");

        }

        conndeneme.Close();

        lblMessage.Visible = true;
        lblMessage.Text = "Wrong Username / Password !";
    }

    void remember()
    {
        if (cbRememberMe.Checked)
        {
            Response.Cookies["Email"].Value = txtUsername.Text;
            Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);

            Response.Cookies["Password"].Value = txtPassword.Text;
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
        }
        else  //If user does not check the remember me button, delete previous cookie
        {
            if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
            {
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}