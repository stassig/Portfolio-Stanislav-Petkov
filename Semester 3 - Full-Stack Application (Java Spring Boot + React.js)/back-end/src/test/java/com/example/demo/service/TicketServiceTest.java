package com.example.demo.service;

import com.example.demo.DTOs.TicketDTO;
import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.dalInterfaces.ITicketDal;
import com.example.demo.models.Block;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class TicketServiceTest {

    @Mock
    private IBlockDal blockDal;
    @Mock
    private ITicketDal ticketDal;
    private TicketService underTest;

    @BeforeEach
    void setUp() {
        underTest = new TicketService(ticketDal, blockDal);
    }

    @Test
    void canGetTicketsByUsername() {
        // when
        underTest.getTicketsByUsername("stanislav");
        // then
        verify(ticketDal).getTicketsByUsername("stanislav");
    }

    @Test
    void SuccessfulBooking() {
        // given
        String username = "stanislav";
        TicketDTO ticketDTO = new TicketDTO(
                "Category 1", 108, 50f, 150f,
                "John Smith", 1, "stanislav",
                3, 100, 3
        );

        given(blockDal.getBlockByEventIdAndCategoryIdAndBlockNumber(1, 3, 108))
                .willReturn(new Block(1, 3, 108, 100));
        // when
        boolean result = underTest.addTicket(ticketDTO, username);
        // then
        verify(ticketDal).addTicket(any());
        assertThat(result).isTrue();
    }

    @Test
    void UnsuccessfulBooking() {
        // given
        String username = "stanislav";
        TicketDTO ticketDTO = new TicketDTO(
                "Category 1", 108, 50f, 150f,
                "John Smith", 1, "stanislav",
                3, 100, 3
        );

        given(blockDal.getBlockByEventIdAndCategoryIdAndBlockNumber(1, 3, 108))
                .willReturn(new Block(1, 3, 108, 2));
        // when
        boolean result = underTest.addTicket(ticketDTO, username);
        // then
        verify(ticketDal, times(0)).addTicket(any());
        assertThat(result).isFalse();
    }

    @Test
    void MultipleSeatsGeneration() {
        // given
        Block block = new Block(1, 3, 108, 100);
        Integer quantity = 5;
        Integer freeSeats = block.getAvailability();
        // when
        String seats = underTest.generateSeats(quantity, freeSeats, block);
        // then
        assertThat(seats).isEqualTo("1-5");
    }

    @Test
    void SingleSeatGeneration() {
        // given
        Block block = new Block(1, 3, 108, 99);
        Integer quantity = 1;
        Integer freeSeats = block.getAvailability();
        // when
        String seats = underTest.generateSeats(quantity, freeSeats, block);
        // then
        assertThat(seats).isEqualTo("2");
    }
}