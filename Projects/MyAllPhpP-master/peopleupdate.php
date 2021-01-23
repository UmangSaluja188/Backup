<?php
$hostname='localhost';
$username='root';
$password='';


try{
    $dbh=new PDO("mysql:host=$hostname;dbname=people",$username,$password);
    echo 'Connected To DataBase<br/>';

    $sql="Update peopleinfo set Name='Moto' where id =3";
    if(($dbh->query($sql)))
	{
		//echo $row["id"]." - ".$row["class"]."-".$row["name"]."-".$row["age"]."<br/>";
        echo'Record are Successfully Updated';
    }
    else
    {
        echo'No Updated';
    }
    $dbh=null;
}
catch(Exception $e)
{
    echo "ERROR".$e->getMessage();
}

?>