<?php require 'authentication\authenticationLoggedIn.php';?>

<form action="handlers/loginHandler.php" method="post" id= "loginForm">
    <div class="login-box">
        <h1>Login</h1>
        <div class="textbox">
            <input type="text" placeholder="E-mail address" id="email" name="email" value=""><br>
        </div>
        <div class="textbox">
            <input type="password" placeholder="Password" id="password" name="password" value=""><br>
        </div>
        <input class="btn" type="submit" value="Sign in" id="btnSubmit">
        <div class="btn-reg">
            <p>
                Don't have an account? <a href="index.php?page=register">Click here to register.</a>
            </p>
        </div>
    </div>
</form>
<script src="js/loginScripts.js"></script>