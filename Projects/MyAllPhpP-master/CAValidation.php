<?php

$str="Hello";

if(preg_match_all('/^h/',"how"))
{

    echo "Hello"."<br>";

}
else
{
    echo "Nahi Chaleya";
}

if(preg_match('/h.w/','how'))
{

    echo "hello2"."<br>";

}
else
{
    echo "Nahi Chaleya2"."<br>";
}

if(preg_match('/\$5\.00/','$5.000'))
{

    echo "hello3"."<br>";

}
else
{
    echo "Nahi Chaleya3"."<br>";
}
//Character Classes
if(preg_match('/c[aeiou]t/','ckt'))
{

    echo "hello4"."<br>";

}
else
{
    echo "Nahi Chaleya4"."<br>";
}

//AlterNatives
if(preg_match('/ab[aeiou]t/','hello how are you abet'))
{

    echo "hello2"."<br>";

}
else
{
    echo "Nahi Chaleya2"."<br>";
}


if(preg_match('/dog|cat/','hello how are you abet '))
{

    echo "hello5"."<br>";

}
else
{
    echo "Nahi Chaleya2"."<br>";
}

$myarray="my string";
$arr=preg_split("//",$myarray);
print_r($arr);


if(preg_match('//','hello how are you abet '))
{

    echo "hello5"."<br>";

}
else
{
    echo "Nahi Chaleya2"."<br>";
}


if(preg_match('/h{2,}/','hhhhhello how are you abet '))
{

    echo "hello59"."<br>";

}
else
{
    echo "Nahi Chaleya2"."<br>";
}

if(preg_match('/^.aa{2}/','haahhhhello how are you abetaa '))
{

    echo "hello44"."<br>";

}
else
{
    echo "Nahi Chaleya55"."<br>";
}

?>
