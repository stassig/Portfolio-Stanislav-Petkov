<?php 

if(!isset($_SESSION['member']))
    {       
        header('Location: index.php?page=home');
        exit;
    }
    
?>

