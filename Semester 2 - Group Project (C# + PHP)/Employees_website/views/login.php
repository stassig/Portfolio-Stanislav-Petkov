<div>
    
    <?php unset($_SESSION['firstTime'])?>
    <?php if (isset($_GET['message'])) : ?>
        <div class="alert">
            <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
            <?php echo  $_GET['message']; ?>
        </div>
    <?php endif ?>
<center>
    <form class="login_container" action="handlers/loginHandler.php" method="post">
        <label class="label" for="username">Username:</label><br>
        <input type="text" id="username" name="username" value=""><br>
        <label class="label" for="password">Password:</label><br>
        <input type="password" id="password" name="password" value=""><br><br>
        <input id="btn" type="submit" value="Login">

    </form>
 </center>
</div>