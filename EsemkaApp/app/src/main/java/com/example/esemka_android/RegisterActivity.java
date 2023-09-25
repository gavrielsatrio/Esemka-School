package com.example.esemka_android;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.esemka_android.Models.ResponseModel;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.concurrent.ExecutionException;

public class RegisterActivity extends AppCompatActivity {

    EditText txtUsername;
    EditText txtFullname;
    EditText txtPhone;
    EditText txtPassword;
    EditText txtConfPassword;
    Button btnRegister;
    TextView lblLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        txtUsername = findViewById(R.id.registerTxtUsername);
        txtFullname = findViewById(R.id.registerTxtFullname);
        txtPhone = findViewById(R.id.registerTxtPhoneNumber);
        txtPassword = findViewById(R.id.registerTxtPassword);
        txtConfPassword = findViewById(R.id.registerTxtConfPassword);
        btnRegister = findViewById(R.id.registerBtnRegister);
        lblLogin = findViewById(R.id.registerLblLogin);

        btnRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(txtUsername.getText().toString().equals("") || txtFullname.getText().toString().equals("") || txtPhone.getText().toString().equals("") || txtPassword.getText().toString().equals("") || txtConfPassword.getText().toString().equals("")) {
                    Toast.makeText(RegisterActivity.this, "Fill up your information", Toast.LENGTH_SHORT).show();
                    return;
                }

                if(!txtConfPassword.getText().toString().equals(txtPassword.getText().toString())) {
                    Toast.makeText(RegisterActivity.this, "Confirm password doesn't match", Toast.LENGTH_SHORT).show();
                    return;
                }

                try {
                    ResponseModel result = new HttpRequest("Register", "POST").execute(
                                    new JSONObject()
                                            .put("username", txtUsername.getText().toString())
                                            .put("fullname", txtFullname.getText().toString())
                                            .put("phoneNumber", txtPhone.getText().toString())
                                            .put("password", txtPassword.getText().toString())
                                            .toString())
                            .get();

                    if(result.ResponseCode != 200) {
                        Toast.makeText(RegisterActivity.this, result.Data, Toast.LENGTH_SHORT).show();
                        return;
                    }

                    GlobalData.userID = new JSONObject(result.Data).getString("id");

                    Intent intent = new Intent(RegisterActivity.this, MainActivity.class);
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

        lblLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                startActivity(intent);
            }
        });
    }
}