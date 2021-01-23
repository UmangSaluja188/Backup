<?php

// Array function
    $arr3=array(5,3,2,1,4);
   
    echo '<h1>Before any operation in array</h1><br>';
    print_r($arr3);

    echo '<h1> Array Push</h1><br>';
    array_push($arr3,6);
    print_r($arr3);

    echo '<h1> Array Pop</h1><br>';
    array_pop($arr3);
    print_r($arr3);

    echo '<h1> Array RSort</h1><br>';
    Rsort($arr3);
    print_r($arr3);

   
    echo '<h1> array_Sum</h1><br>';
    $sum=array_sum($arr3);
    echo $sum;

    echo '<h1> Array Search</h1><br>';
    echo array_search("1",$arr3);
  
    array_pop($arr);
    print_r($arr);
    
    ?>