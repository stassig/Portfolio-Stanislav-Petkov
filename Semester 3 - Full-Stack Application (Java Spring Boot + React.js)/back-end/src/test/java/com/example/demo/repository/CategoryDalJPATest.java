package com.example.demo.repository;

import com.example.demo.models.Category;
import com.example.demo.repositoryInterfaces.ICategoryRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class CategoryDalJPATest {

    @Mock
    private ICategoryRepository categoryRepository;
    private CategoryDalJPA underTest;


    @BeforeEach
    void setUp() {
        underTest = new CategoryDalJPA(categoryRepository);
    }

    @Test
    void canGetCategoryByCategoryId() {
        // when
        underTest.getCategoryByCategoryId(1);
        // then
        verify(categoryRepository).getCategoryByCategoryId(1);
    }

    @Test
    void canGetAllCategories() {
        // when
        underTest.getAllCategories();
        // then
        verify(categoryRepository).findAll();
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
        verify(categoryRepository).save(category);
    }
}