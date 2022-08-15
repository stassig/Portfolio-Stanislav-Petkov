package com.example.demo.controllers;

import com.example.demo.DTOs.TeamDTO;
import com.example.demo.DTOs.messages.MessageResponse;
import com.example.demo.models.Team;
import com.example.demo.serviceInterfaces.ITeamService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;


@RestController
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*")
@RequestMapping("/teams")
public class TeamsController {

    @Autowired
    private ITeamService service;

    @GetMapping("/{name}")
    public ResponseEntity<?> getTeamByName(@PathVariable(value = "name") String name) {
        Team team = this.service.getTeamByName(name);

        if (team != null) {
            return ResponseEntity.ok().body(new TeamDTO(team.getTeamId(), team.getName(), team.getLogo()));
        }
        return ResponseEntity.notFound().build();
    }

    @GetMapping()
    public ResponseEntity<?> getAllTeams() {

        List<Team> teams = this.service.getAllTeams();

        if (teams != null) {
            List<TeamDTO> teamDTOs = new ArrayList<>();
            for (Team team : teams) {
                teamDTOs.add(new TeamDTO(team.getTeamId(), team.getName(), team.getLogo()));
            }
            return ResponseEntity.ok().body(teamDTOs);
        }
        return ResponseEntity.notFound().build();
    }

    @PostMapping()
    public ResponseEntity<?> addTeam(@RequestBody TeamDTO teamDTO) {

        int result = this.service.addTeam(new Team(teamDTO.getName(), teamDTO.getLogo()));

        if (result == -1) {
            return ResponseEntity.badRequest().body(new MessageResponse("Team with this name already exists."));
        } else if (result == -2) {
            return ResponseEntity.badRequest().body(new MessageResponse("Team with this logo already exists."));
        }
        return ResponseEntity.ok(new MessageResponse("Team added successfully!"));
    }

}
