<?php


$arrayName = array(1,2,3,4,5,6,7,8,9,10 );

$n=10;
$index=5;

$i=$index;
$value=12;
echo 'Before Deleting Value in  Array<br>';
for($j=0;$j<$n;$j++)
{
   echo $arrayName[$j]."<br>";
}

while($i<$n)
{
    $arrayName[$i]=$arrayName[$i+1];
    $i++;
}
for($j=0;$j<$n;$j++)
{
   echo $arrayName[$j]."<br>";
}

?>