<html>
<head>
</head>
<body>
<form action="InputFromUSer.php" method="post">

Name<input type="text" name="name"/>
Roll No<input type="text" name="roll"/>
<input type="Submit" text="Submit" >
</form>

</body>
<?php

session_start();
$_SESSION["Counter"]=1;
$name=$_POST["name"];
echo "Your Name is".$name;
echo "<br>";

$roll=$_POST["roll"];
echo "Roll No Is=".$roll;
print_r($_SESSION);
session_destroy();



?>




</html>