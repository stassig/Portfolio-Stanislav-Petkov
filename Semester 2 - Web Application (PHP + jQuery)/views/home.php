<?php if (isset($_SESSION['member'])) : ?>
    <?php $id = (int)$_SESSION['member'];
    $userManager = new UserManager();
    $member = $userManager->GetUser($id);
    if ($member != null) : ?>

        <div class="home-page-message">
            <?php if (isset($_GET['message'])) : ?>
                <h2 style="font-size:45px"> <?php echo  $_GET['message']; ?></h2>
            <?php else : ?>
                <h2 style="font-size:60px">Welcome, <?php echo $member->getUsername(); ?> !</h2>
            <?php endif ?>
        </div>
    <?php endif ?>
<?php elseif (isset($_SESSION['admin'])) : ?>
    <div class="home-page-message">
        <h2 style="font-size:60px"> Welcome, Admin !</h2>
    </div>

<?php endif ?>
<div class="home-page-default">
    <div class="announcement-box">
        <div class="announcement">
            <h1>Announcement 1</h1>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Asperiores, quibusdam inventore at a voluptates id.</p>
        </div>
        <div class="announcement">
            <h1>Announcement 2</h1>
            <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repellat, possimus.</p>
        </div>
    </div>
</div>



<div class="footer-container">
    <footer>
        <h3 id="contacts">
            Contacts <br>
        </h3>
        <li id="contact-info">
            - E-mail address: k.balev@gmail.com<br><br>
            - Phone number: 0697340523
        </li>
    </footer>
</div>

<script src="js/homeScripts.js"></script>