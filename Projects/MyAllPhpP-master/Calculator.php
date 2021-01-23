<html>
<body>

   

    <?php 
echo'<h1>Calculator</h1><br>';
$a=10;
$b=5;
$result=0;
$c='+';
echo'Press + for addition<br>';
echo'Press - for addition<br>';
echo'Press * for addition<br>';
echo'Press / for addition<br>';

switch($c)
{
    case '+':
    {
        $result=$a+$b;

        echo'Addition of two no '.$a.' and '.$b.' is '.$result;
        break;
    }

    case'-':
    {
        $result=$a+$b;

        echo'Subtraction of two no '.$a.' and '.$b.' is '.$result;
        break;
        
    }

    case'*':
    {
        $result=$a+$b;

        echo'Multiplication of two no '.$a.' and '.$b.' is '.$result;
        break;
    }

    case'/':
    {
        $result=$a/$b;

        echo'Divide of two no '.$a.' and '.$b.' is '.$result;
        break;
    }
}

?>
</body>
