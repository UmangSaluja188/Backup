<?php

    setcookie("Name","Kushal",time()+3600);
 // setcookie("Name","",time()-3600);
    setcookie("Age","20",time()+3600);
    setcookie("Gurpreet","Kaul",time()+3600);
    if(isset($_COOKIE["Age"])|| isset($_COOKIE["Gurpreet"]))
    {
        echo $_COOKIE["Age"];
        setcookie("Age","20",time()-3600);
    }
    else
    {
        echo "Cookie is not set";
    }
    if(isset($_COOKIE["Age"]))
    {
        echo "Cookie is Set";
    }
    else{
        echo "Cookie is not set";
    }
?>