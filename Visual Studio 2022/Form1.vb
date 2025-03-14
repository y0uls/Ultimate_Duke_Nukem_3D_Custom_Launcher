Imports System.IO
Imports System.Net
Imports System.IO.Compression
Imports HtmlAgilityPack
Imports System.Web.Script.Serialization
Imports System.Security.Policy
Imports System.Web
Public Class Form1
    Private difficulty As String
    Private serverMode As String
    Private fullscreen As String
    Private exitAfterStart As String
    Private installDir As String
    Private mapsDir As String
    Private modsDir As String
    Private eduke32Path As String
    Private fullscreenFile As String
    Private grpFile As String
    Private urlMods As String = "https://y0uls.com/downloads/mods"
    Private urlMaps As String = "https://y0uls.com/downloads/maps"


    Private WithEvents client As New WebClient()
    Private WithEvents client2 As New WebClient()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim config As Configuration = LoadConfiguration()

        difficulty = config.Game.Difficulty
        serverMode = config.Game.ServerMode
        fullscreen = config.Game.Fullscreen
        exitAfterStart = config.Game.ExitAfterStart
        installDir = config.Config.PathInstall
        mapsDir = installDir + "\CustomDuke\maps"
        modsDir = installDir + "\CustomDuke\mods"
        eduke32Path = installDir + "\CustomDuke\eduke32.exe"
        fullscreenFile = installDir + "\CustomDuke\fullscreen.cfg"
        grpFile = installDir + "\CustomDuke\DUKE3D.GRP"

        If Not Directory.Exists(modsDir) Then
            Directory.CreateDirectory(modsDir)
        End If

        If Not Directory.Exists(mapsDir) Then
            Directory.CreateDirectory(mapsDir)
        End If

        If serverMode = 1 Then
            CheckBox1.Checked = True
        End If

        If fullscreen = 1 Then
            CheckBox2.Checked = True
        End If

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ComboBox1.Items.Add("Maps")
        ComboBox1.Items.Add("Mods")
        ComboBox1.SelectedIndex = -1
        For i As Integer = Asc("A"c) To Asc("Z"c)
            ComboBoxFilter.Items.Add(Chr(i))
            ComboBoxFilterMods.Items.Add(Chr(i))
            ComboBoxFilterMaps.Items.Add(Chr(i))
        Next
        ComboBoxFilter.Items.Add("All")
        ComboBoxFilter.SelectedIndex = ComboBoxFilter.Items.Count - 1
        ComboBoxFilterMods.Items.Add("All")
        ComboBoxFilterMods.SelectedIndex = ComboBoxFilterMods.Items.Count - 1
        ComboBoxFilterMaps.Items.Add("All")
        ComboBoxFilterMaps.SelectedIndex = ComboBoxFilterMaps.Items.Count - 1

        'Mods DL
        Dim files As String() = Directory.GetFiles(modsDir)
        For Each file As String In files
            Dim fileName As String = Path.GetFileNameWithoutExtension(file)
            If Not ListBoxTelecharges.Items.Contains(fileName) Then
                ListBoxNonTelecharges.Items.Remove(fileName)
            End If
        Next

        Dim directories As String() = Directory.GetDirectories(modsDir)
        For Each dir As String In directories
            Dim dirName As String = Path.GetFileName(dir)
            If Not ListBoxTelecharges.Items.Contains(dirName) Then
                ListBoxNonTelecharges.Items.Remove(dirName)
            End If
        Next

        Dim web As New HtmlWeb()
        Dim doc As HtmlDocument = web.Load(urlMods)
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//a[@href]")
        If nodes IsNot Nothing Then
            For Each node As HtmlNode In nodes
                Dim href As String = node.GetAttributeValue("href", String.Empty)
                href = href.Replace("%20", " ")
                If href.EndsWith(".zip") Then
                    Dim fileName As String = Path.GetFileNameWithoutExtension(href)
                    If Not ListBoxNonTelecharges.Items.Contains(fileName) Then
                        ListBoxTelecharges.Items.Add(fileName)
                    End If
                End If
            Next
        Else
            MessageBox.Show("No files found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'Maps DL

        Dim filesMaps As String() = Directory.GetFiles(mapsDir)
        For Each fileM As String In filesMaps
            Dim fileNameM As String = Path.GetFileNameWithoutExtension(fileM)
            If Not ListBoxTelechargesMaps.Items.Contains(fileNameM) Then
                ListBoxNonTelechargesMaps.Items.Remove(fileNameM)
            End If
        Next

        Dim directoriesMaps As String() = Directory.GetDirectories(mapsDir)
        For Each dirM As String In directoriesMaps
            Dim dirNameM As String = Path.GetFileName(dirM)
            If Not ListBoxTelechargesMaps.Items.Contains(dirNameM) Then
                ListBoxNonTelechargesMaps.Items.Remove(dirNameM)
            End If
        Next

        Dim webMaps As New HtmlWeb()
        Dim docMaps As HtmlDocument = webMaps.Load(urlMaps)
        Dim nodesMaps As HtmlNodeCollection = docMaps.DocumentNode.SelectNodes("//a[@href]")
        If nodesMaps IsNot Nothing Then
            For Each nodeM As HtmlNode In nodesMaps
                Dim hrefM As String = nodeM.GetAttributeValue("href", String.Empty)
                hrefM = hrefM.Replace("%20", " ")
                If hrefM.EndsWith(".zip") Then
                    Dim fileNameM As String = Path.GetFileNameWithoutExtension(hrefM)
                    If Not ListBoxNonTelechargesMaps.Items.Contains(fileNameM) Then
                        ListBoxTelechargesMaps.Items.Add(fileNameM)
                    End If
                End If
            Next
        Else
            MessageBox.Show("No files found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                LoadMaps()
            Case 1
                LoadMods()
        End Select
    End Sub

    Private Sub LoadMaps()
        ListBox1.Items.Clear()
        If IO.Directory.Exists(mapsDir) Then
            Dim folders = IO.Directory.GetDirectories(mapsDir)
            For Each folder In folders
                ListBox1.Items.Add(IO.Path.GetFileName(folder))
            Next
        Else
            MessageBox.Show("Maps directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LoadMods()
        ListBox1.Items.Clear()
        If IO.Directory.Exists(modsDir) Then
            Dim folders = IO.Directory.GetDirectories(modsDir)
            For Each folder In folders
                ListBox1.Items.Add(IO.Path.GetFileName(folder))
            Next
        Else
            MessageBox.Show("Mods directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ComboBoxFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFilter.SelectedIndexChanged
        FilterList()
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterList()
    End Sub

    Private Sub ComboBoxFilterMods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFilterMods.SelectedIndexChanged
        FilterListMods()
    End Sub

    Private Sub ComboBoxFilterMaps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFilterMaps.SelectedIndexChanged
        FilterListMaps()
    End Sub

    Private Sub FilterList()
        If ComboBox1.SelectedIndex = -1 Then
            Return
        End If

        Dim searchText As String = TextBox1.Text.ToLower()
        Dim filterLetter As String = If(ComboBoxFilter.SelectedItem.ToString() = "All", "", ComboBoxFilter.SelectedItem.ToString().ToLower())
        Dim items As List(Of String) = If(ComboBox1.SelectedIndex = 0, GetMapItems(), GetModItems())
        ListBox1.Items.Clear()
        For Each item In items
            If item.ToLower().Contains(searchText) AndAlso (filterLetter = "" OrElse item.ToLower().StartsWith(filterLetter)) Then
                ListBox1.Items.Add(item)
            End If
        Next
    End Sub

    Private Sub FilterListMods()
        Dim filterLetterMO As String = If(ComboBoxFilterMods.SelectedItem.ToString() = "All", "", ComboBoxFilterMods.SelectedItem.ToString().ToLower())
        Dim itemsMO As List(Of String) = GetModItemsFromWeb()
        ListBoxNonTelecharges.Items.Clear()
        For Each itemM In itemsMO
            If filterLetterMO = "" OrElse itemM.ToLower().StartsWith(filterLetterMO) Then
                ListBoxNonTelecharges.Items.Add(itemM)
            End If
        Next
    End Sub

    Private Sub FilterListMaps()
        Dim filterLetterMA As String = If(ComboBoxFilterMaps.SelectedItem.ToString() = "All", "", ComboBoxFilterMaps.SelectedItem.ToString().ToLower())
        Dim itemsMA As List(Of String) = GetMapItemsFromWeb()
            ListBoxNonTelechargesMaps.Items.Clear()
        For Each itemM In itemsMA
            If filterLetterMA = "" OrElse itemM.ToLower().StartsWith(filterLetterMA) Then
                ListBoxNonTelechargesMaps.Items.Add(itemM)
            End If
        Next
    End Sub

    Private Function GetModItemsFromWeb() As List(Of String)
        Dim itemsMO As New List(Of String)
        Dim webMO As New HtmlWeb()
        Dim docMO As HtmlDocument = webMO.Load(urlMods)
        Dim nodesMO As HtmlNodeCollection = docMO.DocumentNode.SelectNodes("//a[@href]")
        If nodesMO IsNot Nothing Then
            For Each nodeMO As HtmlNode In nodesMO
                Dim hrefMO As String = nodeMO.GetAttributeValue("href", String.Empty)
                hrefMO = hrefMO.Replace("%20", " ")
                If hrefMO.EndsWith(".zip") Then
                    Dim fileNameMO As String = Path.GetFileNameWithoutExtension(hrefMO)
                    itemsMO.Add(fileNameMO)
                End If
            Next
        Else
            MessageBox.Show("No files found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return itemsMO
    End Function

    Private Function GetMapItemsFromWeb() As List(Of String)
        Dim itemsMA As New List(Of String)
        Dim webMA As New HtmlWeb()
        Dim docMA As HtmlDocument = webMA.Load(urlMaps)
        Dim nodesMA As HtmlNodeCollection = docMA.DocumentNode.SelectNodes("//a[@href]")
        If nodesMA IsNot Nothing Then
            For Each nodeMA As HtmlNode In nodesMA
                Dim hrefMA As String = nodeMA.GetAttributeValue("href", String.Empty)
                hrefMA = hrefMA.Replace("%20", " ")
                If hrefMA.EndsWith(".zip") Then
                    Dim fileNameMA As String = Path.GetFileNameWithoutExtension(hrefMA)
                    itemsMA.Add(fileNameMA)
                End If
            Next
        Else
            MessageBox.Show("No files found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return itemsMA
    End Function

    Private Function GetMapItems() As List(Of String)
        Dim items As New List(Of String)
        If IO.Directory.Exists(mapsDir) Then
            Dim folders = IO.Directory.GetDirectories(mapsDir)
            For Each folder In folders
                items.Add(IO.Path.GetFileName(folder))
            Next
        End If
        Return items
    End Function

    Private Function GetModItems() As List(Of String)
        Dim items As New List(Of String)
        If IO.Directory.Exists(modsDir) Then
            Dim folders = IO.Directory.GetDirectories(modsDir)
            For Each folder In folders
                items.Add(IO.Path.GetFileName(folder))
            Next
        End If
        Return items
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedItem IsNot Nothing Then
            Dim selectedFolder As String = ListBox1.SelectedItem.ToString()
            If ComboBox1.SelectedIndex = 0 Then
                StartGameWithMap(selectedFolder)
            ElseIf ComboBox1.SelectedIndex = 1 Then
                StartGameWithMod(selectedFolder)
            End If
        Else
            MessageBox.Show("Please select a map or mod.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub StartGameWithMap(selectedFolder As String)
        Dim fullPath As String = IO.Path.Combine(mapsDir, selectedFolder)
        Dim mode As String = If(CheckBox1.Checked, "-server", String.Empty)
        Dim specificFile As String = If(CheckBox2.Checked, $"-cfg ""{fullscreenFile}""", String.Empty)
        If IO.Directory.Exists(fullPath) Then
            Dim mapFiles = IO.Directory.GetFiles(fullPath, "*.map").ToArray()
            Dim count As Integer = mapFiles.Length

            If count = 0 Then
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" {mode} {specificFile} -usecwd -s{difficulty}") With {.WorkingDirectory = installDir + "\CustomDuke"})
            ElseIf count = 1 Then
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" ""{IO.Path.GetFileName(mapFiles(0))}"" {mode} {specificFile} -usecwd -s{difficulty}") With {.WorkingDirectory = installDir + "\CustomDuke"})
            Else
                Dim mapFile As String = ChooseMap(mapFiles)
                If Not String.IsNullOrEmpty(mapFile) Then
                    Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" ""{IO.Path.GetFileName(mapFile)}"" {mode} {specificFile} -usecwd -s{difficulty}") With {.WorkingDirectory = installDir + "\CustomDuke"})
                End If
            End If
        Else
            MessageBox.Show("Selected map folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If exitAfterStart = 1 Then
            Me.Close()
        End If
    End Sub

    Private Function ChooseMap(mapFiles As String()) As String
        Dim mapChoiceForm As New Form With {
            .Text = "Choose a Map",
            .Size = New Size(300, 200)
        }
        Dim listBox As New ListBox With {
            .Dock = DockStyle.Fill,
            .SelectionMode = SelectionMode.One
        }
        listBox.Items.AddRange(mapFiles)
        mapChoiceForm.Controls.Add(listBox)
        Dim result As DialogResult = mapChoiceForm.ShowDialog()
        If result = DialogResult.OK AndAlso listBox.SelectedItem IsNot Nothing Then
            Return listBox.SelectedItem.ToString()
        End If
        Return String.Empty
    End Function

    Private Sub StartGameWithMod(selectedFolder As String)
        Dim fullPath As String = IO.Path.Combine(modsDir, selectedFolder)
        Dim mode As String = If(CheckBox1.Checked, "-server", String.Empty)
        Dim specificFile As String = If(CheckBox2.Checked, $"-cfg ""{fullscreenFile}""", String.Empty)


        If IO.Directory.Exists(fullPath) Then
            Dim modFiles = IO.Directory.GetFiles(fullPath, "*.pk3").Concat(IO.Directory.GetFiles(fullPath, "*.dat")).ToArray()
            Dim count As Integer = modFiles.Length

            If count = 1 Then
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" ""{IO.Path.GetFileName(modFiles(0))}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = installDir + "\CustomDuke"})



            ElseIf IO.File.Exists(IO.Path.Combine(fullPath, "launcher.bat")) Then
                Process.Start(New ProcessStartInfo(IO.Path.Combine(fullPath, "launcher.bat"), $"--grp ""{grpFile}"" {mode} -usecwd") With {.WorkingDirectory = fullPath})
            ElseIf IO.File.Exists(IO.Path.Combine(fullPath, "eduke32.exe")) Then
                Process.Start(New ProcessStartInfo(IO.Path.Combine(fullPath, "eduke32.exe"), $"-j""{fullPath}"" --grp ""{grpFile}"" {mode} -usecwd") With {.WorkingDirectory = fullPath})
            Else
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = installDir + "\CustomDuke"})
            End If
        Else
            MessageBox.Show("Selected mod folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If exitAfterStart = 1 Then
            Me.Close()
        End If
    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ' Code pour gérer l'événement CheckBox1_CheckedChanged
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ' Code pour gérer l'événement CheckBox2_CheckedChanged
    End Sub

    Private Sub ButtonOpenFolder_Click(sender As Object, e As EventArgs) Handles ButtonOpenFolder.Click
        Dim selectedFolder As String = String.Empty

        If ComboBox1.SelectedIndex = 0 Then
            selectedFolder = mapsDir
        ElseIf ComboBox1.SelectedIndex = 1 Then
            selectedFolder = modsDir
        End If

        If Not String.IsNullOrEmpty(selectedFolder) AndAlso IO.Directory.Exists(selectedFolder) Then
            Process.Start("explorer.exe", selectedFolder)
        Else
            MessageBox.Show("Please select a valid option from the type of game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonConfig_Click(sender As Object, e As EventArgs) Handles ButtonConfig.Click
        Dim configFilePath As String = "config.json"
        If File.Exists(configFilePath) Then
            Process.Start(configFilePath)
            Dim result As DialogResult = MessageBox.Show("The application needs to restart after modification." & Environment.NewLine & "Are you sure you want to close the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Me.Close()
            End If
        Else
            MessageBox.Show("config.json not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonTelecharger_Click(sender As Object, e As EventArgs) Handles ButtonTelecharger.Click
        If ListBoxNonTelecharges.SelectedItem IsNot Nothing Then
            Dim selectedFile As String = ListBoxNonTelecharges.SelectedItem.ToString() & ".zip"
            Dim url As String = "https://y0uls.com/downloads/mods/" & selectedFile
            Dim filePath As String = Path.Combine(modsDir, selectedFile)

            If Not Directory.Exists(modsDir) Then
                Directory.CreateDirectory(modsDir)
            End If

            ProgressBar1.Value = 0
            client.DownloadFileAsync(New Uri(url), filePath)
        Else
            MessageBox.Show("Please select an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonTelechargerMaps_Click(sender As Object, e As EventArgs) Handles ButtonTelechargerMaps.Click
        If ListBoxNonTelechargesMaps.SelectedItem IsNot Nothing Then
            Dim selectedFileMAP As String = ListBoxNonTelechargesMaps.SelectedItem.ToString() & ".zip"
            Dim urlMAP As String = "https://y0uls.com/downloads/maps/" & selectedFileMAP
            Dim filePathMAP As String = Path.Combine(mapsDir, selectedFileMAP)

            If Not Directory.Exists(mapsDir) Then
                Directory.CreateDirectory(mapsDir)
            End If

            ProgressBar2.Value = 0
            client2.DownloadFileAsync(New Uri(urlMAP), filePathMAP)
        Else
            MessageBox.Show("Please select an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles client.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label4.Text = e.ProgressPercentage & "%"
    End Sub

    Private Sub client2_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles client2.DownloadProgressChanged
        ProgressBar2.Value = e.ProgressPercentage
        Label5.Text = e.ProgressPercentage & "%"
    End Sub

    Private Sub client_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles client.DownloadFileCompleted
        Dim selectedFile As String = ListBoxNonTelecharges.SelectedItem.ToString() & ".zip"
        Dim filePath As String = Path.Combine(modsDir, selectedFile)

        Try
            Dim extractPath As String = Path.Combine(modsDir, Path.GetFileNameWithoutExtension(selectedFile))
            ZipFile.ExtractToDirectory(filePath, extractPath)
            File.Delete(filePath)
            ListBox1.Items.Remove(Path.GetFileNameWithoutExtension(selectedFile))
            ListBoxTelecharges.Items.Remove(Path.GetFileNameWithoutExtension(selectedFile))
            ListBoxNonTelecharges.Items.Remove(Path.GetFileNameWithoutExtension(selectedFile))
            RescanFiles()
            If Not ListBoxTelecharges.Items.Contains(Path.GetFileNameWithoutExtension(selectedFile)) Then
                ListBoxTelecharges.Items.Add(Path.GetFileNameWithoutExtension(selectedFile))
            End If
            MessageBox.Show(Path.GetFileNameWithoutExtension(selectedFile) & " downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar1.Value = 0
            Label4.Text = ""
            RescanFiles()
        Catch ex As Exception
            MessageBox.Show("Error while downloading : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub client2_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles client2.DownloadFileCompleted
        Dim selectedFileMAP As String = ListBoxNonTelechargesMaps.SelectedItem.ToString() & ".zip"
        Dim filePathMAP As String = Path.Combine(mapsDir, selectedFileMAP)

        Try
            Dim extractPathMAP As String = Path.Combine(mapsDir, Path.GetFileNameWithoutExtension(selectedFileMAP))
            ZipFile.ExtractToDirectory(filePathMAP, extractPathMAP)
            File.Delete(filePathMAP)
            ListBox1.Items.Remove(Path.GetFileNameWithoutExtension(selectedFileMAP))
            ListBoxTelechargesMaps.Items.Remove(Path.GetFileNameWithoutExtension(selectedFileMAP))
            ListBoxNonTelechargesMaps.Items.Remove(Path.GetFileNameWithoutExtension(selectedFileMAP))
            RescanFiles2()
            If Not ListBoxTelechargesMaps.Items.Contains(Path.GetFileNameWithoutExtension(selectedFileMAP)) Then
                ListBoxTelechargesMaps.Items.Add(Path.GetFileNameWithoutExtension(selectedFileMAP))
            End If
            MessageBox.Show(Path.GetFileNameWithoutExtension(selectedFileMAP) & " downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar2.Value = 0
            Label5.Text = ""
            RescanFiles2()
        Catch ex As Exception
            MessageBox.Show("Error while downloading : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDesinstaller_Click(sender As Object, e As EventArgs) Handles ButtonDesinstaller.Click
        If ListBoxTelecharges.SelectedItem IsNot Nothing Then
            Dim selectedFile As String = ListBoxTelecharges.SelectedItem.ToString()
            Dim extractPath As String = Path.Combine(modsDir, selectedFile)

            If Directory.Exists(extractPath) Then
                Directory.Delete(extractPath, True)
                MessageBox.Show(Path.GetFileNameWithoutExtension(selectedFile) & " uninstalled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("The option is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ListBox1.Items.Remove(selectedFile)
            ListBoxTelecharges.Items.Remove(selectedFile)
            ListBoxNonTelecharges.Items.Add(selectedFile)
            RescanFiles()
        Else
            MessageBox.Show("Please select an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonDesinstallerMaps_Click(sender As Object, e As EventArgs) Handles ButtonDesinstallerMaps.Click
        If ListBoxTelechargesMaps.SelectedItem IsNot Nothing Then
            Dim selectedFileMAP As String = ListBoxTelechargesMaps.SelectedItem.ToString()
            Dim extractPathMAP As String = Path.Combine(mapsDir, selectedFileMAP)

            If Directory.Exists(extractPathMAP) Then
                Directory.Delete(extractPathMAP, True)
                MessageBox.Show(Path.GetFileNameWithoutExtension(selectedFileMAP) & " uninstalled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("The option is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ListBox1.Items.Remove(selectedFileMAP)
            ListBoxTelechargesMaps.Items.Remove(selectedFileMAP)
            ListBoxNonTelechargesMaps.Items.Add(selectedFileMAP)
            RescanFiles2()
        Else
            MessageBox.Show("Please select an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RescanFiles()
        ListBoxNonTelecharges.Items.Clear()
        ListBox1.Items.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBoxFilterMods.SelectedIndex = ComboBoxFilterMods.Items.Count - 1
        Dim web As New HtmlWeb()
        Dim doc As HtmlDocument = web.Load(urlMods)
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//a[@href]")

        If nodes IsNot Nothing Then
            For Each node As HtmlNode In nodes
                Dim href As String = node.GetAttributeValue("href", String.Empty)
                href = href.Replace("%20", " ")
                If href.EndsWith(".zip") Then
                    Dim fileName As String = Path.GetFileNameWithoutExtension(href)
                    If Not ListBoxTelecharges.Items.Contains(fileName) Then
                        ListBoxNonTelecharges.Items.Add(fileName)
                    End If
                End If
            Next
        Else
            MessageBox.Show("No files found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RescanFiles2()
        ListBoxNonTelechargesMaps.Items.Clear()
        ListBox1.Items.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBoxFilterMaps.SelectedIndex = ComboBoxFilterMaps.Items.Count - 1
        Dim webM As New HtmlWeb()
        Dim docM As HtmlDocument = webM.Load(urlMaps)
        Dim nodesM As HtmlNodeCollection = docM.DocumentNode.SelectNodes("//a[@href]")

        If nodesM IsNot Nothing Then
            For Each nodeM As HtmlNode In nodesM
                Dim hrefM As String = nodeM.GetAttributeValue("href", String.Empty)
                hrefM = hrefM.Replace("%20", " ")
                If hrefM.EndsWith(".zip") Then
                    Dim fileNameM As String = Path.GetFileNameWithoutExtension(hrefM)
                    If Not ListBoxTelechargesMaps.Items.Contains(fileNameM) Then
                        ListBoxNonTelechargesMaps.Items.Add(fileNameM)
                    End If
                End If
            Next
        Else
            MessageBox.Show("No files found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class

Module Module1
    Sub Main()
        Dim config As Configuration = LoadConfiguration()
        Dim pathInstall As String = config.Config.PathInstall
        Dim difficulty As Integer = config.Game.Difficulty
        Dim serverMode As Integer = config.Game.ServerMode
        Dim fullscreen As Integer = config.Game.Fullscreen
        Dim exitAfterStart As Integer = config.Game.ExitAfterStart
    End Sub

    Function LoadConfiguration() As Configuration
        Dim configFilePath As String = "config.json"
        Dim config As Configuration
        Dim appDirectory As String = Application.StartupPath

        If File.Exists(configFilePath) Then
            Dim json As String = File.ReadAllText(configFilePath)
            Dim serializer As New JavaScriptSerializer()
            config = serializer.Deserialize(Of Configuration)(json)

            If config.Config Is Nothing Then
                config.Config = New Config()
            End If
            If String.IsNullOrEmpty(config.Config.PathInstall) Then
                config.Config.PathInstall = $"{appDirectory}"
            End If

            If config.Game Is Nothing Then
                config.Game = New Game()
            End If
            If config.Game.Difficulty = 0 Then
                config.Game.Difficulty = 2
            End If
            If config.Game.ServerMode = 0 Then
                config.Game.ServerMode = 0
            End If
            If config.Game.Fullscreen = 0 Then
                config.Game.Fullscreen = 0
            End If
            If config.Game.ExitAfterStart = 0 Then
                config.Game.ExitAfterStart = 0
            End If
        Else
            config = New Configuration With {
                .Config = New Config With {
                    .PathInstall = $"{appDirectory}"
                },
                .Game = New Game With {
                    .Difficulty = 2,
                    .ServerMode = 0,
                    .Fullscreen = 0,
                    .ExitAfterStart = 0
                }
            }
            WriteDefaultConfiguration(configFilePath, config)
        End If

        Return config
    End Function

    Sub WriteDefaultConfiguration(filePath As String, config As Configuration)
        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(config)
        File.WriteAllText(filePath, json)
    End Sub

End Module