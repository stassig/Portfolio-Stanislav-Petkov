<?php 

if(isset($_SESSION['logged']))
    {       
        header('Location: index.php?page=home');
        exit;
    }

    
?>
