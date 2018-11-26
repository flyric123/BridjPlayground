package com.framework.uicommons;

import com.framework.datas.EventDetail;
import java.util.List;

/// interface for async call back on fetching the data from API
public interface ICloudServiceEventDetailCallback {
    /// method will be called when the cloud service request is done
    void Complete(List<EventDetail> data);
    /// method will be called when any error occurs during the request
    void ErrorOccurred(String error);
}
