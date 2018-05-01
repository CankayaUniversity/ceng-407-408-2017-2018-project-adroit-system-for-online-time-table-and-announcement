using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerifyDevice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        if (!IsPostBack)
        {
            var query = (from x in db.Devices
                         select new
                         {
                             x.DeviceID
                         }).ToList();
            int i = 0; 
            
            while (i < query.Count)
            {
                i++;
            }
            txtId.Text =Convert.ToString( i + 1);
            txtId.Enabled = false;
            lblmessage.Visible = false;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int flag = 0;
        AdroitOnlineTimeTableEntities db = new AdroitOnlineTimeTableEntities();
        Devices newdevice = new Devices();
        if (txtCode.Text=="")
        {
            lblmessage.Visible = true;
            lblmessage.Text = "Please fill the Code Box!";
        }
        Devices[] query = (from x in db.Devices
                       select x).ToArray();
        for (int i = 0; i < query.Length; i++)
        {
            if (query[i].DeviceCode== txtCode.Text)
            {
                flag = 1;
            }
        }
        if (flag==1)
        {
            lblmessage.Visible = true;
            lblmessage.Text = "This device is already registered!";
        }
        else if (flag==0 && txtCode.Text != "")
        {
            newdevice.DeviceCode = txtCode.Text;
            newdevice.IsActive = true;
            db.Devices.Add(newdevice);
            db.SaveChanges();
            lblmessage.Visible = true;
            lblmessage.Text = "This device was saved!";
        }
        
     
    }
   
}