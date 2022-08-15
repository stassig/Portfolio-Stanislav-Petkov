package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Account;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;


@DataJpaTest
class IAccountRepositoryTest {

    @MockBean
    private IAccountService accountService;

    @Autowired
    private IAccountRepository underTest;

    @AfterEach
    void tearDown() {
        underTest.deleteAll();
    }

    @Test
    void itShouldGetAccountByAccountId() {
        // given
        Account savedAccount =
                underTest.save(new Account("test", "test", "test@gmail.com", "USER"));

        // when
        Account expected = underTest.getAccountByAccountId(savedAccount.getAccountId());

        // then
        assertThat(expected).isEqualTo(savedAccount);
    }

    @Test
    void itShouldGetAccountByUsername() {
        // given
        Account savedAccount =
                underTest.save(new Account("test", "test", "test@gmail.com", "USER"));

        // when
        Account expected = underTest.getAccountByUsername(savedAccount.getUsername());

        // then
        assertThat(expected).isEqualTo(savedAccount);
    }

    @Test
    void itShouldCheckIfAccountExistsByUsernameAndPassword() {
        // given
        Account savedAccount =
                underTest.save(new Account("test", "test", "test@gmail.com", "USER"));

        // when
        Boolean expected = underTest.existsAccountByUsernameAndPassword(savedAccount.getUsername(), savedAccount.getPassword());

        // then
        assertThat(expected).isTrue();
    }

    @Test
    void itShouldCheckIfAccountExistsByUsername() {
        // given
        Account savedAccount =
                underTest.save(new Account("test", "test", "test@gmail.com", "USER"));

        // when
        Boolean expected = underTest.existsAccountByUsername(savedAccount.getUsername());

        // then
        assertThat(expected).isTrue();
    }

    @Test
    void itShouldCheckIfAccountExistsByEmail() {
        // given
        Account savedAccount =
                underTest.save(new Account("test", "test", "test@gmail.com", "USER"));

        // when
        Boolean expected = underTest.existsAccountByEmail(savedAccount.getEmail());

        // then
        assertThat(expected).isTrue();
    }
}