package com.example.esemka_android.Adapters;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.esemka_android.Fragments.ExtracurricularDetailFragment;
import com.example.esemka_android.Helpers.BitmapHelper;
import com.example.esemka_android.MainActivity;
import com.example.esemka_android.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class ExtracurricularRecViewAdapter extends RecyclerView.Adapter<ExtracurricularRecViewAdapter.ViewHolder> {
   JSONArray jsonArray;

   public ExtracurricularRecViewAdapter(JSONArray jsonArray) {
      this.jsonArray = jsonArray;
   }

   @NonNull
   @Override
   public ExtracurricularRecViewAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
      return new ViewHolder(LayoutInflater.from(parent.getContext()).inflate(R.layout.item_layout_extracurricular, parent, false));
   }

   @Override
   public void onBindViewHolder(@NonNull ExtracurricularRecViewAdapter.ViewHolder holder, int position) {
      View viewInflate = holder.itemView;

      ImageView img = viewInflate.findViewById(R.id.extracurricularItemImg);
      TextView lblName = viewInflate.findViewById(R.id.extracurricularItemLblName);

      MainActivity activity = (MainActivity) viewInflate.getContext();

      try {
         JSONObject object = jsonArray.getJSONObject(position);
         String iconName = object.getString("iconName");
         String exculID = object.getString("id");

         lblName.setText(object.getString("name"));
         new BitmapHelper(activity).setImg(iconName + ".png", img);

         viewInflate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
               activity.ChangeToFragment(new ExtracurricularDetailFragment(exculID));
            }
         });
      } catch (JSONException e) {
         throw new RuntimeException(e);
      }
   }

   @Override
   public int getItemCount() {
      return jsonArray.length();
   }

   public class ViewHolder extends RecyclerView.ViewHolder {
      public ViewHolder(@NonNull View itemView) {
         super(itemView);
      }
   }
}
