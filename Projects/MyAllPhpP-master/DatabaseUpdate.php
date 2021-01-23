<?php
$hostname='localhost';
$username='root';
$password='';


try{
    $dbh=new PDO("mysql:host=$hostname;dbname=student",$username,$password);
    echo 'Connected To DataBase<br/>';

    $sql="insert into logintable (userId,password) values(12345,'kushal')";
    foreach(($dbh->query($sql))as $row)
	{
		//echo $row["Id"]." - ".$row["Name"]."-".$row["Class"]."-".$row["Age"]."<br/>";
        echo'Record are Successfully Updated';
    }
    
    $dbh=null;
}
catch(Exception $e)
{
    echo "ERROR".$e.getMEssage();
}

?>