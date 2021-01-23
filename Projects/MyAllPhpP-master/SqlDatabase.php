<?php 
$server="localhost";
$username="root";
$pass="";
$db="MyData";

$con=mysqli_connect($server,$username,$pass,$db);

$roll=17;
$name="ajankya2";
$lname="knight2";


$sql="INSERT INTO data1 (roll_no) VALUES ($roll_no)";
if($con->query($sql)==TRUE)
{
    echo "NEW record created successfully";
}
else
{
    echo "ERROR: ".$sql."<br>".$con->error;
}


if($result=mysqli_query($con,$sql));
{
    while($row=mysqli_fatch_row($result))
    {
        echo $row[0];
    }
}
