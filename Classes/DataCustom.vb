Public Class DataCustom




End Class

Public Class ProgramUser
    Public Property LDAPVerified As Boolean = False
    Public Property isTech As Boolean = False
    Public Property isSupervisor As Boolean = False
    Public Property isBasicUser As Boolean = False
    Public Property userName As String = ""
End Class
Public Class ProductInfo

    Public Property ProductDescription As String
    Public Property ProductCode As String
    Public Property SetWeight As Single
    Public Property ProductGrade As Integer
    Public Property Tare As Single
    Public Property Tare2 As Single
    Public Property KickoutCount As Integer
    Public Property MinWeight As Single
    Public Property MaxWeight As Single
    Public Property ItemCountPerBox As Integer
    Public Property ItemTareEach As Single
    Public Property Lot As Integer
    Public Property Type As String
    Public Property AlphaDescription As String
    Public Property ProductDescription2 As String
    Public Property TestingDescription As String

    Public Property LabelTemplate As String
    'Public Property PricePerLb As String
    'Public Property SellByDate As Nullable(Of Date)
    'Public Property KillDate As Nullable(Of Date)
    'Public Property DiscPerLb As String
    Public Property NormalWeight As String
    Public Property IsRigid As Boolean
    Public Property IsFlexible As Boolean

End Class

Public Class LabelVariables
    Public Property ProductDesc As String
    Public Property SP As String
    Public Property Time As String
    Public Property ShiftID As String
    Public Property GradeWP As String
    Public Property GradeDis As String
    Public Property Description3 As String
    Public Property Description2 As String
    Public Property Description As String
    Public Property Barcode_ProdID As String
    Public Property GTIN As String
    Public Property Box_High As String
    Public Property TickerUpdate As String
    Public Property Barcode As String
    Public Property DescDis As String
    Public Property SKU_Trim As String
    Public Property TickerStation As String
    Public Property ProductLine As String   'Product-Line
    Public Property JulianDate As String
    Public Property TickerCount As String
    Public Property OrderNo As String
    Public Property BC_DATE As String
    Public Property Ticker As String
    Public Property PackDateDis As String
    Public Property DailyTicker As String
    Public Property NetKG As String
    Public Property PlantID As String
    Public Property NetLB As String
    Public Property C128_1 As String
    Public Property Box_Low As String
    Public Property Product_ID As String
    Public Property TrimmedWeight As String
    Public Property TimeDis As String
    Public Property Line1Dis As String
    Public Property ScaleData As String
    Public Property DateDisStr As String
    Public Property Serial As String
    Public Property ItemCountPerBox As String
    Public Property SetWeight As String
    Public Property LineStationID As String
    Public Property DateCode As String
    Public Property BC_Weight As String
    Public Property Manufact_ID As String
    Public Property SKU0 As String
    Public Property GrossKG As String
    Public Property GrossLB As String
    Public Property Tare_Box As String
    Public Property ProductCode As String
    Public Property Product_Type_SKUNAME As String
End Class

Public Class MachineInfo
    Public Property ScaleName As String
    Public Property ScaleNumber As String
    Public Property PlantCode As String
    Public Property PrinterPort As String
    Public Property PrinterName As String
    Public Property TemplateName As String
    Public Property AlphaLogFileLocation As String
    Public Property AlphaLogFileLocation2 As String
End Class

