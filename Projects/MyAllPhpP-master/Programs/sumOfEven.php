<?php
$arr=array(
    array(1,2,3),
    array(4,5,6),
    array(7,8,9)
);
$sum=0;
for($i=0;$i<3;$i++)
    {
        for($j=0;$j<3;$j++)
        {
            if($arr[$i][$j]%2==0)
            {
                $sum+= $arr[$i][$j];
            }
        }
    }

    echo "Sum of even no ".$sum;

?>