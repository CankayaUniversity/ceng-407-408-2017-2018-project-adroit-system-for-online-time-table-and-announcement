package com.webcankaya.mobileappcankaya;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class Announcement_Home extends Activity {

    Button publish_button, edit_button;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.announcement_home);


        publish_button = (Button) findViewById(R.id.btn_pann);
        edit_button = (Button) findViewById(R.id.btn_editann);

        publish_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent a = new Intent(Announcement_Home.this, Announcement_Page.class);
                startActivity(a);
            }
        });

        edit_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent a = new Intent(Announcement_Home.this, All_Announcements.class);
                startActivity(a);
            }
        });

    }



}
