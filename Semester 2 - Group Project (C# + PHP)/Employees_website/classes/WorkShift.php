<?php 

class WorkShift 
{
    private $id;
    private $type;
    private $date;

    public function __construct($id, $type, $date){
        $this->id = $id;
        $this->type = $type;
        $this->date = $date;
    }
    
    public function getId()
    {
        return $this->id;
    }
    
    public function getType()
    {
        return $this->type;
    }

    public function getDate()
    {
        return $this->date;
    }
}
?>