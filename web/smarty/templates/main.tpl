<h2>Snowden's Guardian Angels - Support</h2>
<h3>Generating funds and awareness!</h3>
<h4>Summaries</h4>

{if sizeof($personal)!=0}

    <div class="row flex-row" >
        <div class="col-lg-12 col-sm-12">
            <p>Stats for user <b>{$personal.key}</b></p>
            <table class="table table-responsive">
                <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>Hashrate/s</th>
                    <th>Hashrate sum</th>
                    <th>XMR</th>
                    <th>USD</th>
                    <th>Computers</th>

                </tr>
                </thead>
                <tbody>
                <tr>
                    <td><b>est. Total</b></td>
                    <td>{$personal.hashRatePerSecondSummaryTotal}</td>
                    <td>{$personal.hashRateSummaryTotal}</td>
                    <td>{$personal.sumXMRTotal}</td>
                    <td>{$personal.sumUSDTotal}</td>
                    <td>{$personal.uniqueComputersTotal}</td>

                </tr>
                <tr>
                    <td><b>est. Last 24h</b></td>
                    <td>{$personal.hashRatePerSecondSummaryLast}</td>
                    <td>{$personal.hashRateSummaryLast}</td>
                    <td>{$personal.sumXMRLast}</td>
                    <td>{$personal.sumUSDLast}</td>
                    <td>{$personal.uniqueComputersLast}</td>

                </tr>

                </tbody>

            </table>
        </div>
    </div>
{/if}


<div class="row flex-row" >
    <div class="col-lg-6 col-sm-12">
        <table class="table table-responsive">
            <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Hashrate/s</th>
                <th>Hashrate sum</th>
                <th>XMR</th>
                <th>USD</th>
                <th>Computers</th>
                <th>Users</th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <td><b>est. Total</b></td>
                <td>{$summaries.hashRatePerSecondSummaryTotal}</td>
                <td>{$summaries.hashRateSummaryTotal}</td>
                <td>{$summaries.sumXMRTotal}</td>
                <td>{$summaries.sumUSDTotal}</td>
                <td>{$summaries.uniqueComputersTotal}</td>
                <td>{$summaries.uniqueUsersTotal}</td>
            </tr>
            <tr>
                <td><b>est. Last 24h</b></td>
                <td>{$summaries.hashRatePerSecondSummaryLast}</td>
                <td>{$summaries.hashRateSummaryLast}</td>
                <td>{$summaries.sumXMRLast}</td>
                <td>{$summaries.sumUSDLast}</td>
                <td>{$summaries.uniqueComputersLast}</td>
                <td>{$summaries.uniqueUsersLast}</td>
            </tr>

            </tbody>

        </table>
    </div>

    <div class="col-lg-6 col-sm-12">
        <table class="table table-responsive">
            <thead>
            <tr>
                <th>Userkey</th>
                <th>Hashrate sum</th>
                <th>XMR</th>
                <th>USD</th>
            </tr>
            </thead>
            <tbody>
                {section name=mysec loop=$tops}

                    <tr>
                        <td>{$tops[mysec].key}</td>
                        <td>{$tops[mysec].hashRatePerSecondSummaryTotal}</td>
                        <td>{$tops[mysec].sumXMRTotal}</td>
                        <td>{$tops[mysec].sumUSDTotal}</td>
                    </tr>

                {/section}

            </tbody>

        </table>
    </div>


</div>

{if sizeof($chartdata30d) > 0}
{literal}
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", {packages: ["corechart"]});
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Day', 'Total users', 'Active Users', 'Total computers', 'Active computers'],
                {/literal}
                {section name=mysec loop=$chartdata30d}
                ['{$chartdata30d[mysec].stats_daily_ts}',  {$chartdata30d[mysec].stats_daily_totalusers},  {$chartdata30d[mysec].stats_daily_activeusers},  {$chartdata30d[mysec].stats_daily_totalcomputers},  {$chartdata30d[mysec].stats_daily_activecomputers}]
                {if !$smarty.section.mysec.last}
                ,
                {/if}
                {/section}
                {literal}
            ]);

            var options = {
                title: 'Last 30 days (refresh nightly)',
                curveType: 'function',
                colors: ['#000000','#FF0000','#00FF00','#0000FF']
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
{/literal}
    <div class="row flex-row">
        <div class="col-lg-12 col-sm-12">
            <div id="chart_div" style="width: 100%; height: 250px;"></div>
        </div>
    </div>
{/if}

{if sizeof($chartdata30d) > 0}
{literal}
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", {packages: ["corechart"]});
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Day', 'Total users', 'Active Users', 'Total computers', 'Active computers'],
                {/literal}
                {section name=mysec loop=$chartdataFull}
                ['{$chartdataFull[mysec].stats_daily_ts}',  {$chartdataFull[mysec].stats_daily_totalusers},  {$chartdataFull[mysec].stats_daily_activeusers},  {$chartdataFull[mysec].stats_daily_totalcomputers},  {$chartdataFull[mysec].stats_daily_activecomputers}]
                {if !$smarty.section.mysec.last}
                ,
                {/if}
                {/section}
                {literal}
            ]);

            var options = {
                title: 'Since the very beginning (refresh nightly)',
                curveType: 'function',
                colors: ['#000000','#FF0000','#00FF00','#0000FF']
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div1'));
            chart.draw(data, options);
        }
    </script>
{/literal}
    <div class="row flex-row">
        <div class="col-lg-12 col-sm-12">
            <div id="chart_div1" style="width: 100%; height: 250px;"></div>
        </div>
    </div>
{/if}

