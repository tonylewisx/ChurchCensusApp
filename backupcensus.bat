@echo off

REM
REM  Author: L.J Antoniazzi
REM  Date : 3/12/2015 (initial release 1.10)
REM
REM  Version: 1.11
REM
REM  Comment: create backup on customer machine and then copy backup to memory stick
REM  ( correctly specify directory for each customer firstly)
REM


title Census Backup Application

set CHURCH_CENSUS_HOME=c:\ccensus
set BACKUP_DIR=c:\temp\ccensusbackup

rem MEMSTICK_DRIVE may require changing for each site
set MEMSTICK_DRIVE=E:\
set MEMSTICK_DIR=CCENSUS_BACKUP

rem destination of backup on memory stick
set MEMSTICK_FPATH=%MEMSTICK_DRIVE%%MEMSTICK_DIR%

color e0

if not exist %CHURCH_CENSUS_HOME% (md %CHURCH_CENSUS_HOME% ) 

if not exist %BACKUP_DIR% (md %BACKUP_DIR% ) 


echo %DATE%  %time% > %BACKUP_DIR%\bck.log

echo.
echo      **********************************************************************
echo.
echo                 To Back Up Family Census application, Please place your 
echo.
echo                    Memory Stick into the computer then 
echo.

copy /Y %CHURCH_CENSUS_HOME%  %BACKUP_DIR% >> %BACKUP_DIR%\bck.log  2>&1

rem ( net send %computername% backup failed!!)

if "%ERRORLEVEL%" == "0" ( pause ) else ( echo Error Occurred on backup & pause & goto :ERROR)

if not exist %MEMSTICK_DRIVE% (echo. & echo ERROR : Unable to locate your Memory Stick on the computer & echo. & pause & goto :EOF) 

if not exist %MEMSTICK_FPATH% (md %MEMSTICK_FPATH% ) 


copy /Y %BACKUP_DIR%\*  %MEMSTICK_FPATH% >> %BACKUP_DIR%\bck.log  2>&1

echo.
echo.
echo            The Backup has Completed, it is now on your Memory Stick, 
echo.
echo                                Thank You.
echo.

pause

goto :EOF


:ERROR

Echo Backup has Failed with ERROR  - Sorry !
pause

:EOF
