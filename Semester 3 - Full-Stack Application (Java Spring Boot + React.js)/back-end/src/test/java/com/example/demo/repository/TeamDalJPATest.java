package com.example.demo.repository;

import com.example.demo.models.Team;
import com.example.demo.repositoryInterfaces.ITeamRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.verify;


@ExtendWith(MockitoExtension.class)
class TeamDalJPATest {

    @Mock
    private ITeamRepository teamRepository;
    private TeamDalJPA underTest;

    @BeforeEach
    void setUp() {
        underTest = new TeamDalJPA(teamRepository);
    }

    @Test
    void canGetTeamByName() {
        // when
        underTest.getTeamByName("FC Barcelona");
        // then
        verify(teamRepository).getTeamByName("FC Barcelona");
    }

    @Test
    void canGetTeamByTeamId() {
        // when
        underTest.getTeamByTeamId(1);
        // then
        verify(teamRepository).getTeamByTeamId(1);
    }

    @Test
    void canAddTeam() {
        // given
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");
        // when
        underTest.addTeam(team);
        // then
        verify(teamRepository).existsTeamByName(team.getName());
        verify(teamRepository).existsTeamByLogo(team.getLogo());
        verify(teamRepository).save(team);
    }

    @Test
    void teamWithThisNameAlreadyExists() {
        // given
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");

        given(teamRepository.existsTeamByName(team.getName()))
                .willReturn(true);
        // when
        int result = underTest.addTeam(team);
        // then
        assertThat(result).isEqualTo(-1);
    }

    @Test
    void teamWithThisLogoAlreadyExists() {
        // given
        Team team = new Team("FC Barcelona", "/BarcelonaLogo.png");

        given(teamRepository.existsTeamByLogo(team.getLogo()))
                .willReturn(true);
        // when
        int result = underTest.addTeam(team);
        // then
        assertThat(result).isEqualTo(-2);
    }

    @Test
    void canGetAllTeams() {
        // when
        underTest.getAllTeams();
        // then
        verify(teamRepository).findAll();
    }
}