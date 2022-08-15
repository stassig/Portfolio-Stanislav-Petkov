<?php
require '../autoload/init.php';

$db = new AttendanceMediator();
$db->CheckOut();
header("location: ../index.php?message=success");