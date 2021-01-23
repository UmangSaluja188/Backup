<?php
 class ABC
{
    const myConstruct='Value';
    public function __construct()
    {
        
        echo "Hello i am parent constructor";
    }
    public 
}
 class EFG extends ABC
{
    public function __construct()
    {
        
        parent::__construct();
        echo ABC::myConstruct;
        echo " Hello i am child constructor ";
    }
    
}
$e=new EFG();

?>