package com.example.demo.controllers;

import com.example.demo.DTOs.EventDTO;
import com.example.demo.DTOs.messages.MessageResponse;
import com.example.demo.models.Category;
import com.example.demo.models.Event;
import com.example.demo.models.Team;
import com.example.demo.serviceInterfaces.ICategoryService;
import com.example.demo.serviceInterfaces.IEventService;
import com.example.demo.serviceInterfaces.ITeamService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/events")
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*")
public class EventsController {

    @Autowired
    private IEventService eventService;

    @Autowired
    private ITeamService teamService;

    @Autowired
    private ICategoryService categoryService;

    @PostMapping()
    public ResponseEntity<?> addEvent(@RequestBody EventDTO eventDTO) {
        Team opponent = this.teamService.getTeamByName(eventDTO.getTeamName());
        if (opponent != null) {
            this.eventService.addEvent(new Event(eventDTO.getLeague(), eventDTO.getTicketPrice(), eventDTO.getDate(), eventDTO.getTime(), opponent.getTeamId()));
            return ResponseEntity.ok(new MessageResponse("The event was scheduled successfully!"));
        }
        return ResponseEntity.badRequest().body(new MessageResponse("Team with this name doesn't exist."));
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getEventByID(@PathVariable(value = "id") int id, @RequestParam(value = "categoryId") Optional<Integer> categoryId) {
        Event event = this.eventService.getEventById(id);

        if (event != null) {

            Team opponent = this.teamService.getTeamByTeamId(event.getTeamId());
            EventDTO eventDTO = new EventDTO();
            if (categoryId.isPresent()) {
                Category category = categoryService.getCategoryByCategoryId(categoryId.get());
                Float categoryPrice = event.getTicketPrice() + category.getMultiplier();
                String catName = category.getName().replace("Category","");
                eventDTO = new EventDTO(opponent.getName(), event.getLeague(), event.getDate(), event.getTime(), catName, categoryPrice);
            } else {
                eventDTO = new EventDTO(event.getEventId(), event.getLeague(), event.getTicketPrice(), event.getDate(), event.getTime(), opponent.getTeamId(), opponent.getName(), opponent.getLogo());
            }
            return ResponseEntity.ok().body(eventDTO);
        }
        return ResponseEntity.notFound().build();
    }

    @GetMapping()
    public ResponseEntity<?> getAllCurrentEvents() {
        List<Event> events = this.eventService.getCurrentEvents();

        if (events != null) {
            List<EventDTO> eventDTOs = new ArrayList<>();
            for (Event event : events) {
                Team opponent = this.teamService.getTeamByTeamId(event.getTeamId());
                eventDTOs.add(new EventDTO(event.getEventId(), event.getLeague(), event.getTicketPrice(), event.getDate(), event.getTime(), opponent.getTeamId(), opponent.getName(), opponent.getLogo()));
            }
            return ResponseEntity.ok().body(eventDTOs);
        }
        return ResponseEntity.notFound().build();
    }

    @DeleteMapping()
    public ResponseEntity<?> deletePost(@RequestParam("id") int id) {
        this.eventService.deleteEvent(id);
        return ResponseEntity.ok(new MessageResponse("The event was deleted successfully!"));
    }

    @PutMapping()
    public ResponseEntity<?> updateEvent(@RequestBody EventDTO eventDTO) {
        Team opponent = this.teamService.getTeamByName(eventDTO.getTeamName());
        if (opponent != null) {
            Event event = new Event(eventDTO.getEventId(), eventDTO.getLeague(), eventDTO.getTicketPrice(), eventDTO.getDate(), eventDTO.getTime(), opponent.getTeamId());
            this.eventService.editEvent(event);
            return ResponseEntity.ok(new MessageResponse("The event was edited successfully!"));
        } else {
            return ResponseEntity.badRequest().body(new MessageResponse("Team with this name doesn't exist."));
        }
    }

}


