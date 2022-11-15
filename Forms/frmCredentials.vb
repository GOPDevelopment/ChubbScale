Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager


Public Class frmCredentials

    Public Event AuthenticateUser(sender As Object, e As EventArgs)
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Try
            'Raise the event that a message is being sent from this form.
            RaiseEvent AuthenticateUser(Me, EventArgs.Empty)


        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, "")
        End Try
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public ReadOnly Property WinUserName() As String
        Get
            Return cmbUsers.SelectedItem.ToString
        End Get
    End Property
    Public ReadOnly Property WinPassword() As String
        Get
            Return txtPassword.Text.Trim
        End Get
    End Property

    Private Sub frmCredentials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim userType As String = ""
        If Login.rdoTech.Checked Then userType = "IT"
        If Login.rdoSupervisor.Checked Then userType = "FabSupervisors"

        Me.CenterToParent()

        If userType <> "" Then
            'Dim oConn As New SqlConnection
            'oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))
            'Dim cmd As New SqlCommand
            'cmd = New SqlClient.SqlCommand("SELECT * FROM UsernamesForDropdown WHERE UserType = '" & userType & "' order by UserLogin", oConn)
            'Dim dataReader As SqlDataReader
            'dataReader = cmd.ExecuteReader()
            'While dataReader.Read
            '    ' Write code to insert an Item into dropdownlist
            '    cmbUsers.Items.Add(dataReader("UserLogin").ToString())
            'End While
            'dataReader.Close()


            Dim UsersInGroup As New List(Of String)
            UsersInGroup = GetUsersAndGroups(userType)
            For Each item In UsersInGroup
                cmbUsers.Items.Add(item)
            Next
        End If




    End Sub

    Private Sub txtPassword_DoubleClick(sender As Object, e As EventArgs) Handles txtPassword.DoubleClick
        If txtPassword.Text = "" Then
            Dim frmKeyboard As New frmKeyboardEntryOnly
            frmKeyboard.ShowDialog()
            If frmKeyboard.KeyboardEntry = "" Then
                frmKeyboard.Close()
                frmKeyboard.Dispose()
                'Me.Close()
            Else
                txtPassword.Text = frmKeyboard.KeyboardEntry
            End If
            frmKeyboard.Close()
            frmKeyboard.Dispose()
        End If
    End Sub

End Class