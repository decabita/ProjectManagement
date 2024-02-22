Public Class CApplicationHelper
    Implements IDisposable

    Public Shared Function CheckRequiredFieldsHelper(ByVal oObject As Object) As Boolean

        Dim oRequiredText As String = String.Empty

        Try

            If TypeOf oObject Is TextBox Then

                oRequiredText = DirectCast(oObject, TextBox).Text.Trim

            ElseIf TypeOf oObject Is ComboBox Then

                oRequiredText = DirectCast(oObject, ComboBox).Text.Trim

            ElseIf TypeOf oObject Is DateTimePicker Then

                oRequiredText = DirectCast(oObject, DateTimePicker).Text

            End If


            If String.IsNullOrEmpty(oRequiredText) Then oObject.Focus() : Throw New LocalExceptions.RequieredFieldException(oObject.Tag)

            CheckRequiredFieldsHelper = True


        Catch ex As LocalExceptions.RequieredFieldException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CheckRequiredFieldsHelper

    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
