package com.example.demo;

import com.example.demo.configuration.AuthenticationUserDetailsService;
import com.example.demo.serviceInterfaces.IAccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;


@SpringBootApplication
public class TicketingServiceApplication {

    public static void main(String[] args) {
        SpringApplication.run(TicketingServiceApplication.class, args);
    }

    @Bean
    public BCryptPasswordEncoder bCryptPasswordEncoder() {
        return new BCryptPasswordEncoder();
    }

    @Autowired
    IAccountService accountService;

    @Bean
    public AuthenticationUserDetailsService authenticationUserDetailsService() {

        return new AuthenticationUserDetailsService(accountService);
    }
}
