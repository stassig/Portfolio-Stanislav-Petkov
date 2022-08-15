package com.example.demo.repositoryInterfaces;

import com.example.demo.models.Block;
import com.example.demo.serviceInterfaces.IAccountService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;


@DataJpaTest
class IBlockRepositoryTest {

    @MockBean
    private IAccountService accountService;

    @Autowired
    private IBlockRepository underTest;

    @AfterEach
    void tearDown() {
        underTest.deleteAll();
    }

    @Test
    void itShouldGetBlockByBlockId() {
        // given
        Block savedBlock = underTest.save(new Block(1, 1, 109, 100));

        // when
        Block expected = underTest.getBlockByBlockId(savedBlock.getBlockId());

        // then
        assertThat(expected).isEqualTo(savedBlock);
    }

    @Test
    void itShouldGetBlockByEventIdAndCategoryIdAndBlockNumber() {
        // given
        Block block = underTest.save(new Block(1, 1, 109, 100));

        // when
        Block expected = underTest.getBlockByEventIdAndCategoryIdAndBlockNumber(1, 1, 109);

        // then
        assertThat(expected).isEqualTo(block);
    }

    @Test
    void itShouldGetBlocksByEventIdAndCategoryIdAndAvailabilityIsGreaterThanEqual() {
        // given
        underTest.save(new Block( 1, 1, 109, 100));
        underTest.save(new Block( 3, 1, 118, 100));
        underTest.save(new Block( 1, 9, 120, 100));
        underTest.save(new Block( 1, 1, 131, 60));
        underTest.save(new Block( 1, 1, 135, 120));

        // when
        int expected = underTest
                .getBlockByEventIdAndCategoryIdAndAvailabilityIsGreaterThanEqual(1, 1, 100)
                .size();

        // then
        assertThat(expected).isEqualTo(2);
    }
}