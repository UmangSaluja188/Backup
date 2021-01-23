<?php include 'examp]le.php' ?>
<html>
<head>
<link href="C:\xampp\htdocs\php\stylesheet.css" rel="stylesheet" type="text/css">
<style>
.abc
{
    background-color:blue;
}
</style>


</head>
<body class="abc">
<h1 class ="header">
Hello Newjjj</h1>
<?php

echo "hii<br></br>";
echo "how are uhh";
$a=10;
$b=20;
$c=$a+$b;
echo "the value of c  "+ $c;
$a=5;
if($a==5)
{
    echo'<h1>Hello<h1>';
}
for($i=0;$i<=5;$i++)
{
    echo'<h1>Hello<h1>';
}
$j=0;
while($j<3)
{
    echo'<h1>While<h1>';
    $j++;
}

$arr=array("1","2","3","4","5");
echo $arr[0];
$n=0;
for($p=0;$p<5;$p++)
    echo $arr[$p];

?>
</body>

</html>