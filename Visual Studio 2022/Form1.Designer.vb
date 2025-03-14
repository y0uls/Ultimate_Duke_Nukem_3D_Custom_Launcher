<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonConfig = New System.Windows.Forms.Button()
        Me.ComboBoxFilter = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ButtonOpenFolder = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxFilterMods = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonTelecharger = New System.Windows.Forms.Button()
        Me.ListBoxNonTelecharges = New System.Windows.Forms.ListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ButtonDesinstaller = New System.Windows.Forms.Button()
        Me.ListBoxTelecharges = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBoxFilterMaps = New System.Windows.Forms.ComboBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonTelechargerMaps = New System.Windows.Forms.Button()
        Me.ListBoxNonTelechargesMaps = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ButtonDesinstallerMaps = New System.Windows.Forms.Button()
        Me.ListBoxTelechargesMaps = New System.Windows.Forms.ListBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-7, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(638, 564)
        Me.TabControl1.TabIndex = 15
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.Ultimate_Duke_Nukem_3D_Custom.My.Resources.Resources.yrbaxqxyrfj0rapcsscr
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.ButtonExit)
        Me.TabPage1.Controls.Add(Me.CheckBox2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.ButtonConfig)
        Me.TabPage1.Controls.Add(Me.ComboBoxFilter)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.ButtonOpenFolder)
        Me.TabPage1.Controls.Add(Me.ListBox1)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(630, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Game"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(24, 43)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(122, 28)
        Me.ComboBox1.TabIndex = 1
        '
        'ButtonExit
        '
        Me.ButtonExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExit.Location = New System.Drawing.Point(472, 448)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(130, 40)
        Me.ButtonExit.TabIndex = 6
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox2.Location = New System.Drawing.Point(152, 418)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(101, 24)
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "Fullscreen"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(24, 448)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(419, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Start Game"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonConfig
        '
        Me.ButtonConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonConfig.Location = New System.Drawing.Point(497, 111)
        Me.ButtonConfig.Name = "ButtonConfig"
        Me.ButtonConfig.Size = New System.Drawing.Size(105, 28)
        Me.ButtonConfig.TabIndex = 14
        Me.ButtonConfig.Text = "Config File"
        Me.ButtonConfig.UseVisualStyleBackColor = True
        '
        'ComboBoxFilter
        '
        Me.ComboBoxFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFilter.FormattingEnabled = True
        Me.ComboBoxFilter.Location = New System.Drawing.Point(24, 110)
        Me.ComboBoxFilter.Name = "ComboBoxFilter"
        Me.ComboBoxFilter.Size = New System.Drawing.Size(122, 28)
        Me.ComboBoxFilter.TabIndex = 8
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox1.Location = New System.Drawing.Point(24, 418)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 24)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Server Mode"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'ButtonOpenFolder
        '
        Me.ButtonOpenFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenFolder.Location = New System.Drawing.Point(372, 110)
        Me.ButtonOpenFolder.Name = "ButtonOpenFolder"
        Me.ButtonOpenFolder.Size = New System.Drawing.Size(119, 29)
        Me.ButtonOpenFolder.TabIndex = 13
        Me.ButtonOpenFolder.Text = "Browse Folder"
        Me.ButtonOpenFolder.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(15, 168)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(600, 244)
        Me.ListBox1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(152, 110)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(122, 26)
        Me.TextBox1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(148, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Autocomplete"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type of game"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(20, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Filter"
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.Ultimate_Duke_Nukem_3D_Custom.My.Resources.Resources.yrbaxqxyrfj0rapcsscr
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.ComboBoxFilterMods)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.ProgressBar1)
        Me.TabPage2.Controls.Add(Me.ButtonTelecharger)
        Me.TabPage2.Controls.Add(Me.ListBoxNonTelecharges)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(630, 531)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Downloads Mods"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(21, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Filter"
        '
        'ComboBoxFilterMods
        '
        Me.ComboBoxFilterMods.FormattingEnabled = True
        Me.ComboBoxFilterMods.Location = New System.Drawing.Point(25, 51)
        Me.ComboBoxFilterMods.Name = "ComboBoxFilterMods"
        Me.ComboBoxFilterMods.Size = New System.Drawing.Size(122, 28)
        Me.ComboBoxFilterMods.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(203, 421)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 20)
        Me.Label4.TabIndex = 3
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(266, 416)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(316, 25)
        Me.ProgressBar1.TabIndex = 2
        '
        'ButtonTelecharger
        '
        Me.ButtonTelecharger.Location = New System.Drawing.Point(25, 404)
        Me.ButtonTelecharger.Name = "ButtonTelecharger"
        Me.ButtonTelecharger.Size = New System.Drawing.Size(172, 50)
        Me.ButtonTelecharger.TabIndex = 1
        Me.ButtonTelecharger.Text = "Download Mod"
        Me.ButtonTelecharger.UseVisualStyleBackColor = True
        '
        'ListBoxNonTelecharges
        '
        Me.ListBoxNonTelecharges.FormattingEnabled = True
        Me.ListBoxNonTelecharges.ItemHeight = 20
        Me.ListBoxNonTelecharges.Location = New System.Drawing.Point(25, 105)
        Me.ListBoxNonTelecharges.Name = "ListBoxNonTelecharges"
        Me.ListBoxNonTelecharges.Size = New System.Drawing.Size(576, 264)
        Me.ListBoxNonTelecharges.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackgroundImage = Global.Ultimate_Duke_Nukem_3D_Custom.My.Resources.Resources.yrbaxqxyrfj0rapcsscr
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage3.Controls.Add(Me.ButtonDesinstaller)
        Me.TabPage3.Controls.Add(Me.ListBoxTelecharges)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(630, 531)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Uninstall Mods"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ButtonDesinstaller
        '
        Me.ButtonDesinstaller.Location = New System.Drawing.Point(25, 405)
        Me.ButtonDesinstaller.Name = "ButtonDesinstaller"
        Me.ButtonDesinstaller.Size = New System.Drawing.Size(576, 48)
        Me.ButtonDesinstaller.TabIndex = 1
        Me.ButtonDesinstaller.Text = "Uninstall Mod"
        Me.ButtonDesinstaller.UseVisualStyleBackColor = True
        '
        'ListBoxTelecharges
        '
        Me.ListBoxTelecharges.FormattingEnabled = True
        Me.ListBoxTelecharges.ItemHeight = 20
        Me.ListBoxTelecharges.Location = New System.Drawing.Point(25, 25)
        Me.ListBoxTelecharges.Name = "ListBoxTelecharges"
        Me.ListBoxTelecharges.Size = New System.Drawing.Size(576, 344)
        Me.ListBoxTelecharges.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackgroundImage = Global.Ultimate_Duke_Nukem_3D_Custom.My.Resources.Resources.yrbaxqxyrfj0rapcsscr
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.ComboBoxFilterMaps)
        Me.TabPage4.Controls.Add(Me.ProgressBar2)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.ButtonTelechargerMaps)
        Me.TabPage4.Controls.Add(Me.ListBoxNonTelechargesMaps)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(630, 531)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Downloads Maps"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(21, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Filter"
        '
        'ComboBoxFilterMaps
        '
        Me.ComboBoxFilterMaps.FormattingEnabled = True
        Me.ComboBoxFilterMaps.Location = New System.Drawing.Point(25, 51)
        Me.ComboBoxFilterMaps.Name = "ComboBoxFilterMaps"
        Me.ComboBoxFilterMaps.Size = New System.Drawing.Size(122, 28)
        Me.ComboBoxFilterMaps.TabIndex = 4
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(266, 416)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(316, 25)
        Me.ProgressBar2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(203, 421)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Label5"
        '
        'ButtonTelechargerMaps
        '
        Me.ButtonTelechargerMaps.Location = New System.Drawing.Point(25, 404)
        Me.ButtonTelechargerMaps.Name = "ButtonTelechargerMaps"
        Me.ButtonTelechargerMaps.Size = New System.Drawing.Size(172, 50)
        Me.ButtonTelechargerMaps.TabIndex = 1
        Me.ButtonTelechargerMaps.Text = "Download Map"
        Me.ButtonTelechargerMaps.UseVisualStyleBackColor = True
        '
        'ListBoxNonTelechargesMaps
        '
        Me.ListBoxNonTelechargesMaps.FormattingEnabled = True
        Me.ListBoxNonTelechargesMaps.ItemHeight = 20
        Me.ListBoxNonTelechargesMaps.Location = New System.Drawing.Point(25, 105)
        Me.ListBoxNonTelechargesMaps.Name = "ListBoxNonTelechargesMaps"
        Me.ListBoxNonTelechargesMaps.Size = New System.Drawing.Size(576, 264)
        Me.ListBoxNonTelechargesMaps.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackgroundImage = Global.Ultimate_Duke_Nukem_3D_Custom.My.Resources.Resources.yrbaxqxyrfj0rapcsscr
        Me.TabPage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage5.Controls.Add(Me.ButtonDesinstallerMaps)
        Me.TabPage5.Controls.Add(Me.ListBoxTelechargesMaps)
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(630, 531)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Uninstall Maps"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'ButtonDesinstallerMaps
        '
        Me.ButtonDesinstallerMaps.Location = New System.Drawing.Point(25, 405)
        Me.ButtonDesinstallerMaps.Name = "ButtonDesinstallerMaps"
        Me.ButtonDesinstallerMaps.Size = New System.Drawing.Size(576, 48)
        Me.ButtonDesinstallerMaps.TabIndex = 1
        Me.ButtonDesinstallerMaps.Text = "Uninstall Map"
        Me.ButtonDesinstallerMaps.UseVisualStyleBackColor = True
        '
        'ListBoxTelechargesMaps
        '
        Me.ListBoxTelechargesMaps.FormattingEnabled = True
        Me.ListBoxTelechargesMaps.ItemHeight = 20
        Me.ListBoxTelechargesMaps.Location = New System.Drawing.Point(25, 25)
        Me.ListBoxTelechargesMaps.Name = "ListBoxTelechargesMaps"
        Me.ListBoxTelechargesMaps.Size = New System.Drawing.Size(576, 344)
        Me.ListBoxTelechargesMaps.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(624, 544)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Ultimate Duke Nukem 3D Custom"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ButtonExit As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBoxFilter As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents ButtonOpenFolder As Button
    Friend WithEvents ButtonConfig As Button
    Friend WithEvents ButtonTelecharger As Button
    Friend WithEvents ListBoxNonTelecharges As ListBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonDesinstaller As Button
    Friend WithEvents ListBoxTelecharges As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonTelechargerMaps As Button
    Friend WithEvents ListBoxNonTelechargesMaps As ListBox
    Friend WithEvents ButtonDesinstallerMaps As Button
    Friend WithEvents ListBoxTelechargesMaps As ListBox
    Friend WithEvents ComboBoxFilterMods As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxFilterMaps As ComboBox
End Class
