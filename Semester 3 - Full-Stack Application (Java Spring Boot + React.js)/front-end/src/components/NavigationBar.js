import '../styles/Navbar.css'
import logo from "../images/logos/TeamLogo.png";

import {Navbar, Nav} from 'react-bootstrap'
import {Link} from "react-router-dom";
import {createBrowserHistory} from "history";

const NavigationBar = () => {

    const history = createBrowserHistory();
    const logout = () => {
        sessionStorage.clear();
        history.push("/");
        window.location.reload();
    }

    return (
        <div className="Navbar">
            <Navbar className="color-nav" expand="lg" sticky="top">
                <Link to="/" > <img src={logo} className="img-logo" alt="Logo"/>
                </Link>
                <Link to="/" className="info-container">
                    OFFICIAL TICKET-SHOP <br/>
                    TICKET SALE
                </Link>

                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                        {sessionStorage.getItem('accessToken') ?
                            <>
                                <Link to="/options" className="link-nav" id="options-button">Account</Link>
                                <Link to="/" className="link-nav">Home</Link>
                                <Link to='/' onClick={logout} className="link-nav" id="logout-button"> Logout</Link>
                            </>
                            :
                            <>
                                <Link to="/login" className="link-nav" >Login</Link>
                            </>
                        }
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        </div>
    );
}
export default NavigationBar;