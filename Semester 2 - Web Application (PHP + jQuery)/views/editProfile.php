
<?php require 'authentication\authenticationMember.php';

$id = (int)$_SESSION['member'];
$userManager = new UserManager();
$member = $userManager->GetUser($id);
if ($member != null) : ?>

    <form action="handlers/editProfileHandler.php" method="post" id="editProfileForm">
        <div class="profile-page-wrapper">
            <div class="edit-profile-image">
                <img src="img/profile_placeholder.png" />
            </div>
            <div class="profile-info">
                <input class="save-btn" type="submit" value="Save changes" onclick="return confirm('Confirm changes?')">
            </div>

            <div class="details-box">
                <h3>Details</h3><br>
                <div class="detail">
                    <label>Username:</label>
                    <input type="text" id="new-username" name="new-username" value="<?php echo $member->getUsername(); ?>">
                </div>
                <div class="detail">
                    <label>Email:</label>
                    <input type="text" id="new-email" name="new-email" value="<?php echo $member->getEmail(); ?>">
                </div>
                <div class="detail">
                    <lable>Password:</lable>
                    <input type="password" id="new-password" name="new-password" value="<?php 
                    $de = new DataEncryption();
                    $password = $de->DecryptPassword($member->getPassword()); 
                    echo $password; 
                    ?>">
                </div>
                <div class="detail">
                    <lable>Country:</lable>
                    <input type="text" id="new-country" name="new-country" value="<?php echo $member->getCountry(); ?>">
                </div>
                <div class="detail">
                    <lable>Date of Birth:</lable>
                    <input type="text" id="new-birthDate" name="new-birthDate" value="<?php echo $member->getDateOfBirth(); ?>">
                </div>
            </div>
        </div>
    </form>
    <script src="js/editProfileScripts.js"></script>
<?php endif ?>
