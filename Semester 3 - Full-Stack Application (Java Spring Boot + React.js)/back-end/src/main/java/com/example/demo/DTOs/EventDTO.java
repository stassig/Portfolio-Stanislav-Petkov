package com.example.demo.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class EventDTO {

    private Integer eventId;

    private String league;

    private Float ticketPrice;

    private String date;

    private String time;

    private Integer teamId;

    private String teamName;

    private String logo;

    private Float categoryPrice;

    private String categoryName;



    public EventDTO(String teamName, String league, String date, String time, String categoryName, Float categoryPrice){
        this.teamName = teamName;
        this.league = league;
        this.date = date;
        this.time = time;
        this.categoryName = categoryName;
        this.categoryPrice = categoryPrice;
    }

    public EventDTO(Integer eventId, String league, Float ticketPrice, String date, String time, Integer teamId, String teamName, String logo) {
        this.eventId = eventId;
        this.league = league;
        this.ticketPrice = ticketPrice;
        this.date = date;
        this.time = time;
        this.teamId = teamId;
        this.teamName = teamName;
        this.logo = logo;
    }

    public EventDTO(String league, Float ticketPrice, String date, String time, String teamName) {
        this.league = league;
        this.ticketPrice = ticketPrice;
        this.date = date;
        this.time = time;
        this.teamName = teamName;
    }

}
