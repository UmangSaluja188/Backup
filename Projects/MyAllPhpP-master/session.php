<?php
session_start();
//$_POST["n1"];
if(isset($_SESSION['Counter']))
{
    $_SESSION['Counter']+=1;
    echo "Total User ".$_SESSION['Counter'];
}
//echo "Total User ".$_SESSION['Counter'];

?>