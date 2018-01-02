<?php
ini_set("session.bug_compat_42","off");
header('Content-Type:text/html; charset=UTF-8');
error_reporting(E_ERROR | E_WARNING);
date_default_timezone_set('UTC');
session_start();

if (php_sapi_name() != 'cli') {
    if ($_SERVER["HTTP_HOST"] != "127.0.0.1") {

        if ($_SERVER['SERVER_PORT'] != "443") {
            $redirect = 'https://' . $_SERVER['HTTP_HOST'] . $_SERVER['REQUEST_URI'];
            header('HTTP/1.1 301 Moved Permanently');
            header('Location: ' . $redirect);
            exit();
        }

    }
}
if($nosmarty != true) {
    require('smarty/Smarty.class.php');

    $smarty = new Smarty();

    $smarty->template_dir = 'smarty/templates';
    $smarty->compile_dir = 'smarty/templates_c';
    $smarty->cache_dir = 'smarty/cache';
    $smarty->config_dir = 'smarty/configs';

    $smarty->assign("cachets", strtotime(date("Y-m-d H:i:s")));
}


//init DB
include('./includes/db.php');


//load function
include('./includes/functions.php');
