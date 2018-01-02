<h2>Summaries</h2>

<div class="row flex-row" >
    <div class="col-lg-12 col-sm-12">
        <table class="table table-responsive">
            <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Hashrate/s</th>
                <th>Hashrate sum</th>
                <th>Computers</th>
                <th>Users</th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <td><b>Total</b></td>
                <td>{$summaries.hashRatePerSecondSummaryTotal}</td>
                <td>{$summaries.hashRateSummaryTotal}</td>
                <td>{$summaries.uniqueComputersTotal}</td>
                <td>{$summaries.uniqueUsersTotal}</td>
            </tr>
            <tr>
                <td><b>Last 24h</b></td>
                <td>{$summaries.hashRatePerSecondSummaryLast}</td>
                <td>{$summaries.hashRateSummaryLast}</td>
                <td>{$summaries.uniqueComputersLast}</td>
                <td>{$summaries.uniqueUsersLast}</td>
            </tr>

            </tbody>

        </table>
    </div>
</div>

