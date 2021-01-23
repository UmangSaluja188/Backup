<?php

$hostName='localhost';
$userName='root';
$password='';


$dbh=new PDO("mysql:host=$hostName;dbname=teacher",$userName,$password);

$sql="Select * From teacherdetails";

try{
    foreach(($dbh->query($sql)) as $row)
    {
        echo $row["Id"]." ".$row["Name"];
    }
    $dbh=null;
}
catch(Exception $e)
{
    echo $e->getMessage();
}
?>