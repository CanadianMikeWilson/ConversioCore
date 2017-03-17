@echo Off
set config=%1
if "%config%" == "" (
    set config=Release
)

set version=
REM if not "%BuildCounter%" == "" (
REM    set version=--version-suffix ci-%BuildCounter%
REM )

REM (optional) build.bat is in the root of our repo, cd to the correct folder where sources/projects are
REM cd MyLibrary

REM Restore
call dotnet restore
if not "%errorlevel%"=="0" goto failure

REM Build
REM - Option 1: Run dotnet build for every source folder in the project
REM   e.g. call dotnet build <path> --configuration %config%
REM - Option 2: Let msbuild handle things and build the solution
REM "%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" MyLibrary.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
call dotnet build ConversioCore.sln --configuration %config%
if not "%errorlevel%"=="0" goto failure

REM Unit tests
REM TODO: Bring these back
REM call dotnet test test\ConversioCore.Test --configuration %config%
REM if not "%errorlevel%"=="0" goto failure

REM Package
mkdir %cd%\Artifacts
call dotnet pack src\ConversioCore\ConversioCore.csproj --configuration %config% %version% --output Artifacts
if not "%errorlevel%"=="0" goto failure

:success
exit 0

:failure
exit -1
