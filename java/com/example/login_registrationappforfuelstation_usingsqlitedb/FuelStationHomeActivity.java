package com.example.login_registrationappforfuelstation_usingsqlitedb;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.TextView;

public class FuelStationHomeActivity extends AppCompatActivity {

    private static int SPLASH_SCREEN=5000;

    Animation topAnim,bottomAnim;
    ImageView image;
    TextView welcome;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fuel_station_home);

        topAnim = AnimationUtils.loadAnimation(this,R.anim.top_animation);
        bottomAnim = AnimationUtils.loadAnimation(this,R.anim.bottom_animation);

        image = findViewById(R.id.img);
        welcome = findViewById(R.id.textView);

        image.setAnimation(topAnim);
        welcome.setAnimation(bottomAnim);

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent intent = new Intent(FuelStationHomeActivity.this,FuelDashboard.class);
                startActivity(intent);
                finish();
            }
        },SPLASH_SCREEN);
    }
}