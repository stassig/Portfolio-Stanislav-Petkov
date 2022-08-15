import "../styles/BookingStep2.css";
import "../styles/BookingStep1.css"; // can optimize --> split css classes

import EventHeader from "../components/EventHeader";
import BlockTable from "../components/BlockTable";
import ContactInfo from "../components/ContactInfo";
import {useParams} from "react-router-dom";

const BookingStep2 = () => {

    const { id } = useParams(); // event id
    const { categoryId } = useParams();


    return (
        <div className="booking-step-2-content-container">
            <div className="">
                <EventHeader id={id} />
                <div className="step-2-stadium-map-container">
                    <img src={process.env.PUBLIC_URL + `/categories/Category${categoryId}.png`} className="img-map" alt="Map" />
                </div>
            </div>
            <div >
                <BlockTable eventId={id} categoryId={categoryId}/>
            </div>
            <div className="step2-contact-info-container">
                <ContactInfo/>
            </div>
        </div>
    )
}

export default BookingStep2;