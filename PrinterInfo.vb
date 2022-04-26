Imports LabelManager2


Module PrinterInfo

    Private WindowsPrinterName As String = ""       'from appsettings
    Private PrintTemplate As String = ""            'from appsettings
    Private WithEvents MainDoc As LabelManager2.Document


    Public Sub InitializePrinter(printerInfo As MachineInfo)


        'trim line
        '    <add key="PrintTemplateLocation" value="\\192.168.20.106\Prod data\Trim Line\scale8a.prn"/>


        'offal
        '    <add key="PrintTemplateLocation" value="\\192.168.20.106\Prod data\Offal\offall-a.prn"/>


        'tongues
        '    <add key="PrintTemplateLocation" value="\\192.168.20.106\Prod data\Tongues\scale8a.prn"/>

        'combo
        '<add key = "PrintTemplateLocation" value="C:\Users\Tom Kelley\Desktop\Source Code Steak scale\Combo\GOWeighAndPrint\combo1.prn"/>
        '<add key = "LabelPrinterName" value="Combo"/>


        'steak
        '    <add key="PrintTemplateLocation" value="C:\Users\Tom Kelley\Desktop\Source Code Steak scale\Current -6 digit\GOWeighAndPrint\scale8a.prn"/>

        'chubb/grinding/patty 12
        '<add key = "PrintTemplateLocation" value="\\192.168.20.106\Prod data\PATTYLINE\scale8a.prn"/>
        '<add key = "PrintTemplateLocation2" value="\\192.168.20.106\Prod data\PATTYLINE\scale8a18m.prn"/>
        '<add key = "PrintTemplateLocation3" value="\\192.168.20.106\Prod data\PATTYLINE\scale8a12m.prn"/>

        WindowsPrinterName = printerInfo.PrinterName
        If String.IsNullOrEmpty(WindowsPrinterName) Then MsgBox("Windows Printer Name has not been defined." & vbCrLf & "Check the LabelPrinterName parameter in the application config file.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Printer Name")

        'Try
        '    PrintTemplate = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings("PrintTemplateLocation"))
        '    If String.IsNullOrEmpty(PrintTemplate) Then MsgBox("Label template does not appear to have any formatting." & vbCrLf & "Check the PrintTemplateLocation paramter in the application config file.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Label Template Content")

        'Catch ex As Exception
        '    MsgBox("Unable to read the Label Template file." & vbCrLf & "Check the PrintTemplateLocation parameter in the application config file.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Label Template")
        'End Try

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

            MainDoc = .ActiveDocument

            'not sure what the int here means
            Dim Var As Object = MainDoc.ReadVariables(1)

            Dim barcodeReturn = MainDoc.DocObjects.Barcodes.Item(1).Value
            Dim textcodeReturn = MainDoc.DocObjects.Texts.Item(1).Value
            Dim variablesReturn = MainDoc.Variables.Item(1).Value
            Dim variableReturn = MainDoc.Variable.Item(1).Value

            'closing all out
            MyApp.Documents.CloseAll(False)
            MyApp.EnableEvents = False
        End With

        MyApp.Quit()




    End Sub


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

End Module
