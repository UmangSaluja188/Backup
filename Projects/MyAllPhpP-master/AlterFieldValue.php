<?php

$hostName='localhost';
$username='root';
$password='';

$dbh=new PDO("mysql:host=$hostName;dbname=student",$username,$password);

$sql="insert into student (id,name,class) ";
try{
if($dbh->query($sql))
{
    echo 'Record are successfully insert';
}
else
{
    echo 'Record are not insert';    
}
$dbh=null;
}
catch(Exception $e)
{
    echo $e->getMessage();
}
?>