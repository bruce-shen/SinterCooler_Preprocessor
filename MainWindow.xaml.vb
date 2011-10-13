Class MainWindow
    'Menu page windows
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
    Dim sinterCoolerGeometry As New SinterCoolerGeometry()


    Sub New()

        InitializeComponent()
        'InitializeUserControls()    'init all page windows
        InitializeBackground()      'init arcelormittal background


    End Sub

    Private Sub InitializeUserControls()
        Dim fileIni As New FileIni("setup.ini")
        geometryWindow = New Geometry(fileIni.GetPropertities()(0))
        gridWindow = New Grid(fileIni.GetPropertities()(1))
        sinterPropertiesWindow = New SinterProperties(fileIni.GetPropertities()(2))
        sinterParticleWindow = New SinterParticle(fileIni.GetPropertities()(3))
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

    'Clear all page winodws' canvas
    Private Sub ClearCanvas()
        Me.geometryWindow.geometryCanvas.Children.Clear()
        Me.gridWindow.geometryCanvas.Children.Clear()
        Me.sinterParticleWindow.geometryCanvas.Children.Clear()
        Me.probeLocationWindow.geometryCanvas.Children.Clear()
    End Sub

    'Enalbe windows when new or load a file
    Private Sub EnableWindows()
        'File 
        Me.File.IsEnabled = True
        Me.newFile.IsEnabled = True
        Me.openFile.IsEnabled = True
        Me.saveFile.IsEnabled = True
        Me.saveAs.IsEnabled = True

        'Sinter Cooler
        Me.sinterCooler.IsEnabled = True
        Me.geometry.IsEnabled = True
        Me.grid.IsEnabled = True

        'Sinter
        Me.sinter.IsEnabled = True
        Me.sinterProperties.IsEnabled = True
        Me.sinterParticle.IsEnabled = True
        Me.sinterTemperature.IsEnabled = True

        'Cooling Air and Blower
        Me.coolingAirBlower.IsEnabled = True

        'Formats of Results
        Me.formatResult.IsEnabled = True
        Me.probeLocation.IsEnabled = True
        Me.outForProbes.IsEnabled = True
        Me.outForContours.IsEnabled = True
        Me.computation.IsEnabled = True
    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim mnu As MenuItem = DirectCast(e.OriginalSource, MenuItem)
        Select Case mnu.Name
            Case "newFile"
                InitializeUserControls()
                EnableWindows()
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
                ClearCanvas()
                Me.geometryWindow.drawGeometry()
                contentController.Content = geometryWindow
                Exit Select
            Case "grid"
                Me.gridWindow.sinterCoolerGemometry = Me.geometryWindow.sinterCoolerGemometry
                ClearCanvas()
                Me.gridWindow.DrawGeometry()
                contentController.Content = Me.gridWindow
                Exit Select
            Case "sinterProperties"
                contentController.Content = Me.sinterPropertiesWindow
                Exit Select
            Case "sinterParticle"
                Me.sinterParticleWindow.sinterCoolerGemometry = Me.geometryWindow.sinterCoolerGemometry
                ClearCanvas()
                Me.sinterParticleWindow.DrawGeometry()
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
