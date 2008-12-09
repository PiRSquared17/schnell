@echo off
pushd "%~dp0src"
for %%i in (*.sln) do call :build %%i
popd
goto :EOF

:build
for %%i in (Debug Release) do %SystemRoot%\Microsoft.NET\Framework\v3.5\msbuild %1 /p:Configuration=%%i
goto :EOF
