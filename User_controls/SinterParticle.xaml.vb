Partial Public Class SinterParticle

    Private Zx1 As Double
    Private Zx2 As Double
    Private Zx3 As Double
    Private Zx4 As Double
    Private Z1x As Double
    Private Z2x As Double
    Private Z3x As Double
    Private Z4x As Double
    Private Z5x As Double
    Private randomSize As Boolean
    Private sizeOptions As List(Of Double)          '5 sizes with actual double sizze
    Private particleSizeOptions(3, 4) As Integer    'size option of each cells (1, 2, 3, 4, 5)

    Dim diaglog As SinterParticleSelectionForm

    Private sinterCoolerGeometry
    Private defaultDataList As List(Of Double)

    Public Sub New(ByVal list As List(Of Double))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.geometryCanvas.Width = 400
        Me.geometryCanvas.Height = 400

        defaultDataList = list
        InitDefaultGeometry()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property sinterCoolerGemometry() As SinterCoolerGeometry
        Get
            Return sinterCoolerGeometry
        End Get
        Set(ByVal value As SinterCoolerGeometry)
            sinterCoolerGeometry = value
        End Set
    End Property

    Public Sub SetSizeOptions(ByVal list As List(Of Double))
        Me.sizeOptions = list
    End Sub

    ' Default sinter particle
    Private Sub InitDefaultGeometry()
        Me.Zx1 = defaultDataList(0)
        Me.Zx2 = defaultDataList(1)
        Me.Zx3 = defaultDataList(2)
        Me.Zx4 = defaultDataList(3)
        Me.Z1x = defaultDataList(4)
        Me.Z2x = defaultDataList(5)
        Me.Z3x = defaultDataList(6)
        Me.Z4x = defaultDataList(7)
        Me.Z5x = defaultDataList(8)

        'random size
        Me.randomSize = CBool(defaultDataList(9))

        'random radios
        If Me.randomSize Then
            Me.RadioButton_Random.IsChecked = True
        Else
            Me.RadioButton_Specify.IsChecked = True
        End If

        For index As Integer = 10 To 29
            Dim row As Integer = (index - 10) \ 5
            Dim column As Integer = (index - 10) Mod 5
            Dim value As Integer = CInt(defaultDataList(index))
            If Me.randomSize Then   'if random size
                Dim randomSizeOption As Integer = CInt(Int((5 * Rnd()) + 1))
                Me.particleSizeOptions(row, column) = randomSizeOption
            Else                    'specify size read from .ini config file
                Me.particleSizeOptions(row, column) = value
            End If

        Next



        'Reset values for textboxes
        Me.T_Zx1.Text = Me.Z1x.ToString()
        Me.T_Zx2.Text = Me.Z2x.ToString()
        Me.T_Zx3.Text = Me.Z3x.ToString()
        Me.T_Zx4.Text = Me.Z4x.ToString()
        Me.T_Z1x.Text = Me.Z1x.ToString()
        Me.T_Z2x.Text = Me.Z2x.ToString()
        Me.T_Z3x.Text = Me.Z3x.ToString()
        Me.T_Z4x.Text = Me.Z4x.ToString()
        Me.T_Z5x.Text = Me.Z5x.ToString()

    End Sub

    'Draw geometry on canvas
    Public Sub DrawGeometry()
        Me.geometryCanvas.Children.Clear()
        Me.sinterCoolerGemometry.Stroke = Brushes.Blue
        Me.geometryCanvas.Children.Add(Me.sinterCoolerGeometry)

        Dim xRatio As Double = Me.geometryCanvas.Width / (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x)
        Dim yRatio As Double = Me.geometryCanvas.Height / (Me.Zx1 + Me.Zx2 + Me.Zx3 + Me.Zx4)

        DrawArrowLinesNumbers(xRatio, yRatio)
        DrawDistanceMarkers(xRatio, yRatio)
        DrawDistanceArrows(xRatio, yRatio)
        DrawGrids(xRatio, yRatio)
        DrawParticleSizes(xRatio, yRatio)
    End Sub


    'Draw particle sizes
    Private Sub DrawParticleSizes(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim particlesSizeTextBlocks(0 To 19) As TextBlock
        For i As Integer = 0 To 19
            particlesSizeTextBlocks(i) = New TextBlock()
            Me.geometryCanvas.Children.Add(particlesSizeTextBlocks(i))
        Next


        Dim fontSize As Double = particlesSizeTextBlocks(0).FontSize

        'Z14
        particlesSizeTextBlocks(0).Text = Me.sizeOptions(Me.particleSizeOptions(0, 0) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(0), Me.Z1x * xRatio / 2 - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(0), Me.Zx4 * yRatio / 2)

        'Z24
        particlesSizeTextBlocks(1).Text = Me.sizeOptions(Me.particleSizeOptions(0, 1) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(1), (Me.Z1x + Me.Z2x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(1), Me.Zx4 * yRatio / 2)

        'Z34
        particlesSizeTextBlocks(2).Text = Me.sizeOptions(Me.particleSizeOptions(0, 2) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(2), (Me.Z1x + Me.Z2x + Me.Z3x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(2), Me.Zx4 * yRatio / 2)

        'Z44
        particlesSizeTextBlocks(3).Text = Me.sizeOptions(Me.particleSizeOptions(0, 3) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(3), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(3), Me.Zx4 * yRatio / 2)

        'Z54
        particlesSizeTextBlocks(4).Text = Me.sizeOptions(Me.particleSizeOptions(0, 4) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(4), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(4), Me.Zx4 * yRatio / 2)

        'Z13
        particlesSizeTextBlocks(5).Text = Me.sizeOptions(Me.particleSizeOptions(1, 0) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(5), Me.Z1x * xRatio / 2 - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(5), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        'Z23
        particlesSizeTextBlocks(6).Text = Me.sizeOptions(Me.particleSizeOptions(1, 1) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(6), (Me.Z1x + Me.Z2x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(6), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        'Z33
        particlesSizeTextBlocks(7).Text = Me.sizeOptions(Me.particleSizeOptions(1, 2) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(7), (Me.Z1x + Me.Z2x + Me.Z3x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(7), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        'Z43
        particlesSizeTextBlocks(8).Text = Me.sizeOptions(Me.particleSizeOptions(1, 3) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(8), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(8), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        'Z53
        particlesSizeTextBlocks(9).Text = Me.sizeOptions(Me.particleSizeOptions(1, 4) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(9), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(9), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        'Z12
        particlesSizeTextBlocks(10).Text = Me.sizeOptions(Me.particleSizeOptions(2, 0) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(10), Me.Z1x * xRatio / 2 - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(10), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        'Z22
        particlesSizeTextBlocks(11).Text = Me.sizeOptions(Me.particleSizeOptions(2, 1) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(11), (Me.Z1x + Me.Z2x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(11), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        'Z32
        particlesSizeTextBlocks(12).Text = Me.sizeOptions(Me.particleSizeOptions(2, 2) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(12), (Me.Z1x + Me.Z2x + Me.Z3x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(12), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        'Z42
        particlesSizeTextBlocks(13).Text = Me.sizeOptions(Me.particleSizeOptions(2, 3) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(13), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(13), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        'Z52
        particlesSizeTextBlocks(14).Text = Me.sizeOptions(Me.particleSizeOptions(2, 4) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(14), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(14), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        'Z11
        particlesSizeTextBlocks(15).Text = Me.sizeOptions(Me.particleSizeOptions(3, 0) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(15), Me.Z1x * xRatio / 2 - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(15), (Me.Zx4 + Me.Zx3 + Me.Zx2 + Me.Zx1 / 2) * yRatio)

        'Z21
        particlesSizeTextBlocks(16).Text = Me.sizeOptions(Me.particleSizeOptions(3, 1) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(16), (Me.Z1x + Me.Z2x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(16), (Me.Zx4 + Me.Zx3 + Me.Zx2 + Me.Zx1 / 2) * yRatio)

        'Z31
        particlesSizeTextBlocks(17).Text = Me.sizeOptions(Me.particleSizeOptions(3, 2) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(17), (Me.Z1x + Me.Z2x + Me.Z3x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(17), (Me.Zx4 + Me.Zx3 + Me.Zx2 + Me.Zx1 / 2) * yRatio)

        'Z41
        particlesSizeTextBlocks(18).Text = Me.sizeOptions(Me.particleSizeOptions(3, 3) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(18), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(18), (Me.Zx4 + Me.Zx3 + Me.Zx2 + Me.Zx1 / 2) * yRatio)

        'Z51
        particlesSizeTextBlocks(19).Text = Me.sizeOptions(Me.particleSizeOptions(3, 4) - 1).ToString() + " mm"
        Canvas.SetLeft(particlesSizeTextBlocks(19), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x / 2) * xRatio - fontSize)
        Canvas.SetTop(particlesSizeTextBlocks(19), (Me.Zx4 + Me.Zx3 + Me.Zx2 + Me.Zx1 / 2) * yRatio)


    End Sub

    Private Sub DrawArrowLinesNumbers(ByVal xRatio As Double, ByVal yRatio As Double)

        Dim arrows(0 To 10) As SCPreprocessor.Arrow
        Dim textBlocks(0 To 10) As TextBlock
        For index As Integer = 0 To 10
            arrows(index) = New SCPreprocessor.Arrow()
            textBlocks(index) = New TextBlock()

            'init arrow shape
            arrows(index).HeadHeight = 4
            arrows(index).HeadWidth = 10
            arrows(index).Stroke = Brushes.Black
            arrows(index).StrokeThickness = 1

            'init textblock
            textBlocks(index).Foreground = Brushes.Black

            Me.geometryCanvas.Children.Add(arrows(index))
            Me.geometryCanvas.Children.Add(textBlocks(index))
        Next

        'setup arrow lines & text
        Dim fontSize As Double = textBlocks(0).FontSize
        arrows(0).X1 = -50
        arrows(0).Y1 = 0
        arrows(0).X2 = 0
        arrows(0).Y2 = arrows(0).Y1
        textBlocks(0).Text = (Me.Zx1 + Me.Zx2 + Me.Zx3 + Me.Zx4).ToString() + " m"
        Canvas.SetLeft(textBlocks(0), -80)
        Canvas.SetTop(textBlocks(0), 0 - 2 * fontSize / 3)

        arrows(1).X1 = -50
        arrows(1).Y1 = Me.Zx4 * yRatio
        arrows(1).X2 = 0
        arrows(1).Y2 = arrows(1).Y1
        textBlocks(1).Text = (Me.Zx1 + Me.Zx2 + Me.Zx3).ToString() + " m"
        Canvas.SetLeft(textBlocks(1), -80)
        Canvas.SetTop(textBlocks(1), Me.Zx4 * yRatio - 2 * fontSize / 3)

        arrows(2).X1 = -50
        arrows(2).Y1 = (Me.Zx4 + Me.Zx3) * yRatio
        arrows(2).X2 = 0
        arrows(2).Y2 = arrows(2).Y1
        textBlocks(2).Text = (Me.Zx1 + Me.Zx2).ToString() + " m"
        Canvas.SetLeft(textBlocks(2), -80)
        Canvas.SetTop(textBlocks(2), (Me.Zx3 + Me.Zx4) * yRatio - 2 * fontSize / 3)

        arrows(3).X1 = -50
        arrows(3).Y1 = (Me.Zx4 + Me.Zx3 + Me.Zx2) * yRatio
        arrows(3).X2 = 0
        arrows(3).Y2 = arrows(3).Y1
        textBlocks(3).Text = Me.Zx1.ToString() + " m"
        Canvas.SetLeft(textBlocks(3), -80)
        Canvas.SetTop(textBlocks(3), (Me.Zx2 + Me.Zx3 + Me.Zx4) * yRatio - 2 * fontSize / 3)

        arrows(4).X1 = -50
        arrows(4).Y1 = Me.geometryCanvas.Height
        arrows(4).X2 = 0
        arrows(4).Y2 = arrows(4).Y1
        textBlocks(4).Text = "0.0 m"
        Canvas.SetLeft(textBlocks(4), -80)
        Canvas.SetTop(textBlocks(4), Me.geometryCanvas.Height - 2 * fontSize / 3)

        arrows(5).X1 = 0
        arrows(5).Y1 = Me.geometryCanvas.Height + 40
        arrows(5).X2 = arrows(5).X1
        arrows(5).Y2 = Me.geometryCanvas.Height
        textBlocks(5).Text = "0.0 m"
        Canvas.SetLeft(textBlocks(5), 0)
        Canvas.SetTop(textBlocks(5), Me.geometryCanvas.Height + 40 + fontSize)

        arrows(6).X1 = Me.Z1x * xRatio
        arrows(6).Y1 = Me.geometryCanvas.Height + 40
        arrows(6).X2 = arrows(6).X1
        arrows(6).Y2 = Me.geometryCanvas.Height
        textBlocks(6).Text = Me.Z1x.ToString + "m"
        Canvas.SetLeft(textBlocks(6), Me.Z1x * yRatio)
        Canvas.SetTop(textBlocks(6), Me.geometryCanvas.Height + 40 + fontSize)

        arrows(7).X1 = (Me.Z1x + Me.Z2x) * xRatio
        arrows(7).Y1 = Me.geometryCanvas.Height + 40
        arrows(7).X2 = arrows(7).X1
        arrows(7).Y2 = Me.geometryCanvas.Height
        textBlocks(7).Text = (Me.Z1x + Me.Z2x).ToString() + "m"
        Canvas.SetLeft(textBlocks(7), (Me.Z1x + Me.Z2x) * yRatio)
        Canvas.SetTop(textBlocks(7), Me.geometryCanvas.Height + 40 + fontSize)

        arrows(8).X1 = (Me.Z1x + Me.Z2x + Me.Z3x) * xRatio
        arrows(8).Y1 = Me.geometryCanvas.Height + 40
        arrows(8).X2 = arrows(8).X1
        arrows(8).Y2 = Me.geometryCanvas.Height
        textBlocks(8).Text = (Me.Z1x + Me.Z2x + Me.Z3x).ToString() + "m"
        Canvas.SetLeft(textBlocks(8), (Me.Z1x + Me.Z2x + Me.Z3x) * xRatio)
        Canvas.SetTop(textBlocks(8), Me.geometryCanvas.Height + 40 + fontSize)

        arrows(9).X1 = (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x) * xRatio
        arrows(9).Y1 = Me.geometryCanvas.Height + 40
        arrows(9).X2 = arrows(9).X1
        arrows(9).Y2 = Me.geometryCanvas.Height
        textBlocks(9).Text = (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x).ToString() + "m"
        Canvas.SetLeft(textBlocks(9), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x) * xRatio)
        Canvas.SetTop(textBlocks(9), Me.geometryCanvas.Height + 40 + fontSize)

        arrows(10).X1 = Me.geometryCanvas.Width
        arrows(10).Y1 = Me.geometryCanvas.Height + 40
        arrows(10).X2 = arrows(10).X1
        arrows(10).Y2 = Me.geometryCanvas.Height
        textBlocks(10).Text = (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x).ToString() + "m"
        Canvas.SetLeft(textBlocks(10), Me.geometryCanvas.Width)
        Canvas.SetTop(textBlocks(10), Me.geometryCanvas.Height + 40 + fontSize)

    End Sub

    Private Sub DrawDistanceMarkers(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim textBlocks(0 To 8) As TextBlock
        For index As Integer = 0 To 8
            textBlocks(index) = New TextBlock()
            textBlocks(index).Foreground = Brushes.Black
            Me.geometryCanvas.Children.Add(textBlocks(index))
        Next

        textBlocks(0).Text = "Zx4"
        Canvas.SetLeft(textBlocks(0), -70)
        Canvas.SetTop(textBlocks(0), Me.Zx4 * yRatio / 2)

        textBlocks(1).Text = "Zx3"
        Canvas.SetLeft(textBlocks(1), -70)
        Canvas.SetTop(textBlocks(1), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        textBlocks(2).Text = "Zx2"
        Canvas.SetLeft(textBlocks(2), -70)
        Canvas.SetTop(textBlocks(2), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        textBlocks(3).Text = "Zx1"
        Canvas.SetLeft(textBlocks(3), -70)
        Canvas.SetTop(textBlocks(3), Me.geometryCanvas.Height - Me.Zx1 * yRatio / 2)

        textBlocks(4).Text = "Z1x"
        Canvas.SetLeft(textBlocks(4), Me.Z1x * xRatio / 2)
        Canvas.SetTop(textBlocks(4), Me.geometryCanvas.Height + 40)

        textBlocks(5).Text = "Z2x"
        Canvas.SetLeft(textBlocks(5), (Me.Z1x + Me.Z2x / 2) * xRatio)
        Canvas.SetTop(textBlocks(5), Me.geometryCanvas.Height + 40)

        textBlocks(6).Text = "Z3x"
        Canvas.SetLeft(textBlocks(6), (Me.Z1x + Me.Z2x + Me.Z3x / 2) * xRatio)
        Canvas.SetTop(textBlocks(6), Me.geometryCanvas.Height + 40)

        textBlocks(7).Text = "Z4x"
        Canvas.SetLeft(textBlocks(7), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x / 2) * xRatio)
        Canvas.SetTop(textBlocks(7), Me.geometryCanvas.Height + 40)

        textBlocks(8).Text = "Z5x"
        Canvas.SetLeft(textBlocks(8), (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x / 2) * xRatio)
        Canvas.SetTop(textBlocks(8), Me.geometryCanvas.Height + 40)

    End Sub

    Private Sub DrawDistanceArrows(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim stroke As Brush = Brushes.Red
        drawDoubleArrow(New Point(-40, 0), New Point(-40, Me.Zx4 * yRatio), stroke)
        drawDoubleArrow(New Point(-40, Me.Zx4 * yRatio), New Point(-40, (Me.Zx4 + Me.Zx3) * yRatio), stroke)
        drawDoubleArrow(New Point(-40, (Me.Zx4 + Me.Zx3) * yRatio), New Point(-40, (Me.Zx4 + Me.Zx3 + Me.Zx2) * yRatio), stroke)
        drawDoubleArrow(New Point(-40, (Me.Zx4 + Me.Zx3 + Me.Zx2) * yRatio), New Point(-40, Me.geometryCanvas.Height), stroke)
        drawDoubleArrow(New Point(0, Me.geometryCanvas.Height + 30), New Point(Me.Z1x * xRatio, Me.geometryCanvas.Height + 30), stroke)
        drawDoubleArrow(New Point(Me.Z1x * xRatio, Me.geometryCanvas.Height + 30), New Point((Me.Z1x + Me.Z2x) * xRatio, Me.geometryCanvas.Height + 30), stroke)
        drawDoubleArrow(New Point((Me.Z1x + Me.Z2x) * xRatio, Me.geometryCanvas.Height + 30), New Point((Me.Z1x + Me.Z2x + Me.Z3x) * xRatio, Me.geometryCanvas.Height + 30), stroke)
        drawDoubleArrow(New Point((Me.Z1x + Me.Z2x + Me.Z3x) * xRatio, Me.geometryCanvas.Height + 30), New Point((Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x) * xRatio, Me.geometryCanvas.Height + 30), stroke)
        drawDoubleArrow(New Point((Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x) * xRatio, Me.geometryCanvas.Height + 30), New Point(Me.geometryCanvas.Width, Me.geometryCanvas.Height + 30), stroke)

    End Sub

    Private Sub drawDoubleArrow(ByVal point1 As Point, ByVal point2 As Point, ByVal stroke As Brush)
        Dim arrow1, arrow2 As New Arrow()

        arrow1.X1 = point1.X
        arrow1.Y1 = point1.Y
        arrow1.X2 = point2.X
        arrow1.Y2 = point2.Y
        arrow1.HeadWidth = 10
        arrow1.HeadHeight = 4
        arrow1.Stroke = stroke
        arrow1.StrokeThickness = 1
        Me.geometryCanvas.Children.Add(arrow1)

        arrow2.X1 = point2.X
        arrow2.Y1 = point2.Y
        arrow2.X2 = point1.X
        arrow2.Y2 = point1.Y
        arrow2.HeadWidth = 15
        arrow2.HeadHeight = 5
        arrow2.Stroke = stroke
        arrow2.StrokeThickness = 0.5
        Me.geometryCanvas.Children.Add(arrow2)
    End Sub

    Private Sub DrawGrids(ByVal xRatio As Double, ByVal yRatio As Double)
        DrawHorizontalLines(xRatio, yRatio)
        DrawVerticalLines(xRatio, yRatio)
    End Sub

    'draw horizontal lines
    Private Sub DrawHorizontalLines(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim startY As Double = 0

        For i As Integer = 0 To 4
            Dim myLine As New Line()
            myLine.Stroke = Brushes.Black
            myLine.X1 = 0
            myLine.Y1 = startY
            myLine.X2 = Me.geometryCanvas.Width
            myLine.Y2 = startY
            myLine.HorizontalAlignment = HorizontalAlignment.Left
            myLine.VerticalAlignment = VerticalAlignment.Center
            myLine.StrokeThickness = 1
            Me.geometryCanvas.Children.Add(myLine)

            If i = 0 Then
                startY += Me.Zx4 * yRatio
            ElseIf i = 1 Then
                startY += Me.Zx3 * yRatio
            ElseIf i = 2 Then
                startY += Me.Zx2 * yRatio
            ElseIf i = 3 Then
                startY += Me.Zx1 * yRatio
            End If
        Next

    End Sub

    'draw vertical lines
    Private Sub DrawVerticalLines(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim startX As Double = 0

        'H1
        For i As Integer = 0 To 5
            Dim myLine As New Line()
            myLine.Stroke = Brushes.Black
            myLine.X1 = startX
            myLine.Y1 = 0
            myLine.X2 = startX
            myLine.Y2 = Me.geometryCanvas.Height
            myLine.HorizontalAlignment = HorizontalAlignment.Left
            myLine.VerticalAlignment = VerticalAlignment.Center
            myLine.StrokeThickness = 1
            Me.geometryCanvas.Children.Add(myLine)

            If i = 0 Then
                startX += Me.Z1x * xRatio
            ElseIf i = 1 Then
                startX += Me.Z2x * xRatio
            ElseIf i = 2 Then
                startX += Me.Z3x * xRatio
            ElseIf i = 3 Then
                startX += Me.Z4x * xRatio
            ElseIf i = 4 Then
                startX += Me.Z5x * xRatio
            End If
        Next

    End Sub

    Private Sub update(ByVal tempTextBox As TextBox)
        Dim value As Double = CDbl(tempTextBox.Text)
        Dim boxName As String = tempTextBox.Name
        Select Case boxName
            Case "T_Zx1"
                Me.Zx1 = value
                Exit Select
            Case "T_Zx2"
                Me.Zx2 = value
                Exit Select
            Case "T_Zx3"
                Me.Zx3 = value
                Exit Select
            Case "T_Zx4"
                Me.Zx4 = value
                Exit Select
            Case "T_Z1x"
                Me.Z1x = value
                Exit Select
            Case "T_Z2x"
                Me.Z2x = value
                Exit Select
            Case "T_Z3x"
                Me.Z3x = value
                Exit Select
            Case "T_Z4x"
                Me.Z4x = value
                Exit Select
            Case "T_Z5x"
                Me.Z5x = value
                Exit Select

        End Select
    End Sub

    'event hander when mouse click on geometryCanvas 
    Private Sub geometryCanvas_MouseLeftButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        'if random ,doesn't allow to speicify
        If Me.randomSize Then
            Return
        End If

        'get cell row and column, specify particle size option from dialog (1,2,3,4,5)
        Dim row, column As Integer
        Dim mouseLocation As Point = Mouse.GetPosition(Me.geometryCanvas)
        row = GetRow(mouseLocation.Y)
        column = GetColumn(mouseLocation.X)

        'init particle selection dialog
        diaglog = New SinterParticleSelectionForm(Me.sizeOptions, Me.particleSizeOptions(row, column))

        'pop up the dialog and get the focus until close the dialog
        diaglog.ShowDialog()

        'reset particle size of current cell
        Me.particleSizeOptions(row, column) = Me.diaglog.GetSelectedParticle()

        DrawGeometry()

    End Sub

    'Get the row number of particleSizes according to mouse's Y
    Private Function GetRow(ByVal y As Integer) As Integer
        Dim yRatio As Double = Me.geometryCanvas.Height / (Me.Zx1 + Me.Zx2 + Me.Zx3 + Me.Zx4)
        If y <= Me.Zx4 * yRatio Then
            Return 0
        ElseIf y <= (Me.Zx4 + Me.Zx3) * yRatio Then
            Return 1
        ElseIf y <= (Me.Zx4 + Me.Zx3 + Me.Zx2) * yRatio Then
            Return 2
        ElseIf y <= Me.geometryCanvas.Height Then
            Return 3
        End If
    End Function

    'Get the column number of particleSizes according to mouse's X
    Private Function GetColumn(ByVal x As Integer) As Integer
        Dim xRatio As Double = Me.geometryCanvas.Width / (Me.Z1x + Me.Z2x + Me.Z3x + Me.Z4x + Me.Z5x)
        If x <= Me.Z1x * xRatio Then
            Return 0
        ElseIf x <= (Me.Z1x + Me.Z2x) * xRatio Then
            Return 1
        ElseIf x <= (Me.Z1x + Me.Z2x + Me.Z3x) * xRatio Then
            Return 2
        ElseIf x <= Me.geometryCanvas.Width - Me.Z5x * xRatio Then
            Return 3
        ElseIf x <= Me.geometryCanvas.Width Then
            Return 4
        End If
    End Function


    Private Sub TextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs)
        Dim tempTextBox As TextBox = DirectCast(e.OriginalSource, TextBox)
        If (e.Key = Key.Enter) Then
            Try
                update(tempTextBox)
                DrawGeometry()
            Catch ex As Exception
                'do nothing
            End Try

        End If
    End Sub


    Private Sub defaultButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles defaultButton.Click
        Me.geometryCanvas.Children.Clear()
        InitDefaultGeometry()
        DrawGeometry()
    End Sub

    Private Sub RadioButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Me.RadioButton_Random.IsChecked Then
            Me.randomSize = True

            'reset random sizes
            For index As Integer = 10 To 29
                Dim row As Integer = (index - 10) \ 5
                Dim column As Integer = (index - 10) Mod 5
                Dim value As Integer = CInt(defaultDataList(index))

                Dim randomSizeOption As Integer = CInt(Int((5 * Rnd()) + 1))
                Me.particleSizeOptions(row, column) = randomSizeOption
            Next

            DrawGeometry()
        Else
            Me.randomSize = False
        End If
    End Sub
End Class
