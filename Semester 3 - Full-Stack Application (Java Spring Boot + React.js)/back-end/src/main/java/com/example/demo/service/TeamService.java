package com.example.demo.service;

import com.example.demo.dalInterfaces.ITeamDal;
import com.example.demo.models.Team;
import com.example.demo.serviceInterfaces.ITeamService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TeamService implements ITeamService {

    private ITeamDal dal;

    @Autowired
    public TeamService(ITeamDal dal) {
        this.dal = dal;
//        this.addTeam(new Team("FC Barcelona", "/BarcelonaLogo.png"));
//        this.addTeam(new Team("FC Manchester United", "/ManchesterUnitedLogo.png"));
    }

    @Override
    public Team getTeamByName(String name) {
        return this.dal.getTeamByName(name);
    }

    @Override
    public Team getTeamByTeamId(int id) {
        return this.dal.getTeamByTeamId(id);
    }

    @Override
    public int addTeam(Team team) {
        return this.dal.addTeam(team);
    }

    @Override
    public List<Team> getAllTeams() {
        return this.dal.getAllTeams();
    }
}
