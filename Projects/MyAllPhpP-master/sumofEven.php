<?php

$a=array(1,3,4);
$sum=0;
$len=count($a);
for($i=0;$i<$len;$i++)
{
    if(($i+1)%2==0 )
    {
         $sum=$sum+$a[$i];
    }
    
}
echo $sum;
?>