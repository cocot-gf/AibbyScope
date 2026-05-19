@echo off
if "%1" == "" goto usage

set curdir=%~dp0
set srcdir=%~f1\driver\
echo %curdir%
for %%a in (%curdir%inc\*.*) do (echo %%~nxa & copy /b /y %srcdir%inc\%%~nxa %curdir%inc)
for %%a in (%curdir%lib\*.*) do (echo %%~nxa & copy /b /y %srcdir%lib\%%~nxa %curdir%lib)
for %%a in (%curdir%src\*.*) do (echo %%~nxa & copy /b /y %srcdir%src\%%~nxa %curdir%src)
dir %curdir%inc %curdir%lib %curdir%src
echo.
echo Copy Finished.
echo.
goto exit

:usage
echo.
echo Drop "SourceCode" folder to me.
echo.

:exit
pause
