package com.example.esemka_android.Fragments;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.esemka_android.Adapters.ExtracurricularMemberRecViewAdapter;
import com.example.esemka_android.Helpers.BitmapHelper;
import com.example.esemka_android.HttpRequest;
import com.example.esemka_android.MainActivity;
import com.example.esemka_android.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.concurrent.ExecutionException;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.RecyclerView;

public class ExtracurricularDetailFragment extends Fragment {
    String exculID;

    public ExtracurricularDetailFragment(String exculID) {
        this.exculID = exculID;
    }

    ImageView btnBack;
    TextView lblJoinNow;
    ImageView imgIcon;
    TextView lblName;
    TextView lblAbout;
    TextView lblSchedule;
    TextView lblLeader;
    ImageView imgLeader;
    RecyclerView recView;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View viewInflate = inflater.inflate(R.layout.fragment_extracurricular_detail, container, false);

        btnBack = viewInflate.findViewById(R.id.extracurricularDetailBtnBack);
        lblJoinNow = viewInflate.findViewById(R.id.extracurricularDetailLblJoinNow);
        imgIcon = viewInflate.findViewById(R.id.extracurricularDetailImgIcon);
        lblName = viewInflate.findViewById(R.id.extracurricularDetailLblName);
        lblAbout = viewInflate.findViewById(R.id.extracurricularDetailLblAbout);
        lblSchedule = viewInflate.findViewById(R.id.extracurricularDetailLblSchedule);
        lblLeader = viewInflate.findViewById(R.id.extracurricularDetailLblLeader);
        imgLeader = viewInflate.findViewById(R.id.extracurricularDetailImgLeader);
        recView = viewInflate.findViewById(R.id.extracurricularDetailRecViewMembers);

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ((Activity)viewInflate.getContext()).onBackPressed();
            }
        });

        lblJoinNow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    new HttpRequest("JoinExtracurricular/" + exculID, "POST").execute().get();

                    ((Activity)viewInflate.getContext()).startActivity(new Intent(getContext(), MainActivity.class));
                } catch (ExecutionException e) {
                    throw new RuntimeException(e);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
        });

        LoadData();

        return viewInflate;
    }

    private void LoadData() {
        try {
            JSONObject object = new JSONObject(new HttpRequest("ExtracurricularDetail/" + exculID, "GET").execute().get().Data);

            new BitmapHelper(getContext()).setImg(object.getString("iconName") + ".png", imgIcon);
            lblName.setText(object.getString("name"));
            lblLeader.setText(object.getJSONObject("leader").getString("fullname"));
            lblAbout.setText(object.getString("description"));
            lblSchedule.setText(object.getString("day") + ", " + object.getString("startTime") + " - " + object.getString("endTime"));

            recView.setAdapter(new ExtracurricularMemberRecViewAdapter(object.getJSONArray("members")));

            JSONArray myExtracurricularJSONArray = new JSONArray(new HttpRequest("MyExtracurriculars", "GET").execute().get().Data);
            for (int i = 0; i < myExtracurricularJSONArray.length(); i++) {
                JSONObject myExcul = myExtracurricularJSONArray.getJSONObject(i);

                if(myExcul.getString("id").equals(exculID)) {
                    lblJoinNow.setEnabled(false);
                    lblJoinNow.setTextColor(getResources().getColor(R.color.lightgray, getActivity().getTheme()));
                    lblJoinNow.setText("Already joined");

                    break;
                }
            }
        } catch (ExecutionException e) {
            throw new RuntimeException(e);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }
}
