<?php
/**
 * Copyright (c) 2018. Peters Webcorner, All rights reserved if not mentioned different!
 */

function insertStats($postdata) {
    global $db;
/*
        content = content & " [ "
        content = content & " { "

        content = content & """userkey"": """ & c_statscollection.s_userkey & """"
        content = content & ", "
        content = content & """computerkey"": """ & c_statscollection.s_computerkey & """"
        content = content & ", "
        content = content & """sessionstart"": """ & Math.Round((c_statscollection.d_sessionstart.ToUniversalTime - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0).ToString & """"
        content = content & ", "
        content = content & """sessionend"": """ & Math.Round((c_statscollection.d_lastupdate.ToUniversalTime - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0).ToString & """"
        content = content & ", "
        content = content & """hashes"": " & c_statscollection.i_hashessummary.ToString
        content = content & " } "
        content = content & " ] "

 'stats_persession_userkey
        'stats_persession_sessionstart
        'stats_persession_sessionend
        'stats_persession_hashes
        'stats_persession_computerkey
*/
    $json = json_decode($postdata, true);
    
    foreach($json as $item) {
        $stats_persession_sessionstart_l = $item['sessionstart'];
        $stats_persession_sessionend_l = $item['sessionend'];
        $stats_persession_sessionstart=date("Y-m-d H:i:s", $stats_persession_sessionstart_l);
        $stats_persession_sessionend=date("Y-m-d H:i:s", $stats_persession_sessionend_l);
    
        $stats_persession_userkey = $item['userkey'];
        $stats_persession_computerkey = $item['computerkey'];
        $stats_persession_hashes = $item['hashes'];
        
        $stats_sessionwasstarted = $item['sessionwasstarted'];

        if($stats_sessionwasstarted == true) {
            #insert
            //echo "insert";
            $result = pg_prepare($db, "query",
                'insert into stats_persession (stats_persession_userkey, stats_persession_computerkey,
                  stats_persession_sessionstart, stats_persession_sessionend,
                  stats_persession_hashes) values($1,$2,$3,$4,$5)');
    
            $result = pg_execute($db, "query", array($stats_persession_userkey, $stats_persession_computerkey,
                $stats_persession_sessionstart,$stats_persession_sessionend, $stats_persession_hashes));
            
        } else {
            #update
            //echo "update";
    
            $result = pg_prepare($db, "query",
                "update stats_persession set stats_persession_sessionend=$1,stats_persession_hashes=$2
                  where stats_persession_userkey=$3 and stats_persession_computerkey=$4
                  and stats_persession_sessionstart = $5");
    
            $result = pg_execute($db, "query", array($stats_persession_sessionend, $stats_persession_hashes,
                $stats_persession_userkey, $stats_persession_computerkey, $stats_persession_sessionstart));
        }
        
        
        return true;
    }
    
    return false;
}

function insertError($postdata) {
    return;
    global $db;
    
    $json = json_decode($postdata, true);
    
    foreach($json as $item) {
        
        $date=date("Y-m-d H:i:s", $item['date']);
        $message = $item['error'];
        $stacktrace = $item['stacktrace'];
        $version=$item['version'];
        
        $result = pg_prepare($db, "query",
            'insert into errors (errors_ts_created, errors_ts_inserted, errors_sourceip, errors_programversion,
                  errors_message, errors_stacktrace) values($1,now(),$2,$3,$4,$5)');
        
        $result = pg_execute($db, "query", array($date, $_SERVER['REMOTE_ADDR'],$version,$message, $stacktrace));
        
        return true;
    }
    
    return false;
}

function getErrorsFromDatabase() {
    global $db;
    $sql = "select * from errors";
    $result3 = pg_query($db,$sql);
    $num3 = pg_numrows($result3);
    $point=array();
    if($num3>0) {
        for ($i3 = 0; $i3 < $num3; $i3++)
        {
            $r = pg_fetch_array($result3);
            echo "found\n";
        }
    } else {
        echo "no rows";
    }
    
}