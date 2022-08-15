import { useState, useEffect } from "react";
import axios from "axios";

const EventHeader = ({ id }) => {

    const [time, setTime] = useState('');
    const [date, setDate] = useState('');
    const [opponent, setOpponent] = useState('');
    const [league, setLeague] = useState('');

    const convertDate = (dateFormat) => {
        // Convert string to date (when extracted from the database)
        const date1 = new Date(dateFormat);
        const date2 = new Date(Date.UTC(date1.getFullYear(), date1.getMonth(), date1.getDate()));

        // Convert date to string in correct format
        const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        const prnDt = date2.toLocaleTimeString('en-us', options);

        // Remove hours from the string
        const newStr = prnDt.substring(0, prnDt.length - 12);

        setDate(newStr);
    }

    const convertTime = (timeFormat) => {
        // Convert string to time (from database)
        const timeString12hr = new Date('2001-01-01T' + timeFormat + 'Z')
            .toLocaleTimeString('en-US',
                { timeZone: 'UTC', hour12: true, hour: 'numeric', minute: 'numeric' }
            );
        setTime(timeString12hr);
    }

    const getEvent = () => {

        axios
            .get("events/" + id, {})
            .then(response => {
                setOpponent(response.data.teamName);
                setLeague(response.data.league);
                convertDate(response.data.date);
                convertTime(response.data.time);
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    console.log(error.response);
                    alert(error.response.data.message);
                } else {
                    alert("Something went wrong");
                }
            });
    }

    useEffect(() => {
        getEvent();
    }, [])


    return (

        <div className="booking-step-1-title">
            <div className="main-title-container">FC Bayern Munich - {opponent}</div>
            <div className="sub-title-container">{league}</div>
            <div className="booking-time-details">
                {date} Kick-off: {time}
            </div>
        </div>

    )
}

export default EventHeader;