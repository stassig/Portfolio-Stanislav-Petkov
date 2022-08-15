import teamLogo from "../images/logos/logo1.png";
import { Button } from "reactstrap";
import '../styles/Event.css';
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

const Event = ({ teamName, logo, league, date, time, eventId }) => {

    const [eventDate, setDate] = new useState();
    const [eventTime, setTime] = new useState();

    useEffect(() => {
        convertTime();
        convertDate();
    })

    const convertDate = () => {
        // Convert string to date (when extracted from the database)
        const date1 = new Date(date);
        const date2 = new Date(Date.UTC(date1.getFullYear(), date1.getMonth(), date1.getDate()));

        // Convert date to string in correct format
        const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        const prnDt = date2.toLocaleTimeString('en-us', options);

        // Remove hours from the string
        const newStr = prnDt.substring(0, prnDt.length - 12);

        setDate(newStr);
    }

    const convertTime = () => {
        // Convert string to time (from database)
        const timeString12hr = new Date('2001-01-01T' + time + 'Z')
            .toLocaleTimeString('en-US',
                { timeZone: 'UTC', hour12: true, hour: 'numeric', minute: 'numeric' }
            );
        setTime(timeString12hr);
    }


    return (
        <div className="event-container">
            <div><img src={teamLogo} className="img-team" alt="Logo" /></div>
            <div className="vs-tag"><b>vs</b></div>
            <div><img src={process.env.PUBLIC_URL + logo} className="img-team" alt="Logo" /></div>
            <div className="description-container">
                <div><b>FC Bayern Munich - {teamName} </b></div>
                <div>{league}</div>
                <div>{eventDate}</div>
                <div>Kick-Off: {eventTime}</div>
            </div>
            {sessionStorage.getItem('role') === "ADMIN" ?
                <Link to={'/editEvent/' + eventId} className="btn-link"><Button className="edit-button"> Edit</Button></Link>
                :
                <Link to={sessionStorage.getItem('role') === "USER" ? ('/event/' + eventId) : ('/login')} className="btn-link" >
                    <Button className="booking-button"> Book Now</Button>
                </Link>
            }
        </div>
    )
}

export default Event;

// {teamName}, league: {league}, date: {eventDate}, time:  {eventTime}