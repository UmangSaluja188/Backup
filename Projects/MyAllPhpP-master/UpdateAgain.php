<?php
$hostName='localhost';
$userName='root';
$password='';

$dbh=new PDO("mysql:host=$hostName;dbname=teacher",$userName,$password);
$sql="Update teacherdetails set Name='Kaul Saab' where id=1";

try
{
if($dbh->query($sql))
{
    echo 'Record Is Successfully Inserted';
}
else{
    echo "Record Is Not Inserted";
}
$dbh=null;
}

catch(Exception $e)
{
    echo $e->getMessage();
}
?> 