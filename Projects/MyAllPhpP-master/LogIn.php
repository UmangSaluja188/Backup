<html>
    <head>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
    <body>
    <nav class="navbar  bg-success">
                        <div class="container-fluid">
                            <a href="#" class="navbar-brand">LPU Addmission</a>
                       
                        <ul class="nav navbar-nav">
                            <li><a href="#" class="active bg-primary" >HOME</a></li>
                            
                            <li  class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" href="#">LINKS<span class="caret"></span>
                                </a>
        
                                <ul class="dropdown-menu">
                                    <li> <a href="#">Annoucement</a></li>
                                    <li> <a href="#">Fee Details</a></li>
                                    <li> <a href="#">Time Details</a></li>
                                </ul>
                                
                            </li>
                            
                            <li >
                                <a href="#">CONTACT</a>
                            </li>
                            
                            <li >
                                <a href="#">ABOUT</a>
                            </li>

                            
                           
                        </ul>

                        <ul style="float:right" class="nav navbar-nav">
                             <li style="float:right" >
                                    <a href="LogIn.html">Log In</a>
                             </li>
                        </ul>
                    </nav>
                </div>
            </div>


<div class="row">

<div class="col-lg-3 col-xs-offset-4 ">
<div class="jumbotron" style="padding:50px"  >
<h2>Log In Form</h2>
<form action="LogIn.php" method="post">
       <table>
           <tr>
               <td>
                   UserId
               </td>
               <td>
                   <input type="number" class="form-control" >
               </td>
           </tr>
           <tr>
               <td>
                   Password
               </td>
               <td>
                   <input type="password" class="form-control" >
               </td>
           </tr>

           <tr>
               <td>
                   <input type="submit"  class="btn btn-success" value="Sign Up" name="submit">
               </td>
               <td>
                    <input type="submit"  class="btn btn-danger" value="Log In" name="submit">
               </td>
           </tr>
       </table>
</form>
    </div>
    </div>
    </div> 
</body>
</html>
<?php

    if(isset($_POST["submit"]))
    {
        echo "<script>alert('hello')</script>";
    }

?>