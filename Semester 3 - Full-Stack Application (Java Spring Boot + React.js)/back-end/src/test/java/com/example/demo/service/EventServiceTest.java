package com.example.demo.service;

import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.dalInterfaces.IEventDal;
import com.example.demo.models.Event;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;


@ExtendWith(MockitoExtension.class)
class EventServiceTest {

    @Mock
    private IEventDal eventDal;
    @Mock
    private IBlockDal blockDal;
    private EventService underTest;

    @BeforeEach
    void setUp() {
        underTest = new EventService(eventDal, blockDal);
    }

    @Test
    void canGetEventById() {
        // when
        underTest.getEventById(1);
        // then
        verify(eventDal).getEventById(1);
    }

    @Test
    void canGetAllEvents() {
        // when
        underTest.getAllEvents();
        // then
        verify(eventDal).getAllEvents();
    }

    @Test
    void canGetCurrentEvents() {
        // when
        underTest.getCurrentEvents();
        // then
        verify(eventDal).getCurrentEvents();
    }

    @Test
    void canDeleteEvent() {
        // when
        underTest.deleteEvent(1);
        // then
        verify(eventDal).deleteEvent(1);
    }

    @Test
    void canEditEvent() {
        // given
        Event event = new Event("UEFA", 45f, "2022-01-28", "15:30", 1);
        // when
        underTest.editEvent(event);
        // then
        verify(eventDal).saveEvent(event);
    }

    @Test
    void canAddEvent() {
        // given
        Event event = new Event("UEFA", 45f, "2022-01-28", "15:30", 1);
        given(eventDal.saveEvent(event))
                .willReturn(new Event(1000,"UEFA", 45f, "2022-01-28", "15:30", 1));
        // when
        underTest.addEvent(event);
        // then
        verify(eventDal).saveEvent(event);
        verify(blockDal, times(130)).saveBlock(any());
    }
}