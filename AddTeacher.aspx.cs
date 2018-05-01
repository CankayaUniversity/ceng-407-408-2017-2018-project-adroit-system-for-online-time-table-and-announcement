using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        if (!IsPostBack)
        {
            ddlDevice.Items.Add("Select...");
            ddlTeacher.Items.Add("Select...");

            var todevice = (from x in db.Teacher_Device
                            where x.isActive==true
                            select new
                            {
                                x.Device_ID
                            }).ToList();

            var d = (from x in db.Devices
                     where x.IsActive == true
                     select new
                     {
                         x.DeviceCode,
                         x.DeviceID
                     }).ToList();

            
            for (int i = 0; i < d.Count; i++)
            {
                int k = 0;
                for (int j = 0; j < todevice.Count; j++)
                {
                    if (d[i].DeviceID==todevice[j].Device_ID)
                    {
                        k++;
                    }
                }
                if (k==0)
                {
                    ddlDevice.Items.Add(Convert.ToString(d[i].DeviceID)+"-"+ Convert.ToString(d[i].DeviceCode));
                }
                
            }
            var t = (from x in db.Teachers
                     where x.IsActive==true
                     select new
                     {
                         x.TeacherID,
                         x.Name,
                         x.Surname
                     }).ToList();

            var toTeacher = (from x in db.Teacher_Device
                             where x.isActive == true
                             select new
                             {
                                 x.Teacher_ID
                             }).ToList();

            for (int i = 0; i < t.Count; i++)
            {
                int m = 0;
                for (int j = 0; j < toTeacher.Count; j++)
                {
                    if (t[i].TeacherID == toTeacher[j].Teacher_ID)
                    {
                        m++;
                    }
                }
                if (m == 0)
                {
                    ddlTeacher.Items.Add(Convert.ToString(t[i].Name) + " " + Convert.ToString(t[i].Surname));
                }

            }

        }    
           
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        if (ddlDevice.SelectedValue=="Select..." || ddlTeacher.SelectedValue=="Select...")
        {
            lblmessage.Visible = true;
            lblmessage.Text = "Please choose any teacher and device!";
        }
        if (ddlDevice.SelectedValue != "Select..." && ddlTeacher.SelectedValue != "Select...")
        {
            string a = ddlDevice.SelectedValue;
            lblmessage.Visible = true;

            var teacher = (from x in db.Teachers
                           where x.Name + " " + x.Surname == ddlTeacher.SelectedItem.Value
                           select x).SingleOrDefault();

            var dev = (from x in db.Devices
                       where x.DeviceID + "-" + x.DeviceCode== ddlDevice.SelectedItem.Value
                       select x).SingleOrDefault();
            Teacher_Device newtd = new Teacher_Device();
            newtd.Device_ID = dev.DeviceID;
            newtd.Teacher_ID = teacher.TeacherID;
            newtd.isActive = true;
            db.Teacher_Device.Add(newtd);
            db.SaveChanges();
            lblmessage.Text = "Matching process is successfully completed!";
        }
    }
}