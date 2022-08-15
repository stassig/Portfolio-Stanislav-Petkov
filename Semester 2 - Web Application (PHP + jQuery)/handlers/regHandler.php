<?php
require '../autoload/init.php';

if (!empty($_POST['username']) && !empty($_POST['password']) && !empty($_POST['email']) && !empty($_POST['birthDate']) && !empty($_POST['country'])) {

    $username = $_POST['username'];
    $password = $_POST['password'];
    $email = $_POST['email'];
    $country = $_POST['country'];
    $birthDate = $_POST['birthDate'];

    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        echo 'Email is in invalid format.';
    } else if (strlen($password) < 5) {
        echo "Password is too short!";
    } else if (strlen($username) < 5) {
        echo "Username is too short!";
    } else {

        $userManager = new UserManager();
        $check = $userManager->CheckRegistration($username, $email);

        if ($check == 1) {
            echo "Username already exists.";
        } else if ($check == 2) {
            echo "Email already exists.";
        } else {
            $de = new DataEncryption();
            $password = $de->EncryptPassword($_POST['password']); 
            $member = new Member($email, $password, $username, $birthDate, $country);

            $id = $userManager->Add($member);
            $_SESSION['member'] = $id;
            $_SESSION['logged'] = "Successful login";

            echo "Welcome $username, thank you for registering!";
        }
    }
} else {
    echo "One or more fields have missing information.";
}
