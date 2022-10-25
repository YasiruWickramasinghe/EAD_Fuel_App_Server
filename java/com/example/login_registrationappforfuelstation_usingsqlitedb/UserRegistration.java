package com.example.login_registrationappforfuelstation_usingsqlitedb;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

public class UserRegistration extends AppCompatActivity {

    EditText username,password,repassword,chassisNo;
    Button signup,signin;
    Spinner vehicleType;
    DBHelper DB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_registration);

        username=findViewById(R.id.username);
        password=findViewById(R.id.password);
        repassword=findViewById(R.id.repassword);
        chassisNo = findViewById(R.id.chassisNo);
        signup=findViewById(R.id.signup);
        signin=findViewById(R.id.signin);
        vehicleType=findViewById(R.id.spinner);

        ArrayAdapter<String> typeAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1,getResources().getStringArray(R.array.names));
        typeAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        vehicleType.setAdapter(typeAdapter);

        DB = new DBHelper(this);



        signup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String user = username.getText().toString();
                String pass = password.getText().toString();
                String repass = repassword.getText().toString();
                String chassis = chassisNo.getText().toString();

                if(TextUtils.isEmpty(user) || TextUtils.isEmpty(pass) || TextUtils.isEmpty(repass) || TextUtils.isEmpty(chassis))
                    Toast.makeText(UserRegistration.this,"All fields are required",Toast.LENGTH_SHORT).show();
                else
                if(pass.equals(repass)){
                    Boolean CheckUser = DB.checkUsername(user);
                    if(CheckUser==false){
                        Boolean insert = DB.insertData(user,pass);
                        if(insert==true){
                            Toast.makeText(UserRegistration.this,"Registered Successfully..",Toast.LENGTH_SHORT).show();
                            Intent intent = new Intent(getApplicationContext(),FuelStationHomeActivity.class);
                            startActivity(intent);
                        }
                        else{
                            Toast.makeText(UserRegistration.this, "Registration Failed", Toast.LENGTH_SHORT).show();
                        }
                    }
                    else{
                        Toast.makeText(UserRegistration.this, "User Already Exists", Toast.LENGTH_SHORT).show();
                    }
                }
                else{
                    Toast.makeText(UserRegistration.this, "Passwords are not matching", Toast.LENGTH_SHORT).show();
                }
            }
        });

        signin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Intent intent = new Intent(getApplicationContext(),LoginActivity.class);
                startActivity(intent);
            }
        });
    }
}


