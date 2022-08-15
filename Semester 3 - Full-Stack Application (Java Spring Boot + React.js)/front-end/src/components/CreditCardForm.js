import React, {useEffect, useState} from "react";
import useForm from "../logic/UseForm";
import {Button, Form, Row, Col} from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import Cards from "react-credit-cards";
import "react-credit-cards/es/styles-compiled.css";
import PhoneInput from 'react-phone-input-2'
import 'react-phone-input-2/lib/style.css'
import axios from "axios";
import {createBrowserHistory} from "history";

const CreditCardForm = ({categoryId, eventId, blockNumber, price, category}) => {


    const {handleChange, handleFocus, handleSubmit, values, errors} = useForm();

    const history = createBrowserHistory();

    const [personalInfo, setPersonalInfo] = useState({
        firstName: '',
        lastName: '',
        gender: 'Male',
        email: ''
    })

    const [phoneNumber, setPhoneNumber] = useState(``);

    const handleInfoChange = e => {
        const {name, value} = e.target
        setPersonalInfo({
            ...personalInfo,
            [name]: value
        })
    }

    const completeBooking = () => {
        axios
            .post(`/tickets`, {
                quantity: sessionStorage.getItem("quantity"),
                eventId,
                categoryId,
                blockNumber,
                category: category,
                pricePerSeat: price,
                totalPrice: (price * sessionStorage.getItem("quantity")).toFixed(2),
                ticketOwner: `${personalInfo.firstName} ${personalInfo.lastName}`,
            })
            .then((response) => {
                alert(response.data.message);
                history.push("/bookings");
                window.location.reload();
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    alert(error.response.data.message);
                } else {
                    alert("Something went wrong");
                }
            });
    }

    useEffect(() => {
        console.log(errors);
        if (errors.variant === "success") {
            completeBooking();
        } else {
            if (errors.message !== 'undefined' && errors.message != null) {
                alert(errors.message);
            }
        }
    }, [errors])

    const usePersonalData = (e) => {

        if (e.target.checked) {
            axios
                .get("users")
                .then((response) => {
                    setPersonalInfo({
                        firstName: response.data.firstName,
                        lastName: response.data.lastName,
                        gender: response.data.gender,
                        email: response.data.email
                    })
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
        } else {
            setPersonalInfo({
                firstName: '',
                lastName: '',
                gender: 'Male',
                email: ''
            })
            setPhoneNumber(``);
        }
    }


    return (
        <div>
            <div className="creditCard-container">
                <div className="box justify-content-center align-items-center">
                    <div className="formDiv">
                        <Form onSubmit={handleSubmit}>
                            <div className="payment-container">
                                <div className="card-position">
                                    <div className="creditCard">
                                        <Cards
                                            cvc={values.cardSecurityCode}
                                            expiry={values.cardExpiration}
                                            focused={values.focus}
                                            name={values.cardName}
                                            number={values.cardNumber}
                                        />
                                    </div>
                                    <Form.Group>
                                        <Form.Control
                                            type="text"
                                            id="cardName"
                                            data-testid="cardName"
                                            name="cardName"
                                            placeholder="Cardholder Name"
                                            value={values.cardName}
                                            onChange={handleChange}
                                            onFocus={handleFocus}
                                            isValid={errors.cname}
                                            required
                                        />
                                    </Form.Group>
                                    <Form.Group>
                                        <Form.Control
                                            type="number"
                                            id="cardNumber"
                                            data-testid="cardNumber"
                                            name="cardNumber"
                                            placeholder="Card Number"
                                            value={values.cardNumber}
                                            onChange={handleChange}
                                            onFocus={handleFocus}
                                            isValid={errors.cnumber}
                                            required
                                        />
                                    </Form.Group>
                                    <Row>
                                        <Col>
                                            <Form.Group>
                                                <Form.Control
                                                    type="number"
                                                    id="cardSecurityCode"
                                                    data-testid="cardSecurityCode"
                                                    name="cardSecurityCode"
                                                    placeholder="Security Code"
                                                    value={values.cardSecurityCode}
                                                    onChange={handleChange}
                                                    onFocus={handleFocus}
                                                    isValid={errors.ccvv}
                                                    required
                                                />
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group>
                                                <Form.Control
                                                    type="text"
                                                    id="cardExpiration"
                                                    data-testid="cardExpiration"
                                                    name="cardExpiration"
                                                    placeholder="Expiration Date"
                                                    value={values.cardExpiration}
                                                    onChange={handleChange}
                                                    onFocus={handleFocus}
                                                    isValid={errors.cexp}
                                                    required
                                                />
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </div>
                                <div className="vertical-line-splitter"></div>
                                <div className="personal-details-container">
                                    <Form.Group className="mb-3 personalDetailsCheckbox" controlId="formBasicCheckbox1">
                                        <Form.Check type={"checkbox"}>
                                            <Form.Check.Input
                                                className="personalDetailsCheckbox"
                                                type={"checkbox"}
                                                defaultChecked={false}
                                                onClick={usePersonalData}
                                            />
                                            <Form.Check.Label style={{fontSize: "18px"}}>Use My Account
                                                Information</Form.Check.Label>
                                        </Form.Check>
                                    </Form.Group>
                                    <Form.Group>
                                        <Form.Control
                                            type="text"
                                            id="firstName"
                                            name="firstName"
                                            placeholder="First Name"
                                            value={personalInfo.firstName}
                                            onChange={handleInfoChange}
                                            required
                                        />
                                    </Form.Group>
                                    <Form.Group>
                                        <Form.Control
                                            type="text"
                                            id="lastName"
                                            name="lastName"
                                            placeholder="Last Name"
                                            value={personalInfo.lastName}
                                            onChange={handleInfoChange}
                                            required
                                        />
                                    </Form.Group>
                                    <Form.Group>
                                        Gender:
                                        <select className="gender-selector" name="gender"
                                                onChange={e => setPersonalInfo({
                                                    ...personalInfo,
                                                    gender: e.target.value
                                                })}
                                                value={personalInfo.gender}>
                                            <option value="Male">Male</option>
                                            <option value="Female">Female</option>
                                            <option value="Other">Other</option>
                                        </select>
                                    </Form.Group>
                                    <Form.Group>
                                        <PhoneInput
                                            country={'nl'}
                                            value={phoneNumber}
                                            onChange={phoneNumber => setPhoneNumber(phoneNumber)}
                                            inputProps={{
                                                name: 'phone',
                                                required: true,
                                            }}
                                        />
                                    </Form.Group>
                                    <Form.Group>
                                        <Form.Control
                                            type="email"
                                            id="email"
                                            name="email"
                                            placeholder="Email"
                                            value={personalInfo.email}
                                            onChange={handleInfoChange}
                                            required
                                        />
                                    </Form.Group>
                                </div>
                            </div>
                            <div className="agreement-checkbox">
                                <Form.Group className="" controlId="formBasicCheckbox">
                                    <Form.Check type={"checkbox"}>
                                        <Form.Check.Input
                                            type={"checkbox"}
                                            defaultChecked={false}
                                            required
                                        />
                                        <Form.Check.Label>I agree to the terms and conditions of <b>ITicketsBayern</b>.</Form.Check.Label>
                                    </Form.Check>
                                </Form.Group>
                            </div>

                            <Button
                                className="orderButton"
                                type="submit"
                            >
                                Complete Order
                            </Button>
                        </Form>
                    </div>
                </div>

            </div>

        </div>

    );
};

export default CreditCardForm;

/* SOURCE CODE FOR CREDIT CARD VALIDATION TAKEN FROM: https://github.com/aphrx/credit-card-validation.git*/