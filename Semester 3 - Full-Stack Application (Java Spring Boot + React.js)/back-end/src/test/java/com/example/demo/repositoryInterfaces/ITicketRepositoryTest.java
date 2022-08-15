package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Team;
import com.example.demo.models.Ticket;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.junit.jupiter.api.Assertions.*;

@DataJpaTest
class ITicketRepositoryTest {

    @MockBean
    private IAccountService accountService;

    @Autowired
    private ITicketRepository underTest;

    @AfterEach
    void tearDown() {
        underTest.deleteAll();
    }

    @Test
    void itShouldGetTicketsByUsernameOrderByTicketIdDesc() {
        // given
        underTest.save(new Ticket("Category 1", 109, "7-8", 50f, 250f, "Stanislav Petkov", 1, "john1"));
        underTest.save(new Ticket("Category 1", 109, "1-4", 50f, 250f, "Stanislav Petkov", 1, "stassig"));
        underTest.save(new Ticket("Category 1", 109, "5-6", 50f, 150f, "Stanislav Petkov", 1, "stassig"));

        // when
        int count = underTest.getTicketsByUsernameOrderByTicketIdDesc("stassig").size();

        // then
        assertThat(count).isEqualTo(2);
    }
}