package com.example.demo.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.text.DecimalFormat;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class CategoryDTO {

    private static final DecimalFormat df = new DecimalFormat("0.00");

    private Integer categoryId;

    private String name;

    private String description;

    private Float price;

    public CategoryDTO(Integer categoryId, String name, String description, Float multiplier, Float basicPrice) {
        this.categoryId = categoryId;
        this.name = name;
        this.description = description;
        this.price = multiplier + basicPrice;
    }

}
