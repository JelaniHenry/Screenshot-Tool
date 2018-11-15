
OutFile "Screenshot Tool Installer.exe"
 
InstallDir "$PROGRAMFILES\Screenshot Tool"

Section
 
SetOutPath $INSTDIR
 
File ..\ScreenshotForTesting\bin\Release\ScreenshotForTesting.exe
File ..\ScreenshotForTesting\bin\Release\ScreenshotForTesting.exe.config

CreateShortCut "$DESKTOP\Screenshot Tool.lnk" "$INSTDIR\ScreenshotForTesting.exe"

WriteUninstaller "$INSTDIR\Screenshot Tool Uninstaller.exe"

SectionEnd
 

Section "Uninstall"
 
Delete "$INSTDIR\Screenshot Tool Uninstaller.exe"
 
Delete $INSTDIR\ScreenshotForTesting.exe
Delete $INSTDIR\ScreenshotForTesting.exe.config
Delete "$DESKTOP\Screenshot Tool.lnk" 

RMDir $INSTDIR
 
SectionEnd