package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Ticket;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ITicketRepository extends JpaRepository<Ticket, Integer> {

    List<Ticket> getTicketsByUsernameOrderByTicketIdDesc(String username);

}
