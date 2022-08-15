<?php
require '../autoload/init.php';

if (!empty($_POST['password']) && !empty($_POST['email'])) {

    $password = $_POST['password'];
    $email = $_POST['email'];

    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        echo 'Email is in invalid format.';
    } else {
        $de = new DataEncryption();
        $password = $de->EncryptPassword($password); 
        $userManager = new UserManager();
        $result = $userManager->CheckLoginCredentials($email, $password);

        if ($result == 2) {
            //regular user case
            $_SESSION['member'] = $userManager->GetID($email, $password);
            $_SESSION['logged'] = "Successful login";
            echo 1;
        } else if ($result == 1) {
            //Admin case
            $_SESSION['admin'] = "Logged as admin";
            $_SESSION['logged'] = "Successful login";
            echo 1;
        } else {
            echo 'Invalid credentials.';
        }
    }
} else {
    echo 'Please fill in both fields.';
}
