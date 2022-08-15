package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Category;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ICategoryRepository  extends JpaRepository<Category, Integer> {

    Category getCategoryByCategoryId(int id);
}
