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
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity {

    EditText username,password;
    ImageView showHidePwd1;
    Button login,userReg;
    DBHelper DB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        userReg=findViewById(R.id.userReg);
        username = findViewById(R.id.login_username);
        password = findViewById(R.id.login_password);
//        showHidePwd1=findViewById(R.id.imageview_show_hide_pwd1);
        login = findViewById(R.id.login);

        /*showHidePwd1.setImageResource(R.drawable.actionhidepassword);

        showHidePwd1.setOnClickListener(new View.OnClickListener() {
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

        DB = new DBHelper(this);


        userReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(LoginActivity.this, "Please Create Your Account !!!", Toast.LENGTH_LONG).show();
                Intent intent = new Intent(getApplicationContext(),UserRegistration.class);
                startActivity(intent);
            }
        });

        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String user = username.getText().toString();
                String pass = password.getText().toString();
                
                if(TextUtils.isEmpty(user) || TextUtils.isEmpty(pass))
                    Toast.makeText(LoginActivity.this, "All fields are required", Toast.LENGTH_SHORT).show();
                else{
                    Boolean checkUserPass = DB.checkUsernamePassword(user,pass);
                    if(checkUserPass==true){
                        Toast.makeText(LoginActivity.this, "Login Successful", Toast.LENGTH_SHORT).show();
                        Intent intent = new Intent(getApplicationContext(),FuelStationHomeActivity.class);
                        startActivity(intent);
                    }
                    else{
                        Toast.makeText(LoginActivity.this, "Login Failed", Toast.LENGTH_SHORT).show();
                    }
                }
                    
            }
        });
    }
}