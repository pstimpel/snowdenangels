{include file="head.tpl"}
<body>

{include file="menu.tpl"}




<div id="content_container" style="margin: 10px;">

    <div id="container">

        {if $display eq "faq"}
            {include file="faq.tpl"}
        {elseif $display eq "about"}
            {include file="about.tpl"}
        {elseif $display eq "legal"}
            {include file="legal.tpl"}
        {else}
            {include file="main.tpl"}
        {/if}




{include file="foot.tpl"}
