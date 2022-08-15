package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Team;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;


@DataJpaTest
class ITeamRepositoryTest {

    @MockBean
    private IAccountService accountService;

    @Autowired
    private ITeamRepository underTest;

    @AfterEach
    void tearDown() {
        underTest.deleteAll();
    }

    @Test
    void itShouldCheckIfTeamExistsByName() {
        // given
        Team savedTeam = underTest.save(new Team("FC Barcelona", "/BarcelonaLogo.png"));

        // when
        Boolean expected = underTest.existsTeamByName(savedTeam.getName());

        // then
        assertThat(expected).isTrue();
    }

    @Test
    void itShouldCheckIfTeamExistsByLogo() {
        // given
        Team savedTeam = underTest.save(new Team("FC Barcelona", "/BarcelonaLogo.png"));

        // when
        Boolean expected = underTest.existsTeamByLogo(savedTeam.getLogo());

        // then
        assertThat(expected).isTrue();
    }

    @Test
    void itShouldGetTeamByName() {
        // given
        Team savedTeam = underTest.save(new Team("FC Barcelona", "/BarcelonaLogo.png"));

        // when
        Team expected = underTest.getTeamByName(savedTeam.getName());

        // then
        assertThat(expected).isEqualTo(savedTeam);
    }

    @Test
    void itShouldGetTeamByTeamId() {
        // given
        Team savedTeam = underTest.save(new Team("FC Barcelona", "/BarcelonaLogo.png"));

        // when
        Team expected = underTest.getTeamByTeamId(savedTeam.getTeamId());

        // then
        assertThat(expected).isEqualTo(savedTeam);
    }
}