<?php
require '../autoload/init.php';

if (isset($_POST['password']) && isset($_POST['username'])) {
    $de = new DataEncryption();
    $password = $de->EncryptPassword($_POST['password']);   
       
    $username = $_POST['username'];
    $db = new UserMediator();
    $id = (int)$db->CheckUserLogin($username, $password);
    if ($id > 0) {
        $_SESSION['logged'] = $id;
        if(!$db->CheckContractType($id)){
            $_SESSION['zeroHours'] = 'zeroHours';
        }
        if ($db->CheckFirstTime($id)) {
            $_SESSION['firstTime'] = 'first';
            header("location: ../index.php?page=firstLogin");
        } else {
            header("location: ../index.php?page=home");
        }
        exit;
    } else if ($id == -1) {
        $message = "Your contract has been terminated, you can no longer enter the website.";
        header("location: ../index.php?page=login&message=$message");
    } else {
        $message = "Invalid credentials";
        header("location: ../index.php?page=login&message=$message");
    }
}
