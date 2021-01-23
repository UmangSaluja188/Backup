

<?php
// Insert in  specified array index

    $arra1=array(1,2,3,5,6);
    $arra2=array();
    $index=3;
    $temp=0;
    $value=9;
    $k=0;
    for($i=5;$i>=$index;$i--)
    {
        $arra1[$i]=$arra1[$i-1];
    }
       $arra1[$index]=$value;
for($p=0;$p<6;$p++)
{
    echo $arra1[$p];
}


?>