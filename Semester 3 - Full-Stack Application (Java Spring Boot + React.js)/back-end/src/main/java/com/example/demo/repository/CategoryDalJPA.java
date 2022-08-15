package com.example.demo.repository;

import com.example.demo.dalInterfaces.ICategoryDal;
import com.example.demo.models.Category;
import com.example.demo.repositoryInterfaces.ICategoryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class CategoryDalJPA implements ICategoryDal {

    private final ICategoryRepository repository;

    @Autowired
    public CategoryDalJPA(ICategoryRepository repository) {
        this.repository = repository;
    }

    @Override
    public Category getCategoryByCategoryId(int id) {
        return this.repository.getCategoryByCategoryId(id);
    }

    @Override
    public List<Category> getAllCategories() {
        return this.repository.findAll();
    }

    @Override
    public void addCategory(Category category) {
        this.repository.save(category);
    }
}
