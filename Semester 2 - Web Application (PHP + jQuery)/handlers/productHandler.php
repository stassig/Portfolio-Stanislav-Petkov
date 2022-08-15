
<?php
require '../autoload/init.php';

if (
    !empty($_POST['new-manufacturer']) || !empty($_POST['new-battery']) || !empty($_POST['imageUpload']) ||
    !empty($_POST['new-screen-size']) || !empty($_POST['new-cpu']) || !empty($_POST['new-gpu'])  ||
    !empty($_POST['new-hdd']) || !empty($_POST['new-ssd']) || !empty($_POST['new-ram'])
) {

    $manufacturer = $_POST['new-manufacturer'];
    $screenSize = $_POST['new-screen-size'];
    $cpu = $_POST['new-cpu'];
    $gpu = $_POST['new-gpu'];
    $ram = $_POST['new-ram'];
    $hdd = $_POST['new-hdd'];
    $ssd = $_POST['new-ssd'];
    $battery = $_POST['new-battery'];

    $id = (int)$_GET['id'];
    $laptopManager = new LaptopManager();
    //If a new image has been submitted
    if ($_FILES['imageUpload']['size'] != 0) {
        $targetDir = "../img/";
        $target_file = $targetDir . basename($_FILES["imageUpload"]["name"]);
        $imageFileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));
        //Image validations
        if (file_exists($target_file)) {
            echo "File with this name already exists.";
        } else if ($_FILES["imageUpload"]["size"] > 500000) {
            echo "The submitted image file is too large.";
        } else if ($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg" && $imageFileType != "gif") {
            echo "You can upload only files in JPG, JPEG, PNG & GIF formats.";
        } else if (!move_uploaded_file($_FILES["imageUpload"]["tmp_name"], $target_file)) {
            echo 'There was an error while uploading your file.';
        } else {
            $target_file = "img/" . basename($_FILES["imageUpload"]["name"]);
            $laptopManager->Update($id, $manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery, $target_file);

            echo $id;
        }
    } else {
        $laptopManager->Update($id, $manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery, "");
        echo $id;
    }
} else {
    echo 'Please fill in all of the required fields.';
}
