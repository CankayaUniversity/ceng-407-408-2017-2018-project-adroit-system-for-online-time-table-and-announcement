package com.webcankaya.mobileappcankaya;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CalendarView;
import android.widget.EditText;
import android.widget.TextView;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.time.LocalDateTime;
import java.util.Date;


public class Announcement_Page extends Activity {
    Button publish_btn;
    EditText content;
    String id, password, username, db;
    Connection conn;
    Statement stmt;
    ResultSet rs;
    TextView date, ann_content;
    CalendarView expdate,date2;
    LocalDateTime noww;
    Date selectedDate;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.announcement_page);

        publish_btn = (Button)findViewById(R.id.btn_publish);
        date = (TextView)findViewById(R.id.txt_expdate);
        ann_content = (TextView)findViewById(R.id.txt_content);
        content = (EditText)findViewById(R.id.asil_content);
        expdate = (CalendarView) findViewById(R.id.calendar_exp);
        selectedDate = new Date(expdate.getDate());
        //id = "206.189.26.46";
        //username = "efe";
        //password = "efe123";
        //db = "AdroitDatabase";

        publish_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                publish();
            }
        });

    }

    private void publish()
    {
        try
        {
            Class.forName("com.mysql.jdbc.Driver").newInstance();
            conn=DriverManager.getConnection("jdbc:mysql://206.189.26.46:3306/AdroitDatabase","efe","efe123");
            stmt=conn.createStatement();
            noww = LocalDateTime.now();
            rs=stmt.executeQuery("Insert into Teacher_Ann Values(DEFAULT, 1, '"+noww+"', '"+content+"', '"+selectedDate+"', 1");
            conn.close();
        }
        catch(Exception e)
        {
            System.out.println(e);
        }
    }

}