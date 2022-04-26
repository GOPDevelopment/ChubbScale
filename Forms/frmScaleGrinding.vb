Imports System.Globalization
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.IO.Ports
Imports System.Data.SqlClient

Public Class frmScaleGrinding

    Private Property SCALE_NAME As String = "GRINDING"
    Private Property PROD_LINE As String = "11"

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
    Private Property GRADE As String = "3"
    Private Property CUSTOMER As String = "00"
    Private Property LAST_GROSS_WEIGHT As Single = 0
    Private Property OVERRIDE_GRADE_VALUE As Integer = 4
    Private Property CURRENT_TEST_NO As String = ""
    Private Property LAST_BARCODE As String = ""
    Private Property LAST_SERIAL As String = ""


    Private WithEvents ScaleInstance As New SerialPort
    Private Property UserInfo As ProgramUser
    Private Property MachineInstance As MachineInfo
    Private Property EntireScaleMessage As String = ""


    Public Sub New(ByVal PassedUserInfo As ProgramUser, ByVal PassedMachineInstance As MachineInfo)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UserInfo = PassedUserInfo
        MachineInstance = PassedMachineInstance
    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.CenterToScreen()

            Me.KeyPreview = True
            AddHandler Me.KeyDown, AddressOf KeyDownHandler
            AddHandler Me.KeyUp, AddressOf KeyUpHandler


            'starting time to update this time display box
            Me.Timer1.Interval = 1000
            Me.Timer1.Start()

            'Tue Jun / 01 / 2002
            If Login.nudDayNum.Value <> 0 Then
                lblDateDisplay.Text = DateTime.Now.AddDays(Login.nudDayNum.Value).ToString("ddd MMM / dd / yyyy")
                lblDayDisplay.Text = DateTime.Now.AddDays(Login.nudDayNum.Value).DayOfYear.ToString
            Else
                lblDateDisplay.Text = DateTime.Now.ToString("ddd MMM / dd / yyyy")
                lblDayDisplay.Text = DateTime.Now.DayOfYear.ToString
            End If
            lblTimeDisplay.Text = DateTime.Now.ToString("h:mm:ss tt")

            If Login.rdo1stShift.Checked Then
                lblShiftDisplay.Text = "1st"
            Else
                lblShiftDisplay.Text = "2nd"
            End If
            lblStationDisplay.Text = MachineInstance.ScaleNumber & " - " & MachineInstance.ScaleName
            lblPlantDisplay.Text = MachineInstance.PlantCode


            'DatabaseHandling.ResetDailyPrintCounter()


            'get product list and store
            ProductList = DatabaseHandling.GetProductList(MachineInstance.ScaleName)
            If ProductList.Count < 1 Then
                MsgBox("No Product Codes loaded for this scale, contact IT.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "No Product Codes")
            End If

            'get favorite product list and set buttons
            SetFavoriteKeys()

            'initialize scale port
            Dim scalePort As New ScalePortInfo
            ScaleInstance = scalePort.ScalePort

            'initialize label printer
            InitializePrinter(MachineInstance)

            'set intial display fields
            SetDisplay("00000")
            btnMakeFavorite.Text = "Remove Favorite"


            If AppSettings("InTest") = "TRUE" Then
                btnSetWeightPrint.Visible = True
            Else
                btnSetWeightPrint.Visible = False
            End If

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub


    'Private Sub btnResetLot_Click(sender As Object, e As EventArgs) Handles btnResetLot.Click
    '    Try
    '        Dim response = MsgBox("Are you sure you want to End/Reset Lot?  Press Cancel to keep Lot", vbOKCancel)

    '        If response = MsgBoxResult.Ok Then
    '            BOX_COUNT_LOT = 0
    '            CURRENT_LOT = 0
    '            DatabaseHandling.ResetCount(lblProductCode.Text)
    '            'Try
    '            '    cmd.CommandText = "Exec [sp_tblProduct_update_Lot] " & CheckString(lblProductCode.Text) & "," & CURRENT_LOT
    '            '    cmd.ExecuteNonQuery()

    '            '    MsgBox("Lot updated.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Update Successful")
    '            '    ' Me.Close()

    '            'Catch ex As Exception
    '            '    MsgBox("Unable to update." & vbCrLf & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Database Error")
    '            'End Try
    '            lblLot.Text = CURRENT_LOT
    '            lblBoxesInLot.Text = BOX_COUNT_LOT
    '        End If
    '    Catch ex As Exception
    '        WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
    '    End Try

    'End Sub
    'Private Sub btnIncreaseLot_Click(sender As Object, e As EventArgs) Handles btnIncreaseLot.Click
    '    Try
    '        Dim response = MsgBox("Are you sure you want to Advance/Increase Lot?  Press Cancel to keep Lot", vbOKCancel)

    '        If response = MsgBoxResult.Ok Then
    '            'cmd.CommandText = "Exec sp_tblProduct_count_reset"
    '            'Try
    '            '    cmd.ExecuteNonQuery()

    '            'Catch ex As Exception
    '            '    MsgBox("There was a problem resetting the counters." & vbCrLf & ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Reset Daily Counters")

    '            'End Try
    '            BOX_COUNT_LOT = 0
    '            CURRENT_LOT = CURRENT_LOT + 1
    '            DatabaseHandling.UpdateLot(lblProductCode.Text, CURRENT_LOT)

    '            lblLot.Text = CURRENT_LOT
    '            lblBoxesInLot.Text = BOX_COUNT_LOT
    '        End If
    '    Catch ex As Exception
    '        WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
    '    End Try

    'End Sub
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

    Private Sub SetDisplay(ProductCodePassed As String)
        'load initial or passed lookup


        ''set user or scale specific settings
        'If UserInfo.isBasicUser Then
        '    btnResetLot.Enabled = False
        'Else
        '    btnResetLot.Enabled = True
        'End If



        'If MachineInstance.ScaleName = "TONGUES" Then
        '    btnIncreaseLot.Enabled = False
        '    btnResetLot.Enabled = False

        'End If



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


            'count for each scan

            lblProductCountShift.Text = PRODUCT_COUNT_SHIFT
            lblProductCountDaily.Text = PRODUCT_COUNT_DAILY

            lblWeightTotalShift.Text = WEIGHT_TOTAL_SHIFT
            lblWeightTotalDaily.Text = WEIGHT_TOTAL_DAILY

            lblBoxTotalShift.Text = BOX_TOTAL_SHIFT
            lblBoxTotalDaily.Text = BOX_TOTAL_DAILY


            If txtGrossWeight.Text <> "0" And txtGrossWeight.Text <> "" Then
                txtWarnings.Text = GetWarnings()
            End If

            If FavoriteProductList.Contains(tempProductInfo.ProductCode) Then
                btnMakeFavorite.Text = "Remove Favorite"
            Else
                btnMakeFavorite.Text = "Make Favorite"
            End If

        End If


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        WriteToLog("Program End", "", "Program End")
        Me.Close()
    End Sub
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

    Private Function GetWarnings() As String
        Dim warningReturn As String = ""
        If txtGrossWeight.Text <> "" And txtGrossWeight.Text <> "0" Then
            If FixNullInteger(txtGrossWeight.Text) > CInt(txtMaxWeight.Text) Then
                warningReturn = "OVER MAX WEIGHT"
            End If

            If FixNullInteger(txtGrossWeight.Text) < CInt(txtMinWeight.Text) Then
                warningReturn = "UNDER MIN WEIGHT"
            End If
        End If

        Return warningReturn
    End Function
    'Private Function FixButtonText(sValue As String) As String
    '    Return sValue.Replace(vbCrLf, "").Replace(" ", "")
    'End Function

    Private Sub btnProdActive_Click(sender As Object, e As EventArgs) Handles btnProdActive.Click
        If btnToggleLanguage.Text = "English" Then
            'if it says English then the screen is in spanish
            If btnProdActive.Text = "Producción Activa" Then
                btnProdActive.Text = "Producción Inactivo"
                PROD_ACTIVE = False
            Else
                btnProdActive.Text = "Producción Activa"
                PROD_ACTIVE = True
            End If
        Else
            'if it says espanol then the screen is in english
            If btnProdActive.Text = "Production Active" Then
                btnProdActive.Text = "Production Inactive"
                PROD_ACTIVE = False
            Else
                btnProdActive.Text = "Production Active"
                PROD_ACTIVE = True
            End If
        End If

    End Sub


    Private Function BuildLabelContentGrinding(ByVal nLBS As Single, ByVal iBoxCount As Integer) As String

        Dim LabelOutput As String = ""
        'BuildLabelContentTrim = ""

        Try

            Dim tempProductInfo As New ProductInfo
            tempProductInfo = DatabaseHandling.LookupSpecificProduct(lblProductCode.Text, ProductList)




            'If setweight <> 0 Then nLBS = setweight
            'lblProductWeight.Text = FormatNumber(nLBS, 1) & " LBS   Tare " & Math.Round(LastGrossWeight - nLBS, 2)

            Dim GradeToUse As Integer = IIf(OVERRIDE_GRADE_VALUE = 0, GRADE, OVERRIDE_GRADE_VALUE)

            Dim nKGS As Single = nLBS * CSng(AppSettings("KiloConversionRate"))
            'Dim tLBSHundred As String = Microsoft.VisualBasic.Right("000000" & FormatNumber(nLBS * 100, 0, TriState.UseDefault, TriState.UseDefault, TriState.False), 6)
            ' Lop off the "last digit"
            Dim wrkNumber As String = FormatNumber((Math.Round(nLBS, 1)) * 100, 0, TriState.UseDefault, TriState.UseDefault, TriState.False)
            Dim tLBSHundred As String = Microsoft.VisualBasic.Right("000000" & wrkNumber.Substring(0, wrkNumber.Length - 1), 6)
            Dim tBoxCount As String
            If tempProductInfo.Lot <> 0 Then
                tBoxCount = Microsoft.VisualBasic.Right("0000" & iBoxCount, 4) & "-" & MachineInstance.ScaleNumber & IIf(IsKickoutBox(tempProductInfo), "+", "") & "  Lot " & tempProductInfo.Lot
            Else
                tBoxCount = Microsoft.VisualBasic.Right("0000" & iBoxCount, 4) & "-" & MachineInstance.ScaleNumber & IIf(IsKickoutBox(tempProductInfo), "+", "")
            End If


            Dim tGradePad As String = Microsoft.VisualBasic.Right("00" & GradeToUse, 1)
            If GradeToUse = 8 Then
                tGradePad = "0"
            End If
            Dim tGradeAndProduct As String = tGradePad & Microsoft.VisualBasic.Right("0000" & tGradePad & lblProductCode.Text, 4)

            'Dim tBarcode As String = tGradePad & tGradeAndProduct & tLBSHundred
            Dim tmpSerialNumber As String = DatabaseHandling.GetNextSerialNumber(MachineInstance.ScaleNumber)
            tmpSerialNumber = tmpSerialNumber.ToString().PadLeft(9, "0")

            '   Dim tBarcodeText As String = "0190630308" & tGradeAndProduct & GetCheckDigitGTIN_13("90630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & Now.ToString("yyMMdd") & "21" & ProductionLineNumber & tmpSerialNumber
            '  Dim tBarcodeFooter As String = "(01)90630308" & tGradeAndProduct & GetCheckDigitGTIN_13("90630308" & tGradeAndProduct) & "(3201)" & tLBSHundred & "(11)" & Now.ToString("yyMMdd") & "(21)" & ProductionLineNumber & tmpSerialNumber

            ' Debug.Print(tBarcodeText)

            Dim tBarcodeText As String = "019630308" & tGradeAndProduct & GetCheckDigitGTIN_13("9630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & Now.ToString("yyMMdd") & "21" & MachineInstance.ScaleNumber & tmpSerialNumber
            Dim tBarcodeFooter As String = "(01)9630308" & tGradeAndProduct & GetCheckDigitGTIN_13("9630308" & tGradeAndProduct) & "(3201)" & tLBSHundred & "(11)" & Now.ToString("yyMMdd") & "(21)" & MachineInstance.ScaleNumber & tmpSerialNumber

            'Dim tBarcodeText As String = "019630308" & "009272" & GetCheckDigitGTIN_13("90630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & Now.ToString("yyMMdd") & "21" & MachineInstance.ScaleNumber & tmpSerialNumber
            'Dim tBarcodeFooter As String = "019630308" & "009272" & GetCheckDigitGTIN_13("90630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & Now.ToString("yyMMdd") & "21" & MachineInstance.ScaleNumber & tmpSerialNumber
            'Dim tBarcodeText As String = "0190630308" & "123456" & GetCheckDigitGTIN_13("90630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & Now.ToString("yyMMdd") & "21" & "101234567"
            'Dim tBarcodeFooter As String = "0190630308" & "123456" & GetCheckDigitGTIN_13("90630308" & tGradeAndProduct) & "3201" & tLBSHundred & "11" & Now.ToString("yyMMdd") & "21" & "101234567"
            LAST_BARCODE = tBarcodeText

            LabelOutput = System.IO.File.ReadAllText(Environment.CurrentDirectory & AppSettings("PrintTemplateLocation_Grinding"))    'PrintTemplate
            Dim tstspc As Integer = Math.Round((55 - Len(tempProductInfo.ProductDescription)) / 1.5, 0)
            Dim currenttestnohold As String = tempProductInfo.ProductDescription
            If tstspc > 1 Then
                currenttestnohold = tempProductInfo.ProductDescription
                For x = 1 To tstspc
                    tempProductInfo.ProductDescription = " " & tempProductInfo.ProductDescription
                Next
            End If
            LabelOutput = LabelOutput.Replace("<<proddesc>>", tempProductInfo.ProductDescription)
            tempProductInfo.ProductDescription = currenttestnohold

            LabelOutput = LabelOutput.Replace("<<HEADER_WEIGHT_KGS>>", FormatNumber(nKGS, 2, TriState.UseDefault, TriState.UseDefault, TriState.False))
            LabelOutput = LabelOutput.Replace("<<HEADER_WEIGHT_LBS>>", FormatNumber(nLBS, 2, TriState.UseDefault, TriState.UseDefault, TriState.False))

            If GradeToUse = 8 Then
                LabelOutput = LabelOutput.Replace("<<BIG_GRADE>>", "")
            Else
                LabelOutput = LabelOutput.Replace("<<BIG_GRADE>>", GradeToUse)
            End If

            If CURRENT_TEST_NO = "0" And GradeToUse = 1 Then
                CURRENT_TEST_NO = "   BEEF USDA CERTIFIED ANGUS"
            End If
            If CURRENT_TEST_NO = "0" And GradeToUse = 2 Then
                CURRENT_TEST_NO = "  BEEF USDA SELECT "
            End If
            If CURRENT_TEST_NO = "0" And GradeToUse = 3 Then
                CURRENT_TEST_NO = "  BEEF USDA CHOICE "
            End If
            If CURRENT_TEST_NO = "0" And GradeToUse = 5 Then
                CURRENT_TEST_NO = "  BEEF USDA PRIME "
            End If
            If CURRENT_TEST_NO = "0" And GradeToUse = 6 Then
                CURRENT_TEST_NO = "  BEEF USDA CERTIFIED HERFORD "
            End If


            If CURRENT_TEST_NO = "0" Then CURRENT_TEST_NO = ""
            tstspc = Math.Round((32 - Len(CURRENT_TEST_NO)) / 1.5, 0)
            currenttestnohold = CURRENT_TEST_NO
            If tstspc > 1 Then
                currenttestnohold = CURRENT_TEST_NO
                For x = 1 To tstspc
                    CURRENT_TEST_NO = " " & CURRENT_TEST_NO
                Next
            End If
            LabelOutput = LabelOutput.Replace("<<Testno>>", CURRENT_TEST_NO)
            CURRENT_TEST_NO = currenttestnohold

            LabelOutput = LabelOutput.Replace("<<BOX_COUNT>>", tBoxCount)
            LabelOutput = LabelOutput.Replace("<<MMDDYY>>", CheckString(Now.ToString("MMddyy")))
            LabelOutput = LabelOutput.Replace("<<PRINT_TIME>>", Now.ToString("hmmt"))
            'If productionact <> 0 Then
            LabelOutput = LabelOutput.Replace("<<BARCODE_TEXT>>", tBarcodeText)
            'Else
            'LabelOutput = LabelOutput.Replace("<<BARCODE_TEXT>>", "")
            'End If
            LabelOutput = LabelOutput.Replace("<<BARCODE_FOOTER>>", tBarcodeFooter)
            LabelOutput = LabelOutput.Replace("<<PRODUCT_CODE>>", tempProductInfo.ProductCode)

            'BuildLabelContent = BuildLabelContent.Replace("<<BARCODE_GRADE>>", tGradePad)
            'BuildLabelContent = BuildLabelContent.Replace("<<BARCODE_GRADE_AND_PRODUCT_CODE>>", tGradeAndProduct)
            'BuildLabelContent = BuildLabelContent.Replace("<<BARCODE_PRODUCT_WEIGHT>>", tLBSHundred)

            ' Gross is the net plus the weight of the packaging....
            Dim tGrossLBS As String = FormatNumber(LAST_GROSS_WEIGHT, 1)
            Dim tGrossKGS As String = FormatNumber(LAST_GROSS_WEIGHT * CSng(System.Configuration.ConfigurationManager.AppSettings("KiloConversionRate")), 1)
            LabelOutput = LabelOutput.Replace("<<TOP_MINI_GROSS_LBS>>", tGrossLBS)
            LabelOutput = LabelOutput.Replace("<<TOP_MINI_GROSS_KGS>>", tGrossKGS)

            'LastBarCodeText = tBarcodeText

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        Finally
        End Try

        Return LabelOutput

    End Function

    Private Sub BuildFileAndPrint(ByVal nLBS As Single)

        Try

            Dim tempProductInfo As New ProductInfo
            tempProductInfo = DatabaseHandling.LookupSpecificProduct(lblProductCode.Text, ProductList)

            'ListBox3.Enabled = False
            ' Save reported weight as Gross
            LAST_GROSS_WEIGHT = nLBS

            ' Adjust for tare of Box
            nLBS -= tempProductInfo.Tare

            ' Adjust for tare of "items"

            nLBS -= (tempProductInfo.ItemCountPerBox * tempProductInfo.ItemTareEach)


            CURRENT_LOT = FixNullInteger(lblLotDisplay.Text)

            If tempProductInfo.SetWeight <> 0 Then LAST_GROSS_WEIGHT = tempProductInfo.SetWeight + tempProductInfo.Tare
            If tempProductInfo.SetWeight <> 0 Then nLBS = tempProductInfo.SetWeight


            Dim outFile As String = Environment.CurrentDirectory & AppSettings("TempWorkFolder") & MachineInstance.ScaleName & "_" & System.Guid.NewGuid.ToString & ".palco.lbl"

            System.IO.File.WriteAllText(outFile, BuildLabelContentGrinding(nLBS, BOX_COUNT_LOT))

            WriteToLog("before print", outFile, MachineInstance.PrinterName)

            Dim bSuccess As Boolean = RawPrinterHelper.RawPrinterHelper.SendFileToPrinter(MachineInstance.PrinterName, outFile)


            WriteToLog("after print", outFile, MachineInstance.PrinterPort)






            'Me.BeginInvoke(DirectCast(Sub() lblSerialNumberDisplay.Text = Microsoft.VisualBasic.Right(LAST_BARCODE, 10), System.Windows.Forms.MethodInvoker))

            LAST_SERIAL = Microsoft.VisualBasic.Right(LAST_BARCODE, 10)

            'ListBox3.Enabled = True
        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

    End Sub

    Private Function IsKickoutBox(tempProductInfo As ProductInfo) As Boolean
        IsKickoutBox = False
        If tempProductInfo.KickoutCount > 0 And BOX_COUNT_LOT > 0 Then
            If (BOX_COUNT_LOT Mod tempProductInfo.KickoutCount) = 0 Then IsKickoutBox = True
        End If
    End Function

    Private Sub btnSetWeightPrint_Click(sender As Object, e As EventArgs) Handles btnSetWeightPrint.Click
        If AppSettings("InTest") = "TRUE" Then
            Dim random As New Random
            txtGrossWeight.Text = random.Next(1, 100)
        End If

        HandleAllPrinting(txtGrossWeight.Text)
    End Sub

    Private Sub HandleAllPrinting(weight As Single)

        Try

            BuildFileAndPrint(weight)

            If PROD_ACTIVE Then
                'add info for transaction.....then get totals below
                AddTransactionToDB()

                'CreateInfoForAlpha()  'not doing this any more, should come from database

                'get current totals by database queries
                GetCounts()


                'print
                'PrinterInfo.PrinterStuff()

                SetDisplay(lblProductCode.Text)
            End If

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

    End Sub

    Private Sub AddTransactionToDB()

        Try

            Dim sSql As String
            sSql = "INSERT INTO LabelPrintLog(PlantID, ShiftID, StationName, LineID, DateProcessed, ProductCode, ProductName, 
                  BoxBarcode, LotBoxCount, Lot, Grade, SetWeightLB, CaptureWeightLB, TareWeightLB, MaxWeightLB, MinWeightLB)
                  VALUES (@PlantID, @ShiftID, @StationName, @LineID, @DateProcessed, @ProductCode, @ProductName, 
                  @BoxBarcode, @LotBoxCount, @Lot, @Grade, @SetWeightLB, @CaptureWeightLB, @TareWeightLB, @MaxWeightLB, @MinWeightLB)"


            Dim oConn As New SqlConnection
            oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))

            Dim cmd As New SqlCommand
            cmd = New SqlClient.SqlCommand(sSql, oConn)

            cmd.Parameters.AddWithValue("@PlantID", MachineInstance.PlantCode)
            cmd.Parameters.AddWithValue("@ShiftID", lblShiftDisplay.Text)
            cmd.Parameters.AddWithValue("@StationName", MachineInstance.ScaleName)
            cmd.Parameters.AddWithValue("@LineID", MachineInstance.ScaleNumber)
            cmd.Parameters.AddWithValue("@DateProcessed", Convert.ToDateTime(lblDateDisplay.Text))
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
            'cmd.Parameters.AddWithValue("@FreezeBy", "")    '???

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

    End Sub
    'Private Sub CreateInfoForAlpha()

    '    'creating a flat file for Alpha to pick up and pull into the system for inventory

    '    Using sr As New System.IO.StreamWriter(AppSettings("logfile") & Format(Now.ToString("MMddyyyy")) & ".txt", True)
    '        sr.WriteLine(Now.ToString("MM/dd/yyyy HH:mm") & "," & LAST_BARCODE & "," & CUSTOMER)
    '    End Using
    '    Using sr As New System.IO.StreamWriter(AppSettings("logfile2") & Format(Now.ToString("MMddyyyy")) & ".txt", True)
    '        sr.WriteLine(Now.ToString("MM/dd/yyyy HH:mm") & "," & LAST_BARCODE & "," & CUSTOMER)
    '    End Using

    'End Sub
    Private Sub btnMakeFavorite_Click(sender As Object, e As EventArgs) Handles btnMakeFavorite.Click
        If btnMakeFavorite.Text.Contains("Make Favorite") Then
            If FavoriteProductList.Count >= 12 Then
                MsgBox("Only 12 favorites allowed. " & vbCrLf & "Please remove a code before adding a new one.", vbOKOnly, "Too Many Favorites")
            Else
                'add product code to favorites db 

                DatabaseHandling.MakeProductFavorite(MachineInstance.ScaleName, MachineInstance.ScaleNumber, lblProductCode.Text)
                btnMakeFavorite.Text = "Remove Favorite"
            End If
        Else
            'remove product code to favorites db 
            DatabaseHandling.RemoveProductFavorite(MachineInstance.ScaleName, MachineInstance.ScaleNumber, lblProductCode.Text)
            btnMakeFavorite.Text = "Make Favorite"
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

    Private Sub ScalePort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ScaleInstance.DataReceived
        'this is triggered by user hitting PRINT on the scale
        Try

            Dim scaleMessage As String = ScaleInstance.ReadExisting()
            'Dim scaleWeightEndText As String = AppSettings("ScaleWeightEndText")
            Dim NetWeightinLBs As Single = 0
            Dim NetWeightinKgs As Single = 0

            ' Message may come in pieces... append to master message until we get the final NET message
            EntireScaleMessage &= scaleMessage

            If AppSettings("InTest") = "TRUE" Then EntireScaleMessage = EntireScaleMessage.Replace(vbCr, "lb")

            If EntireScaleMessage.Contains("kg") Or EntireScaleMessage.Contains("lb") Then
                ' Find the line that says "xxxx lb NET" and extract the weight
                For Each ThisLine As String In EntireScaleMessage.Split(vbCr)
                    Dim stemp As String = ThisLine.Replace(" ", "").Replace(vbCrLf, "").Replace(vbCr, "")

                    If stemp.EndsWith("kg") Then
                        NetWeightinKgs = CSng(stemp.Replace("kg", "").Replace(" ", ""))
                        NetWeightinLBs = NetWeightinKgs / CSng(AppSettings("KiloConversionRate"))
                    ElseIf stemp.EndsWith("lb") Then
                        NetWeightinLBs = CSng(stemp.Replace("lb", "").Replace(" ", ""))
                        NetWeightinKgs = NetWeightinLBs * CSng(AppSettings("KiloConversionRate"))
                    End If


                    If CSng(NetWeightinLBs) > 0 Then
                        Try
                            If Me.InvokeRequired Then
                                BeginInvoke(Sub()
                                                txtGrossWeight.Text = NetWeightinLBs
                                                HandleAllPrinting(NetWeightinLBs)
                                            End Sub)
                            Else
                                txtGrossWeight.Text = scaleMessage
                            End If
                        Catch ex As Exception
                            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                        End Try
                    End If

                    NetWeightinKgs = 0
                    NetWeightinLBs = 0

                Next
            End If

            ' Reset for next message.
            EntireScaleMessage = ""

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

    End Sub

    Private Sub GetCounts()

        Dim oConn As New SqlConnection

        Try
            oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionString"))
            Dim sSQL As String = ""
            Dim cmd As New SqlCommand

            sSQL = "SELECT COUNT(PlantID) AS CountReturn From LabelPrintLog Where (ShiftID = '" & lblShiftDisplay.Text & "') AND (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date))"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            PRODUCT_COUNT_SHIFT = cmd.ExecuteScalar
            cmd.Dispose()

            sSQL = "SELECT COUNT(PlantID) AS CountReturn From LabelPrintLog Where (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date))"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            PRODUCT_COUNT_DAILY = cmd.ExecuteScalar
            cmd.Dispose()

            sSQL = "SELECT SUM(CAST(CaptureWeightLB AS decimal)) AS WeightReturn From LabelPrintLog Where (ShiftID = '" & lblShiftDisplay.Text & "') AND (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date))"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            WEIGHT_TOTAL_SHIFT = cmd.ExecuteScalar
            cmd.Dispose()

            sSQL = "SELECT SUM(CAST(CaptureWeightLB AS decimal)) AS WeightReturn From LabelPrintLog Where (LineID = '" & MachineInstance.ScaleNumber & "') AND (ProductCode = '" & lblProductCode.Text & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date))"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            WEIGHT_TOTAL_DAILY = cmd.ExecuteScalar
            cmd.Dispose()

            BOX_TOTAL_SHIFT = PRODUCT_COUNT_SHIFT
            BOX_TOTAL_DAILY = PRODUCT_COUNT_DAILY

        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        Finally
            oConn.Close()
        End Try

    End Sub

    'Private Sub btnChangeGrade_Click(sender As Object, e As EventArgs)
    '    Dim GradeSelect As frmEditGrade = New frmEditGrade
    '    'GradeSelect.SetProductList(ProductList)
    '    GradeSelect.ShowDialog()
    '    'lblGradeDisplay.Text = GradeSelect.CurrentGrade
    '    GradeSelect.Close()

    'End Sub

    Private Sub btnChangeLot_Click(sender As Object, e As EventArgs) Handles btnChangeLot.Click
        Dim ChangeLot As frmEditLot = New frmEditLot
        ChangeLot.ShowDialog()
        lblLotDisplay.Text = ChangeLot.SetLot
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

            lblBoxesInLot.Text = LanguageToUse.BoxesInLot
            lblLot.Text = LanguageToUse.Lot
            'lblGrade.Text = LanguageToUse.Grade
            'btnScanCombo.Text = LanguageToUse.ScanCombo
            btnChangeLot.Text = LanguageToUse.ChangeLot


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

            lblBoxesInLot.Text = LanguageToUse.BoxesInLot
            lblLot.Text = LanguageToUse.Lot
            'lblGrade.Text = LanguageToUse.Grade
            'btnScanCombo.Text = LanguageToUse.ScanCombo
            btnChangeLot.Text = LanguageToUse.ChangeLot

        End If

    End Sub


End Class