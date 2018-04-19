using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;


public partial class Inbox : System.Web.UI.Page
{public static string receiver;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];
        lblmessage.Visible = false;
        //ServiceReferenceDersler.Service1Soap DERSLER = new ServiceReferenceDersler.Service1SoapClient();

        //DERSLER.XML_3_OBS.
        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();
        if (!IsPostBack)
        {
            var query = (from x in db.Messages
                         where x.TeacherID == teacher.TeacherID && x.IsActive == true && x.SenderName != t.Email && x.Draft != true

                         select new
                         {
                             x.SenderName,
                             x.MessageContent,
                             x.TimeSent,
                             x.MessageID


                         }).ToList();

            var SortedList = query.OrderBy(o => o.TimeSent).ToList();

            grdEmail.DataSource = SortedList;
            grdEmail.DataBind();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

        for (int i = 0; i < grdEmail.Rows.Count; i++)
        {
            GridViewRow row = (GridViewRow)grdEmail.Rows[i];
            Label lblid = (Label)row.FindControl("lblId");
            int id1 = Convert.ToInt32(lblid.Text);
            CheckBox cbRequest = (CheckBox)row.FindControl("cbDelete");
           
            if (cbRequest != null && cbRequest.Checked)
            {
                Messages m1 = (from x in db.Messages
                               where x.MessageID == id1 && x.IsActive == true
                               select x).SingleOrDefault();
                if (m1 != null)
                {
                    m1.IsActive = false;
                    db.SaveChanges();
                }

            }

           
        } Response.Redirect(Request.RawUrl);
    }

    protected void grdEmail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdEmail.EditIndex = -1;
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();
        var query = (from x in db.Messages
                     where x.TeacherID == teacher.TeacherID && x.IsActive == true && x.SenderName != t.Email && x.Draft != true

                     select new
                     {
                         x.SenderName,
                         x.MessageContent,
                         x.TimeSent,
                         x.MessageID


                     }).ToList();


        grdEmail.DataSource = query;
        grdEmail.DataBind();
        txtMail.Visible = false;
        btnSendEmail.Visible = false;
        txtReceiver.Visible = false;
        txtSubject.Visible = false;
        lblsubject.Visible = false;
        lblmsg.Visible = false;
    }

    protected void grdEmail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdEmail.EditIndex = e.NewEditIndex;
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();
        var query = (from x in db.Messages
                     where x.TeacherID == teacher.TeacherID && x.IsActive == true && x.SenderName != t.Email && x.Draft != true

                     select new
                     {
                         x.SenderName,
                         x.MessageContent,
                         x.TimeSent,
                         x.MessageID


                     }).ToList();


        grdEmail.DataSource = query;
        grdEmail.DataBind();

    }

    protected void grdEmail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        GridViewRow row = (GridViewRow)grdEmail.Rows[e.RowIndex];
        Label lblid = (Label)row.FindControl("lblId");
        int id1 = Convert.ToInt32(lblid.Text);
        Messages m1 = (from x in db.Messages
                       where x.MessageID == id1 && x.IsActive == true
                       select x).SingleOrDefault();


        txtMail.Visible = true;
        btnSendEmail.Visible = true;
        txtReceiver.Visible = true;
        lblmsg.Visible = true;
        txtSubject.Visible = true;
        lblsubject.Visible = true;
        receiver = m1.SenderName;
        txtReceiver.Text = receiver;
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        string subject = txtSubject.Text;
        string body = txtMail.Text;
        SmtpClient sc = new SmtpClient();
        sc.Port = 587;
        sc.Host = "smtp.gmail.com"; //smtp 
        sc.EnableSsl = true;

        sc.Credentials = new NetworkCredential("nzlks95@gmail.com", "nk290795@");

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("nzlks95@gmail.com", "Nazlı");
        
        mail.To.Add(receiver);
        mail.CC.Add("nzlks95@gmail.com");

        mail.CC.Add("c1311030@student.cankaya.edu.tr");

        mail.CC.Add("c1411031@student.cankaya.edu.tr");

        mail.CC.Add("c1311006@student.cankaya.edu.tr");

        mail.Subject = subject;
        mail.IsBodyHtml = true;
        mail.Body = body;

        if (body!="")
        {
            sc.Send(mail);
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