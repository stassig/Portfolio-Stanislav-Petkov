package com.example.demo.repository;

import com.example.demo.dalInterfaces.IEventDal;
import com.example.demo.models.Event;
import com.example.demo.repositoryInterfaces.IEventRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

@Repository
public class EventDalJPA implements IEventDal {

    private final IEventRepository repository;

    @Autowired
    public EventDalJPA(IEventRepository repository) {
        this.repository = repository;
    }

    @Override
    public Event getEventById(int id) {
        return this.repository.getEventByEventId(id);
    }

    @Override
    public List<Event> getAllEvents() {
        return this.repository.findAll();
    }

    @Override
    public List<Event> getCurrentEvents() {
        // Get yesterday's date, to include the current one in DB query
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(new Date());
        calendar.add(Calendar.DATE, -1);
        Date today = calendar.getTime();

        SimpleDateFormat DateFormat = new SimpleDateFormat("yyyy-MM-dd");
        String stringDate = DateFormat.format(today);

        return this.repository.getEventsByDateAfterOrderByDate(stringDate);
    }

    @Override
    public Event saveEvent(Event event) {
        return this.repository.save(event);
    }

    @Override
    public void deleteEvent(int eventId) { this.repository.deleteByEventId(eventId); }

}
