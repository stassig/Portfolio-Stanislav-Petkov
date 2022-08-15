import {useState} from "react";

import {Button, Form, FormGroup, Label, Input} from "reactstrap";
import "../styles/AddTeam.css";

import axios from 'axios';
import {Link} from "react-router-dom";


const AddTeam = () => {
    const [name, setName] = useState("");
    const [image, setImage] = useState();


    const uploadImage = () => {

        const formData = new FormData();
        formData.append(
            "image",
            image,
            image.name
        );

        axios.post("http://localhost:63342/front-end/src/api/imageUploader.php", formData)
            .then((response) => {
                console.log(response);
            });
    }

    const addTeam = () => {
        axios
            .post("teams", {
                name,
                logo: "/" + image.name,
            })
            .then((response) => {
                alert(response.data.message);
                uploadImage();
                setImage(null);
                setName("");
                document.getElementById("imageFile").value = "";
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    alert(error.response.data.message);
                } else {
                    alert("Something went wrong");
                }
            });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        addTeam();
    }

    return (
        <div>
            <div className="spacer-addTeam">
                <div className="addTeam-container">
                    <div className="spacer"></div>
                    <Form onSubmit={handleSubmit}>
                        <FormGroup>
                            <div className="d-flex justify-content-center flex-column">
                                <h2 className="addTeam-title">New Team</h2>
                                <Label className="addTeam-label">Name</Label>
                                <Input className="addTeam-input w-75"
                                       onChange={e => setName(e.target.value)}
                                       value={name}
                                       type="text"
                                       required> </Input>
                                <Label className="addTeam-label">Logo</Label>

                                <Input id="imageFile" className="addTeam-file-input w-75" type="file" accept="image/png, image/jpeg"
                                       onChange={(e) => setImage(e.target.files[0])}
                                       required
                                > </Input>
                            </div>
                        </FormGroup>
                        <div className="buttons-container">
                            <div className="addTeam-button-container">
                                <Button className="addTeam-button" variant="primary" size="lg" type="submit"
                                        value="Add">
                                    Add
                                </Button>
                            </div>
                            <div className="back-button-container">
                                <Link to="/addEvent" className="btn btn-info back-button">Back</Link>
                            </div>
                        </div>
                    </Form>
                </div>
            </div>
        </div>
    );
};

export default AddTeam;
