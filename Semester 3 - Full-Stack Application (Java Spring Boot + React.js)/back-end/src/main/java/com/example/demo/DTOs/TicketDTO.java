package com.example.demo.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@AllArgsConstructor
@NoArgsConstructor
public class TicketDTO {

    private Integer ticketId;

    private String date;

    private String time;

    private String category;

    private Integer blockNumber;

    private String seats;

    private Float pricePerSeat;

    private Float totalPrice;

    private String ticketOwner;

    private String league;

    private Integer eventId;

    private String username;

    private Integer quantity;

    private String teamName;

    private String logo;

    private Integer blockId;

    private Integer categoryId;

    public TicketDTO(String category, Integer blockNumber, Float pricePerSeat, Float totalPrice, String ticketOwner, Integer eventId, String username, Integer quantity, Integer blockId, Integer categoryId) {
        this.category = category;
        this.blockNumber = blockNumber;
        this.pricePerSeat = pricePerSeat;
        this.totalPrice = totalPrice;
        this.ticketOwner = ticketOwner;
        this.eventId = eventId;
        this.username = username;
        this.quantity = quantity;
        this.blockId = blockId;
        this.categoryId = categoryId;
    }

    public TicketDTO(Integer ticketId, String date, String time, String category, Integer blockNumber, String seats, Float pricePerSeat, Float totalPrice, String ticketOwner, String league, Integer eventId, String username, String teamName, String logo) {
        this.ticketId = ticketId;
        this.date = date;
        this.time = time;
        this.category = category;
        this.blockNumber = blockNumber;
        this.seats = seats;
        this.pricePerSeat = pricePerSeat;
        this.totalPrice = totalPrice;
        this.ticketOwner = ticketOwner;
        this.league = league;
        this.eventId = eventId;
        this.username = username;
        this.teamName = teamName;
        this.logo = logo;
    }
}
