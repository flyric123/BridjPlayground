package com.framework.DataHandlers;

import com.framework.datas.EventDetail;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

/// the helper class to filter/sort the raw data we get from cloud service
public class EventDetailsDataHandler {

    /// function to filter and keep the has-seat event then order them by their dates in descending order
    public static List<EventDetail> GetEventHasSeatsOrderedByDate(List<EventDetail> events){
        List<EventDetail> result = events.stream().filter(e -> e.HasSeats()).collect(Collectors.toList());
        result.sort( (o1, o2) -> o1.date.after(o2.date) ? -1 : 1);

        return result;
    }

    /// function to filter and keep the has-seat events with the specified labels ,then order them by their dates in descending order
    public static List<EventDetail> GetEventHasSeatsAndWithLabelsOrderedByDate(List<EventDetail> events, List<String> labels){
        List<EventDetail> result = events.stream().filter(e -> e.HasSeats()).filter(e -> e.HasLabels(labels)).collect(Collectors.toList());
        result.sort( (o1, o2) -> o1.date.after(o2.date) ? -1 : 1);

        return result;
    }
}
