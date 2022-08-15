package com.example.demo.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@AllArgsConstructor
@NoArgsConstructor
public class TeamDTO {

    private Integer teamId;

    private String name;

    private String logo;

    public TeamDTO(String name, String logo) {
        this.name = name;
        this.logo = logo;
    }
}
