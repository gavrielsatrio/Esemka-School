package com.example.esemka_android.Adapters;

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

public class ExtracurricularMemberRecViewAdapter extends RecyclerView.Adapter<ExtracurricularMemberRecViewAdapter.ViewHolder> {
   JSONArray jsonArray;

   public ExtracurricularMemberRecViewAdapter(JSONArray jsonArray) {
      this.jsonArray = jsonArray;
   }

   @NonNull
   @Override
   public ExtracurricularMemberRecViewAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
      return new ViewHolder(LayoutInflater.from(parent.getContext()).inflate(R.layout.item_layout_extracurricular_member, parent, false));
   }

   @Override
   public void onBindViewHolder(@NonNull ExtracurricularMemberRecViewAdapter.ViewHolder holder, int position) {
      View viewInflate = holder.itemView;

      TextView lblName = viewInflate.findViewById(R.id.extracurricularMemberItemLblName);
      TextView lblMemberSince = viewInflate.findViewById(R.id.extracurricularMemberItemLblMemberSince);

      try {
         JSONObject object = jsonArray.getJSONObject(position);

         lblName.setText(object.getString("fullname"));
         lblMemberSince.setText("Member since: " + object.getString("joinDate"));
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
