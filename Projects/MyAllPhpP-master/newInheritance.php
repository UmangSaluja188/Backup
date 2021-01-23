<?php
class ABC
{
    public static $value;
    function __construct($value)
    {
        $this->value=$value;
        echo "Hello ".$value."<br>";
    }
    public function print1()
    {
        echo "<br>Shaa geya guru<br>";
    }
    public function __destructor()
    {
        echo "Destroy1";
    }
} 
class EFG extends ABC
{
    function __construct()
    {
        parent:: __construct("Jai Mata Di");
        echo  $this->value=" A le chak me chal geya";
        echo $this->value;
    }   
}
$a=new ABC("Deepak chal geya mera constructor");
$a->print1();
$b=new EFG();
$b->print1();
abstract class AbstractClass
{
    public abstract  function first();
    public  function notAbstract()
    {
        
        echo "Not Abstract Method";
    }
}

class inheritAbs extends AbstractClass
{
    public function first()
    {
        echo "Mai v  chal geya";
    }
}

$inheobj=new inheritAbs();
$inheobj->first();
//$a->notAbstract();

AbstractClass::notAbstract();
ABC::print1();

interface newInterface
{
    public function interfaceMethod();
   
}
class C implements newInterface
{
    const Kushal="Kaul";

    function interfaceMethod()
    {
        echo"Interface MEthod";
        echo "Challaaaa".self::Kushal;
    }
   
}
$c=new C();
$c->interfaceMethod();

define("meraConst","DeepakBhata");
    echo meraConst;
?> 
