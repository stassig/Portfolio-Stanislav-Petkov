package com.example.demo.dalInterfaces;

import com.example.demo.models.Category;

import java.util.List;

public interface ICategoryDal {

    Category getCategoryByCategoryId(int id);

    List<Category> getAllCategories();

    void addCategory(Category category);


}
