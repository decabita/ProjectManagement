Public Class LocalExceptions


    Public Class CustomException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal InnerExecption As Exception)
            MyBase.New(message, InnerExecption)
        End Sub
        Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class

    Public Class RequieredFieldException
        Inherits Exception

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal field As String)

            MyBase.New("El campo " & field & " no puede estar vacio.")

        End Sub

        Public Sub New(ByVal field As String, ByVal value As String)
            MyBase.New("El campo " & field & " no puede estar vacio.")
        End Sub
        Public Sub New(ByVal message As String, ByVal InnerExecption As Exception)
            MyBase.New(message, InnerExecption)
        End Sub
        Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class

    Public Class ZeroFieldException
        Inherits Exception

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal field As String)

            MyBase.New("El campo " & field & " no puede ser menor o igual a cero.")

        End Sub
 
        Public Sub New(ByVal message As String, ByVal InnerExecption As Exception)
            MyBase.New(message, InnerExecption)
        End Sub
        Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class

    Public Class NumericFieldException
        Inherits Exception

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal field As String)

            MyBase.New("El campo " & field & " debe ser numérico.")

        End Sub

        Public Sub New(ByVal message As String, ByVal InnerExecption As Exception)
            MyBase.New(message, InnerExecption)
        End Sub
        Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class
End Class
