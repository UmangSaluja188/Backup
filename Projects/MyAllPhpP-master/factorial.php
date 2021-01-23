<html>
<body>
    <?php
    echo'<h1>Factorial</h1><br>';
        $no=5;
        $fac=$no;
        for($i=$no-1;$i>1;$i--)
        {
            $fac*=$i;
        }
        echo'Fatctorial of no '.$no."is ".$fac;


    ?>
</body>
</html>