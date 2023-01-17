Public Class frmEditLot

    Public SetLot As String = ""
    Public SetBoxCount As String = ""
    Private Property UserInfo As ProgramUser

    Public Sub New(ByVal PassedUserInfo As ProgramUser)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UserInfo = PassedUserInfo
    End Sub

    Private Sub frmEditLot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Me.CenterToParent()
        'If UserInfo.isSupervisor Or UserInfo.isTech Then
        '    nudBoxCount.Enabled = True
        'Else
        '    nudBoxCount.Enabled = False
        'End If
        txtEntry.Text = "0" 'default to 0
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        SetBoxCount = -1
        SetLot = -1

    End Sub

    Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        '' See if a numeric value was entered.
        'If IsNumeric(txtWeight.Text) Then
        '    If Single.TryParse(txtWeight.Text, EnteredWeight) Then
        '        Me.Close()
        '    Else
        '        MsgBox("Invalid numeric value entered.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Manual Weight")
        '    End If
        'Else
        '    MsgBox("Invalid numeric value entered.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Manual Weight")
        'End If
        If IsNumeric(txtEntry.Text) Then
            SetLot = txtEntry.Text
            'If nudBoxCount.Enabled Then
            'SetBoxCount = nudBoxCount.Value
            'Else
            SetBoxCount = 0
            'End If
            Me.Close()
        Else
            MsgBox("Please enter a numeric value.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Manual Weight")
        End If

    End Sub

    Private Sub btn0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn0.Click
        txtEntry.Focus()
        SendKeys.Send("0")
    End Sub
    Private Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        txtEntry.Focus()
        SendKeys.Send("1")
    End Sub
    Private Sub btn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn2.Click
        txtEntry.Focus()
        SendKeys.Send("2")
    End Sub
    Private Sub btn3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn3.Click
        txtEntry.Focus()
        SendKeys.Send("3")
    End Sub
    Private Sub btn4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn4.Click
        txtEntry.Focus()
        SendKeys.Send("4")
    End Sub
    Private Sub btn5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn5.Click
        txtEntry.Focus()
        SendKeys.Send("5")
    End Sub
    Private Sub btn6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn6.Click
        txtEntry.Focus()
        SendKeys.Send("6")
    End Sub
    Private Sub btn7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn7.Click
        txtEntry.Focus()
        SendKeys.Send("7")
    End Sub
    Private Sub btn8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn8.Click
        txtEntry.Focus()
        SendKeys.Send("8")
    End Sub
    Private Sub btn9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn9.Click
        txtEntry.Focus()
        SendKeys.Send("9")
    End Sub
End Class