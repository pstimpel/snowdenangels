<?php

ini_set("session.bug_compat_42","off");
header('Content-Type:text/html; charset=UTF-8');
error_reporting(E_ERROR | E_WARNING | E_PARSE);
date_default_timezone_set('UTC');

//init DB
require 'db.php';

//load function
require 'functions.php';
