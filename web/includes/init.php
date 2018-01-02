<?php
ini_set("session.bug_compat_42","off");
header('Content-Type:text/html; charset=UTF-8');
error_reporting(E_ERROR | E_WARNING);
date_default_timezone_set('UTC');
session_start();

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
