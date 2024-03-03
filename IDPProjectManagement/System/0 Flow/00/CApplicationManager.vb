Friend Class CApplicationManager

    <STAThread()>
    Shared Sub Main()

        Dim oFLoginForm As New FLoginForm

        Call CApplication.SetCultureSettings()

        If oFLoginForm.ShowDialog() = DialogResult.OK Then
            Application.Run(FAdministrationMenu)
        End If

        FCatalogFormTemplate.Show()

    End Sub

End Class
