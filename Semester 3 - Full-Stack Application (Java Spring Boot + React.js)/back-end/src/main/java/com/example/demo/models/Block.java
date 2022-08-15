package com.example.demo.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name="blocks")
public class Block {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer blockId;

    @Column(name = "eventId")
    private Integer eventId;

    @Column(name = "categoryId")
    private Integer categoryId;

    @Column(name = "blockNumber")
    private Integer blockNumber;

    @Column(name = "availability", columnDefinition ="integer default 100")
    private Integer availability;

    public Block(Integer eventId, Integer categoryId, Integer blockNumber, Integer availability) {
        this.eventId = eventId;
        this.categoryId = categoryId;
        this.blockNumber = blockNumber;
        this.availability = availability;
    }
}


