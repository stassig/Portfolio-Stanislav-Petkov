package com.example.demo.service;

import com.example.demo.dalInterfaces.ICategoryDal;
import com.example.demo.models.Category;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class CategoryServiceTest {

    @Mock
    private ICategoryDal categoryDal;
    private CategoryService underTest;

    @BeforeEach
    void setUp() {
        underTest = new CategoryService(categoryDal);
    }

    @Test
    void canGetCategoryByCategoryId() {
        // when
        underTest.getCategoryByCategoryId(1);
        // then
        verify(categoryDal).getCategoryByCategoryId(1);
    }

    @Test
    void canGetAllCategories() {
        // when
        underTest.getAllCategories();
        // then
        verify(categoryDal).getAllCategories();
    }

    @Test
    void canAddCategory() {
        // given
        Category category = new Category(
                "Category 1 Gold",
                "Short Side Upper Tier Tickets.",
                10f
        );
        // when
        underTest.addCategory(category);
        // then
        verify(categoryDal).addCategory(category);
    }
}