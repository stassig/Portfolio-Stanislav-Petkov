<?php


require dirname(__FILE__).'/../autoload/init.php';
// require 'autoload/init.php';


class CartMediator extends DatabaseMediator{

    public function GetCart(int $userid)
    {
        $sql = 'SELECT * FROM cart INNER JOIN laptops ON cart.productId = laptops.id WHERE userId = '.$userid;
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

    public function GetRequests($userid)
    {
        $sql = 'SELECT id FROM cart WHERE userId = :userid';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':userid' => $userid        
        ]);
        $requests = array();
        $result = $sth->fetchAll();
        foreach ($result as $row) {
            $requests[] = $row['id'];
        }

        return $requests;
    }

    public function AddToCart($userId, $productId)
    {
        $sql = 'INSERT INTO cart(userId, productId) VALUES(:userId, :productId)'; 
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':productId' => $productId,
            ':userId' => $userId
        ]);

        return $this->conn->lastInsertId();
    }

    public function RemoveFromCart($id)
    {
        $sql = 'DELETE from cart WHERE id = :id';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
    }

    public function GetTotalPrice($userId)
    {
        $sql = 'SELECT price FROM cart INNER JOIN laptops ON cart.productId = laptops.id WHERE userId = :userId';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':userId' => $userId
        ]);
        if ($sth->rowCount() >= 1) {
            $totalPrice = 0;
            $result = $sth->fetchAll();

            foreach ($result as $row) {
                
               $totalPrice +=  (int)$row['price'];                                         
            }
            return $totalPrice;
        } else {
            return 0;
        }
    }

}