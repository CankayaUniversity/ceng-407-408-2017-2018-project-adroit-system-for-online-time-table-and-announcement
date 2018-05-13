package com.example.utku.email;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import android.view.View;

import java.lang.String;


public class reply_page extends Activity {

    EditText mail, sbj, cnt;
    Button sendBtn;

    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reply_page);

        mail = (EditText) findViewById(R.id.mailText);
        sbj = (EditText) findViewById((R.id.subjText));
        cnt = (EditText) findViewById((R.id.cntText));
        sendBtn = (Button) findViewById(R.id.button);
        sendBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                sendEmail();

            }
        });
    }


    protected void sendEmail() {

        if (mail.getText().toString().matches("") &&
                sbj.getText().toString().matches("")&& cnt.getText().toString().matches("")) {
            Toast.makeText(getApplicationContext(), "Please Fill All The Parts!",Toast.LENGTH_SHORT).show();
        }
        else {

            String email = "c" + mail.getText().toString() + "@student.cankaya.edu.tr";
            String cntnt = cnt.getText().toString();
            String subj = sbj.getText().toString();
            String[] TO = {email};
            Intent emailIntent = new Intent(Intent.ACTION_SEND);
            emailIntent.setData(Uri.parse("mailto:"));
            emailIntent.setType("text/plain");


            emailIntent.putExtra(Intent.EXTRA_EMAIL, TO);
            emailIntent.putExtra(Intent.EXTRA_SUBJECT, subj);
            emailIntent.putExtra(Intent.EXTRA_TEXT, cntnt);

            try {
                startActivity(Intent.createChooser(emailIntent, "Send mail..."));
                finish();
            } catch (android.content.ActivityNotFoundException ex) {
                Toast.makeText(reply_page.this,
                        "There is no email client installed.", Toast.LENGTH_SHORT).show();
            }
        }
    }
}
