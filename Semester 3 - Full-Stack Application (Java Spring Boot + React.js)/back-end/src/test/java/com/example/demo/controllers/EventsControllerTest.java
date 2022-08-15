package com.example.demo.controllers;

import com.example.demo.DTOs.EventDTO;
import com.example.demo.models.Category;
import com.example.demo.models.Event;
import com.example.demo.models.Team;
import com.example.demo.serviceInterfaces.IAccountService;
import com.example.demo.serviceInterfaces.ICategoryService;
import com.example.demo.serviceInterfaces.IEventService;
import com.example.demo.serviceInterfaces.ITeamService;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import java.util.ArrayList;
import java.util.List;

import static org.mockito.ArgumentMatchers.*;
import static org.mockito.Mockito.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(EventsController.class)
class EventsControllerTest {

    private MockMvc mockMvc;
    @MockBean
    private IEventService eventService;
    @MockBean
    private ITeamService teamService;
    @MockBean
    private ICategoryService categoryService;
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
                .build();
    }

    @Test
    void addEventSuccess() throws Exception{
        // given
        EventDTO eventDTO = new EventDTO("Champions League", 45f, "2022-01-17", "18:30", "Barcelona");
        Team team = new Team(1000,"Barcelona", "/BarcelonaLogo.png");
        when(teamService.getTeamByName(any())).thenReturn(team);

        // when
        mockMvc.perform(post("/events")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(eventDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // then
        verify(teamService).getTeamByName(any());
        verify(eventService).addEvent(any());
    }

    @Test
    void addEventFailure() throws Exception{
        // given
        EventDTO eventDTO = new EventDTO("Champions League", 45f, "2022-01-17", "18:30", "Barcelona");
        when(teamService.getTeamByName(any())).thenReturn(null);

        // when
        mockMvc.perform(post("/events")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(eventDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());

        // then
        verify(teamService).getTeamByName(any());
        verify(eventService, times(0)).addEvent(any());
    }

    @Test
    void getFullEventInfo() throws Exception {
        // given
        Event event = new Event("Champions League", 45f, "2022-01-17", "18:30", 1);
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");
        Category category = new Category("Category 1 Gold", "Short Side.", 10f);
        when(eventService.getEventById(1)).thenReturn(event);
        when(teamService.getTeamByTeamId(1)).thenReturn(team);
        when(categoryService.getCategoryByCategoryId(2)).thenReturn(category);

        // when
        mockMvc.perform(
                get("/events/1?categoryId=2"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(eventService).getEventById(1);
        verify(teamService).getTeamByTeamId(1);
        verify(categoryService).getCategoryByCategoryId(2);
    }

    @Test
    void getShortEventInfo() throws Exception {
        // given
        Event event = new Event("Champions League", 45f, "2022-01-17", "18:30", 1);
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");
        when(eventService.getEventById(1)).thenReturn(event);
        when(teamService.getTeamByTeamId(1)).thenReturn(team);

        // when
        mockMvc.perform(
                get("/events/1"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(eventService).getEventById(1);
        verify(teamService).getTeamByTeamId(1);
        verify(categoryService, times(0)).getCategoryByCategoryId(anyInt());
    }

    @Test
    void getEventInfoFailure() throws Exception {
        // given
        when(eventService.getEventById(1)).thenReturn(null);

        // when
        mockMvc.perform(
                get("/events/1"))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(eventService).getEventById(1);
        verify(teamService, times(0)).getTeamByTeamId(1);
        verify(categoryService, times(0)).getCategoryByCategoryId(anyInt());
    }

    @Test
    void getAllCurrentEventsSuccess() throws Exception {
        // given
        List<Event> events = new ArrayList<>();
        events.add(new Event("Champions League", 45f, "2022-01-17", "18:30", 1));
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");
        when(eventService.getCurrentEvents()).thenReturn(events);
        when(teamService.getTeamByTeamId(1)).thenReturn(team);

        // when
        mockMvc.perform(
                get("/events"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(eventService).getCurrentEvents();
        verify(teamService).getTeamByTeamId(1);
    }

    @Test
    void getAllCurrentEventsFail() throws Exception {
        // given
        when(eventService.getCurrentEvents()).thenReturn(null);

        // when
        mockMvc.perform(
                get("/events"))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(eventService).getCurrentEvents();
        verify(teamService, times(0)).getTeamByTeamId(anyInt());
    }

    @Test
    void deletePost() throws Exception {
        // when
        mockMvc.perform(
                delete("/events?id=1"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(eventService).deleteEvent(1);
    }

    @Test
    void updateEventSuccess() throws Exception {
        // given
        EventDTO eventDTO = new EventDTO("Champions League", 45f, "2022-01-17", "18:30", "Barcelona");
        Team team = new Team(1000,"Barcelona", "/BarcelonaLogo.png");
        when(teamService.getTeamByName(anyString())).thenReturn(team);

        // when
        mockMvc.perform(put("/events")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(eventDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // then
        verify(teamService).getTeamByName(any());
        verify(eventService).editEvent(any());
    }

    @Test
    void updateEventFailure() throws Exception {
        // given
        EventDTO eventDTO = new EventDTO("Champions League", 45f, "2022-01-17", "18:30", "Barcelona");
        when(teamService.getTeamByName(any())).thenReturn(null);

        // when
        mockMvc.perform(put("/events")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(eventDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());

        // then
        verify(teamService).getTeamByName(any());
        verify(eventService, times(0)).editEvent(any());
    }
}