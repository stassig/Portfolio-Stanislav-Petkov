<?php

class UserManager
{
    private $dbConnenction;

    public function __construct()
    {
        $this->dbConnenction = new UserMediator();
    }

    public function Add(Member $member): int
    {
        return $this->dbConnenction->AddMember($member);
    }

    public function Update($id, $email, $password, $username, $birthDate, $country)
    {
        $member = $this->dbConnenction->GetMember($id);
        $member->editPersonalDetails($email, $password, $username, $birthDate, $country);
        $this->dbConnenction->UpdateMember($member, $id);
    }

    public function GetID($email, $password): int
    {
        return  $this->dbConnenction->GetMemberId($email, $password);
    }

    public function GetUser($id) : Member
    {
        return $this->dbConnenction->GetMember($id);
    }

    public function CheckLoginCredentials($email, $password): int
    {
        return $this->dbConnenction->CheckUserLogin($email, $password);
    }

    public function CheckRegistration($username, $email) : int
    {
        return $this->dbConnenction->CheckRegistration($username, $email);
    }
}
