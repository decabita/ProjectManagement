Public Class CDynamicMenu

    ''''''''''''''''''''''variable declarations begins''''''''''''''''''''''''''''
    'Create a main menu object.
    Private mainMenu As New MainMenu()
    'Object for loading XML File
    Private objXML As Xml.XmlDocument
    ' Create menu item objects.
    Private mItem As New MenuItem()
    'Menu handle that should be returned
    Private objMenu As Menu
    'Path of the XML Menu Configuration File 
    '   Public XMLMenuFile As String
    'Form Object in which Menu has to be build
    Public objForm As Object
    ''''''''''''''''''''''variable declarations ends '''''''''''''''''''''''''''''

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'This method will get invoked by a parent Form.
    'And it returns Menu Object.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function LoadDynamicMenu() As Object

        Dim oXmlElement As Xml.XmlElement
        Dim objNode As Xml.XmlNode

        objXML = New Xml.XmlDocument()
        'load the XML File
        objXML.LoadXml(My.Resources.menu_config)
        'Get the documentelement of the XML file.
        oXmlElement = CType(objXML.DocumentElement, Xml.XmlElement)
        'loop through the each Top level nodes
        'For ex., File & Edit becomes Top Level nodes
        'And File -> Open , File ->Save will be treated as 
        'child for the Top Level Nodes
        For Each objNode In objXML.FirstChild.ChildNodes
            'Create a New MenuItem for Top Level Nodes
            mItem = New MenuItem()
            ' Set the caption of the menu items.
            mItem.Text = objNode.Attributes("id").Value
            ' Add the menu items to the main menu.
            mainMenu.MenuItems.Add(mItem)
            'Call this Method to generate child nodes for
            'the top level node which was added now(mItem in the above Add statement)
            GenerateMenusFromXML(objNode, mainMenu.MenuItems(mainMenu.MenuItems.Count - 1))
        Next
        'return this Menu handle to the parent Form so that
        'generated menu gets displayed in the Form
        Return objMenu
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'This method takes care of loading Menus based on XML file contents. 
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub GenerateMenusFromXML(ByVal objNode As Xml.XmlNode, ByVal mItm As MenuItem)
        'This method will be invoked in an recursive fashion
        'till all the child nodes are generated. This method
        'drills up to N-levels to generate all the Child nodes
        Dim objNod As Xml.XmlNode
        Dim sMenu As New MenuItem()
        'loop for child nodes
        For Each objNod In objNode.ChildNodes
            sMenu = New MenuItem()
            ' Set the caption of the menu items.
            sMenu.Text = objNod.Attributes("id").Value
            mItm.MenuItems.Add(sMenu)
            'Add a Event handler to the menu item added
            'this method takes care of Binding Event Name(based on the parameter from
            'from xml file) to newly added menu item.
            'for ex., Your Form Code should have a Private sub MenuItemOnClick_New even to handle
            'the click of New Menu Item
            If Not objNod.Attributes("OnClick") Is Nothing Then
                FindEventsByName(sMenu, objForm, True, "MenuItemOn", objNod.Attributes("OnClick").Value)
            End If
            'call the same method to see you have any child nodes
            'for the particular node you have added now(above mItm)
            GenerateMenusFromXML(objNod, mItm.MenuItems(mItm.MenuItems.Count - 1))
        Next
        'assign the generated mainMenu object to objMenu - public object
        'which is to be used in the Main Form
        objMenu = mainMenu
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'objective of this method is to find out the private event present in Form 
    'and attach the newly added menuitem to this event, this was achieved using
    'Reflection technique
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub FindEventsByName(ByVal sender As Object, _
     ByVal receiver As Object, ByVal bind As Boolean, _
     ByVal handlerPrefix As String, ByVal handlerSufix As String)
        ' Get the sender's public events.
        Dim SenderEvents() As System.Reflection.EventInfo = sender.GetType().GetEvents()
        ' Get the receiver's type and lookup its public
        ' methods matching the naming convention:
        '  handlerPrefix+Click+handlerSufix
        Dim ReceiverType As Type = receiver.GetType()
        Dim E As System.Reflection.EventInfo
        Dim Method As System.Reflection.MethodInfo
        For Each E In SenderEvents
            Method = ReceiverType.GetMethod( _
              handlerPrefix & E.Name & handlerSufix, _
              System.Reflection.BindingFlags.IgnoreCase Or _
              System.Reflection.BindingFlags.Instance Or _
              System.Reflection.BindingFlags.NonPublic)

            If Not Method Is Nothing Then
                Dim D As System.Delegate = System.Delegate.CreateDelegate(E.EventHandlerType, receiver, Method.Name)
                If bind Then
                    'add the event handler
                    E.AddEventHandler(sender, D)
                Else
                    'you can also remove the event handler if you pass bind variable as false
                    E.RemoveEventHandler(sender, D)
                End If
            End If
        Next
    End Sub


End Class
