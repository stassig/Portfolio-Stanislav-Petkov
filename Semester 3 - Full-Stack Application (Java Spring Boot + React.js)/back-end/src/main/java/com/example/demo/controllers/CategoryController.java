package com.example.demo.controllers;

import com.example.demo.DTOs.CategoryDTO;
import com.example.demo.DTOs.messages.MessageResponse;
import com.example.demo.models.Category;
import com.example.demo.models.Event;
import com.example.demo.serviceInterfaces.ICategoryService;
import com.example.demo.serviceInterfaces.IEventService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/categories")
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*")
public class CategoryController {

    @Autowired
    private ICategoryService categoryService;

    @Autowired
    private IEventService eventService;

    @GetMapping("/{id}")
    public ResponseEntity<?> getCategoryByID(@PathVariable(value = "id") int categoryId) {
        Category category = this.categoryService.getCategoryByCategoryId(categoryId);

        if (category != null) {
            return ResponseEntity.ok().body(new CategoryDTO(category.getCategoryId(), category.getName(), category.getDescription(), category.getMultiplier()));
        }
        return ResponseEntity.notFound().build();
    }

    @GetMapping()
    public ResponseEntity<?> getAllCategories(@RequestParam("eventId") int eventId) {

        Event event = this.eventService.getEventById(eventId);
        if (event != null) {

            List<CategoryDTO> categoryDTOs = new ArrayList<>();

            for (Category category : this.categoryService.getAllCategories()) {
                categoryDTOs.add(new CategoryDTO(category.getCategoryId(), category.getName(), category.getDescription(), category.getMultiplier(), event.getTicketPrice()));
            }
            return ResponseEntity.ok().body(categoryDTOs);
        }
        return ResponseEntity.badRequest().body(new MessageResponse("Event with this ID doesn't exist."));
    }

}
