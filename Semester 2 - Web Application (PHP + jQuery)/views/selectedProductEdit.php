<?php require 'authentication\autheticationAdmin.php'; ?>
<?php

$id = (int)$_GET['id'];
$laptopManager = new LaptopManager();
$laptop = $laptopManager->GetLaptop($id);

if ($laptop != null) : ?>

    <form action="handlers/productHandler.php?id=<?php echo $laptop->getId(); ?>" method="post" id="editProductForm">
        <div class="page-wrapper">
            <div class="product-img">            
                <img id="edit-image" src="<?php echo $laptop->getPhoto(); ?>" /> <br>
                <label>Select Image File:</label>
                <input type="file" name="imageUpload" id="imageUpload">         
            </div>
            <div class="selected-product-info">
                <h2><?php echo $laptop->getName(); ?></h2>
                <h1>Price: <?php echo $laptop->getPrice(); ?> $</h1>
                <input class="save-btn" type="submit" value="Save changes" onclick="return confirm('Confirm changes?')" id = "btnEditProduct">
            </div>

            <div class="specifications-box">

                <h3>Specifications</h3><br>
                <div class="spec">
                    <label>Manufacturer:</label>
                    <input type="text" id="new-manufacturer" name="new-manufacturer" value="<?php echo $laptop->getManufacturer(); ?>">
                </div>
                <div class="spec">
                    <label>Screen size:</label>
                    <input type="text" id="new-screen-size" name="new-screen-size" value="<?php echo $laptop->getScreenSize(); ?>">
                </div>
                <div class="spec">
                    <label>CPU:</label>
                    <input type="text" id="new-cpu" name="new-cpu" value="<?php echo $laptop->getCpu(); ?>">
                </div>
                <div class="spec">
                    <label>GPU:</label>
                    <input type="text" id="new-gpu" name="new-gpu" value="<?php echo $laptop->getGpu(); ?>">
                </div>
                <div class="spec">
                    <label>RAM:</label>
                    <input type="text" id="new-ram" name="new-ram" value="<?php echo $laptop->getRam(); ?>">
                </div>
                <div class="spec">
                    <label>HDD:</label>
                    <input type="text" id="new-hdd" name="new-hdd" value="<?php echo $laptop->getHdd(); ?>">
                </div>
                <div class="spec">
                    <label>SSD:</label>
                    <input type="text" id="new-ssd" name="new-ssd" value="<?php echo $laptop->getSsd(); ?>">
                </div>
                <div class="spec">
                    <label>Battery:</label>
                    <input type="text" id="new-battery" name="new-battery" value="<?php echo $laptop->getBattery(); ?>">
                </div>
            </div>


        </div>
    </form>

<?php endif; ?>
<script src="js\editProductScript.js"></script>