<?php require 'autoload/init.php'; ?>

<!DOCTYPE html>
<html lang="en">

<head>
   <meta charset="utf-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>Media Bazaar</title>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
   <link rel="stylesheet" href="CSS/style.css">
   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>   
</head>

<body id="home">

   <div id="header_container">
      <?php require 'views/navbar.php'; ?>
   </div>
   <?php
   ini_set('display_errors', 1);
   ini_set('display_startup_errors', 1);
   error_reporting(E_ALL);

   if (isset($_SESSION['logged'])) {
      $requiredPage = 'home.php';
   } else {
      $requiredPage = 'login.php';
   }

   if (isset($_GET['page'])) {
      switch ($_GET['page']) {
         case 'account':
            $requiredPage = 'account.php';
            break;
         case 'loginCredentials':
            $requiredPage = 'loginCredentials.php';
            break;
         case 'home':
            $requiredPage = 'home.php';
            break;
         case 'logout':
            $requiredPage = 'logout.php';
            break;
         case 'firstLogin':
            $requiredPage = 'firstLogin.php';
            break;
         case 'checkIn':
            $requiredPage = 'checkIn.php';
            break;
         case 'checkOut':
            $requiredPage = 'checkOut.php';
            break;
      }
   }
   require 'views/' . $requiredPage;
   ?>
   <div id="footer_container" style="width: 100%; height:50px; margin-top:5000px">
      <p align="Center">Copy right &copy; 2021</p>
   </div>

</body>