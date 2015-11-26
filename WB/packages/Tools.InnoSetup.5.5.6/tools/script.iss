#define   Name       "WebBrowser"
#define   Version    GetFileVersion("..\..\..\WebBrowserTest\bin\Release\WebBrowserTest.exe")
#define   Publisher  "Kirill"
#define   URL        "http://kirill.beldyaga@gmail.com"
#define   ExeName    "WebBrowser.exe"

#define ver=80

[Setup]
AppId={{88D8C527-ED86-4304-93C7-84CC759A4B13}

AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

DefaultDirName={pf}\{#Name}
DefaultGroupName={#Name}

OutputDir=..\..\..\test-setup\
OutputBaseFileName={#Name}-{#Version}

Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "License_ENG.txt"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; LicenseFile: "License_RUS.txt"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\..\..\WebBrowserTest\bin\Release\WebBrowserTest.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\..\WebBrowserTest\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

