package com.example.demo.controllers;

import com.example.demo.DTOs.TicketDTO;
import com.example.demo.DTOs.messages.MessageResponse;
import com.example.demo.models.Event;
import com.example.demo.models.Team;
import com.example.demo.models.Ticket;
import com.example.demo.serviceInterfaces.IEventService;
import com.example.demo.serviceInterfaces.ITeamService;
import com.example.demo.serviceInterfaces.ITicketService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.security.Principal;
import java.util.ArrayList;
import java.util.List;

@RestController
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*")
@RequestMapping("/tickets")
public class TicketController {

    @Autowired
    private ITicketService ticketService;

    @Autowired
    private IEventService eventService;

    @Autowired
    private ITeamService teamService;

    @PostMapping()
    public ResponseEntity<?> addTicket(@RequestBody TicketDTO ticketDTO, Principal principal) {

        boolean result = this.ticketService.addTicket(ticketDTO, principal.getName());

        if (result) {
            return ResponseEntity.ok(new MessageResponse("Your order was successful. You can view your booking from your account page!"));
        }
        return ResponseEntity.badRequest().body(new MessageResponse("The seats in the selected block have been sold out. Please select a new block for your booking!"));
    }

    @GetMapping()
    public ResponseEntity<?> getTicketsByUser(Principal principal) {

        String username = principal.getName();
        List<Ticket> tickets = this.ticketService.getTicketsByUsername(username);

        if (tickets != null) {
            List<TicketDTO> ticketDTOs = new ArrayList<>();
            for (Ticket ticket : tickets) {
                Event event = this.eventService.getEventById(ticket.getEventId());
                Team opponent = this.teamService.getTeamByTeamId(event.getTeamId());

                ticketDTOs.add(new TicketDTO(ticket.getTicketId(), event.getDate(), event.getTime(), ticket.getCategory(), ticket.getBlockNumber(), ticket.getSeats(), ticket.getPricePerSeat(), ticket.getTotalPrice(), ticket.getTicketOwner(), event.getLeague(), ticket.getEventId(), username, opponent.getName(), opponent.getLogo()));
            }
            return ResponseEntity.ok().body(ticketDTOs);
        }
        return ResponseEntity.notFound().build();
    }

}
