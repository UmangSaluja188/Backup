<?php

 $arrayName = array(1,2,3,4,5,6,7,8,9,10 );

 $n=10;
 $index=5;
 $i=$n;
 $value=12;
 echo 'Before Inserting Value in  Array<br>';
for($j=0;$j<$n;$j++)
{
    echo $arrayName[$j]."<br>";
}

 while($i>$index)
 {
     $arrayName[$i]=$arrayName[$i-1];
     $i--;
 }
 if($i==$index)
 {
     $arrayName[$index]=$value;
 }


 echo 'After Inserting Value in  Array<br>';
for($j=0;$j<=$n;$j++)
{
    echo $arrayName[$j]."<br>";
}

?>