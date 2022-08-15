<?php 
require '../autoload/init.php';
$username = $_POST['new-username'];
$password = $_POST['new-password'];
$email = $_POST['new-email'];
$country = $_POST['new-country'];
$birthDate = $_POST['new-birthDate'];

if (!empty($_POST['new-username']) && !empty($_POST['new-password']) && !empty($_POST['new-email']) && !empty($_POST['new-birthDate']) && !empty($_POST['new-country'])) {

    $username = $_POST['new-username'];
    $password = $_POST['new-password'];
    $email = $_POST['new-email'];
    $country = $_POST['new-country'];
    $birthDate = $_POST['new-birthDate'];

    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        echo 'Email is in invalid format.';
    } else if (strlen($password) < 5) {
        echo "Password is too short!";
    } else if (strlen($username) < 5) {
        echo "Username is too short!";
    } else {
        $de = new DataEncryption();
        $password = $de->EncryptPassword($password); 
        $id = (int)$_SESSION['member'];
        $userManager = new UserManager();
        $userManager->Update($id, $email, $password, $username, $birthDate, $country);
        echo 'success';
    }
} else {
    echo 'All required fields, should be filled in.';
}
