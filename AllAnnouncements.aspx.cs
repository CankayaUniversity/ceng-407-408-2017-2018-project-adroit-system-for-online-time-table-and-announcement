using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Announcements : System.Web.UI.Page
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

            var SortedList = query.OrderBy(o => o.PublishDate).ToList();

            dtAnnouncemnets.DataSource = SortedList;
            dtAnnouncemnets.DataBind();
        }
    }

    public string FindDate(object date)
    {
        DateTime dt = Convert.ToDateTime(date);
        string res = Convert.ToString(dt.Day) + "." + Convert.ToString(dt.Month) + "." + Convert.ToString(dt.Year);
        return res;
    }
}