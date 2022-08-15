import "../styles/BookingStep3.css"

import CreditCardForm from "../components/CreditCardForm";
import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import axios from "axios";

const BookingStep3 = () => {

    const {categoryId} = useParams();
    const {id} = useParams();
    const {blockId} = useParams();

    const [eventDetails, setEventDetails] = useState({
        league: "",
        date: "",
        time: "",
        teamName: "",
        categoryPrice: 0,
        categoryName: ""
    })


    const getCategory = () => {
        axios
            .get(`events/${id}?categoryId=${categoryId}`)
            .then(response => {

                setEventDetails(response.data);
            });
    }

    useEffect(() => {
        getCategory();
    }, [])


    return (
        <div className="payment-page">
            <div className="payment-page-section-1">
                <div className="event-details-container">
                    <div className="match-title-container">Bayern Munich vs {eventDetails.teamName}</div>
                    <div className="match-league-container">{eventDetails.league}</div>
                    <div className="event-location-details">
                        <div style={{fontWeight: 'bold'}}>Munich, Germany</div>
                        <div
                            style={{textAlign: 'right', width: '247px'}}>{eventDetails.date} | {eventDetails.time}</div>
                    </div>
                    <div className="stadium-name-container">Allianz Arena</div>

                    <hr className="line-separator"/>
                    <div
                        className="category-name-container">Category:{eventDetails.categoryName === "Standing" ? " " + eventDetails.categoryName : eventDetails.categoryName} /
                        Block: {blockId}</div>
                </div>
                <div className="vertical-line"></div>
                <div className="price-details-container">
                    <div className="quantity-container">
                        <div>Quantity:</div>
                        <div className="quantity">{sessionStorage.getItem("quantity")}</div>
                    </div>
                    <div className="price-per-seat-container">
                        <div>Price per Seat:</div>
                        <div className="price-per-seat">
                            {eventDetails.categoryPrice.toFixed(2)} €
                        </div>
                    </div>
                    <div className="total-price-container">
                        <div>Total:</div>
                        <div className="total-price">
                            {(eventDetails.categoryPrice * sessionStorage.getItem("quantity")).toFixed(2)} €
                        </div>
                    </div>
                </div>
            </div>
            <div className="payment-header"> PAYMENT INFORMATION</div>
            <div className="payment-details-container">
                <CreditCardForm info = {eventDetails} category={eventDetails.categoryName} price = {eventDetails.categoryPrice} categoryId={categoryId} eventId={id} blockNumber={blockId}/>

            </div>
        </div>
    )

}

export default BookingStep3;