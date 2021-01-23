<?php
   $line = "Vi is the greatest word processor ever created!";
   // perform a case-Insensitive search for the word "Vi"
   
 //First Program 
if (preg_match("[^V]", $line)) 
{
   print "Match found!<br>";
}
else
{
   print "Not Match<br>";
}
//Second Program
if (preg_match("[a-z]", "aez")) 
{
   print "Chal Pea Match found!<br>";
}
else
{
 print " Nahi Challa<br>";
}
//Third Program
if (preg_match("[!$]", $line)) 
{
    print "Match found!<br>";
}
 else
 {
  print "Not Match<br>";
 }
 //Fourth Program
 if (preg_match("[$]", $line)) 
 {
     print "Match found!<br>";
 }
 else
 {
   print "Not Match<br>";
 }
 //Fifth Program
if (preg_match("[$!]", $line)) 
{
    print "Match found!<br>";
}
 else
 {
  print "Not Match<br>";
 }
 //Sixth Program
if (preg_match("[t.e]", $line)) 
{
    print "Match found!<br>";
}
 else
 {
  print "Not Match<br>";
 }
//Seventh Program
if (preg_match("[$!]", $line)) 
{
    print "Match found!<br>";
}
else
{
  print "Not Match<br>";
}
//Eight Programs
if (preg_match("/yahoo\.com/", "gahoo.com")) 
{
    print "Match found!<br>";
}
 else
 {
  print "Not Match<br>";
 }
if (preg_match("[c..[a-z]t]", "caaat")) 
{
    print "Match found!<br>";
}
 else
 {
  print "Not Match<br>";
 }
  if (preg_match("[$!]", $line)) 
  {
     print "Match found!<br>";
  }
  else
  {
    print "Not Match<br>";
  }
?>