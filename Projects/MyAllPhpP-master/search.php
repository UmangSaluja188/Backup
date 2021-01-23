<?php 
     $arr1=array(1,2,3,4,5);
     $value=5;
     $flag=0;
     for($i=0;$i<5;$i++)
     {
         if($value==$arr1[$i])
         {
             
             $flag=1;
             break;
         }
     }

     if($flag==0)
     {
        
            echo 'Element is found';        
     }
     else
     {
        echo 'Element  found'; 
     }



     $upper=5;
     $lower=0;
     $mid=0;
     while($lower<=$upper)
     {
        $mid=($upper+$lower)/2;

        if($arr1[$mid]==$value)
        {
            echo 'Binary Element found';
            $flag=1;
            break;
        }
        else if($value>$arr1[$mid])
        {
            $lower=$mid+1;
        }
        else 
        {
            $upper=$mid-1 ;   
        }
       
     }
     if($flag==1)
        {
            echo 'Element is found';
        }
        else{
            echo 'Element is not found';
        }

        
?>
