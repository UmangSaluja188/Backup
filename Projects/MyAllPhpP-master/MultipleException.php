<?php
    
    class DivideByZeroException extends Exception
    {
        
    };
    class DivideByNegativeException extends Exception
    {
    };
    
    function newFunc($value)
    {
        if($value==0)
        {
            throw new DivideByZeroException("No Devide By Zero Exception<br>");
        }
        
        else
        {
            throw new DivideByNegativeException("No Devide By Negative");
        }
        
    }
try
{
    newFunc(0);
}
catch(DivideByZeroException $e)
{
    echo $e->getMessage();

}
catch(DivideByNegativeException $e2)
{
    echo $e2->getMessage();
}




?>