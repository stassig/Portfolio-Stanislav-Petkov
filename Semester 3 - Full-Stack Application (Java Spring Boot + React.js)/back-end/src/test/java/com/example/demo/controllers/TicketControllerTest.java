package com.example.demo.controllers;

import com.example.demo.DTOs.TicketDTO;
import com.example.demo.models.Event;
import com.example.demo.models.Team;
import com.example.demo.models.Ticket;
import com.example.demo.serviceInterfaces.IAccountService;
import com.example.demo.serviceInterfaces.IEventService;
import com.example.demo.serviceInterfaces.ITeamService;
import com.example.demo.serviceInterfaces.ITicketService;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import java.util.ArrayList;
import java.util.List;

import static org.mockito.ArgumentMatchers.anyInt;
import static org.mockito.Mockito.*;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.csrf;
import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(TicketController.class)
class TicketControllerTest {

    private MockMvc mockMvc;
    @MockBean
    private ITicketService ticketService;
    @MockBean
    private IEventService eventService;
    @MockBean
    private ITeamService teamService;
    @MockBean
    private IAccountService accountService;
    @Autowired
    private ObjectMapper objectMapper;
    @Autowired
    private WebApplicationContext context;

    @BeforeEach
    public void setup() {
        this.mockMvc = MockMvcBuilders
                .webAppContextSetup(this.context)
                .apply(springSecurity())
                .build();
    }

    @Test
    void addTicketSuccess() throws Exception {
        // given
        TicketDTO ticketDTO = new TicketDTO(
                "Category 1", 108, 50f, 150f,
                "John Smith", 1, "stanislav",
                3, 100, 3
        );
        when(ticketService.addTicket(ticketDTO, "stan")).thenReturn(true);

        // when
        mockMvc.perform(post("/tickets")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(ticketDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // then
        verify(ticketService).addTicket(ticketDTO, "stan");
    }

    @Test
    void addTicketFailure() throws Exception {
        // given
        TicketDTO ticketDTO = new TicketDTO(
                "Category 1", 108, 50f, 150f,
                "John Smith", 1, "stanislav",
                3, 100, 3
        );
        when(ticketService.addTicket(ticketDTO, "stan")).thenReturn(false);

        // when
        mockMvc.perform(post("/tickets")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(ticketDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());

        // then
        verify(ticketService).addTicket(ticketDTO, "stan");
    }

    @Test
    void getTicketsByUserSuccess() throws Exception {
        // given
        List<Ticket> tickets = new ArrayList<>();
        tickets.add(new Ticket("Category 1", 109, "7-8", 50f, 250f, "Stanislav Petkov", 1, "john1"));
        Team team = new Team(1000, "Barcelona", "/BarcelonaLogo.png");
        Event event = new Event("Champions League", 45f, "2022-01-17", "18:30", 1);
        when(ticketService.getTicketsByUsername("stan")).thenReturn(tickets);
        when(eventService.getEventById(anyInt())).thenReturn(event);
        when(teamService.getTeamByTeamId(anyInt())).thenReturn(team);

        // when
        mockMvc.perform(
                get("/tickets")
                        .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                        .with(csrf()))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(ticketService).getTicketsByUsername("stan");
        verify(eventService).getEventById(anyInt());
        verify(teamService).getTeamByTeamId(anyInt());
    }

    @Test
    void getTicketsByUserFailure() throws Exception {
        // given
        when(ticketService.getTicketsByUsername("stan")).thenReturn(null);

        // when
        mockMvc.perform(
                get("/tickets")
                        .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                        .with(csrf()))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(ticketService).getTicketsByUsername("stan");
        verify(eventService, times(0)).getEventById(anyInt());
        verify(teamService, times(0)).getTeamByTeamId(anyInt());
    }
}