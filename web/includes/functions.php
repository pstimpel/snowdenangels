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

function getMarketData() {

    //print_r($array);

    $XMRMarket=array("XMR2BTC"=>0, "BTC2USD"=>0);

    $XMRMarketget=false;
    if($_SERVER["HTTP_HOST"] != "127.0.0.1") {

        $memcache = new Memcached;
        $memcache->addServers(array(array("127.0.0.1", 11211)));
        $XMRMarketget = $memcache->get("SGAXMRMarket");

    }
    if($XMRMarketget===false) {



        $homepage = file_get_contents('https://blockchain.info/de/ticker');
        $array=json_decode($homepage, true);

        $rateBtcInUsd=$array["USD"]["last"];




        $homepage = file_get_contents('https://bittrex.com/api/v1.1/public/getmarkets');
        $array=json_decode($homepage, true);




        $rateXmrInBtc=0;


        foreach ($array['result'] as $item) {
            if($item['MarketCurrency']=="XMR" && $item['BaseCurrency']=="BTC") {
                $rateXmrInBtc=$item['MinTradeSize'];
            }

        }

        $XMR1InBTC = $rateXmrInBtc;

        $XMR2USD = $XMR1InBTC * $rateBtcInUsd;


        $HashesPerXMR = (120000 * 86400);

        $XMRMarket=array("XMR2BTC"=>$rateXmrInBtc, "BTC2USD"=>$rateBtcInUsd, "XMR2USD"=> $XMR2USD, "HashesPerXMR"=>$HashesPerXMR);


        if($_SERVER["HTTP_HOST"] != "127.0.0.1") {
            $memcache->set("SGAXMRMarket", $XMRMarket, 600);
        }

        return $XMRMarket;

    } else {
        return $XMRMarketget;
    }


}

function getTops() {
    global $db;
    
    $sql = "select sum(stats_persession_hashes) as hashes, stats_persession_userkey from stats_persession
            group by stats_persession_userkey order by hashes desc limit 5";

    $result = pg_query($db, $sql);
    
    $num3 = pg_numrows($result);

    $counts=array();
    $market = getMarketData();
    
    if ($num3 > 0) {
        for ($i3 = 0; $i3 < $num3; $i3++) {
            
            $r = pg_fetch_array($result);
    
    
            array_push($counts,array(
                "key"=>substr($r['stats_persession_userkey'],0,10)."...".substr($r['stats_persession_userkey'],54,
                        10),
                "hashRatePerSecondSummaryTotal"=>$r['hashes'],
                "sumXMRTotal"=>sprintf('%.8f', round($r['hashes']/$market['HashesPerXMR'],8)),
                "sumUSDTotal"=>sprintf('%.2f', round(($r['hashes']/$market['HashesPerXMR'])*$market['XMR2USD'],2))
            ));
        }
    }
    return $counts;
    
}


function getSummaries($mykey='') {

    $memcacheobject='SGAScounters';
    $memcachecachetime=300;
    if($mykey!='') {
        $memcacheobject='SGAScounters_'.$mykey;
        $memcachecachetime=300;
    }
    $countscache=false;
    if($_SERVER["HTTP_HOST"] != "127.0.0.1") {

        $memcache = new Memcached;
        $memcache->addServers(array(array("127.0.0.1", 11211)));
        $countscache = $memcache->get($memcacheobject);

    }
    if($countscache===false) {
        $hashRatePerSecondSummaryTotal = getHashratePerSecondSummary(false, $mykey);
        $hashRatePerSecondSummaryLast = getHashratePerSecondSummary(true, $mykey);

        $hashRateSummaryTotal=getHashrateSummary(false, $mykey);
        $hashRateSummaryLast=getHashrateSummary(true, $mykey);

        $uniqueComputersTotal=getUniqueComputersCount(false, $mykey);
        $uniqueComputersLast=getUniqueComputersCount(true, $mykey);

        $uniqueUsersTotal = getUniqueUsersCount(false, $mykey);
        $uniqueUsersLast = getUniqueUsersCount(true, $mykey);

        $market = getMarketData();


        $countscache=array(
            "key"=>$mykey,
            "hashRatePerSecondSummaryTotal"=>$hashRatePerSecondSummaryTotal,
            "hashRatePerSecondSummaryLast"=>$hashRatePerSecondSummaryLast,
            "hashRateSummaryTotal"=>$hashRateSummaryTotal,
            "hashRateSummaryLast"=>$hashRateSummaryLast,
            "uniqueComputersTotal"=>$uniqueComputersTotal,
            "uniqueComputersLast"=>$uniqueComputersLast,
            "uniqueUsersTotal"=>$uniqueUsersTotal,
            "uniqueUsersLast"=>$uniqueUsersLast,
            "sumXMRTotal"=>sprintf('%.8f', round($hashRateSummaryTotal/$market['HashesPerXMR'],8)),
            "sumXMRLast"=>sprintf('%.8f', round($hashRateSummaryLast/$market['HashesPerXMR'],8)),
            "sumUSDTotal"=>sprintf('%.2f', round(($hashRateSummaryTotal/$market['HashesPerXMR'])*$market['XMR2USD'],2)),
            "sumUSDLast"=>sprintf('%.2f', round(($hashRateSummaryLast/$market['HashesPerXMR'])*$market['XMR2USD'],2))
        );
        if($_SERVER["HTTP_HOST"] != "127.0.0.1") {
            $memcache->set($memcacheobject, $countscache, $memcachecachetime);
        }
    }

    return $countscache;

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

    if($personal==false) {
        $data=getSummaries();
        $data['key']='none';

    } else {
        if(strlen($mykey)==64) {

            $data=getSummaries($mykey);
        } else {

            $data=array();
        }

    }

    $xml = new SimpleXMLElement('<data/>');
    to_xml($xml, $data);

    print $xml->asXML();
    exit;
}

function displayMain() {
    global $smarty;

    $smarty->assign("summaries",getSummaries());

    $smarty->assign("chartdataFull",prepareChart(false));
    $smarty->assign("chartdata30d",prepareChart(true));

    if(strlen($_SESSION["userkey"])==64) {

        $smarty->assign("personal", getSummaries($_SESSION["userkey"]));
    } else {

        $smarty->assign("personal", array());
    }

    $smarty->assign("tops",getTops());
    
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

function getHashratePerSecondSummary($last24hours = false, $mykey='') {
    global $db;
    $sql = "select avg(stats_persession_hashes / (1+((DATE_PART('day', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp) * 24 + 
                DATE_PART('hour', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp)) * 60 +
                DATE_PART('minute', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp)) * 60 +
                DATE_PART('second', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp))) as hashspersecsum 
from stats_persession where stats_persession_sessionend<>stats_persession_sessionstart";
    if($last24hours==true) {
        $sql = $sql . " and stats_persession_sessionend > now() - INTERVAL '1 days'";
    }
    if($mykey!='') {
        $sql = $sql . " and stats_persession_userkey='" . $mykey . "'";
    }
    $result3 = pg_query($db,$sql);
    $num3 = pg_numrows($result3);

    if($num3>0) {
        for ($i3 = 0; $i3 < $num3; $i3++)
        {
            $r = pg_fetch_array($result3);
            return round($r['hashspersecsum'],0);
        }
    }
    return 0;
}

function getHashrateSummary($last24hours = false, $mykey='') {
    global $db;
    $sql = "select sum(stats_persession_hashes) as summary  from stats_persession where 1=1 ";
    if($last24hours==true) {
        $sql = $sql . " and stats_persession_sessionend > now() - INTERVAL '1 days'";
    }

    if($mykey!='') {
        $sql = $sql . " and stats_persession_userkey='" . $mykey . "'";
    }
    $result3 = pg_query($db,$sql);

    $num3 = pg_numrows($result3);

    if($num3>0) {
        for ($i3 = 0; $i3 < $num3; $i3++)
        {
            $r = pg_fetch_array($result3);
            return $r['summary'];
        }
    }
    return 0;
}

function getUniqueComputersCount($activeonly = false, $mykey='') {
    global $db;
    $sql = "select count(distinct stats_persession_computerkey) as counter  from stats_persession where 1=1 ";
    if($activeonly==true) {
        $sql = $sql . " and stats_persession_sessionend > now() - INTERVAL '1 days'";
    }
    if($mykey!='') {
        $sql = $sql . " and stats_persession_userkey='" . $mykey . "'";
    }
    $result3 = pg_query($db,$sql);
    $num3 = pg_numrows($result3);

    if($num3>0) {
        for ($i3 = 0; $i3 < $num3; $i3++)
        {
            $r = pg_fetch_array($result3);
            return $r['counter'];
        }
    }
    return 0;
}

function getUniqueUsersCount($activeonly = false, $mykey='') {
    global $db;
    $sql = "select count(distinct stats_persession_userkey) as counter  from stats_persession where 1=1 ";
    if($activeonly==true) {
        $sql = $sql . " and stats_persession_sessionend > now() - INTERVAL '1 days'";
    }
    if($mykey!='') {
        $sql = $sql . " and stats_persession_userkey='" . $mykey . "'";
    }
    $result3 = pg_query($db,$sql);
    $num3 = pg_numrows($result3);

    if($num3>0) {
        for ($i3 = 0; $i3 < $num3; $i3++)
        {
            $r = pg_fetch_array($result3);
            return $r['counter'];
        }
    }
    return 0;
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

    $uniqueComputersTotal=getUniqueComputersCount(false);
    $uniqueComputersLast=getUniqueComputersCount(true);

    $uniqueUsersTotal = getUniqueUsersCount(false);
    $uniqueUsersLast = getUniqueUsersCount(true);

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