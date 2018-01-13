<?php
$nosmarty=false;
include('includes/init.php');

$display="main";

$page="";
if(isset($_GET['page'])) {
    $page=$_GET['page'];
}

$action="";
if(isset($_GET['action'])) {
    $action=$_GET['action'];
}

$userkey="";
if(isset($_GET['key'])) {
    if(strlen($_GET['key'])==64) {
        $userkey=$_GET['key'];
        if(checkKey($userkey)==true) {
            $_SESSION["userkey"]=$userkey;
        }
    } else {
        $_SESSION["userkey"]='';
    }
}
if(isset($_SESSION["userkey"]) && strlen($_SESSION["userkey"])==64) {
    $smarty->assign("userkey",$_SESSION["userkey"]);
    $smarty->assign("share_userkey",urlencode("?key=".$_SESSION["userkey"]));
}  else {
    $smarty->assign("userkey","");
    $smarty->assign("share_userkey","");
}

switch($action) {
    case "xmloverall":
        generateXML();
        break;
    case "xmlpersonal":
        generateXML(true, $_SESSION["userkey"]);
        break;
    case "cron":
        cron();
        break;
    default:

}


switch($_GET['page']) {
    
    case "about":
        $display="about";
        break;
    case "faq":
        $display="faq";
        break;
    case "legal":
        $display="legal";
        break;
    case "stats":
        $display="stats";
        displayMain();
        break;
    default:
        $display="about";

}
$smarty->assign("display",$display);

$smarty->display('index.tpl');

