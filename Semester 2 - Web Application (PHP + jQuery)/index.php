<?php
require 'autoload/init.php';

?>

<!doctype html>
<html lang="en">

<head>
    <title>Laptop shop</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="keywords" content="">

    <link rel="stylesheet" href="css/styles.css">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
</head>

<body>

    <div class="page">
        <?php require 'views/navbar.php'; ?>
    </div>
    <?php
    $requestedPage = 'home.php';

    if (isset($_GET['page'])) {
        switch ($_GET['page']) {
            case 'catalog':
                $requestedPage = 'catalog.php';
                break;
            case 'register':
                $requestedPage = 'register.php';
                break;
            case 'login':
                $requestedPage = 'login.php';
                break;
            case 'contacts':
                $requestedPage = 'contacts.php';
                break;
            case 'profile':
                $requestedPage = 'profile.php';
                break;
            case 'logout':
                $requestedPage = 'logout.php';
                break;
            case 'selectedProduct':
                $requestedPage = 'selectedProduct.php';
                break;
            case 'selectedProductEdit':
                $requestedPage = 'selectedProductEdit.php';
                break;
            case 'addProduct':
                $requestedPage = 'addProduct.php';
                break;
            case 'editProfile':
                $requestedPage = 'editProfile.php';
                break;
            case 'cart':
                $requestedPage = 'cart.php';
                break;
        }
    }
    require 'views/' . $requestedPage;
    ?>

</body>

</html>