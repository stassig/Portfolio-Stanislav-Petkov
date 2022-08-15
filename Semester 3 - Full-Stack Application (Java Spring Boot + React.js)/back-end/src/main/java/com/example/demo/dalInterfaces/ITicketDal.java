package com.example.demo.dalInterfaces;

import com.example.demo.models.Ticket;

import java.util.List;

public interface ITicketDal {

    List<Ticket> getTicketsByUsername(String username);

    void addTicket(Ticket ticket);
}
