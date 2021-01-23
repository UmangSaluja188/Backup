<?php
$hostname="localhost";
$userName="root";
$password="";

try
{
    $dbh=new PDO("mysql:host=$hostname;dbname=student",$userName,$password);
    $sql="Alter Table studentinfo ADD Sallary Varchar(50) "; 

    if(($dbh->query($sql)))
	{
		//echo $row["Id"]." - ".$row["Name"]."-".$row["Class"]."-".$row["Age"]."<br/>";
        echo'Record are Successfully Updated';
    }
    else{
        echo'No Updated';
    }
}

catch(Exceptio $e)
{
    echo 'Error a geya Bai';
}


?>