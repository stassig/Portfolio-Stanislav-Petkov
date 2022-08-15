<?php
if (!isset($_SESSION['member'])) {
    header("Location: index.php?page=login");
}
$id = (int)$_SESSION['member'];
$db = new CartMediator();
$laptops = $db->GetCart($id);
$requests = $db->GetRequests($id);
 $i = -1;
 $totalPrice = $db->GetTotalPrice($id);
?>
<div class="cart">
    <div class="cart-products">
        <div class="cart-info">
            <!-- <li>Image</li> -->
            <li>Name and Price</li>
        </div>
        <?php if ($laptops != null) : ?>
            <?php foreach ($laptops as $laptop) : ?>
                <?php $i++; ?>
                <div class="cart-product">
                    <div class="cart-product-info">
                        <h1><?php echo $laptop->getName(); ?></h1>
                        <h3>Price: <?php echo $laptop->getPrice(); ?> $ </h3>
                        <a href="index.php?page=selectedProduct&id=<?php echo $laptop->getId(); ?>">Go to product page</a> |
                        <a href="handlers/removeRequest.php?id=<?php echo $requests[$i]; ?>">Remove</a>
                    </div>

                    <!-- <div class="cart-product-img">
                    <img id="product-img" src="<?php //echo $laptop->getPhoto(); ?>" />
                </div> -->

                </div>
            <?php endforeach; ?>
        <?php else : ?>
            <h1> Your cart is empty.<h1>
        <?php endif; ?>
    </div>

    <div class="order-summary">
        <h3>Total Price:</h3>
        <h1><?php echo $totalPrice; ?> $ </h1><br><br><br>
        <div class="finish-order-btn">
            <a href="">Finish order</a>
        </div>
    </div>

</div>