package com.example.esemka_android.Helpers;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.widget.ImageView;

import com.example.esemka_android.GlobalData;

import java.io.IOException;
import java.net.ContentHandler;
import java.net.URL;

public class BitmapHelper {
   Context context;

   public BitmapHelper(Context context) {
      this.context = context;
   }

   public void setImg(String url, ImageView img) {
      new Thread(new Runnable() {
         @Override
         public void run() {
            try {
               String imgURL = GlobalData.API_URL + "images/" + url;
               Bitmap bitmap = BitmapFactory.decodeStream(new URL(imgURL).openStream());

               ((Activity)context).runOnUiThread(new Runnable() {
                  @Override
                  public void run() {
                     img.setImageBitmap(bitmap);
                  }
               });
            } catch (IOException e) {
               throw new RuntimeException(e);
            }
         }
      }).start();
   }
}
