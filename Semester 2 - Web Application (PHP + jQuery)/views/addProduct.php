<?php require 'authentication\autheticationAdmin.php'; ?>

<form action="handlers/addProductHandler.php" method="post" enctype="multipart/form-data" id="addProductForm">
    <div class="page-wrapper">
        <div class="product-img">

            <label>Select Image File:</label>
            <input type="file" name="new-imageUpload" id="new-imageUpload">
            <img id="previewImg" src = ""/>
        </div>
        <div class="selected-product-info">
            <h2>Name: </h2>
            <input type="text" placeholder="Full name of the product" id="new-product-name" name="new-product-name" value="">
            <h1>Price: </h1>
            <input type="text" placeholder="Total price of the product" id="new-product-price" name="new-product-price" value=""><br>

            <input class="create-btn" type="submit" value="Save product" onclick="return confirm('Confirm creation?')" id="btnSubmitProduct">

        </div>

        <div class="specifications-box">

            <h3>Specifications</h3><br>
            <div class="spec">
                <label>Manufaturer:</label>
                <input type="text" id="new-product-manufacturer" name="new-product-manufacturer" value="">
            </div>
            <div class="spec">
                <label>Screen size:</label>
                <input type="text" id="new-product-screen" name="new-product-screen" value="">
            </div>
            <div class="spec">
                <label>CPU:</label>
                <input type="text" id="new-product-cpu" name="new-product-cpu" value="">
            </div>
            <div class="spec">
                <label>GPU:</label>
                <input type="text" id="new-product-gpu" name="new-product-gpu" value="">
            </div>
            <div class="spec">
                <label>RAM:</label>
                <input type="text" id="new-product-ram" name="new-product-ram" value="">
            </div>
            <div class="spec">
                <label>HDD:</label>
                <input type="text" id="new-product-hdd" name="new-product-hdd" value="">
            </div>
            <div class="spec">
                <label>SSD:</label>
                <input type="text" id="new-product-ssd" name="new-product-ssd" value="">
            </div>
            <div class="spec">
                <label>Battery:</label>
                <input type="text" id="new-product-battery" name="new-product-battery" value="">
            </div>
        </div>
    </div>
</form>
<script src="js\addProductScript.js"></script>