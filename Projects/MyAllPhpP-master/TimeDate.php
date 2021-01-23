<?php
date_default_timezone_set("Asia/kolkata");

echo "Today is " . date("Y/m/d") . "<br>";
echo "Today is " . date("Y.m.d") . "<br>";
echo "Today is " . date("Y-m-d") . "<br>";
echo "Today is " . date("l");

echo "Today time is".date("h:i:sa") . "<br>";;

$b=mktime(10,20,30,12,1,2018);

echo "Date is ".date("Y/M/D h:i:sA",$b);

$c=strtotime("10:30pm April 15 2014");

echo "<br>".date("D/M/Y h:i:sA",$c);




$e=strtotime("tomorrow");
echo date("Y-m-d h:i:sa", $e)."<br>";

?>



