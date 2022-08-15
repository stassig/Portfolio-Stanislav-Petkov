package com.example.demo.service;

import com.example.demo.DTOs.TicketDTO;
import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.dalInterfaces.ITicketDal;
import com.example.demo.models.Block;
import com.example.demo.models.Ticket;
import com.example.demo.serviceInterfaces.ITicketService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TicketService implements ITicketService {

    private final ITicketDal dal;

    private final IBlockDal blockDal;

    @Autowired
    public TicketService(ITicketDal dal, IBlockDal blockDal) {
        this.dal = dal;
        this.blockDal = blockDal;
    }

    @Override
    public List<Ticket> getTicketsByUsername(String username) {
        return this.dal.getTicketsByUsername(username);
    }

    @Override
    public boolean addTicket(TicketDTO ticketDTO, String username) {

        Block block = this.blockDal.getBlockByEventIdAndCategoryIdAndBlockNumber(ticketDTO.getEventId(), ticketDTO.getCategoryId(), ticketDTO.getBlockNumber());
        Integer freeSeats = block.getAvailability();
        Integer quantity = ticketDTO.getQuantity();

        if (freeSeats >= quantity) {

            String seats = this.generateSeats(quantity, freeSeats, block);
            this.dal.addTicket(new Ticket(ticketDTO.getCategory(), ticketDTO.getBlockNumber(), seats, ticketDTO.getPricePerSeat(), ticketDTO.getTotalPrice(), ticketDTO.getTicketOwner(), ticketDTO.getEventId(), username));
            return true;
        }
        return false;
    }

    public String generateSeats(Integer quantity, Integer freeSeats, Block block) {

        String seats;
        if (quantity > 1) {
            freeSeats = freeSeats - quantity; // remaining free seats after booking completion
            int lastSeat = 100 - freeSeats; // last seat of the current booking
            int firstSeat = lastSeat - (quantity - 1); // first seat of the current booking
            seats = firstSeat + "-" + lastSeat;
        } else {
            freeSeats = freeSeats - 1; // remaining free seats after booking completion
            int lastSeat = 100 - freeSeats; // last seat of the current booking
            seats = Integer.toString(lastSeat);
        }
        block.setAvailability(freeSeats);
        return seats;
    }
}
