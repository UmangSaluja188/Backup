<?php

$hostname="root";
$password="";

$con=MySqi_Connect("localhost","root","","example");
$sql="insert into studentinfo(id,name) Values (3,'Umang')";
$rust=MySqi_query($con,$sql);
if(rust==True)
{
    echo "Data is Insert";
}
else
{
    echo "Data is Not Insert";
}

?>