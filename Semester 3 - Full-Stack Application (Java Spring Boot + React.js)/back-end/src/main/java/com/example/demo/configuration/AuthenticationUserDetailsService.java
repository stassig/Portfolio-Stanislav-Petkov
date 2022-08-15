package com.example.demo.configuration;

import com.example.demo.models.Account;

import com.example.demo.serviceInterfaces.IAccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.Collection;
import java.util.Arrays;

import lombok.RequiredArgsConstructor;

@Service
public class AuthenticationUserDetailsService implements UserDetailsService {

    private final IAccountService userService;

    @Autowired
    public AuthenticationUserDetailsService(IAccountService accountService){
        this.userService = accountService;
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        Account account = userService.getAccountByUsername(username);
        if (account == null) {
            throw new UsernameNotFoundException(username);
        }
        return new org.springframework.security.core.userdetails.User(account.getUsername(), account.getPassword(), getAuthorities(account.getRole()));
    }

    private Collection<? extends GrantedAuthority> getAuthorities(String role) {
        return Arrays.asList(new SimpleGrantedAuthority(role));
    }
}