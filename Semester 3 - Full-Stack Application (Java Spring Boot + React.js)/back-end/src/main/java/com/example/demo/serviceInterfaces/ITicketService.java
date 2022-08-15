package com.example.demo.serviceInterfaces;

import com.example.demo.DTOs.TicketDTO;
import com.example.demo.models.Ticket;

import java.util.List;

public interface ITicketService {

    List<Ticket> getTicketsByUsername(String username);

    boolean addTicket(TicketDTO ticketDTO, String username);

}
