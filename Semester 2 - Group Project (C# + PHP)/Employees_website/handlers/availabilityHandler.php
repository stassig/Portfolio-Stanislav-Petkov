<?php
require '../autoload/init.php';

$id = (int)$_SESSION['logged'];
$db = new UserMediator();

if (isset($_POST['days'])) {

    if (count($_POST['days']) > 2) {
        $message = "You can only select 2 days of the week, when you are not available.";
        header("location: ../index.php?page=home&message=$message");
        exit;
    } else {
        $weekDays = implode(',', $_POST['days']) ;
        $db->ChangeAvailableDays($id, $weekDays);
    }
} else {
    $weekDays = 'All';
    $db->ChangeAvailableDays($id, $weekDays);
}

if (isset($_POST['nightShift'])) {
    $db->ChangeNightShiftAvailability($id, false);
} else {
    $db->ChangeNightShiftAvailability($id, true);
}

header("location: ../index.php?page=home");

?>
