package com.example.esemka_android.Models;

public class ResponseModel {
    public int ResponseCode;
    public String Data;

    public ResponseModel(int responseCode, String data) {
        ResponseCode = responseCode;
        Data = data;
    }
}