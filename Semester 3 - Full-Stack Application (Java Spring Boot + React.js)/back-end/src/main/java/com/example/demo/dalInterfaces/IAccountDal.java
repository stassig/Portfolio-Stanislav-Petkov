package com.example.demo.dalInterfaces;

import com.example.demo.models.Account;

import java.util.List;

public interface IAccountDal {

    Account getAccountById(int id);

    Account getAccountByUsername(String username);

    List<Account> getAllAccounts();

    int addAccount(Account account);

    void editAccount(Account account);

    boolean checkCredentials(String username, String password);

    boolean changePassword(String currentPassword, String newPassword, Account account);
}
