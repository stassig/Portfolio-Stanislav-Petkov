package com.example.demo.serviceInterfaces;

import com.example.demo.models.Team;

import java.util.List;

public interface ITeamService {

    Team getTeamByName(String name);

    Team getTeamByTeamId(int id);

    int addTeam(Team team);

    List<Team> getAllTeams();
}
