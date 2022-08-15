<?php
require '../autoload/init.php';

$id = (int)$_GET['id'];
$laptopManager = new LaptopManager();
$laptopManager->Delete($id);

header("location: ../index.php?page=catalog");
