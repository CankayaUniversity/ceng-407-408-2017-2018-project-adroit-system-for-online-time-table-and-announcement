using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
public partial class AddTeacher : System.Web.UI.Page
{
    public static List<Ders> dersler = new List<Ders>();
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;
    String Dt;
    string Teacherid;
    string Deviceid;
    string Registry;
    MySql.Data.MySqlClient.MySqlCommand cmdd;
    MySql.Data.MySqlClient.MySqlCommand tcmd;
    MySql.Data.MySqlClient.MySqlCommand ttcmd;
    MySql.Data.MySqlClient.MySqlCommand cmdteacher;
    MySql.Data.MySqlClient.MySqlCommand cmddevice;
    MySql.Data.MySqlClient.MySqlCommand cmdText;
    MySql.Data.MySqlClient.MySqlConnection conncontrol;
    MySql.Data.MySqlClient.MySqlCommand cmdscontrol;
    MySql.Data.MySqlClient.MySqlDataReader rdcontrol;
    MySql.Data.MySqlClient.MySqlConnection connf;
    MySql.Data.MySqlClient.MySqlCommand cmdsf;
    MySql.Data.MySqlClient.MySqlDataReader rdf;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            adding_ddl();
        }    
           
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        if (ddlDevice.SelectedValue == "Select..." || ddlTeacher.SelectedValue == "Select...")
        {
            lblmessage.Visible = true;
            lblmessage.Text = "Please choose any teacher and device!";
        }
        if (ddlDevice.SelectedValue != "Select..." && ddlTeacher.SelectedValue != "Select...")
        {
           
            string a = ddlDevice.SelectedValue;
            lblmessage.Visible = true;
            int t = 1;//true value
            string constrt = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
            conn = new MySqlConnection(constrt);
            conn.Open();
            cmdteacher = new MySqlCommand("SELECT TeacherID,Name,Surname,RegistryNo FROM Teachers where IsActive= '" + t + "'", conn);
            MySqlDataAdapter sdateacher = new MySqlDataAdapter(cmdteacher);
            DataTable dtteacher = new DataTable();
            sdateacher.Fill(dtteacher);

            foreach (DataRow drteacher in dtteacher.Rows)
            {
                if (drteacher["Name"] + " " + drteacher["Surname"] == ddlTeacher.SelectedItem.Value)
                {
                    Teacherid = drteacher["TeacherID"].ToString();
                    Registry= drteacher["RegistryNo"].ToString();
                }
            }
            cmddevice = new MySqlCommand("SELECT DevicesID,DeviceCode FROM Devices where IsActive= '" + t + "'", conn);
            MySqlDataAdapter sdadevice = new MySqlDataAdapter(cmddevice);
            DataTable dtdevice = new DataTable();
            sdadevice.Fill(dtdevice);
            foreach (DataRow drdevice in dtdevice.Rows)
            {
                if (drdevice["DevicesID"] + "-" + drdevice["DeviceCode"] == ddlDevice.SelectedItem.Value)
                {
                    Deviceid = drdevice["DevicesID"].ToString();
                }
            }
            string CmdText = "INSERT INTO Teacher_Devices(Teacher_ID,Devices_ID,isActive)VALUES(@Teacher_ID,@Devices_ID, @isActive)";
            cmdText = new MySqlCommand(CmdText, conn);

            cmdText.Parameters.AddWithValue("@Teacher_ID", Teacherid);
            cmdText.Parameters.AddWithValue("@Devices_ID", Deviceid);
            cmdText.Parameters.AddWithValue("@isActive", t);

            cmdText.ExecuteNonQuery();
          
          
            lblmessage.Text = "Matching process is successfully completed!";
            adding_ddl();
            addLecturestoDatabase();
            conn.Close();
            conn.Dispose();
        }
    }
    void addLecturestoDatabase()
    {

        short method = 7000;
        short methodNo = 1;
        string Params = Registry;  //İlgili kişinin 5 haneli sicil nosu
        string Key = "LCFVgYmX2Y";


        ServiceReference1.Service1Soap webservis = new ServiceReference1.Service1SoapClient();
        var result = webservis.XML_3_OBS(method, methodNo, Params, Key);


        DataTable dt = new DataTable();

        foreach (DataRow dr in result.Tables[0].Rows)
        {
            dersler.Add(new Ders
            {
                DersKod = Convert.ToString(dr["DersKod"]),
                DersNo = Convert.ToString(dr["DersNo"]),
                Section = Convert.ToString(dr["Section"]),
                DersAdiTurkce = Convert.ToString(dr["DersAdıTurkce"]),
                DersAdiEng = Convert.ToString(dr["DersAdıEng"]),
                DayName = Convert.ToString(dr["DayName"]),
                DayNameTr = Convert.ToString(dr["DayNameTR"]),
                TimeOldCampus = Convert.ToString(dr["TimeOldCampus"]),
                TimeNewCampus = Convert.ToString(dr["TimeNewCampus"]),
                TimeBoth = Convert.ToString(dr["TimeBoth"]),
                Ad = Convert.ToString(dr["Ad"]),
                Classroom = Convert.ToString(dr["Classroom"])
            });
        }
        for (int i = 0; i < dersler.Count; i++)
        {
            String connStringcontrol = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
            conncontrol = new MySql.Data.MySqlClient.MySqlConnection(connStringcontrol);
            conncontrol.Open();
            cmdscontrol = conncontrol.CreateCommand();
            cmdscontrol.CommandType = CommandType.Text;
            cmdscontrol.CommandText = "select * from Lectures where LectureCode='" + dersler[i].DersKod + "' and LectureNo='" + dersler[i].DersNo + "' and LectureDay='" + dersler[i].DayName + "' and LectureHour='" + dersler[i].TimeNewCampus + "' and LectureClass='" + dersler[i].Classroom + "'";
            cmdscontrol.ExecuteNonQuery();
            DataTable dtcontrol = new DataTable();
            MySqlDataAdapter dacontrol = new MySqlDataAdapter(cmdscontrol);
            dacontrol.Fill(dtcontrol);
            if (dtcontrol.Rows.Count == 0)
            {
                String connStringf = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
                connf = new MySql.Data.MySqlClient.MySqlConnection(connStringf);
                connf.Open();

                string CmdText = "INSERT INTO AdroitDatabase.Lectures(TeacherID,LectureCode,LectureNo,LectureDay,LectureHour,LectureClass)VALUES(@TeacherID,@LectureCode, @LectureNo, @LectureDay, @LectureHour,@LectureClass)";
                MySqlCommand cmdsf = new MySqlCommand(CmdText, connf);

                cmdsf.Parameters.AddWithValue("@TeacherID", Teacherid);
                cmdsf.Parameters.AddWithValue("@LectureCode", dersler[i].DersKod);
                cmdsf.Parameters.AddWithValue("@LectureNo", dersler[i].DersNo);
                cmdsf.Parameters.AddWithValue("@LectureDay", dersler[i].DayName);
                cmdsf.Parameters.AddWithValue("@LectureHour", dersler[i].TimeNewCampus);
                cmdsf.Parameters.AddWithValue("@LectureClass", dersler[i].Classroom);

                cmdsf.ExecuteNonQuery();
                connf.Close();
                connf.Dispose();
            }

            conncontrol.Close();
            conncontrol.Dispose();
        }
    }
    void adding_ddl()
    {
        ddlDevice.Items.Clear();
        ddlTeacher.Items.Clear();
        int t = 1; //true value
        ddlDevice.Items.Add("Select...");
        ddlTeacher.Items.Add("Select...");
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT Devices_ID FROM Teacher_Devices where IsActive= '" + t + "'", conn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable todevice = new DataTable();
        sda.Fill(todevice);

        cmdd = new MySqlCommand("SELECT DevicesID,DeviceCode FROM Devices where IsActive= '" + t + "'", conn);
        MySqlDataAdapter sdad = new MySqlDataAdapter(cmdd);
        DataTable d = new DataTable();
        sdad.Fill(d);
        foreach (DataRow drd in d.Rows)
        {
            int k = 0;
            foreach (DataRow td in todevice.Rows)
            {
                if (drd["DevicesID"].ToString() == td["Devices_ID"].ToString())
                {
                    k++;
                }
            }
            if (k == 0)
            {
                ddlDevice.Items.Add(Convert.ToString(drd["DevicesID"]) + "-" + Convert.ToString(drd["DeviceCode"]));
            }
        }


        conn.Close();
        conn.Dispose();
        conn = new MySqlConnection(constr);
        conn.Open();
        tcmd = new MySqlCommand("SELECT TeacherID,Name,Surname FROM Teachers where IsActive= '" + t + "'", conn);
        MySqlDataAdapter tda = new MySqlDataAdapter(tcmd);
        DataTable teach = new DataTable();
        tda.Fill(teach);

        ttcmd = new MySqlCommand("SELECT Teacher_ID FROM Teacher_Devices where IsActive= '" + t + "'", conn);
        MySqlDataAdapter ttda = new MySqlDataAdapter(ttcmd);
        DataTable toteacher = new DataTable();
        ttda.Fill(toteacher);


        foreach (DataRow teac in teach.Rows)
        {
            int m = 0;
            foreach (DataRow tt in toteacher.Rows)
            {
                if (teac["TeacherID"].ToString() == tt["Teacher_ID"].ToString())
                {
                    m++;
                }
            }
            if (m == 0)
            {
                ddlTeacher.Items.Add(Convert.ToString(teac["Name"]) + " " + Convert.ToString(teac["Surname"]));
            }
        }

        conn.Close();
        conn.Dispose();
    }
}