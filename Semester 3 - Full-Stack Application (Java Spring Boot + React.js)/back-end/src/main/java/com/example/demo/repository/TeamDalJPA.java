package com.example.demo.repository;

import com.example.demo.dalInterfaces.ITeamDal;
import com.example.demo.models.Team;
import com.example.demo.repositoryInterfaces.ITeamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class TeamDalJPA implements ITeamDal {

    private final ITeamRepository repository;

    @Autowired
    public TeamDalJPA(ITeamRepository repository) {
        this.repository = repository;
    }

    @Override
    public Team getTeamByName(String name) {
        return this.repository.getTeamByName(name);
    }

    @Override
    public Team getTeamByTeamId(int id) {
        return this.repository.getTeamByTeamId(id);
    }

    @Override
    public int addTeam(Team team) {

        if (this.repository.existsTeamByName(team.getName())) {
            return -1;
        } else if (this.repository.existsTeamByLogo(team.getLogo())) {
            return -2;
        }
        this.repository.save(team);
        return 0;
    }

    @Override
    public List<Team> getAllTeams() {
        return this.repository.findAll();
    }
}
