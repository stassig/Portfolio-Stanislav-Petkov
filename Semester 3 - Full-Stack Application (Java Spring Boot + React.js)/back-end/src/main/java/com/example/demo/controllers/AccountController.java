package com.example.demo.controllers;

import com.example.demo.DTOs.AccountDTO;
import com.example.demo.DTOs.PasswordDTO;
import com.example.demo.models.Account;
import com.example.demo.DTOs.messages.MessageResponse;
import com.example.demo.serviceInterfaces.IAccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.*;

import java.security.Principal;
import java.sql.SQLOutput;

@RestController
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*")
@RequestMapping("/users")
public class AccountController {

    @Autowired
    private IAccountService service;


    @PostMapping()
    public ResponseEntity<?> userRegistration(@RequestBody AccountDTO accountDTO) {

        int registrationResult = this.service.addAccount(new Account(accountDTO.getUsername(), accountDTO.getPassword(), accountDTO.getEmail(), accountDTO.getRole(), accountDTO.getFirstName(), accountDTO.getLastName(), accountDTO.getGender(), accountDTO.getPhoneNumber()));

        if (registrationResult == -1) {
            return ResponseEntity.badRequest().body(new MessageResponse("User with this username already exists."));
        } else if (registrationResult == -2) {
            return ResponseEntity.badRequest().body(new MessageResponse("User with this email already exists."));
        } else {
            return ResponseEntity.ok(new MessageResponse("You have signed up successfully!"));
        }
    }

    @GetMapping()
    public ResponseEntity<?> getUserDetails(Principal principal) {

        Account account = this.service.getAccountByUsername(principal.getName());
        if (account != null) {
            return ResponseEntity.ok().body(new AccountDTO(account.getFirstName(), account.getLastName(), account.getGender(), account.getPhoneNumber(), account.getEmail()));
        }
        return ResponseEntity.notFound().build();
    }

    @PutMapping()
    public ResponseEntity<?> editUserDetails(@RequestBody AccountDTO accountDTO, Principal principal) {

        Account account = this.service.getAccountByUsername(principal.getName());
        if (account != null) {
            account.setFirstName(accountDTO.getFirstName());
            account.setLastName(accountDTO.getLastName());
            account.setGender(accountDTO.getGender());
            account.setPhoneNumber(accountDTO.getPhoneNumber());
            account.setEmail(accountDTO.getEmail());
            this.service.editAccount(account);

            return ResponseEntity.ok(new MessageResponse("Your account information has been updated successfully!"));
        }
        return ResponseEntity.notFound().build();
    }

    @PutMapping("/passwordChange")
    public ResponseEntity<?> changePassword(@RequestBody PasswordDTO passwordDTO, Principal principal) {

        Account account = this.service.getAccountByUsername(principal.getName());
        if (account != null) {
            boolean result = this.service.changePassword(passwordDTO.getCurrentPassword(), passwordDTO.getNewPassword(), account);
            if (result) {
                return ResponseEntity.ok(new MessageResponse("Your password has been updated successfully!"));
            }
            return ResponseEntity.badRequest().body(new MessageResponse("The current password doesn't match your account's password."));
        }
        return ResponseEntity.notFound().build();
    }

}