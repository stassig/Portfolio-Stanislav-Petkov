import React, {useEffect, useState} from "react";

import {Button, Form, FormGroup, Input} from "reactstrap";
import "../styles/Register.css";
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import {createBrowserHistory} from "history";


const AccountPage = () => {

    const history = createBrowserHistory();

    const [phoneNumber, setPhoneNumber] = useState(``);
    const [firstName, setFirstName] = useState();
    const [lastName, setLastName] = useState();
    const [gender, setGender] = useState();
    const [email, setEmail] = useState();

    const getAccountInfo = () => {
        axios
            .get("users")
            .then((response) => {
                setFirstName(response.data.firstName);
                setLastName(response.data.lastName);
                setGender(response.data.gender);
                setEmail(response.data.email);
                setPhoneNumber(response.data.phoneNumber);
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

    const editAccountInfo = () => {
        axios
            .put("users", {
                email: email,
                firstName: firstName,
                lastName: lastName,
                gender: gender,
                phoneNumber: phoneNumber,
            })
            .then((response) => {
                alert(response.data.message);
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
        getAccountInfo();
    }, [])

    const handleSubmit = (e) => {
        e.preventDefault();
        editAccountInfo();
    };

    return (
        <div>
            <div className="spacer-account">
                <div className="register-container">
                    <Form className="register-form" onSubmit={handleSubmit}>
                        <FormGroup>
                            <h2 className="title register">ACCOUNT INFORMATION</h2>

                            <Input
                                id="account-first-name"
                                onChange={e => setFirstName(e.target.value)}
                                value={firstName}
                                className="register-input"
                                placeholder="First Name"
                                name="firstName"
                                type="text"
                                required
                            />
                            <Input
                                onChange={e => setLastName(e.target.value)}
                                value={lastName}
                                className="register-input"
                                placeholder="Last Name"
                                name="lastName"
                                type="text"
                                required
                            />
                            <div>
                                Gender:
                                <select className="gender-selector-register" name="gender"
                                        onChange={e => setGender(e.target.value)}
                                        value={gender}>
                                    <option value="Male">Male</option>
                                    <option value="Female">Female</option>
                                    <option value="Other">Other</option>
                                </select>
                            </div>

                            <div className="phone-container-register">
                                <PhoneInput
                                    inputStyle={{width: "460px"}}
                                    country={'nl'}
                                    value={phoneNumber}
                                    onChange={phoneNumber => setPhoneNumber(phoneNumber)}
                                    inputProps={{
                                        name: 'phone',
                                        required: true,
                                    }}
                                />
                            </div>

                            <Input
                                onChange={e => setEmail(e.target.value)}
                                value={email}
                                className="register-input"
                                placeholder="Email"
                                type="email"
                                required
                            />
                        </FormGroup>
                        <Button className="register-button" type="submit" value="Sign In" id="save-account-button">
                            SAVE
                        </Button>
                    </Form>
                </div>
            </div>
        </div>
    );
};

export default AccountPage;
