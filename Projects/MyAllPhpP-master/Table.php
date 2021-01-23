<html>
<body>

$total;
for($i=1;$i<=10;$i++)<br>
{<br>
    for($j=1;$j<=10;$j++)<br>
    {<br>
        echo $i.'*'.$j.'='.$i*$j.'<br>';<br>
    }<br>
<?php
echo'<h1>Table</h1><br>';
$total;

for($i=1;$i<=10;$i++)
{
    
    echo'<h1>'. $i.' Table</h1><br><br>';
    echo'<table border=1>';
    for($j=1;$j<=10;$j++)
    {
          echo'<tr><td>';
        echo $i.'*'.$j.'='.$i*$j.'<br>';
        echo'</tr></td>';
    }
    echo'</table>';
    echo'<br>';
}
?>
</body>
</html>