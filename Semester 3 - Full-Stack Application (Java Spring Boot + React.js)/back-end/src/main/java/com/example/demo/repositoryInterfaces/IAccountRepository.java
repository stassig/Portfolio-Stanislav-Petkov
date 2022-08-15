package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Account;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IAccountRepository extends JpaRepository<Account, Integer> {

    Account getAccountByAccountId(int id);

    Account getAccountByUsername(String username);

    boolean existsAccountByUsernameAndPassword(String username, String password);

    boolean existsAccountByUsername(String username);

    boolean existsAccountByEmail(String email);
}
