<?php
//Sum of digit

$no=121;

sumOfDigit($no);
function sumOFDigit($no )
{
    $sum=0;
 while($no>1)
{
    $rem=$no%10;
    $sum+=$rem;
    $no=$no/10;
}
echo "Sum of digit is ".$sum;
}

