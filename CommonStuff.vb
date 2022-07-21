Imports System.Runtime.InteropServices
Imports System.IO
Imports System.IO.Ports
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices

Module CommonStuff
    'Public cmd As New OleDb.OleDbCommand
    'Public Conn As OleDb.OleDbConnection
    'Public dbCommand As OleDb.OleDbCommand
    'Public dbDataReader As OleDb.OleDbDataReader
    'Public strsql As String

    Public inTest As Boolean = False


    Function FixNull(ByVal szValue)
        If IsDBNull(szValue) Then
            Return ""
        Else
            Return szValue
        End If
    End Function
    Function FixNullInteger(ByVal szValue)
        If IsDBNull(szValue) Then
            Return 0
        ElseIf IsNumeric(szvalue) Then
            Return CInt(szValue)
        Else
            Return 0
        End If
    End Function
    Function FixNullDecimal(ByVal szValue)
        If IsDBNull(szValue) Then
            Return 0
        ElseIf IsNumeric(szValue) Then
            Return CDec(szValue)
        Else
            Return 0
        End If
    End Function
    Function CheckBit(ByVal b As Boolean, ByVal endchar As String)
        If b Then
            Return "1" & endchar
        Else
            Return "0" & endchar
        End If
    End Function
    Function CheckString(ByVal s As String)
        Return CheckString(s, "")
    End Function
    Function CheckString(ByVal s As String, ByVal endchar As String)
        Dim pos = InStr(s, "'")
        While pos > 0
            s = Mid(s, 1, pos) & "'" & Mid(s, pos + 1)
            pos = InStr(pos + 2, s, "'")
        End While
        CheckString = "'" & s & "'" & endchar
    End Function
    Function CheckDate(ByVal szValue) As Nullable(Of Date)
        If szValue Is Nothing Or IsDBNull(szValue) Then
            Return Nothing
        Else
            Return Convert.ToDateTime(szValue.ToString).ToString("MM/dd/yyyy")
        End If
    End Function
    Function CheckValueForNull(ByVal s As String, ByVal endchar As String, ByVal IsString As Boolean)
        If String.IsNullOrEmpty(s) Then
            Return "NULL" & endchar
        Else
            If IsString Then
                Return CheckString(s, endchar)
            Else
                Return s & endchar
            End If
        End If
    End Function
    Function FixButtonText(sValue As String) As String
        Return sValue.Replace(vbCrLf, "").Replace(" ", "")
    End Function

    Public Function GetWindowsUserName() As String
        Dim temp As String
        temp = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\"c)(1) 'Name comes as "DOMAIN-OR-COMPUTERNAME\Username"
        Return temp
    End Function
    Public Function GetWindowsRoles() As IEnumerable(Of String)
        Dim identity As Principal.WindowsIdentity = Principal.WindowsIdentity.GetCurrent()
        Dim groupNames = From id In identity.Groups Select id.Translate(GetType(NTAccount)).Value

        Return groupNames
    End Function

    Public Function IsUserUser() As Boolean
        Dim groups As IEnumerable(Of String) = GetWindowsRoles()
        For Each item In groups
            If item = "CONSOLE LOGON" Then
                Return True
            End If
        Next

        Return False
    End Function
    Public Function IsUserSupervisor() As Boolean

        'Dim credentialForm As New frmCredentials
        'AddHandler credentialForm.AuthenticateUser, AddressOf frmCredentials_AuthenticateUser
        'credentialForm.ShowDialog()



        Dim groups As IEnumerable(Of String) = GetWindowsRoles()
        For Each item In groups
            If item = "FABSUP" Then
                Return True
            End If
        Next

        Return False
    End Function
    Public Function IsUserTech() As Boolean

        'Dim credentialForm As New frmCredentials
        'AddHandler credentialForm.AuthenticateUser, AddressOf frmCredentials_AuthenticateUser
        'credentialForm.ShowDialog()


        Dim groups As IEnumerable(Of String) = GetWindowsRoles()
        For Each item In groups
            If item = "GOPACK\IT" Then
                Return True
            End If
        Next

        Return False
    End Function



    Function GetCheckDigitGTIN_13(ByVal szString As String) As String
        Try
            ' String should be 13 characters
            ' First digit x 1, second digit x 3, next x 1, and so on.
            ' Subtract sum from "nearest" equal or higher multiple of ten, = check digit
            Dim multiplier As Integer = 3
            Dim totalValue As Integer = 0
            For i As Integer = 0 To Len(szString) - 1
                totalValue += CInt(szString.Substring(i, 1)) * multiplier
                multiplier = IIf(multiplier = 1, 3, 1)
            Next

            Dim chkDigit As Integer = CStr(10 - totalValue Mod 10)
            If chkDigit = 10 Then
                Return 0
            Else
                Return chkDigit
            End If

        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace)
            Return "-"
        End Try
    End Function

    Function GetCheckDigitGS1_128(ByVal szString As String) As String
        Dim checkDigit As Integer = 0
        For i = 1 To Len(szString)
            Dim e As Integer = Asc(Mid(szString, i, 1)) - 32
            checkDigit = checkDigit + (e * i)
        Next i

        checkDigit = checkDigit Mod 103

        Return checkDigit
    End Function

    Sub CleanWorkFolder(tempWorkFolder As String)
        Dim OldFiles() As String = Directory.GetFiles(Environment.CurrentDirectory & tempWorkFolder, "*.palco.lbl*")
        For Each ThisFile As String In OldFiles
            Try
                If DateDiff(DateInterval.DayOfYear, File.GetLastWriteTime(ThisFile), Now) > 30 Then
                    File.Delete(ThisFile)
                End If
            Catch ex As Exception
                WriteToErrorLog("ERROR", ex.Message, ex.StackTrace)

            End Try
        Next
    End Sub

    Private Sub CleanErrLogFolder()

        'clean out old err files
        Dim OldFiles() As String = Directory.GetFiles(Application.StartupPath & "\Errors\", "*.txt")
        For Each ThisFile As String In OldFiles
            Try
                If DateDiff(DateInterval.DayOfYear, File.GetLastWriteTime(ThisFile), Now) > 30 Then
                    File.Delete(ThisFile)
                End If

            Catch ex As Exception
                WriteToErrorLog("ERROR", ex.Message, ex.StackTrace)
            End Try
        Next

    End Sub

    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        Try

            If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
            End If

            Dim fn As String = "errlog" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            'check the file
            Dim fs As FileStream = New FileStream(Application.StartupPath & "\Errors\" & fn, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\" & fn, FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)
            s1.Write("===== " & DateTime.Now.ToString() & "============================================================" & vbCrLf)
            s1.Write(title & ": " & msg & vbCrLf)
            s1.Write(stkTrace & vbCrLf)
            s1.Close()
            fs1.Close()

        Catch ex As Exception
            'do nothing, carry on
        End Try
    End Sub

    Public Sub WriteToLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        Try

            If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
            End If

            Dim fn As String = "errlog" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            'check the file
            Dim fs As FileStream = New FileStream(Application.StartupPath & "\Errors\" & fn, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\" & fn, FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)
            s1.Write("===== " & DateTime.Now.ToString() & "============= Informational Only ===========================" & vbCrLf)
            s1.Write(title & ": " & msg & vbCrLf)
            s1.Write(stkTrace & vbCrLf)
            s1.Close()
            fs1.Close()

        Catch ex As Exception
            'do nothing, carry on
        End Try
    End Sub

End Module

Public Class WinApi
    <DllImport("user32.dll", EntryPoint:="GetSystemMetrics")>
    Public Shared Function GetSystemMetrics(ByVal which As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Sub SetWindowPos(ByVal hwnd As IntPtr, ByVal hwndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal width As Integer, ByVal height As Integer,
  ByVal flags As UInteger)
    End Sub

    Private Const SM_CXSCREEN As Integer = 0
    Private Const SM_CYSCREEN As Integer = 1
    Private Shared HWND_TOP As IntPtr = IntPtr.Zero
    Private Const SWP_SHOWWINDOW As Integer = 64
    ' 0×0040
    Public Shared ReadOnly Property ScreenX() As Integer
        Get
            Return GetSystemMetrics(SM_CXSCREEN)
        End Get
    End Property

    Public Shared ReadOnly Property ScreenY() As Integer
        Get
            Return GetSystemMetrics(SM_CYSCREEN)
        End Get
    End Property

    Public Shared Sub SetWinFullScreen(ByVal hwnd As IntPtr)
        SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY,
         SWP_SHOWWINDOW)
    End Sub
End Class


Public Class FormState
    Private winState As FormWindowState
    Private brdStyle As FormBorderStyle
    Private topMost As Boolean
    Private bounds As Rectangle

    Private IsMaximized As Boolean = False

    Public Sub Maximize(ByVal targetForm As Form)
        If Not IsMaximized Then
            IsMaximized = True
            Save(targetForm)
            targetForm.WindowState = FormWindowState.Maximized
            targetForm.FormBorderStyle = FormBorderStyle.None
            targetForm.TopMost = True
            WinApi.SetWinFullScreen(targetForm.Handle)
        End If
    End Sub

    Public Sub Save(ByVal targetForm As Form)
        winState = targetForm.WindowState
        brdStyle = targetForm.FormBorderStyle
        topMost = targetForm.TopMost
        bounds = targetForm.Bounds
    End Sub

    Public Sub Restore(ByVal targetForm As Form)
        targetForm.WindowState = winState
        targetForm.FormBorderStyle = brdStyle
        targetForm.TopMost = topMost
        targetForm.Bounds = bounds
        IsMaximized = False
    End Sub
End Class
