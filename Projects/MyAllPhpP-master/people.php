<?php
$hostname='localhost';
$username='root';
$password='';


try{
    $dbh=new PDO("mysql:host=$hostname;dbname=people",$username,$password);
    echo 'Connected To DataBase<br/>';

    $sql="Update;
    foreach($dbh->query($sql)as $row)
    {
        echo $row["id"]." - ".$row["name"]."-".$row["class"]."-".$row["age"]."<br/>";
	}

    $dbh=null;
}
catch(Exception $e)
{
    echo "ERROR".$e.getMEssage();
}

?>