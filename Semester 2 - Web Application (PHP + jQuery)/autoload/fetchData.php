<?php
require "../dataAccess/LaptopMediator.php";
//dbo connection
$db = new LaptopMediator();
$brand = $_POST['brand'];
$price = $_POST['price'];
$sql;

$output = $db->FilterLaptop($brand, $price);

echo $output;