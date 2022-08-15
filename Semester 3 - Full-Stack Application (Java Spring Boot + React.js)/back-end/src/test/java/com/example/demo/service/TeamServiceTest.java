package com.example.demo.service;

import com.example.demo.dalInterfaces.ITeamDal;
import com.example.demo.models.Team;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class TeamServiceTest {

    @Mock
    private ITeamDal teamDal;
    private TeamService underTest;

    @BeforeEach
    void setUp() {
        underTest = new TeamService(teamDal);
    }

    @Test
    void canGetTeamByName() {
        // when
        underTest.getTeamByName("FC Barcelona");
        // then
        verify(teamDal).getTeamByName("FC Barcelona");
    }

    @Test
    void canGetTeamByTeamId() {
        // when
        underTest.getTeamByTeamId(1);
        // then
        verify(teamDal).getTeamByTeamId(1);
    }

    @Test
    void canAddTeam() {
        // given
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");
        // when
        underTest.addTeam(team);
        // then
        verify(teamDal).addTeam(team);
    }

    @Test
    void canGetAllTeams() {
        // when
        underTest.getAllTeams();
        // then
        verify(teamDal).getAllTeams();
    }
}