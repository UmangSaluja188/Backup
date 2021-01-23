<?php
class customExp extends Exception
{
    function showMessage()
    {
        $message=$this->getMessage()." chak de phatte";
        echo $message;
        return $message;
    }
}
try
{
        try
        {
            throw new Exception("Deepak Exception A gayi");
        }
        catch(Exception $e)
        {
            $newMes="Hun fhir a gayi exceptio";
            throw new customExp($newMes);
        }
        
}
catch(customExp $e1)
{
    $e1->showMessage();
}

?>