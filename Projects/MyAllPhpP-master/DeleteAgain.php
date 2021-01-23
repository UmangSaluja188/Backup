<?php
$hostName='localhost';
$userName='root';
$password="";

$dbh=new PDO("mysql:host=$hostName;dbname=teacher",$userName,$password);

$sql ="Delete From teacherdetails where Idr=2";
try{
  if($dbh->query($sql))
    {
        echo"Delete Successfully";
    }
    else
    {
        echo"Not Successfully";
    }
}


catch(Exception $e)
{
    echo $e->getMessage();
}
?>


