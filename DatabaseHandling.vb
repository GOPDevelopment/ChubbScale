Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

'--------USE THIS TO ORGANIZE OLD TABLES INTO NEW TABLES----------
'SELECT 'COMBO' AS ScaleType,ProductCode,description,descip2,SetWeight,ProductGrade,Tare,KickoutCount,MinWeight,MaxWeight,ItemCountPerBox,ItemTareEach,Lot,AlphaDescription,Testing FROM tblProduct

'SELECT ScaleType,ProductCode,ProductDesc,ProductDesc2,SetWeight,ProductGrade,ProductTare,KickoutCount,MinWeight,MaxWeight,ItemCountPerBox,ItemTareEach,Lot,AlphaDesc,TestingDesc FROM ProductInfo


Public Class DatabaseHandling
    Public Shared Function ConnectSQL(db As String) As SqlConnection

        Dim myConn As SqlConnection
        myConn = New SqlConnection(db)
        myConn.Open()
        Return myConn

    End Function

    Public Shared Function GetMachineInfo(scale As String) As MachineInfo
        'using default db right now, add in when needed
        Dim tempProductInfo As New MachineInfo
        Dim oConn As New SqlConnection
        oConn = ConnectSQL(AppSettings("ConnectionStringNetwork"))

        Dim cmd As New SqlCommand
        cmd = New SqlClient.SqlCommand("SELECT * FROM ScaleInfo WHERE ScaleNumber = '" & scale & "'", oConn)
        Dim rdr As SqlClient.SqlDataReader
        rdr = cmd.ExecuteReader

        If rdr.HasRows Then
            While rdr.Read()
                tempProductInfo.ScaleName = FixNull(rdr("ScaleName"))
                tempProductInfo.ScaleNumber = FixNull(rdr("ScaleNumber"))
                tempProductInfo.PlantCode = FixNull(rdr("PlantCode"))
                tempProductInfo.PrinterPort = FixNull(rdr("PrinterPortInConfig"))
                tempProductInfo.PrinterName = FixNull(rdr("PrinterNameInConfig"))
                tempProductInfo.TemplateName = FixNull(rdr("TemplateName"))
                tempProductInfo.AlphaLogFileLocation = FixNull(rdr("AlphaLogFileLocation"))
                tempProductInfo.AlphaLogFileLocation2 = FixNull(rdr("AlphaLogFileLocation2"))
            End While
        End If
        cmd.Dispose()
        oConn.Dispose()

        Return tempProductInfo
    End Function

    Public Shared Function GetProductList(scale As String) As List(Of ProductInfo)
        Dim tempList As New List(Of ProductInfo)

        'using default db right now, add in when needed
        Dim tempProductInfo As New ProductInfo
        Dim oConn As New SqlConnection
        Dim cmd As New SqlCommand

        ''oConn = ConnectSQL(AppSettings("ConnectionStringAlpha"))
        ''cmd = New SqlClient.SqlCommand("SELECT * FROM productMaster order by productGroup, productDescription1", oConn)

        'oConn = ConnectSQL(AppSettings("ConnectionStringAlpha"))
        'cmd = New SqlClient.SqlCommand("SELECT * FROM productMaster order by productGroup, productDescription1", oConn)

        ''SELECT        productCode, productGrade, activeInactive, complexNo, productGroup, boneInOut, productDescriptionX, halalRate, productDescription1, marketPrice, setHighPrice, setLowPrice, setHighWeight, cabCommRate, qtyPerBox, 
        ''testHold, directFrozen, pkgType, passThru, tarYield, prtQry, trimCode, weightCode, productClass, offalFlag, productDescription2, usda5dayAvgPrice, usda5dayAvgUpdDate, carousel, frtDescId, histLowPrice, histHighPrice,
        ''tareWeight, fixedWeight, ticker, introDate, lastFabDate, lastChgDate, mprClass, lastChgUid, vaXfrDiscPct
        ''From dbo.productMaster


        ''SELECT        , , activeInactive, complexNo, productGroup, boneInOut, productDescriptionX, halalRate, , marketPrice, setHighPrice, setLowPrice, setHighWeight, cabCommRate, , 
        ''testHold, directFrozen, pkgType, passThru, , prtQry, trimCode, weightCode, productClass, offalFlag, , usda5dayAvgPrice, usda5dayAvgUpdDate, carousel, frtDescId, histLowPrice, histHighPrice,
        '', , ticker, introDate, lastFabDate, lastChgDate, mprClass, lastChgUid, vaXfrDiscPct
        ''From dbo.productMaster


        'Dim rdr As SqlClient.SqlDataReader
        'rdr = cmd.ExecuteReader

        'If rdr.HasRows Then
        '    While rdr.Read()
        '        tempProductInfo = New ProductInfo

        '        tempProductInfo.ProductCode = FixNull(rdr("productCode"))
        '        tempProductInfo.ProductDescription = FixNull(rdr("productDescription1"))
        '        tempProductInfo.ProductDescription2 = FixNull(rdr("productDescription2"))
        '        tempProductInfo.SetWeight = FixNullDecimal(rdr("fixedWeight"))
        '        tempProductInfo.ProductGrade = FixNullInteger(rdr("productGrade"))
        '        tempProductInfo.Tare = FixNullDecimal(rdr("tareWeight"))
        '        tempProductInfo.Tare2 = FixNullDecimal(rdr("tarYield"))
        '        tempProductInfo.KickoutCount = FixNullInteger(rdr("qtyPerBox"))
        '        'tempProductInfo.MinWeight = FixNullDecimal(rdr("MinWeight"))
        '        'tempProductInfo.MaxWeight = FixNullDecimal(rdr("MaxWeight"))
        '        'tempProductInfo.ItemCountPerBox = FixNullInteger(rdr("ItemCountPerBox"))
        '        'tempProductInfo.ItemTareEach = FixNullDecimal(rdr("ItemTareEach"))
        '        'tempProductInfo.Lot = FixNullInteger(rdr("Lot"))
        '        'tempProductInfo.Type = FixNull(rdr("ProductType"))
        '        'tempProductInfo.AlphaDescription = FixNull(rdr("AlphaDesc"))
        '        'tempProductInfo.TestingDescription = FixNull(rdr("TestingDesc"))
        '        'tempProductInfo.LabelTemplate = FixNull(rdr("Label"))
        '        'tempProductInfo.NormalWeight = FixNullDecimal(rdr("NormalWeight"))

        '        tempList.Add(tempProductInfo)
        '    End While
        'End If
        'cmd.Dispose()
        'oConn.Dispose()


        oConn = ConnectSQL(AppSettings("ConnectionStringNetwork"))
        cmd = New SqlClient.SqlCommand("SELECT * FROM ProductInfo WHERE ScaleType = '" & scale & "' order by ProductCode", oConn)

        Dim rdr As SqlClient.SqlDataReader
        rdr = cmd.ExecuteReader

        If rdr.HasRows Then
            While rdr.Read()
                tempProductInfo = New ProductInfo

                tempProductInfo.ProductCode = FixNull(rdr("ProductCode"))
                tempProductInfo.ProductDescription = FixNull(rdr("ProductDesc"))
                tempProductInfo.ProductDescription2 = FixNull(rdr("ProductDesc2"))
                tempProductInfo.SetWeight = FixNullDecimal(rdr("SetWeight"))
                tempProductInfo.ProductGrade = FixNullInteger(rdr("ProductGrade"))
                tempProductInfo.Tare = FixNullDecimal(rdr("ProductTare"))
                tempProductInfo.Tare2 = FixNullDecimal(rdr("ProductTare2"))
                tempProductInfo.KickoutCount = FixNullInteger(rdr("KickoutCount"))
                tempProductInfo.MinWeight = FixNullDecimal(rdr("MinWeight"))
                tempProductInfo.MaxWeight = FixNullDecimal(rdr("MaxWeight"))
                tempProductInfo.ItemCountPerBox = FixNullInteger(rdr("ItemCountPerBox"))
                tempProductInfo.ItemTareEach = FixNullDecimal(rdr("ItemTareEach"))
                tempProductInfo.Lot = FixNullInteger(rdr("Lot"))
                tempProductInfo.Type = FixNull(rdr("ProductType"))
                tempProductInfo.AlphaDescription = FixNull(rdr("AlphaDesc"))
                tempProductInfo.TestingDescription = FixNull(rdr("TestingDesc"))
                tempProductInfo.LabelTemplate = FixNull(rdr("Label"))
                tempProductInfo.NormalWeight = FixNullDecimal(rdr("NormalWeight"))
                tempProductInfo.SellByDay = FixNullInteger(rdr("SellByDay"))


                tempList.Add(tempProductInfo)
            End While
        End If
        cmd.Dispose()
        oConn.Dispose()


        Return tempList
    End Function

    Public Shared Function GetFavoriteProductList(scale As String, line As String) As List(Of String)
        Dim tempList As New List(Of String)

        'using default db right now, add in when needed
        'Dim tempProductInfo As New ProductInfo
        Dim oConn As New SqlConnection
        oConn = ConnectSQL(AppSettings("ConnectionStringNetwork"))

        Dim cmd As New SqlCommand
        cmd = New SqlClient.SqlCommand("SELECT ProductCode FROM ProductFavoriteByScale WHERE Scale = '" & scale & "' and Line = '" & line & "' order by ProductCode", oConn)

        Dim rdr As SqlClient.SqlDataReader
        rdr = cmd.ExecuteReader
        If rdr.HasRows Then
            While rdr.Read()
                tempList.Add(rdr("ProductCode"))
            End While
        End If
        cmd.Dispose()
        oConn.Dispose()

        Return tempList
    End Function

    Public Shared Sub MakeProductFavorite(scale As String, line As String, productCode As String)
        Dim tempList As New List(Of String)

        Dim oConn As New SqlConnection
        oConn = ConnectSQL(AppSettings("ConnectionStringNetwork"))

        Dim sSQL As String = "Insert Into ProductFavoriteByScale(Scale, Line, ProductCode) VALUES ('" & scale & "','" & line & "','" & productCode & "')"
        Dim cmd As New SqlCommand
        cmd = New SqlClient.SqlCommand(sSQL, oConn)

        Dim rdr As SqlClient.SqlDataReader
        rdr = cmd.ExecuteReader

        cmd.Dispose()
        oConn.Dispose()

    End Sub

    Public Shared Sub RemoveProductFavorite(scale As String, line As String, productCode As String)
        Dim tempList As New List(Of String)

        Dim oConn As New SqlConnection
        oConn = ConnectSQL(AppSettings("ConnectionStringNetwork"))

        Dim sSQL As String = "Delete From ProductFavoriteByScale where Scale = '" & scale & "' and line = '" & line & "' and ProductCode = '" & productCode & "'"
        Dim cmd As New SqlCommand
        cmd = New SqlClient.SqlCommand(sSQL, oConn)

        Dim rdr As SqlClient.SqlDataReader
        rdr = cmd.ExecuteReader
        cmd.Dispose()
        oConn.Dispose()

    End Sub

    Public Shared Function GetNextSerialNumber(scale As String) As Integer

        Dim oConn As New SqlConnection

        Try
            oConn = ConnectSQL(AppSettings("ConnectionStringLocal"))

            Dim cmd As New SqlCommand("sp_advance_serial_number", oConn)
            cmd.Parameters.AddWithValue("@ProductionLineNumber", scale)
            cmd.CommandType = CommandType.StoredProcedure

            Return Convert.ToInt64(cmd.ExecuteScalar())
        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, scale)
            Return 0
        Finally
            oConn.Close()
        End Try

    End Function

    Public Shared Function LookupSpecificProduct(ProductCode As String, ProductList As List(Of ProductInfo)) As ProductInfo

        Dim tempProductInfo As New ProductInfo

        Dim query = From temp In ProductList Where temp.ProductCode = ProductCode
        For Each result In query
            tempProductInfo = result
        Next

        Return tempProductInfo

    End Function

    Public Shared Function DoesProductCodeExist(ProductCode As String, ProductList As List(Of ProductInfo)) As Boolean
        Dim bExists As Boolean = False

        Dim query = From temp In ProductList Where temp.ProductCode = ProductCode
        For Each result In query
            bExists = True
        Next

        Return bExists

    End Function
    Public Shared Sub LogUserChanges(name As String, datechange As String, scalechange As String)
        Dim oConn As New SqlConnection
        oConn = ConnectSQL(AppSettings("ConnectionStringNetwork"))

        Dim sSQL As String = "Insert Into UserChanges(UserName, DateChange, ScaleChange) VALUES ('" & name & "','" & datechange & "','" & scalechange & "')"
        Dim cmd As New SqlCommand
        cmd = New SqlClient.SqlCommand(sSQL, oConn)

        Dim rdr As SqlClient.SqlDataReader
        rdr = cmd.ExecuteReader

        cmd.Dispose()
        oConn.Dispose()
    End Sub
    Public Shared Function GetLotBoxCountCurrent(scaleNumber As String, productCode As String, lot As Integer) As Integer

        Dim oConn As New SqlConnection
        Dim iReturn As Integer = 0

        Try
            oConn = DatabaseHandling.ConnectSQL(AppSettings("ConnectionStringLocal"))
            Dim sSQL As String = ""
            Dim cmd As New SqlCommand

            'get highest number entered and add 1.  Count doesn't work correctly
            'sSQL = "SELECT COUNT(PlantID) AS BoxesInLot From LabelPrintLog Where (LineID = '" & scaleNumber & "') AND (ProductCode = '" & productCode & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date)) AND Lot = '" & lot & "'"
            sSQL = "SELECT LotBoxCount From LabelPrintLog Where (LineID = '" & scaleNumber & "') AND (ProductCode = '" & productCode & "') AND (CAST(DateProcessed AS date) = CAST(GETDATE() AS date)) AND Lot = '" & lot & "' order by LotBoxCount Desc"
            cmd = New SqlClient.SqlCommand(sSQL, oConn)
            iReturn = cmd.ExecuteScalar
            cmd.Dispose()


        Catch ex As Exception
            WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, scaleNumber)
        Finally
            oConn.Close()
        End Try

        Return iReturn

    End Function
End Class



