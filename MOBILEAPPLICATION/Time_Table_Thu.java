package com.webcankaya.mobileappcankaya;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.view.Display;
import android.view.View;

import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class Time_Table_Thu extends Activity
{
    Button Tue, Wed, Mon, Fri;
    private int count = 0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.time_table_thu);
        Tue = (Button) findViewById(R.id.salıbt);
        Wed = (Button) findViewById(R.id.carsbt);
        Mon = (Button) findViewById(R.id.pztbt);
        Fri = (Button) findViewById(R.id.cumbt);

        Tue.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Time_Table_Thu.this, Time_Table_Tue.class);
                startActivity(i);
            }
        });

        Wed.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Time_Table_Thu.this, Time_Table_Wed.class);
                startActivity(i);
            }
        });

        Mon.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Time_Table_Thu.this, Time_Table.class);
                startActivity(i);
            }
        });

        Fri.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Time_Table_Thu.this, Time_Table_Fri.class);
                startActivity(i);
            }
        });
    }
    @Override
    public void onBackPressed() {
        count++;
        if (count >=1) {
        /* If count is greater than 1 ,you can either move to the next
        activity or just quit. */
            Intent intent = new Intent(Time_Table_Thu.this, Home_Page.class);
            startActivity(intent);
            finish();
//                overridePendingTransition
//                        (R.anim.push_left_in, R.anim.push_left_out);
            /* Quitting */
            finishAffinity();
        }
        else {
            Toast.makeText(this, "Press back again to Leave!", Toast.LENGTH_SHORT).show();

            // resetting the counter in 2s
            Handler handler = new Handler();
            handler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    count = 0;
                }
            }, 2000);
        }
        super.onBackPressed();
    }
}
