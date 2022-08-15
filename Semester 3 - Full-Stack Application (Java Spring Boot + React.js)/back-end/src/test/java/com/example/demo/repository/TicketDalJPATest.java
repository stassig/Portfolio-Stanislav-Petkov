package com.example.demo.repository;

import com.example.demo.models.Ticket;
import com.example.demo.repositoryInterfaces.ITicketRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.verify;


@ExtendWith(MockitoExtension.class)
class TicketDalJPATest {

    @Mock
    private ITicketRepository ticketRepository;
    private TicketDalJPA underTest;

    @BeforeEach
    void setUp() {
        underTest = new TicketDalJPA(ticketRepository);
    }

    @Test
    void canGetTicketsByUsername() {
        // when
        underTest.getTicketsByUsername("stanislav");
        // then
        verify(ticketRepository).getTicketsByUsernameOrderByTicketIdDesc("stanislav");
    }

    @Test
    void canAddTicket() {
        // given
        Ticket ticket =
                new Ticket("Category 1", 109, "7-8", 50f, 250f, "Stanislav Petkov", 1, "john1");
        // when
        underTest.addTicket(ticket);
        // then
        verify(ticketRepository).save(ticket);
    }
}