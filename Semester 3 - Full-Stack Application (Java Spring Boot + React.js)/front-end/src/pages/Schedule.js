import React, {useEffect, useState} from 'react'
import '../styles/Schedule.css'
import Match from '../components/Event'
import axios from "axios";


const Schedule = () => {

    const [matches, setMatches] = useState([]);

    useEffect(() => {
            axios.get(`http://localhost:8080/matches`)
                .then(res => {
                    setMatches(res.data);
                    console.log(res.data);
                });
        }, []
    )

    return (
        <div>
            <div className="wrapper">
                <div className="match-list">
                    {matches.map(match => (
                        <Match key={match.id} {...match}/>
                    ))}
                </div>
            </div>
        </div>
    )
};

export default Schedule;

