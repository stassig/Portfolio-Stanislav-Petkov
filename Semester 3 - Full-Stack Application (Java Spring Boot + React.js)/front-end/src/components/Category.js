import { useState } from "react";
import { Link } from "react-router-dom";

const Category = ({ categoryId, name, description, price, eventId, setImage, setDefaultImage }) => {

    const [quantity, setQuantity] = useState(1);

    const storeQuantity = () => {
        sessionStorage.setItem("quantity", quantity);
        sessionStorage.setItem("price",price.toFixed(2));
    }


    return (
        <div className="category" onMouseEnter={e => setImage(e, categoryId)} onMouseLeave={setDefaultImage}>
            <div className="category-name">
                <div className="category-main-name">{name}</div>
                <div>{description}</div>
            </div>

            <select className="quantity-selector" onChange={e => setQuantity(e.target.value)} value={quantity}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
                <option value="8">8</option>
                <option value="9">9</option>
            </select>

            <div className="price-container">{price.toFixed(2)} $</div>
            <Link onClick={storeQuantity} to={"/event/" + eventId + "/category/" + categoryId} className="btn btn-success buy-now-button">Buy Now</Link>
        </div>
    );
};


export default Category;        