<?php

$myKeyWord=$_POST['KeyWord'];
$myType=$_POST['type'];
$sql="select BookClassId,BookName,BookAuthor,ImageUrl from BookClass where BookClassification = '".$myType."' and BookName LIKE '%".$myKeyWord."%'";

$db_host   = 'localhost';  //数据库主机名称，一般都为localhost   
$db_user   = 'root';        //数据库用户帐号，根据个人情况而定   
$db_passw = 'LJCljc123';   //数据库用户密码，根据个人情况而定   
$db_name  = 'MiniLibrary'; //数据库具体名称，以刚才创建的数据库为准  
  
  
//连接数据库   
$conn = mysqli_connect($db_host,$db_user,$db_passw) or die ('-1'.mysql_error());   
  
  
//设置字符集，如utf8和gbk等，根据数据库的字符集而定   
mysqli_query($conn,"set names 'utf8'");   
  
  
//选定数据库   
mysqli_select_db($conn,$db_name) or die('-2'.mysql_error());   
  
  
//执行SQL语句(查询)   
$result = mysqli_query($conn,$sql) or die('-3'.mysql_error());   



//提示操作成功信息，注意：$result存在于conn.php文件中，被调用出来 
if($result) 
{ 
	$res=array();

    while($row=mysqli_fetch_assoc($result)){

            
            $res[]=$row;
            

    }
    echo json_encode($res);
} 


mysqli_free_result($result);
//释放结果
mysql_close();
//关闭连接

?>