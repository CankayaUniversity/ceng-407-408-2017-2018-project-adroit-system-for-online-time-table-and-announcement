using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
public partial class PublishAnnouncement : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblmessage.Visible = false;
        }

        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT *  FROM Teachers where Email= '" + Session["Email"].ToString() + "' ", conn);
        rd = cmd.ExecuteReader();

        if (rd.Read())
        {

            id = Convert.ToInt32(rd.GetString("TeacherID"));
            conn.Close();
            rd.Close();
        }
        conn.Close();
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {      

        if (txtCont.Text!="" && txtExp.Text!="")
        {
            String connStringf = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connStringf);
            conn.Open();
            string tnow = Convert.ToString(DateTime.Now);
            string publishDate = Convert.ToDateTime(tnow).ToString("yyyy-MM-dd HH:mm:ss");
            
            string CmdText = "INSERT INTO AdroitDatabase.Teacher_Ann(TeacherID,PublishDate,AnnContent,ExpDate,IsActive)VALUES(@TeacherID,@PublishDate, @AnnContent, @ExpDate, @IsActive)";
            MySqlCommand cmd = new MySqlCommand(CmdText, conn);

            cmd.Parameters.AddWithValue("@TeacherID", id);
            cmd.Parameters.AddWithValue("@PublishDate", publishDate);
            cmd.Parameters.AddWithValue("@AnnContent", txtCont.Text);
            cmd.Parameters.AddWithValue("@ExpDate", txtExp.Text);
            cmd.Parameters.AddWithValue("@IsActive", 1);


            cmd.ExecuteNonQuery();
            conn.Close();
            lblmessage.Text = "Announcement is published!";
            lblmessage.Visible = true;
        }
        else
        {
            lblmessage.Text = "Please fill the all boxes!";
            lblmessage.Visible = true;
        }
       

    }
}