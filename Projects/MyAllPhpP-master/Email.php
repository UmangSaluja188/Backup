<?php

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'C:\xampp\htdocs\vendor\autoload.php';
$mail=new PHPMailer(true);


try
{
$mail->SMTPDebug=1;
$mail->isSMTP();
$mail->Host='smtp.gmail.com';
$mail->SMTPAuth=true;
$mail->Username='phptrial421@gmail.com';
$mail->Password='phptrial';
$mail->SMTPSecure='ssl';
$mail->Port=465;

$mail->smtpConnect(
array("ssl"=>array(
"verify_peer"=>false,
"verify_peer_name"=>false,
"allow_self_signed"=>true)));

$mail->setFrom('phptrial421@gmail.com','preet');
$mail->addAddress('kkaul928@gmail.com','mainunahipata');
//$mail->addAttachment('barimage.bmp','new.bmp');
$mail->addCC('dpkbhatta205@gmail.com');
$mail->addBCC('dpkbhatta205@gmail.com');
$mail->isHTML(true);
$mail->Subject='Here is the subject';
$mail->Body='This is the HTML message body<b>in bold!</b>';
$mail->AltBody='This is the body in plain text for non-HTML mail clients';
$mail->send();
	echo 'Messagehas been sent';
}
catch(Exception $e)
{
	echo 'Message Could not be sent.Mailer Error:',
	$mail->ErrorInfo;
}
?>