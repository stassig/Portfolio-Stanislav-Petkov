<?php

if(!isset($_SESSION)){
	session_start();
}

spl_autoload_register(function ($className) { 
    
	$path = sprintf(dirname(__FILE__). '/../classes/'.$className.'.php'); 
	if (file_exists($path)) { 
		include $path; 
	} 

	$path = sprintf(dirname(__FILE__). '/../dataAccess/'.$className.'.php');
	if (file_exists($path)) { 
		include $path; 
	} 
}); 

?>
