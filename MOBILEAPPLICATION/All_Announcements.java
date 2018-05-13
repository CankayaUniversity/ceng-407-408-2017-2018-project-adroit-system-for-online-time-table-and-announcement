package com.webcankaya.mobileappcankaya;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import java.sql.SQLException;


public class All_Announcements extends Activity {
    ListView lv;
    EditText Anncontent, PublishDate, ExpireDate;
    Button deletebtn, updatebtn;
    Connection conn;
    Statement stmt;
    Date publishdatee,expdatee;
    String content;
    ResultSet rs , rs2,rs3;
    ArrayList<String> names = new ArrayList<String>();
    ArrayAdapter<String> adapter;
    int i=0;

    private static final String Db_URL = "jdbc:mysql://206.189.26.46:3306/AdroitDatabase";
    private static final String UserName = "efe";
    private static final String Password = "efe123";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.all_announcements);

        lv =(ListView) findViewById(R.id.list_ann);
        //nameText = (EditText)findViewById(R.id.txt_update);

        deletebtn = (Button) findViewById(R.id.btn_delete);
        updatebtn = (Button) findViewById(R.id.btn_update);
        Anncontent = (EditText)findViewById(R.id.txt_anncontent);
        PublishDate = (EditText)findViewById(R.id.txt_pdate);
        ExpireDate = (EditText)findViewById(R.id.txt_edate);

        try
        {
            Class.forName("com.mysql.jdbc.Driver");
            conn= DriverManager.getConnection(Db_URL,UserName,Password);
            stmt=conn.createStatement();
            rs=stmt.executeQuery("SELECT * FROM Teacher_Ann WHERE IsActive=1 and TeacherID=1");

            while(rs.next()){
                names.add(rs.getString(i));
                i++;
            }

            //adapter
            adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_single_choice,names);
            lv.setAdapter(adapter);

            //conn.close();
        }
        catch(Exception e)
        {
            System.out.println(e);
        }

        //select item
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int pos, long id) {
                String AllText = names.get(pos);
                int length = AllText.length();

                int indexEdate= AllText.lastIndexOf(" ");
                String Content_Pdate = AllText.substring(0,indexEdate);
                String Edate = AllText.substring(indexEdate, length);
                Edate = Edate.trim();
                Content_Pdate = Content_Pdate.trim();//başındaki ve sonundaki boşlukları siliyor.
                int length2 = Content_Pdate.length();

                int indexPdate= Content_Pdate.lastIndexOf(" ");
                String Contentt = Content_Pdate.substring(0,indexPdate);
                Contentt = Contentt.trim();
                String Pdate = Content_Pdate.substring(indexPdate, length2);
                Pdate = Pdate.trim();

                Anncontent.setText(Contentt);
                PublishDate.setText(Pdate);
                ExpireDate.setText(Edate);
            }
        });

        //handle events
        deletebtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                delete();
            }
        });

        updatebtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                update();
            }
        });
    }
    //update
    private void update()
    {
        content = Anncontent.getText().toString();
        String pdate = PublishDate.getText().toString();
        String edate = ExpireDate.getText().toString();
        String name =  content+ pdate+ edate;


        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm");
        try
        {
            publishdatee = simpleDateFormat.parse(pdate);
            expdatee = simpleDateFormat.parse(edate);

            //System.out.println("date : " +simpleDateFormat.format(publishdatee));
            //System.out.println("date : " +simpleDateFormat.format(expdatee));

        }
        catch (ParseException ex)
        {
            System.out.println("Exception "+ex);
        }

        //GET POS OF SELECTED ITEM
        int pos= lv.getCheckedItemPosition();


        if(!name.isEmpty() && name.length()>0)
        {
            //int id = stmt.executeQuery("SELECT AnnouncementID FROM Teacher_Ann WHERE AnnContent = '"+content+"' AND IsActive=1");
            //int id=1;
            //stmt.executeUpdate("UPDATE Teacher_Ann SET (AnnContent = '"+content+"' and ExpDate = '"+expdatee+"' and PublishDate = '"+publishdatee+"') WHERE AnnouncementID = '" + id + "' ");

            //remove item
            adapter.remove(names.get(pos));

            //insert
            adapter.insert(name,pos);

            //refresh
            adapter.notifyDataSetChanged();

            Toast.makeText(getApplicationContext(), "Updated" + name, Toast.LENGTH_SHORT).show();
        }
        else
        {
            Toast.makeText(getApplicationContext(), "Nothing to Update!", Toast.LENGTH_SHORT).show();
        }
    }
    //delete
    private void delete()
    {
        int pos= lv.getCheckedItemPosition();

        if(pos > -1)
        {
            String deletedData = names.get(pos);
            int index= deletedData.lastIndexOf(" ");
            String content = deletedData.substring(0,index);

//            rs3 = stmt.executeQuery("SELECT AnnouncementID FROM Teacher_Ann WHERE IsActive=1 AND AnnContent = "+content+" ");
//            while (rs3.next())
//            {
//                int id  = rs.getInt("AnnouncementID");
//            }
//            stmt.executeUpdate("UPDATE Teacher_Ann SET IsActive=0 WHERE AnnouncementID = '"+id+"' ");

            //remove
            adapter.remove(names.get(pos));

            //refresh
            adapter.notifyDataSetChanged();

            Toast.makeText(getApplicationContext(), "Deleted", Toast.LENGTH_SHORT).show();
        }
        else
        {
            Toast.makeText(getApplicationContext(), "Nothing to Delete!", Toast.LENGTH_SHORT).show();
        }
    }
}
