using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditAnnouncements : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();
        if (!IsPostBack)
        {
            var query = (from x in db.Teacher_Ann
                         where x.TeacherID == teacher.TeacherID && x.IsActive == true

                         select new
                         {
                             x.AnnouncementID,
                             x.AnnContent,
                             x.PublishDate,
                             x.ExpDate

                         }).ToList();
            grdAnnouncement.DataSource = query;
            grdAnnouncement.DataBind();
        }
    }

    protected void grdAnnouncement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)grdAnnouncement.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblId");
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        int id = Convert.ToInt32(lbldeleteid.Text);

        Teacher_Ann m = (from x in db.Teacher_Ann where x.AnnouncementID == id && x.IsActive == true select x).SingleOrDefault();
        m.IsActive = false;
        db.SaveChanges();

        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();

        var query = (from x in db.Teacher_Ann
                     where x.TeacherID == teacher.TeacherID && x.IsActive == true

                     select new
                     {
                         x.AnnouncementID,
                         x.AnnContent,
                         x.PublishDate,
                         x.ExpDate

                     }).ToList();
        grdAnnouncement.DataSource = query;
        grdAnnouncement.DataBind();
    }



    protected void grdAnnouncement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdAnnouncement.EditIndex = -1;
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();

        var query = (from x in db.Teacher_Ann
                     where x.TeacherID == teacher.TeacherID && x.IsActive == true

                     select new
                     {
                         x.AnnouncementID,
                         x.AnnContent,
                         x.PublishDate,
                         x.ExpDate

                     }).ToList();
        grdAnnouncement.DataSource = query;
        grdAnnouncement.DataBind();
    }

    protected void grdAnnouncement_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdAnnouncement.EditIndex = e.NewEditIndex;
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();

        var query = (from x in db.Teacher_Ann
                     where x.TeacherID == teacher.TeacherID && x.IsActive == true

                     select new
                     {
                         x.AnnouncementID,
                         x.AnnContent,
                         x.PublishDate,
                         x.ExpDate

                     }).ToList();

        grdAnnouncement.DataSource = query;
        grdAnnouncement.DataBind();
 
}

    protected void grdAnnouncement_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = (Label)grdAnnouncement.Rows[e.RowIndex].FindControl("lblId");


        TextBox content = (TextBox)grdAnnouncement.Rows[e.RowIndex].FindControl("txtContent");
        TextBox pub = (TextBox)grdAnnouncement.Rows[e.RowIndex].FindControl("txtPub");
        TextBox exp = (TextBox)grdAnnouncement.Rows[e.RowIndex].FindControl("txtExp");
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        int id1 = Convert.ToInt32(id.Text);

        Teacher_Ann m = (from x in db.Teacher_Ann where x.AnnouncementID == id1 && x.IsActive == true select x).SingleOrDefault();


        m.AnnContent = content.Text;
        m.PublishDate = Convert.ToDateTime(pub.Text);
        m.ExpDate = Convert.ToDateTime(exp.Text);

        db.SaveChanges();

        Teachers teacher = (Teachers)Session["Teachers"];

        Teachers t = (from x in db.Teachers
                      where x.TeacherID == teacher.TeacherID
                      select x).SingleOrDefault();

        var query = (from x in db.Teacher_Ann
                     where x.TeacherID == teacher.TeacherID && x.IsActive == true

                     select new
                     {
                         x.AnnouncementID,
                         x.AnnContent,
                         x.PublishDate,
                         x.ExpDate

                     }).ToList();
        grdAnnouncement.DataSource = query;
        grdAnnouncement.DataBind();
    }

  
}