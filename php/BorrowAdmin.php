<?php
//error_reporting(~E_ALL);
	$myPhoneNum=$_POST['PhoneNum'];
	$myBookId=$_POST['BookId'];
	if($myPhoneNum=='') {echo 'null'; exit;}
	if($myBookId=='') {echo 'null'; exit;}
	$sql="INSERT INTO BorrowRecode(BookId, BorrowDate, ReturnFlag, PhoneNum, IfRenew) VALUES ('".$myBookId."',(SELECT now()),0,'".$myPhoneNum."',0)";

	$db_host   = 'localhost';  //数据库主机名称，一般都为localhost   
	$db_user   = 'root';        //数据库用户帐号，根据个人情况而定   
	$db_passw = 'LJCljc123';   //数据库用户密码，根据个人情况而定   
	$db_name  = 'MiniLibrary';         //数据库具体名称，以刚才创建的数据库为准  
		  
		  
	//连接数据库   
	$conn = mysqli_connect($db_host,$db_user,$db_passw) or die ('-1'.mysql_error());   
	  
	  
	//设置字符集，如utf8和gbk等，根据数据库的字符集而定   
	mysqli_query($conn,"set names 'utf8'");   
	  
	  
	//选定数据库   
	mysqli_select_db($conn,$db_name) or die('-2'.mysql_error());   

	mysqli_query($conn,$sql) or die('-3'.mysql_error());
	echo 'Success';
	
	mysqli_free_result($result);
	mysql_close();
	//关闭连接

?>