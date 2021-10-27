Public Class Launcher
    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        ReadConfig()
        Launch()
    End Sub

    Private Shared debug_line_nr As Integer = 0
    Public Sub Write(text As String)
        Dim stack As String = ((New System.Diagnostics.StackTrace).GetFrame(1).GetMethod.Name)
        Dim TB1 = Me.Console

        If text = "clear" Then
            TB1.Clear()
        Else
            debug_line_nr = debug_line_nr + 1
            Try
                TB1.AppendText(" >> " & DateAndTime.Now.ToLongTimeString() & " > " & debug_line_nr & "> Func: " & stack & " - " & text & System.Environment.NewLine)
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class