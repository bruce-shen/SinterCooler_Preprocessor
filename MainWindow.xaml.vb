Class MainWindow

    Dim geometryWindow As Geometry
    Dim gridWindow As Grid
    Dim sinterPropertiesWindow As SinterProperties
    Dim sinterParticleWindow As SinterParticle
    Dim sinterTemperatureWindow As SinterTemperature
    Dim coolingAirBlowerWindow As CoolingAirBlower
    Dim probeLocationWindow As ProbeLocation
    Dim outForProbesWindow As OutputforProbes
    Dim outForContoursWindow As OutputforContours
    Dim solverSetupWindow As SolverSetup
    Dim runWindow As Run
    Dim resultsWindow As Results


    Sub New()
        InitializeComponent()
        InitializeUserControls()
        InitializeBackground()
    End Sub

    Private Sub InitializeUserControls()
        geometryWindow = New Geometry
        gridWindow = New Grid
        sinterPropertiesWindow = New SinterProperties
        sinterParticleWindow = New SinterParticle
        sinterTemperatureWindow = New SinterTemperature
        coolingAirBlowerWindow = New CoolingAirBlower
        probeLocationWindow = New ProbeLocation
        outForProbesWindow = New OutputforProbes
        outForContoursWindow = New OutputforContours
        solverSetupWindow = New SolverSetup
        runWindow = New Run
        resultsWindow = New Results

    End Sub

    Private Sub InitializeBackground()
        Me.bkImage.Source = BitmapFrame.Create(Application.GetResourceStream(New Uri("/Resources/imgs/arcelormittal.jpg", UriKind.Relative)).Stream)
    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim mnu As MenuItem = DirectCast(e.OriginalSource, MenuItem)
        Select Case mnu.Name
            Case "newFile"
                contentController.Content = geometryWindow
                Exit Select
            Case "exit"
                Dim Response As Integer
                Response = MsgBox(Prompt:="Are you sure to exit without saving?", Buttons:=vbYesNo)

                If Response = vbYes Then
                    Application.Current.Shutdown()
                End If

                Exit Select
            Case "geometry"
                contentController.Content = geometryWindow
                Exit Select
            Case "grid"
                contentController.Content = Me.gridWindow
                Exit Select
            Case "sinterProperties"
                contentController.Content = Me.sinterPropertiesWindow
                Exit Select
            Case "sinterParticle"
                contentController.Content = Me.sinterParticleWindow
                Exit Select
            Case "sinterTemperature"
                contentController.Content = Me.sinterTemperatureWindow
                Exit Select
            Case "coolingAirBlower"
                contentController.Content = Me.coolingAirBlowerWindow
                Exit Select
            Case "probeLocation"
                contentController.Content = Me.probeLocationWindow
                Exit Select
            Case "outForProbes"
                contentController.Content = Me.outForProbesWindow
                Exit Select
            Case "outForContours"
                contentController.Content = Me.outForContoursWindow
                Exit Select
            Case "solverSetup"
                contentController.Content = Me.solverSetupWindow
                Exit Select
            Case "run"
                contentController.Content = Me.runWindow
                Exit Select
            Case "results"
                contentController.Content = Me.resultsWindow
                Exit Select


        End Select
        

    End Sub
End Class
