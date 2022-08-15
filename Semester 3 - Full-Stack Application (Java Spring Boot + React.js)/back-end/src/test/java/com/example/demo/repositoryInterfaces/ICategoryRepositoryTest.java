package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Category;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;


@DataJpaTest
class ICategoryRepositoryTest {

    @MockBean
    private IAccountService accountService;

    @Autowired
    private ICategoryRepository underTest;

    @AfterEach
    void tearDown() {
        underTest.deleteAll();
    }

    @Test
    void itShouldGetCategoryByCategoryId() {
        // given
        int id = 1;
        Category category = new Category(
                id,
                "Category 1 Gold",
                "Short Side (Behind The Goal) Upper Tier Tickets.",
                10f
        );
        underTest.save(category);

        // when
        Category expected = underTest.getCategoryByCategoryId(id);

        // then
        assertThat(category).isEqualTo(expected);
    }
}