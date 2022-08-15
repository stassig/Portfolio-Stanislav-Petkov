<?php require 'authentication/firstLoginAuthentication.php';  ?>

<div>
    <?php if (isset($_GET['message'])) : ?>
       
        <div class="alert">
            <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
            <?php echo  $_GET['message']; ?>
        </div>           
        
    <?php endif ?>
    <center>
    <form class="reset_password"action="handlers/firstLoginHandler.php" method="post">
        <label class="label" for="newPassword">New password:</label><br>
        <input type="password" id="newPassword" name="newPassword" value=""><br>
        <label class="label" for="repeatNewPassword">Repeat password:</label><br>
        <input type="password" id="repeatNewPassword" name="repeatNewPassword" value=""><br><br>
        <input id="btn" type="submit" value="Submit">

    </form>
    </center>
</div>