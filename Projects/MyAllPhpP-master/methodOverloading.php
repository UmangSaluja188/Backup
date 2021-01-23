<?php

class Example
{
    public $name;
    public $class;

    public function display()
    {
        echo $this->name;
    }
    public function  __call($method,$args)
    {
        if($method=="setMessage")
        {
            if(count($args))
            {
                $this->name=$args[0];
            }
        }
    }
}
$ex=new Example();
$ex->setMessage("Kushal","Ajay");
$ex->display();
?>