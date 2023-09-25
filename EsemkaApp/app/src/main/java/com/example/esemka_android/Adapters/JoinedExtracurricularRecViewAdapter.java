package com.example.esemka_android.Adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.esemka_android.Helpers.BitmapHelper;
import com.example.esemka_android.MainActivity;
import com.example.esemka_android.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class JoinedExtracurricularRecViewAdapter extends RecyclerView.Adapter<JoinedExtracurricularRecViewAdapter.ViewHolder> {
   JSONArray jsonArray;

   public JoinedExtracurricularRecViewAdapter(JSONArray jsonArray) {
      this.jsonArray = jsonArray;
   }

   @NonNull
   @Override
   public JoinedExtracurricularRecViewAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
      return new ViewHolder(LayoutInflater.from(parent.getContext()).inflate(R.layout.item_layout_joined_extracurricular, parent, false));
   }

   @Override
   public void onBindViewHolder(@NonNull JoinedExtracurricularRecViewAdapter.ViewHolder holder, int position) {
      View viewInflate = holder.itemView;

      ImageView img = viewInflate.findViewById(R.id.joinedExtracurricularItemImg);
      TextView lblName = viewInflate.findViewById(R.id.joinedExtracurricularItemLblName);
      TextView lblJoinedDate = viewInflate.findViewById(R.id.joinedExtracurricularItemLblJoinedDate);

      MainActivity activity = (MainActivity) viewInflate.getContext();

      try {
         JSONObject object = jsonArray.getJSONObject(position);
         String iconName = object.getString("iconName");

         new BitmapHelper(activity).setImg(iconName + ".png", img);
         lblName.setText(object.getString("name"));
         lblJoinedDate.setText("Join date: " + object.getString("joinDate"));
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
