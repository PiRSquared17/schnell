@echo off
pushd %~dp0\src
for %%i in (*.sln) do call :build %%i
popd
goto :EOF

:build
for %%i in (Debug Release) do %SystemRoot%\Microsoft.NET\Framework\v2.0.50727\msbuild %1 /p:Configuration=%%i
goto :EOF
