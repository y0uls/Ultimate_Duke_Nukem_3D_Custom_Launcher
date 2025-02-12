@echo off
title - Ultimate Duke Nukem 3D Launcher By Y0uls -
color 2
chcp 65001 > nul
setlocal enabledelayedexpansion
cd %~dp0
set "arguments=%1"

set "wallpaper=%~dp0cover\background.jpg"
set "wallpaper=%wallpaper:\=\\%"
set "settingsFile=%LOCALAPPDATA%\\Packages\\Microsoft.WindowsTerminal_8wekyb3d8bbwe\\LocalState\\settings.json"
set "newSettingsFile=%LOCALAPPDATA%\\Packages\\Microsoft.WindowsTerminal_8wekyb3d8bbwe\\LocalState\\settings_old.json"
set "backupSettingsFile=%LOCALAPPDATA%\\Packages\\Microsoft.WindowsTerminal_8wekyb3d8bbwe\\LocalState\\settings_backup.json"

if exist "%settingsFile%" (
    copy "%settingsFile%" "%newSettingsFile%" > NUL
)

if not exist "%backupSettingsFile%" (
	copy "%settingsFile%" "%backupSettingsFile%" > NUL
)

echo { > %temp%\temp.json
echo     "profiles": { >> %temp%\temp.json
echo         "defaults": {}, >> %temp%\temp.json
echo         "list": [ >> %temp%\temp.json
echo             { >> %temp%\temp.json
echo                 "guid": "{0caa0dad-35be-5f56-a8ff-afceeeaa6101}", >> %temp%\temp.json
echo                 "name": "Command Prompt", >> %temp%\temp.json
echo                 "commandline": "cmd.exe", >> %temp%\temp.json
echo                 "fontSize": 14, >> %temp%\temp.json
echo                 "hidden": false, >> %temp%\temp.json
echo                 "experimental.retroTerminalEffect": true, >> %temp%\temp.json
echo                 "backgroundImage": "%wallpaper%", >> %temp%\temp.json
echo                 "backgroundImageOpacity": 0.5 >> %temp%\temp.json
echo             } >> %temp%\temp.json
echo         ] >> %temp%\temp.json
echo     } >> %temp%\temp.json
echo } >> %temp%\temp.json

powershell -Command "Get-Content %temp%\temp.json | Set-Content -Path %settingsFile%"

del %temp%\temp.json

if "%arguments%"=="--fullscreen" (
	copy /y "%~dp0fullscreen.cfg" "%~dp0eduke32.cfg" > NUL
	goto execute
)

if not "%arguments%"=="" (
	cls
	echo Command line options:
	echo.
	echo "Ultimate Duke Nukem 3D Custom By Y0uls.bat" --fullscreen
	echo.
	if exist "%newSettingsFile%" (
		del "%settingsFile%" > NUL
		rename "%newSettingsFile%" "settings.json" > NUL
	)
	endlocal
	exit /b
)

copy /y "%~dp0resize.cfg" "%~dp0eduke32.cfg" > NUL

:execute
set "mapsDir=%~dp0maps"
set "modsDir=%~dp0mods"

:startup
cls
set select=
echo - DUKE NUKE 3D LAUNCHER
echo.
echo 1. Choose a custom map
echo 2. Choose a custom mod
echo.
echo 3. Exit
echo.
set /p select=Type of game: 
if "%select%" == "1" goto maps
if "%select%" == "2" goto mods
if "%select%" == "3" goto end
if "%select%" == "" goto startup
goto startup

:maps
cls
set selectedFolder=
set choice=
set otherMaps=
set options=
set quit=
set letter=
echo - Filter list of Custom Maps:
echo.
set /p letter=Enter the starting letter to filter maps (or press Enter to show all): 
if "%letter%" == "" goto skipUpper
set "letter=%letter:"=%"
set "letter=%letter: =%"
set "letter=%letter:~0,1%%letter:~1%"
for %%i in (A B C D E F G H I J K L M N O P Q R S T U V W X Y Z) do (
    set "letter=!letter:%%i=%%i!"
)
:skipUpper
cls
echo - List of Custom Maps:
echo.
echo 0. Standard Version 

set /a count=0
for /d %%D in ("%mapsDir%\*") do (
    set "folderName=%%~nxD"
    if "!folderName:~0,1!"=="%letter%" (
        set /a count+=1
        set "folder[!count!]=%%D"
        echo !count!. %%~nxD
    ) else if "%letter%"=="" (
        set /a count+=1
        set "folder[!count!]=%%D"
        echo !count!. %%~nxD
    )
)
set /a otherMaps=%count%+1
set /a options=%otherMaps%+1
set /a quit=%options%+1
echo.
echo %otherMaps%. Choose another type of filter
echo %options%. Choose another type of game
echo %quit%. Exit
echo.
set /p choice="Enter the map number you want to use: "

if "%choice%"=="%otherMaps%" (
	goto maps
)
if "%choice%"=="%options%" (
	goto startup
)
if "%choice%"=="%quit%" (
	goto end
)
if "%choice%"=="0" (
	goto menu2
)
if defined folder[%choice%] (
	for %%I in ("!folder[%choice%]!") do set "selectedFolder=%%~nxI"
	goto menu2
) else (
    goto maps
)

:mods
cls
set selectedFolder=
set choice=
set otherMods=
set options=
set quit=
set letter=
echo - Filter list of Custom Mods:
echo.
set /p letter=Enter the starting letter to filter mods (or press Enter to show all): 
if "%letter%" == "" goto skipUpper2
set "letter=%letter:"=%"
set "letter=%letter: =%"
set "letter=%letter:~0,1%%letter:~1%"
for %%i in (A B C D E F G H I J K L M N O P Q R S T U V W X Y Z) do (
    set "letter=!letter:%%i=%%i!"
)
:skipUpper2
cls
echo - List of Custom Mods:
echo.
echo 0. Standard Version 

set /a count=0
for /d %%D in ("%modsDir%\*") do (
    set "folderName=%%~nxD"
    if "!folderName:~0,1!"=="%letter%" (
        set /a count+=1
        set "folder[!count!]=%%D"
        echo !count!. %%~nxD
    ) else if "%letter%"=="" (
        set /a count+=1
        set "folder[!count!]=%%D"
        echo !count!. %%~nxD
    )
)
set /a otherMods=%count%+1
set /a options=%otherMods%+1
set /a quit=%options%+1
echo.
echo %otherMods%. Choose another type of filter
echo %options%. Choose another type of game
echo %quit%. Exit
echo.
set /p choice="Enter the number of the mod you want to use: "

if "%choice%"=="%otherMods%" (
	goto mods
)
if "%choice%"=="%options%" (
	goto startup
)
if "%choice%"=="%quit%" (
	goto end
)
if "%choice%"=="0" (
	goto menu
)
if defined folder[%choice%] (
	for %%I in ("!folder[%choice%]!") do set "selectedFolder=%%~nxI"
	goto menu
) else (
    goto mods
)

:menu
cls
echo - CUSTOM GAME SELECTED: %selectedFolder%
set choose=
echo.
echo 1. Start solo mode
echo 2. Start server/multiplayer mode
echo.
echo 3. Choose another type of game
echo 4. Exit
echo.
set /p choose=Startup type: 
if "%choose%" == "1" (
    set mode=
    goto game
)
if "%choose%" == "2" (
    set "mode=-server"
    goto game
)
if "%choose%" == "3" goto startup
if "%choose%" == "4" goto end
if "%choose%" == "" goto menu
goto menu

:menu2
cls
echo - CUSTOM GAME SELECTED: %selectedFolder%
set choose=
echo.
echo 1. Start the game
echo.
echo 2. Choose another type of game
echo 3. Exit
echo.
set /p choose=Indicate your choice: 
if "%choose%" == "1" (
    set mode=
    goto game
)
if "%choose%" == "2" goto startup
if "%choose%" == "3" goto end
if "%choose%" == "" goto menu2
goto menu2

:game
if "%choice%"=="0" (
	start eduke32.exe %mode%
	goto end
)

set /a count=0
set "mapFile="

for %%f in ("!folder[%choice%]!\*.map" "!folder[%choice%]!\*.pk3" "!folder[%choice%]!\*.dat") do (
    set /a count+=1
    set "mapFile=%%~nxf"
)

if exist "!folder[%choice%]!\launcher.bat" (
	cd !folder[%choice%]!
	call "!folder[%choice%]!\launcher.bat"
	goto end

) else if exist "!folder[%choice%]!\eduke32.exe" (
	cd !folder[%choice%]!
	start eduke32.exe -j"!folder[%choice%]!" %mode% -usecwd
	goto end
)
	
if %count%==0 (
	start eduke32.exe -j"!folder[%choice%]!" %mode% -usecwd
	goto end
) else if %count%==1 (
    start eduke32.exe -j"!folder[%choice%]!" "%mapFile%" %mode% -usecwd
	goto end
) else (
    start eduke32.exe -j"!folder[%choice%]!" %mode% -usecwd
	goto end
)

:end
if exist "%newSettingsFile%" (
    del "%settingsFile%" > NUL
    rename "%newSettingsFile%" "settings.json" > NUL
)
endlocal
exit