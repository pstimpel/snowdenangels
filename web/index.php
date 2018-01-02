<?php
$nosmarty=false;
include('includes/init.php');

$display="main";

if(isset($_GET['page'])) {
    $page=$_GET['page'];
} else {
    $page="";
}

if(isset($_GET['action'])) {
    $action=$_GET['action'];
} else {
    $action="";
}

switch($action) {

    case "cron":
        cron();
        break;
    default:

}


switch($_GET['page']) {

    case "me":
        $display="me";
        break;
    default:
        $display="main";
        displayMain();

}
$smarty->assign("display",$display);

$smarty->display('index.tpl');

