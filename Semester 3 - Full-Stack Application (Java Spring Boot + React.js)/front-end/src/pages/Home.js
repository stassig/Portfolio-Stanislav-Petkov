import '../styles/Home.css';
// eslint-disable-next-line import/no-webpack-loader-syntax
import '!style-loader!css-loader!bootstrap/dist/css/bootstrap.css';
import {Link} from "react-router-dom";
import Event from "../components/Event";
import ContactInfo from "../components/ContactInfo";

import {useState, useEffect} from "react";
import axios from "axios";


const Home = () => {

    const [events, setEvents] = useState([]);

    useEffect(() => {
            const instance = axios.create();
            delete instance.defaults.headers.common['Authorization'];

            instance.get("events")
                .then(response => {
                    setEvents(response.data);
                    // console.log(res.data);
                });
        }, []
    )


    return (
        <div className="Home">
            <div className="home-container">
                <div className="flex-container-1">
                    <h2 className="title-container">Event Selection</h2>
                    {events.map(event => (
                        <Event key={event.eventId} {...event}/>
                    ))}
                    {sessionStorage.getItem('role') === "ADMIN" &&
                    <Link to="/addEvent" className="btn btn-primary addMatch-button" id="add-new-match-button">Add New Match</Link>}
                </div>
                <ContactInfo/>

            </div>
        </div>
    )
}

export default Home;

// Test Data #
// FC Bayern Munich - FC Chelsea
// UEFA Champions League 2021/22
// Thursday, September 23, 2021
// Kick-Off: 5:30 PM