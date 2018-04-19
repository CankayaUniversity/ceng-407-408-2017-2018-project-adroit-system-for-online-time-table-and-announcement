using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;

public partial class SentMail : System.Web.UI.Page
{
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
                         where x.TeacherID == teacher.TeacherID && x.IsActive == true && x.SenderName == t.Email && x.Draft != true

                         select new
                         {
                             
                             x.MessageContent,
                             x.TimeSent,
                             x.ReceiverName,
                             x.MessageID


                         }).ToList();


            grdEmail.DataSource = query;
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

            
        }Response.Redirect(Request.RawUrl);
    }

}
