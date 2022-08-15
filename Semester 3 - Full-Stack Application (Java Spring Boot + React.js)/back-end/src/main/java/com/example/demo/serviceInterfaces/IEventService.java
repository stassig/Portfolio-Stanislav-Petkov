package com.example.demo.serviceInterfaces;

import com.example.demo.models.Event;

import java.util.List;

public interface IEventService {

    Event getEventById(int id);

    List<Event> getAllEvents();

    List<Event> getCurrentEvents();

    void addEvent(Event event);

    void editEvent(Event event);

    void deleteEvent(int eventId);
}
