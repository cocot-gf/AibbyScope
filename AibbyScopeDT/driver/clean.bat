@echo off
for %%a in (inc\*.*) do (echo %%a & copy /b /y nul %curdir%%%a)
for %%a in (lib\*.*) do (echo %%a & copy /b /y nul %curdir%%%a)
for %%a in (src\*.*) do (echo %%a & copy /b /y nul %curdir%%%a)
dir inc lib src
echo.
echo Clean Finished.
echo.
pause
