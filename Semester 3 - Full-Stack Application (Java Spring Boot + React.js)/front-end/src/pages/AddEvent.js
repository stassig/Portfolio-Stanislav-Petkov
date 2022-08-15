import {useState} from "react";

import {Button, Label, Form, FormGroup, Input} from "reactstrap";
import TimePicker from 'react-time-picker';
import "../styles/AddEvent.css";
// eslint-disable-next-line import/no-webpack-loader-syntax
import '!style-loader!css-loader!bootstrap/dist/css/bootstrap.css';

import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import axios from "axios";
import {createBrowserHistory} from "history";
import {Link} from "react-router-dom";

const AddEvent = () => {
    const [time, setTime] = useState('10:00');
    const [date, setDate] = useState(new Date());
    const [opponent, setOpponent] = useState();
    const [league, setLeague] = useState();
    const [ticketPrice, setTicketPrice] = useState();
    const history = createBrowserHistory();

    const today = new Date();
    today.setMonth(today.getMonth() + 12);


    const addEvent = (opponent, league, date, time, ticketPrice) => {
        axios
            .post("events", {
                league,
                ticketPrice,
                date,
                time,
                teamName: opponent,
            })
            .then((response) => {
                alert(response.data.message);
                history.push("/");
                window.location.reload();
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    console.log(error.response);
                    alert(error.response.data.message);
                } else {
                    alert("Something went wrong");
                }
            });
    };


    const handlePriceChange = (e) => {
        e.preventDefault();

        setTicketPrice(e.target.value.toString().split(".").map((el, i) => i ? el.split("").slice(0, 2).join("") : el).join("."));
    }

    const handleFormSubmit = (e) => {
        e.preventDefault();

        //Convert value from datepicker to string to save into the database
        const dateString = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();

        addEvent(opponent, league, dateString, time, ticketPrice);
    };

    return (
        <div>
            <div className="spacer-addEvent">
                <div className="addEvent-container">
                    <div className="spacer"></div>
                    <Form onSubmit={handleFormSubmit} className="addEvent-form">
                        <FormGroup>
                            <div className="d-flex justify-content-center flex-column">
                                <h2 className="title ">New Match</h2>

                                <Label>Opponent</Label>
                                <Input className="addEvent-input w-75"
                                       onChange={e => setOpponent(e.target.value)}
                                       value={opponent}
                                       type="text"
                                       required> </Input>

                                <Label>League</Label>
                                <Input className="addEvent-input w-75"
                                       onChange={e => setLeague(e.target.value)}
                                       value={league}
                                       type="text"
                                       required> </Input>

                                <Label>Ticket Price</Label>
                                <Input className="addEvent-input w-75"
                                       onChange={handlePriceChange}
                                       value={ticketPrice}
                                       type="number"
                                       required> </Input>

                                <Label>Date</Label>
                                <DatePicker selected={date} onChange={(date) => setDate(date)}
                                            monthsShown={1}
                                            minDate={new Date()}
                                            maxDate={today}
                                            showDisabledMonthNavigation

                                            popperPlacement="bottom"
                                            popperModifiers={{
                                                flip: {
                                                    behavior: ["bottom"]
                                                },
                                                preventOverflow: {
                                                    enabled: false
                                                },
                                                hide: {
                                                    enabled: false
                                                }
                                            }}/>

                                <Label>Time</Label>
                                <div>
                                    <TimePicker
                                        onChange={setTime}
                                        value={time}
                                        required/>
                                </div>
                            </div>
                        </FormGroup>
                        <Button className="addEvent-button" variant="primary" size="lg" type="submit" value="Add">
                            Add
                        </Button>
                    </Form>
                </div>
                <Link to="/addTeam" className="btn btn-info addTeam-1-button">Add New Team</Link>
                <Link to="/" className="btn btn-info cancel-button">Cancel</Link>
            </div>
        </div>
    )
        ;
};

export default AddEvent;


// //Convert string to date (when extracted from the database)
// const date1 = new Date(dateString);
// const date2 = new Date(Date.UTC(date1.getFullYear(), date1.getMonth() + 1,  date1.getDate()));
//
// //convert date to string in correct format
// var options = {  weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
// var prnDt = date2.toLocaleTimeString('en-us', options);
//
// //remove hours from the string
// var newStr = prnDt.substring(0, prnDt.length - 12);
// alert(prnDt);


// // Convert string to time (from database)
// const timeString12hr = new Date('2001-01-01T' + time + 'Z')
//     .toLocaleTimeString('en-US',
//         {timeZone:'UTC',hour12:true,hour:'numeric',minute:'numeric'}
//     );