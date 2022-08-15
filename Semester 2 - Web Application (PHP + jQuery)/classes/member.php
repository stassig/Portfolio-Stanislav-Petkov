<?php
require dirname(__FILE__).'/../autoload/init.php';

class Member extends User
{
    private $dateOfBirth;
    private $country;

    public function __construct(string $email, string $password, string $username, string $dateOfBirth, string $country) 
    {
        parent::__construct($email,$password,$username);
        $this->dateOfBirth = $dateOfBirth;
        $this->country = $country;
    }
    
    public function getDateOfBirth()
    {
        return $this->dateOfBirth;
    }

    public function getCountry()
    {
        return $this->country;
    }
    
    public function editPersonalDetails( string $email, string $password, string $username, string $dateOfBirth, string $country)
    {
        $this-> email = $email;
        $this->password = $password;
        $this->username = $username;
        $this->country = $country;
        $this->dateOfBirth = $dateOfBirth;       
    }

  

}
?>