package com.example.demo.controllers;


import com.example.demo.DTOs.BlockDTO;
import com.example.demo.DTOs.messages.MessageResponse;
import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.models.Block;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*")
@RequestMapping("/blocks")
public class BlockController {

    @Autowired
    private IBlockDal dal;

    @GetMapping()
    public ResponseEntity<?> getAvailableBlocks(@RequestParam("eventId") int eventId, @RequestParam("categoryId") int categoryId, @RequestParam("quantity") int quantity) {

        List<Block> blocks = this.dal.getBlockByEventIdAndCategoryIdAndAvailability(eventId, categoryId, quantity);
        if (blocks != null) {

            List<BlockDTO> blockDTOs = new ArrayList<>();

            for (Block block : blocks) {
                blockDTOs.add(new BlockDTO(block.getBlockId(), block.getBlockNumber(),block.getAvailability()));
            }
            return ResponseEntity.ok().body(blockDTOs);
        }
        return ResponseEntity.badRequest().body(new MessageResponse("There are no available blocks for the selected category!"));

    }

}
