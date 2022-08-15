<?php
require '../autoload/init.php';

$id = (int)$_GET['id'];
$db = new CartMediator();
$db->RemoveFromCart($id);

header("location: ../index.php?page=cart");