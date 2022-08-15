<?php require 'authentication/authentication.php';  ?>
<div>
        <?php if (isset($_GET['message'])) : ?>

                <?php if ($_GET['message'] == "Password has been changed successfully.") : ?>
                        <div class="success">
                                <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                                <?php echo $_GET['message'];?>
                        </div>
                <?php else : ?>

                        <div class="alert">
                                <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                                <?php echo  $_GET['message']; ?>
                        </div>
                <?php endif ?>
        <?php endif ?>
        <center>
        <form class="reset_password" method="post" action="handlers/passwordChangeHandler.php">
        <img scr="img\budget.jpg" >   
                <label class="label" for="currentPassword">Current password:</label><br>
                <input type="password" id="currentPassword" name="currentPassword" value=""><br>
                <label class="label" for="newPassword">New password:</label><br>
                <input type="password" id="newPassword" name="newPassword" value=""><br>
                <label class="label" for="confirmPassword">Confirm password:</label><br>
                <input type="password" id="confirmPassword" name="confirmPassword" value=""><br><br>
                <input id="btn" type="submit" value="Submit">

        </form>
         </center>
</div>