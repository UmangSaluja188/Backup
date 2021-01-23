<?php
    function Hello()
    {
        $arra1=array(1,2,3,4,5);
        $arra2=array(5,6,7,8,9,10);
        $arra3=array_merge($arra1,$arra2);
        print_r($arra3);
      
        array_shift($arra1);
        print_r($arra1);  echo 'Shift<br>';
        
        print_r($arra3);
        echo 'Unshift<br>';
        array_unshift($arra1,21);
         
        print_r($arra1);

        echo 'Replace<br>';
        //replace
        array_replace($arra2,$arra1);
         
        print_r($arra2);


        $arra3=array_flip($arra1);
        print_r($arra3);

        //array_splice
        array_splice($arra3,3,2);
        print_r($arra3);

        //array_splice
        array_splice($a,2,0,$b);

    }
    Hello();
?>