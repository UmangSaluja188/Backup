<?php

    $arra1=array(
   array(1,2),
   array(3,4)

);

$arra2=array(
    array(1,2),
    array(3,4)
 
 );
 $arra3=array(
    array(0,0),
    array(0,0)
 );
for($i=0;$i<count($arra1[0]);$i++)
{
    for($j=0;$j<count($arra1[0]);$j++)
    {
        $arra3[$i][$j]=$arra1[$i][$j]+$arra2[$i][$j];
        echo $arra3[$i][$j]." ";   
    }
    echo "<br>";

}
$temp=0;
$i=0;
$j=0;
for($i=0;$i<2;$i++)
{
    for($j=0;$j<2;$j++)
    {
        for($k=0;$k<2;$k++)
        {
            $temp+=$arra1[$j][$k]*$arra2[$k][$j];
        }
      $arra3[$i][$j]=$temp;
        
    }
    echo $arra3[$i][$j]." ";  
    echo "<br>";

}
?>