
<?php
require '../autoload/init.php';

$db = new AttendanceMediator();
$db->CheckIn();
header("location: ../index.php?page=checkOut&message=success");