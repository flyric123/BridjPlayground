package com.bridjplayground.nativeandroid;

import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.framework.DataHandlers.EventDetailsDataHandler;
import com.framework.datas.EventDetail;
import com.framework.services.*;
import com.framework.uicommons.ICloudServiceEventDetailCallback;

import java.util.Arrays;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        final MainActivity activity = this;

        // to-do: we may need a loading screen

        // fetch data from API and display it to user
        CloudService.GetEventDetailFromCloud(new ICloudServiceEventDetailCallback()
        {
            @Override
            public void Complete(final List<EventDetail> data) {
                List<EventDetail> eventsHasSeats = EventDetailsDataHandler.GetEventHasSeatsOrderedByDate(data);
                List<EventDetail> eventsHasLabels = EventDetailsDataHandler.GetEventHasSeatsAndWithLabelsOrderedByDate(data, Arrays.asList("play"));

                new Handler(Looper.getMainLooper()).post(() -> {
                        LinearLayout llayout_has_seat = activity.findViewById(R.id.linearLayoutEventHasSeats);
                        for (EventDetail item : eventsHasSeats)
                        {
                            LayoutInflater inflater = (LayoutInflater)activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                            View temp = inflater.inflate(R.layout.temp_event_item, null);
                            PopulateEventTemplateUI(temp, item);
                            llayout_has_seat.addView(temp);
                        }

                        LinearLayout llayout_has_label = activity.findViewById(R.id.linearLayoutEventHasLabel);
                        for (EventDetail item : eventsHasLabels)
                        {
                            LayoutInflater inflater = (LayoutInflater)activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                            View temp = inflater.inflate(R.layout.temp_event_item, null);
                            PopulateEventTemplateUI(temp, item);
                            llayout_has_label.addView(temp);
                        }
                });
            }

            @Override
            public void ErrorOccurred(final String error) {
                new Handler(Looper.getMainLooper()).post( () -> {
                        AlertDialog alertDialog = new AlertDialog.Builder(MainActivity.this).create();
                        alertDialog.setTitle("Error");
                        alertDialog.setMessage(error);
                        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "Ok",
                                (dialog, which) -> {
                                    dialog.dismiss();
                                });
                        alertDialog.show();
                });
            }
        });
    }

    /// funtion to populate the event detail datas in to UI template
    private void PopulateEventTemplateUI(View view, EventDetail obj)
    {
        TextView label_name = view.findViewById(R.id.textViewEventName);
        TextView label_venue = view.findViewById(R.id.textViewEventVenue);
        TextView label_price = view.findViewById(R.id.textViewEventPrice);

        label_name.setText("Name: " + obj.name);
        label_price.setText("Price: " + obj.price);
        label_venue.setText("Venue: " +obj.venue);
    }
}
