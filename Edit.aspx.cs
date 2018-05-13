using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Edit : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmds;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;
    int teacherid;
    MySql.Data.MySqlClient.MySqlConnection conncontrol;
    MySql.Data.MySqlClient.MySqlCommand cmdscontrol;
    MySql.Data.MySqlClient.MySqlDataReader rdcontrol;
    String str=" ";
    String queryStrcontrol;
    protected void Page_Load(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmds = new MySqlCommand("SELECT *  FROM Teachers where Email= '" + Session["Email"].ToString() + "' ", conn);
        rd = cmds.ExecuteReader();

        if (rd.Read())
        {

            teacherid = Convert.ToInt32(rd.GetString("TeacherID"));
            conn.Close();
            rd.Close();
        }
        conn.Close();
        cmds.Dispose();
        conn.Dispose();
        if (!IsPostBack)
        {
            ddlDay.Items.Add("Select..");
            ddlDay.Items.Add("Monday");
            ddlDay.Items.Add("Tuesday");
            ddlDay.Items.Add("Wednesday");
            ddlDay.Items.Add("Thursday");
            ddlDay.Items.Add("Friday");
            ddlTime.Items.Add("Select..");
            ddlExtras.Items.Add("Select..");
            ddlExtras.Items.Add("In a Meeting");
            ddlExtras.Items.Add("Lunch");
            ddlExtras.Items.Add("Office Hour");
            ddlExtras.Items.Add("Research Hour");
            ddlExtras.Items.Add("Not on Campus");
            ddlExtras.Items.Add("Do not Disturb");

            cmds = new MySqlCommand("SELECT LectureCode,LectureNo  FROM Lectures where TeacherID= '" + teacherid + "' ", conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmds);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dtTimetable.DataSource = new Array[1];
            dtTimetable.DataBind();

        }
        
    }

    public string FindM9()
    {
        string da = "Monday";
        string ti = "09:20";

        addtotable(da,ti);
        string ret = str;
        return ret;
    }
    public string FindTu9()
    {
        string da = "Tuesday";
        string ti = "09:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW9()
    {
        string da = "wednesday";
        string ti = "09:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh9()
    {
        string da = "Thursday";
        string ti = "09:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF9()
    {
        string da = "Friday";
        string ti = "09:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM10()
    {
        string da = "Monday";
        string ti = "10:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu10()
    {
        string da = "Tuesday";
        string ti = "10:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW10()
    {
        string da = "wednesday";
        string ti = "10:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh10()
    {
        string da = "Thursday";
        string ti = "10:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF10()
    {
        string da = "Friday";
        string ti = "10:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM11()
    {
        string da = "Monday";
        string ti = "11:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu11()
    {
        string da = "Tuesday";
        string ti = "11:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW11()
    {
        string da = "Wednesday";
        string ti = "11:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh11()
    {
        string da = "Thursday";
        string ti = "11:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF11()
    {
        string da = "Friday";
        string ti = "11:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM12()
    {
        string da = "Monday";
        string ti = "12:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu12()
    {
        string da = "Tuesday";
        string ti = "12:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW12()
    {
        string da = "Wednesday";
        string ti = "12:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh12()
    {
        string da = "Thursday";
        string ti = "12:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF12()
    {
        string da = "Friday";
        string ti = "12:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM13()
    {
        string da = "Monday";
        string ti = "13:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu13()
    {
        string da = "Tuesday";
        string ti = "13:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW13()
    {
        string da = "Wednesday";
        string ti = "13:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh13()
    {
        string da = "Thursday";
        string ti = "13:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF13()
    {
        string da = "Friday";
        string ti = "13:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM14()
    {
        string da = "Monday";
        string ti = "14:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu14()
    {
        string da = "Tuesday";
        string ti = "14:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW14()
    {
        string da = "Wednesday";
        string ti = "14:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh14()
    {
        string da = "Thursday";
        string ti = "14:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF14()
    {
        string da = "Friday";
        string ti = "14:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM15()
    {
        string da = "Monday";
        string ti = "15:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu15()
    {
        string da = "Tuesday";
        string ti = "15:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW15()
    {
        string da = "Wednesday";
        string ti = "15:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh15()
    {
        string da = "Thursday";
        string ti = "15:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF15()
    {
        string da = "Friday";
        string ti = "15:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindM16()
    {
        string da = "Monday";
        string ti = "16:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTu16()
    {
        string da = "Tuesday";
        string ti = "16:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindW16()
    {
        string da = "Wednesday";
        string ti = "16:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindTh16()
    {
        string da = "Thursday";
        string ti = "16:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    public string FindF16()
    {
        string da = "Friday";
        string ti = "16:20";

        addtotable(da, ti);
        string ret = str;
        return ret;
    }
    void addtotable(string day, string time)
    {
        str = " ";
        String connStringcontrol = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
        conncontrol = new MySql.Data.MySqlClient.MySqlConnection(connStringcontrol);
        conncontrol.Open();
        cmdscontrol = conncontrol.CreateCommand();
        cmdscontrol.CommandType = CommandType.Text;
        cmdscontrol.CommandText = "select * from Lectures where LectureDay='" + day + "' and LectureHour='" + time + "' and TeacherID='" + teacherid + "'";
        cmdscontrol.ExecuteNonQuery();
        DataTable dtcontrol = new DataTable();
        MySqlDataAdapter sdacontrol = new MySqlDataAdapter(cmdscontrol);
        sdacontrol.Fill(dtcontrol);
        foreach (DataRow dr in dtcontrol.Rows)
        {
            string s = dr["LectureCode"].ToString() + " " + dr["LectureNo"].ToString() + " " + dr["Extra"].ToString() ;
          
            if (dr["Extra"].ToString()=="")
            {
                string d = dr["LectureClass"].ToString();
                var indexOfFirstSpace = d.IndexOf(" ");
                var first = d.Substring(0, indexOfFirstSpace);
                s = s + Environment.NewLine;
                s = s + first;
                s = s.Replace(Environment.NewLine, "<br />");
            }
            str = s;
        }
        conncontrol.Close();
        conncontrol.Dispose();
        cmdscontrol.Dispose();
        dtcontrol.Dispose();
        sdacontrol.Dispose();
        if (str==" ")
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(connStringcontrol);
            conn.Open();
            cmdscontrol = conn.CreateCommand();
            cmdscontrol.CommandType = CommandType.Text;
            cmdscontrol.CommandText = "select * from Extras where TeacherID='" + teacherid + "' and Day='"+day+"' and Time='"+time+"' ";
            cmdscontrol.ExecuteNonQuery();
            DataTable dtc = new DataTable();
            MySqlDataAdapter sdac = new MySqlDataAdapter(cmdscontrol);
            sdac.Fill(dtc);
            if (dtc.Rows.Count ==0)
            {
                String connStringf = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
                conncontrol = new MySql.Data.MySqlClient.MySqlConnection(connStringf);
                conncontrol.Open();

                string CmdText = "INSERT INTO AdroitDatabase.Extras(TeacherID,Day,Time)VALUES(@TeacherID,@Day, @Time)";
                MySqlCommand cmdcontrol = new MySqlCommand(CmdText, conncontrol);

                cmdcontrol.Parameters.AddWithValue("@TeacherID", teacherid);
                cmdcontrol.Parameters.AddWithValue("@Day", day);
                cmdcontrol.Parameters.AddWithValue("@Time", time);
                cmdcontrol.ExecuteNonQuery();

                conncontrol.Close();
                conncontrol.Dispose();
                cmdscontrol.Dispose();
                sdacontrol.Dispose();
            }
            conn.Close();
            conn.Dispose();
            cmdscontrol.Dispose();
            dtc.Dispose();
            sdac.Dispose();

           

        }

    }
    void adding_ddl(string day)
    {
        ddlTime.Items.Clear();
        ddlTime.Items.Add("Select..");
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmds = new MySqlCommand("SELECT *  FROM Extras where TeacherID= '"+teacherid+ "' and Day='"+day+"'", conn);
       MySqlDataAdapter sdadevice = new MySqlDataAdapter(cmds);
        DataTable dtdevice = new DataTable();
        sdadevice.Fill(dtdevice);
        foreach (DataRow drdevice in dtdevice.Rows)
        {
            ddlTime.Items.Add(drdevice["Time"].ToString());
         
        }
       
        conn.Close();
        cmds.Dispose();
        conn.Dispose();
       
    }

    protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDay.SelectedItem.Value == "Monday")
        {
            adding_ddl("Monday");
        }
        if (ddlDay.SelectedItem.Value == "Tuesday")
        {
            adding_ddl("Tuesday");
        }
        if (ddlDay.SelectedItem.Value == "Wednesday")
        {
            adding_ddl("Wednesday");
        }
        if (ddlDay.SelectedItem.Value == "Thursday")
        {
            adding_ddl("Thursday");
        }
        if (ddlDay.SelectedItem.Value == "Friday")
        {
            adding_ddl("Friday");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (ddlExtras.SelectedItem.Value == "Select.." || ddlTime.SelectedItem.Value == "Select.." || ddlDay.SelectedItem.Value == "Select..")
        {
            lblmessage.Visible = true;
            lblmessage.Text = "Please fill all the fields!";
        }
        else
        {
            String connStringf = System.Configuration.ConfigurationManager.ConnectionStrings["Adroit"].ToString();
            conncontrol = new MySql.Data.MySqlClient.MySqlConnection(connStringf);
            conncontrol.Open();

            string CmdText = "INSERT INTO AdroitDatabase.Lectures(TeacherID,LectureDay,LectureHour,Extra)VALUES(@TeacherID,@LectureDay,@LectureHour,@Extra)";
            MySqlCommand cmdcontrol = new MySqlCommand(CmdText, conncontrol);

            cmdcontrol.Parameters.AddWithValue("@TeacherID", teacherid);
            cmdcontrol.Parameters.AddWithValue("@LectureDay", ddlDay.SelectedItem.Value);
            cmdcontrol.Parameters.AddWithValue("@LectureHour", ddlTime.SelectedItem.Value);
            cmdcontrol.Parameters.AddWithValue("@Extra", ddlExtras.SelectedItem.Value);
            cmdcontrol.ExecuteNonQuery();

            conncontrol.Close();
            conncontrol.Dispose();
            cmdcontrol.Dispose();
            Response.Redirect(Request.RawUrl);

        }
        

    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        string a = " ";
        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmds = new MySqlCommand("Delete from Lectures WHERE TeacherID=@a2 and Extra!=@a3", conn);
        cmds.Parameters.Add("a2", teacherid);
        cmds.Parameters.Add("a3", a);
        cmds.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        cmds.Dispose();
        Response.Redirect(Request.RawUrl);
        
    }


}