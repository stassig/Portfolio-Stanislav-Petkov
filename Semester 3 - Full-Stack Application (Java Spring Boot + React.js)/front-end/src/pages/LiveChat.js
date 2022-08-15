import "../styles/LiveChat.css";

import {useState, useEffect} from 'react';
import SockJS from 'sockjs-client';
import Stomp from 'stompjs';
import {Input} from "reactstrap";
import {Button, Card} from "react-bootstrap";
import jwt_decode from "jwt-decode";

const ENDPOINT = "http://localhost:8080/chat";

const LiveChat = () => {

    const userCredentials = jwt_decode(sessionStorage.getItem("accessToken"));
    const username = userCredentials.sub;

    const [stompClient, setStompClient] = useState(null);
    const [messageToSend, setSendMessage] = useState("");
    const [messages, setMessages] = useState([]);

    useEffect(() => {
        // use SockJS as the websocket client
        const socket = SockJS(ENDPOINT);
        // Set stomp to use websockets
        const stompClient = Stomp.over(socket);

        // connect to the backend
        stompClient.connect({'Authorization': "Bearer " + sessionStorage.getItem('accessToken')}, () => {
            // subscribe to the backend
            stompClient.subscribe('/topic/chat', (data) => {
                console.log(data);
                onMessageReceived(data);
            });
        });
        // maintain the client for sending and receiving
        setStompClient(stompClient);


        return () => {
            // Anything in here is fired on component unmount.
            stompClient.disconnect({}, () => {
                // unsubscribe to the backend
                stompClient.unsubscribe('/topic/chat');
            });
        }
    }, []);


    const sendMessage = () => {
        stompClient.send("/app/message", {}, JSON.stringify({'content': messageToSend, 'sender': username}));
    }

    const onMessageReceived = (data) => {
        const result = JSON.parse(data.body);
        setMessages(previous => [...previous, result]);
        console.log(result);
    }

    return (
        <><Card className="chat-container">
            <Card.Header className="chat-title">
                <div>LIVE CHAT SUPPORT</div>
            </Card.Header>
            <Card.Body>
                <div className="chat-body">
                    {messages.map(message => {
                        return (
                            <div className="message-container"><b>{message.sender}</b>: {message.content}</div>
                        )
                    })}
                </div>

                <Input className="message-input-field"
                       onChange={e => setSendMessage(e.target.value)}
                       value={messageToSend}
                       type="text"
                       placeholder="Enter a message!"
                       required/>
                <Button onClick={sendMessage} className="send-button">Send</Button>
            </Card.Body>
        </Card>
        </>

    )
}

export default LiveChat;