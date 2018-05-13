using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
public partial class VerifyDevice : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    MySql.Data.MySqlClient.MySqlCommand cmdText;
    String queryStr;
    String Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT DevicesID FROM Devices", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable todevice = new DataTable();
        sda.Fill(todevice);
       
        if (!IsPostBack)
        {
           
            int i = 0;
            foreach (DataRow drd in todevice.Rows)
            {
                i =Convert.ToInt32( drd["DevicesID"]);
            }
           
            txtId.Text =Convert.ToString( i + 1);
            txtId.Enabled = false;
            lblmessage.Visible = false;
        }
        conn.Close();
        cmd.Dispose();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int flag = 0;

        if (txtCode.Text == "")
        {
            lblmessage.Visible = true;
            lblmessage.Text = "Please fill the Code Box!";
        }
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT DeviceCode FROM Devices", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable todevice = new DataTable();
        sda.Fill(todevice);

        foreach (DataRow drd in todevice.Rows)
        {
            if (drd["DeviceCode"].ToString() == txtCode.Text)
            {
                flag = 1;
            }
        }

     
        if (flag == 1)
        {
            lblmessage.Visible = true;
            lblmessage.Text = "This device is already registered!";
        }
        else if (flag == 0 && txtCode.Text != "")
        {
            int t = 1;
            string CmdText = "INSERT INTO Devices(DeviceCode,IsActive)VALUES(@DeviceCode, @IsActive)";
            cmdText = new MySqlCommand(CmdText, conn);

            cmdText.Parameters.AddWithValue("@DeviceCode", txtCode.Text);
            cmdText.Parameters.AddWithValue("@IsActive", t);
            cmdText.ExecuteNonQuery();

          
            lblmessage.Visible = true;
            lblmessage.Text = "This device was saved!";
        }


    }

}