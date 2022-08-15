package com.example.demo.repository;

import com.example.demo.dalInterfaces.ITicketDal;
import com.example.demo.models.Ticket;
import com.example.demo.repositoryInterfaces.ITicketRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class TicketDalJPA implements ITicketDal {

    private final ITicketRepository repository;

    @Autowired
    public TicketDalJPA(ITicketRepository repository) {
        this.repository = repository;
    }

    @Override
    public List<Ticket> getTicketsByUsername(String username) {
        return repository.getTicketsByUsernameOrderByTicketIdDesc(username);
    }

    @Override
    public void addTicket(Ticket ticket) {
        repository.save(ticket);
    }
}
