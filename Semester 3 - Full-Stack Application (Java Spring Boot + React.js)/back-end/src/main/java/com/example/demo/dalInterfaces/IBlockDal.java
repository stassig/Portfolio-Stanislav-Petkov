package com.example.demo.dalInterfaces;

import com.example.demo.models.Block;

import java.util.List;

public interface IBlockDal {

    Block getBlockByBlockId(Integer blockId);

    Block getBlockByEventIdAndCategoryIdAndBlockNumber(Integer eventId, Integer categoryId, Integer blockNumber);

    List<Block> getBlockByEventIdAndCategoryIdAndAvailability(Integer eventId, Integer categoryId, Integer quantity);

    void saveBlock(Block block);

}
