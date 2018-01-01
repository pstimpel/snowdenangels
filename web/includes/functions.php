<?php
/**
 * Copyright (c) 2018. Peters Webcorner, All rights reserved if not mentioned different!
 */


function insertError($postdata) {
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