<?php
require dirname(__FILE__).'/../autoload/init.php';

class UserMediator extends DatabaseMediator
{

    public function CheckRegistration($username, $email): int
    {
        $sql = 'SELECT username, email FROM users WHERE username=:username OR email=:email LIMIT 1';
        $sth = $this->conn->prepare($sql);

        $sth->execute([
            ':username' => $username,
            ':email' => $email,
        ]);

        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();
            if ($result['username'] === $username) {
                return 1;
            } else {
                return 2;
            }
        }
        return 0;
    }
    
    public function CheckAdminOrMember(int $id): bool
    {
        $sql = 'SELECT * FROM admins WHERE id=:id';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);
        if ($sth->rowCount() == 1) {
            return true;
        } else {
            return false;
        }
    }

    public function CheckUserLogin($email, $password): int
    {
        $sql = 'SELECT id ,email, password FROM users WHERE password=:password AND email=:email';
        $sth = $this->conn->prepare($sql);

        $sth->execute([
            ':password' => $password,
            ':email' => $email,
        ]);

        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();
            $id = (int)$result['id'];

            if ($this->CheckAdminOrMember($id)) {
                return 1;
            } else {
                return 2;
            }
        } else {
            return 0;
        }
    }

    public function AddMember(Member $member): int
    {
        $sql = 'INSERT INTO users(username, password, email) VALUES(:username, :password, :email)';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':username' => $member->getUsername(),
            ':password' => $member->getPassword(),
            ':email' => $member->getEmail(),
        ]);

        $id = (int)$this->conn->lastInsertId();
        $sql = 'INSERT INTO members(member_id, username, password, email, date_of_birth, country)
        VALUES(:member_id,:username, :password, :email, :date_of_birth, :country)';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':member_id' => $id,
            ':username' => $member->getUsername(),
            ':password' => $member->getPassword(),
            ':email' => $member->getEmail(),
            ':date_of_birth' => $member->getDateOfBirth(),
            ':country' => $member->getCountry(),
        ]);
        return $id;
    }

    public function GetMemberId($email, $password): int
    {
        $sql = 'SELECT member_id FROM  members WHERE email = :email AND password = :password ;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':email' => $email,
            ':password' => $password
        ]);
        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();
            return (int)$result['member_id'];
        } else {
            return -1;
        }
    }

    public function GetMember($id) : Member
    {

        $sql = 'SELECT * FROM  members WHERE member_id = :id;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id
        ]);

        if ($sth->rowCount() == 1) {
            $row = $sth->fetch();
            return new Member(
                $row['email'], 
                $row['password'],
                $row['username'],
                $row['date_of_birth'],
                $row['country']               
            );
        } else {
            return null;
        }

    }

    public function UpdateMember(Member $member, int $id) 
    {
        $sql = 'UPDATE members SET username = :username, password = :password, email = :email,
        date_of_birth = :birthDate, country = :country  WHERE member_id = :id';
       $sth = $this->conn->prepare($sql);
       $sth->execute([
           ':id' => $id,
           ':username' => $member->getUsername(),
           ':password' => $member->getPassword(),            
           ':email' => $member->getEmail(),
           ':birthDate' => $member->getDateOfBirth(),
           ':country' => $member->getCountry()         
       ]);

       $sql = 'UPDATE users SET username = :username, password = :password, email = :email WHERE id = :id';
       $sth = $this->conn->prepare($sql);
       $sth->execute([
           ':id' => $id,
           ':username' => $member->getUsername(),
           ':password' => $member->getPassword(),            
           ':email' => $member->getEmail(),     
       ]);

    }

}
