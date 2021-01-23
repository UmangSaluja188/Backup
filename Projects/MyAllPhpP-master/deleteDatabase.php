<?php
$hostname='localhost';
$username='root';
$password='';

$name=$_POST["name"];
try{
    $dbh=new PDO("mysql:host=$hostname;dbname=student",$username,$password);
    echo 'Connected To DataBase<br/>';

    $sql="Delete from studentinfo where name=$name";
    if(($dbh->query($sql)))
	{
		//echo $row["id"]." - ".$row["class"]."-".$row["name"]."-".$row["age"]."<br/>";
        echo'Record are Successfully Deleted';
    }
    else
    {
        echo'No Deleted';
    }

    $dbh=null;
}
catch(Exception $e)
{
    echo "ERROR".$e->getMessage();
}

?>