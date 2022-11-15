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

    Public Property ShiftID As String = ""  '1
    Public Property Description As String = ""    'Tastyfood
    Public Property Barcode_ProdID As String = ""    '622333
    Public Property GTIN As String = ""    '630308680123
    Public Property barcode As String = ""    '00213225622333
    Public Property Pack_Time As String = ""    '9:45
    Public Property DescDis As String = ""    'Tastyfood
    Public Property SKU_Trim As String = ""    '622333
    Public Property BC_Date As String = ""    '221108
    Public Property GradDis As String = ""    '62
    Public Property Packdatedis As String = ""    '110822
    Public Property NetKG As String = ""    '28.12 KG
    Public Property boxcount As String = ""    '0036
    Public Property C128_1 As String = ""    '{CODE C}0196303086801231320100064511221108{CODE B}211400000001
    Public Property NetLB As String = ""    '61.99 LBS
    Public Property Product_ID As String = ""    '680123
    Public Property Clear As String = ""    '*
    Public Property TimeDis As String = ""    '9:45
    Public Property TrimmedWeight As String = ""    '64.49
    Public Property DateDisStr As String = ""    'PACK Date: 110822
    Public Property scaledata As String = ""    '64.49
    Public Property Serial As String = ""    '1400000001
    Public Property LineStationID As String = ""    '12
    Public Property BC_Weight As String = ""    '645
    Public Property Tare_Box As String = ""    '2.5
    Public Property GrossLB As String = ""    'GROSS 64.49 LB
    Public Property GrossKG As String = ""    'GROSS 29.25 KG

End Class

Public Class LabelVariableAssignment
    Public Property ProductWeightKG As Integer = 0
    Public Property BarcodeReadable As Integer = 0
    Public Property UseFreezeDate As Integer = 0
    Public Property GradeNumber As Integer = 0
    Public Property PackDate As Integer = 0
    Public Property ProductDescription2 As Integer = 0
    Public Property ScaleNumber As Integer = 0
    Public Property ProductWeightLB As Integer = 0
    Public Property BoxCount As Integer = 0
    Public Property Barcode128 As Integer = 0
    Public Property PrintTime As Integer = 0
    Public Property ProductDescription As Integer = 0
    Public Property Lot As Integer = 0
    Public Property ProductCode As Integer = 0
End Class

Public Class LabelVariableString
    Public Property ProductWeightKG As String = "ProductWeightKG"
    Public Property BarcodeReadable As String = "BarcodeReadable"
    Public Property UseFreezeDate As String = "UseFreezeDate"
    Public Property GradeNumber As String = "GradeNumber"
    Public Property PackDate As String = "PackDate"
    Public Property ProductDescription2 As String = "ProductDescription2"
    Public Property ScaleNumber As String = "ScaleNumber"
    Public Property ProductWeightLB As String = "ProductWeightLB"
    Public Property BoxCount As String = "BoxCount"
    Public Property Barcode128 As String = "Barcode128"
    Public Property PrintTime As String = "PrintTime"
    Public Property ProductDescription As String = "ProductDescription"
    Public Property Lot As String = "Lot"
    Public Property ProductCode As String = "ProductCode"
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

