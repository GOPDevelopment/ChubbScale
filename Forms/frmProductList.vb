Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class frmProductList
    Public Event ProductSelected(ByVal szProductCode As String)

    Public Property ChosenProductCode As String
    Private Property SpecificProductList As List(Of ProductInfo)

    Private Sub frmProductList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 5
    End Sub
    Public Sub SetProductList(ByVal ProdList As List(Of ProductInfo))
        SpecificProductList = ProdList
    End Sub

    Public Sub DoFilter(ByVal szValue As String)

        lstProducts.Items.Clear()

        If szValue > "" Then
            Try
                'Dim tmpCommand As New OleDb.OleDbCommand("SELECT ProductCode,Description FROM tblProduct WHERE ProductCode LIKE " & CheckString("%" & szValue & "%") & " OR Description LIKE " & CheckString("%" & szValue & "%"), Conn)
                ''Dim tmpCommand As New OleDb.OleDbCommand("SELECT ProductCode,Description FROM tblProduct ", Conn)
                'Dim tmpReader As OleDb.OleDbDataReader = tmpCommand.ExecuteReader
                'While tmpReader.Read
                '    With tmpReader
                '        ' add sample data
                '        lstProducts.Items.Add(FixNull(.Item("ProductCode")) & ": " & FixNull(.Item("Description")))
                '    End With
                'End While

                Dim oConn As New SqlConnection
                oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))

                Dim cmd As New SqlCommand
                cmd = New SqlClient.SqlCommand("SELECT ProductCode,Description FROM ComboProductInfo WHERE ProductCode LIKE " & CheckString("%" & szValue & "%") & " OR Description LIKE " & CheckString("%" & szValue & "%"), oConn)

                Dim rdr As SqlClient.SqlDataReader
                rdr = cmd.ExecuteReader

                If rdr.HasRows Then
                    Do While rdr.Read
                        lstProducts.Items.Add(FixNull(rdr.Item("ProductCode")) & ": " & FixNull(rdr.Item("Description")))
                    Loop
                End If
                cmd.Dispose()
                oConn.Dispose()


            Catch ex As Exception
                WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End If

    End Sub

    Public Sub LoadProductList(ByVal sValue As String)

        For Each item In SpecificProductList
            If item.ProductCode.StartsWith(sValue) Then
                lstProducts.Items.Add(item.ProductCode & ": " & item.ProductDescription)
            ElseIf item.ProductDescription.Contains(sValue) Then
                lstProducts.Items.Add(item.ProductCode & ": " & item.ProductDescription)
            End If
        Next

    End Sub
    Private Sub lstProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstProducts.Click
        Try
            If lstProducts.SelectedIndex < 0 Then Exit Sub
            If lstProducts.Items.Count < 1 Then Exit Sub

            Dim prdSelected As String = lstProducts.SelectedItem

            Dim TheItems() As String = prdSelected.Split(":")
            RaiseEvent ProductSelected(TheItems(0).Trim)
            'frmKeyboard.txtProductCode.Text = TheItems(0).Trim
            'Close()

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")

        End Try
    End Sub

    Private Sub lstProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProducts.SelectedIndexChanged

    End Sub

    'Private Sub lstProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProducts.SelectedIndexChanged
    '    Try
    '        If lstProducts.SelectedIndex < 0 Then Exit Sub
    '        If lstProducts.Items.Count < 1 Then Exit Sub

    '        Dim prdSelected As String = lstProducts.SelectedItem

    '        Dim TheItems() As String = prdSelected.Split(":")
    '        RaiseEvent ProductSelected(TheItems(0).Trim)

    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class