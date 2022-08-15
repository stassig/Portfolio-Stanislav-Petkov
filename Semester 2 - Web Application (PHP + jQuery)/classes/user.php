<?php
abstract class User
{
    protected $username;
    protected $password;
    protected $email;

    public function __construct(string $email, string $password, string $username)
    {
        $this->email = $email;
        $this->password = $password;
        $this->username = $username;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function getPassword()
    {
        return $this->password;
    }
    
    public function __toString(): string
    {
        return "Info";
    }
}
