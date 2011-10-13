Partial Public Class Grid

    Private Zx1 As Double
    Private Zx2 As Double
    Private Zx3 As Double
    Private Zx4 As Double
    Private Z1x As Double
    Private Z2x As Double
    Private Z3x As Double

    Private V1_Grid As Integer
    Private V2_Grid As Integer
    Private V3_Grid As Integer
    Private V4_Grid As Integer
    Private H1_Grid As Integer
    Private H2_Grid As Integer
    Private H3_Grid As Integer

    Private sinterCoolerGeometry
    Private defaultDataList As List(Of Double)

    Public Sub New(ByVal list As List(Of Double))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

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

    ' Default Grid
    Private Sub InitDefaultGeometry()
        Me.Zx1 = defaultDataList(0)
        Me.Zx2 = defaultDataList(1)
        Me.Zx3 = defaultDataList(2)
        Me.Zx4 = defaultDataList(3)
        Me.Z1x = defaultDataList(4)
        Me.Z2x = defaultDataList(5)
        Me.Z3x = defaultDataList(6)
        Me.V1_Grid = defaultDataList(7)
        Me.V2_Grid = defaultDataList(8)
        Me.V3_Grid = defaultDataList(9)
        Me.V4_Grid = defaultDataList(10)
        Me.H1_Grid = defaultDataList(11)
        Me.H2_Grid = defaultDataList(12)
        Me.H3_Grid = defaultDataList(13)

        'Reset values for textboxes
        Me.T_Zx1.Text = Me.Zx1.ToString()
        Me.T_Zx2.Text = Me.Zx2.ToString()
        Me.T_Zx3.Text = Me.Zx3.ToString()
        Me.T_Zx4.Text = Me.Zx4.ToString()
        Me.T_Z1x.Text = Me.Z1x.ToString()
        Me.T_Z2x.Text = Me.Z2x.ToString()
        Me.T_Z3x.Text = Me.Z3x.ToString()
        Me.T_V1_Grid.Text = Me.V1_Grid.ToString()
        Me.T_V2_Grid.Text = Me.V2_Grid.ToString()
        Me.T_V3_Grid.Text = Me.V3_Grid.ToString()
        Me.T_V4_Grid.Text = Me.V4_Grid.ToString()
        Me.T_H1_Grid.Text = Me.H1_Grid.ToString()
        Me.T_H2_Grid.Text = Me.H2_Grid.ToString()
        Me.T_H3_Grid.Text = Me.H3_Grid.ToString()

    End Sub

    Public Sub DrawGeometry()
        Me.geometryCanvas.Children.Clear()
        Me.sinterCoolerGemometry.Stroke = Brushes.Blue
        Me.geometryCanvas.Children.Add(Me.sinterCoolerGeometry)

        Dim xRatio As Double = Me.geometryCanvas.Width / (Me.Z1x + Me.Z2x + Me.Z3x)
        Dim yRatio As Double = Me.geometryCanvas.Height / (Me.Zx1 + Me.Zx2 + Me.Zx3 + Me.Zx4)
        DrawArrowLinesNumbers(xRatio, yRatio)
        DrawDistanceMarkers(xRatio, yRatio)
        DrawDistanceArrows(xRatio, yRatio)
        DrawGrids(xRatio, yRatio)
    End Sub

    Private Sub DrawArrowLinesNumbers(ByVal xRatio As Double, ByVal yRatio As Double)

        Dim arrows(0 To 8) As SCPreprocessor.Arrow
        Dim textBlocks(0 To 8) As TextBlock
        For index As Integer = 0 To 8
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
        arrows(5).Y1 = Me.geometryCanvas.Height + 50
        arrows(5).X2 = arrows(5).X1
        arrows(5).Y2 = Me.geometryCanvas.Height
        textBlocks(5).Text = "0.0 m"
        Canvas.SetLeft(textBlocks(5), 0)
        Canvas.SetTop(textBlocks(5), Me.geometryCanvas.Height + 50 + fontSize)

        arrows(6).X1 = Me.Z1x * xRatio
        arrows(6).Y1 = Me.geometryCanvas.Height + 50
        arrows(6).X2 = arrows(6).X1
        arrows(6).Y2 = Me.geometryCanvas.Height
        textBlocks(6).Text = Me.Z1x.ToString + "m"
        Canvas.SetLeft(textBlocks(6), Me.Z1x * yRatio)
        Canvas.SetTop(textBlocks(6), Me.geometryCanvas.Height + 50 + fontSize)

        arrows(7).X1 = (Me.Z1x + Me.Z2x) * xRatio
        arrows(7).Y1 = Me.geometryCanvas.Height + 50
        arrows(7).X2 = arrows(7).X1
        arrows(7).Y2 = Me.geometryCanvas.Height
        textBlocks(7).Text = (Me.Z1x + Me.Z2x).ToString() + "m"
        Canvas.SetLeft(textBlocks(7), (Me.Z1x + Me.Z2x) * yRatio)
        Canvas.SetTop(textBlocks(7), Me.geometryCanvas.Height + 50 + fontSize)

        arrows(8).X1 = Me.geometryCanvas.Width
        arrows(8).Y1 = Me.geometryCanvas.Height + 50
        arrows(8).X2 = arrows(8).X1
        arrows(8).Y2 = Me.geometryCanvas.Height
        textBlocks(8).Text = (Me.Z1x + Me.Z2x + Me.Z3x).ToString() + "m"
        Canvas.SetLeft(textBlocks(8), Me.geometryCanvas.Width)
        Canvas.SetTop(textBlocks(8), Me.geometryCanvas.Height + 50 + fontSize)

    End Sub

    Private Sub DrawDistanceMarkers(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim textBlocks(0 To 6) As TextBlock
        For index As Integer = 0 To 6
            textBlocks(index) = New TextBlock()
            textBlocks(index).Foreground = Brushes.Black
            Me.geometryCanvas.Children.Add(textBlocks(index))
        Next

        textBlocks(0).Text = "V4"
        Canvas.SetLeft(textBlocks(0), -70)
        Canvas.SetTop(textBlocks(0), Me.Zx4 * yRatio / 2)

        textBlocks(1).Text = "V3"
        Canvas.SetLeft(textBlocks(1), -70)
        Canvas.SetTop(textBlocks(1), (Me.Zx4 + Me.Zx3 / 2) * yRatio)

        textBlocks(2).Text = "V2"
        Canvas.SetLeft(textBlocks(2), -70)
        Canvas.SetTop(textBlocks(2), (Me.Zx4 + Me.Zx3 + Me.Zx2 / 2) * yRatio)

        textBlocks(3).Text = "V1"
        Canvas.SetLeft(textBlocks(3), -70)
        Canvas.SetTop(textBlocks(3), Me.geometryCanvas.Height - Me.Zx1 * yRatio / 2)

        textBlocks(4).Text = "H1"
        Canvas.SetLeft(textBlocks(4), Me.Z1x * xRatio / 2)
        Canvas.SetTop(textBlocks(4), Me.geometryCanvas.Height + 40)

        textBlocks(5).Text = "H2"
        Canvas.SetLeft(textBlocks(5), (Me.Z1x + Me.Z2x / 2) * xRatio)
        Canvas.SetTop(textBlocks(5), Me.geometryCanvas.Height + 40)

        textBlocks(6).Text = "H3"
        Canvas.SetLeft(textBlocks(6), (Me.Z1x + Me.Z2x + Me.Z3x / 2) * xRatio)
        Canvas.SetTop(textBlocks(6), Me.geometryCanvas.Height + 40)

    End Sub

    Private Sub DrawDistanceArrows(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim stroke As Brush = Brushes.Red
        drawDoubleArrow(New Point(-40, 0), New Point(-40, Me.Zx4 * yRatio), stroke)
        drawDoubleArrow(New Point(-40, Me.Zx4 * yRatio), New Point(-40, (Me.Zx4 + Me.Zx3) * yRatio), stroke)
        drawDoubleArrow(New Point(-40, (Me.Zx4 + Me.Zx3) * yRatio), New Point(-40, (Me.Zx4 + Me.Zx3 + Me.Zx2) * yRatio), stroke)
        drawDoubleArrow(New Point(-40, (Me.Zx4 + Me.Zx3 + Me.Zx2) * yRatio), New Point(-40, Me.geometryCanvas.Height), stroke)
        drawDoubleArrow(New Point(0, Me.geometryCanvas.Height + 30), New Point(Me.Z1x * xRatio, Me.geometryCanvas.Height + 30), stroke)
        drawDoubleArrow(New Point(Me.Z1x * xRatio, Me.geometryCanvas.Height + 30), New Point((Me.Z1x + Me.Z2x) * xRatio, Me.geometryCanvas.Height + 30), stroke)
        drawDoubleArrow(New Point((Me.Z1x + Me.Z2x) * xRatio, Me.geometryCanvas.Height + 30), New Point(Me.geometryCanvas.Width, Me.geometryCanvas.Height + 30), stroke)
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
        Dim grid As Integer = CInt(Me.V4_Grid)

        'V4
        For i As Integer = 0 To grid - 1
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

            startY += Me.Zx4 * yRatio / grid
        Next

        'V3
        grid = CInt(Me.V3_Grid)
        For i As Integer = 0 To grid - 1
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

            startY += Me.Zx3 * yRatio / grid
        Next

        'V2
        grid = CInt(Me.V2_Grid)
        For i As Integer = 0 To grid - 1
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

            startY += Me.Zx2 * yRatio / grid
        Next

        'V1
        grid = CInt(Me.V1_Grid)
        For i As Integer = 0 To grid - 1
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

            startY += Me.Zx1 * yRatio / grid
        Next
    End Sub

    'draw vertical lines
    Private Sub DrawVerticalLines(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim startX As Double = 0
        Dim grid As Integer = CInt(Me.H1_Grid)

        'H1
        For i As Integer = 0 To grid - 1
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

            startX += Me.Z1x * xRatio / grid
        Next

        'H2
        grid = CInt(Me.H2_Grid)
        For i As Integer = 0 To grid - 1
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

            startX += Me.Z2x * xRatio / grid
        Next

        'H3
        grid = CInt(Me.H3_Grid)
        For i As Integer = 0 To grid - 1
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

            startX += Me.Z3x * xRatio / grid
        Next

    End Sub

    'update value for grid
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
            Case "T_V1_Grid"
                Me.V1_Grid = CInt(value)
                Exit Select
            Case "T_V2_Grid"
                Me.V2_Grid = CInt(value)
                Exit Select
            Case "T_V3_Grid"
                Me.V3_Grid = CInt(value)
                Exit Select
            Case "T_V4_Grid"
                Me.V4_Grid = CInt(value)
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
            Case "T_H1_Grid"
                Me.H1_Grid = CInt(value)
                Exit Select
            Case "T_H2_Grid"
                Me.H2_Grid = CInt(value)
                Exit Select
            Case "T_H3_Grid"
                Me.H3_Grid = CInt(value)
                Exit Select
        End Select
    End Sub

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
End Class
