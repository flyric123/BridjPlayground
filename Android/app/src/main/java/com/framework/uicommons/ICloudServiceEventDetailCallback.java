package com.framework.uicommons;

import com.framework.datas.EventDetail;
import java.util.List;

/// interface for async call back on fetching the data from API
public interface ICloudServiceEventDetailCallback {
    void Complete(List<EventDetail> data);
    void ErrorOccurred(String error);
}
