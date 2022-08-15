package com.example.demo.service;

import com.example.demo.dalInterfaces.ICategoryDal;
import com.example.demo.models.Category;
import com.example.demo.serviceInterfaces.ICategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CategoryService implements ICategoryService {

    private ICategoryDal dal;

    @Autowired
    public CategoryService(ICategoryDal dal){
        this.dal  = dal;
//        this.addCategory(new Category("Standing","Any Available Ticket in the Standing Section.",10f));
//        this.addCategory(new Category("Category 4","Short Side (Behind The Goal) Upper Tier Tickets.",20f));
//        this.addCategory(new Category("Category 3","Corner Area Upper Tier Tickets.",30f));
//        this.addCategory(new Category("Category 2","Short Side (Behind The Goal) Middle Tier Tickets.",40f));
//        this.addCategory(new Category("Category 1","Long Side Upper Tickets.",50f));
//        this.addCategory(new Category("Category 1 Silver","Long Side Upper Central Tickets.",60f));
//        this.addCategory(new Category("Category 1 Gold","Long Side Lower 1st Or 2nd Tier Tickets.",70f));
//        this.addCategory(new Category("Category 1 Platinum","Long Side Lower Central Between the Penalty Boxes Tickets.",80f));
    }

    @Override
    public Category getCategoryByCategoryId(int id) {
        return this.dal.getCategoryByCategoryId(id);
    }

    @Override
    public List<Category> getAllCategories() {
        return this.dal.getAllCategories();
    }

    @Override
    public void addCategory(Category category) {
        this.dal.addCategory(category);
    }
}
