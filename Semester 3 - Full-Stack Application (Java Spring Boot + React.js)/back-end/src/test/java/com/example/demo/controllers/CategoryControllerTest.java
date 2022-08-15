package com.example.demo.controllers;

import com.example.demo.models.Block;
import com.example.demo.models.Category;
import com.example.demo.models.Event;
import com.example.demo.serviceInterfaces.IAccountService;
import com.example.demo.serviceInterfaces.ICategoryService;
import com.example.demo.serviceInterfaces.IEventService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;


@WebMvcTest(CategoryController.class)
class CategoryControllerTest {

    private MockMvc mockMvc;
    @MockBean
    private IAccountService accountService;
    @MockBean
    private ICategoryService categoryService;
    @MockBean
    private IEventService eventService;
    @Autowired
    private WebApplicationContext context;

    @BeforeEach
    public void setup() {
        this.mockMvc = MockMvcBuilders
                .webAppContextSetup(this.context)
                .build();
    }

    @Test
    void getCategoryByIDSuccess() throws Exception {
        // given
        Category category = new Category(1000, "Category 1", "Short Side", 10f);
        when(categoryService.getCategoryByCategoryId(1))
                .thenReturn(category);

        // when
        mockMvc.perform(
                get("/categories/1"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(categoryService).getCategoryByCategoryId(1);
    }

    @Test
    void getCategoryByIDFailure() throws Exception {
        // given
        when(categoryService.getCategoryByCategoryId(1))
                .thenReturn(null);

        // when
        mockMvc.perform(
                get("/categories/1"))
                .andDo(print())
                .andExpect(status().isNotFound());

        // then
        verify(categoryService).getCategoryByCategoryId(1);
    }

    @Test
    void getAllCategoriesSuccess() throws Exception{
        // given
        List<Category> categories = new ArrayList<>();
        categories.add(new Category(1000, "Category 1", "Short Side", 10f));
        Event event = new Event("Champions League", 45f, "2022-01-17", "18:30", 1);
        when(eventService.getEventById(1)).thenReturn(event);
        when(categoryService.getAllCategories()).thenReturn(categories);

        // when
        mockMvc.perform(
                get("/categories?eventId=1"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(eventService).getEventById(1);
        verify(categoryService).getAllCategories();
    }

    @Test
    void getAllCategoriesFailure() throws Exception{
        // given
        when(eventService.getEventById(1)).thenReturn(null);

        // when
        mockMvc.perform(
                get("/categories?eventId=1"))
                .andDo(print())
                .andExpect(status().isBadRequest());

        // then
        verify(eventService).getEventById(1);
    }
}