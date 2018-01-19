@rem Delete the old stuff first of exists

del list.txt 
del list.txt.asc 

@rem create a temp directory
md temp

@rem switch into this temp directory
cd temp

@rem copy the files in question temp directory
copy ..\..\SnowdenAngelsSupport\SnowdenAngelsSupport\bin\Release\SnowdenAngelsSupport.exe *  
copy ..\..\xmr-stak\xmr-stak.exe *  
copy ..\..\xmr-stak\*.lib * 
copy ..\..\xmr-stak\*.dll * 

@rem create sha256 hashes of these files and store it outside this temp directory
c:\cygwin64\bin\sha256sum.exe *.* > ..\list.txt

@rem move away from this temp directory
cd ..\

@rem delete the temp directory
rd /S /Q temp 

@rem sign the created list
gpg --clearsign --armor -u "pstimpel@googlemail.com" list.txt

@rem remove the list file, just keep the output after signing

del list.txt



