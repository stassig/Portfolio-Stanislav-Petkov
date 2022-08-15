<?php
require '../autoload/init.php';

unset($_SESSION['msg']);

if (isset($_POST['Update'])) {
        $db = new UserMediator();
        $id = (int)$_SESSION['logged'];
        $user = $db->GetUser($id);

        if ($_FILES['imageUpload']['size'] != 0) {
                echo 'Success';
                $targetDir = "../img/";
                $target_file = $targetDir . basename($_FILES["imageUpload"]["name"]);
                $imageFileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));

                move_uploaded_file($_FILES["imageUpload"]["tmp_name"], $target_file);
                $target_file = "img/" . basename($_FILES["imageUpload"]["name"]);

                $user->UpdateDetails(
                        $_POST['firstName'],
                        $_POST['familyName'],
                        $_POST['address'],
                        $_POST['addressnum'],
                        $_POST['zipCode'],
                        $_POST['town'],
                        $_POST['country'],
                        $_POST['email'],
                        $target_file
                );
        } else {
                $user->UpdateDetails(
                        $_POST['firstName'],
                        $_POST['familyName'],
                        $_POST['address'],
                        $_POST['addressnum'],
                        $_POST['zipCode'],
                        $_POST['town'],
                        $_POST['country'],
                        $_POST['email'],
                        ""
                );
        }



        $_SESSION['msg'] = 'you have succesffully changed user info';


        header("Location: ../index.php?page=account");
}
