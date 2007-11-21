@echo off
pushd "%~dp0"
setlocal

set SCHWIKI=..\..\bin\Debug\schwiki.exe
if not exist "%SCHWIKI%" (
    echo Did you forget to build the project?
    goto :EOF
)

if "%1"=="" (
    call :help
) else (
    call :test %1
)

popd
goto :EOF

:test
echo Exporting wikis from http://%1.googlecode.com/svn/wiki/
svn export http://%1.googlecode.com/svn/wiki/ %1
for %%i in (*.css *.js) do copy %%i %1 > nul
for %%i in (%1\*.wiki) do echo Formatting %%i && "%SCHWIKI%" -t wikitemp.html "%%i" "%%~dpni.html" --name-pattern %%([a-z]+)%% -d "time=%DATE% %TIME%" -d url=http://code.google.com/p/%1/wiki/%%~ni
echo = Index = > %1\index.tmp
for %%i in (%1\*.wiki) do echo   * [%%~ni] >> %1\index.tmp
"%SCHWIKI%" -t idxtemp.html %1\index.tmp %1\index.html --name-pattern %%([a-z]+)%% -d "time=%DATE% %TIME%"
del %1\index.tmp
start %1\index.html
goto :EOF

:help
echo Usage:
echo.
echo   %~n0 PROJECT
echo.
echo   This script exports wikis from PROJECT hosted on Google Code 
echo   Project Hosting (see http://code.google.com/hosting/) and formats 
echo   them into HTML. It will then launch an index of the formatted
echo   HTML files. The files are exported and formatted in a 
echo   sub-directory that is named after the project.
echo.
echo Example:
echo.
echo   %~n0 support
echo.
echo   This example export and format wikis from the project over at
echo   http://support.googlecode.com/. You should really try the above
echo   and then check out support\WikiSyntax.wiki and, once formatted,
echo   support\WikiSyntax.html.
echo.
echo Notes:
echo.
echo   The export is carried out using the Subversion command-line 
echo   interface so svn.exe must be somewhere in your PATH.
echo.
echo Limitations:
echo.
echo   * The export only occurs once for a given project. To re-run this
echo     on a project, make sure you delete its sub-directory entirely
echo     (use rmdir PROJECT /s /q).
echo.
echo   * This script cannot handle spaces within wiki file names.
echo.
echo   * You must have JavaScript enabled in your browser to get the
echo     code syntax highlighting to work.

goto :EOF
