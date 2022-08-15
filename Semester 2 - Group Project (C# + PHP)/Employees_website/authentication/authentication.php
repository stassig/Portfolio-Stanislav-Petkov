<?php 

if(!isset($_SESSION['logged']))
    {
        //header("HTTP/1.1 401 Unauthorized");
        header('Location: index.php');
        exit;
    }
if(isset($_SESSION['firstTime'])){
    header('Location: index.php?page=firstLogin');
    exit;
}
?>