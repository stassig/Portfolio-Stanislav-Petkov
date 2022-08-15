<?php
require '../autoload/init.php';

if (
    !empty($_POST['new-product-name']) || !empty($_POST['new-product-price']) || !empty($_POST['new-product-manufacturer']) ||
    !empty($_POST['new-product-screen']) || !empty($_POST['new-product-cpu']) || !empty($_POST['new-product-gpu']) || !empty($_POST['new-product-ram']) ||
    !empty($_POST['new-product-hdd']) || !empty($_POST['new-product-ssd']) || !empty($_POST['new-product-battery']) || !empty($_POST['new-imageUpload'])
) {    

    $name = $_POST['new-product-name'];
    $price = $_POST['new-product-price'];
    $manufacturer = $_POST['new-product-manufacturer'];
    $screenSize = $_POST['new-product-screen'];
    $cpu = $_POST['new-product-cpu'];
    $gpu = $_POST['new-product-gpu'];
    $ram = $_POST['new-product-ram'];
    $hdd = $_POST['new-product-hdd'];
    $ssd = $_POST['new-product-ssd'];
    $battery = $_POST['new-product-battery'];

    $targetDir = "../img/";
    $target_file = $targetDir . basename($_FILES["new-imageUpload"]["name"]);
    $imageFileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));
    
    //Image validations
    
    if (file_exists($target_file)) {
        echo "File with this name already exists.";
    } else if ($_FILES["new-imageUpload"]["size"] > 500000) {
        echo "The submitted image file is too large.";
    } else if ($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg" && $imageFileType != "gif") {
        echo "You can upload only files in JPG, JPEG, PNG & GIF formats.";
     } else if (!move_uploaded_file($_FILES["new-imageUpload"]["tmp_name"], $target_file)) {
       echo 'There was an error while uploading your file.';
     
    }else {
        $target_file = "img/" . basename($_FILES["new-imageUpload"]["name"]);
        $laptop = new Laptop(-10, $name, $price, $target_file, $manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery);

        $laptopManager = new LaptopManager();
        $laptopManager->Add($laptop);

        echo 'success';
    }
} else {
    echo 'Please fill in all of the required fields.';
}
