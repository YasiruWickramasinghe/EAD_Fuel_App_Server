package com.example.login_registrationappforfuelstation_usingsqlitedb;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;

public class UserTypeSelectionActivity extends AppCompatActivity {

    Animation topAnim;
    ImageView image;
    RadioGroup radioGroup;
    RadioButton radioButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_type_selectio);

        image=findViewById(R.id.img);
        topAnim = AnimationUtils.loadAnimation(this,R.anim.top_animation);
        radioGroup = findViewById(R.id.rgroup);


        image.setAnimation(topAnim);
    }

    public void rbclick(View v)
    {
        int radioButtonId = radioGroup.getCheckedRadioButtonId();
        radioButton = (RadioButton) findViewById(radioButtonId);

        findRadioButton(radioButtonId);
    }

    private void findRadioButton(int radioButtonId) {
        switch (radioButtonId){
            case R.id.radioButton1:
                Toast.makeText(UserTypeSelectionActivity.this,"Logged As Station Owner..",Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(getApplicationContext(),StationOwnerLoginActivity.class);
                startActivity(intent);
                break;
            case R.id.radioButton2:
                Toast.makeText(UserTypeSelectionActivity.this,"Logged as User",Toast.LENGTH_SHORT).show();
                Intent intent2 = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(intent2);
                break;
        }
    }
}