package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Block;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface IBlockRepository extends JpaRepository<Block, Integer> {

    Block getBlockByBlockId(Integer blockId);

    Block getBlockByEventIdAndCategoryIdAndBlockNumber(Integer eventId, Integer categoryId, Integer blockNumber);

    List<Block> getBlockByEventIdAndCategoryIdAndAvailabilityIsGreaterThanEqual(Integer eventId, Integer categoryId, Integer quantity);

}
