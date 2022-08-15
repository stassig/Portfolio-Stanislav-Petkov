package com.example.demo.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@AllArgsConstructor
@NoArgsConstructor
public class AccountDTO {

    private Integer accountId;

    private String username;

    private String password;

    private String email;

    private String role;

    private String firstName;

    private String lastName;

    private String gender;

    private String phoneNumber;

    public AccountDTO(String username, String password, String email, String role) {
        this.username = username;
        this.password = password;
        this.email = email;
        this.role = role;
    }

    public AccountDTO( String firstName, String lastName, String gender, String phoneNumber, String email){
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
        this.phoneNumber = phoneNumber;
        this.email = email;
    }

    public AccountDTO(String username, String password, String email, String role, String firstName, String lastName, String gender, String phoneNumber) {
        this.username = username;
        this.password = password;
        this.email = email;
        this.role = role;
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
        this.phoneNumber = phoneNumber;
    }
}