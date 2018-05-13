package com.example.utku.email;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class email_page extends Activity {

    Button replyBtn;
    TextView tv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_email_page);

        replyBtn = (Button)findViewById(R.id.btn_reply);
        replyBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent i = new Intent(email_page.this, reply_page.class);
                startActivity(i);
            }
        });

    }
}
