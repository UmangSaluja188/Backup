<?php
    
    function swap($a,$b)
    {
        $a=$a+$b;
        $b=$a-$b;
        $a=$a-$b;
        echo "After Swaping The No Is=".$a
    }
?>