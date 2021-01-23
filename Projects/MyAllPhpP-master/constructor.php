<?php
class FirstClass
{
    public $address;
    public $contactNo;

    public function showdetails()
    {
        echo "Address is =".$this->address;
        echo "Contact No is=".$this->contactNo;
    }

}

//Inharitance
class Example extends FirstClass
{
    public $name;
    public $class;


   public  function __construct($name1,$class2)
    {
        $this->name=$name1;
        $this->class=$class2;

    }


    function display()
    {
        echo $this->name." ".$this->class;
    }

    

    
//Overridding Define the parents class function in child class with same name and same parameter
    public function showdetails()
    {
        echo "Address is =".$this->address;
        echo "Contact No is=".$this->contactNo;
    }

}

$ex=new Example("Kushal kumar","MCA:");
$ex->display();
$ex->address="1111 Model Town";
$ex->contactNo=9876543210;

$ex->showdetails();
