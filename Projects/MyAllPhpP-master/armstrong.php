<html>
<body>
<?php
    $no=371;
    $digit;
    $total=0;
    $no2=$no;
    while($no>0)
    {
        $digit=$no%10;
        $no=$no/10;
        $total+=$digit*$digit*$digit;
    }
    if($total==$no2)
    {
        echo $total.' No is Armstrong';
    }
    else{
        echo $total.'No is not Armstrong';
    }
?>
</body>
</html>