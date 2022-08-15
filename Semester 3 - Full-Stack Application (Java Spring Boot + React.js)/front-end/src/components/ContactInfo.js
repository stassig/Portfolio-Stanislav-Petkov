import '../styles/ContactInfo.css';
import {Link} from "react-router-dom";


const ContactInfo = () => {

    return (

        <div className="contact-info-container">
            <div className="contact-info-sub-container">
                <b>Contact us</b>
                <div>Phone: +31 71 012 6320</div>
                <div>available Monday to Friday</div>
                <div>08:00 am - 05:00 pm</div>
                <div className="email-container">Email: s.petkov@mail.com</div>
                <Link to={sessionStorage.getItem("accessToken") ? ('/livechat') : ('/login')}>
                     Live Chat Support
                </Link>
            </div>
            <div className="information-container">
                <b className="info-tile">Information</b>
                <ul>
                    <li>FAQ</li>
                    <li>BAYERN.COM</li>
                    <li>POLICY</li>
                </ul>
            </div>
        </div>
    )
}

export default ContactInfo;