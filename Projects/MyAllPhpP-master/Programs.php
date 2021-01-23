<html>
<body>
    <?php 
echo'<h1>Prime No</h1><br>';
        $no1=5;
        $flag=0;

        for($i=2;$i<$no1;$i++)
        {
            if($no1%$i==0)
            {
                $flag=1;
                break;
            }
        }
        if($no1==2)
        {
            $flag=1;
        }

        if($flag==0)
        {
            echo 'No is Prime';
        }
        else
        {
            echo 'No is not Prime';
        }



    ?>
<body>
</html>
