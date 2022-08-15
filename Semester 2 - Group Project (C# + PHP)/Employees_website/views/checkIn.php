<?php require 'authentication/authentication.php'; ?>

<a href="handlers/checkInHandler.php" class="checkButton" id="checkInButton">Check-in</a>

<a href="handlers/callInSickHandler.php" id="callInSickButton" onclick="return confirm('Are you sure you want to call in sick?')">Call in sick</a>