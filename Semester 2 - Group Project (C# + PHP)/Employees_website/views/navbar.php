<nav id="navbar">
    <?php if (isset($_SESSION['firstTime'])) : ?>
        <h2><a href="index.php?page=firstLogin"><span class="text-primary">Media</span> Bazaar</a></h2>

    <?php else :  ?>
        <?php if (isset($_SESSION['logged'])) : ?>
            <h2><a href="index.php?page=home"><span class="text-primary">Media</span> Bazaar</a></h2>
            <ul>
                <li><a href="index.php?page=home">Home</a></li>
                <?php $db = new AttendanceMediator();
                $result = $db->CheckState();
                if ($result == 0) : ?>
                    <li><a href="index.php?page=checkIn">Check-in</a></li>
                <?php elseif ($result == 1) : ?>
                    <li><a href="index.php?page=checkOut">Check-out</a></li>
                <?php endif; ?>
                <li><a href="index.php?page=account">Account</a></li>
                <li><a href="index.php?page=loginCredentials">Change Password</a></li>
            </ul>
            <ul>
                <li>
                    <h5>Username: <?php echo $_SESSION['UsernameSet']; ?> <h5>
                </li>
                <li><a href="index.php?page=logout" onclick="return confirm('Do you really want to exit your profile?')">Logout</a></li>
            </ul>
        <?php else : ?>
            <h2><a href="index.php"><span class="text-primary">Media</span> Bazaar</a></h2>
        <?php endif;  ?>
    <?php endif;  ?>
</nav>