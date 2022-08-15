<?php require 'authentication\authenticationMember.php';

$id = (int)$_SESSION['member'];
$userManager = new UserManager();
$member = $userManager->GetUser($id);
if ($member != null) : ?>


    <div class="profile-page-wrapper">
        <div class="profile-image">
            <img src="img/profile_placeholder.png" />
        </div>
        <div class="profile-info">
            <h1><?php echo $member->getUsername(); ?></h1>
            <a href="index.php?page=editProfile">
                <input class="edit-btn" type="submit" value="Edit details">
            </a>
        </div>

        <div class="details-box">
            <h3>Details</h3><br>
            <div class="detail">
                <label for="email">Email: <?php echo $member->getEmail(); ?></label>
            </div>

            <div class="detail">
                <label for="password">Password: ***********</label>
            </div>
            <div class="detail">
                <label for="country">Country: <?php echo $member->getCountry(); ?></label>
            </div>
            <div class="detail">
                <label for="date-of-birth">Birth date: <?php echo $member->getDateOfBirth(); ?></label>
            </div>
        </div>
    </div>

<?php endif ?>