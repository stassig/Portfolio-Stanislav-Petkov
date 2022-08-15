package com.example.demo.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "tickets")
public class Ticket {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer ticketId;

    @Column(name = "category")
    private String category;

    @Column(name = "blockNumber")
    private Integer blockNumber;

    @Column(name = "seats")
    private String seats;

    @Column(name = "pricePerSeat")
    private Float pricePerSeat;

    @Column(name = "totalPrice")
    private Float totalPrice;

    @Column(name = "ticketOwner")
    private String ticketOwner;

    @Column(name = "eventId")
    private int eventId;

    @Column(name = "username")
    private String username;

    public Ticket(String category, Integer blockNumber, String seats, Float pricePerSeat, Float totalPrice, String ticketOwner, int eventId, String username) {
        this.category = category;
        this.blockNumber = blockNumber;
        this.seats = seats;
        this.pricePerSeat = pricePerSeat;
        this.totalPrice = totalPrice;
        this.ticketOwner = ticketOwner;
        this.eventId = eventId;
        this.username = username;
    }
}
