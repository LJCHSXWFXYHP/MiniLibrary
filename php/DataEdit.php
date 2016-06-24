<?php
//error_reporting(~E_ALL);
	$myOldPhoneNum=$_POST['OldPhoneNum'];
	$myNewPhoneNum=$_POST['PhoneNum'];
	if($myNewPhoneNum=='') {echo 'null'; exit;}
	if($myOldPhoneNum=='') {echo 'null'; exit;}
	$sql_0="SELECT PhoneNum FROM UserInformation WHERE PhoneNum='".$myNewPhoneNum."'";
	$sql="UPDATE UserInformation SET PhoneNum='".$myNewPhoneNum."' WHERE PhoneNum='".$myOldPhoneNum."'";

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
	  
	  
	//执行SQL语句(更新)   
	$result=mysqli_query($conn,$sql_0);

	$row=mysqli_fetch_assoc($result);
	if($row['PhoneNum'] !='') {
		echo 'Failed';
		exit;
	}
	mysqli_query($conn,$sql) or die('-3'.mysql_error());
	echo 'Success';
	
	mysqli_free_result($result);
	mysql_close();
	//关闭连接

?>