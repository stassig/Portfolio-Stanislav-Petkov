<?php
class Laptop
{
    private $id;
    private $name;
    private $price;
    private $photo;

    private $manufacturer;
    private $screenSize;
    private $cpu;
    private $gpu;
    private $ram;
    private $hdd;
    private $ssd;
    private $battery;

    public function __construct($id, $name, $price, $photo, $manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery)
    {
        $this->id = $id;
        $this->name = $name;
        $this->price = $price;
        $this->photo = $photo;
        $this->manufacturer = $manufacturer;
        $this->screenSize = $screenSize;
        $this->cpu = $cpu;
        $this->gpu = $gpu;
        $this->ram = $ram;
        $this->hdd = $hdd;
        $this->ssd = $ssd;
        $this->battery = $battery;
    }

    public function EditDetails($manufacturer, $screenSize, $cpu, $gpu, $ram, $hdd, $ssd, $battery, $photo) : void
    {
        $this->manufacturer = $manufacturer;
        $this->screenSize = $screenSize;
        $this->cpu = $cpu;
        $this->gpu = $gpu;
        $this->ram = $ram;
        $this->hdd = $hdd;
        $this->ssd = $ssd;
        $this->battery = $battery;
        $this->photo = $photo;
    }
    
    public function getPrice()
    {
        return $this->price;
    }

    public function getName()
    {
        return $this->name;
    }

    public function getId()
    {
        return $this->id;
    }

    public function getPhoto()
    {
        return $this->photo;
    }

    public function getManufacturer()
    {
        return $this->manufacturer;
    }

    public function getScreenSize()
    {
        return $this->screenSize;
    }

    public function getCpu()
    {
        return $this->cpu;
    }

    public function getGpu()
    {
        return $this->gpu;
    }

    public function getRam()
    {
        return $this->ram;
    }

    public function getHdd()
    {
        return $this->hdd;
    }

    public function getSsd()
    {
        return $this->ssd;
    }

    public function getBattery()
    {
        return $this->battery;
    }

    public function setId($id)
    {
        $this->id = $id;

        return $this;
    }
}
?>