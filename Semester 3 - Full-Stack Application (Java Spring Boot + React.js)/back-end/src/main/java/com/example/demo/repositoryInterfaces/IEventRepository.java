package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Event;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface IEventRepository extends JpaRepository<Event, Integer> {

    Event getEventByEventId(int id);

    List<Event> getEventsByDateAfterOrderByDate(String date);

    void deleteByEventId(int eventId);
}
