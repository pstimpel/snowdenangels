<?php
/**
 * the sitemap for search engines
 */
header("Content-type: application/xhtml+xml");
echo '<?xml version="1.0" encoding="UTF-8"?>'."\n";?>
<urlset xmlns="http://www.google.com/schemas/sitemap/0.84">
    <url>
        <loc>https://redzoneaction.org/sgasupport/</loc>
        <lastmod><?php echo date("Y-m-d")?></lastmod>
    </url>
    <url>
        <loc>https://redzoneaction.org/sgasupport/?page=about</loc>
        <lastmod><?php echo date("Y-m-d")?></lastmod>
    </url>
    <url>
        <loc>https://redzoneaction.org/sgasupport/?page=legal</loc>
        <lastmod><?php echo date("Y-m-d")?></lastmod>
    </url>
    <url>
        <loc>https://redzoneaction.org/sgasupport/?page=faq</loc>
        <lastmod><?php echo date("Y-m-d")?></lastmod>
    </url>
    <url>
        <loc>https://redzoneaction.org/sgasupport/page=stats</loc>
        <lastmod><?php echo date("Y-m-d")?></lastmod>
    </url>
</urlset>