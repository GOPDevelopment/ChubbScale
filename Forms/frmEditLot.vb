﻿Public Class frmEditLot

    Public SetLot As String = ""

    Private Sub frmEditLot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Me.CenterToParent()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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
        SetLot = txtEntry.Text
        Me.Close()

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