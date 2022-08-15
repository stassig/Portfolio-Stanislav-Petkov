<?php
require '../autoload/init.php';

if (isset($_POST['newPassword']) && isset($_POST['repeatNewPassword'])) {


    $newPassword = $_POST['newPassword'];
    $repeatNewPassword = $_POST['repeatNewPassword'];

    if (strlen($newPassword) > 4 && strlen($repeatNewPassword) > 4) {
        if ($newPassword == $repeatNewPassword) {
            $de = new DataEncryption();
            $newPassword = $de->EncryptPassword($repeatNewPassword);
            $db = new UserMediator();
            $id = (int)$_SESSION['logged'];
            $db->UpdateFirstTimeLogin($id, $newPassword);
            unset($_SESSION['firstTime']);
            header("location: ../index.php?page=home");
        } else {
            $message = "The passwords do not match.";
            header("location: ../index.php?page=firstLogin&message=$message");
        }
    } else {
        $message = "Password should be at least 5 characters long.";
        header("location: ../index.php?page=firstLogin&message=$message");
    }
} 
?>