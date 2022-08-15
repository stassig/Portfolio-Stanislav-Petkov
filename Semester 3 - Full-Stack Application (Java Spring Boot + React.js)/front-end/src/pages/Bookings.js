import "../styles/BookingsPage.css";

import ContactInfo from "../components/ContactInfo";
import Ticket from "../components/Ticket";
import {useEffect, useState} from "react";
import axios from "axios";


const Bookings = () => {

    const [tickets, setTickets] = useState([]);

    const getTickets = () => {
        axios
            .get(`/tickets`)
            .then(response => {
                setTickets(response.data);
                console.log(response.data);
            });
    }

    useEffect(() => {
        getTickets();
    }, [])


    return (
        <div className="booking-page-container">
            <div className="bookings-container">
                <div className="bookings-title">MY BOOKINGS</div>

                {tickets.map(ticket => (
                    <Ticket key={ticket.ticketId} {...ticket}/>
                ))}

            </div>
            <div className="contacts-container">
                <ContactInfo/>
            </div>
        </div>

    )
}

export default Bookings;