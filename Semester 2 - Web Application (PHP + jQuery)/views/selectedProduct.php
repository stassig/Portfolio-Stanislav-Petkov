<?php if (isset($_GET['id'])) {
    $id = $_GET['id'];
    $laptopManager = new LaptopManager();
    $laptop = $laptopManager->GetLaptop($id);
}
if ($laptop != null) : ?>

    <div class="page-wrapper">
        <div class="product-img">
            <img class="selected-product-image" src="<?php echo $laptop->getPhoto(); ?>" />
        </div>
        <div class="selected-product-info">
            <h2><?php echo $laptop->getName(); ?></h2>
            <h1><?php echo $laptop->getPrice(); ?> $</h1>
            <?php if (isset($_SESSION['member'])) : ?>
                <a href="handlers/addToCartHandler.php?userId=<?php echo $_SESSION['member']?>&productId=<?php echo $id?>">
                    <input class="add-btn" type="submit" value="Add to cart">
                </a>
            <?php elseif(!isset($_SESSION['member'])&& !isset($_SESSION['admin'])) : ?>
                <a id="not-logged-message" href="index.php?page=login">In order to add this item to your cart, please login into your account.</a>
            <?php endif; ?>
            <?php if (isset($_SESSION['admin'])) : ?>
                <a href="index.php?page=selectedProductEdit&id=<?php echo $laptop->getId(); ?>">
                    <input class="product-edit-btn" type="submit" value="Edit this product">
                </a>
                <a href="handlers/deleteHandler.php?id=<?php echo $laptop->getId() ?>">
                    <input class="delete-btn" type="submit" value="Delete this product" onclick="return confirm('Are you sure you want to delete this product?')">
                </a>
            <?php endif; ?>

        </div>

        <div class="specifications-box">
            <h3>Specifications</h3><br>
            <div class="spec">
                <label for="manufacturer">Manufaturer: <?php echo $laptop->getManufacturer(); ?></label>
            </div>
            <div class="spec">
                <label for="screen-size">Screen size: <?php echo $laptop->getScreenSize(); ?> inches</label>
            </div>
            <!-- <div class="spec">
                <label for="screen-resolution">Screen resolution</label>
            </div>
            <div class="spec">
                <label for="screen-ratio">Aspect ration</label>
            </div>
            <div class="spec">
                <label for="screen-refresh">Refresh rate</label>
            </div> -->
            <div class="spec">
                <label for="cpu">CPU: <?php echo $laptop->getCpu(); ?></label>
            </div>
            <div class="spec">
                <label for="gpu">GPU: <?php echo $laptop->getGpu(); ?></label>
            </div>
            <div class="spec">
                <label for="ram">RAM: <?php echo $laptop->getRam(); ?></label>
            </div>
            <div class="spec">
                <label for="hdd">HDD storage: <?php echo $laptop->getHdd(); ?></label>
            </div>
            <div class="spec">
                <label for="ssd">SSD storage: <?php echo $laptop->getSsd(); ?></label>
            </div>
            <div class="spec">
                <label for="battery">Battery: <?php echo $laptop->getBattery(); ?></label>
            </div>
            <!-- <div class="spec">
                <label for="purpose">Main purpose</label>
            </div>
            <div class="spec">
                <label for="warranty">Warranty</label>
            </div> -->
        </div>
    </div>

<?php endif; ?>