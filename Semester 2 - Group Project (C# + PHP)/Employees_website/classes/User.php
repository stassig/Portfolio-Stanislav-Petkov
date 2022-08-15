<?php
class User
{
    private $id;
    private $username;
    private $password;
    private $firstName;
    private $lastName;
    private $email;
    private $contractType;
    private $birthDate;
    private $firstWorkingDate;
    private $lastWorkingDate;
    private $hourlyWage;
    private $country;
    private $town;
    private $streetName;
    private $streetNumber;
    private $zipCode;  
    private $photo;
   
    
    public function __construct($id ,$password, $username, $firstName,  $familyName, $streetName, $streetNumber, $zipCode, $town,
    $country, $email, $dateOfBirth, $contractType, $firstDate, $lastDate, $wage, $photo)
    {       
         $this->id = $id;
         $this->password = $password;
         $this->username = $username;
         $this->firstName = $firstName;
         $this->lastName = $familyName; 
         $this->streetName = $streetName;
         $this->streetNumber = $streetNumber;
         $this->zipCode = $zipCode;
         $this->town = $town;
         $this->country = $country;
         $this->email = $email;
         $this->birthDate = $dateOfBirth;
         $this->contractType = $contractType;
         $this->firstWorkingDate = $firstDate;
         $this->lastWorkingDate = $lastDate;
         $this->hourlyWage = $wage;
         $this->photo = $photo;      
    }
  
    public function EditPersonalDetails( $firstName,  $familyName, $streetName, $streetNumber, $zipCode,  $town,
      $country, $email, $photo) : void 
    {
        $this->firstName = $firstName;
        $this->lastName = $familyName;
        $this->streetName = $streetName;
        $this->streetNumber = $streetNumber;
        $this->zipCode = $zipCode;
        $this->town = $town;
        $this->country = $country;
        $this->email = $email;  
        $this->photo = $photo;    
    }

    public function UpdateDetails($firstName,  $familyName, $streetName, $streetNumber, $zipCode,  $town,
    $country, $email, $photo)
    {   
        
        if($photo != "" && $this->photo != ""){
            $filename = '../' . $this->photo;
            if (file_exists($filename)) {
                unlink($filename);
            }   
            $this->photo = $photo;
        } else if($photo != ""){
            $this->photo = $photo;
        } 
        $this->EditPersonalDetails($firstName,  $familyName, $streetName, $streetNumber, $zipCode,  $town,
        $country, $email,$this->photo);

        $db = new UserMediator();
        $db->EditUser($this->id, $email , $streetName, $streetNumber,  $town,
        $country, $zipCode,$firstName,  $familyName, $this->photo);
        
    }

    public function EditLoginCredentials($username, $newPassword) : void
    {
        $this->username = $username;
        $this->password = $newPassword;
    }

    public function __toString(): string
    {
        return "Info";
    }

    public function GetUserData(){
     
    //    return $data[] = [$this->id, $this->username,$this->firstName,$this->familyName,$this->streetName ,$this->streetNumber,
    //    $this->zipCode,$this->town,$this->country,$this->email,$this->dateOfBirth,$this->contractType,$this->firstDate,
    //    $this->lastDate,$this->wage];
    }

    public function getId()
    {
        return $this->id;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function getPassword()
    {
        return $this->password;
    }
 
    public function getFirstName()
    {
        return $this->firstName;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function getContractType()
    {
        return $this->contractType;
    }

    public function getBirthDate()
    {
        return $this->birthDate;
    }

    public function getFirstWorkingDate()
    {
        return $this->firstWorkingDate;
    }

    public function getLastWorkingDate()
    {
        return $this->lastWorkingDate;
    }

    public function getHourlyWage()
    {
        return $this->hourlyWage;
    }

    public function getCountry()
    {
        return $this->country;
    }

    public function getTown()
    {
        return $this->town;
    }

    public function getStreetName()
    {
        return $this->streetName;
    }

    public function getStreetNumber()
    {
        return $this->streetNumber;
    }

    public function getZipCode()
    {
        return $this->zipCode;
    }

    public function getPhoto()
    {
        return $this->photo;
    }
}
?>