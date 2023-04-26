Public Class DataTableColumn

    Private _Name As String
    Private _Type As Integer
    Private _Key As Boolean
    Private _AllowNull As Boolean

    Public Sub New()
        _Name = String.Empty
        _Type = 0
        _Key = False
        _AllowNull = False
    End Sub

    Public Sub New(ByVal Name As String)
        _Name = Name
        _Type = 0
        _Key = False
        _AllowNull = False
    End Sub

    Public Sub New(ByVal Name As String, ByVal Type As Integer)
        _Name = Name
        _Type = Type
        _Key = False
        _AllowNull = False
    End Sub

    Public Sub New(ByVal Name As String, ByVal Key As Boolean)
        _Name = Name
        _Type = 0
        _Key = Key
        _AllowNull = False
    End Sub

    Public Sub New(ByVal Name As String, ByVal Type As Integer, ByVal Key As Boolean)
        _Name = Name
        _Type = Type
        _Key = Key
        _AllowNull = False
    End Sub

    Public Sub New(ByVal Name As String, ByVal Type As Integer, ByVal Key As Boolean, ByVal AllowNull As Boolean)
        _Name = Name
        _Type = Type
        _Key = Key
        _AllowNull = AllowNull
    End Sub

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property Type() As Integer
        Get
            Return _Type
        End Get
        Set(value As Integer)
            _Type = value
        End Set
    End Property

    Public Property Key() As Boolean
        Get
            Return _Key
        End Get
        Set(value As Boolean)
            _Key = value
        End Set
    End Property

    Public Property AllowNull() As Boolean
        Get
            Return _AllowNull
        End Get
        Set(value As Boolean)
            _AllowNull = value
        End Set
    End Property

End Class

Public Class RegKey

    Private _Name As String
    Private _ValueString As String = Nothing
    Private _ValueBinary As Byte() = Nothing
    Private _ValueDWord As Int32 = Nothing
    Private _ValueExpandString As String = Nothing
    Private _ValueMultiString As String() = Nothing
    Private _ValueQWord As Int64 = Nothing
    Private _Kind As RegistryValueKind = RegistryValueKind.None
    Private _LocalMachine As Boolean = False

    Public Sub New(ByVal Name As String)
        _Name = Name
        _ValueString = String.Empty
        _Kind = RegistryValueKind.String
    End Sub

    Public Sub New(ByVal Name As String, ByVal StringValue As String, ByVal Kind As RegistryValueKind, Optional ByVal LocalMachine As Boolean = False)
        _Name = Name
        If Kind = RegistryValueKind.String Then
            _ValueString = StringValue
        ElseIf Kind = RegistryValueKind.ExpandString Then
            _ValueExpandString = StringValue
        Else
            _ValueString = StringValue
        End If
        _Kind = Kind
        _LocalMachine = LocalMachine
    End Sub

    Public Sub New(ByVal Name As String, ByVal MultiStringValue As String(), ByVal Kind As RegistryValueKind, Optional ByVal LocalMachine As Boolean = False)
        _Name = Name
        _ValueMultiString = MultiStringValue
        _Kind = Kind
        _LocalMachine = LocalMachine
    End Sub

    Public Sub New(ByVal Name As String, ByVal BinaryValue As Byte(), ByVal Kind As RegistryValueKind, Optional ByVal LocalMachine As Boolean = False)
        _Name = Name
        _ValueBinary = BinaryValue
        _Kind = Kind
    End Sub

    Public Sub New(ByVal Name As String, ByVal DWordValue As Int32, ByVal Kind As RegistryValueKind, Optional ByVal LocalMachine As Boolean = False)
        _Name = Name
        _ValueDWord = DWordValue
        _Kind = Kind
        _LocalMachine = LocalMachine
    End Sub

    Public Sub New(ByVal Name As String, ByVal QWordValue As Int64, ByVal Kind As RegistryValueKind, Optional ByVal LocalMachine As Boolean = False)
        _Name = Name
        _ValueQWord = QWordValue
        _Kind = Kind
        _LocalMachine = LocalMachine
    End Sub

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property RegistryValueString() As String
        Get
            Return _ValueString
        End Get
        Set(value As String)
            _ValueString = value
        End Set
    End Property

    Public Property RegistryValueExpandString() As String
        Get
            Return _ValueExpandString
        End Get
        Set(value As String)
            _ValueExpandString = value
        End Set
    End Property

    Public Property RegistryValueMultiString() As String()
        Get
            Return _ValueMultiString
        End Get
        Set(value As String())
            _ValueMultiString = value
        End Set
    End Property

    Public Property RegistryValueBinary() As Byte()
        Get
            Return _ValueBinary
        End Get
        Set(value As Byte())
            _ValueBinary = value
        End Set
    End Property

    Public Property RegistryValueDWord() As Int32
        Get
            Return _ValueDWord
        End Get
        Set(value As Int32)
            _ValueDWord = value
        End Set
    End Property

    Public Property RegistryValueQWord() As Int64
        Get
            Return _ValueQWord
        End Get
        Set(value As Int64)
            _ValueQWord = value
        End Set
    End Property

    Public Property Kind() As RegistryValueKind
        Get
            Return _Kind
        End Get
        Set(value As RegistryValueKind)
            _Kind = value
        End Set
    End Property

    Public Property LocalMachine() As Boolean
        Get
            Return _LocalMachine
        End Get
        Set(value As Boolean)
            _LocalMachine = value
        End Set
    End Property

End Class
