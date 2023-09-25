package com.example.esemka_android;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.esemka_android.Models.ResponseModel;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.concurrent.ExecutionException;

public class LoginActivity extends AppCompatActivity {

    EditText txtUsername;
    EditText txtPassword;
    Button btnLogin;
    TextView lblRegisterNow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        txtUsername = findViewById(R.id.loginTxtUsername);
        txtPassword = findViewById(R.id.loginTxtPassword);
        btnLogin = findViewById(R.id.loginBtnLogin);
        lblRegisterNow = findViewById(R.id.loginLblRegisterNow);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(txtUsername.getText().toString().equals("") || txtPassword.getText().toString().equals("")) {
                    Toast.makeText(LoginActivity.this, "Fill up login information", Toast.LENGTH_SHORT).show();
                    return;
                }

                try {
                    ResponseModel result = new HttpRequest("Auth", "POST").execute(
                            new JSONObject()
                                    .put("username", txtUsername.getText().toString())
                                    .put("password", txtPassword.getText().toString())
                                    .toString())
                            .get();

                    if(result.ResponseCode != 200) {
                        Toast.makeText(LoginActivity.this, result.Data, Toast.LENGTH_SHORT).show();
                        return;
                    }

                    GlobalData.userID = new JSONObject(result.Data).getString("id");

                    Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                    startActivity(intent);
                } catch (JSONException e) {
                    throw new RuntimeException(e);
                } catch (ExecutionException e) {
                    throw new RuntimeException(e);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
        });

        lblRegisterNow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, RegisterActivity.class);
                startActivity(intent);
            }
        });
    }
}