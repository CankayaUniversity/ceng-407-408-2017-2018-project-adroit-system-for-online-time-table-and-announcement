using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
public partial class AllAnnouncements : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader rd;
    String queryStr;

    MySql.Data.MySqlClient.MySqlConnection connAnn;
    MySql.Data.MySqlClient.MySqlCommand cmdAnn;
    MySql.Data.MySqlClient.MySqlDataReader rdAnn;
    String queryStrAnn;

    MySql.Data.MySqlClient.MySqlConnection connUp;
    MySql.Data.MySqlClient.MySqlCommand cmdUp;
    MySql.Data.MySqlClient.MySqlDataReader rdUp;
    String queryStrUp;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        conn = new MySqlConnection(constr);
        conn.Open();
        cmd = new MySqlCommand("SELECT *  FROM Teachers where Email= '" + Session["Email"].ToString() + "' ", conn);
        rd = cmd.ExecuteReader();

        if (rd.Read())
        {

            id = Convert.ToInt32(rd.GetString("TeacherID"));
            conn.Close();
            rd.Close();
        }
        conn.Close();
        int x = 0;
        string tnow = Convert.ToString(DateTime.Now);
        string createddate = Convert.ToDateTime(tnow).ToString("yyyy-MM-dd HH:mm:ss");
        string constrUp = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        connUp = new MySqlConnection(constrUp);
        connUp.Open();
        cmdUp = new MySqlCommand("UPDATE Teacher_Ann SET IsActive=@a1 WHERE Expdate<@a2 and TeacherID=@a3",connUp);
        cmdUp.Parameters.Add("a1",x);
        cmdUp.Parameters.Add("a2", createddate);
        cmdUp.Parameters.Add("a3", id);
        cmdUp.ExecuteNonQuery();
        connUp.Close();

        


        string constrAnn = ConfigurationManager.ConnectionStrings["Adroit"].ConnectionString;
        connAnn = new MySqlConnection(constrAnn);
        connAnn.Open();
        cmdAnn = new MySqlCommand("SELECT * FROM Teacher_Ann where IsActive=1 and TeacherID='"+id+"' and ExpDate>= '"+ createddate + "' order by PublishDate ", connAnn);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmdAnn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count==0)
        {
            lblmes.Visible = true;
            lblmes.Text = " There is no announcement!";
        }
        dtAnnouncemnets.DataSource = dt;
        dtAnnouncemnets.DataBind();
        rdAnn = cmdAnn.ExecuteReader();
        connAnn.Close();


    }

    public string FindDate(object date)
    {
        DateTime dt = Convert.ToDateTime(date);
        string res = Convert.ToString(dt.Day) + "." + Convert.ToString(dt.Month) + "." + Convert.ToString(dt.Year);
        return res;
    }

    public string Alert(object date)
    {
        DateTime dt = Convert.ToDateTime(date);
        DateTime n = DateTime.Now;
        if (dt.Year == n.Year)
        {
            if (dt.Month == n.Month)
            {
                if (dt.Day - n.Day <= 1)
                {
                    string res = "" + "" + "Last Day!";

                    return res;
                }
            }
        }
        return " ";

    }
}