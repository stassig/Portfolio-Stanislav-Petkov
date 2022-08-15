package com.example.demo.controllers;

import com.example.demo.DTOs.messages.Message;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;
import org.springframework.web.util.HtmlUtils;


@Controller
public class ChatController {

    @MessageMapping("/message")
    @SendTo("/topic/chat")
    public Message sendMessage(@Payload Message message) {
        String content = HtmlUtils.htmlEscape(message.getContent());
        String sender = HtmlUtils.htmlEscape(message.getSender());
        return new Message(sender, content);
    }
}
