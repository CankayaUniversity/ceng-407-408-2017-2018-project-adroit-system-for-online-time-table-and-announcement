using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
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
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers t;
        Admins a;
        LoginService ls = new LoginService();
        string email = txtUsername.Text.Trim();
        string password = txtPassword.Text;


        t = ls.readDataTeacher(email, password);

        a = ls.readDataAdmin(email, password);

        remember();

        if (t != null)
        {
            Session["Teachers"] = t;
            if (t.IsActive == false)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Correct username and password, but not active!";
            }
            else
            {
                lblMessage.Visible = true;
                Response.Redirect("TeacherHomepage.aspx");
            }

        }

        else if (a != null)
        {
            Session["Admin"] = a;
            lblMessage.Visible = true;
            lblMessage.Text = "Welcome! " + a.Name + " " + a.Surname;
            Response.Redirect("AdminHomepage.aspx");
        }
        else
        {

            lblMessage.Visible = true;
            lblMessage.Text = "Wrong Username / Password !";
        }

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