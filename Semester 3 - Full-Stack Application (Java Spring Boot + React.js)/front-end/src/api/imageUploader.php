<?php

// Define Upload Folder
$target_dir = "../../public/";
$target_file = $target_dir.basename($_FILES["image"]["name"]);
$imageFileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));

// Move File To Uploads Folder
move_uploaded_file($_FILES["image"]["tmp_name"], $target_file);