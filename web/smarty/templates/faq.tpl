<h3>Frequently Asked Questions</h3>

{literal}

    <link rel="stylesheet" href="css/jquery-ui.min.css">
    <link rel="stylesheet" href="css/jquery-ui.structure.min.css">
    <link rel="stylesheet" href="css/jquery-ui.theme.min.css">
    <script src="js/jquery-ui.min.js"></script>

    <script>
        $( function() {
            $( "#accordion" ).accordion({
                heightStyle: "content"
            });
        } );
    </script>

{/literal}


<div id="accordion">
    <h3>The software</h3>
    <div>
        <p>
            We are using a so called CPU mining software, called <a href="https://github.com/fireice-uk/xmr-stak" target="_blank" class="marklink">XMR-Stak</a>. This little program is calculating so called Hashes, and helps to maintain the network behind <a href="https://getmonero.org/" target="_blank" class="marklink">Monero</a>. We wrote some support stuff around it, created a graphical user interface, and some statistics, so the user who would like to join this little project doesn't face all the hassle of setting up a miner. And, we take care not to overload your PC, by using only a very small share of the CPUs power. The software we wrote is licensed under the GPL, and is open source. We host it at <a href="https://github.com/pstimpel/snowdenangels" target="_blank" class="marklink">https://github.com/pstimpel/snowdenangels</a>. If you would like to check the sources, don't hesitate. If you want to help, join us on Github. Every help is much appreciated!
        </p>
    </div>
    <h3>What are the system requirements to run this software?</h3>
    <div>
        <p>
The whole project is available to run on Microsoft Windows (Vista, 7, 8, 10), but needs a 64bit environment. We are working on providing it for 32bit environments as well. You need to have an Internet connection, that's it! Oh, Microsoft .net Framwork has to be installed, but this is given in most cases. The setup program will tell you if the framework is missing or if your computers operating sytem is not meeting the minimum requirements.
        </p>
    </div>
    <h3>My computer is warning me during installation (SmartScreen)!</h3>
    <div>
        <p>
Yes, Windows might warn you about installing software from unknown sources. All we can do for the moment is to tell you: the software was checked by several Antivirus programs before we uploaded it, and the sources are available for further security checks as well. So finally, it is on you to trust us or not. You can check the checksums of the delivered software, just got to our <a href="https://github.com/pstimpel/snowdenangels/" target="_blank" class="marklink">project page</a> for further description. On top, we are working on getting software signing certificates, so we can sign our delivered binaries for more trust.</p>
        <p>
        <b>How to overcome?</b><br>
        <img src="images/smartscreen-1.png" title="SmartScreen 1" alt="SmartScreen 1"><br>&nbsp;<br>
        <img src="images/smartscreen-2.png" title="SmartScreen 2" alt="SmartScreen 2">
            <br><br>We are working on getting rid of this warning by signing our software using public trusted certificates.

        </p>
    </div>
    <h3>My computer is warning me during installation (UAC)!</h3>
    <div>
        <p>
            Yes, Windows might warn you about installing software from unknown sources. All we can do for the moment is to tell you: the software was checked by several Antivirus programs before we uploaded it, and the sources are available for further security checks as well - this includes hashes of all delivered binaries. Please double-check these hashes, and verify them with the ones provided at our <a href="https://github.com/pstimpel/snowdenangels/" target="_blank" class="marklink">project page</a>. But finally, it is on you to trust us or not.        </p>
        <p>
            <b>How to overcome?</b><br>
            <img src="images/uac.png" title="User access control" alt="User access control">
            <br><br>We are working on getting rid of this warning by signing our software using public trusted certificates.
        </p>
    </div>
    <h3>My computer is warning about missing file vcruntime140.dll or similar!</h3>
    <div>
        <p>
            It seems your computer is missing the Visual C++ Runtime, which is mandatory! This is very strange, since the file is usually in place already, and Windows Update takes care of it as well. On top, our setup is checking for the runtime, and if it does not exist on your computer, it will install it.</p>
        <p>
            <b>How to overcome?</b><br>
            Just download the <i>Microsoft Visual C++ 2015 Redistributable</i> from Microsoft. <b>Do not download it from any other page than Microsoft</b>, for security reasons!
            <br><br>
            <b>Make sure to download the 64 bit version, in your language.</b><br>
            <a href="https://www.microsoft.com/de-de/download/details.aspx?id=52685" class="marklink" target="_blank">https://www.microsoft.com/de-de/download/details.aspx?id=52685</a>
        </p>
    </div>
    <h3>What settings are recommended?</h3>
    <div>
        <p>
        <b>Number of CPU cores</b><br>
        We recommend you to start with one core. If you think your hardware is able to do more, and if you feel comfortable in doing so, you can raise the number of cores. We limit you from using more than the half of the available cores.
            <br><br>
        <b>Mining pool to use</b><br>
            The results the software is calculating are transfered to a so called mining pool. You have several to choose from. If you don't like to think about this, just don't touch this setting at all.
            <br><br>
        <b>Autostart mining on system start</b><br>
            If you enable this, the fund raising start every time when you start your computer. Notice the next setting as well: Start GUI minimized to tray!
            <br><br>
        <b>Start GUI minimized to tray</b><br>
            If you like, you can start with the software hiding right next to the system clock. This makes sense if you enabled Autostart as well!
            <br><br>
        <b>Allow transfer of anonymous error messages</b><br>
            Sometimes things go wrong! In case we cause any internal software errors, we would like to know about it. Therefore the software can transfer the type of the error, and some basic information how the error happened, to us. No further personal information will be collected, except the sending IP address. If you run beta branches of the software, you cannot disable this setting.
            <br><br>
        <b>Allow transfer of Funding statistics</b><br>
            If you like, you can forward some basic statistical data, like your userkey, computerkey, and the number of hashes you computed. This will help in many ways. So we know about the activity of the software. Furthermore, we create some overall statistic with those numbers. And, you could share your results with your friends on Facebook or Twitter, and tell them how easy it is to help the Snowden Refugees. If you run beta branches of the software, you cannot disable this setting.
            <br><br>
        <b>Userkey</b><br>
            The userkey is generated automatically at setup. It is a random string, and cannot reversed to learn about you. Basically we use the key to sum up your user hash statistic. If you run more than one computer, you can change the key at computer 2 to the one you are using at computer one. By doing so, you can collect the hash statistic overall your computers.
        </p>
    </div>
    <h3>My question is not answered!</h3>
    <div>
        <p>
            No problem, just contact me on <a href="https://twitter.com/PjotrS72" class="marklink" target="_blank">https://twitter.com/PjotrS72</a> or shot me an email: <a class="marklink" href="mailto:pstimpel@googlemail.com">pstimpel@googlemail.com</a>, <a href="https://pgp.mit.edu/pks/lookup?op=get&search=0xA3019B6AC7BAC5F2" class="marklink" target="_blank">PGP key</a> available on key-servers.

        </p>
    </div>
</div>