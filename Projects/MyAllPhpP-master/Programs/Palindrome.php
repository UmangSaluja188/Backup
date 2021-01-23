<?php

function plaindrome()
{

$no=121;
$no2=$no;
$rem=0;
$rev=0;

while($no>1)
{
    $rem=$no%10;
    $rev=$rev*10+$rem;
    $no=$no/10;
}

if($rev==$no2)
{
    echo $rev."No is Palindrome";

}
else{
    echo $rev."No is not Palindrome";
}
}
plaindrome();

?>
