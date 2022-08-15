package com.example.demo.dalInterfaces;

import com.example.demo.models.Team;

import java.util.List;

public interface ITeamDal {

    Team getTeamByName(String name);

    Team getTeamByTeamId(int id);

    int addTeam(Team team);

    List<Team> getAllTeams();
}
