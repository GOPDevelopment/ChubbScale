Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports BarcodeLib.BarcodeReader
Imports System.Runtime.InteropServices
Imports LabelManager2
'Imports System.IO
'Imports System.IO.Ports


'GB5x3.LBL
'GB5x3CAB.LBL
'GB5x3CHB.LBL
'GB5x3ONA.LBL
'GBOHB5D.LBL


Public Class frmScaleGrinding

    Private Property SCALE_NAME As String = "GRINDING"
    Private Property PROD_LINE As String = "11"
    Private Property GRADE As String = "3"
    Private Property CUSTOMER As String = "00"
    Private Property OVERRIDE_GRADE_VALUE As Integer = 4

    Private Property ProductList As New List(Of ProductInfo)
    Private Property FavoriteProductList As New List(Of String)
    Private Property BOX_TOTAL_SHIFT As Integer = 0
    Private Property BOX_TOTAL_DAILY As Integer = 0
    Private Property PRODUCT_COUNT_SHIFT As Integer = 0
    Private Property PRODUCT_COUNT_DAILY As Integer = 0
    Private Property WEIGHT_TOTAL_SHIFT As Single = 0
    Private Property WEIGHT_TOTAL_DAILY As Single = 0
    Private Property BOX_COUNT_LOT As Integer = 0
    Private Property CURRENT_LOT As Integer = 0
    Private Property PROD_ACTIVE As Boolean = True
    Private Property LAST_GROSS_WEIGHT As Single = 0
    'Private Property CURRENT_TEST_NO As String = ""
    Private Property LAST_BARCODE As String = ""
    Private Property LAST_SERIAL As String = ""
    Private Property CURRENT_PRODUCT_LABEL_NET_WEIGHT As Single = 0
    Private Property VALID_PRODUCTCODE As Boolean = True

    Friend WithEvents SerialPortA As New System.IO.Ports.SerialPort
    Friend WithEvents SerialPortB As New System.IO.Ports.SerialPort
    Friend WithEvents SerialPortC As New System.IO.Ports.SerialPort
    Friend WithEvents SerialPortD As New System.IO.Ports.SerialPort
    'Private WithEvents ScaleInstance As New SerialPort
    Private Property UserInfo As ProgramUser
    Private Property MachineInstance As MachineInfo
    Private Property EntireScaleMessage As String = ""
    Private Property EntireQRMessage As String = ""
    Private Property PROD_DATE_TO_USE As Date

    Private m_Lppx2Manager As Lppx2Manager = Nothing
    Private WithEvents MyCsApp As LabelManager2.Application

    ' Need to have a WithEvents object to manage events at the ActiveDocument level
    Private WithEvents ActiveLabelDocument As LabelManager2.Document = Nothing
    'Private WithEvents ActiveLabelDocument As New LabelManager2.Document


    'Private _IsPrinting As Boolean = False
    'Private picDefW As System.Int32
    'Private picDefH As System.Int32
    'Private currentImage As Drawing.Image
    'Private myCallback As Drawing.Image.GetThumbnailImageAbort

    Dim varTab As String()() = New String(2)() {}


    Public Sub New(ByVal PassedUserInfo As ProgramUser, ByVal PassedMachineInstance As MachineInfo, ByVal DateToUse As System.DateTime)

        ' This call is required by the designer.
        InitializeComponent()

        UserInfo = PassedUserInfo
        MachineInstance = PassedMachineInstance
        PROD_DATE_TO_USE = DateToUse
        Try

            'm_Lppx2Manager = New Lppx2Manager
            'MyCsApp = DirectCast(m_Lppx2Manager.GetApplication(), LabelManager2.Application)
            'MyCsApp.PreloadUI()

            MyCsApp = New LabelManager2.Application


        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        End Try

    End Sub
    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            WriteToLog("Entering " & MachineInstance.ScaleName, "Scale Name", MachineInstance.ScaleNumber, MachineInstance.ScaleNumber)
            Me.CenterToScreen()

            Me.KeyPreview = True
            AddHandler Me.KeyDown, AddressOf KeyDownHandler
            AddHandler Me.KeyUp, AddressOf KeyUpHandler


            'starting time to update this time display box
            Me.Timer1.Interval = 1000
            Me.Timer1.Start()

            lblDateDisplay.Text = PROD_DATE_TO_USE.ToString("ddd MMM / dd / yyyy")
            lblDayDisplay.Text = PROD_DATE_TO_USE.DayOfYear.ToString
            lblTimeDisplay.Text = System.DateTime.Now.ToString("h:mm:ss tt")

            If Login.rdo1stShift.Checked Then
                lblShiftDisplay.Text = "1st"
            Else
                lblShiftDisplay.Text = "2nd"
            End If
            lblStationDisplay.Text = MachineInstance.ScaleNumber & " - " & MachineInstance.ScaleName
            lblPlantDisplay.Text = MachineInstance.PlantCode
            PROD_LINE = MachineInstance.ScaleNumber


            'get product list and store
            ProductList = DatabaseHandling.GetProductList(MachineInstance.ScaleName)
            If ProductList.Count < 1 Then
                MsgBox("No Product Codes loaded for this scale, contact IT.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "No Product Codes")
            End If

            'get favorite product list and set buttons
            SetFavoriteKeys()

            'initialize scale ports
            InitializeScalePorts()


            'initialize label printer
            'InitializePrinter(MachineInstance)     'commenting out for now as it's done above

            'set intial display fields
            SetDisplay("000000")
            btnMakeFavorite.Text = "Remove Favorite"


            If AppSettings("InTest") = "TRUE" Then
                btnSetWeightPrint.Visible = True
                btnProdActive.PerformClick()    'to make it inactive
            Else
                btnSetWeightPrint.Visible = False
            End If

        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        End Try
    End Sub
    Private Sub InitializeScalePorts()
        Dim myPort As String() = IO.Ports.SerialPort.GetPortNames()
        Dim portString As New List(Of String)

        For i = 0 To myPort.Count - 1
            portString.Add(myPort(i).ToString)
        Next

        'WriteToLog(portString, "", "Available Ports", MachineInstance.ScaleNumber)
        Dim z As Integer = 1
        For Each portInstance In portString
            Dim scalePort As New ScalePortInfo(portInstance)
            Select Case z
                Case 1
                    SerialPortA = scalePort.ScalePort
                Case 2
                    SerialPortB = scalePort.ScalePort
                Case 3
                    SerialPortC = scalePort.ScalePort
                Case 4
                    SerialPortD = scalePort.ScalePort
            End Select
            z += 1
        Next


        'using this to keep the program open to listen
        'Console.SetWindowSize(80, 40)
        'Console.ReadLine()

    End Sub
    Private Sub SerialPortA_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortA.DataReceived
        'System.Threading.Thread.Sleep(15000)
        Dim sRead As String = SerialPortA.ReadExisting()
        WriteToLog(sRead, SerialPortA.PortName, "A Port Reading", MachineInstance.ScaleNumber)
        'Console.WriteLine(SerialPortA.PortName & " - " & sRead)

        HandleInput(sRead, SerialPortA.PortName)

    End Sub
    Private Sub SerialPortB_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortB.DataReceived
        'System.Threading.Thread.Sleep(15000)
        Dim sRead As String = SerialPortB.ReadExisting()
        WriteToLog(sRead, SerialPortB.PortName, "B Port Reading", MachineInstance.ScaleNumber)

        HandleInput(sRead, SerialPortB.PortName)
    End Sub
    Private Sub SerialPortC_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortC.DataReceived
        'System.Threading.Thread.Sleep(15000)
        Dim sRead As String = SerialPortC.ReadExisting()
        WriteToLog(sRead, SerialPortC.PortName, "C Port Reading", MachineInstance.ScaleNumber)

        HandleInput(sRead, SerialPortC.PortName)

    End Sub
    Private Sub SerialPortD_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortD.DataReceived
        'System.Threading.Thread.Sleep(15000)
        Dim sRead As String = SerialPortD.ReadExisting()
        WriteToLog(sRead, SerialPortD.PortName, "D Port Reading", MachineInstance.ScaleNumber)

        HandleInput(sRead, SerialPortD.PortName)
    End Sub

    Private Sub HandleInput(inputSent As String, comPort As String)
        Try


            If comPort = AppSettings("QRReaderComPort") Then
                'this reads in the QR code - totally works!
                'Dim datas() As String = BarcodeReader.read("c:/temp/qr-code.png", BarcodeReader.QRCODE)

                EntireQRMessage = EntireQRMessage & inputSent

                If EntireQRMessage.Trim.Length = 6 Then
                    WriteToLog(EntireQRMessage, comPort, "Entire QR message", MachineInstance.ScaleNumber)
                    lblProductCode.Text = EntireQRMessage

                    'for logging purposes only
                    If Not DatabaseHandling.DoesProductCodeExist(EntireQRMessage, ProductList) Then
                        WriteToLog(EntireQRMessage, "", "Product Code doesn't exist in database", MachineInstance.ScaleNumber)
                        VALID_PRODUCTCODE = False
                    Else
                        VALID_PRODUCTCODE = True
                    End If

                    SetDisplay(EntireQRMessage)

                    EntireQRMessage = ""

                    If AppSettings("InTest") = "TRUE" Then
                        Dim random As New Random
                        txtGrossWeight.Text = random.Next(7, 100)
                        CURRENT_PRODUCT_LABEL_NET_WEIGHT = CSng(txtGrossWeight.Text)
                        If VALID_PRODUCTCODE Then
                            HandleAllPrinting(CURRENT_PRODUCT_LABEL_NET_WEIGHT)
                        Else
                            PrintLabelBlank()
                        End If

                        VALID_PRODUCTCODE = False   'JUST TO RESET AFTER A PRINT
                    End If
                End If

            End If


            If comPort = AppSettings("ScaleComPort") Then

                EntireScaleMessage = EntireScaleMessage & inputSent

                If EntireScaleMessage.Contains("lb") Then 'And DatabaseHandling.DoesProductCodeExist(lblProductCode.Text, ProductList) Then
                    WriteToLog(EntireScaleMessage, SerialPortB.PortName, "Entire Scale message", MachineInstance.ScaleNumber)
                    'Dim random As New Random
                    'txtGrossWeight.Text = random.Next(7, 100)

                    EntireScaleMessage = RemoveAllAlphas(EntireScaleMessage)
                    txtGrossWeight.Text = EntireScaleMessage

                    CURRENT_PRODUCT_LABEL_NET_WEIGHT = CSng(txtGrossWeight.Text)
                    If VALID_PRODUCTCODE Then
                        HandleAllPrinting(CURRENT_PRODUCT_LABEL_NET_WEIGHT)
                    Else
                        PrintLabelBlank()
                    End If

                    VALID_PRODUCTCODE = False   'JUST TO RESET AFTER A PRINT

                    EntireScaleMessage = ""
                End If

            End If

        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        End Try

    End Sub

    Private Sub SetDisplay(ProductCodePassed As String)
        'load initial or passed lookup

        If ProductCodePassed = String.Empty Then
            txtMaxWeight.Text = ""
            txtSetWeight.Text = ""
            'txtTare.Text = ""
            txtGrossWeight.Text = 0
            txtWarnings.Text = ""
            txtMinWeight.Text = ""

            lblProductCode.Text = ""
            lblProductDesc.Text = ""
            lblSerialNumberDisplay.Text = ""

            lblProductCountDaily.Text = ""
            lblWeightTotalShift.Text = ""
            lblBoxTotalShift.Text = ""
            lblBoxTotalDaily.Text = ""
            lblWeightTotalDaily.Text = ""
            lblProductCountShift.Text = ""
            'lblLotDisplay.Text = CURRENT_LOT
            'lblBoxesInLotDisplay.Text = ""
            btnMakeFavorite.Text = "Make Favorite"
        Else
            'txtGrossWeight.Text = "0"
            'txtGrossWeight.Text = ScalePortInfo.CurrentScaleRead           'WEIGHT_TOTAL      'leave as entered on the screen
            lblProductCode.Text = ProductCodePassed
            'lblGradeDisplay.Text = ""  'leave as entered on the screen

            Dim tempProductInfo As New ProductInfo
            tempProductInfo = DatabaseHandling.LookupSpecificProduct(ProductCodePassed, ProductList)

            'from database
            lblSerialNumberDisplay.Text = LAST_SERIAL

            lblProductDesc.Text = tempProductInfo.ProductDescription
            txtTare.Text = tempProductInfo.Tare
            txtMaxWeight.Text = tempProductInfo.MaxWeight
            txtSetWeight.Text = tempProductInfo.SetWeight
            txtMinWeight.Text = tempProductInfo.MinWeight
            Dim grossWeight As String = "0"
            If FixNullDecimal(txtGrossWeight.Text) - FixNullDecimal(txtTare.Text) > 0 Then
                grossWeight = FixNullDecimal(txtGrossWeight.Text) - FixNullDecimal(txtTare.Text)
            End If
            txtNetWeight.Text = grossWeight

            'get current totals by database queries
            BOX_COUNT_LOT = GetLotBoxCountCurrent()

            GRADE = tempProductInfo.ProductGrade

            'count for each scan
            GetCounts()

            lblProductCountShift.Text = PRODUCT_COUNT_SHIFT
            lblProductCountDaily.Text = PRODUCT_COUNT_DAILY

            lblWeightTotalShift.Text = WEIGHT_TOTAL_SHIFT
            lblWeightTotalDaily.Text = WEIGHT_TOTAL_DAILY

            lblBoxTotalShift.Text = BOX_TOTAL_SHIFT
            lblBoxTotalDaily.Text = BOX_TOTAL_DAILY


            'If txtGrossWeight.Text <> "0" And txtGrossWeight.Text <> "" Then
            '    txtWarnings.Text = GetWarnings(tempProductInfo)
            'Else
            '    txtWarnings.Text = ""
            'End If

            If FavoriteProductList.Contains(tempProductInfo.ProductCode) Then
                btnMakeFavorite.Text = "Remove Favorite"
            Else
                btnMakeFavorite.Text = "Make Favorite"
            End If

        End If


    End Sub
    'Private Function GetWarnings(tempProductInfo As ProductInfo) As String
    '    Dim warningReturn As String = ""
    '    If txtGrossWeight.Text <> "" And txtGrossWeight.Text <> "0" Then
    '        If txtMaxWeight.Text <> "" And txtMaxWeight.Text <> "0" Then
    '            If FixNullInteger(txtGrossWeight.Text - txtTare.Text) > FixNullInteger(txtMaxWeight.Text) Then
    '                warningReturn = "OVER MAX WEIGHT"
    '                WriteToLog("Weight over ", txtGrossWeight.Text, txtMaxWeight.Text, MachineInstance.ScaleNumber)
    '            End If
    '        End If

    '        If txtMinWeight.Text <> "" And txtMinWeight.Text <> "0" Then
    '            If FixNullInteger(txtGrossWeight.Text - txtTare.Text) < FixNullInteger(txtMinWeight.Text) Then
    '                warningReturn = "UNDER MIN WEIGHT"
    '                WriteToLog("Weight under ", txtGrossWeight.Text, txtMinWeight.Text, MachineInstance.ScaleNumber)
    '            End If
    '        End If

    '        If FixNullInteger(txtGrossWeight.Text - txtTare.Text) < 0 Then
    '            warningReturn = "UNDER 0 LBS"
    '            WriteToLog("Weight over 0 ", txtGrossWeight.Text, "", MachineInstance.ScaleNumber)
    '        End If
    '    End If


    '    'If BOX_COUNT_LOT > tempProductInfo.KickoutCount And tempProductInfo.KickoutCount > 0 Then
    '    If IsKickoutBox(tempProductInfo) Then
    '        warningReturn = "KICKOUT BOX COUNT MET AT " & tempProductInfo.KickoutCount
    '        WriteToLog("Kickout Count met at ", BOX_COUNT_LOT, tempProductInfo.KickoutCount, MachineInstance.ScaleNumber)
    '    End If

    '    Return warningReturn
    'End Function
    Private Sub btnProdActive_Click(sender As Object, e As EventArgs) Handles btnProdActive.Click
        If btnToggleLanguage.Text = "English" Then
            'if it says English then the screen is in spanish
            If btnProdActive.Text = "Producción Activa" Then
                btnProdActive.Text = "Producción Inactivo"
                'txtWarnings.BackColor = SystemColors.Highlight
                txtWarnings.Text = "Producción Inactivo"
                Me.BackColor = Color.IndianRed
                PROD_ACTIVE = False
            Else
                btnProdActive.Text = "Producción Activa"
                'txtWarnings.BackColor = SystemColors.Control
                txtWarnings.Text = ""
                Me.BackColor = SystemColors.Control
                PROD_ACTIVE = True
            End If
        Else
            'if it says espanol then the screen is in english
            If btnProdActive.Text = "Production Active" Then
                btnProdActive.Text = "Production Inactive"
                'txtWarnings.BackColor = SystemColors.Highlight
                txtWarnings.Text = "Production Inactive"
                Me.BackColor = Color.IndianRed
                PROD_ACTIVE = False
            Else
                btnProdActive.Text = "Production Active"
                'txtWarnings.BackColor = SystemColors.Control
                txtWarnings.Text = ""
                Me.BackColor = SystemColors.Control
                PROD_ACTIVE = True
            End If
        End If

    End Sub

    Private Sub HandleAllPrinting(weight As Single)

        Try
            CURRENT_LOT = 0
            BOX_COUNT_LOT = GetLotBoxCountCurrent()
            BOX_COUNT_LOT = BOX_COUNT_LOT + 1

            'set prod date time to current time at print
            PROD_DATE_TO_USE = PROD_DATE_TO_USE.ToString("yyyy-MM-dd ") & System.DateTime.Now.ToString("HH:mm:ss tt")

            'BuildFileAndPrint(weight)
            Dim outFile As String = Environment.CurrentDirectory & AppSettings("TempWorkFolder") & MachineInstance.ScaleName & "_" & System.Guid.NewGuid.ToString & ".lab"

            'copy original label file to new file and update
            OpenLabelFile(outFile)

            UpdateLabelFields(weight)

            WriteToLog("before print", outFile, "", MachineInstance.ScaleNumber)

            PrintLabel(outFile)


            'close label file
            If (Not (ActiveLabelDocument Is Nothing)) Then
                ActiveLabelDocument.Close(False)
                Marshal.ReleaseComObject(ActiveLabelDocument)
                ActiveLabelDocument = Nothing
            End If

            'add info for transaction
            AddTransactionToDB()

            'If PROD_ACTIVE Then
            '    CreateInfoForAlpha()
            'End If

            'delete copied template file, not needed anymore
            System.IO.File.Delete(outFile)

        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        End Try
    End Sub
    'Private Sub BuildFileAndPrint(ByVal nLBS As Single)

    '    Try
    '        Dim outFile As String = Environment.CurrentDirectory & AppSettings("TempWorkFolder") & MachineInstance.ScaleName & "_" & System.Guid.NewGuid.ToString & ".lab"

    '        'copy original label file to new file and update
    '        OpenLabelFile(outFile)

    '        UpdateLabelFields(nLBS)

    '        WriteToLog("before print", outFile, MachineInstance.PrinterName, MachineInstance.ScaleNumber)

    '        PrintLabel(outFile)

    '        WriteToLog("after print", outFile, MachineInstance.PrinterPort, MachineInstance.ScaleNumber)

    '        'close label file
    '        If (Not (ActiveLabelDocument Is Nothing)) Then
    '            ActiveLabelDocument.Close(False)
    '            Marshal.ReleaseComObject(ActiveLabelDocument)
    '            ActiveLabelDocument = Nothing
    '        End If

    '    Catch ex As Exception
    '        WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
    '    End Try

    'End Sub
    Private Sub OpenLabelFile(outFile As String)

        Try

            If (Not (ActiveLabelDocument Is Nothing)) Then
                ActiveLabelDocument.Close(False)
                Marshal.ReleaseComObject(ActiveLabelDocument)
                ActiveLabelDocument = Nothing
            End If

            'copy template file to new file and open
            Dim templateFile As String = Environment.CurrentDirectory & AppSettings("PrintTemplateLocation_Chubb")
            If System.IO.File.Exists(templateFile) Then
                System.IO.File.Copy(templateFile, outFile)

                Dim fileDetail As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(outFile)
                fileDetail.IsReadOnly = False

                Dim csDocuments As LabelManager2.Documents = MyCsApp.Documents
                ActiveLabelDocument = csDocuments.Open(outFile, False)
                Marshal.ReleaseComObject(csDocuments)
            Else
                MessageBox.Show("No template file", "Stop", MessageBoxButtons.OK)
            End If


        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
            If ActiveLabelDocument IsNot Nothing Then
                Marshal.ReleaseComObject(ActiveLabelDocument)
                ActiveLabelDocument = Nothing
            End If
        End Try


    End Sub
    Private Sub UpdateLabelFields(ByVal nLBS As Single)

        Dim currentLabelVariables As New LabelVariables
        Dim availableVariableAssignment As New LabelVariableAssignment

        availableVariableAssignment = FillVariablesTabFromActiveLabel()

        Try
            Dim tempProductInfo As New ProductInfo
            tempProductInfo = DatabaseHandling.LookupSpecificProduct(lblProductCode.Text, ProductList)

            ' Save reported weight as Gross
            LAST_GROSS_WEIGHT = nLBS

            ' Adjust for tare of Box
            nLBS -= tempProductInfo.Tare

            ' Adjust for tare of "items"
            nLBS -= (tempProductInfo.ItemCountPerBox * tempProductInfo.ItemTareEach)

            If tempProductInfo.SetWeight <> 0 Then LAST_GROSS_WEIGHT = tempProductInfo.SetWeight + tempProductInfo.Tare
            If tempProductInfo.SetWeight <> 0 Then nLBS = tempProductInfo.SetWeight
            If nLBS < 0 Then nLBS = 0
            CURRENT_PRODUCT_LABEL_NET_WEIGHT = nLBS



            Dim nKGS As Single = nLBS * CSng(AppSettings("KiloConversionRate"))

            ' Lop off the "last digit"
            Dim wrkNumber As String = FormatNumber((Math.Round(nLBS, 1)) * 100, 0, TriState.UseDefault, TriState.UseDefault, TriState.False)
            Dim tLBSHundred As String = Microsoft.VisualBasic.Right("000000" & wrkNumber.Substring(0, wrkNumber.Length - 1), 6)
            Dim tBoxCount As String
            'If tempProductInfo.Lot <> 0 Then
            '    tBoxCount = Microsoft.VisualBasic.Right("0000" & BOX_COUNT_LOT, 4) & "-" & MachineInstance.ScaleNumber & IIf(IsKickoutBox(tempProductInfo), "+", "") & "  Lot " & tempProductInfo.Lot
            'Else
            '    tBoxCount = Microsoft.VisualBasic.Right("0000" & BOX_COUNT_LOT, 4) & "-" & MachineInstance.ScaleNumber & IIf(IsKickoutBox(tempProductInfo), "+", "")
            'End If
            tBoxCount = Microsoft.VisualBasic.Right("0000" & BOX_COUNT_LOT, 4)

            'Dim GradeToUse As Integer = IIf(OVERRIDE_GRADE_VALUE = 0, GRADE, OVERRIDE_GRADE_VALUE)
            Dim Gradetouse As String = "0"
            Dim tGradePad As String = Microsoft.VisualBasic.Right("00" & GradeToUse, 1)
            If GradeToUse = 8 Then tGradePad = "0"
            Dim tGradeAndProduct As String = tGradePad & Microsoft.VisualBasic.Right("0000" & tGradePad & lblProductCode.Text, 4)

            'Dim tBarcode As String = tGradePad & tGradeAndProduct & tLBSHundred
            Dim tmpSerialNumber As String = DatabaseHandling.GetNextSerialNumber(MachineInstance.ScaleNumber)
            tmpSerialNumber = tmpSerialNumber.ToString().PadLeft(8, "0")

            Dim tBarcodeText As String = "019630308" & tGradeAndProduct & GetCheckDigitGTIN_13("9630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & PROD_DATE_TO_USE.ToString("yyMMdd") & "21" & MachineInstance.ScaleNumber & tmpSerialNumber
            Dim tBarcodeFooter As String = "(01)9630308" & tGradeAndProduct & GetCheckDigitGTIN_13("9630308" & tGradeAndProduct) & "(3201)" & tLBSHundred & "(11)" & PROD_DATE_TO_USE.ToString("yyMMdd") & "(21)" & MachineInstance.ScaleNumber & tmpSerialNumber

            LAST_BARCODE = tBarcodeText
            LAST_SERIAL = Microsoft.VisualBasic.Right(LAST_BARCODE, 10)


            varTab(1)(availableVariableAssignment.ProductWeightKG) = FormatNumber(nKGS, 2, TriState.UseDefault, TriState.UseDefault, TriState.False)
            varTab(1)(availableVariableAssignment.BarcodeReadable) = tBarcodeFooter
            varTab(1)(availableVariableAssignment.UseFreezeDate) = IIf(tempProductInfo.SellByDay > 0, PROD_DATE_TO_USE.AddDays(tempProductInfo.SellByDay).ToString("MMddyy"), "")
            varTab(1)(availableVariableAssignment.GradeNumber) = ""     'GradeToUse
            varTab(1)(availableVariableAssignment.PackDate) = PROD_DATE_TO_USE.ToString("MMddyy")
            varTab(1)(availableVariableAssignment.ProductDescription2) = TrimToLength(25, tempProductInfo.ProductDescription2)
            varTab(1)(availableVariableAssignment.ScaleNumber) = MachineInstance.ScaleNumber
            varTab(1)(availableVariableAssignment.ProductWeightLB) = FormatNumber(nLBS, 2, TriState.UseDefault, TriState.UseDefault, TriState.False)
            varTab(1)(availableVariableAssignment.BoxCount) = tBoxCount
            varTab(1)(availableVariableAssignment.Barcode128) = tBarcodeText
            varTab(1)(availableVariableAssignment.PrintTime) = PROD_DATE_TO_USE.ToString("hmmt")
            varTab(1)(availableVariableAssignment.ProductDescription) = TrimToLength(30, tempProductInfo.ProductDescription)
            varTab(1)(availableVariableAssignment.Lot) = CURRENT_LOT
            varTab(1)(availableVariableAssignment.ProductCode) = tempProductInfo.ProductCode

            Dim imageLeftTopLocation As String = Environment.CurrentDirectory & "\PrintTemplates\"
            Dim imageMiddleRightLocation As String = Environment.CurrentDirectory & "\PrintTemplates\"
            Select Case tempProductInfo.LabelTemplate
                Case "GB5x3CAB.LBL"
                    imageLeftTopLocation = imageLeftTopLocation & "CAB.bmp"
                    imageMiddleRightLocation = imageMiddleRightLocation & "45834.BUG.bmp"
                Case "GB5x3CHB.LBL"
                    imageLeftTopLocation = imageLeftTopLocation & "classicherford.bmp"
                    imageMiddleRightLocation = imageMiddleRightLocation & "45834.BUG.bmp"
                Case "GB5x3ONA.LBL"
                    imageLeftTopLocation = imageLeftTopLocation & "onalogo.bmp"
                    imageMiddleRightLocation = imageMiddleRightLocation & "960A.BUG.bmp"
                Case "GBOHB5D.LBL"
                    imageLeftTopLocation = imageLeftTopLocation & "herfgb.bmp"
                    imageMiddleRightLocation = imageMiddleRightLocation & "960A.BUG.bmp"
                Case Else
                    'GB5x3.LBL
                    imageLeftTopLocation = imageLeftTopLocation & "chub.bmp"
                    imageMiddleRightLocation = imageMiddleRightLocation & "45834.BUG.bmp"
            End Select

            varTab(1)(availableVariableAssignment.ImageMiddleRightLocation) = imageMiddleRightLocation
            varTab(1)(availableVariableAssignment.ImageTopLeftLocation) = imageLeftTopLocation


            'update variables to activedocument
            UpdateVariablesInActiveLabel()

            'ActiveLabelDocument.WriteVariables(varTab)

        Catch ex As Exception
            WriteToErrorLog("Error", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        Finally
        End Try

        'Return sReturn

    End Sub
    Private Function FillVariablesTabFromActiveLabel() As LabelVariableAssignment
        Dim sLabelStuff As String = ""


        Dim availableVariableAssignment As New LabelVariableAssignment


        Try
            Dim variables As LabelManager2.Variables = ActiveLabelDocument.Variables
            Dim availableVariables As New LabelVariableString

            varTab(0) = New String(Variables.Count) {}
            varTab(1) = New String(Variables.Count) {}
            For i As Integer = 1 To Variables.Count
                Dim item As LabelManager2.Variable = ActiveLabelDocument.Variables.Item(i)

                Select Case item.Name
                    Case availableVariables.Barcode128
                        availableVariableAssignment.Barcode128 = i - 1
                    Case availableVariables.ProductWeightKG
                        availableVariableAssignment.ProductWeightKG = i - 1
                    Case availableVariables.BarcodeReadable
                        availableVariableAssignment.BarcodeReadable = i - 1
                    Case availableVariables.UseFreezeDate
                        availableVariableAssignment.UseFreezeDate = i - 1
                    Case availableVariables.GradeNumber
                        availableVariableAssignment.GradeNumber = i - 1
                    Case availableVariables.PackDate
                        availableVariableAssignment.PackDate = i - 1
                    Case availableVariables.ProductDescription2
                        availableVariableAssignment.ProductDescription2 = i - 1
                    Case availableVariables.ScaleNumber
                        availableVariableAssignment.ScaleNumber = i - 1
                    Case availableVariables.ProductWeightLB
                        availableVariableAssignment.ProductWeightLB = i - 1
                    Case availableVariables.BoxCount
                        availableVariableAssignment.BoxCount = i - 1
                    Case availableVariables.PrintTime
                        availableVariableAssignment.PrintTime = i - 1
                    Case availableVariables.ProductDescription
                        availableVariableAssignment.ProductDescription = i - 1
                    Case availableVariables.Lot
                        availableVariableAssignment.Lot = i - 1
                    Case availableVariables.ProductCode
                        availableVariableAssignment.ProductCode = i - 1
                    Case availableVariables.ImageMiddleRightLocation
                        availableVariableAssignment.ImageMiddleRightLocation = i - 1
                    Case availableVariables.ImageTopLeftLocation
                        availableVariableAssignment.ImageTopLeftLocation = i - 1
                    Case Else
                        WriteToLog("LabelVariables item Not found", item.Name, "", MachineInstance.ScaleNumber)
                End Select

                varTab(0)(i - 1) = (item.Name)
                varTab(1)(i - 1) = (item.Value)


                sLabelStuff = sLabelStuff & item.Name & "," & item.Value & vbCrLf

                Marshal.ReleaseComObject(item)
            Next i

            'WriteToLog("LabelVariables", sLabelStuff, "", MachineInstance.ScaleNumber)

            Marshal.ReleaseComObject(Variables)

        Catch ex As Exception
            WriteToErrorLog("Error", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        Finally


        End Try


        Return availableVariableAssignment

    End Function
    Private Sub UpdateVariablesInActiveLabel()
        Dim variables As LabelManager2.Variables = ActiveLabelDocument.Variables

        For i As Integer = 0 To varTab(0).Length - 2
            Dim item As LabelManager2.Variable = variables.Item(i + 1)
            item.Name = varTab(0)(i)
            item.Value = varTab(1)(i)
            Marshal.ReleaseComObject(item)
        Next i

        Marshal.ReleaseComObject(variables)

    End Sub
    Private Sub PrintLabelBlank()


        Try

            If (Not (ActiveLabelDocument Is Nothing)) Then
                ActiveLabelDocument.Close(False)
                Marshal.ReleaseComObject(ActiveLabelDocument)
                ActiveLabelDocument = Nothing
            End If

            'copy template file to new file and open
            Dim templateFile As String = Environment.CurrentDirectory & "\PrintTemplates\NOCODE.lab"
            If System.IO.File.Exists(templateFile) Then

                Dim csDocuments As LabelManager2.Documents = MyCsApp.Documents
                ActiveLabelDocument = csDocuments.Open(templateFile, False)
                Marshal.ReleaseComObject(csDocuments)
                'Else
                '    MessageBox.Show("No template file", "Stop", MessageBoxButtons.OK)
            End If


            If (ActiveLabelDocument Is Nothing) Then
                'MessageBox.Show("A document must be opened To print!")
                WriteToErrorLog("Error", "No open document", "", "")
                Exit Sub
            End If


            'Dim csDialogs As LabelManager2.Dialogs = MyCsApp.Dialogs
            'Dim csDialog As LabelManager2.Dialog = csDialogs.Item(LabelManager2.enumDialogType.lppxPrinterSelectDialog)
            'csDialog.Show(Me.Handle)
            'Me.Text = MyCsApp.ActivePrinterName
            'Marshal.ReleaseComObject(csDialogs)
            'Marshal.ReleaseComObject(csDialog)

            'AddPrintingHandlers()
            'ActiveLabelDocument.Printer.FullName = ""
            'ActiveLabelDocument.Printer.InitialPrinterName = ""
            'ActiveLabelDocument.Printer.ModelName = "SATO S84-ex (305 dpi)"
            ActiveLabelDocument.Printer.Name = "SATO S84-ex (305 dpi)"

            Dim iSuccess As Integer = ActiveLabelDocument.PrintDocument(1)
            WriteToLog("after print", iSuccess, templateFile, MachineInstance.ScaleNumber)



            'If Not (_BeginPrintingEventRes Is Nothing) Then
            '    listBoxEvents.EndInvoke(_BeginPrintingEventRes)
            '    _BeginPrintingEventRes = Nothing
            'End If

            'If Not (_EndPrintingEventRes Is Nothing) Then
            '    listBoxEvents.EndInvoke(_EndPrintingEventRes)
            '    _EndPrintingEventRes = Nothing
            'End If

            'RemovePrintingHandlers()

            'these don't work....
            'Dim sSuccess As Short = ActiveLabelDocument.SaveAs(outfile)
            'sSuccess = ActiveLabelDocument.Save
            'sSuccess = ActiveLabelDocument.SaveAs("testfile.lab")


            'saves as an image!!! yay!!
            'Dim strSuccess As String = ActiveLabelDocument.CopyImageToFile(8, "BMP", 0, 100, outfile)
            Dim strSuccess As String = ActiveLabelDocument.CopyImageToFile(8, "JPG", 0, 100, templateFile)
            WriteToLog("after save", strSuccess, templateFile, MachineInstance.ScaleNumber)


        Catch ex As Exception
            WriteToErrorLog("Error", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        Finally
        End Try

    End Sub

    Private Sub PrintLabel(outfile As String)


        Try
            If (ActiveLabelDocument Is Nothing) Then
                'MessageBox.Show("A document must be opened To print!")
                WriteToErrorLog("Error", "No open document", "", "")
                Exit Sub
            End If


            'Dim csDialogs As LabelManager2.Dialogs = MyCsApp.Dialogs
            'Dim csDialog As LabelManager2.Dialog = csDialogs.Item(LabelManager2.enumDialogType.lppxPrinterSelectDialog)
            'csDialog.Show(Me.Handle)
            'Me.Text = MyCsApp.ActivePrinterName
            'Marshal.ReleaseComObject(csDialogs)
            'Marshal.ReleaseComObject(csDialog)

            'AddPrintingHandlers()
            'ActiveLabelDocument.Printer.FullName = ""
            'ActiveLabelDocument.Printer.InitialPrinterName = ""
            'ActiveLabelDocument.Printer.ModelName = "SATO S84-ex (305 dpi)"
            ActiveLabelDocument.Printer.Name = "SATO S84-ex (305 dpi)"

            Dim iSuccess As Integer = ActiveLabelDocument.PrintDocument(1)
            WriteToLog("after print", iSuccess, outfile, MachineInstance.ScaleNumber)



            'If Not (_BeginPrintingEventRes Is Nothing) Then
            '    listBoxEvents.EndInvoke(_BeginPrintingEventRes)
            '    _BeginPrintingEventRes = Nothing
            'End If

            'If Not (_EndPrintingEventRes Is Nothing) Then
            '    listBoxEvents.EndInvoke(_EndPrintingEventRes)
            '    _EndPrintingEventRes = Nothing
            'End If

            'RemovePrintingHandlers()

            'these don't work....
            'Dim sSuccess As Short = ActiveLabelDocument.SaveAs(outfile)
            'sSuccess = ActiveLabelDocument.Save
            'sSuccess = ActiveLabelDocument.SaveAs("testfile.lab")


            'saves as an image!!! yay!!
            'Dim strSuccess As String = ActiveLabelDocument.CopyImageToFile(8, "BMP", 0, 100, outfile)
            Dim strSuccess As String = ActiveLabelDocument.CopyImageToFile(8, "JPG", 0, 100, outfile)
            WriteToLog("after save", strSuccess, outfile, MachineInstance.ScaleNumber)


        Catch ex As Exception
            WriteToErrorLog("Error", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        Finally
        End Try

    End Sub

    Private Sub AddTransactionToDB()

        Try

            Dim sSql As String
            sSql = "INSERT INTO LabelPrintLog(PlantID, ShiftID, StationName, LineID, DateProcessed, ProductCode, ProductName, 
                  BoxBarcode, LotBoxCount, Lot, Grade, SetWeightLB, CaptureWeightLB, TareWeightLB, MaxWeightLB, MinWeightLB, ProductLabelWeightLB, ProductionActive)
                  VALUES (@PlantID, @ShiftID, @StationName, @LineID, @DateProcessed, @ProductCode, @ProductName, 
                  @BoxBarcode, @LotBoxCount, @Lot, @Grade, @SetWeightLB, @CaptureWeightLB, @TareWeightLB, @MaxWeightLB, @MinWeightLB, @ProductLabelWeightLB, @ProductionActive)"


            Dim oConn As New SqlConnection
            oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))

            Dim cmd As New SqlCommand
            cmd = New SqlClient.SqlCommand(sSql, oConn)

            cmd.Parameters.AddWithValue("@PlantID", MachineInstance.PlantCode)
            cmd.Parameters.AddWithValue("@ShiftID", lblShiftDisplay.Text)
            cmd.Parameters.AddWithValue("@StationName", MachineInstance.ScaleName)
            cmd.Parameters.AddWithValue("@LineID", MachineInstance.ScaleNumber)
            cmd.Parameters.AddWithValue("@DateProcessed", Convert.ToDateTime(PROD_DATE_TO_USE.ToString("yyyy-MM-dd HH:mm:ss")))
            cmd.Parameters.AddWithValue("@ProductCode", lblProductCode.Text)
            cmd.Parameters.AddWithValue("@ProductName", lblProductDesc.Text)
            cmd.Parameters.AddWithValue("@BoxBarcode", LAST_BARCODE)
            cmd.Parameters.AddWithValue("@LotBoxCount", BOX_COUNT_LOT)
            cmd.Parameters.AddWithValue("@Lot", CURRENT_LOT)
            cmd.Parameters.AddWithValue("@Grade", GRADE)
            cmd.Parameters.AddWithValue("@SetWeightLB", FixNullDecimal(txtSetWeight.Text))
            cmd.Parameters.AddWithValue("@CaptureWeightLB", FixNullDecimal(txtGrossWeight.Text))
            cmd.Parameters.AddWithValue("@TareWeightLB", FixNullDecimal(txtTare.Text))
            cmd.Parameters.AddWithValue("@MaxWeightLB", FixNullDecimal(txtMaxWeight.Text))
            cmd.Parameters.AddWithValue("@MinWeightLB", FixNullDecimal(txtMinWeight.Text))
            cmd.Parameters.AddWithValue("@ProductLabelWeightLB", CURRENT_PRODUCT_LABEL_NET_WEIGHT)
            cmd.Parameters.AddWithValue("@ProductionActive", PROD_ACTIVE)
            'cmd.Parameters.AddWithValue("@FreezeBy", "")    '???

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        End Try

    End Sub
    'Private Sub CreateInfoForAlpha()

    '    'creating a flat file for Alpha to pick up and pull into the system for inventory

    '    Using sr As New System.IO.StreamWriter(MachineInstance.AlphaLogFileLocation & Convert.ToDateTime(PROD_DATE_TO_USE.ToString("MMddyyyy")) & ".txt", True)
    '        sr.WriteLine(PROD_DATE_TO_USE.ToString("MM/dd/yyyy HH:mm") & "," & LAST_BARCODE & "," & CUSTOMER)
    '    End Using
    '    'Using sr As New System.IO.StreamWriter(AppSettings("logfile2") & Format(PROD_DATE_TO_USE.ToString("MMddyyyy")) & ".txt", True)
    '    '    sr.WriteLine(PROD_DATE_TO_USE.ToString("MM/dd/yyyy HH:mm") & "," & LAST_BARCODE & "," & CUSTOMER)
    '    'End Using

    'End Sub
    'Private Function IsKickoutBox(tempProductInfo As ProductInfo) As Boolean
    '    IsKickoutBox = False
    '    If tempProductInfo.KickoutCount > 0 And BOX_COUNT_LOT > 0 Then
    '        If (BOX_COUNT_LOT Mod tempProductInfo.KickoutCount) = 0 Then IsKickoutBox = True
    '    End If
    'End Function
    Private Sub btnSetWeightPrint_Click(sender As Object, e As EventArgs) Handles btnSetWeightPrint.Click
        'button only available in testing mode
        If AppSettings("InTest") = "TRUE" Then
            Dim random As New Random
            txtGrossWeight.Text = random.Next(7, 100)
            WriteToLog("Print button hit", txtGrossWeight.Text, "", MachineInstance.ScaleNumber)
        End If

        PrintLabelBlank()

        HandleAllPrinting(txtGrossWeight.Text)
    End Sub
    Private Sub btnMakeFavorite_Click(sender As Object, e As EventArgs) Handles btnMakeFavorite.Click
        If btnMakeFavorite.Text.Contains("Make Favorite") Or btnMakeFavorite.Text.Contains("Hacer Favorito") Then
            If FavoriteProductList.Count >= 12 Then
                MsgBox("Only 12 favorites allowed. " & vbCrLf & "Please remove a code before adding a new one.", vbOKOnly, "Too Many Favorites")
                'Solo 12 usuarios son permitidos

            Else
                'add product code to favorites db 

                DatabaseHandling.MakeProductFavorite(MachineInstance.ScaleName, MachineInstance.ScaleNumber, lblProductCode.Text)
                If btnToggleLanguage.Text = "English" Then
                    btnMakeFavorite.Text = "Eliminar Favorito"
                Else
                    btnMakeFavorite.Text = "Remove Favorite"
                End If
            End If
        Else
            'remove product code to favorites db 
            DatabaseHandling.RemoveProductFavorite(MachineInstance.ScaleName, MachineInstance.ScaleNumber, lblProductCode.Text)
            If btnToggleLanguage.Text = "English" Then
                btnMakeFavorite.Text = "Hacer Favorito"
            Else
                btnMakeFavorite.Text = "Make Favorite"
            End If
        End If

        SetFavoriteKeys()
    End Sub
    Private Sub btnF1Fave_Click(sender As Object, e As EventArgs) Handles btnF1Fave.Click
        lblProductCode.Text = FixButtonText(btnF1Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF2Fave_Click(sender As Object, e As EventArgs) Handles btnF2Fave.Click
        lblProductCode.Text = FixButtonText(btnF2Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF3Fave_Click(sender As Object, e As EventArgs) Handles btnF3Fave.Click
        lblProductCode.Text = FixButtonText(btnF3Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF4Fave_Click(sender As Object, e As EventArgs) Handles btnF4Fave.Click
        lblProductCode.Text = FixButtonText(btnF4Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF5Fave_Click(sender As Object, e As EventArgs) Handles btnF5Fave.Click
        lblProductCode.Text = FixButtonText(btnF5Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF6Fave_Click(sender As Object, e As EventArgs) Handles btnF6Fave.Click
        lblProductCode.Text = FixButtonText(btnF6Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF7Fave_Click(sender As Object, e As EventArgs) Handles btnF7Fave.Click
        lblProductCode.Text = FixButtonText(btnF7Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF8Fave_Click(sender As Object, e As EventArgs) Handles btnF8Fave.Click
        lblProductCode.Text = FixButtonText(btnF8Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF9Fave_Click(sender As Object, e As EventArgs) Handles btnF9Fave.Click
        lblProductCode.Text = FixButtonText(btnF9Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF10Fave_Click(sender As Object, e As EventArgs) Handles btnF10Fave.Click
        lblProductCode.Text = FixButtonText(btnF10Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF11Fave_Click(sender As Object, e As EventArgs) Handles btnF11Fave.Click
        lblProductCode.Text = FixButtonText(btnF11Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub btnF12Fave_Click(sender As Object, e As EventArgs) Handles btnF12Fave.Click
        lblProductCode.Text = FixButtonText(btnF12Fave.Text)
        SetDisplay(lblProductCode.Text)
    End Sub
    Private Sub GetCounts()

        Dim oConn As New SqlConnection

        Try
            oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))
            Dim sSQL As String = ""
            Dim cmd As New SqlCommand

            sSQL = "SELECT COUNT(PlantID) AS CountReturn From LabelPrintLog Where (ShiftID = '" & lblShiftDisplay.Text & "') AND (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST('" & PROD_DATE_TO_USE & "' AS date)) AND ProductionActive = '" & PROD_ACTIVE & "'"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            PRODUCT_COUNT_SHIFT = cmd.ExecuteScalar
            cmd.Dispose()

            sSQL = "SELECT COUNT(PlantID) AS CountReturn From LabelPrintLog Where (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST('" & PROD_DATE_TO_USE & "' AS date)) AND ProductionActive = '" & PROD_ACTIVE & "'"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            PRODUCT_COUNT_DAILY = cmd.ExecuteScalar
            cmd.Dispose()

            If PRODUCT_COUNT_SHIFT = 0 Then
                WEIGHT_TOTAL_SHIFT = 0
            Else
                sSQL = "SELECT SUM(CAST(CaptureWeightLB AS decimal)) AS WeightReturn From LabelPrintLog Where (ShiftID = '" & lblShiftDisplay.Text & "') AND (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST('" & PROD_DATE_TO_USE & "' AS date)) AND ProductionActive = '" & PROD_ACTIVE & "'"
                cmd = New SqlClient.SqlCommand(sSQL, oConn)
                WEIGHT_TOTAL_SHIFT = cmd.ExecuteScalar
                cmd.Dispose()
            End If

            If PRODUCT_COUNT_DAILY = 0 Then
                WEIGHT_TOTAL_DAILY = 0
            Else
                sSQL = "SELECT SUM(CAST(CaptureWeightLB AS decimal)) AS WeightReturn From LabelPrintLog Where (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST('" & PROD_DATE_TO_USE & "' AS date)) AND ProductionActive = '" & PROD_ACTIVE & "'"
                cmd = New SqlClient.SqlCommand(sSQL, oConn)
                WEIGHT_TOTAL_DAILY = cmd.ExecuteScalar
                cmd.Dispose()
            End If

            BOX_TOTAL_SHIFT = PRODUCT_COUNT_SHIFT
            BOX_TOTAL_DAILY = PRODUCT_COUNT_DAILY

        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
        Finally
            oConn.Close()
        End Try

    End Sub
    Private Function GetLotBoxCountCurrent() As Integer
        'MachineInstance.ScaleNumber, lblProductCode.Text, CURRENT_LOT, PROD_DATE_TO_USE
        Dim oConn As New SqlConnection
        Dim iReturn As Integer = 0

        Try
            oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))
            Dim sSQL As String = ""
            Dim cmd As New SqlCommand

            'get highest number entered and add 1.  Count doesn't work correctly
            'sSQL = "SELECT COUNT(PlantID) AS BoxesInLot From LabelPrintLog Where (LineID = '" & scaleNumber & "') AND (ProductCode = '" & productCode & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date)) AND Lot = '" & lot & "'"
            'sSQL = "SELECT LotBoxCount From LabelPrintLog Where (LineID = '" & scaleNumber & "') AND (ProductCode = '" & productCode & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date)) AND Lot = '" & lot & "' AND ProductionActive = 'True' order by LotBoxCount Desc"
            sSQL = "SELECT LotBoxCount From LabelPrintLog Where (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST('" & PROD_DATE_TO_USE & "' AS date)) AND Lot = '" & CURRENT_LOT & "' AND ProductionActive = '" & PROD_ACTIVE & "' order by LotBoxCount Desc"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            iReturn = cmd.ExecuteScalar
            cmd.Dispose()


        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error", MachineInstance.ScaleNumber)
        Finally
            oConn.Close()
        End Try

        Return iReturn

    End Function
    Private Sub btnProductLookup_Click(sender As Object, e As EventArgs) Handles btnProductLookup.Click
        Dim KeyboardLookup As frmKeyboard = New frmKeyboard
        KeyboardLookup.SetProductList(ProductList)
        KeyboardLookup.ShowDialog()

        SetDisplay(KeyboardLookup.ChosenProductCode)
    End Sub
    Private Sub SetFavoriteKeys()


        FavoriteProductList = DatabaseHandling.GetFavoriteProductList(MachineInstance.ScaleName, MachineInstance.ScaleNumber)


        btnF1Fave.Text = ""
        btnF1Fave.Enabled = False
        btnF2Fave.Text = ""
        btnF2Fave.Enabled = False
        btnF3Fave.Text = ""
        btnF3Fave.Enabled = False
        btnF4Fave.Text = ""
        btnF4Fave.Enabled = False
        btnF5Fave.Text = ""
        btnF5Fave.Enabled = False
        btnF6Fave.Text = ""
        btnF6Fave.Enabled = False
        btnF7Fave.Text = ""
        btnF7Fave.Enabled = False
        btnF8Fave.Text = ""
        btnF8Fave.Enabled = False
        btnF9Fave.Text = ""
        btnF9Fave.Enabled = False
        btnF10Fave.Text = ""
        btnF10Fave.Enabled = False
        btnF11Fave.Text = ""
        btnF11Fave.Enabled = False
        btnF12Fave.Text = ""
        btnF12Fave.Enabled = False


        Dim iCount As Integer = 1
        For Each item In FavoriteProductList
            Select Case iCount
                Case 1
                    btnF1Fave.Text = vbCrLf & item
                    btnF1Fave.Enabled = True
                Case 2
                    btnF2Fave.Text = vbCrLf & item
                    btnF2Fave.Enabled = True
                Case 3
                    btnF3Fave.Text = vbCrLf & item
                    btnF3Fave.Enabled = True
                Case 4
                    btnF4Fave.Text = vbCrLf & item
                    btnF4Fave.Enabled = True
                Case 5
                    btnF5Fave.Text = vbCrLf & item
                    btnF5Fave.Enabled = True
                Case 6
                    btnF6Fave.Text = vbCrLf & item
                    btnF6Fave.Enabled = True
                Case 7
                    btnF7Fave.Text = vbCrLf & item
                    btnF7Fave.Enabled = True
                Case 8
                    btnF8Fave.Text = vbCrLf & item
                    btnF8Fave.Enabled = True
                Case 9
                    btnF9Fave.Text = vbCrLf & item
                    btnF9Fave.Enabled = True
                Case 10
                    btnF10Fave.Text = vbCrLf & item
                    btnF10Fave.Enabled = True
                Case 11
                    btnF11Fave.Text = vbCrLf & item
                    btnF11Fave.Enabled = True
                Case 12
                    btnF12Fave.Text = vbCrLf & item
                    btnF12Fave.Enabled = True
            End Select

            iCount += 1
        Next

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        'constantly updates the time onscreen
        lblTimeDisplay.Text = CStr(TimeValue(CStr(Now)))
    End Sub
    Private Sub btnToggleLanguage_Click(sender As Object, e As EventArgs) Handles btnToggleLanguage.Click
        If btnToggleLanguage.Text = "Español" Then
            Dim LanguageToUse As New TranslateToSpanish

            lblPlant.Text = LanguageToUse.Plant
            lblStation.Text = LanguageToUse.Station
            lblShift.Text = LanguageToUse.Shift
            lblDate.Text = LanguageToUse.DateLabel
            lblDay.Text = LanguageToUse.Day
            lblTime.Text = LanguageToUse.Time

            lblGrossWeight.Text = LanguageToUse.GrossWeight
            lblSetWeight.Text = LanguageToUse.SetWeight
            lblTare.Text = LanguageToUse.Tare
            lblNetWeight.Text = LanguageToUse.NetWeight
            lblMin.Text = LanguageToUse.Min
            lblMax.Text = LanguageToUse.Max

            lblCurrentShift.Text = LanguageToUse.CurrentShift
            lblDailyTotal.Text = LanguageToUse.DailyTotal
            lblProductCount.Text = LanguageToUse.ProductCount
            lblBoxesPerShift.Text = LanguageToUse.BoxesPerShift
            lblWeightTotal.Text = LanguageToUse.WeightTotal
            lblSerial.Text = LanguageToUse.Serial

            grpTotalsPerProduct.Text = LanguageToUse.TotalsPerProduct
            grpFavorites.Text = LanguageToUse.Favorites

            btnExit.Text = LanguageToUse.ExitLabel
            btnProductLookup.Text = LanguageToUse.ProductLookup
            btnSetWeightPrint.Text = LanguageToUse.SetWeightPrint
            btnMakeFavorite.Text = LanguageToUse.MakeFavorite
            btnProdActive.Text = LanguageToUse.ProdActive
            btnToggleLanguage.Text = LanguageToUse.ToggleLanguage

            'lblBoxesInLot.Text = LanguageToUse.BoxesInLot
            'lblLot.Text = LanguageToUse.Lot
            'lblGrade.Text = LanguageToUse.Grade
            'btnScanCombo.Text = LanguageToUse.ScanCombo
            'btnChangeLot.Text = LanguageToUse.ChangeLot


        Else
            Dim LanguageToUse As New TranslateToEnglish

            lblPlant.Text = LanguageToUse.Plant
            lblStation.Text = LanguageToUse.Station
            lblShift.Text = LanguageToUse.Shift
            lblDate.Text = LanguageToUse.DateLabel
            lblDay.Text = LanguageToUse.Day
            lblTime.Text = LanguageToUse.Time

            lblGrossWeight.Text = LanguageToUse.GrossWeight
            lblSetWeight.Text = LanguageToUse.SetWeight
            lblTare.Text = LanguageToUse.Tare
            lblNetWeight.Text = LanguageToUse.NetWeight
            lblMin.Text = LanguageToUse.Min
            lblMax.Text = LanguageToUse.Max

            lblCurrentShift.Text = LanguageToUse.CurrentShift
            lblDailyTotal.Text = LanguageToUse.DailyTotal
            lblProductCount.Text = LanguageToUse.ProductCount
            lblBoxesPerShift.Text = LanguageToUse.BoxesPerShift
            lblWeightTotal.Text = LanguageToUse.WeightTotal
            lblSerial.Text = LanguageToUse.Serial

            grpTotalsPerProduct.Text = LanguageToUse.TotalsPerProduct
            grpFavorites.Text = LanguageToUse.Favorites

            btnExit.Text = LanguageToUse.ExitLabel
            btnProductLookup.Text = LanguageToUse.ProductLookup
            btnSetWeightPrint.Text = LanguageToUse.SetWeightPrint
            btnMakeFavorite.Text = LanguageToUse.MakeFavorite
            btnProdActive.Text = LanguageToUse.ProdActive
            btnToggleLanguage.Text = LanguageToUse.ToggleLanguage

            'lblBoxesInLot.Text = LanguageToUse.BoxesInLot
            'lblLot.Text = LanguageToUse.Lot
            'lblGrade.Text = LanguageToUse.Grade
            'btnScanCombo.Text = LanguageToUse.ScanCombo
            'btnChangeLot.Text = LanguageToUse.ChangeLot

        End If

    End Sub
    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        'e.SuppressKeyPress = True
        'If e.KeyCode = Keys.F1 Then
        '    txtWarnings.AppendText("F1 was pressed!" & Environment.NewLine)
        'End If
    End Sub
    Private Sub KeyDownHandler(ByVal o As Object, ByVal e As KeyEventArgs)
        e.SuppressKeyPress = True

        Select Case e.KeyValue
            Case Keys.F1
                btnF1Fave.PerformClick()
            Case Keys.F2
                btnF2Fave.PerformClick()
            Case Keys.F3
                btnF3Fave.PerformClick()
            Case Keys.F4
                btnF4Fave.PerformClick()
            Case Keys.F5
                btnF5Fave.PerformClick()
            Case Keys.F6
                btnF6Fave.PerformClick()
            Case Keys.F7
                btnF7Fave.PerformClick()
            Case Keys.F8
                btnF8Fave.PerformClick()
            Case Keys.F9
                btnF9Fave.PerformClick()
            Case Keys.F10
                btnF10Fave.PerformClick()
            Case Keys.F11
                btnF11Fave.PerformClick()
            Case Keys.F12
                btnF12Fave.PerformClick()
                'Case Keys.W
                'Dim fManual As New frmEditWeight
                'fManual.ShowDialog()
                'If fManual.EnteredWeight > 0 Then
                '    BuildFileAndPrint(fManual.EnteredWeight)
                'End If
                'fManual.Dispose()
                'Case Keys.T
                'Dim fTare As New frmEditTare
                'fTare.ShowDialog()
                'fTare.Close()
                'fTare.Dispose()
            Case Else
                'do nothing
        End Select



        'txtWarnings.AppendText(
        'String.Format("down '{0}' '{1}' '{2}' '{3}' {4}", e.Modifiers, e.KeyValue, e.KeyData, e.KeyCode, Environment.NewLine))
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmScaleGrinding_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        WriteToLog("Program End", Environment.MachineName, "Program End", MachineInstance.ScaleNumber)
        WriteToLog("", "", "", MachineInstance.ScaleNumber)
    End Sub
End Class