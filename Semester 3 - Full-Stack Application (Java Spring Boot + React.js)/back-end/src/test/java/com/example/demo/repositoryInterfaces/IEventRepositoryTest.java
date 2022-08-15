package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Event;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import java.util.List;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;


@DataJpaTest
class IEventRepositoryTest {

    @MockBean
    private IAccountService accountService;

    @Autowired
    private IEventRepository underTest;

    @AfterEach
    void tearDown() {
        underTest.deleteAll();
    }

    @Test
    void itShouldGetEventByEventId() {
        // given
        Event savedEvent =
                underTest.save(new Event("Champions League", 45f, "2022-01-28", "18:30", 1));

        // when
        Event expected = underTest.getEventByEventId(savedEvent.getEventId());

        // then
        assertThat(expected).isEqualTo(savedEvent);
    }

    @Test
    void itShouldGetEventsByDateAfterOrderByDate() {
        // given
        underTest.save(new Event("Champions League", 45f, "2022-01-17", "18:30", 1));
        underTest.save(new Event("Champions League", 45f, "2022-01-30", "18:30", 2));
        underTest.save(new Event("Champions League", 45f, "2022-01-28", "18:30", 5));

        // when
        List<Event> events = underTest.getEventsByDateAfterOrderByDate("2022-01-27");
        int count = events.size();
        int team = events.get(0).getTeamId();

        // then
        assertThat(count).isEqualTo(2);
        assertThat(team).isEqualTo(5);
    }

    @Test
    void itShouldDeleteByEventId() {
        // given
        underTest.save(new Event("Champions League", 45f, "2022-01-30", "18:30", 2));
        underTest.save(new Event("Champions League", 45f, "2022-01-28", "18:30", 5));
        Event savedEvent =
                underTest.save(new Event("Champions League", 45f, "2022-01-17", "18:30", 1));

        // when
        underTest.deleteByEventId(savedEvent.getEventId());
        int count = underTest.findAll().size();

        // then
        assertThat(count).isEqualTo(2);
    }
}