package com.example.demo.serviceInterfaces;

import com.example.demo.models.Category;

import java.util.List;

public interface ICategoryService {

    Category getCategoryByCategoryId(int id);

    List<Category> getAllCategories();

    void addCategory(Category category);

}
