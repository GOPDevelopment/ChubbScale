Imports System.Runtime.InteropServices
Imports LabelManager2

Public Class Lppx2Manager
    Public Sub New()
        'Do nothing
    End Sub

#Region "Private Members"
    Private WithEvents m_CsApp As LabelManager2.Application
    Private bDeleteCsApp As Boolean = False
    Private bUnableToLoad As Boolean = False
    Private Const Lppx2ProgId As String = "Lppx2.Application"
#End Region

#Region "Private Methods"
    Private Sub ConnectToLppx2()

        If Not (m_CsApp Is Nothing) Then
            Exit Sub
        End If

        ' Try to get a running lppx2
        Dim csObject As Object
        Try
            csObject = System.Runtime.InteropServices.Marshal.GetActiveObject(Lppx2ProgId)
        Catch
            'No CODESOFT object Running !
            csObject = Nothing
        End Try

        ' Initializes the application
        Try
            If (csObject Is Nothing) Then
                'Create our own lppx2
                m_CsApp = New LabelManager2.Application
                bDeleteCsApp = True
            Else
                ' DirectCast the running lppx2
                m_CsApp = DirectCast(csObject, LabelManager2.Application)
            End If

        Catch e As Exception
            Dim szerror As String = e.Message.ToString()
            MessageBox.Show(szerror)
        End Try

        ' Final initialization
        If (m_CsApp.IsEval) Then
            MessageBox.Show(Nothing, "DemoMode", "Quick Print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Make the application visible
        'm_CsApp.Visible = True

    End Sub

#End Region

#Region "Public Methods"
    Public Sub QuitLppx2()

        If Not (m_CsApp Is Nothing) Then

            If (bDeleteCsApp = True) Then
                bDeleteCsApp = False
                Dim csDocumnets As Documents = m_CsApp.Documents
                csDocumnets.CloseAll(False)
                Marshal.ReleaseComObject(csDocumnets)
                m_CsApp.Quit()
            End If

            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_CsApp)
            m_CsApp = Nothing

        End If

    End Sub

    Public Function GetApplication() As Object
        Call Me.ConnectToLppx2()
        GetApplication = m_CsApp
    End Function

    Public Sub SwitchPrinter(ByVal PrinterName As String)
        Call Me.ConnectToLppx2()

        Dim ActiveDoc As LabelManager2.Document = m_CsApp.ActiveDocument
        If Not (ActiveDoc Is Nothing) Then
            Dim PrnSystem As LabelManager2.PrinterSystem = m_CsApp.PrinterSystem()
            Dim PrintersName As LabelManager2.Strings = PrnSystem.Printers(LabelManager2.enumKindOfPrinters.lppxAllPrinters)

            Dim CurrentPrinter As String = ActiveDoc.Printer.Name
            If (CurrentPrinter <> PrinterName) Then

                Dim NbPrinters As Short = PrintersName.Count
                Dim FullPrinterName As String = ""

                For i As Short = 1 To NbPrinters
                    FullPrinterName = PrintersName.Item(i)
                    Dim pos As Integer = FullPrinterName.LastIndexOf(",")
                    If (pos <> -1) Then
                        Dim CurrentPrinterName As String = FullPrinterName.Substring(0, pos)
                        If (CurrentPrinterName = PrinterName) Then
                            Dim bDirectAccess As Boolean = False
                            Dim PortName As String = FullPrinterName.Substring(pos + 1)
                            If (PortName.StartsWith("->")) Then
                                PortName = PortName.Substring(2)
                                bDirectAccess = True
                            End If
                            Dim csPrinter As Printer = ActiveDoc.Printer
                            csPrinter.SwitchTo(PrinterName, PortName, bDirectAccess)
                            Marshal.ReleaseComObject(csPrinter)
                        End If
                    End If
                Next i
                System.Runtime.InteropServices.Marshal.ReleaseComObject(PrintersName)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(PrnSystem)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ActiveDoc)
            End If
        End If
    End Sub
#End Region
End Class
