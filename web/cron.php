<?php
/**
 * this is the cron job for nightly stats calculation
 */
$nosmarty=true;
include('includes/init.php');


cron();
echo "\nEnd of job";
