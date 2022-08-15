
<?php
require 'authentication/authentication.php';

session_destroy();
header('location: index.php');

?>


