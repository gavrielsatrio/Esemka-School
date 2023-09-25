package com.example.esemka_android;

import android.os.AsyncTask;

import com.example.esemka_android.Models.ResponseModel;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class HttpRequest extends AsyncTask<String, Void, ResponseModel> {
    String url;
    String method;
    HttpURLConnection connection;

    public HttpRequest(String url, String method) {
        this.url = GlobalData.API_URL + "api/" + url;
        this.method = method;

        try {
            this.connection = (HttpURLConnection) new URL(this.url).openConnection();
            this.connection.setRequestProperty("Content-Type", "application/json");
            this.connection.setRequestMethod(this.method);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    protected ResponseModel doInBackground(String... strings) {
        if(strings.length > 0) {
            try {
                DataOutputStream writer = new DataOutputStream(this.connection.getOutputStream());
                writer.writeBytes(strings[0]);
                writer.close();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }

        StringBuilder result = new StringBuilder();

        try {
            BufferedReader reader = new BufferedReader(new InputStreamReader(this.connection.getInputStream()));
            result.append(reader.readLine());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        try {
//            if(result.toString().startsWith("{")) {
//                return new ResponseModel<JSONObject>(this.connection.getResponseCode(), new JSONObject(result.toString()));
//            } else if(result.toString().startsWith("[")) {
//                return new ResponseModel<JSONArray>(this.connection.getResponseCode(), new JSONArray(result.toString()));
//            }

            return new ResponseModel(this.connection.getResponseCode(), result.toString());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
