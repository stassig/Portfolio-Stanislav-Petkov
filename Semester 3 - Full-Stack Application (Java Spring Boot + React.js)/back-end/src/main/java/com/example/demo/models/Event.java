package com.example.demo.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;


@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "events")
public class Event {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer eventId;

    @Column(name = "league")
    private String league;

    @Column(name = "ticketPrice")
    private Float ticketPrice;

    @Column(name = "date")
    private String date;

    @Column(name = "time")
    private String time;

    @Column(name = "teamId")
    private int teamId;

    public Event(String league, Float ticketPrice, String date, String time, int teamId) {
        this.league = league;
        this.ticketPrice = ticketPrice;
        this.date = date;
        this.time = time;
        this.teamId = teamId;
    }
}