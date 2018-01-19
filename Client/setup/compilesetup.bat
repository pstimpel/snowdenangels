
"c:\Program Files (x86)\Windows Kits\10\bin\10.0.15063.0\x64\signtool.exe" sign /n "Open Source Developer, Peter Stimpel" /t http://time.certum.pl/ /fd sha1 /v ../SnowdenAngelsSupport\SnowdenAngelsSupport\bin\Release\SnowdenAngelsSupport.exe

"c:\Program Files (x86)\Windows Kits\10\bin\10.0.15063.0\x64\signtool.exe" sign /n "Open Source Developer, Peter Stimpel" /t http://time.certum.pl/ /fd sha1 /v ../xmr-stak\xmr-stak.exe

"c:\Program Files (x86)\Windows Kits\10\bin\10.0.15063.0\x64\signtool.exe" sign /n "Open Source Developer, Peter Stimpel" /t http://time.certum.pl/ /fd sha1 /v ../xmr-stak\libeay32.dll

"c:\Program Files (x86)\Windows Kits\10\bin\10.0.15063.0\x64\signtool.exe" sign /n "Open Source Developer, Peter Stimpel" /t http://time.certum.pl/ /fd sha1 /v ../xmr-stak\ssleay32.dll



call hashandsign.bat

del /Q ..\..\release\sassetup*.exe

"C:\Program Files (x86)\Inno Setup 5\ISCC.exe" sassetup.iss



"c:\Program Files (x86)\Windows Kits\10\bin\10.0.15063.0\x64\signtool.exe" sign /n "Open Source Developer, Peter Stimpel" /t http://time.certum.pl/ /fd sha1 /v ../../release/sassetup*.exe

copy list.txt.asc ..\..\hashes.txt

del list.txt.asc

cd ..\..\release

c:\cygwin64\bin\sha256sum.exe *.exe > list.txt

gpg --clearsign --armor -u "pstimpel@googlemail.com" list.txt

copy list.txt.asc ..\setuphash.txt

del /Q list.txt.asc
del /Q list.txt


pause