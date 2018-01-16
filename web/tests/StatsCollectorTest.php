<?php


use PHPUnit\Framework\TestCase;

require_once ("includes/StatsCollector.php");

class StatsCollectorTest extends TestCase
{

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
