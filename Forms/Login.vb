Imports System.Configuration.ConfigurationManager
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices


Public Class Login
    Public UserInfo As New ProgramUser
    Public MachineInstance As New MachineInfo
    Private scaleChanged As Boolean = False
    Private dayChanged As Boolean = False


    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim bContinue As Boolean = True

        CleanWorkFolder(AppSettings("TempWorkFolder"), MachineInstance.ScaleNumber)

        'shift validation
        'defaulted so something will always be selected.


        'user validation
        'Dim tempUser As String = GetWindowsUserName()
        Select Case True
            Case rdoUser.Checked
                If Not IsUserUser() Then
                    MessageBox.Show("User not valid for this access", "No Access", MessageBoxButtons.OK)
                    bContinue = False
                End If

                'If nudDayNum.Value <> 0 Then
                '    nudDayNum.Value = 0
                '    MessageBox.Show("User does not have access to change the date", "No Access", MessageBoxButtons.OK)
                'End If
                If DateTimePicker1.Value.DayOfYear = DateTime.Now.DayOfYear Then
                Else
                    MessageBox.Show("User does not have access to change the date", "No Access", MessageBoxButtons.OK)
                End If

                If scaleChanged Then
                    MessageBox.Show("User does not have access to change scale", "No Access", MessageBoxButtons.OK)
                End If

                UserInfo.isBasicUser = True

            Case rdoSupervisor.Checked
                'If dayChanged Or scaleChanged Then
                Dim credentialForm As New frmCredentials
                AddHandler credentialForm.AuthenticateUser, AddressOf frmCredentials_AuthenticateUser
                credentialForm.ShowDialog()
                'End If

                If UserInfo.userName = "" Then
                    MessageBox.Show("Username not entered. Please choose User for regular access.", "No Access", MessageBoxButtons.OK)
                    bContinue = False
                ElseIf Not IsUserSupervisor(UserInfo.userName) Then
                    MessageBox.Show("User not valid for this access", "No Access", MessageBoxButtons.OK)
                    bContinue = False
                ElseIf UserInfo.LDAPVerified Then
                    UserInfo.isSupervisor = True
                Else
                    bContinue = False
                End If

            Case rdoTech.Checked
                'If dayChanged Or scaleChanged Then
                Dim credentialForm As New frmCredentials
                AddHandler credentialForm.AuthenticateUser, AddressOf frmCredentials_AuthenticateUser
                credentialForm.ShowDialog()
                'End If

                If UserInfo.userName = "" Then
                    MessageBox.Show("Username not entered. Please choose User for regular access.", "No Access", MessageBoxButtons.OK)
                    bContinue = False
                ElseIf Not IsUserTech(UserInfo.userName) Then
                    MessageBox.Show("User not valid for this access", "No Access", MessageBoxButtons.OK)
                    bContinue = False
                ElseIf UserInfo.LDAPVerified Then
                    UserInfo.isTech = True
                Else
                    bContinue = False
                End If

            Case Else

        End Select

        If bContinue Then
            'log admin/tech changes
            If dayChanged Or scaleChanged Then
                DatabaseHandling.LogUserChanges(UserInfo.userName, DateTimePicker1.Value.ToString, scaleChanged)
            End If

            Me.Hide()

            Dim DateToUse As DateTime = DateTime.Now
            If dayChanged Then
                DateToUse = DateTimePicker1.Value
            End If

            Dim formGrinding As New frmScaleGrinding(UserInfo, MachineInstance, DateToUse)
            formGrinding.ShowDialog()

            Me.Close()
        End If


    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Me.Timer1.Interval = 1000   'every second update
        Me.Timer1.Start()

        Dim machineName As String = "13"
        WriteToLog("Program Start", "", "Program Start", machineName)

        MachineInstance = DatabaseHandling.GetMachineInfo(machineName)

        lblStationDisplay.Text = MachineInstance.ScaleNumber
        lblScaleDisplay.Text = MachineInstance.ScaleName
        lblPlant.Text = MachineInstance.PlantCode

        lblDateDisplay.Text = DateTime.Now.ToString("ddd MMM / dd / yyyy")
        lblDayDisplay.Text = DateTime.Now.DayOfYear.ToString
        lblTimeDisplay.Text = DateTime.Now.ToString("h:mm:ss tt")

        'lblDateDescription.Text = DateTime.Now.ToString("ddd MMM / dd / yyyy")
        lblDayDescription.Text = DateTime.Now.DayOfYear.ToString

        rdo1stShift.Checked = CheckState.Checked
        rdoUser.Checked = CheckState.Checked

        grpSupTechOptions.Enabled = False
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        'constantly updates the time onscreen
        lblTimeDisplay.Text = CStr(TimeValue(CStr(Now)))
    End Sub

    'Private Sub nudDayNum_ValueChanged(sender As Object, e As EventArgs)
    '    If rdoUser.Checked = True And nudDayNum.Value <> 0 Then
    '        nudDayNum.Value = 0
    '        MessageBox.Show("User does not have access to change the date", "No Access", MessageBoxButtons.OK)
    '        dayChanged = False
    '    Else
    '        'update with ticker, then pass to form
    '        lblDateDescription.Text = DateTime.Now.AddDays(nudDayNum.Value).ToString("ddd MMM / dd / yyyy")
    '        lblDayDescription.Text = DateTime.Now.AddDays(nudDayNum.Value).DayOfYear.ToString
    '        dayChanged = True
    '    End If
    'End Sub


    Private Sub frmCredentials_AuthenticateUser(sender As Object, e As EventArgs)

        '    '    AD Domain = gopack.local
        '    '    distinguishedName: DC = GOPACK,DC=LOCAL
        '    '    our two domain controllers are 10.1.0.6 And 10.1.0.7
        '    '    You will need to run recursive queries as we have separate OU's for each department, and the users are assigned to the OU's below their department.
        '    '    Example: GOPACK.Local/ Cattle Buyes/Users
        '    '    you can use "Ldapuser" to query


        Dim path As String = "LDAP://DC=GOPACK,DC=LOCAL"


        Dim de As New DirectoryEntry(path, sender.WinUserName, sender.WinPassword, AuthenticationTypes.Secure)
        UserInfo.userName = sender.WinUserName

        Try
            'run a search using those credentials.  
            'If it returns anything, then you're authenticated
            Dim ds As DirectorySearcher = New DirectorySearcher(de)
            ds.SearchScope = SearchScope.Subtree

            ds.FindOne()

            UserInfo.LDAPVerified = True
        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
            MsgBox("User credentials not valid.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Invalid User")
            'otherwise, it will crash out so return false
            UserInfo.LDAPVerified = False
        End Try
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If rdoUser.Checked = True Then
            'nudDayNum.Value = 0
            'DateTimePicker1.Value = DateTime.Now()
            MessageBox.Show("User does not have access to change the date", "No Access", MessageBoxButtons.OK)
            dayChanged = False
        Else
            'update with ticker, then pass to form
            'lblDateDescription.Text = DateTime.Now.AddDays(nudDayNum.Value).ToString("ddd MMM / dd / yyyy")
            'lblDayDescription.Text = DateTime.Now.AddDays(nudDayNum.Value).DayOfYear.ToString
            'lblDateDescription.Text = DateTimePicker1.Value.ToString("ddd MMM / dd / yyyy")
            lblDayDescription.Text = DateTimePicker1.Value.DayOfYear.ToString
            dayChanged = True
        End If
    End Sub

    Private Sub rdoSupervisor_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSupervisor.CheckedChanged
        grpSupTechOptions.Enabled = True
    End Sub

    Private Sub rdoTech_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTech.CheckedChanged
        grpSupTechOptions.Enabled = True
    End Sub

    Private Sub rdoUser_CheckedChanged(sender As Object, e As EventArgs) Handles rdoUser.CheckedChanged
        grpSupTechOptions.Enabled = False
        'DateTimePicker1.Value = DateTime.Now()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        WriteToLog("Program End", "", "Program End", MachineInstance.ScaleNumber)
        Me.Close()
    End Sub

    'Private Function GetScaleFromMachineName(infoSent As String) As String
    '    Dim sReturn As String = "5" 'default to Trim

    '    If infoSent = "GOP001539" Then
    '        'teresa's machine, in test, no default
    '        sReturn = "8"
    '        inTest = True
    '    End If
    '    'ScaleNumber = COMBO (7/8) OFFAL (6/9) TONGUES (99) TRIM (4/5) STEAK (0/14) GRINDING (13) PATTY (12)   


    '    If infoSent.Contains("05") Or infoSent.Contains("TRIM") Then    'scale05
    '        sReturn = "5"
    '    End If
    '    If infoSent.Contains("7") Then
    '        sReturn = "7"
    '    End If
    '    If infoSent.Contains("8") Then
    '        sReturn = "8"
    '    End If
    '    If infoSent.Contains("06") Then 'scale06
    '        sReturn = "6"
    '    End If
    '    If infoSent.Contains("99") Then 'scale99
    '        sReturn = "99"
    '    ElseIf infoSent.Contains("09") Then 'scale09
    '        sReturn = "9"
    '    End If

    '    If infoSent.Contains("scale00") Then 'scale00
    '        sReturn = "0"
    '    End If

    '    If infoSent.Contains("14") Then
    '        sReturn = "14"
    '    ElseIf infoSent.Contains("4") Then  'not in use
    '        sReturn = "4"
    '    End If


    '    If infoSent.Contains("13") Then 'scale13    'Chubline
    '        sReturn = "13"
    '    End If
    '    If infoSent.Contains("12") Then 'scale12    'PattyLine Scale 12
    '        sReturn = "12"
    '    End If

    '    Return sReturn
    'End Function

    'Private Sub btnChangeScale_Click_1(sender As Object, e As EventArgs)
    '    If rdoTech.Checked Or rdoSupervisor.Checked Then
    '        Dim formSelectScale As New frmSelectScale
    '        formSelectScale.ShowDialog()
    '        MachineInstance = formSelectScale.ReturnMachineInstance

    '        If Not (IsNothing(MachineInstance)) Then
    '            scaleChanged = True

    '            lblStationDisplay.Text = MachineInstance.ScaleNumber
    '            lblScaleDisplay.Text = MachineInstance.ScaleName
    '            lblPlant.Text = MachineInstance.PlantCode
    '        End If
    '    Else
    '        MsgBox("Only a Supervisor or Tech can change scales.", MsgBoxStyle.OkOnly, "Invalid User")
    '    End If
    'End Sub
End Class