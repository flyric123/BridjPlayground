package com.bridjplayground.nativeandroid;

import android.provider.ContactsContract;

import org.junit.Test;

import static org.junit.Assert.*;

import com.framework.DataHandlers.EventDetailsDataHandler;
import com.framework.datas.EventDetail;
import com.framework.services.*;

import java.time.Instant;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
public class ExampleUnitTest {
    @Test
    public void addition_isCorrect() {
        assertEquals(4, 2 + 2);
    }

    @Test
    public void EventDetail_funcs(){
        EventDetail event = new EventDetail();
        event.available_seats = 10;
        event.labels = Arrays.asList("a", "b", "c");

        assertTrue(event.HasSeats());
        assertTrue(event.HasLabels(Arrays.asList("a")));
        assertTrue(event.HasLabels(Arrays.asList("a", "c")));
        assertFalse(event.HasLabels(Arrays.asList("d")));
        assertFalse(event.HasLabels(Arrays.asList("d", "a")));
    }

    @Test
    public void EventDetailDataHandler_funcs(){
        List<EventDetail> events = new ArrayList<EventDetail>();
        events.add(new EventDetail());
        events.get(0).available_seats = 1;
        events.get(0).date = new GregorianCalendar(2018, Calendar.NOVEMBER, 26).getTime();
        events.get(0).labels = Arrays.asList("a", "b", "c");

        events.add(new EventDetail());
        events.get(1).available_seats = 0;
        events.get(1).date = new GregorianCalendar(2018, Calendar.NOVEMBER, 26).getTime();
        events.get(1).labels = Arrays.asList("a", "b");

        events.add(new EventDetail());
        events.get(2).available_seats = 10;
        events.get(2).date = new GregorianCalendar(2018, Calendar.NOVEMBER, 30).getTime();
        events.get(2).labels = Arrays.asList("b", "c", "e");

        List<EventDetail> result = EventDetailsDataHandler.GetEventHasSeatsOrderedByDate(events);
        assertTrue(result.size() == 2);
        assertTrue(result.get(0).available_seats == 10);

        events.add(new EventDetail());
        events.get(3).available_seats = 3;
        events.get(3).date = new GregorianCalendar(2018, Calendar.NOVEMBER, 29).getTime();
        events.get(3).labels = Arrays.asList("e", "c");

        result = EventDetailsDataHandler.GetEventHasSeatsAndWithLabelsOrderedByDate(events, Arrays.asList("e"));
        assertTrue(result.size() == 2);
        assertTrue(result.get(0).available_seats == 10);
    }
}