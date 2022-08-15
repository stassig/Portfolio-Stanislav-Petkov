package com.example.demo.repository;

import com.example.demo.models.Event;
import com.example.demo.repositoryInterfaces.IEventRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class EventDalJPATest {

    @Mock
    private IEventRepository eventRepository;
    private EventDalJPA underTest;

    @BeforeEach
    void setUp() {
        underTest = new EventDalJPA(eventRepository);
    }

    @Test
    void canGetEventById() {
        // when
        underTest.getEventById(1);
        // then
        verify(eventRepository).getEventByEventId(1);
    }

    @Test
    void canGetAllEvents() {
        // when
        underTest.getAllEvents();
        // then
        verify(eventRepository).findAll();
    }

    @Test
    void canGetCurrentEvents() {
        // when
        underTest.getCurrentEvents();
        // then
        verify(eventRepository).getEventsByDateAfterOrderByDate(anyString());
    }

    @Test
    void canSaveEvent() {
        // given
        Event event = new Event("UEFA", 45f, "2022-01-28", "15:30", 1);
        // when
        underTest.saveEvent(event);
        // then
        verify(eventRepository).save(event);
    }

    @Test
    void canDeleteEvent() {
        // when
        underTest.deleteEvent(1);
        // then
        verify(eventRepository).deleteByEventId(1);
    }
}