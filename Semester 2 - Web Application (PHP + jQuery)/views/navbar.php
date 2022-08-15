<nav>
     <?php if (isset($_SESSION['member'])) : ?>    
        <li><a href="index.php">Home</a></li>
        <li><a href="index.php?page=catalog">Catalog</a></li>
        <li><a href="index.php?page=profile">Profile</a></li>
        <li><a href="index.php?page=cart">Cart</a>                
        <li><a href="index.php?page=logout" onclick="return confirm('Are you sure you want to log out?')">Logout</a></li>
        <?php  elseif(isset($_SESSION['admin'])) : ?>  
        <li><a href="index.php">Home</a></li>
        <li><a href="index.php?page=catalog">Catalog</a></li>                     
        <li><a href="index.php?page=logout" onclick="return confirm('Are you sure you want to log out?')">Logout</a></li>
     <?php  else : ?> 
            <li><a href="index.php">Home</a></li>
            <li><a href="index.php?page=catalog">Catalog</a></li>
            <li><a href="index.php?page=login">Login</a></li>    
    <?php endif;  ?>
</nav>
