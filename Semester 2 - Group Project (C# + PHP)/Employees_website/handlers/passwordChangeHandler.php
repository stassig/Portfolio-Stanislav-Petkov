<?php
require '../autoload/init.php';

if (isset($_POST['currentPassword']) && isset($_POST['newPassword']) && isset($_POST['confirmPassword'])) {
    $de = new DataEncryption();

    $currentPassword = $de->EncryptPassword($_POST['currentPassword']);
    $newPassword = $_POST['newPassword'];
    $repeatNewPassword = $_POST['confirmPassword'];

    $db = new UserMediator();
    $id = (int)$_SESSION['logged'];
    if($db->CheckCurrentPassword($id, $currentPassword)){

        if (strlen($newPassword) > 4 && strlen($repeatNewPassword) > 4) {
            if ($newPassword == $repeatNewPassword) {
                
                $newPassword = $de->EncryptPassword($repeatNewPassword);
                $db->UpdateCurrentPassword($id, $newPassword); 
                $message = "Password has been changed successfully.";              
                header("location: ../index.php?page=loginCredentials&message=$message");
            } else {
                $message = "The passwords do not match.";
                header("location: ../index.php?page=loginCredentials&message=$message");
            }
        } else {
            $message = "Password should be at least 5 characters long.";
            header("location: ../index.php?page=loginCredentials&message=$message");
        }

    }else{
        $message = "Current password is wrong.";
        header("location: ../index.php?page=loginCredentials&message=$message");
    }

   
} 
?>