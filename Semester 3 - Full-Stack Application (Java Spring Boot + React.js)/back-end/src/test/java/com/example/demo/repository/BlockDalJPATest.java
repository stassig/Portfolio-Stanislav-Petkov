package com.example.demo.repository;

import com.example.demo.models.Block;
import com.example.demo.repositoryInterfaces.IBlockRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
class BlockDalJPATest {

    @Mock
    private IBlockRepository blockRepository;
    private BlockDalJPA underTest;

    @BeforeEach
    void setUp() {
        underTest = new BlockDalJPA(blockRepository);
    }

    @Test
    void canGetBlockByBlockId() {
        // when
        underTest.getBlockByBlockId(1);
        // then
        verify(blockRepository).getBlockByBlockId(1);
    }

    @Test
    void canGetBlockByEventIdAndCategoryIdAndBlockNumber() {
        // when
        underTest.getBlockByEventIdAndCategoryIdAndBlockNumber(1, 1, 1);
        // then
        verify(blockRepository)
                .getBlockByEventIdAndCategoryIdAndBlockNumber(1, 1, 1);
        ;
    }

    @Test
    void canGetBlockByEventIdAndCategoryIdAndAvailability() {
        // when
        underTest.getBlockByEventIdAndCategoryIdAndAvailability(1, 1, 4);
        // then
        verify(blockRepository)
                .getBlockByEventIdAndCategoryIdAndAvailabilityIsGreaterThanEqual(1, 1, 4);
    }

    @Test
    void canSaveBlock() {
        // given
        Block block = new Block(1, 1, 109, 100);
        // when
        underTest.saveBlock(block);
        // then
        verify(blockRepository).save(block);
    }
}