package com.example.esemka_android.Fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.esemka_android.Adapters.ExtracurricularRecViewAdapter;
import com.example.esemka_android.HttpRequest;
import com.example.esemka_android.Models.ResponseModel;
import com.example.esemka_android.R;

import org.json.JSONArray;
import org.json.JSONException;

import java.util.concurrent.ExecutionException;

public class ExtracurricularFragment extends Fragment {
    RecyclerView recView;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View viewInflate = inflater.inflate(R.layout.fragment_extracurricular, container, false);

        recView = viewInflate.findViewById(R.id.extracurricularRecView);

        LoadData();

        return viewInflate;
    }

    private void LoadData() {
        try {
            ResponseModel result = new HttpRequest("Extracurriculars", "GET").execute().get();

            recView.setAdapter(new ExtracurricularRecViewAdapter(new JSONArray(result.Data)));
        } catch (ExecutionException e) {
            throw new RuntimeException(e);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }
}
