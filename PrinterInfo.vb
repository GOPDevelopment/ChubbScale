Imports LabelManager2
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
'Imports System
Imports System.IO
'Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Module PrinterInfo

    Private WindowsPrinterName As String = ""       'from appsettings
    Private PrintTemplate As String = ""            'from appsettings
    'Private WithEvents MainDoc As LabelManager2.Document
    Private m_Lppx2Manager As Lppx2Manager = Nothing
    Private WithEvents MyCsApp As LabelManager2.Application = Nothing

    ' Need to have a WithEvents object to manage events at the ActiveDocument level
    Private WithEvents MyActiveDocument As LabelManager2.Document = Nothing
    Private _IsPrinting As Boolean = False

    Private picDefW As System.Int32
    Private picDefH As System.Int32
    Private currentImage As Drawing.Image

    Private myCallback As Drawing.Image.GetThumbnailImageAbort

    Dim varTab As String()() = New String(2)() {}

    Public realSizeImage As Drawing.Image

    Private csPath As System.String

    'Used by Invoke call to update the UI from the Events thread
    'Necessary to avoid an inter-thread invalid operation exception
    'Private Delegate Sub UpdateMessagesListEvent(ByVal strMessage As String)
    'Private _UpdateMessagesList As UpdateMessagesListEvent

    'Need to use BeginInvoke instead of Invoke for Printing events
    'or the Printing thread is blocked by Invoke (synchronous call)
    Private _BeginPrintingEventRes As IAsyncResult
    Private _PausedPrintingEventRes As IAsyncResult
    Private _EndPrintingEventRes As IAsyncResult

    Public Sub InitializePrinter(printerInfo As MachineInfo)

        Dim docToPrint As New PrintDocument
        Dim dlg As New PrintDialog

        docToPrint.DocumentName = "C:\Code\ChubScale\ChubScale\Labels\Box Line 4.5x3.lab_18_teresa.lab"
        'dlg.PrinterSettings.PrinterName = "\\PRDPRINTAPPW01.GOPACK.LOCAL\FO4515C-Lowerlevel-01"
        dlg.PrinterSettings.PrinterName = "SATO S86-ex 305dpi"
        dlg.Document = docToPrint

        Dim result As DialogResult = dlg.ShowDialog
        If result = DialogResult.OK Then
            docToPrint.Print()

        End If


        ''dlg.


        'dlg.Document = oDoc


        'WindowsPrinterName = printerInfo.PrinterName
        'If String.IsNullOrEmpty(WindowsPrinterName) Then MsgBox("Windows Printer Name has not been defined." & vbCrLf & "Check the LabelPrinterName parameter in the application config file.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Printer Name")

        'Try
        '    PrintTemplate = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings("PrintTemplateLocation"))
        '    If String.IsNullOrEmpty(PrintTemplate) Then MsgBox("Label template does not appear to have any formatting." & vbCrLf & "Check the PrintTemplateLocation paramter in the application config file.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Label Template Content")

        'Catch ex As Exception
        '    MsgBox("Unable to read the Label Template file." & vbCrLf & "Check the PrintTemplateLocation parameter in the application config file.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Label Template")
        'End Try

    End Sub

    Private Sub CreateLppx2Manager()
        'Create an instance of Lppx2Manager
        m_Lppx2Manager = New Lppx2Manager
        MyCsApp = DirectCast(m_Lppx2Manager.GetApplication(), LabelManager2.Application)
        'lblLoading.Text = "Please Wait. " & vbCr & "Loading in progress... "
        MyCsApp.PreloadUI()

        '_UpdateMessagesList = New UpdateMessagesListEvent(AddressOf UpdateMessagesList)
        'chkEvents.CheckState = CheckState.Unchecked

    End Sub

    Public Sub PrinterStuff()

        Dim MyApp As New LabelManager2.Application
        'Dim WithEvents oDoc As LabelManager2.Document
        'Dim MyApp2 As New lppx2.application

        'always start a new instance......
        'MyApp = CreateObject("Lppx2.Application")
        'MyApp = GetObject("Lppx2.Application")

        'MyApp = CreateObject("LabelManager2.Application")
        'MyApp = GetObject("LabelManager2.Application")


        With MyApp
            .EnableEvents = True
            .Visible = False

            MyActiveDocument = .ActiveDocument

            'not sure what the int here means
            Dim Var As Object = MyActiveDocument.ReadVariables(1)

            Dim barcodeReturn = MyActiveDocument.DocObjects.Barcodes.Item(1).Value
            Dim textcodeReturn = MyActiveDocument.DocObjects.Texts.Item(1).Value
            Dim variablesReturn = MyActiveDocument.Variables.Item(1).Value
            Dim variableReturn = MyActiveDocument.Variable.Item(1).Value

            'closing all out
            MyApp.Documents.CloseAll(False)
            MyApp.EnableEvents = False
        End With

        MyApp.Quit()

    End Sub

    Partial Public Class PrintHelp
        Inherits System.Windows.Forms.Form

        Private components As System.ComponentModel.Container
        Private printButton As System.Windows.Forms.Button
        Private printFont As Font
        Private streamToPrint As StreamReader

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                streamToPrint = New StreamReader("C:\Code\ChubScale\ChubScale\Labels\Box Line 4.5x3.lab_18_teresa.lab")

                Try
                    'printFont = New Font("Arial", 10)      'not needed
                    Dim pd As PrintDocument = New PrintDocument()

                    'figure this out
                    'pd.PrintPage = New PrintPageEventHandler(AddressOf Me.pd_PrintPage)

                    pd.Print()
                Finally
                    streamToPrint.Close()
                End Try

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
            Dim linesPerPage As Single = 0
            Dim yPos As Single = 0
            Dim count As Integer = 0
            Dim leftMargin As Single = ev.MarginBounds.Left
            Dim topMargin As Single = ev.MarginBounds.Top
            Dim line As String = Nothing
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

            While count < linesPerPage AndAlso (line = streamToPrint.ReadLine()) = True
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics))
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
                count += 1
            End While

            If line IsNot Nothing Then
                ev.HasMorePages = True
            Else
                ev.HasMorePages = False
            End If
        End Sub

        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.printButton = New System.Windows.Forms.Button()
            Me.ClientSize = New System.Drawing.Size(504, 381)
            Me.Text = "Print Example"
            printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            printButton.Location = New System.Drawing.Point(32, 110)
            printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            printButton.TabIndex = 0
            printButton.Text = "Print the file."
            printButton.Size = New System.Drawing.Size(136, 40)
            AddHandler printButton.Click, New System.EventHandler(AddressOf printButton_Click)
            Me.Controls.Add(printButton)
        End Sub
    End Class












    '    Function Make_Label()
    '        'DoCmd.Hourglass True

    '        Dim I, Y As Integer
    '        Dim MyApp As LabelManager2.Application
    '        Dim MyDoc As LabelManager2.Document
    '        Dim MyVars As LabelManager2.Variables
    '        Dim var As LabelManager2.Variable

    '        MyApp = New LabelManager2.Application
    '        'MyApp.Visible = False, else Codesoft opens in a new window
    '        MyApp.Visible = False
    '        MyDoc = MyApp.Documents.Open("C:\Program Files\CS6\Lab\Grondstoffen.Lab")
    '        MyVars = MyDoc.Variables

    '        'Values on a form that will be inserted in the label
    '        Y = 1
    '        Do While Y < 10
    '            MyVars.FormVariables("veld" & Y & "").Value = IIf(IsNull(Forms("Frm_Label")("Veld" & Y & "")), "", (Forms("Frm_Label")("Veld" & Y & "")))
    '            Y = Y + 1
    '        Loop


    '        If Printen = True And Preview = False Then
    '            'if you need to print
    '            MyDoc.PrintDocument
    '        Else
    '            'if you want to show a preview
    '            MyDoc.CopyToClipboard
    '        End If

    '        DoCmd.Hourglass False
    '    MyApp.Documents.CloseAll True
    '    MyApp.Quit
    '    Set MyApp = Nothing

    'End Function

    'Private Sub Command25_Click()
    '    Preview = False
    '    Printen = True
    '    Maak_Label()
    'End Sub

    Private Sub GetSetDevMode()
        Dim oCS As LabelManager2.Application
        Dim oDoc As LabelManager2.Document
        Dim ISize As Long
        Dim devmode As New Object



        oCS = GetObject(, "lppx2.Application")

        oDoc = oCS.ActiveDocument

        ISize = oDoc.Printer.GetDevMode(devmode)

        ISize = oDoc.Printer.GetDevMode(devmode)

        ISize = oDoc.Printer.SetDevMode(devmode)

    End Sub

End Module
