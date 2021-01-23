<html>
    <body>

<?php

class divide extends Exception
{
};
class Ndivide extends Exception
{
};
    $value=1;
    try
    {
        if($value==0)
        {
            throw new divide("Exception  gati veere");
        }
        if($value==1)
        {
            throw new Ndivide("Exception 2");
        }
    }
    catch (divide $e)
    {
        echo ' '.$e->getMessage();
    }

    catch(Ndivide $e1)
    {
        echo ' '.$e1->getMessage();
    }
?>

</body>
</html>
