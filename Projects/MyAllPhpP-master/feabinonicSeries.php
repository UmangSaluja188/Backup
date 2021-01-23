<html>
<body>
    <?php
    echo'<h1>Febinonic Series</h1><br>';
        $no=10;
        $a=0;
        $b=1;
        $c=0;

        echo $a.' '.$b;
        for($i=0;$i<$no-2;$i++)
        {
            $c=$a+$b;
            $a=$b;
            $b=$c;
            echo ' '.$c;
        }

    ?>
</body>
</html>