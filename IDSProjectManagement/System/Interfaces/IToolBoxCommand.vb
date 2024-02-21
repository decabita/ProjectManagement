Public Interface IToolBoxCommand

    ' ToolBoxCommand
    Function CommandSave() As Boolean
    Function CommandNew() As Boolean
    Function CommandDelete() As Boolean
    Function UpdateCommand() As Boolean
    Function CommandEdit() As Boolean
    Function CommandCancel() As Boolean
    Function CommandQuery() As Boolean
    Function CommandExit() As Boolean

    ' Common Behavior

    Function SetControlsBinding() As Boolean
    Function ClearControlsBinding() As Boolean

    Sub SetControlPropertiesFormat()
    Sub SetGridPropertiesFormat()
    Sub SetToolBarConfiguration(ByVal State As Integer)


End Interface


