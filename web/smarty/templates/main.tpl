<div class="row flex-row" >
    <div class="col-lg-12 col-sm-12">
        <h2>Snowden's Guardian Angels - Support</h2>
        <h3>Generating funds and awareness!</h3>
    </div>
</div>

<div class="row flex-row" >
    <div class="col-lg-12 col-sm-12">
        <h5>Beta, but you could join!</h5>
        <p>Dear visitor, at the moment this is all beta, it is in development, it is a test. But if you would like to join, please do so. We are generating funds already, even this is a test. Joining us is easy: just download the support client, install it...that's it! Thanks for considering!</p>
    </div>
</div>

<div class="row flex-row" >
    <div class="col-lg-12 col-sm-12">

<h4>Summaries</h4>
    </div>
</div>
{if sizeof($personal)!=0}

    <div class="row flex-row" >
        <div class="col-lg-12 col-sm-12">
            <h5 class="greyheader">Stats for user <b>{$personal.key}</b></h5>
            <table class="table table-responsive">
                <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>Hashrate/s</th>
                    <th>Hashrate sum</th>
                    <th>XMR</th>
                    <th>USD</th>
                    <th>Computers</th>
                    <th>Days to 1 XMR</th>
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
                    <td>{$personal.daysToXMRTotal}</td>
                </tr>
                <tr>
                    <td><b>est. Last 24h</b></td>
                    <td>{$personal.hashRatePerSecondSummaryLast}</td>
                    <td>{$personal.hashRateSummaryLast}</td>
                    <td>{$personal.sumXMRLast}</td>
                    <td>{$personal.sumUSDLast}</td>
                    <td>{$personal.uniqueComputersLast}</td>
                    <td>{$personal.daysToXMRLast}</td>

                </tr>

                </tbody>

            </table>
        </div>
    </div>
{/if}


<div class="row flex-row" >
    <div class="col-lg-6 col-sm-12">
        <h5 class="greyheader addtopmargin">Total stats of Support network</h5>
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
                <th>Days to 1 XMR</th>

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
                <td>{$summaries.daysToXMRTotal}</td>
            </tr>
            <tr>
                <td><b>est. Last 24h</b></td>
                <td>{$summaries.hashRatePerSecondSummaryLast}</td>
                <td>{$summaries.hashRateSummaryLast}</td>
                <td>{$summaries.sumXMRLast}</td>
                <td>{$summaries.sumUSDLast}</td>
                <td>{$summaries.uniqueComputersLast}</td>
                <td>{$summaries.uniqueUsersLast}</td>
                <td>{$summaries.daysToXMRLast}</td>
            </tr>

            </tbody>

        </table>
        <h5 class="greyheader addtopmargin">Current market data</h5>
        <table class="table table-responsive">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>1 XMR in BTC</th>
                    <th>1 BTC in USD</th>
                    <th>1 XMR in USD</th>
                    <th>est. Hashes per XMR</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><b>Market data</b></td>
                    <td>{$market['XMR2BTC']|number_format:6:".":","}</td>
                    <td>{$market['BTC2USD']|number_format:2:".":","}</td>
                    <td>{$market['XMR2USD']|number_format:2:".":","}</td>
                    <td>{$market['HashesPerXMR']|number_format:0:".":","}</td>
                </tr>

            </tbody>
        </table>
        <h5 class="greyheader addtopmargin">Estimates if 1000 users join the Support network</h5>
        <table class="table table-responsive">
            <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Hashrate/s</th>
                <th>Hashrate sum</th>
                <th>XMR</th>
                <th>USD</th>
                <th>Days to 1 XMR</th>

            </tr>
            </thead>
            <tbody>
            <tr>
                <td><b>est. Total</b></td>
                <td>{$summaries1000users.hashRatePerSecondSummaryTotal}</td>
                <td>{$summaries1000users.hashRateSummaryTotal}</td>
                <td>{$summaries1000users.sumXMRTotal}</td>
                <td>{$summaries1000users.sumUSDTotal}</td>
                <td>{$summaries1000users.daysToXMRTotal}</td>
            </tr>
            <tr>
                <td><b>est. Last 24h</b></td>
                <td>{$summaries1000users.hashRatePerSecondSummaryLast}</td>
                <td>{$summaries1000users.hashRateSummaryLast}</td>
                <td>{$summaries1000users.sumXMRLast}</td>
                <td>{$summaries1000users.sumUSDLast}</td>
                <td>{$summaries1000users.daysToXMRLast}</td>
            </tr>

            </tbody>

        </table>
    </div>

    <div class="col-lg-6 col-sm-12">
        <h5 class="greyheader addtopmargin">Top 5 Supporters</h5>
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
            <div id="chart_div" style="width: 100%; height: 250px;" class="addtopmargin"></div>
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
            <div id="chart_div1" style="width: 100%; height: 250px;" class="addtopmargin"></div>
        </div>
    </div>
{/if}

