package com.example.demo.controllers;

import com.example.demo.DTOs.TeamDTO;
import com.example.demo.models.Category;
import com.example.demo.models.Team;
import com.example.demo.serviceInterfaces.IAccountService;
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

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(TeamsController.class)
class TeamsControllerTest {

    private MockMvc mockMvc;
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
                .build();
    }

    @Test
    void getTeamByNameSuccess() throws Exception {
        // given
        Team team = new Team(1000, "Barcelona", "/BarcelonaLogo.png");
        when(teamService.getTeamByName(team.getName())).thenReturn(team);

        // when
        mockMvc.perform(
                get("/teams/" + team.getName()))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(teamService).getTeamByName(team.getName());
    }

    @Test
    void getTeamByNameFailure() throws Exception {
        // given
        when(teamService.getTeamByName("Barcelona")).thenReturn(null);

        // when
        mockMvc.perform(
                get("/teams/Barcelona"))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(teamService).getTeamByName("Barcelona");
    }

    @Test
    void getAllTeamsSuccess() throws Exception {
        // given
        List<Team> teams = new ArrayList<>();
        teams.add(new Team(1000, "Barcelona", "/BarcelonaLogo.png"));
        when(teamService.getAllTeams()).thenReturn(teams);

        // when
        mockMvc.perform(
                get("/teams"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(teamService).getAllTeams();
    }

    @Test
    void getAllTeamsFailure() throws Exception {
        // given
        when(teamService.getAllTeams()).thenReturn(null);

        // when
        mockMvc.perform(
                get("/teams"))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(teamService).getAllTeams();
    }

    @Test
    void addTeamSuccess() throws Exception {
        // given
        TeamDTO teamDTO = new TeamDTO("Barcelona", "/BarcelonaLogo.png");
        when(teamService.addTeam(any())).thenReturn(0);

        // when
        mockMvc.perform(post("/teams")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(teamDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(teamService).addTeam(any());
    }

    @Test
    void addTeamWithNameAlreadyTaken() throws Exception {
        // given
        TeamDTO teamDTO = new TeamDTO("Barcelona", "/BarcelonaLogo.png");
        when(teamService.addTeam(any())).thenReturn(-1);

        // when
        mockMvc.perform(post("/teams")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(teamDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andDo(print())
                .andExpect(status().isBadRequest());

        // then
        verify(teamService).addTeam(any());
    }

    @Test
    void addTeamWithLogoAlreadyTaken() throws Exception {
        // given
        TeamDTO teamDTO = new TeamDTO("Barcelona", "/BarcelonaLogo.png");
        when(teamService.addTeam(any())).thenReturn(-2);

        // when
        mockMvc.perform(post("/teams")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(teamDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andDo(print())
                .andExpect(status().isBadRequest());

        // then
        verify(teamService).addTeam(any());
    }
}