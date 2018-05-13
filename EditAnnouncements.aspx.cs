using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public partial class EditAnnouncements : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;
    int id;
    int t = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
            cmd = new MySqlCommand("SELECT * FROM Teacher_Ann where IsActive= '" + t + "' and TeacherID= '" + id + "' order by PublishDate", conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                lblmes.Visible = true;
                lblmes.Text = " There is no announcement!";
            }
            grdAnnouncement.DataSource = dt;
            grdAnnouncement.DataBind();
            rd = cmd.ExecuteReader();
            conn.Close();
            
        }
    }

    protected void grdAnnouncement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)grdAnnouncement.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblId");       
        int deleteid = Convert.ToInt32(lbldeleteid.Text);
        int fals = 0;
        int tru = 1;
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("UPDATE Teacher_Ann SET IsActive=@a1 WHERE AnnouncementID=@a2 and IsActive=@a3", conn);
        cmd.Parameters.Add("a1", fals);
        cmd.Parameters.Add("a2", deleteid);
        cmd.Parameters.Add("a3", tru);
        cmd.ExecuteNonQuery();
        conn.Close();
        cmd.Dispose();


        conn.Open();
        cmd = new MySqlCommand("SELECT * FROM Teacher_Ann where IsActive= '" + t + "' and TeacherID= '" + id + "' order by PublishDate", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count == 0)
        {
            lblmes.Visible = true;
            lblmes.Text = " There is no announcement!";
        }
        grdAnnouncement.DataSource = dt;
        grdAnnouncement.DataBind();
        rd = cmd.ExecuteReader();
        conn.Close();
    }



    protected void grdAnnouncement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdAnnouncement.EditIndex = -1;
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT * FROM Teacher_Ann where IsActive= '" + t + "' and TeacherID= '" + id + "' order by PublishDate", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        grdAnnouncement.DataSource = dt;
        grdAnnouncement.DataBind();
        rd = cmd.ExecuteReader();
        conn.Close();
    }

    protected void grdAnnouncement_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdAnnouncement.EditIndex = e.NewEditIndex;
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT * FROM Teacher_Ann where IsActive= '" + t + "' and TeacherID= '" + id + "' order by PublishDate", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        grdAnnouncement.DataSource = dt;
        grdAnnouncement.DataBind();
        rd = cmd.ExecuteReader();
        conn.Close();

    }

    protected void grdAnnouncement_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblid = (Label)grdAnnouncement.Rows[e.RowIndex].FindControl("lblId");


        TextBox content = (TextBox)grdAnnouncement.Rows[e.RowIndex].FindControl("txtContent");
        TextBox pub = (TextBox)grdAnnouncement.Rows[e.RowIndex].FindControl("txtPub");
        TextBox exp = (TextBox)grdAnnouncement.Rows[e.RowIndex].FindControl("txtExp");
        int upid1 = Convert.ToInt32(lblid.Text);

        DateTime tpublish= Convert.ToDateTime(pub.Text);
        DateTime texpire = Convert.ToDateTime(exp.Text);

        int tru = 1;

        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("UPDATE Teacher_Ann SET  AnnContent=@a2 , PublishDate=@a3 , ExpDate=@a4 WHERE AnnouncementID=@a5 and IsActive=@a6", conn);
      
        cmd.Parameters.Add("a2", content.Text);
        cmd.Parameters.Add("a3", tpublish);
        cmd.Parameters.Add("a4", texpire);
        cmd.Parameters.Add("a5", upid1);
        cmd.Parameters.Add("a6", tru);
        cmd.ExecuteNonQuery();
        conn.Close();
        cmd.Dispose();


        conn.Open();
        cmd = new MySqlCommand("SELECT * FROM Teacher_Ann where IsActive= '" + t + "' and TeacherID= '" + id + "' order by PublishDate", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        grdAnnouncement.DataSource = dt;
        grdAnnouncement.DataBind();
        rd = cmd.ExecuteReader();
        conn.Close();
    }  
}