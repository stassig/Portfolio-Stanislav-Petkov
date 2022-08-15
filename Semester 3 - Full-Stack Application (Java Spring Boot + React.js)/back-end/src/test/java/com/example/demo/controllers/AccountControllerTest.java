package com.example.demo.controllers;

import com.example.demo.DTOs.AccountDTO;
import com.example.demo.DTOs.PasswordDTO;
import com.example.demo.models.Account;
import com.example.demo.serviceInterfaces.IAccountService;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import static org.mockito.ArgumentMatchers.*;
import static org.mockito.Mockito.*;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.csrf;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;


@WebMvcTest(AccountController.class)
class AccountControllerTest {

    private MockMvc mockMvc;
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
                .apply(springSecurity())
                .build();
    }

    @Test
    void userRegistrationSuccessful() throws Exception {
        // given
        AccountDTO accountDTO = new AccountDTO("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.addAccount(any())).thenReturn(0);

        // when
        mockMvc.perform(post("/users")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(accountDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // then
        verify(accountService).addAccount(any());
    }

    @Test
    void userRegistrationUsernameAlreadyTaken() throws Exception {
        // given
        AccountDTO accountDTO = new AccountDTO("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.addAccount(any())).thenReturn(-1);

        // when
        mockMvc.perform(post("/users")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(accountDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());

        // then
        verify(accountService).addAccount(any());
    }

    @Test
    void userRegistrationEmailAlreadyTaken() throws Exception {
        // given
        AccountDTO accountDTO = new AccountDTO("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.addAccount(any())).thenReturn(-2);

        // when
        mockMvc.perform(post("/users")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(accountDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());

        // then
        verify(accountService).addAccount(any());
    }

    @Test
    void getUserDetailsSuccess() throws Exception {
        // given
        Account account = new Account("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.getAccountByUsername(any())).thenReturn(account);

        // when
        mockMvc.perform(
                get("/users")
                        .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                        .with(csrf()))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(accountService).getAccountByUsername("stan");
    }

    @Test
    void getUserDetailsFailure() throws Exception {
        // given
        when(accountService.getAccountByUsername(any())).thenReturn(null);

        // when
        mockMvc.perform(
                get("/users")
                        .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                        .with(csrf()))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(accountService).getAccountByUsername("stan");
    }

    @Test
    void editUserDetailsSuccessfully() throws Exception {
        // given
        AccountDTO accountDTO = new AccountDTO("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        Account account = new Account("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.getAccountByUsername(any())).thenReturn(account);

        // when
        mockMvc.perform(put("/users")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(accountDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // then
        verify(accountService).getAccountByUsername("stan");
        verify(accountService).editAccount(any());
    }

    @Test
    void editUserDetailsFailure() throws Exception {
        // given
        AccountDTO accountDTO = new AccountDTO("stan", "stan", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.getAccountByUsername(any())).thenReturn(null);

        // when
        mockMvc.perform(put("/users")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(accountDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isNotFound());

        // then
        verify(accountService).getAccountByUsername("stan");
        verify(accountService, times(0)).editAccount(any());
    }

    @Test
    void changePasswordSuccessfully() throws Exception {
        // given
        PasswordDTO passwordDTO = new PasswordDTO("test", "password");
        Account account = new Account("stan", "test", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.getAccountByUsername(any())).thenReturn(account);
        when(accountService.changePassword("test", "password", account)).thenReturn(true);

        // when
        mockMvc.perform(put("/users/passwordChange")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(passwordDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // then
        verify(accountService).getAccountByUsername("stan");
        verify(accountService).changePassword("test", "password", account);
    }

    @Test
    void changePasswordButCurrentPasswordNotMatching() throws Exception {
        // given
        PasswordDTO passwordDTO = new PasswordDTO("test123", "password");
        Account account = new Account("stan", "test", "stan@gmail.com", "USER", "Stanislav", "Petkov", "Male", "359545232323");
        when(accountService.getAccountByUsername(anyString())).thenReturn(account);
        when(accountService.changePassword("test123", "password", account)).thenReturn(false);

        // when
        mockMvc.perform(put("/users/passwordChange")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(passwordDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());

        // then
        verify(accountService).getAccountByUsername("stan");
        verify(accountService).changePassword("test123", "password", account);
    }

    @Test
    void changePasswordFailure() throws Exception {
        // given
        PasswordDTO passwordDTO = new PasswordDTO("test", "password");
        when(accountService.getAccountByUsername(anyString())).thenReturn(null);

        // when
        mockMvc.perform(put("/users/passwordChange")
                .with(SecurityMockMvcRequestPostProcessors.user("stan").roles("USER"))
                .with(csrf())
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(passwordDTO))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isNotFound());

        // then
        verify(accountService).getAccountByUsername("stan");
        verify(accountService, times(0)).changePassword(anyString(),anyString(),any());
    }
}