import {Button} from "react-bootstrap";
import "../styles/OptionsPage.css";
import {Link} from "react-router-dom";


const OptionsPage = () => {

    const username = sessionStorage.getItem("username");


    return (
        <div className="options-page">
            <div className="account-title-container"> YOUR OPTIONS</div>
            <Link to="/bookings"><Button className="account-page-button">SHOW BOOKINGS</Button></Link>
            <Link to="/account"><Button className="account-page-button" id="account-page-button">EDIT PROFILE</Button></Link>
            <Link to="/passwordChange"><Button className="account-page-button">CHANGE PASSWORD</Button></Link>
        </div>
    )
}

export default OptionsPage;