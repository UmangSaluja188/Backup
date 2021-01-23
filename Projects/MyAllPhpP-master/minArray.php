<?php

 $arrayName = array(1,2,3,4,5,6,7,8,9,10 );

 $n=10;
 $i=0;
 $min=$arrayName[0];
 $j=1;
while($j<$n)
{
    if($arrayName[$j]<$min)
    {
        $min=$arrayName[$j];
    }
    $j++;
}
echo "Mininmum Value in the array is ".$min;



?>