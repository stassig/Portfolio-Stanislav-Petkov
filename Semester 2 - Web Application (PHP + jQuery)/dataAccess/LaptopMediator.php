<?php


require dirname(__FILE__).'/../autoload/init.php';
// require 'autoload/init.php';


class LaptopMediator extends DatabaseMediator
{
    public function AddLaptop(Laptop $laptop): int
    {
        $sql = 'INSERT INTO laptops(name, price, image_path, manufacturer, screen_size, cpu, gpu, ram, hdd, ssd, battery) 
        VALUES( :name, :price, :photo, :manufacturer, :screenSize, :cpu, :gpu, :ram, :hdd, :ssd, :battery)';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':name' => $laptop->getName(),
            ':price' => $laptop->getPrice(),
            ':photo' => $laptop->getPhoto(),
            ':manufacturer' => $laptop->getManufacturer(),
            ':screenSize' => $laptop->getScreenSize(),
            ':cpu' => $laptop->getCpu(),
            ':gpu' => $laptop->getGpu(),
            ':ram' => $laptop->getRam(),
            ':hdd' => $laptop->getHdd(),
            ':ssd' => $laptop->getSsd(),
            ':battery' => $laptop->getBattery(),
        ]);

        return $this->conn->lastInsertId();
    }

    public function GetLaptop(int $id) : Laptop
    {
        $sql = 'SELECT * FROM  laptops WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);

        if ($sth->rowCount() == 1) {
            $row = $sth->fetch();
            return new Laptop(
                $row['id'],
                $row['name'],
                $row['price'],
                $row['image_path'],
                $row['manufacturer'],
                $row['screen_size'],
                $row['cpu'],
                $row['gpu'],
                $row['ram'],
                $row['hdd'],
                $row['ssd'],
                $row['battery']
            );
        } else {
            return null;
        }
    }

    public function GetAllLaptops()
    {
        $sql = 'SELECT * FROM laptops';
        $sth = $this->conn->prepare($sql);
        $sth->execute();
        if ($sth->rowCount() >= 1) {
            $laptops = array();
            $result = $sth->fetchAll();
            

            foreach ($result as $row) {
                
                $laptops[] = new Laptop(
                    $row['id'],
                    $row['name'],
                    $row['price'],
                    $row['image_path'],
                    $row['manufacturer'],
                    $row['screen_size'],
                    $row['cpu'],
                    $row['gpu'],
                    $row['ram'],
                    $row['hdd'],
                    $row['ssd'],
                    $row['battery']
                );
            }
            return $laptops;
        } else {
            return null;
        }
    }

    public function DeleteLaptop(int $id)
    {
        $sql = 'DELETE from laptops WHERE id = :id';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
    }

    public function UpdateLaptop(Laptop $laptop)
    {
        $sql = 'UPDATE laptops SET name = :name, price = :price, manufacturer = :manufacturer, image_path = :photo,
         screen_size = :screenSize, cpu = :cpu, gpu = :gpu, ram = :ram, hdd = :hdd, ssd = :ssd, battery = :battery WHERE id = :id';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $laptop->getId(),
            ':name' => $laptop->getName(),
            ':price' => $laptop->getPrice(),            
            ':manufacturer' => $laptop->getManufacturer(),
            ':screenSize' => $laptop->getScreenSize(),
            ':cpu' => $laptop->getCpu(),
            ':gpu' => $laptop->getGpu(),
            ':ram' => $laptop->getRam(),
            ':hdd' => $laptop->getHdd(),
            ':ssd' => $laptop->getSsd(),
            ':battery' => $laptop->getBattery(),
            ':photo' => $laptop->getPhoto(),
        ]);
    }

    public function FilterLaptop(string $brand, string $price)
    {
        $sql = "";

        if ($brand == "none" || $brand == "") {
            $sql = "SELECT * 
                    FROM laptops 
                    WHERE manufacturer IS NOT NULL ";
        } else {
            $sql = "SELECT * 
                    FROM laptops 
                    WHERE manufacturer = '$brand' ";
        }
        
        if ($price != "none" && $price != "")  
        {
                    $sql .= "AND price ";
                    if ($price == "budget") {
                        $sql .= "<= 1000";
                    } else if ($price == "midrange") {
                        $sql .= "BETWEEN 1000 AND 2000";
                    } else if ($price == "highend") {
                        $sql .= ">= 2000";
                    }
        }

        $sth = $this->conn->prepare($sql);
        $sth->execute();
        $result = $sth->fetchAll();
        $rows = $sth->rowCount();
        $output = "";

        if ($rows > 0) {
            foreach ($result as $laptop) {
                $output .=
                "<div class=\"product-card\">
                <a href=\"index.php?page=selectedProduct&id=".$laptop['id']."\">
                    <div class=\"product-image\">
                        <img class=\"product-image\" src=\"".$laptop['image_path']."\"/>
                        <div class=\"product-info\">
                            <h1>".$laptop['name']."</h1>
                            <h3>Price: ".$laptop['price']."$ </h3>
                        </div>
                    </div>
                </a>
            </div>";
            }
        } else {
            $output .= "No products found.";
        }

        echo $output;
    }   
}
?>