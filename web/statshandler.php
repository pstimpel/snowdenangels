<?php
require 'includes/init.php';


if (isset($_POST['data']) && strlen($_POST['data']) > 0) {
    
    if(insertStats($_POST["data"])==true) {
        
        header('HTTP/1.1 200 OK', true, 200);
        
    } else {
        
        header('HTTP/1.1 500 Internal Server Error', true, 500);
        
    }
    
    
} else {
    
    header('HTTP/1.1 500 Internal Server Error', true, 500);
    
}

