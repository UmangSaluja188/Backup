<?php
echo $_COOKIE["Name"];

setcookie("Age","12",time()+3600);
setcookie("NewAge","RamGopal" time()+3600);
setcookie("NewAge","",time()-3600);

?>