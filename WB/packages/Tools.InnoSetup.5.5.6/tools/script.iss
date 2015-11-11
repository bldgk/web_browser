; Имя приложения
#define   Name       "WebBrowser"
; Версия приложения
#define   Version    GetFileVersion("..\..\..\WebBrowserTest\bin\Release\WebBrowserTest.exe")
; Фирма-разработчик
#define   Publisher  "Kirill"
; Сафт фирмы разработчика
#define   URL        "http://kirill.beldyaga@gmail.com"
; Имя исполняемого модуля
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

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=..\..\..\test-setup\
OutputBaseFileName={#Name}-{#Version}

; Параметры сжатия
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "License_ENG.txt"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; LicenseFile: "License_RUS.txt"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Исполняемый файл
Source: "..\..\..\WebBrowserTest\bin\Release\WebBrowserTest.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "dotNetFx45_Full_setup.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

; Прилагающиеся ресурсы
Source: "..\..\..\WebBrowserTest\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Code]
function IsDotNetDetected(version: string; release: cardinal): boolean;
var 
    reg_key: string; // Просматриваемый подраздел системного реестра
    success: boolean; // Флаг наличия запрашиваемой версии .NET
    release45: cardinal; // Номер релиза для версии 4.5.x
    key_value: cardinal; // Прочитанное из реестра значение ключа
    sub_key: string;

begin
    success := false;
    reg_key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\';

     // Вресия 4.5
     if Pos('v4.5', version) = 1 then
      begin
          sub_key := 'v4.5\Full';
          reg_key := reg_key + sub_key;
          success := RegQueryDWordValue(HKLM, reg_key, 'Release', release45);
          success := success and (release45 >= release);
      end;
        
    result := success;

end;

function IsRequiredDotNetDetected(): boolean;
begin
    result := IsDotNetDetected('v4.5 Full Profile', 0);
end;

function InitializeSetup(): boolean;
begin

  // Если нет тербуемой версии .NET выводим сообщение о том, что инсталлятор
  // попытается установить её на данный компьютер
  if not IsDotNetDetected('v4.5 Full Profile', 0) then
    begin
      MsgBox('{#Name} requires Microsoft .NET Framework 4.5 Full Profile.'#13#13
             'The installer will attempt to install it', mbInformation, MB_OK);
    end;   

  result := true;
end;
[Run]
;------------------------------------------------------------------------------
;   Секция запуска после инсталляции
;------------------------------------------------------------------------------
Filename: {tmp}\dotNetFx45_Full_setup.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft Framework 4.5 is installed. Please wait...