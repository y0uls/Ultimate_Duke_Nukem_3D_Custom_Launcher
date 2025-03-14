Public Class Config
    Public Property PathInstall As String
End Class

Public Class Game
    Public Property Difficulty As Integer
    Public Property ServerMode As Integer
    Public Property Fullscreen As Integer
    Public Property ExitAfterStart As Integer
End Class

Public Class Configuration
    Public Property Config As Config
    Public Property Game As Game
End Class