<?php
require '../autoload/init.php';

$db = new AttendanceMediator();
$db->CallInSick();
$dbS = new ShiftMediator();
$dbS->CancelShift();
header("location: ../index.php?message=sick");