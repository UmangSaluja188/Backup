<?php
$arr=array(9,8,7,6,5,4,3,2,1,0);
$searchValue=5;
$no=10;
$index=0;
for($i=0;$i<$no;$i++)
{
	if($arr[$i]==$searchValue)
	{
		$index=1;
		break;
	}
}

if($index==1)
{
	echo "Value is find at index ".$i;
}
else
{
	echo "Value is not find ";
}



?>