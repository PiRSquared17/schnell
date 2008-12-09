@echo off
pushd "%~dp0src"
for %%i in (*.sln) do (
  for %%j in (Debug Release) do %SystemRoot%\Microsoft.NET\Framework\v3.5\msbuild %%i /p:Configuration=%%j
)
popd
