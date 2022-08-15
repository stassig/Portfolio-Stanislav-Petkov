import "../styles/BookingStep1.css";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Category from "../components/Category";
import EventHeader from "../components/EventHeader";


const BookingStep1 = () => {

    const { id } = useParams();
    const [mapImage, setMapImage] = useState(process.env.PUBLIC_URL + "/categories/Default.png");
    const [categories, setCategories] = useState([]);

    const getCategories = () => {
        axios
            .get("categories?eventId=" + id)
            .then(response => {
                setCategories(response.data);
            });
    }

    const changeMapImage = (e, id) => {
        e.preventDefault();
        setMapImage(process.env.PUBLIC_URL + `/categories/Category${id}.png`);
    }

    const swapToDefaultMap = (e) => {
        e.preventDefault();
        setMapImage(process.env.PUBLIC_URL + "/categories/Default.png");
    }

    useEffect(() => {
        getCategories();
    }, [])


    return (
        <div className="booking-step-1-container">

            <EventHeader id={id} />

            <div className="booking-step-1-content-container">

                <div className="stadium-map-container"><img src={mapImage} className="img-map" alt="Map" /></div>
                <div className="category-container">
                    <div className="category-header">
                        <div className="category-name-header">Category</div>
                        <div className="category-quantity-header">Quantity</div>
                        <div className="category-price-header">Price</div>
                    </div>

                    {categories.map(category => (
                        <Category key={category.categoryId} {...category} eventId={id} setImage={changeMapImage} setDefaultImage={swapToDefaultMap} />
                    ))}

                </div>
            </div>

        </div>
    )
}

export default BookingStep1;