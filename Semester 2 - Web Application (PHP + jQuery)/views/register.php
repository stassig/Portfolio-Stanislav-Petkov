<?php require 'authentication\authenticationLoggedIn.php';?>

<form action="handlers/regHandler.php" method="post" id="registerForm">
    <div class="reg-box">
        <h1>Register</h1>
        <div class="textbox">
            <input type="text" placeholder="E-mail address" id="email" name="email" value=""><br>
        </div>
        <div class="textbox">
            <input type="text" placeholder="Username" id="username" name="username" value=""><br>
        </div>
        <div class="textbox">
            <input type="password" placeholder="Password" id="password" name="password" value=""><br>
        </div>
        <div class="textbox">
            <input type="text" placeholder="Country" id="country" name="country" value=""><br> 
        </div>
        <div class="textbox">
            <input type="text" placeholder="Date of Birth" id="birthDate" name="birthDate" value=""><br>
        </div>
        <input class="btn" type="submit" value="Sign Up">
        <div class="btn-reg">
            <p>
                Already have an account? <a href="index.php?page=login">Click here to login.</a>
            </p>
        </div>
    </div>
</form>
<script src="js/registerScripts.js"></script>
<script src="js/scripts.js"></script>
