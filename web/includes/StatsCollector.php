<?php


class StatsCollector
{
    public $userkey;
    
    function __construct() {

        $this->userkey='';

    }
    
    public function getSummary() {

        return $this->compileSummary();

    }
    
    private function compileSummary() {
        $memcacheobject='SGAScounters';
        $memcachecachetime=300;
        if($this->userkey!='') {
            $memcacheobject='SGAScounters_'.$this->userkey;
            $memcachecachetime=300;
        }
        $countscache=false;
        if($_SERVER["HTTP_HOST"] != "127.0.0.1") {
        
            $memcache = new Memcached;
            $memcache->addServers(array(array("127.0.0.1", 11211)));
            $countscache = $memcache->get($memcacheobject);
        
        }
        //$countscache=false;
        if($countscache===false) {
            $hashRatePerSecondSummaryTotal = $this->getHashratePerSecondSummary(false, $this->userkey);
            $hashRatePerSecondSummaryLast = $this->getHashratePerSecondSummary(true, $this->userkey);
        
            $hashRateSummaryTotal=$this->getHashrateSummary(false, $this->userkey);
            $hashRateSummaryLast=$this->getHashrateSummary(true, $this->userkey);
        
            $uniqueComputersTotal=StatsCollector::getUniqueComputersCount(false, $this->userkey);
            $uniqueComputersLast=StatsCollector::getUniqueComputersCount(true, $this->userkey);
        
            $uniqueUsersTotal = StatsCollector::getUniqueUsersCount(false, $this->userkey);
            $uniqueUsersLast = StatsCollector::getUniqueUsersCount(true, $this->userkey);
        
            $market = $this::getMarketData();
        
            //now calculate how long it takes to 1 monero
            $hashesPer24hTotal = $hashRatePerSecondSummaryTotal * 86400;
            $hashesPer24hLast = $hashRatePerSecondSummaryLast * 86400;
            $daysToXMRTotal = $market['HashesPerXMR'] / $hashesPer24hTotal;
            $daysToXMRLast = $market['HashesPerXMR'] / $hashesPer24hLast;
            //echo $hashesPer24hTotal." ".$hashesPer24hLast." ".$daysToXMRTotal." ".$daysToXMRLast."<hr>";
        
        
            $countscache=array(
                "key"=>$this->userkey,
                "daysToXMRTotal"=>sprintf('%.1f',round($daysToXMRTotal,1)),
                "daysToXMRLast"=>sprintf('%.1f',round($daysToXMRLast,1)),
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
    
    private function getHashratePerSecondSummary($last24hours, $mykey) {
        global $db;
        $sql = "select avg(stats_persession_hashes / (1+((DATE_PART('day', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp) * 24 +
                DATE_PART('hour', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp)) * 60 +
                DATE_PART('minute', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp)) * 60 +
                DATE_PART('second', stats_persession_sessionend::timestamp - stats_persession_sessionstart::timestamp))) as hashspersecsum
from stats_persession where stats_persession_sessionend<>stats_persession_sessionstart and stats_persession_hashes > 0";
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
    
    private function getHashrateSummary($last24hours, $mykey) {
        global $db;
        $sql = "select sum(stats_persession_hashes) as summary  from stats_persession where 1=1 and stats_persession_hashes > 0";
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
    
    public static function getUniqueComputersCount($activeonly, $mykey) {
        global $db;
        $sql = "select count(distinct stats_persession_computerkey) as counter  from stats_persession where 1=1  and stats_persession_hashes > 0";
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
    
    public static function getUniqueUsersCount($activeonly, $mykey) {
        global $db;
        $sql = "select count(distinct stats_persession_userkey) as counter  from stats_persession where 1=1  and stats_persession_hashes > 0";
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
    

    
    public static function getMarketData() {
    
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
        
            $homepage = file_get_contents('https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=XMR,BTC');
            $array=json_decode($homepage, true);
        
            $rateXmrInBtc=$array['BTC']/$array['XMR'];
        
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
    
    public static function getTops() {
        global $db;
        
        $sql = "select sum(stats_persession_hashes) as hashes, stats_persession_userkey from stats_persession
                group by stats_persession_userkey order by hashes desc limit 5";
        
        $result = pg_query($db, $sql);
        
        $num3 = pg_numrows($result);
        
        $counts=array();
        $market = StatsCollector::getMarketData();
        
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
    
    
}