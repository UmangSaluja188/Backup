<?php
$hostname='localhost';
$username='root';
$password='';


try{
    $dbh=new PDO("mysql:host=$hostname;dbname=student",$username,$password);
    echo 'Connected To DataBase<br/>';

    $sql="insert into studentinfo(id,name,class,age) Values (3,'Umang','MCA',20)";
    if($dbh->query($sql))
    {
        echo 'Record are successfully insert';
    }
    else
    {
        echo 'Data is not successfully insert';
    }

    $dbh=null;
}
catch(Exception $e)
{
    echo "ERROR".$e.getMEssage();
}

?>