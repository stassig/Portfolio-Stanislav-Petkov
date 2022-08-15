package com.example.demo.repository;

import com.example.demo.dalInterfaces.IBlockDal;
import com.example.demo.models.Block;
import com.example.demo.repositoryInterfaces.IBlockRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class BlockDalJPA implements IBlockDal {


    private final IBlockRepository repository;

    @Autowired
    public BlockDalJPA(IBlockRepository repository) {
        this.repository = repository;
    }

    @Override
    public Block getBlockByBlockId(Integer blockId) {
        return this.repository.getBlockByBlockId(blockId);
    }

    @Override
    public Block getBlockByEventIdAndCategoryIdAndBlockNumber(Integer eventId, Integer categoryId, Integer blockNumber) {
        return this.repository.getBlockByEventIdAndCategoryIdAndBlockNumber(eventId, categoryId, blockNumber);
    }

    @Override
    public List<Block> getBlockByEventIdAndCategoryIdAndAvailability(Integer eventId, Integer categoryId, Integer quantity) {
        return this.repository.getBlockByEventIdAndCategoryIdAndAvailabilityIsGreaterThanEqual(eventId, categoryId, quantity);
    }

    @Override
    public void saveBlock(Block block) {
        this.repository.save(block);
    }
}
