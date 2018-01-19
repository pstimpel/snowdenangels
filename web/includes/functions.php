<?php

function insertStats($postdata) {
    global $db;

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

function to_xml(SimpleXMLElement $object, array $data)
{
    foreach ($data as $key => $value) {
        if (is_array($value)) {
            $new_object = $object->addChild($key);
            to_xml($new_object, $value);
        } else {
            // if the key is an integer, it needs text with it to actually work.
            if ($key == (int) $key) {
                $key = "key_$key";
            }

            $object->addChild($key, $value);
        }
    }
}

function generateXML($personal=false, $mykey='') {

    $summary = new StatsCollector();
    
    if($personal==false) {
    
        $summary->userkey=$mykey;
        $data=$summary->getSummary();
        $data['key']='none';

    } else {
        if(strlen($mykey)==64) {
    
            $summary->userkey=$mykey;
            $data=$summary->getSummary();

        } else {

            $data=array();
        }

    }

    $xml = new SimpleXMLElement('<data/>');
    to_xml($xml, $data);

    print $xml->asXML();
    exit;
}

function calc1000UsersSummary($summary) {
    
    $factorTotal=1000/$summary['uniqueUsersTotal'];
    $factorLast=1000/$summary['uniqueUsersLast'];
    
    $returnvalue=array(
        "key"=>"",
        "daysToXMRTotal"=>sprintf('%.1f',round($summary['daysToXMRTotal'] / $factorTotal,1)),
        "daysToXMRLast"=>sprintf('%.1f',round($summary['daysToXMRLast'] / $factorLast,1)),
        "hashRatePerSecondSummaryTotal"=>round($summary['hashRatePerSecondSummaryTotal'] * $factorTotal,0),
        "hashRatePerSecondSummaryLast"=>round($summary['hashRatePerSecondSummaryLast'] * $factorLast,0),
        "hashRateSummaryTotal"=>round($summary['hashRateSummaryTotal'] * $factorTotal, 9),
        "hashRateSummaryLast"=>round($summary['hashRateSummaryLast'] * $factorLast, 0),
        "uniqueComputersTotal"=>0,
        "uniqueComputersLast"=>0,
        "uniqueUsersTotal"=>0,
        "uniqueUsersLast"=>0,
        "sumXMRTotal"=>sprintf('%.8f', round( $factorTotal * $summary['sumXMRTotal'],8)),
        "sumXMRLast"=>sprintf('%.8f', round($factorLast * $summary['sumXMRLast'],8)),
        "sumUSDTotal"=>sprintf('%.2f', round($factorTotal * $summary['sumUSDTotal'],2)),
        "sumUSDLast"=>sprintf('%.2f', round($factorLast * $summary['sumUSDLast'],2))
    );
    return $returnvalue;
}

function displayMain() {
    global $smarty;

    $summary = new StatsCollector();
    $summary->userkey='';
    $globalSummary=$summary->getSummary();

    $smarty->assign("summaries",$globalSummary);
    
    $estimated100Users = calc1000UsersSummary($globalSummary);
    $smarty->assign("summaries1000users",$estimated100Users);
    

    $smarty->assign("chartdataFull",prepareChart(false));
    $smarty->assign("chartdata30d",prepareChart(true));

    if(strlen($_SESSION["userkey"])==64) {
        $personalsummary = new StatsCollector();
        $personalsummary->userkey=$_SESSION["userkey"];
        $smarty->assign("personal", $personalsummary->getSummary());
    } else {

        $smarty->assign("personal", array());
    }

    $smarty->assign("tops", StatsCollector::getTops());
    
    $smarty->assign("market", StatsCollector::getMarketData());
    
    
}

function checkKey($mykey) {
    global $db;
    if(strlen($mykey)==64) {
        $result = pg_prepare($db, "query",
            "select count(*) as counter from stats_persession where stats_persession_userkey = $1 ");

        $result = pg_execute($db, "query", array($mykey));

        $num3 = pg_numrows($result);

        if ($num3 > 0) {
            for ($i3 = 0; $i3 < $num3; $i3++) {

                $r = pg_fetch_array($result);

                if ($r['counter'] > 0) {
                    return true;
                }

            }
        }
    }
    return false;

}

function getErrorsFromDatabase() {

    global $db;
    $sql = "select * from errors";
    $result3 = pg_query($db,$sql);
    $num3 = pg_numrows($result3);

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

function cron() {
    if (php_sapi_name() != 'cli') {
        echo "abort";
        exit;
    }

    global $db;

    
    $uniqueComputersTotal = StatsCollector::getUniqueComputersCount(false,'');
    $uniqueComputersLast = StatsCollector::getUniqueComputersCount(true,'');

    $uniqueUsersTotal = StatsCollector::getUniqueUsersCount(false,'');
    $uniqueUsersLast = StatsCollector::getUniqueUsersCount(true,'');

    $result = pg_prepare($db, "query",
        'insert into stats_daily (stats_daily_totalusers, stats_daily_activeusers, stats_daily_totalcomputers, stats_daily_activecomputers,
                  stats_daily_ts) values($1,$2,$3,$4,now())');

    $result = pg_execute($db, "query", array($uniqueUsersTotal, $uniqueUsersLast, $uniqueComputersTotal, $uniqueComputersLast));

    echo "SUCCESS";
    exit;
}

function prepareChart($last30days=false) {

    global $db;
    $sql = "select * from stats_daily ";
    if($last30days==true) {
        $sql = $sql . " where stats_daily_ts > now() - INTERVAL '30 days'";
    }
    $sql = $sql . " order by stats_daily_ts";

    $result3 = pg_query($db,$sql);
    $num3 = pg_numrows($result3);
    $chartdata=array();
    if($num3>0) {
        for ($i3 = 0; $i3 < $num3; $i3++)
        {
            $r = pg_fetch_array($result3);
            array_push($chartdata,array(
                "stats_daily_totalusers"=>$r['stats_daily_totalusers'],
                "stats_daily_activeusers"=>$r['stats_daily_activeusers'],
                "stats_daily_totalcomputers"=>$r['stats_daily_totalcomputers'],
                "stats_daily_activecomputers"=>$r['stats_daily_activecomputers'],
                "stats_daily_ts"=>date("Y-m-d",strtotime($r['stats_daily_ts']))
            ));
        }
    }

    return $chartdata;

}