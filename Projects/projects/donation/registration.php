<html>
<head>
    <style>
        body{
            background-color:antiquewhite;
        }
    table{
        margin-top:100px;
        
    }
    </style>
<body>
<?php>
    session_start();
    $_SESSION["uname"] = $_POST['username'];
    
?>
    

<form  method="post">
<table  border="3"align="center">
<tr>
    <th colspan="2" align="center"> Login page </th>
    </tr>
    <tr>
    <td>Username</td>
<td><input type="text" name="username"></td>
</tr>
<tr>
    <td>password</td>
    <td><input type="password" name="password"></td>
</tr>
<tr>
    <td colspan="2" align="center"><input type="submit" name="login"></td>
</tr>
</table>
</body>
</head>
</html>
