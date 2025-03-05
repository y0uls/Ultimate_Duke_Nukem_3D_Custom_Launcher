#define MyAppName "Ultimate Duke Nukem 3D Custom"
#define MyAppVersion "3.0"
#define MyAppPublisher "Y0uls"
#define MyAppExeName "Ultimate Duke Nukem 3D Custom.exe"

[Setup]
AppId={{607C781D-E9BE-4203-AE25-9EFFB22933D9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DisableDirPage=yes
DisableWelcomePage=no
UserInfoPage=no
DisableProgramGroupPage=yes
OutputDir=C:\Inno Setup Output\UDNC
OutputBaseFilename=UltimateDukeNukemInstaller
WizardImageFile=DukeNukem3D.bmp
SetupIconFile=duke.ico
UninstallDisplayIcon={app}\Ultimate Duke Nukem 3D Custom.exe
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "fr"; MessagesFile: "compiler:Languages\French.isl"

[CustomMessages]
fr.SelectFileCaption=Sélectionnez le fichier DUKE3D.GRP (fichier de données Duke Nukem 3D)
english.SelectFileCaption=Select the DUKE3D.GRP file (Duke Nukem 3D data file)
fr.InfoLabelCaption=Si vous possédez le jeu sur Steam, le fichier est dans :
english.InfoLabelCaption=If you own the game on Steam, you can get the file from:
fr.BrowseButtonCaption=Parcourir
english.BrowseButtonCaption=Browse
fr.SelectFileError=Veuillez sélectionner le fichier DUKE3D.GRP avant de continuer.
english.SelectFileError=Please select the DUKE3D.GRP file before proceeding.
fr.ErrorZipExtract=Erreur lors de la décompression du fichier ZIP
english.ErrorZipExtract=Error unzipping ZIP file

[Dirs]
Name: "{app}"; Permissions: users-full

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "readme"; Description: "Read Me"; GroupDescription: "Options"; Flags: unchecked

[Files]
Source: "Ultimate Duke Nukem 3D Custom.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{tmp}\UltimateDukeNukem3DCustom.zip"; DestDir: "{app}"; Flags: external ignoreversion deleteafterinstall; AfterInstall: DecompressAndDeleteZip
Source: {code:GetMyFile}; DestDir: "{app}"; Flags: external

[Icons]
Name: "{autodesktop}\Ultimate Duke Nukem 3D Custom"; Filename:"{app}\{#MyAppExeName}"; IconFilename:"{app}\Ultimate Duke Nukem 3D Custom.exe"; Tasks: desktopicon;

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Ultimate Duke Nukem 3D Custom"; Flags: shellexec postinstall runhidden
Filename: "{app}\ReadMe.txt"; Description: "Read Me"; Flags: postinstall shellexec skipifsilent; Tasks: readme

[UninstallDelete]
Type: files; Name: "{app}\*.*"
Type: filesandordirs; Name: "{app}"

[Code]
var
  DownloadPage: TDownloadWizardPage;
  PageSelectFile: TWizardPage;
  InfoLabel: TLabel;
  FilenameEdit: TEdit;
  BrowseButton: TButton;
  Filename: String;
  
function OnDownloadProgress(const Url, FileName: String; const Progress, ProgressMax: Int64): Boolean;
begin
  if Progress = ProgressMax then
    Log(Format('Successfully downloaded file to {tmp}: %s', [FileName]));
  Result := True;
end;
  
procedure DecompressAndDeleteZip;
var
  ShellApp: Variant;
  ZipFilePath, ExtractPath: string;
begin
  ZipFilePath := ExpandConstant('{tmp}\UltimateDukeNukem3DCustom.zip');
  ExtractPath := ExpandConstant('{app}');
  
  try
    ShellApp := CreateOleObject('Shell.Application');
  except
    Exit;
  end;

  if VarIsNull(ShellApp) then
  begin
    Exit;
  end;

  if not FileExists(ZipFilePath) then
  begin
    Exit;
  end;

  try
    ShellApp.NameSpace(ExtractPath).CopyHere(ShellApp.NameSpace(ZipFilePath).Items, 16);
    DeleteFile(ZipFilePath);
  except
    MsgBox(ExpandConstant('{cm:ErrorZipExtract}'), mbError, MB_OK);
  end;
end;

procedure BrowseButtonClick(Sender: TObject);
begin
  if GetOpenFileName('', Filename, '',
     'DUKE3D File (*.grp)|*.grp', 'grp') then
  begin
    FilenameEdit.Text := Filename;
  end;
end;

procedure CreateTheWizardPages;
begin
  PageSelectFile := CreateCustomPage(wpSelectDir,
                ExpandConstant('{cm:SelectFileCaption}'),
                '');

  InfoLabel := TLabel.Create(PageSelectFile);
  InfoLabel.Parent := PageSelectFile.Surface;
  InfoLabel.Caption := ExpandConstant('{cm:InfoLabelCaption}') + #13#10#13#10 + '"C:\Program Files (x86)\Steam\steamapps\common\Duke Nukem 3D..."';
  InfoLabel.Left := 10;
  InfoLabel.Top := 10;
  InfoLabel.Width := PageSelectFile.SurfaceWidth - 20;
  
  FilenameEdit := TEdit.Create(PageSelectFile);
  FilenameEdit.Parent := PageSelectFile.Surface;
  FilenameEdit.Left := 10;
  FilenameEdit.Top := InfoLabel.Top + InfoLabel.Height + 10;
  FilenameEdit.Width := PageSelectFile.SurfaceWidth - 80;

  BrowseButton := TButton.Create(PageSelectFile);
  BrowseButton.Parent := PageSelectFile.Surface;
  BrowseButton.Caption := ExpandConstant('{cm:BrowseButtonCaption}');
  BrowseButton.Left := FilenameEdit.Left;
  BrowseButton.Top := FilenameEdit.Top + FilenameEdit.Height + 10;
  BrowseButton.OnClick := @BrowseButtonClick;
end;

function GetMyFile(Param: String): String;
begin
  Result := Filename;
end;

procedure CopyFileToInstallDirs;
var
  DestDir1, DestDir2, DestDir3, DestDir4, DestDir5: String;
begin
  if Filename <> '' then
  begin
    DestDir1 := ExpandConstant('{app}\CustomDuke');
    DestDir2 := ExpandConstant('{app}\CustomDuke\mods\Alien Armageddon 564');
    DestDir3 := ExpandConstant('{app}\CustomDuke\mods\Duke Nukem 3D - Legacy Edition');
    DestDir4 := ExpandConstant('{app}\CustomDuke\mods\Imperium 2011');
    DestDir5 := ExpandConstant('{app}\CustomDuke\mods\WGMEGA - DukePlus');
    
    if not DirExists(DestDir1) then
    begin
      if not ForceDirectories(DestDir1) then
      begin
        Exit;
      end;
    end;

    if not FileCopy(Filename, DestDir1 + '\' + ExtractFileName(Filename), False) then
    begin
      Exit;
    end;

    if not DirExists(DestDir2) then
    begin
      if not ForceDirectories(DestDir2) then
      begin
        Exit;
      end;
    end;

    if not FileCopy(Filename, DestDir2 + '\' + ExtractFileName(Filename), False) then
    begin
      Exit;
    end;
    
    if not DirExists(DestDir3) then
    begin
      if not ForceDirectories(DestDir3) then
      begin
        Exit;
      end;
    end;

    if not FileCopy(Filename, DestDir3 + '\' + ExtractFileName(Filename), False) then
    begin
      Exit;
    end;
    
    if not DirExists(DestDir4) then
    begin
      if not ForceDirectories(DestDir4) then
      begin
        Exit;
      end;
    end;

    if not FileCopy(Filename, DestDir4 + '\' + ExtractFileName(Filename), False) then
    begin
      Exit;
    end;
    
    if not DirExists(DestDir5) then
    begin
      if not ForceDirectories(DestDir5) then
      begin
        Exit;
      end;
    end;

    if not FileCopy(Filename, DestDir5 + '\' + ExtractFileName(Filename), False) then
    begin
      Exit;
    end;
  end;
end;

procedure InitializeWizard();
begin
  CreateTheWizardPages;
  DownloadPage := CreateDownloadPage(SetupMessage(msgWizardPreparing), SetupMessage(msgPreparingDesc), @OnDownloadProgress);
end;

function NextButtonClick(CurPageID: Integer): Boolean;
begin
  Result := True;
  if CurPageID = wpReady then
  begin
    DownloadPage.Clear;
    DownloadPage.Add('https://y0uls.com/UltimateDukeNukem3DCustom.zip', 'UltimateDukeNukem3DCustom.zip', '');
    DownloadPage.Show;
    try
      try
        DownloadPage.Download;
        Result := True;
      except
        if DownloadPage.AbortedByUser then
          Log('Aborted by user.')
        else
          SuppressibleMsgBox(AddPeriod(GetExceptionMessage), mbCriticalError, MB_OK, IDOK);
        Result := False;
      end;
    finally
      DownloadPage.Hide;
    end;
  end
  else if CurPageID = PageSelectFile.ID then
  begin
    if FilenameEdit.Text = '' then
    begin
      MsgBox(ExpandConstant('{cm:SelectFileError}'), mbError, MB_OK);
      Result := False;
    end
    else
    begin
      CopyFileToInstallDirs;
    end;
  end;
end;

procedure DeleteFileAtRoot;
var
  RootFile: String;
begin
  RootFile := ExpandConstant('{app}\' + ExtractFileName(Filename));
  if FileExists(RootFile) then
  begin
    if not DeleteFile(RootFile) then
    begin
      Exit;
    end
    else
    begin
      Exit;
    end;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    DecompressAndDeleteZip;
    DeleteFileAtRoot;
  end;
end;