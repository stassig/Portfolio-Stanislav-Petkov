package com.example.demo.service;

import com.example.demo.dalInterfaces.IAccountDal;
import com.example.demo.models.Account;
import com.example.demo.serviceInterfaces.IAccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AccountService implements IAccountService {

   private  IAccountDal dal;

    @Autowired
    public AccountService(IAccountDal dal) {
        this.dal = dal;
//        this.addAccount(new Account("stan", "stan", "stan@gmail.com", "USER","Stanislav", "Petkov", "Male","359545232323"));
//        this.addAccount(new Account("test", "test", "test@gmail.com", "USER"));
//        this.addAccount(new Account("stanislav", "stanislav", "stanislav@gmail.com", "USER"));
//        this.addAccount(new Account("admin","admin","admin@gmail.com","ADMIN"));
    }

    @Override
    public Account getAccountById(int id) {
        return this.dal.getAccountById(id);
    }

    @Override
    public Account getAccountByUsername(String username) {
        return this.dal.getAccountByUsername(username);
    }

    @Override
    public List<Account> getAllAccounts() {
        return this.dal.getAllAccounts();
    }

    @Override
    public int addAccount(Account account) {
        return this.dal.addAccount(account);
    }

    @Override
    public void editAccount(Account account) {
        this.dal.editAccount(account);
    }

    @Override
    public boolean checkCredentials(String username, String password) {
        return this.dal.checkCredentials(username, password);
    }

    @Override
    public boolean changePassword(String currentPassword, String newPassword, Account account) {
        return this.dal.changePassword(currentPassword, newPassword, account);
    }
}
