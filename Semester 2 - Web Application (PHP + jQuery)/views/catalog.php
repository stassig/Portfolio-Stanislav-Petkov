<h1 id="catalog-message">You can browse between different brands and price ranges, such as:</h1>
<div class="default-filters">
    <div class="filter-card">
        <div class="filter-image">
            <img class="filter-image" src="img/budget.jpg" />
            <div class="text">
                <h1>Budget Laptops</h1>
                <h3>Under 1000$</h3>
            </div>
        </div>
    </div>
    <div class="filter-card">
        <div class="filter-image">
            <img class="filter-image" src="img/midrange.jpg" />
            <div class="text">
                <h1>Mid-range Laptops</h1>
                <h3>1000$ - 2000$</h3>
            </div>
        </div>
    </div>
    <div class="filter-card">
        <div class="filter-image">
            <img class="filter-image" src="img/highend.jpg" />
            <div class="text">
                <h1>High-end Laptops</h1>
                <h3>Over 2000$</h3>
            </div>
        </div>
    </div>
    
</div>
<a href="#catalog" id="browse-btn">Browse now!</a>

<?php
if (isset($_SESSION['admin'])) {

    echo '<a href="index.php?page=addProduct">
        <input class="add-product-btn" type="button" value="Add a product">
        </a>';
}
?>

<div class="catalog" id="catalog">

    <div class="filter">
        <h1>Filters</h1>
        <div class="filter-option">
        <label for="filters">Price:</label>
        <select class="price" name="price" id="price">
            <option value="" disabled selected hidden>Choose a price range</option>
            <option value="none">Show All</option>
            <option value="budget">Under 1000$</option>
            <option value="midrange">1000$ - 2000$</option>
            <option value="highend">Over 2000$</option>
        </select>
        </div>
        <div class="filter-option">
        <label for="filters">Brand:</label>
        <select class="price" name="brand" id="brand">
            <option value="" disabled selected hidden>Choose a brand</option>
            <option value="none">Show All</option>
            <option value="Acer">Acer</option>
            <option value="Apple">Apple</option>
            <option value="ASUS">ASUS</option>
        </select>
        </div>

    </div>
    <div class="wrapper-flex">
        <?php
        $laptopManager = new LaptopManager();
        $laptops = $laptopManager->GetAll();
        foreach ($laptops as $laptop) : ?>
            <div class="product-card">
                <a href="index.php?page=selectedProduct&id=<?php echo $laptop->getId(); ?>">
                    <div class="product-image">
                        <img class="product-image" src="<?php echo $laptop->getPhoto(); ?>" />
                        <div class="product-info">
                            <h1><?php echo $laptop->getName(); ?></h1>
                            <h3>Price: <?php echo $laptop->getPrice(); ?> $ </h3>
                        </div>
                    </div>
                </a>
            </div>

        <?php endforeach; ?>
    </div>


</div>

<script src="js/catalogScripts.js"></script>