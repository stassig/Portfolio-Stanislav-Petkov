package com.example.demo.dalInterfaces;

import com.example.demo.models.Account;
import com.example.demo.models.Event;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface IEventDal {

    Event getEventById(int id);

    List<Event> getAllEvents();

    List<Event> getCurrentEvents();

    Event saveEvent(Event event);

    void deleteEvent(int eventId);
}
