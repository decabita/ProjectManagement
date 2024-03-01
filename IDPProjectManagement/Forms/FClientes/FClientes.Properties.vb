Imports System.Data.SqlClient

Partial Public Class FClientes

    Private _oCCustomer As New CCustomer
    Public Property oMainClass() As CCustomer
        Get
            Return _oCCustomer
        End Get
        Set(ByVal value As CCustomer)
            _oCCustomer = value
        End Set
    End Property

End Class
