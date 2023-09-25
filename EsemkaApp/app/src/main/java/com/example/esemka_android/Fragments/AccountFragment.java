package com.example.esemka_android.Fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.RecyclerView;

import com.example.esemka_android.Adapters.ExtracurricularRecViewAdapter;
import com.example.esemka_android.Adapters.JoinedExtracurricularRecViewAdapter;
import com.example.esemka_android.HttpRequest;
import com.example.esemka_android.Models.ResponseModel;
import com.example.esemka_android.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.concurrent.ExecutionException;

public class AccountFragment extends Fragment {
    TextView lblFullname;
    TextView lblUsername;
    TextView lblPhoneNumber;
    RecyclerView recView;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View viewInflate = inflater.inflate(R.layout.fragment_account, container, false);

        lblFullname = viewInflate.findViewById(R.id.accountLblFullname);
        lblUsername = viewInflate.findViewById(R.id.accountLblUsername);
        lblPhoneNumber = viewInflate.findViewById(R.id.accountLblPhoneNumber);
        recView = viewInflate.findViewById(R.id.accountRecViewJoinedExtracurricular);

        LoadDataProfile();
        LoadDataJoinedExtracurriculars();

        return viewInflate;
    }

    private void LoadDataProfile() {
        try {
            ResponseModel result = new HttpRequest("Me", "GET").execute().get();

            if(result.ResponseCode != 200) {
                Toast.makeText(getContext(), result.Data, Toast.LENGTH_SHORT).show();
            }

            JSONObject object = new JSONObject(result.Data);
            lblFullname.setText(object.getString("fullname"));
            lblUsername.setText(object.getString("username"));
            lblPhoneNumber.setText(object.getString("phoneNumber"));
        } catch (ExecutionException e) {
            throw new RuntimeException(e);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }

    private void LoadDataJoinedExtracurriculars() {
        try {
            ResponseModel result = new HttpRequest("MyExtracurriculars", "GET").execute().get();

            recView.setAdapter(new JoinedExtracurricularRecViewAdapter(new JSONArray(result.Data)));
        } catch (ExecutionException e) {
            throw new RuntimeException(e);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }
}
