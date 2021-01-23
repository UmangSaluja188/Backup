<?php
date_default_timezone_set("Asia/kolkata");

$Today1=date("D");
$d=mktime(11, 14, 54, 8, 11, 2014);
$Today=date("D");
echo "Today is ".$Today."<br>";

switch($Today)
{
    case "Mon":
    {
        echo "Weak Day";
        break;
    }
    case "Tue":
    {
        echo "Weak Day";
        break;
    }
    case "Wed":
    {
        echo "Weak Day";
        break;
    }
    case "Thu":
    {
        echo "Weak Day";
        break;
    }
    case "Fri":
    {
        echo "Weak Day";
        break;
    }
    default:
    {
        echo "No Weak day";
    }
}?>



