import {useState} from "react";

import {Button, Form, FormGroup, Input} from "reactstrap";
import "../styles/Login.css";
import {Link} from "react-router-dom";
import axios from "axios";
import jwt_decode from "jwt-decode";
import {createBrowserHistory} from "history";


const Login = () => {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const history = createBrowserHistory();

    const login = () => {
        axios
            .post("login", {username, password})
            .then((response) => {
                    const token = response.data.toString();
                    const userCredentials = jwt_decode(token);

                    sessionStorage.setItem("accessToken", token);
                    sessionStorage.setItem("username", userCredentials.sub);
                    sessionStorage.setItem("role", userCredentials.role);

                    history.push("/");
                    window.location.reload();
                }
            )
            .catch((error) => {
                if (error.response.status === 403) {
                    alert("Invalid Credentials!");
                } else {
                    alert("Something went wrong");
                }
            });
    };


    const handleUsernameChange = (e) => {
        e.preventDefault();

        setUsername(e.target.value);
    };
    const handlePasswordChange = (e) => {
        e.preventDefault();

        setPassword(e.target.value);
    };

    const handleFormSubmit = (e) => {
        e.preventDefault();

        login();
    };

    return (
        <div>
            <div className="spacer-login">
                <div className="login-container">
                    <Form onSubmit={handleFormSubmit} className="login-form">
                        <FormGroup>
                            <h2 className="title login">Login</h2>
                            <Input
                                id="login-username"
                                className="login-input"
                                onChange={handleUsernameChange}
                                placeholder="Username"
                                value={username}
                                type="username"
                                required
                            />
                            <Input
                                id="login-password"
                                className="login-input"
                                onChange={handlePasswordChange}
                                placeholder="Password"
                                value={password}
                                type="password"
                                required
                            />
                        </FormGroup>
                        <Button className="login-button" type="submit" value="Sign In" id="login-button">
                            Sign in
                        </Button>
                        <div className="extra-links">
                            <Link to="/register" className="link">Don't have an account? Signup Now!</Link>
                        </div>
                    </Form>
                </div>
            </div>
        </div>
    );
};

export default Login;
