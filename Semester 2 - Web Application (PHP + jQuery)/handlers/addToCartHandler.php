<?php
require '../autoload/init.php';

$productId = $_GET['productId'];
$userId = $_GET['userId'];

$db = new CartMediator();
$db->AddToCart($userId, $productId);

header("location: ../index.php?page=cart");
?>
