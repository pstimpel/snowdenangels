<?php


use PHPUnit\Framework\TestCase;

require_once (__DIR__ . "/../includes/StatsCollector.php");
require_once (__DIR__ . "/../includes/functions.php");

class StatsCollectorTest extends TestCase
{

    public function testcalc1000UsersSummary() {
    
        $value=array(
            "key"=>"17",
            "daysToXMRTotal"=>1000,
            "daysToXMRLast"=>500,
            "hashRatePerSecondSummaryTotal"=>200,
            "hashRatePerSecondSummaryLast"=>100,
            "hashRateSummaryTotal"=>50000000,
            "hashRateSummaryLast"=>25000000,
            "uniqueComputersTotal"=>100,
            "uniqueComputersLast"=>50,
            "uniqueUsersTotal"=>80,
            "uniqueUsersLast"=>40,
            "sumXMRTotal"=>15.75,
            "sumXMRLast"=>12.87,
            "sumUSDTotal"=>5874.45,
            "sumUSDLast"=>2786.99
        );
        
        $foo = calc1000UsersSummary($value);
        
        $this->assertEquals(80.0,$foo['daysToXMRTotal']);
    
        $this->assertEquals(625000000.0,$foo['hashRateSummaryTotal']);
    
        $this->assertEquals(196.875,$foo['sumXMRTotal']);

        $this->assertEquals(69674.75,$foo['sumUSDLast']);
        
    }
    
    public function testStatsCollector() {
        
        $foo = new StatsCollector();

        $this->assertEquals('', $foo->userkey);

        $foo->userkey='dfdsfsd';
        $this->assertEquals('dfdsfsd', $foo->userkey);
    
    }
    
    public function testGetMarketData()
    {

        $market = StatsCollector::getMarketData();

        $this->assertNotEmpty($market['XMR2BTC']);
        $this->assertGreaterThan(0,$market['XMR2BTC']);
        $this->assertNotNull($market['XMR2BTC']);

        $this->assertNotEmpty($market['BTC2USD']);
        $this->assertGreaterThan(0,$market['BTC2USD']);
        $this->assertNotNull($market['BTC2USD']);

    }
    
}
