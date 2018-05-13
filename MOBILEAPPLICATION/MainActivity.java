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

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;


public class MainActivity extends Activity  {
    Button b1,b2;
    EditText ed1,ed2;

    TextView tx1;
    int counter = 3;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        b1 = (Button)findViewById(R.id.button);
        ed1 = (EditText)findViewById(R.id.editText);
        ed2 = (EditText)findViewById(R.id.editText2);

        b2 = (Button)findViewById(R.id.button2);
        tx1 = (TextView)findViewById(R.id.textView3);
        tx1.setVisibility(View.GONE);
        test();
        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //
                test();
                if(ed1.getText().toString().equals("admin") &&
                        ed2.getText().toString().equals("admin")) {
                    Toast.makeText(getApplicationContext(), "Redirecting...",Toast.LENGTH_SHORT).show();

                    Intent i = new Intent(MainActivity.this, Home_Page.class);
                    startActivity(i);
                }else{
                    Toast.makeText(getApplicationContext(), "Wrong E-mail or password",Toast.LENGTH_SHORT).show();

                            tx1.setVisibility(View.VISIBLE);
                    tx1.setBackgroundColor(Color.RED);
                    counter--;
                    tx1.setText(Integer.toString(counter));

                    if (counter == 0) {
                        b1.setEnabled(false);
                    }
                }
            }
        });

        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    public void test() {
        try {
            System.out.println("ONER UNAL");
            Connection connection = openConnection();
            Statement statement = connection.createStatement();
            ResultSet rs = statement.executeQuery("select 1");
            if (rs.next()) {
                int result = rs.getInt(1);
                System.out.println("SONUC: "+result);
                Toast.makeText(getApplicationContext(), "Sonuc: "+result, Toast.LENGTH_SHORT);
            }
            System.out.println("MERHABA");
        }
        catch ( Exception e) {
            e.printStackTrace();
            Toast.makeText(getApplicationContext(), "HATA: "+e.getMessage(), Toast.LENGTH_SHORT);
        }
    }

    public  Connection openConnection() {
        try {
            // The newInstance() call is a work around for some
            // broken Java implementations

            Class.forName("com.mysql.jdbc.Driver").newInstance();

        } catch (Exception ex) {
            System.out.println("SQLException: " + ex.getMessage());
            // handle the error
        }

        Connection conn = null;
        try {
            conn =
                    DriverManager.getConnection("jdbc:mysql://206.189.26.46/AdroitDatabase?" +
                            "user=efe&password=efe123");

            // Do something with the Connection

        } catch (SQLException ex) {
            // handle any errors
            System.out.println("SQLException: " + ex.getMessage());
            System.out.println("SQLState: " + ex.getSQLState());
            System.out.println("VendorError: " + ex.getErrorCode());
        }
        return conn;
    }
}