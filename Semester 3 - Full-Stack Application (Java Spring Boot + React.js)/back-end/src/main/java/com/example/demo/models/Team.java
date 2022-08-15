package com.example.demo.models;

import lombok.*;
import javax.persistence.*;


@Data
@NoArgsConstructor
@Entity
@AllArgsConstructor
@Table(name = "teams")
public class Team {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer teamId;

    @Column(name = "name")
    private String name;

    @Column(name = "logo")
    private String logo;

    public Team(String name, String logo) {
        this.name = name;
        this.logo = logo;
    }
}
