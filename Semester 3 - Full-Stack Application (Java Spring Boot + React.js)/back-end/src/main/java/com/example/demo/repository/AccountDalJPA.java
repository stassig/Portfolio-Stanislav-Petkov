package com.example.demo.repository;

import com.example.demo.dalInterfaces.IAccountDal;
import com.example.demo.models.Account;
import com.example.demo.repositoryInterfaces.IAccountRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class AccountDalJPA implements IAccountDal {

    private final BCryptPasswordEncoder passwordEncoder;

    private final IAccountRepository repository;

    @Autowired
    public AccountDalJPA(IAccountRepository repository, BCryptPasswordEncoder passwordEncoder) {
        this.repository = repository;
        this.passwordEncoder = passwordEncoder;
    }

    @Override
    public Account getAccountById(int id) {
        return this.repository.getAccountByAccountId(id);
    }

    @Override
    public Account getAccountByUsername(String username) {
        return this.repository.getAccountByUsername(username);
    }

    @Override
    public List<Account> getAllAccounts() {
        return this.repository.findAll();
    }

    @Override
    public int addAccount(Account account) {
        if (this.repository.existsAccountByUsername(account.getUsername())) {
            return -1;
        } else if (this.repository.existsAccountByEmail(account.getEmail())) {
            return -2;
        }
        account.setPassword(passwordEncoder.encode(account.getPassword()));
        this.repository.save(account);
        return 0;
    }

    @Override
    public boolean changePassword(String currentPassword, String newPassword, Account account) {

        if (passwordEncoder.matches(currentPassword, account.getPassword())) {
            account.setPassword(passwordEncoder.encode(newPassword));
            this.repository.save(account);
            return true;
        }
        return false;
    }

    @Override
    public void editAccount(Account account) {
        this.repository.save(account);
    }

    @Override
    public boolean checkCredentials(String username, String password) {
        return this.repository.existsAccountByUsernameAndPassword(username, password);
    }
}
