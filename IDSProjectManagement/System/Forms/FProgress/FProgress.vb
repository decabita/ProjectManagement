Imports System.ComponentModel
Imports System.Reflection

Public NotInheritable Class FProgress

    Shared _IsWorkDone As Boolean
    Shared Property IsWorkDone() As Boolean
        Get
            Return _IsWorkDone
        End Get
        Set(ByVal value As Boolean)
            _IsWorkDone = value
        End Set
    End Property

    Shared _oCaller As Object
    Shared Property oCaller() As Object
        Get
            Return _oCaller
        End Get
        Set(ByVal value As Object)
            _oCaller = value
        End Set
    End Property

    Shared _oTypeCaller As Type
    Shared Property oTypeCaller() As Type
        Get
            Return _oTypeCaller
        End Get
        Set(ByVal value As Type)
            _oTypeCaller = value
        End Set
    End Property

    Shared _oMethodInfo As MethodInfo
    Shared Property oMethodInfo() As MethodInfo
        Get
            Return _oMethodInfo
        End Get
        Set(ByVal value As MethodInfo)
            _oMethodInfo = value
        End Set
    End Property

    Shared _oFProgress As FProgress = New FProgress
    Shared Property oFProgress() As FProgress
        Get
            Return _oFProgress
        End Get
        Set(ByVal value As FProgress)
            _oFProgress = value
        End Set
    End Property

    Shared _oBackgroundWorker As BackgroundWorker = New BackgroundWorker
    Shared Property oBackgroundWorker() As BackgroundWorker
        Get
            Return _oBackgroundWorker
        End Get
        Set(ByVal value As BackgroundWorker)
            _oBackgroundWorker = value
        End Set
    End Property

    Shared _oDelegate As [Delegate]
    Shared Property oDelegate() As [Delegate]
        Get
            Return _oDelegate
        End Get
        Set(ByVal value As [Delegate])
            _oDelegate = value
        End Set
    End Property

    Shared _oBindingSource As New BindingSource
    Shared Property oBindingSource() As BindingSource
        Get
            Return _oBindingSource
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSource = value
        End Set
    End Property

    Private Sub FProgressForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '    oBackgroundWorker = New BackgroundWorker()

        '  AddHandler oBackgroundWorker.RunWorkerCompleted, AddressOf RunWorkerCompleted
        '  AddHandler oBackgroundWorker.DoWork, AddressOf DoWork

    End Sub

    Public Shared Sub StartWorker()

        oBackgroundWorker = New BackgroundWorker

        AddHandler oBackgroundWorker.RunWorkerCompleted, AddressOf RunWorkerCompleted
        AddHandler oBackgroundWorker.DoWork, AddressOf DoWork

        FProgress.oBackgroundWorker.RunWorkerAsync()

        ' Show Progress Window. 
        FProgress.ShowDialog()


    End Sub

    Public Shared Sub DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try

            ' Executes Query.
            e.Result = oMethodInfo.Invoke(oCaller, Nothing).ToString     'GetSomeWork(oFilterWorkDelegate)
 
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Shared Sub RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

        Try

            IsWorkDone = e.Result

        Finally

            FProgress.Dispose()
            oBackgroundWorker.Dispose()

        End Try
        
    End Sub

End Class
