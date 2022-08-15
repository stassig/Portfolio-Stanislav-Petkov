package com.example.demo.service;

import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.dalInterfaces.IEventDal;
import com.example.demo.models.Block;
import com.example.demo.models.Event;
import com.example.demo.serviceInterfaces.IEventService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
public class EventService implements IEventService {

    private IEventDal eventDal;

    private IBlockDal blockDal;

    @Autowired
    public EventService(IEventDal eventDal, IBlockDal blockDal) {
        this.eventDal = eventDal;
        this.blockDal = blockDal;
//        this.addEvent(new Event("Champions League", 45f, "2022-01-28", "15:30", 1));
//        this.saveEvent(new Event("European Cup", 50f, "2022-02-13", "19:30", 2));

    }

    @Override
    public Event getEventById(int id) {
        return this.eventDal.getEventById(id);
    }

    @Override
    public List<Event> getAllEvents() {
        return this.eventDal.getAllEvents();
    }

    @Override
    public List<Event> getCurrentEvents() {
        return this.eventDal.getCurrentEvents();
    }

    @Transactional
    @Override
    public void deleteEvent(int eventId) {
        this.eventDal.deleteEvent(eventId);
    }

    @Override
    public void editEvent(Event event) {
        this.eventDal.saveEvent(event);
    }

    @Override
    public void addEvent(Event event) {
        Event savedEvent = this.eventDal.saveEvent(event);
        Integer eventId = savedEvent.getEventId();
        this.generateBlocks(eventId);
    }

    private void generateBlocks(Integer eventId) {

        for (int i = 101; i <= 347; i++) {

            // 101 - 136
            if (i <= 136) {
                if (isBetween(i, 101, 106) || isBetween(i, 119, 124)) {
                    this.blockDal.saveBlock(new Block(eventId, 8, i, 100));
                } else if (isBetween(i, 109, 117) || isBetween(i, 126, 134)) {
                    this.blockDal.saveBlock(new Block(eventId, 1, i, 100));
                } else if (i == 136) {
                    this.blockDal.saveBlock(new Block(eventId, 7, i, 100));
                    i += 64;
                } else {
                    this.blockDal.saveBlock(new Block(eventId, 7, i, 100));
                }
            }
            // 201 - 247
            else if (i <= 247) {
                if (isBetween(i, 201, 213) || isBetween(i, 228, 233)) {
                    this.blockDal.saveBlock(new Block(eventId, 8, i, 100));
                } else if (isBetween(i, 216, 225) || isBetween(i, 236, 245)) {
                    this.blockDal.saveBlock(new Block(eventId, 4, i, 100));
                } else if (i == 247) {
                    this.blockDal.saveBlock(new Block(eventId, 7, i, 100));
                    i += 53;
                } else {
                    this.blockDal.saveBlock(new Block(eventId, 7, i, 100));
                }
            }
            // 301 - 347
            else {
                if (isBetween(i, 312, 319) || isBetween(i, 336, 343)) {
                    this.blockDal.saveBlock(new Block(eventId, 2, i, 100));
                } else if (i == 303 || i == 304 || i == 327 || i == 328) {
                    this.blockDal.saveBlock(new Block(eventId, 6, i, 100));
                } else if (isBetween(i, 308, 311) || isBetween(i, 320, 323) ||
                        isBetween(i, 332, 335) || isBetween(i, 344, 347)) {
                    this.blockDal.saveBlock(new Block(eventId, 3, i, 100));
                } else {
                    this.blockDal.saveBlock(new Block(eventId, 5, i, 100));
                }
            }
        }
    }

    private boolean isBetween(int x, int lower, int upper) {
        return lower <= x && x <= upper;
    }

}
