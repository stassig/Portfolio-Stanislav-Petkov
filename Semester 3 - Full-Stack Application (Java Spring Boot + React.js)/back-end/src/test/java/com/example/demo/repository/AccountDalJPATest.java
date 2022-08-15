package com.example.demo.repository;

import com.example.demo.models.Account;
import com.example.demo.repositoryInterfaces.IAccountRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class AccountDalJPATest {

    @Mock
    private IAccountRepository accountRepository;
    @Mock
    private BCryptPasswordEncoder passwordEncoder;

    private AccountDalJPA underTest;

    @BeforeEach
    void setUp() {
        underTest = new AccountDalJPA(accountRepository, passwordEncoder);
    }

    @Test
    void getAccountById() {
        // when
        underTest.getAccountById(1);
        // then
        verify(accountRepository).getAccountByAccountId(1);
    }

    @Test
    void getAccountByUsername() {
        // when
        underTest.getAccountByUsername("stanislav");
        // then
        verify(accountRepository).getAccountByUsername("stanislav");
    }

    @Test
    void canGetAllAccounts() {
        // when
        underTest.getAllAccounts();
        // then
        verify(accountRepository).findAll();
    }

    @Test
    void canAddAccount() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");
        // when
        underTest.addAccount(account);
        // then
        verify(accountRepository).existsAccountByUsername(account.getUsername());
        verify(accountRepository).existsAccountByEmail(account.getEmail());
        verify(accountRepository).save(account);
        verify(passwordEncoder).encode("test");
    }

    @Test
    void accountWithThisUsernameAlreadyExists() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");

        given(accountRepository.existsAccountByUsername(account.getUsername()))
                .willReturn(true);
        // when
        int result = underTest.addAccount(account);
        // then
        assertThat(result).isEqualTo(-1);
    }

    @Test
    void accountWithThisEmailAlreadyExists() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");

        given(accountRepository.existsAccountByEmail(account.getEmail()))
                .willReturn(true);
        // when
        int result = underTest.addAccount(account);
        // then
        assertThat(result).isEqualTo(-2);
    }

    @Test
    void canEditAccount() {
        // given
        Account account = new Account("test", "test", "test@gmail.com", "USER");
        // when
        underTest.editAccount(account);
        // then
        verify(accountRepository).save(account);
    }

    @Test
    void checkIfUserCredentialsAreValid() {
        // when
        underTest.checkCredentials("stanislav","password");
        // then
        verify(accountRepository).existsAccountByUsernameAndPassword("stanislav", "password");
    }

    @Test
    void canChangePassword() {
        // given
        String currentPassword = "test";
        String newPassword = "password1";
        Account account = new Account("test", "test", "test@gmail.com", "USER");

        given(passwordEncoder.matches(currentPassword, account.getPassword()))
                .willReturn(true);
        // when
        boolean result = underTest.changePassword(currentPassword, newPassword, account);
        // then
        assertThat(result).isTrue();
    }

    @Test
    void changePasswordFailure() {
        // given
        String currentPassword = "test";
        String newPassword = "password1";
        Account account = new Account("test", "test", "test@gmail.com", "USER");

        given(passwordEncoder.matches(currentPassword, account.getPassword()))
                .willReturn(false);
        // when
        boolean result = underTest.changePassword(currentPassword, newPassword, account);
        // then
        assertThat(result).isFalse();
        verify(accountRepository, times(0)).save(any());
    }
}