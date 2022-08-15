package com.example.demo.controllers;

import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.models.Account;
import com.example.demo.models.Block;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.csrf;
import static org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers.springSecurity;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(BlockController.class)
class BlockControllerTest {

    private MockMvc mockMvc;
    @MockBean
    private IBlockDal blockDal;
    @MockBean
    private IAccountService accountService;
    @Autowired
    private WebApplicationContext context;

    @BeforeEach
    public void setup() {
        this.mockMvc = MockMvcBuilders
                .webAppContextSetup(this.context)
                .build();
    }

    @Test
    void getAvailableBlocksSuccess() throws Exception{
        // given
        List<Block> blocks = new ArrayList<>();
        blocks.add(new Block( 100000,1, 1, 109, 100));
        when(blockDal.getBlockByEventIdAndCategoryIdAndAvailability(1,2,3))
                .thenReturn(blocks);

        // when
        mockMvc.perform(
                get("/blocks?eventId=1&categoryId=2&quantity=3"))
                .andDo(print())
                .andExpect(status().isOk());

        // then
        verify(blockDal).getBlockByEventIdAndCategoryIdAndAvailability(1,2,3);
    }

    @Test
    void getAvailableBlocksFailure() throws Exception{
        // given
        when(blockDal.getBlockByEventIdAndCategoryIdAndAvailability(1,2,3))
                .thenReturn(null);

        // when
        mockMvc.perform(
                get("/blocks?eventId=1&categoryId=2&quantity=3"))
                .andDo(print())
                .andExpect(status().isBadRequest());

        // then
        verify(blockDal).getBlockByEventIdAndCategoryIdAndAvailability(1,2,3);
    }
}