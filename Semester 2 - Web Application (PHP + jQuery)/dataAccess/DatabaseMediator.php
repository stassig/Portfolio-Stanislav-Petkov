<?php

abstract class DatabaseMediator {

    private $username = 'dbi460703';
    private $password = 'wadproject123';
    private $host = 'studmysql01.fhict.local';
    private $dbName = 'dbi460703';
    protected $conn;

    public function __construct() {
        $this->conn = new PDO("mysql:host=$this->host;dbname=$this->dbName", $this->username, $this->password);
        $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }
}

?>