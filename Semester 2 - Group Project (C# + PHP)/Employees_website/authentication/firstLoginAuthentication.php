<?php 

if(!isset($_SESSION['firstTime']))
    {
        header('Location: index.php');                
        exit;
    }

?>