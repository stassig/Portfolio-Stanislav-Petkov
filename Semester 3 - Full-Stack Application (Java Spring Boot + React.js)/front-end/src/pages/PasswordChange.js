import {Form} from "react-bootstrap";
import {FormGroup, Input} from "reactstrap";
import React, {useState} from "react";
import "../styles/PasswordChange.css";
import {Button} from "react-bootstrap";
import ContactInfo from "../components/ContactInfo";
import axios from "axios";

const PasswordChange = () => {

    const [password, setPassword] = useState({
        currentPassword: '',
        newPassword: '',
        repeatNewPassword: ''
    })

    const handlePasswordChange = (event) => {
        const {name, value} = event.target;
        setPassword({...password, [name]: value});
    };

    const changePassword = () => {
        axios
            .put("users/passwordChange", {
                currentPassword: password.currentPassword,
                newPassword: password.newPassword
            })
            .then((response) => {
                alert(response.data.message);
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    alert(error.response.data.message);
                } else {
                    alert("Something went wrong")
                }
            });
    }

    const handleSubmit = (event) => {
        event.preventDefault();

        if (password.newPassword === password.repeatNewPassword) {
            if (password.newPassword.length < 6) {
                alert("Your password must be at least 6 characters long");
                return;
            }
            changePassword();
        } else {
            alert("Passwords do not match.");
        }
    }


    return (
        <div className="password-change-page">
            <div className="password-change-container">
                <div className="password-change-title">PASSWORD CHANGE</div>
                <div>
                    <Form onSubmit={handleSubmit} className="password-change-form">
                        <div className="password-change-row">
                            <div className="field-description">Current Password</div>
                            <Input
                                onChange={handlePasswordChange}
                                className="password-change-input"
                                id="currentPassword"
                                name="currentPassword"
                                type="password"
                                required
                            />
                        </div>
                        <div className="password-change-row">
                            <div className="field-description">New Password</div>
                            <Input
                                onChange={handlePasswordChange}
                                className="password-change-input"
                                id="newPassword"
                                name="newPassword"
                                type="password"
                                required
                            />
                        </div>
                        <div className="password-change-row">
                            <div className="field-description">Repeat New Password</div>
                            <Input
                                onChange={handlePasswordChange}
                                className="password-change-input"
                                id="repeatNewPassword"
                                name="repeatNewPassword"
                                type="password"
                                required
                            />
                        </div>
                        <Button type="submit" className="change-password-button">SAVE PASSWORD</Button>
                    </Form>
                </div>
            </div>
            <div>
                <ContactInfo/>
            </div>
        </div>
    )

}

export default PasswordChange;