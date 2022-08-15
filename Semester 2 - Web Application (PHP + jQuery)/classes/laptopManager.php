<?php

class LaptopManager
{
    private $dbConnenction;

    public function __construct()
    {
        $this->dbConnenction = new LaptopMediator();
    }

    public function Add(Laptop $laptop)
    {
        $this->dbConnenction->AddLaptop($laptop);
    }

    public function Update($id, $manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery, $photo)
    {
        $laptop = $this->dbConnenction->GetLaptop($id);
        $newphoto =  $laptop->getPhoto();
        if($photo != ""){
            $filename = '../' . $laptop->getPhoto();
            if (file_exists($filename)) {
                unlink($filename);
            }   
            $newphoto = $photo;
        }       
        $laptop->EditDetails($manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery, $newphoto);
        $this->dbConnenction->UpdateLaptop($laptop);
    }

    public function Delete($id)
    {
        $laptop = $this->dbConnenction->GetLaptop($id);
        $filename = '../' . $laptop->getPhoto();
        if (file_exists($filename)) {
            unlink($filename);
        }
        $this->dbConnenction->DeleteLaptop($id);
    }

    public function GetLaptop($id) : Laptop
    {   
        return $this->dbConnenction->GetLaptop($id);
    }

    public function GetAll()
    {
        return $this->dbConnenction->GetAllLaptops();
    }
}
