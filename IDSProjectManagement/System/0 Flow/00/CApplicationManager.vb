Friend Class CApplicationManager

    <STAThread()>
    Shared Sub Main()

        Dim oFLoginForm As New FLoginForm

        If oFLoginForm.ShowDialog() = DialogResult.OK Then
            Application.Run(FMenuAdministration)
        End If

    End Sub

End Class
