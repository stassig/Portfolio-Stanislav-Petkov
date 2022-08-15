import {Link, useParams} from "react-router-dom";
import {Button, Form, FormGroup, Input, Label} from "reactstrap";
import DatePicker from "react-datepicker";
import TimePicker from "react-time-picker";
import {useEffect, useState} from "react";
import {createBrowserHistory} from "history";
import axios from "axios";
import "../styles/EditEvent.css";


const EditEvent = () => {

    const {id} = useParams();

    const [time, setTime] = useState('10:00');
    const [date, setDate] = useState(new Date());
    const [opponent, setOpponent] = useState();
    const [league, setLeague] = useState();
    const [ticketPrice, setTicketPrice] = useState();

    const history = createBrowserHistory();
    const today = new Date();
    today.setMonth(today.getMonth() + 12);

    const getEvent = () => {
        axios
            .get("events/" + id, {})
            .then((response) => {
                    setTime(response.data.time);
                    setDate(new Date(response.data.date));
                    setOpponent(response.data.teamName);
                    setLeague(response.data.league);
                    setTicketPrice(response.data.ticketPrice);
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

    const editEvent = (opponent, league, date, time, ticketPrice) => {
        axios
            .put("events", {
                eventId: id,
                teamName: opponent,
                league,
                date,
                time,
                ticketPrice,
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

        // Convert value from datepicker to string to save into the database
        const dateString = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();

        console.log(dateString);
        console.log(time);

        editEvent(opponent, league, dateString, time, ticketPrice);
    };

    const deleteEvent = (e) => {
        e.preventDefault();

        axios.delete("events?id=" + id)
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
    }


    return (

        <div>
            <div className="spacer-editEvent">
                <div className="editEvent-container">
                    <div className="spacer"></div>
                    <Form onSubmit={handleFormSubmit} className="addEvent-form">
                        <FormGroup>
                            <div className="d-flex justify-content-center flex-column">
                                <h2 className="title ">Edit Event</h2>

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
                        <Button className="editEvent-button" variant="primary" size="lg" type="submit" value="Add">
                            Edit
                        </Button>
                    </Form>
                    <Button className="deleteEvent-button" variant="primary" size="lg" type="submit" value="Add"
                            onClick={e => window.confirm('Are you sure you wish to delete this event?') && deleteEvent(e)}>
                        Delete
                    </Button>
                </div>
                <Link to="/" className="btn btn-secondary cancel-edit-button">Cancel</Link>
            </div>
        </div>
    )
}
export default EditEvent;