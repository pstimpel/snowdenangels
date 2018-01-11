call hashandsign.bat

"C:\Program Files (x86)\Inno Setup 5\ISCC.exe" sassetup.iss

copy list.txt.asc ..\..\hashes.txt

del list.txt.asc

cd ..\..\release

c:\cygwin64\bin\sha256sum.exe *.exe > list.txt

gpg --clearsign --armor -u "pstimpel@googlemail.com" list.txt

copy list.txt.asc ..\setuphash.txt

del /Q list.txt.asc
del /Q list.txt


pause