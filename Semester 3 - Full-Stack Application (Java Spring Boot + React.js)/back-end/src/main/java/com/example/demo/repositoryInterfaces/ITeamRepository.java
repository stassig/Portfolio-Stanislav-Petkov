package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Team;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ITeamRepository extends JpaRepository<Team, Integer> {

    boolean existsTeamByName(String name);

    boolean existsTeamByLogo(String name);

    Team getTeamByName(String name);

    Team getTeamByTeamId(int id);
}
