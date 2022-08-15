<?php
require 'authentication\authenticationNotLoggedIn.php';
session_destroy();
header('location: index.php');
?>