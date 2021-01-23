<?php

class DivideByZero extends Exception
{
        
};

class DivideByNegative extends Exception
{
        
};
function divideByZero1($value)
{
    if($value==0)
    {
        throw new DivideByZero("No is Not Divide By Zero");
    }
    else
    {
        $var=5/$value;
    }
}


function divideByNEg($value)
{
    if($value<0)
    {
        throw new DivideByNegative("No is not divide by Negative No");
    }
    else
    {
        $var=5/$value;
    }
}


try{
    divideByZero1(0);
    divideByZero1(-1);
}
catch( $e)
{
 echo $e1->__toString();  ;
}

?>

