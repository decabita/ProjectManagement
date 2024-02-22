Public Class testClass

    Public Delegate Sub ProgressUpdate(ByVal value As Integer)
    Public Event OnProgressUpdate As ProgressUpdate
    Private val As Integer

    Public Function changevalue(ByVal i As Integer) As Integer
        For j As Integer = 0 To 1000 - 1
            val += i + j
            RaiseEvent OnProgressUpdate(i)
        Next

        Return val
    End Function

End Class
