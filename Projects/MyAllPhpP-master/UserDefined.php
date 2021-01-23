<?php
    
    class UserDefined extends Exception
    {
        
    };
    
    function user()
    {
            throw new UserDefined("This is user Defined Exception");
        
        
       
    }
try
{
    user();
    
}
catch(Exception $e)
{
    echo $e->getMessage();

}




?>