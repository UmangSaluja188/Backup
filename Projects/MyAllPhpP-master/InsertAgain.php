<?php


$hostname='localhost';
$username='root';
$password='';

$dbh=new PDO("mysql:host=$hostname;dbname=teacher",$username,$password);
$sql="Insert into teacherdetails (Id,Name,FatherName,MotherName) Values(4,'Deepak','Deepak Father','Deepak Mother')";
try
{
    if($dbh->query($sql))
    {
        echo "The record is Successfully Insert";
    }
    else
    {
        echo "No Insert";
    }
    $dbh=null;
}

catch(Exception $e)
{
    echo "ERROR".$e->getMessage();
}
?>