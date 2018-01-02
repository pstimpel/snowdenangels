{include file="head.tpl"}
<body>

{include file="menu.tpl"}




<div id="content_container" style="margin: 10px;">

    <div id="container">

        {if $display eq ""}
            {include file=".tpl"}
        {elseif $display eq ""}
            {include file=".tpl"}
        {else}
            {include file="main.tpl"}
        {/if}




{include file="foot.tpl"}
