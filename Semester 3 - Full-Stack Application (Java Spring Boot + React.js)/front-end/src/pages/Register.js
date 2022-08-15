import React, {useState} from "react";

import {Button, Form, FormGroup, Input} from "reactstrap";
import "../styles/Register.css";
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import {createBrowserHistory} from "history";

const Register = () => {

    const history = createBrowserHistory();
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [phoneNumber, setPhoneNumber] = useState(``);
    const [personalInfo, setPersonalInfo] = useState({
        firstNameRegister: '',
        lastNameRegister: '',
        gender: 'Male'
    });

    const register = (username, password, email, firstName, lastName, gender, phoneNumber) => {
        const instance = axios.create();
        delete instance.defaults.headers.common['Authorization'];

        instance
            .post("users", {
                username,
                email,
                password,
                role: "USER",
                firstName,
                lastName,
                gender,
                phoneNumber,
            })
            .then((response) => {
                alert(response.data.message);
                history.push("/login");
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

    const handleInfoChange = e => {
        const {name, value} = e.target
        setPersonalInfo({
            ...personalInfo,
            [name]: value
        })
    };

    const handleUsernameChange = (e) => {
        e.preventDefault();

        setUsername(e.target.value);
    };

    const handlePasswordChange = (e) => {
        e.preventDefault();

        setPassword(e.target.value);
    };

    const handleConfirmPasswordChange = (e) => {
        e.preventDefault();

        setConfirmPassword(e.target.value);
    };

    const handleEmailChange = (e) => {
        e.preventDefault();

        setEmail(e.target.value);
    };
    const handleSubmit = (e) => {
        e.preventDefault();

        if (password === confirmPassword) {
            if (password.length < 6) {
                alert("Password must be at least 6 characters long");
                return;
            }
            register(username, password, email, personalInfo.firstNameRegister, personalInfo.lastNameRegister, personalInfo.gender, phoneNumber);
        } else {
            alert("Passwords do not match.");
        }
    };

    return (
        <div>
            <div className="spacer-register">
                <div className="register-container">
                    <Form className="register-form" onSubmit={handleSubmit}>
                        <FormGroup>
                            <h2 className="title register">Registration</h2>

                            <Input
                                onChange={handleInfoChange}
                                id="firstNameRegister"
                                name="firstNameRegister"
                                className="register-input"
                                placeholder="First Name"
                                type="text"
                                required
                            />
                            <Input
                                onChange={handleInfoChange}
                                id="lastNameRegister"
                                name="lastNameRegister"
                                className="register-input"
                                placeholder="Last Name"
                                type="text"
                                required
                            />
                            <div>
                                Gender:
                                <select className="gender-selector-register" name="gender"
                                        onChange={e => setPersonalInfo({
                                            ...personalInfo,
                                            gender: e.target.value
                                        })}
                                        value={personalInfo.gender}>
                                    <option value="Male">Male</option>
                                    <option value="Female">Female</option>
                                    <option value="Other">Other</option>
                                </select>
                            </div>

                            <div className="phone-container-register">
                                <PhoneInput
                                    inputStyle={{width: "460px"}}
                                    className="register-input"
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
                                onChange={handleEmailChange}
                                className="register-input"
                                placeholder="Email"
                                type="email"
                                required
                            />
                            <Input
                                onChange={handleUsernameChange}
                                className="register-input"
                                placeholder="Username"
                                type="username"
                                required
                            />
                            <Input
                                onChange={handlePasswordChange}
                                className="register-input"
                                placeholder="Password"
                                type="password"
                                required
                            />
                            <Input
                                onChange={handleConfirmPasswordChange}
                                className="register-input"
                                placeholder="Confirm Password"
                                type="password"
                                required
                            />
                        </FormGroup>
                        <Button className="register-button" type="submit" value="Sign In">
                            Sign up
                        </Button>
                    </Form>
                </div>
            </div>
        </div>
    );
};

export default Register;
