Partial Public Class Geometry

    Private sinterCoolerGeometry As New SinterCoolerGeometry()


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        InitDefaultGeometry()
        drawGeometry()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ' Default Geometry
    Private Sub InitDefaultGeometry()

        Me.sinterCoolerGeometry.W1L = 100
        Me.sinterCoolerGeometry.W1R = 100
        Me.sinterCoolerGeometry.W2L = 85
        Me.sinterCoolerGeometry.W2R = 85
        Me.sinterCoolerGeometry.W3L = 50
        Me.sinterCoolerGeometry.W3R = 50
        Me.sinterCoolerGeometry.W4L = 30
        Me.sinterCoolerGeometry.W4R = 30
        Me.sinterCoolerGeometry.H1 = 100
        Me.sinterCoolerGeometry.H2 = 30
        Me.sinterCoolerGeometry.H3 = 30
        

        'Reset values for textboxes
        Me.T_W1L.Text = Me.sinterCoolerGeometry.W1L.ToString
        Me.T_W1R.Text = Me.sinterCoolerGeometry.W1R.ToString
        Me.T_W2L.Text = Me.sinterCoolerGeometry.W2L.ToString
        Me.T_W2R.Text = Me.sinterCoolerGeometry.W2R.ToString
        Me.T_W3L.Text = Me.sinterCoolerGeometry.W3L.ToString
        Me.T_W3R.Text = Me.sinterCoolerGeometry.W3R.ToString
        Me.T_W4L.Text = Me.sinterCoolerGeometry.W4L.ToString
        Me.T_W4R.Text = Me.sinterCoolerGeometry.W4R.ToString
        Me.T_H1.Text = Me.sinterCoolerGeometry.H1.ToString
        Me.T_H2.Text = Me.sinterCoolerGeometry.H2.ToString
        Me.T_H3.Text = Me.sinterCoolerGeometry.H3.ToString
    End Sub


    'update value for geometry properties
    Private Sub update(ByVal tempTextBox As TextBox)
        Dim value As Double = CDbl(tempTextBox.Text)
        Dim boxName As String = tempTextBox.Name
        Select Case boxName
            Case "T_W1L"
                Me.sinterCoolerGeometry.W1L = value
                Exit Select
            Case "T_W1R"
                Me.sinterCoolerGeometry.W1R = value
                Exit Select
            Case "T_W2L"
                Me.sinterCoolerGeometry.W2L = value
                Exit Select
            Case "T_W2R"
                Me.sinterCoolerGeometry.W2R = value
                Exit Select
            Case "T_W3L"
                Me.sinterCoolerGeometry.W3L = value
                Exit Select
            Case "T_W3R"
                Me.sinterCoolerGeometry.W3R = value
                Exit Select
            Case "T_W4L"
                Me.sinterCoolerGeometry.W4L = value
                Exit Select
            Case "T_W4R"
                Me.sinterCoolerGeometry.W4R = value
                Exit Select
            Case "T_H1"
                Me.sinterCoolerGeometry.H1 = value
                Exit Select
            Case "T_H2"
                Me.sinterCoolerGeometry.H2 = value
                Exit Select
            Case "T_H3"
                Me.sinterCoolerGeometry.H3 = value
                Exit Select
        End Select
    End Sub

    'draw geometry
    Private Sub drawGeometry()

        Dim points(0 To 7) As Point
        Dim xLengthRatio As Double = Me.geometryCanvas.Width / (Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W1R)
        Dim yLengthRatio As Double = Me.geometryCanvas.Height / (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2 + Me.sinterCoolerGeometry.H3)
        points(0) = New Point(0, 0)
        points(1) = New Point(xLengthRatio * (Me.sinterCoolerGeometry.W1L - Me.sinterCoolerGeometry.W2L), yLengthRatio * Me.sinterCoolerGeometry.H1)
        points(2) = New Point(xLengthRatio * (Me.sinterCoolerGeometry.W1L - Me.sinterCoolerGeometry.W3L), yLengthRatio * (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2))
        points(3) = New Point(xLengthRatio * (Me.sinterCoolerGeometry.W1L - Me.sinterCoolerGeometry.W4L), Me.geometryCanvas.Height)
        points(4) = New Point(xLengthRatio * (Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W4R), Me.geometryCanvas.Height)
        points(5) = New Point(xLengthRatio * (Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W3R), yLengthRatio * (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2))
        points(6) = New Point(xLengthRatio * (Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W2R), yLengthRatio * Me.sinterCoolerGeometry.H1)
        points(7) = New Point(Me.geometryCanvas.Width, 0)

        'draw outline
        Me.sinterCoolerGeometry.Stroke = Brushes.Black
        Me.sinterCoolerGeometry.StrokeThickness = 1
        Me.geometryCanvas.Children.Add(sinterCoolerGeometry)

        'draw dash lines
        drawDashLines(points, xLengthRatio)

        'draw arrow liens
        drawArrowLines(xLengthRatio, yLengthRatio)

        drawPropertyMarkers(xLengthRatio, yLengthRatio)
    End Sub


    Private Sub drawDashLines(ByVal points() As Point, ByVal ratio As Double)
        drawSingleDashLine(points(0), True, True)
        drawSingleDashLine(points(0), False, True)
        drawSingleDashLine(points(1), True, True)
        drawSingleDashLine(points(1), False, True)
        drawSingleDashLine(points(2), True, True)
        drawSingleDashLine(points(2), False, True)
        drawSingleDashLine(points(3), True, True)
        drawSingleDashLine(points(3), False, False)
        drawSingleDashLine(points(4), False, False)
        drawSingleDashLine(points(5), False, True)
        drawSingleDashLine(points(6), False, True)
        drawSingleDashLine(points(7), False, True)

        'Draw 'central' dash line
        Dim centralLine As New Line()
        Dim dashes As New DoubleCollection()
        dashes.Add(4)
        dashes.Add(2)
        centralLine.StrokeDashArray = dashes
        centralLine.StrokeThickness = 1
        centralLine.Stroke = Brushes.Black
        centralLine.StrokeDashCap = PenLineCap.Round

        centralLine.X1 = Me.sinterCoolerGeometry.W1L * ratio
        centralLine.Y1 = -30
        centralLine.X2 = Me.sinterCoolerGeometry.W1L * ratio
        centralLine.Y2 = Me.geometryCanvas.Height + 30
        Me.geometryCanvas.Children.Add(centralLine)
    End Sub

    Private Sub drawArrowLines(ByVal xRatio As Double, ByVal yRatio As Double)
        drawArrow(New Point(-20, 0), New Point(-20, Me.sinterCoolerGeometry.H1 * yRatio))    'H1 arrow
        drawArrow(New Point(-20, Me.sinterCoolerGeometry.H1 * yRatio), New Point(-20, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio)) 'H2 arrow
        drawArrow(New Point(-20, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio), New Point(-20, Me.geometryCanvas.Height))   'H3 arrow
        drawArrow(New Point(0, -15), New Point(Me.sinterCoolerGeometry.W1L * xRatio, -15))  'W1L arrow
        drawArrow(New Point(Me.sinterCoolerGeometry.W1L * xRatio, -15), New Point(Me.geometryCanvas.Width, -15)) 'W1R arrow
        drawArrow(New Point((Me.sinterCoolerGeometry.W1L - Me.sinterCoolerGeometry.W2L) * xRatio, Me.sinterCoolerGeometry.H1 * yRatio - 20), New Point(Me.sinterCoolerGeometry.W1L * xRatio, Me.sinterCoolerGeometry.H1 * yRatio - 20)) 'W2L arrow
        drawArrow(New Point(Me.sinterCoolerGeometry.W1L * xRatio, Me.sinterCoolerGeometry.H1 * yRatio - 20), New Point((Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W2R) * xRatio, Me.sinterCoolerGeometry.H1 * yRatio - 20)) 'W2R arrow
        drawArrow(New Point((Me.sinterCoolerGeometry.W1L - Me.sinterCoolerGeometry.W3L) * xRatio, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio - 20), New Point(Me.sinterCoolerGeometry.W1L * xRatio, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio - 20))    'draw W3L arrow
        drawArrow(New Point(Me.sinterCoolerGeometry.W1L * xRatio, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio - 20), New Point((Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W3R) * xRatio, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio - 20))   'draw W3R arrow
        drawArrow(New Point((Me.sinterCoolerGeometry.W1L - Me.sinterCoolerGeometry.W4L) * xRatio, Me.geometryCanvas.Height + 15), New Point(Me.sinterCoolerGeometry.W1L * xRatio, Me.geometryCanvas.Height + 15))    'W4L arrow
        drawArrow(New Point(Me.sinterCoolerGeometry.W1L * xRatio, Me.geometryCanvas.Height + 15), New Point((Me.sinterCoolerGeometry.W1L + Me.sinterCoolerGeometry.W4R) * xRatio, Me.geometryCanvas.Height + 15))    'W4R arrow
    End Sub

    Private Sub drawArrow(ByVal point1 As Point, ByVal point2 As Point)
        Dim arrow1, arrow2 As New Arrow()

        arrow1.X1 = point1.X
        arrow1.Y1 = point1.Y
        arrow1.X2 = point2.X
        arrow1.Y2 = point2.Y
        arrow1.HeadWidth = 10
        arrow1.HeadHeight = 4
        arrow1.Stroke = Brushes.Black
        arrow1.StrokeThickness = 1
        Me.geometryCanvas.Children.Add(arrow1)

        arrow2.X1 = point2.X
        arrow2.Y1 = point2.Y
        arrow2.X2 = point1.X
        arrow2.Y2 = point1.Y
        arrow2.HeadWidth = 15
        arrow2.HeadHeight = 5
        arrow2.Stroke = Brushes.Black
        arrow2.StrokeThickness = 0.5
        Me.geometryCanvas.Children.Add(arrow2)
    End Sub

    Private Sub drawPropertyMarkers(ByVal xRatio As Double, ByVal yRatio As Double)
        Dim tb_H1 As New TextBlock()
        Dim tb_H2 As New TextBlock()
        Dim tb_H3 As New TextBlock()
        Dim tb_W1L As New TextBlock()
        Dim tb_W1R As New TextBlock()
        Dim tb_W2L As New TextBlock()
        Dim tb_W2R As New TextBlock()
        Dim tb_W3L As New TextBlock()
        Dim tb_W3R As New TextBlock()
        Dim tb_W4L As New TextBlock()
        Dim tb_W4R As New TextBlock()

        'draw H1 
        tb_H1.Text = "H1"
        tb_H1.Foreground = Brushes.Black
        Canvas.SetLeft(tb_H1, -50)
        Canvas.SetTop(tb_H1, Me.sinterCoolerGeometry.H1 * yRatio / 2)
        Me.geometryCanvas.Children.Add(tb_H1)

        'draw H2
        tb_H2.Text = "H2"
        tb_H2.Foreground = Brushes.Black
        Canvas.SetLeft(tb_H2, -50)
        Canvas.SetTop(tb_H2, Me.sinterCoolerGeometry.H1 * yRatio + Me.sinterCoolerGeometry.H2 * yRatio / 2)
        Me.geometryCanvas.Children.Add(tb_H2)

        'draw H3
        tb_H3.Text = "H3"
        tb_H3.Foreground = Brushes.Black
        Canvas.SetLeft(tb_H3, -50)
        Canvas.SetTop(tb_H3, Me.geometryCanvas.Height - Me.sinterCoolerGeometry.H3 * yRatio / 2)
        Me.geometryCanvas.Children.Add(tb_H3)

        'draw W1L
        tb_W1L.Text = "W1L"
        tb_W1L.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W1L, Me.sinterCoolerGeometry.W1L * xRatio / 2)
        Canvas.SetTop(tb_W1L, -40)
        Me.geometryCanvas.Children.Add(tb_W1L)

        'draw W1R
        tb_W1R.Text = "W1R"
        tb_W1R.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W1R, Me.sinterCoolerGeometry.W1L * xRatio + Me.sinterCoolerGeometry.W1R * xRatio / 2)
        Canvas.SetTop(tb_W1R, -40)
        Me.geometryCanvas.Children.Add(tb_W1R)

        'draw W2L
        tb_W2L.Text = "W2L"
        tb_W2L.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W2L, Me.sinterCoolerGeometry.W1L * xRatio - Me.sinterCoolerGeometry.W2L * xRatio / 2)
        Canvas.SetTop(tb_W2L, Me.sinterCoolerGeometry.H1 * yRatio - 40)
        Me.geometryCanvas.Children.Add(tb_W2L)

        'draw W2R
        tb_W2R.Text = "W2R"
        tb_W2R.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W2R, Me.sinterCoolerGeometry.W1L * xRatio + Me.sinterCoolerGeometry.W2R * xRatio / 2)
        Canvas.SetTop(tb_W2R, Me.sinterCoolerGeometry.H1 * yRatio - 40)
        Me.geometryCanvas.Children.Add(tb_W2R)

        'draw W3L
        tb_W3L.Text = "W3L"
        tb_W3L.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W3L, Me.sinterCoolerGeometry.W1L * xRatio - Me.sinterCoolerGeometry.W3L * xRatio / 2)
        Canvas.SetTop(tb_W3L, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio - 40)
        Me.geometryCanvas.Children.Add(tb_W3L)

        'draw W3R
        tb_W3R.Text = "W3R"
        tb_W3R.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W3R, Me.sinterCoolerGeometry.W1L * xRatio + Me.sinterCoolerGeometry.W3R * xRatio / 2)
        Canvas.SetTop(tb_W3R, (Me.sinterCoolerGeometry.H1 + Me.sinterCoolerGeometry.H2) * yRatio - 40)
        Me.geometryCanvas.Children.Add(tb_W3R)

        'draw W4L
        tb_W4L.Text = "W4L"
        tb_W4L.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W4L, Me.sinterCoolerGeometry.W1L * xRatio - Me.sinterCoolerGeometry.W4L * xRatio / 2)
        Canvas.SetTop(tb_W4L, Me.geometryCanvas.Height + 20)
        Me.geometryCanvas.Children.Add(tb_W4L)

        'draw W4R
        tb_W4R.Text = "W4R"
        tb_W4R.Foreground = Brushes.Black
        Canvas.SetLeft(tb_W4R, Me.sinterCoolerGeometry.W1L * xRatio + Me.sinterCoolerGeometry.W4R * xRatio / 2)
        Canvas.SetTop(tb_W4R, Me.geometryCanvas.Height + 20)
        Me.geometryCanvas.Children.Add(tb_W4R)

    End Sub

    Private Sub drawSingleDashLine(ByVal point As Point, ByVal horizontal As Boolean, ByVal upSide As Boolean)
        Dim line As New Line()
        Dim dashes As New DoubleCollection()
        dashes.Add(4)
        dashes.Add(2)
        line.StrokeDashArray = dashes
        line.StrokeThickness = 1
        line.Stroke = Brushes.Black
        line.StrokeDashCap = PenLineCap.Round

        If (horizontal) Then
            line.X1 = -30
            line.Y1 = point.Y
            line.X2 = point.X
            line.Y2 = point.Y
        ElseIf (upSide) Then
            line.X1 = point.X
            line.Y1 = point.Y
            line.X2 = point.X
            line.Y2 = point.Y - 30
        Else
            line.X1 = point.X
            line.Y1 = point.Y
            line.X2 = point.X
            line.Y2 = point.Y + 30
        End If

        Me.geometryCanvas.Children.Add(line)
    End Sub

    Private Sub defaultButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles defaultButton.Click
        Me.geometryCanvas.Children.Clear()
        InitDefaultGeometry()
        drawGeometry()
    End Sub

    Private Sub proceedButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles proceedButton.Click

    End Sub


    Private Sub TextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs)
        Dim tempTextBox As TextBox = DirectCast(e.OriginalSource, TextBox)
        If (e.Key = Key.Enter) Then
            Try
                Me.geometryCanvas.Children.Clear()
                update(tempTextBox)
                drawGeometry()
            Catch ex As Exception
                'do nothing
            End Try

        End If

    End Sub
End Class
