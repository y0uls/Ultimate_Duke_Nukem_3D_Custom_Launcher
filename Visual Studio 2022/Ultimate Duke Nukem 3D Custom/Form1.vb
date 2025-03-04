Public Class Form1
    Private mapsDir As String = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke\maps"
    Private modsDir As String = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke\mods"
    Private eduke32Path As String = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke\eduke32.exe"
    Private specificFilePath As String = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke\fullscreen.cfg"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Empêcher le redimensionnement
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ComboBox1.Items.Add("Choose a custom map")
        ComboBox1.Items.Add("Choose a custom mod")
        ComboBox1.SelectedIndex = -1 ' Ne rien sélectionner par défaut
        For i As Integer = Asc("A"c) To Asc("Z"c)
            ComboBoxFilter.Items.Add(Chr(i))
        Next
        ComboBoxFilter.Items.Add("All")
        ComboBoxFilter.SelectedIndex = ComboBoxFilter.Items.Count - 1 ' Select "All" by default
        Console.WriteLine("Form loaded and ComboBox items added.")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                Console.WriteLine("Maps option selected.")
                LoadMaps()
                CheckBox1.Enabled = False ' Désactiver la CheckBox
            Case 1
                Console.WriteLine("Mods option selected.")
                LoadMods()
                CheckBox1.Enabled = True ' Activer la CheckBox
        End Select
    End Sub

    Private Sub LoadMaps()
        ListBox1.Items.Clear()
        If IO.Directory.Exists(mapsDir) Then
            Console.WriteLine("Maps directory exists.")
            Dim folders = IO.Directory.GetDirectories(mapsDir)
            For Each folder In folders
                ListBox1.Items.Add(IO.Path.GetFileName(folder))
                Console.WriteLine($"Map added: {IO.Path.GetFileName(folder)}")
            Next
        Else
            MessageBox.Show("Maps directory does not exist.")
            Console.WriteLine("Maps directory does not exist.")
        End If
    End Sub

    Private Sub LoadMods()
        ListBox1.Items.Clear()
        If IO.Directory.Exists(modsDir) Then
            Console.WriteLine("Mods directory exists.")
            Dim folders = IO.Directory.GetDirectories(modsDir)
            For Each folder In folders
                ListBox1.Items.Add(IO.Path.GetFileName(folder))
                Console.WriteLine($"Mod added: {IO.Path.GetFileName(folder)}")
            Next
        Else
            MessageBox.Show("Mods directory does not exist.")
            Console.WriteLine("Mods directory does not exist.")
        End If
    End Sub

    Private Sub ComboBoxFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFilter.SelectedIndexChanged
        FilterList()
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterList()
    End Sub

    Private Sub FilterList()
        If ComboBox1.SelectedIndex = -1 Then
            Return ' Ne rien faire si aucun élément n'est sélectionné dans ComboBox1
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
            ' Démarrer le jeu avec le dossier sélectionné
            If ComboBox1.SelectedIndex = 0 Then
                StartGameWithMap(selectedFolder)
            ElseIf ComboBox1.SelectedIndex = 1 Then
                StartGameWithMod(selectedFolder)
            End If
        Else
            MessageBox.Show("Please select a map or mod.")
            Console.WriteLine("No map or mod selected.")
        End If
    End Sub

    Private Sub StartGameWithMap(selectedFolder As String)
        Dim fullPath As String = IO.Path.Combine(mapsDir, selectedFolder)
        Dim mode As String = If(CheckBox1.Checked, "-server", String.Empty)
        Dim specificFile As String = If(CheckBox2.Checked, $"-cfg ""{specificFilePath}""", String.Empty)
        If IO.Directory.Exists(fullPath) Then
            Dim mapFiles = IO.Directory.GetFiles(fullPath, "*.map").ToArray()
            Dim count As Integer = mapFiles.Length

            If count = 0 Then
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke"})
                Console.WriteLine($"Starting eduke32.exe with no specific map in {fullPath}")
            ElseIf count = 1 Then
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" ""{IO.Path.GetFileName(mapFiles(0))}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke"})
                Console.WriteLine($"Starting eduke32.exe with map {mapFiles(0)} in {fullPath}")
            Else
                ' If there are multiple maps, let the user choose one
                Dim mapFile As String = ChooseMap(mapFiles)
                If Not String.IsNullOrEmpty(mapFile) Then
                    Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" ""{IO.Path.GetFileName(mapFile)}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke"})
                    Console.WriteLine($"Starting eduke32.exe with map {mapFile} in {fullPath}")
                End If
            End If
        Else
            MessageBox.Show("Selected map folder does not exist.")
            Console.WriteLine("Selected map folder does not exist.")
        End If
    End Sub

    Private Function ChooseMap(mapFiles As String()) As String
        ' Display a dialog to choose a map if there are multiple maps
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
        Dim specificFile As String = If(CheckBox2.Checked, $"-cfg ""{specificFilePath}""", String.Empty)


        If IO.Directory.Exists(fullPath) Then
            Dim modFiles = IO.Directory.GetFiles(fullPath, "*.pk3").Concat(IO.Directory.GetFiles(fullPath, "*.dat")).ToArray()
            Dim count As Integer = modFiles.Length

            If count = 1 Then
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" ""{IO.Path.GetFileName(modFiles(0))}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke"})
                Console.WriteLine($"Starting eduke32.exe with mod {modFiles(0)} in {fullPath}")



            ElseIf IO.File.Exists(IO.Path.Combine(fullPath, "launcher.bat")) Then
                Process.Start(New ProcessStartInfo(IO.Path.Combine(fullPath, "launcher.bat"), mode) With {.WorkingDirectory = fullPath})
                Console.WriteLine($"Starting launcher.bat in {fullPath}")
            ElseIf IO.File.Exists(IO.Path.Combine(fullPath, "eduke32.exe")) Then
                Process.Start(New ProcessStartInfo(IO.Path.Combine(fullPath, "eduke32.exe"), $"-j""{fullPath}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = fullPath})
                Console.WriteLine($"Starting eduke32.exe in {fullPath}")
            Else
                Process.Start(New ProcessStartInfo(eduke32Path, $"-j""{fullPath}"" {mode} {specificFile} -usecwd") With {.WorkingDirectory = "C:\Program Files (x86)\Ultimate Duke Nukem 3D Custom\CustomDuke"})
                Console.WriteLine($"Starting eduke32.exe with mod in {fullPath}")
            End If
        Else
            MessageBox.Show("Selected mod folder does not exist.")
            Console.WriteLine("Selected mod folder does not exist.")
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
            MessageBox.Show("Please select a valid option from the type of game.")
        End If
    End Sub
End Class