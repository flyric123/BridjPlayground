package com.framework.datas;

import java.util.Date;
import java.util.*;

/// the event detail class
public class EventDetail
{
    public String name;
    public Date date;
    public int available_seats;
    public float price;
    public String venue;
    public List<String> labels;

    /// determine whether this event has seats
    public boolean HasSeats () {
        return available_seats > 0;
    }

    /// determine whether this event has all the targeted labels
    public boolean HasLabels(List<String> target_labels) {
        return labels.containsAll(target_labels);
    }
}
