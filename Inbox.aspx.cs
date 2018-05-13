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
using System.IO;

public partial class Inbox : System.Web.UI.Page
{
    int messageid;
    public static string receiver;
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;
    MySql.Data.MySqlClient.MySqlConnection imageconn;
    MySql.Data.MySqlClient.MySqlCommand imagecmd;
    MySql.Data.MySqlClient.MySqlDataReader imagerd;

    MySql.Data.MySqlClient.MySqlConnection urlconn;
    MySql.Data.MySqlClient.MySqlCommand urlcmd;
    MySql.Data.MySqlClient.MySqlDataReader urlrd;
   
    String imagequeryStr;
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
            int idd = 1;
            string imageconstr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
            imageconn = new MySqlConnection(imageconstr);
            imageconn.Open();
            imagecmd = new MySqlCommand("SELECT * FROM Messages WHERE IsActive= '" + idd + "' and TeacherID='"+ TID +"' ", imageconn);
            MySqlDataAdapter imagesda = new MySqlDataAdapter(imagecmd);
            imagerd = imagecmd.ExecuteReader();

            while (imagerd.Read())
            {
                int row = Convert.ToInt32(imagerd["MessageID"].ToString());
                if (imagerd["Image"] != DBNull.Value)
                {
                    byte[] imgg = (byte[])(imagerd["Image"]);
                    if (imgg != null)
                    {

                        MemoryStream mstream = new MemoryStream(imgg);
                        string url = "data:image/jpeg;base64," + Convert.ToBase64String(imgg);

                        string urlconstr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
                        urlconn = new MySqlConnection(urlconstr);
                        urlconn.Open();
                        urlcmd = new MySqlCommand("UPDATE Messages SET PhotoUrl=@a1 WHERE MessageID=@a2", urlconn);
                        urlcmd.Parameters.Add("a1", url);
                        urlcmd.Parameters.Add("a2", row);

                        urlcmd.ExecuteNonQuery();
                        urlconn.Close();
                        urlcmd.Dispose();

                    }
                }
            }
            imageconn.Close();

            lblmessage.Visible = false;
            conn.Open();
            cmd = new MySqlCommand("SELECT SenderName,MessageContent,TimeSent,MessageID,PhotoUrl FROM Messages where IsActive= '" + t + "' and TeacherID= '" + id + "' and SenderName!= '" + Session["Email"] + "' ORDER BY TimeSent DESC", conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count!=0)
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

    protected void grdEmail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdEmail.EditIndex = -1;
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT SenderName,MessageContent,TimeSent,MessageID,PhotoUrl FROM Messages where IsActive= '" + t + "' and TeacherID= '" + id + "' and SenderName!= '" + Session["Email"] + "' ORDER BY TimeSent DESC ", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        grdEmail.DataSource = dt;
        grdEmail.DataBind();
        cmd.ExecuteNonQuery();
        conn.Close();
        cmd.Dispose();
        txtMail.Visible = false;
        btnSendEmail.Visible = false;
        txtReceiver.Visible = false;
        txtSubject.Visible = false;
        lblsubject.Visible = false;
        lblmsg.Visible = false;
        lblmessage.Visible = false;
    }

    protected void grdEmail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdEmail.EditIndex = e.NewEditIndex;
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT SenderName,MessageContent,TimeSent,MessageID,PhotoUrl FROM Messages where IsActive= '" + t + "' and TeacherID= '" + id + "' and SenderName!= '" + Session["Email"] + "' ORDER BY TimeSent DESC", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        grdEmail.DataSource = dt;
        grdEmail.DataBind();
        cmd.ExecuteNonQuery();
        conn.Close();
        cmd.Dispose();

    }

    protected void grdEmail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = (GridViewRow)grdEmail.Rows[e.RowIndex];
        Label lblid = (Label)row.FindControl("lblId");
        int id1 = Convert.ToInt32(lblid.Text);

        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT SenderName,MessageContent,TimeSent,MessageID,PhotoUrl FROM Messages where IsActive= '" + t + "' and MessageID= '" + id1 + "' ORDER BY TimeSent DESC", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            txtMail.Visible = true;
            btnSendEmail.Visible = true;
            txtReceiver.Visible = true;
            lblmsg.Visible = true;
            txtSubject.Visible = true;
            lblsubject.Visible = true;
            receiver = dr["SenderName"].ToString();
            txtReceiver.Text = receiver;
            
       }
        conn.Close();
        cmd.Dispose();

    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
       
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT *  FROM Teachers where Email= '" + Session["Email"].ToString() + "' ", conn);
        rd = cmd.ExecuteReader();

        if (rd.Read())
        {
            TID = rd.GetString("TeacherID");
            TEmail = rd.GetString("Email");         
            conn.Close();
            cmd.Dispose();
            rd.Close();
        }
        string subject = txtSubject.Text;
        string body = txtMail.Text;
   
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        SmtpClient sc = new SmtpClient();
        sc.Port = 587;
        //sc.Host = "student.cankaya.edu.tr";
        sc.Host = "smtp.gmail.com"; //smtp 
        sc.EnableSsl = true;
        sc.UseDefaultCredentials = false;
        //sc.Credentials = new NetworkCredential("c1311037@student.cankaya.edu.tr", "sifre");

        //mail.From = new MailAddress("c1311037@student.cankaya.edu.tr","Nazlı");

        sc.Credentials = new NetworkCredential("naztim2111@gmail.com", "sifre");

        mail.From = new MailAddress("naztim2111@gmail.com", "Nazlı");
        mail.To.Add(receiver);
        mail.CC.Add("nzlks95@gmail.com");

        mail.CC.Add("c1311030@student.cankaya.edu.tr");

        mail.CC.Add("c1411031@student.cankaya.edu.tr");

        mail.CC.Add("c1311006@student.cankaya.edu.tr");

        mail.Subject = subject;
      
        mail.Body = body;

        if (body!="")
        {
          
            sc.Send(mail);
            mail.Dispose();

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
   
            string CmdText = "INSERT INTO Messages(SenderName,TeacherID,MessageContent,TimeSent,ReceiverName,IsActive,PhotoUrl)VALUES(@SenderName,@TeacherID, @MessageContent, @TimeSent, @ReceiverName,1, @PhotoUrl)";
            cmd = new MySqlCommand(CmdText, conn);

            cmd.Parameters.AddWithValue("@SenderName", TEmail);
            cmd.Parameters.AddWithValue("@TeacherID", TID);
            cmd.Parameters.AddWithValue("@MessageContent", body);
            cmd.Parameters.AddWithValue("@ReceiverName", receiver);
            cmd.Parameters.AddWithValue("@PhotoUrl", "sss");
            cmd.Parameters.AddWithValue("@TimeSent", DateTime.Now);

            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            lblmessage.Text = "The Message Was Sent!";
            txtReceiver.Text = " ";
            txtSubject.Text = " ";
            txtMail.Text = " ";
            lblmessage.Visible = true;    
                   
        }
        else
        {
            lblmessage.Visible = true;
            lblmessage.Text = "The Message Could Not Be Sent! Please Try Again!";
        }
        
    }

}