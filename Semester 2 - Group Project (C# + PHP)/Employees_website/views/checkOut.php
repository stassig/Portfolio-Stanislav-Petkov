<?php require 'authentication/authentication.php'; ?>

<?php if (isset($_GET['message'])) : ?>
    <div class="success">
        <span class="closebtn" onclick="this.parentElement.style.display='none';" action='<?php unset($_SESSION['msg']); ?>'>&times;</span>
        You have checked-in successfully.
    </div>
<?php endif; ?>

<a href="handlers/checkOutHandler.php" class="checkButton" id="checkOutButton" onclick="return confirm('Are you sure you want to check-out?')">Check-out</a>