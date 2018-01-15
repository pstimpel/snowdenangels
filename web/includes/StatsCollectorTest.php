<?php



class StatsCollectorTest extends PHPUnit_Framework_TestCase
{
    
    public function testGetMarketData()
    {
        $market = StatsCollector::getMarketData();
        $this->assertNotEmpty($market['XMR2BTC']);
        $this->assertGreaterThan(0,$market['XMR2BTC']);
        
    }
}
