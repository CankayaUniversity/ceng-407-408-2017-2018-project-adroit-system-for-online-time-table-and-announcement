using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
public partial class SentMail : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;
    String Dt;
    int id; //teacher id
    int t = 1; //true value
    string TID; //teacherId
    string TEmail; //teacherEmail

    protected void Page_Load(object sender, EventArgs e)
    {
        btnDelete.Visible = false;
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT *  FROM Teachers where Email= '" + Session["Email"].ToString() + "' ", conn);
        rd = cmd.ExecuteReader();

        if (rd.Read())
        {

            id = Convert.ToInt32(rd.GetString("TeacherID"));
            rd.Close();
        }
        conn.Close();

        if (!IsPostBack)
        {
           
            conn.Open();
            cmd = new MySqlCommand("SELECT MessageContent,TimeSent,MessageID,ReceiverName FROM Messages where IsActive= '" + t + "' and TeacherID= '" + id + "' and SenderName= '" + Session["Email"] + "' ORDER BY TimeSent DESC", conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                btnDelete.Visible = true;
            }
            else
            {
                lblmes.Visible = true;
                lblmes.Text = "There is no Email!";
            }
            grdEmail.DataSource = dt;
            grdEmail.DataBind();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdEmail.Rows.Count; i++)
        {
            GridViewRow row = (GridViewRow)grdEmail.Rows[i];
            Label lblid = (Label)row.FindControl("lblId");
            int id1 = Convert.ToInt32(lblid.Text);
            CheckBox cbRequest = (CheckBox)row.FindControl("cbDelete");

            if (cbRequest != null && cbRequest.Checked)
            {
                int fals = 0;
                int tru = 1;
                string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
                conn = new MySqlConnection(constr);
                conn.Open();
                cmd = new MySqlCommand("UPDATE Messages SET IsActive=@a1 WHERE MessageID=@a2 and IsActive=@a3", conn);
                cmd.Parameters.Add("a1", fals);
                cmd.Parameters.Add("a2", id1);
                cmd.Parameters.Add("a3", tru);
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
            }

        }
        Response.Redirect(Request.RawUrl);
    }

}
