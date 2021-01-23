<?php
class Toys{
private $str;
public function __set($name,$value){
$this->str[$name] = $value;
}
public function __get($name){
echo "Overloaded Property name = " . $this->str[$name] . "<br/>";
}
public function __isset($name){
if(isset($this->str[$name])){
echo "Property \$$name is set.<br/>";		
} else {
echo "Property \$$name is not set.<br/>";
}
}
public function __unset($name){
unset($this->str[$name]);
echo "\$$name is unset <br/>";
}
}
$objToys = new Toys;
/* setters and getters on dynamic properties */
$objToys->overloaded_property = 123;
$objToys->overloaded_property = 456;
echo $objToys->overloaded_property . "\n\n";
isset($objToys->overloaded_property);
unset($objToys->overloaded_property);
isset($objToys->overloaded_property);
?>