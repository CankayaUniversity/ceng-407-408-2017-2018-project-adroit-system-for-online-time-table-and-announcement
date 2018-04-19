using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PublishAnnouncement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {

        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

     
        Teacher_Ann newAnnouncement = new Teacher_Ann();
        newAnnouncement.AnnContent = txtCont.Text;
        newAnnouncement.PublishDate = DateTime.Now;
        newAnnouncement.ExpDate = Convert.ToDateTime(txtExp.Text);
        newAnnouncement.TeacherID = teacher.TeacherID;
        newAnnouncement.IsActive = true;
        db.Teacher_Ann.Add(newAnnouncement);
        db.SaveChanges();

    }
}