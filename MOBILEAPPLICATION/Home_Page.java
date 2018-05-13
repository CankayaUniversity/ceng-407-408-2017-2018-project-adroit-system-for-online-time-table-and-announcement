package com.webcankaya.mobileappcankaya;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.Display;
import android.view.View;

import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;


public class Home_Page extends Activity
{
    Button Time, annon, email, logout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.home_page);
        Time = (Button) findViewById(R.id.Timebt);
        annon = (Button) findViewById(R.id.Anbt);
        email = (Button) findViewById(R.id.emailbt);
        logout = (Button) findViewById(R.id.Logbt);


        Time.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Home_Page.this, Time_Table.class);
                startActivity(i);
            }
        });
        annon.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent a = new Intent(Home_Page.this, Announcement_Page.class);
                startActivity(a);
            }
        });


        logout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });


    }

}
