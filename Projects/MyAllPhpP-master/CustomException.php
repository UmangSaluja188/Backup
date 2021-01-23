<?php
class customException extends Exception
{
    public function errorMessage()
    {
        echo "Hello".$this->getMessage();
    }
}
try{
    $no=10;
if($no==10)
{
    throw new customException("Exception are generated");
}
}
catch(customException $e )
{
    echo $e->errorMessage();
}
?>