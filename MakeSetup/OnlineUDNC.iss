#define MyAppName "Ultimate Duke Nukem 3D Custom"
#define MyAppVersion "6.0"
#define MyAppPublisher "Y0uls"
#define MyAppExeName "Ultimate Duke Nukem 3D Custom.exe"
#define UrlZipFile "https://y0uls.com/UltimateDukeNukem3DCustom.zip"

[Setup]
AppId={{607C781D-E9BE-4203-AE25-9EFFB22933D9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DisableDirPage=no
DisableWelcomePage=no
UserInfoPage=no
DisableProgramGroupPage=yes
OutputDir=C:\Inno Setup Output\UDNC
OutputBaseFilename=OnlineUltimateDukeNukemInstaller
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
fr.InfoLabelCaption=Vous devez posséder le jeu et sélectionner le fichier DUKE3D.GRP
english.InfoLabelCaption=You must have the game and select the DUKE3D.GRP file
fr.BrowseButtonCaption=Parcourir
english.BrowseButtonCaption=Browse
fr.SelectFileError=Veuillez sélectionner le fichier DUKE3D.GRP avant de continuer.
english.SelectFileError=Please select the DUKE3D.GRP file before proceeding.
fr.ErrorZipExtract=Erreur lors de la décompression du fichier ZIP
english.ErrorZipExtract=Error unzipping ZIP file
fr.CreateFileError=Erreur lors de la création du fichier
english.CreateFileError=Error creating file

[Dirs]
Name: "{app}"; Permissions: users-full

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "readme"; Description: "Read Me"; GroupDescription: "Options"; Flags: unchecked

[Files]
Source: "{tmp}\UltimateDukeNukem3DCustom.zip"; DestDir: "{app}"; Flags: external ignoreversion deleteafterinstall; AfterInstall: DecompressAndDeleteZip
Source: {code:GetMyFile}; DestDir: "{app}"; Flags: external

[Icons]
Name: "{autodesktop}\Ultimate Duke Nukem 3D Custom"; Filename:"{app}\{#MyAppExeName}"; IconFilename:"{app}\Ultimate Duke Nukem 3D Custom.exe"; Tasks: desktopicon;

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Ultimate Duke Nukem 3D Custom"; Flags: shellexec postinstall runhidden
Filename: "{app}\README.txt"; Description: "Read Me"; Flags: postinstall shellexec skipifsilent; Tasks: readme

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
  
const
  SteamFilePath = 'C:\Program Files (x86)\Steam\steamapps\common\Duke Nukem 3D Twentieth Anniversary World Tour\DUKE3D.GRP';

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
  InfoLabel.Caption := ExpandConstant('{cm:InfoLabelCaption}');
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
  
  if FileExists(SteamFilePath) then
  begin
    FilenameEdit.Text := SteamFilePath;
    Filename := SteamFilePath;
  end;
end;

function GetMyFile(Param: String): String;
begin
  Result := Filename;
end;

procedure CopyFileToInstallDirs;
var
  DestDir: String;
begin
  if Filename <> '' then
  begin
    DestDir := ExpandConstant('{app}\CustomDuke');
        
    if not DirExists(DestDir) then
    begin
      if not ForceDirectories(DestDir) then
      begin
        Exit;
      end;
    end;

    if not FileCopy(Filename, DestDir + '\' + ExtractFileName(Filename), False) then
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
    DownloadPage.Add('{#UrlZipFile}', 'UltimateDukeNukem3DCustom.zip', '');
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

procedure CreateJSONFile;
var
  JSONFile: TStringList;
  JSONContent: String;
  PathInstall: String;
begin
  PathInstall := ExpandConstant('{app}');
  StringChangeEx(PathInstall, '\', '\\', True);
  JSONContent := '{"Config":{"PathInstall":"'+PathInstall+'"},"Game":{"Difficulty":2,"ServerMode":0,"Fullscreen":0,"ExitAfterStart":0}}';
  JSONFile := TStringList.Create;
  try
    JSONFile.Text := JSONContent;
    JSONFile.SaveToFile(ExpandConstant('{app}\config.json'));
  except
    MsgBox(ExpandConstant('{cm:CreateFileError')+' config.json.', mbError, MB_OK);
  end;
  JSONFile.Free;
end;

procedure CreateREADMEFile;
var
  READMEFile: TStringList;
  READMEContent: String;
  Lang: String;
begin
  Lang := ExpandConstant('{language}');
  if Lang = 'fr' then
    READMEContent := 'Un immense merci à tous les contributeurs, créateur de map, communauté, développeur de mods et ainsi de suite, pour m''avoir permis la création de ce launcher, regroupant toutes les meilleures maps personnalisées de ce jeu emblématique, Duke Nukem 3D !'+ #13#10#13#10 +
  'Pour l''utiliser, lancez simplement "Ultimate Duke Nukem 3D Custom.exe" et choisissez l''option de lancement !'+ #13#10 +
  'Amusez-vous pendant de nombreuses heures !'+ #13#10#13#10 +
  'Il est possible d''ajouter une map personnalisée en exécutant "Ultimate Duke Nukem 3D Custom.exe", choisissez "Maps" dans la liste déroulante puis cliquez sur "Browse Folder".'+ #13#10#13#10 +
  'Une fois dans le dossier "Maps", créez un dossier avec le nom de la map et placez-y le fichier .map.'+ #13#10#13#10 +
  '!! Attention dans la section "Maps", les dossiers ne doivent contenir qu''1 seul fichier .map !!'+ #13#10 +
  'S''il y a plusieurs fichiers maps, faites la même manipulation mais dans la section "Mods"'
  else if Lang = 'english' then
    READMEContent := 'A huge thank you to all the contributors, map creator, community, mod developer and so on, for allowing me the creation of this launcher, bringing together all the best custom maps from this iconic game, Duke Nukem 3D!'+ #13#10#13#10 +
  'To use it, simply run the "Ultimate Duke Nukem 3D Custom.exe" and choose the launch options!'+ #13#10 +
  'Have fun for many hours!'+ #13#10#13#10 +
  'It is possible to add a custom map for example by running "Ultimate Duke Nukem 3D Custom.exe", choose "Maps" from the drop-down list then click on "Browse Folder".'+ #13#10 +
  'Once in the "Maps" folder, create a folder with the name of the map and place the .map file there.'+ #13#10#13#10 +
  '!! Be careful in the "Maps" section, the folders must contain only 1 .map file !!'+ #13#10 +
  'If there are several maps files, do the same manipulation but in the "Mods" section'
  else
    READMEContent := 'A huge thank you to all the contributors, map creator, community, mod developer and so on, for allowing me the creation of this launcher, bringing together all the best custom maps from this iconic game, Duke Nukem 3D!'+ #13#10#13#10 +
  'To use it, simply run the "Ultimate Duke Nukem 3D Custom.exe" and choose the launch options!'+ #13#10 +
  'Have fun for many hours!'+ #13#10#13#10 +
  'It is possible to add a custom map for example by running "Ultimate Duke Nukem 3D Custom.exe", choose "Maps" from the drop-down list then click on "Browse Folder".'+ #13#10 +
  'Once in the "Maps" folder, create a folder with the name of the map and place the .map file there.'+ #13#10#13#10 +
  '!! Be careful in the "Maps" section, the folders must contain only 1 .map file !!'+ #13#10 +
  'If there are several maps files, do the same manipulation but in the "Mods" section';
  READMEFile := TStringList.Create;
  try
    READMEFile.Text := READMEContent;
    READMEFile.SaveToFile(ExpandConstant('{app}\README.txt'));
  except
    MsgBox(ExpandConstant('{cm:CreateFileError')+' README.txt.', mbError, MB_OK);
  end;
  READMEFile.Free;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    CreateJSONFile;
    CreateREADMEFile;
    DecompressAndDeleteZip;
    DeleteFileAtRoot;
  end;
end;