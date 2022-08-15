package com.example.demo.service;

import com.example.demo.dalInterfaces.IAccountDal;
import com.example.demo.models.Account;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.verify;


@ExtendWith(MockitoExtension.class)
class AccountServiceTest {

    @Mock
    private IAccountDal accountDal;
    private AccountService underTest;

    @BeforeEach
    void setUp() {
        underTest = new AccountService(accountDal);
    }

    @Test
    void canGetAccountById() {
        // when
        underTest.getAccountById(1);
        // then
        verify(accountDal).getAccountById(1);
    }

    @Test
    void canGetAccountByUsername() {
        // when
        underTest.getAccountByUsername("stanislav");
        // then
        verify(accountDal).getAccountByUsername("stanislav");
    }

    @Test
    void canGetAllAccounts() {
        // when
        underTest.getAllAccounts();
        // then
        verify(accountDal).getAllAccounts();
    }

    @Test
    void canAddAccount() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");
        // when
        underTest.addAccount(account);
        // then
        verify(accountDal).addAccount(account);
    }

    @Test
    void canEditAccount() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");
        // when
        underTest.editAccount(account);
        // then
        verify(accountDal).editAccount(account);
    }

    @Test
    void canCheckCredentials() {
        // when
        underTest.checkCredentials("stanislav", "password");
        // then
        verify(accountDal).checkCredentials("stanislav", "password");
    }

    @Test
    void canChangePassword() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");
        // when
        underTest.changePassword("test", "password1", account);
        // then
        verify(accountDal).changePassword("test", "password1", account);
    }
}