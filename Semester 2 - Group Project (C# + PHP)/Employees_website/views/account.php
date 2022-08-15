<?php require 'authentication/authentication.php';
$id = (int)$_SESSION['logged'];
$db = new UserMediator();
$user = $db->GetUser($id);
$data = $user->GetUserData();



if (isset($_SESSION['msg'])) {
?><div class="success">
    <span class="closebtn" onclick="this.parentElement.style.display='none';" action='<?php unset($_SESSION['msg']); ?>'>&times;</span>
    Information successfully updated!
  </div><?php
      }
        ?>

<title> Profile Information </title>
<form action="handlers/UpdateInfo.php" method="POST" enctype="multipart/form-data">
  <div class="Edit">
    <h1> Editable Information </h1>

    <label for="email">Email:</label>
    <input type="email" class="input" value="<?php echo $user->getEmail(); ?>" name="email"><br><br>
    <label for="address">Address:</label>
    <input type="text" class="input" value="<?php echo $user->getStreetName(); ?>" name="address"><br><br>
    <label for="address">Address Number:</label>
    <input type="text" class="input" value="<?php echo $user->getStreetNumber(); ?>" name="addressnum"><br><br>
    <label for="city">Place of residence:</label>
    <input type="text" class="input" value="<?php echo $user->getTown(); ?>" name="town"><br><br>
    <label for="country">Country:</label>
    <input type="text" class="input" value="<?php echo $user->getCountry(); ?>" name="country"><br><br>
    <label for="zipcode">ZipCode:</label>
    <input type="text" class="input" value="<?php echo $user->getZipCode(); ?>" name="zipCode"><br><br>
    <label for="fname">First name:</label>
    <input type="text" class="input" value="<?php echo $user->getFirstName(); ?>" name="firstName"><br><br>
    <label for="famname">Family name:</label>
    <input type="text" class="input" value="<?php echo $user->getLastName(); ?>" name="familyName"><br><br>

    <button type="submit" value="Save changes" onclick="return confirm('Confirm changes?')" name="Update" style="margin:5px" id="btnSubmitDetails"> Edit </button>

  </div>

  <div class="Non-editable">
    <h1>Non-edtitable Information</h1>
    <label>Username:</label>
    <input type="text" class="input" value="<?php echo $user->getUsername(); ?>" name="username" disabled><br><br>
    <label> Birthday:</label>
    <input type="text" class="input" value="<?php echo $user->getBirthDate(); ?>" name="dateOfBirth" disabled><br><br>
    <label> Date of first working day:</label>
    <input type="text" class="input" value="<?php echo $user->getFirstWorkingDate(); ?>" disabled><br><br>
    <label> Date of last working day:</label>
    <input type="text" class="input" value="<?php echo $user->getLastWorkingDate(); ?>" disabled><br><br>
    <label> Hourly wage:</label>
    <input type="text" class="input" value="<?php echo $user->getHourlyWage(); ?>" disabled><br><br>
    <label> Account number:</label>
    <input type="text" class="input" value="<?php echo $user->getId(); ?>" disabled><br><br>
    <label> Kind of contract:</label>
    <input type="text" class="input" value="<?php echo $user->getContractType(); ?>" disabled><br><br>
    
  </div>

  <div class="ProfilePic">

    <img src="
    <?php $photo = $user->getPhoto();
    if ($photo != "") {
      echo $photo;
    } else {
      echo "img\placeholder.png";
    }
    ?> " id="photo">

    <label>Choose Profile Picture </label><br>
    <input type="file" id="imageUpload" name = "imageUpload">

  </div>
</form>
<script src="js\editCredentials.js"></script>
<?php
// $id = (int)$_SESSION['logged'];
// $db = new UserMediator();
// if (isset($_POST['submit'])) {
//   $upload_dir = "uploads/";
//   $maxSize = 2000000;
//   $type = $_FILES["file"]["type"];
//   $name = $_FILES["file"]["name"];
//   $tmp_name = $_FILES["file"]["tmp_name"];
//   $fileExtension = explode(".", $name);
//   $fileExtension = end($fileExtension);
//   $ex1 = rand(1, 10000);
//   @$newName = $ex1 . "." . $fileExtension;
//   $filepath = $upload_dir . $newName;
//   if (empty($name)) {
//     echo "<h1>Please select a file</h1>";
//   } elseif ($_FILES['file']['size'] > $maxSize) {
//     echo "please Select max size of 2MB";
//   } elseif ($type == "image/jpeg" || $type == "image/jpg" || $type == "image/png") {
//     move_uploaded_file($tmp_name, $filepath);
//     $sql = ("INSERT INTO employee SET img_name=? WHERE id=:id");
//     $sth = $this->conn->prepare($sql);
//     $sth->execute([
//       ':id' => $id
//     ]);
//     $ok = $add->execute(array($newName));
//     if ($ok) {
//       echo "saved";
//       header("Refresh:2");
//     }
//   }
// }

?>