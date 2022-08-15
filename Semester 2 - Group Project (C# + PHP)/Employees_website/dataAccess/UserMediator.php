<?php

require dirname(__FILE__).'/../autoload/init.php';


class UserMediator extends DatabaseMediator
{

    public function CheckUserLogin($username, $password): int
    {
        $sql = 'SELECT id ,username, password, contract_type FROM employee WHERE password=:password AND username=:username';
        $sth = $this->conn->prepare($sql);

        $sth->execute([
            ':password' => $password,
            ':username' => $username,
        ]);

        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();

            $_SESSION['UsernameSet'] = $result['username'];
            if (strval($result['contract_type']) != 'Terminated') {
                return (int)$result['id'];
            } else {
                return -1;
            }
        } else {
            return 0;
        }
    }

    public function CheckContractType($id) : bool
    {
        $sql = 'SELECT contract_type FROM employee WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
        
        $result = $sth->fetch();
        if (strval($result['contract_type']) != 'ZeroHours') {
            return true;
        } else {
            return false;
        }
    }

    public function CheckFirstTime(int $id): bool
    {
        $sql = 'SELECT first_time_login FROM employee WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
        $result = $sth->fetch();
        if (strval($result['first_time_login']) == 'Yes') {
            return true;
        } else {
            return false;
        }
    }

    public function UpdateFirstTimeLogin(int $id, string $newPassword): void
    {
        $sql = 'UPDATE employee SET first_time_login = :firstTime, password = :newPassword WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':firstTime' => 'No',
            ':newPassword' => $newPassword,
            ':id' => $id
        ]);

        $sql = 'UPDATE user SET password = :newPassword WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':newPassword' => $newPassword,
            ':id' => $id
        ]);
    }

    public function UpdateCurrentPassword(int $id, string $newPassword)
    {
        $sql = 'UPDATE employee SET  password = :newPassword WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':newPassword' => $newPassword,
            ':id' => $id
        ]);

        $sql = 'UPDATE user SET  password = :newPassword WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':newPassword' => $newPassword,
            ':id' => $id
        ]);
    }

    public function CheckCurrentPassword(int $id, string $currentPassword): bool
    {
        $sql = 'SELECT password FROM employee WHERE id = :id';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
        $result = $sth->fetch();
        if ($result['password'] == $currentPassword) {
            return true;
        } else {
            return false;
        }
    }

    public function GetUser(int $id): User
    {
        $sql = 'SELECT * FROM  employee WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();
            return new User(
                $result['id'],
                $result['password'],
                $result['username'],
                $result['first_name'],
                $result['last_name'],
                $result['street_name'],
                $result['street_number'],
                $result['zipcode'],
                $result['town'],
                $result['country'],
                $result['email'],
                $result['birth_date'],
                $result['contract_type'],
                $result['first_working_date'],
                $result['last_working_date'],
                $result['hourly_wage'],
                $result['photo']
               
            );
        } else {
            return null;
        }
    }
    public function GetUsernameByID($id): string
    {
        $sql = 'SELECT username FROM  employee WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();
            return $result;
        } else {
            return null;
        }
    }

    
    public function EditUser($id, $email, $streetName, $streetNumber, $town, $country, $zipCode, $firstName, $lastName, $photo)
    {

		$query = 'UPDATE employee SET email = :email, street_name = :street, street_number = :streetnum, town = :town, country = :country, zipcode = :zip, first_name = :fnam, last_name = :lnam, photo=:photo WHERE employee.`id` = :id';
		$values = array(':id' => $id ,':email' => $email,':street' => $streetName, ':streetnum' =>$streetNumber , ':town' => $town, ':country' => $country ,':zip' => $zipCode, ':fnam' => $firstName,  ':lnam' => $lastName, ':photo' => $photo);

		try {
			$res = $this->conn->prepare($query);
			$res->execute($values);
		} catch (PDOException $e) {
			throw new Exception('Database query error'.$e->getMessage());
		}        
    } 



    public function ChangeNightShiftAvailability($id, bool $available)
    {
        if ($available) {
            $availability = "Available";
        } else {
            $availability = "Unavailable";
        }

        $sql = 'UPDATE employee SET nightShifts = :nightAvailability WHERE id = :id;';
        $sth = $this->conn->prepare($sql);

        $sth->execute([
            ':id' => $id,
            ':nightAvailability' => $availability
        ]);
    }

    public function ChangeAvailableDays($id, $days)
    {
        $sql = 'UPDATE employee SET Unavailability = :weekDays WHERE id = :id;';
        $sth = $this->conn->prepare($sql);

        $sth->execute([
            ':id' => $id,
            ':weekDays' => $days
        ]);
    }

    public function GetAvailableDays($id) 
    {

        $sql = 'SELECT Unavailability FROM  employee WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
       
        $result = $sth->fetch();
        return $result['Unavailability'];
    }

    public function GetNightshiftAvailability($id) 
    {
        $sql = 'SELECT nightShifts FROM  employee WHERE id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);

        $result = $sth->fetch();
        return $result['nightShifts'];
    }

       

}
