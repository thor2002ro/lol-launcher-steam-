Imports System.IO
Imports System.Text.RegularExpressions

Module Module1
    Dim s1, s2, s3, s4 As String

    Public Sub Launch()
        Launcher.Write(Format("Opening {0}", s1))

        Try
            '// Create a new ProcessStartInfo
            Dim p As New ProcessStartInfo

            '// Specify the location of the binary
            p.FileName = s1

            '// Use these arguments for the process
            p.Arguments = " """ & s2 & """ """ & s3 & """ """ & s4 & """  "

            ' Use a hidden window
            'p.WindowStyle = ProcessWindowStyle.Hidden

            ' Start the process
            Dim lolclient As System.Diagnostics.Process = Process.Start(p)
            Launcher.Write("LeagueClient.exe found. this window will close in 5 seconds.")
            'lolclient.WaitForExit()
            'Launcher.Write("LeagueClient.exe was closed, this window will close in 5 seconds")
            System.Threading.Thread.Sleep(5000)
            Environment.[Exit](0)
        Catch __unusedException1__ As Exception
            Launcher.Write("Could not find LeagueClient.exe, please place inside the League of Legends root folder" & vbLf & "Press any key to close")
            Console.ReadLine()
        End Try
    End Sub

    Public Sub ReadConfig()
        Dim strFile As String = "lol.launcher.INI"
        Dim sr As New StreamReader(strFile)
        Dim InputString As String

        While sr.Peek <> -1
            InputString = sr.ReadLine()
            checkIfContains(InputString)
            InputString = String.Empty
        End While
        sr.Close()

    End Sub


    Private Sub checkIfContains(ByVal inputString As String)
        Dim m, m1, m2, m3 As Match
        Dim itemPattern As String = "exe=(.+)"
        Dim itemPattern2 As String = "arg1=(.+)"
        Dim itemPattern3 As String = "arg2=(.+)"
        Dim itemPattern4 As String = "arg3=(.+)"

        m = Regex.Match(inputString, itemPattern, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        m1 = Regex.Match(inputString, itemPattern2, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        m2 = Regex.Match(inputString, itemPattern3, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        m3 = Regex.Match(inputString, itemPattern4, RegexOptions.IgnoreCase Or RegexOptions.Compiled)

        Do While m.Success
            Launcher.Write(Format("Found exe {0}", m.Groups(1).Value))
            s1 = m.Groups(1).Value
            m = m.NextMatch()
        Loop

        Do While m1.Success
            Launcher.Write(Format("Found arg1 {0}", m1.Groups(1).Value))
            s2 = m1.Groups(1).Value
            m1 = m1.NextMatch()
        Loop

        Do While m2.Success
            Launcher.Write(Format("Found arg2 {0}", m2.Groups(1).Value))
            s3 = m2.Groups(1).Value
            m2 = m2.NextMatch()
        Loop

        Do While m3.Success
            Launcher.Write(Format("Found arg3 {0}", m3.Groups(1).Value))
            s4 = m3.Groups(1).Value
            m3 = m3.NextMatch()
        Loop

    End Sub

End Module
