using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;

public partial class CheckEmail : System.Web.UI.Page
{
    public int flag = 1;
        
    protected void Page_Load(object sender, EventArgs e)
    {
        
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];
        //ServiceReferenceDersler.Service1Soap DERSLER = new ServiceReferenceDersler.Service1SoapClient();
        
        //DERSLER.XML_3_OBS.
        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();
        if (!IsPostBack)
        {
            var query = (from x in db.Messages
                         where x.TeacherID == teacher.TeacherID && x.IsActive==true && x.SenderName!=t.Email && x.Draft!=true
                       
                         select new
                         {
                             x.SenderName,
                             x.MessageContent,
                             x.TimeSent,
                             x.ReceiverName,
                             x.MessageID


                         }).ToList();

            grdEmail.Columns[1].Visible = true;
            grdEmail.Columns[2].Visible = false;
            grdEmail.Columns[4].Visible = true;
            grdEmail.DataSource = query;
            grdEmail.DataBind();

            if (query.Count==0)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
            }
            
        }
        

    }
    protected void Inbox(object sender, EventArgs e)
    {
        
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
                             x.ReceiverName,
                             x.MessageID


                         }).ToList();
        grdEmail.Columns[1].Visible = true;
        grdEmail.Columns[2].Visible = false;
        grdEmail.Columns[4].Visible = true;
        grdEmail.DataSource = query;
        grdEmail.DataBind();

        if (query.Count == 0)
        {
            btnDelete.Visible = false;
        }
        else
        {
            btnDelete.Visible = true;
        }
    
    }
    protected void SentMail(object sender, EventArgs e)
    {
        
            AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
            Teachers teacher = (Teachers)Session["Teachers"];
        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();


        var query = (from x in db.Messages
                         where x.TeacherID == teacher.TeacherID && x.IsActive == true && x.SenderName == t.Email && x.Draft != true

                         select new
                         {
                             x.SenderName,
                             x.MessageContent,
                             x.TimeSent,
                             x.ReceiverName,
                             x.MessageID


                         }).ToList();

        grdEmail.Columns[1].Visible = false;
        grdEmail.Columns[2].Visible = true;
        grdEmail.Columns[4].Visible = true;
        grdEmail.DataSource = query;
        grdEmail.DataBind();
        if (query.Count == 0)
        {
            btnDelete.Visible = false;
        }
        else
        {
            btnDelete.Visible = true;
        }
        flag = 2;
    }
 
    protected void Trash(object sender, EventArgs e)
    {
        
            AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
            Teachers teacher = (Teachers)Session["Teachers"];
        
            var query = (from x in db.Messages                        
                         where x.TeacherID == teacher.TeacherID && x.IsActive == false 

                         select new
                         {
                             x.SenderName,
                             x.MessageContent,
                             x.TimeSent,
                             x.ReceiverName,
                             x.MessageID

                         }).ToList();

        grdEmail.Columns[1].Visible = true;
        grdEmail.Columns[2].Visible = true;
        grdEmail.Columns[4].Visible = false;
        grdEmail.DataSource = query;
        grdEmail.DataBind();
       
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
                               where x.MessageID == id1 && x.IsActive==true
                               select x).SingleOrDefault();
                if (m1!=null)
                {
                    m1.IsActive = false;
                    db.SaveChanges();
                }
            
            }
            if (flag == 1)
            {
                Response.Redirect(Request.RawUrl);
            }
            else if (flag == 2)
            {
                Teachers t = (from x in db.Teachers
                              where x.TeacherID == teacher.TeacherID
                              select x).SingleOrDefault();


                var query = (from x in db.Messages
                             where x.TeacherID == teacher.TeacherID && x.IsActive == true && x.SenderName == t.Email && x.Draft != true

                             select new
                             {
                                 x.SenderName,
                                 x.MessageContent,
                                 x.TimeSent,
                                 x.ReceiverName,
                                 x.MessageID


                             }).ToList();

                grdEmail.Columns[1].Visible = false;
                grdEmail.Columns[2].Visible = true;
                grdEmail.Columns[4].Visible = true;
                grdEmail.DataSource = query;
                grdEmail.DataBind();
                if (query.Count == 0)
                {
                    btnDelete.Visible = false;
                }
                else
                {
                    btnDelete.Visible = true;
                }
                flag = 2;
            }
            else if (flag == 3)
            {

                var query = (from x in db.Messages
                             where x.TeacherID == teacher.TeacherID && x.IsActive == false

                             select new
                             {
                                 x.SenderName,
                                 x.MessageContent,
                                 x.TimeSent,
                                 x.ReceiverName,
                                 x.MessageID

                             }).ToList();

                grdEmail.Columns[1].Visible = true;
                grdEmail.Columns[2].Visible = true;
                grdEmail.Columns[4].Visible = false;
                grdEmail.DataSource = query;
                grdEmail.DataBind();
                flag = 3;
            }
        }
    }
        

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        MailMessage mail = new MailMessage();
        mail.To.Add("c1311037@student.cankaya.edu.tr");
        mail.From = new MailAddress("c1311006@student.cankaya.edu.tr");
        mail.Subject = "arifceylan.com üzerinden... Adı: ";
        mail.Body =  "&lt;br/&gt;&lt;b&gt;Gönderenin epostası:&lt;/b&gt;";
        mail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("student.cankaya.edu.tr", 587);
        NetworkCredential credentials = new NetworkCredential("c1311006@student.cankaya.edu.tr", "Timur1995");
        client.Credentials = credentials;

        try

        {

            client.Send(mail);

            Response.Write("Mesaj gönderildi. Teşekkür ederiz");
        

        }

        catch (Exception hata)

        {

            Response.Write(hata);  //hata ayıklama ile hata olduğunda hata mesajı yazdırılacak.

        }
    }
}