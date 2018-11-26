package com.framework.services;

import org.json.*;

import com.framework.uicommons.ICloudServiceEventDetailCallback;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.loopj.android.http.*;
import cz.msebera.android.httpclient.*;

import com.framework.datas.*;

public class CloudService
{
    private static final String TEST_ENDPOINT_URL = "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json";
    private static AsyncHttpClient client = new AsyncHttpClient();

    // function to get the event details from cloud, it is an async method, so pass in the interface to handle the result
    public static void GetEventDetailFromCloud(final ICloudServiceEventDetailCallback callback)
    {
        client.get(TEST_ENDPOINT_URL,null, new JsonHttpResponseHandler() {
            @Override
            public void onSuccess(int statusCode, Header[] headers, JSONObject response) {
                // If the response is JSONObject instead of expected JSONArray
                try {
                    GsonBuilder builder = new GsonBuilder();
                    Gson gson = builder.create();
                    EventList events = gson.fromJson(response.toString(), EventList.class);
                    callback.Complete(events.events);
                }
                catch (Exception e){callback.ErrorOccurred(e.getMessage());}
            }

            @Override
            public void onFailure(int statusCode, Header[] headers, String responseString, Throwable throwable) {
                callback.ErrorOccurred(responseString);
            }
        });
    }
}
