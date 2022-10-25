package com.example.login_registrationappforfuelstation_usingsqlitedb;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.text.method.HideReturnsTransformationMethod;
import android.text.method.PasswordTransformationMethod;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.Toast;

public class StationOwnerRegistration extends AppCompatActivity {

    EditText stationName,stationNo,username,password,repassword;
    ImageView showHidePwd1,showHidePwd2;
    Button signup,signin;
    DBHelper DB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_station_owner_registration);

        stationName=findViewById(R.id.stationName);
        stationNo=findViewById(R.id.stationNo);
        username=findViewById(R.id.username);
        password=findViewById(R.id.ownerPassword);
        repassword=findViewById(R.id.ownerRepassword);
//        showHidePwd1=findViewById(R.id.imageview_show_hide_pwd1);
//        showHidePwd2=findViewById(R.id.imageview_show_hide_pwd2);
        signin=findViewById(R.id.signin);
        signup=findViewById(R.id.signup);


//        showHidePwd1.setImageResource(R.drawable.actionhidepassword);
//        showHidePwd2.setImageResource(R.drawable.actionhidepassword);
        DB = new DBHelper(this);




       /* showHidePwd1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(password.getTransformationMethod().equals(HideReturnsTransformationMethod.getInstance()))
                {
                    password.setTransformationMethod(PasswordTransformationMethod.getInstance());
                    showHidePwd1.setImageResource(R.drawable.actionhidepassword);
                }
                else
                {
                    password.setTransformationMethod(PasswordTransformationMethod.getInstance());
                    showHidePwd1.setImageResource(R.drawable.actionshowpassword);
                }
            }
        });
*/
        /*showHidePwd2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(repassword.getTransformationMethod().equals(HideReturnsTransformationMethod.getInstance()))
                {
                    repassword.setTransformationMethod(PasswordTransformationMethod.getInstance());
                    showHidePwd2.setImageResource(R.drawable.actionhidepassword);
                }
                else
                {
                    repassword.setTransformationMethod(PasswordTransformationMethod.getInstance());
                    showHidePwd2.setImageResource(R.drawable.actionshowpassword);
                }
            }
        });*/

        signup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String name=stationName.getText().toString();
                String no=stationNo.getText().toString();
                String user = username.getText().toString();
                String pass = password.getText().toString();
                String repass = repassword.getText().toString();

                if(TextUtils.isEmpty(name) || TextUtils.isEmpty(no)||TextUtils.isEmpty(user) || TextUtils.isEmpty(pass) || TextUtils.isEmpty(repass))
                    Toast.makeText(StationOwnerRegistration.this,"All fields are required",Toast.LENGTH_SHORT).show();
                else
                if(pass.equals(repass)){
                    Boolean CheckUser = DB.checkUsername(user);
                    if(CheckUser==false){
                        Boolean insert = DB.insertData(user,pass);
                        if(insert==true){
                            Toast.makeText(StationOwnerRegistration.this,"Registered Successfully..",Toast.LENGTH_SHORT).show();
                            Intent intent = new Intent(getApplicationContext(),FuelStationHomeActivity.class);
                            startActivity(intent);
                        }
                        else{
                            Toast.makeText(StationOwnerRegistration.this, "Registration Failed", Toast.LENGTH_SHORT).show();
                        }
                    }
                    else{
                        Toast.makeText(StationOwnerRegistration.this, "User Already Exists", Toast.LENGTH_SHORT).show();
                    }
                }
                else{
                    Toast.makeText(StationOwnerRegistration.this, "Passwords are not matching", Toast.LENGTH_SHORT).show();
                }
            }
        });

        signin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Intent intent = new Intent(getApplicationContext(),StationOwnerLoginActivity.class);
                startActivity(intent);
            }
        });

    }
}