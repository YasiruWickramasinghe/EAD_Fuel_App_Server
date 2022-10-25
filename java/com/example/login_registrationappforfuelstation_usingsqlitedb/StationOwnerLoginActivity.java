package com.example.login_registrationappforfuelstation_usingsqlitedb;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class StationOwnerLoginActivity extends AppCompatActivity {

    Button ownerRegistration,ownerLogin;
    EditText username,password;
    DBHelper DB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_station_owner_login);

        username=findViewById(R.id.login_owner_username);
        password=findViewById(R.id.login_owner_password);
        ownerLogin=findViewById(R.id.login);
        ownerRegistration = findViewById(R.id.ownerReg);

        DB = new DBHelper(this);
        ownerRegistration.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(StationOwnerLoginActivity.this, "Please Create Your Account !!!", Toast.LENGTH_LONG).show();
                Intent intent = new Intent(getApplicationContext(),StationOwnerRegistration.class);
                startActivity(intent);
            }
        });

        ownerLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String user = username.getText().toString();
                String pass = password.getText().toString();

                if(TextUtils.isEmpty(user) || TextUtils.isEmpty(pass))
                    Toast.makeText(StationOwnerLoginActivity.this, "All fields are required", Toast.LENGTH_SHORT).show();
                else{
                    Boolean checkUserPass = DB.checkUsernamePassword(user,pass);
                    if(checkUserPass==true){
                        Toast.makeText(StationOwnerLoginActivity.this, "Login Successful", Toast.LENGTH_SHORT).show();
                        Intent intent = new Intent(getApplicationContext(),FuelStationHomeActivity.class);
                        startActivity(intent);
                    }
                    else{
                        Toast.makeText(StationOwnerLoginActivity.this, "Login Failed", Toast.LENGTH_SHORT).show();
                    }
                }

            }
        });
    }
}