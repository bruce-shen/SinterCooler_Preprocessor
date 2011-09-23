Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Windows.Controls
Imports System.Windows.Shapes


Public NotInheritable Class SinterCoolerGeometry
    Inherits Shape
#Region "Dependency Properties"

    Public Shared ReadOnly W1LProperty As DependencyProperty = DependencyProperty.Register("W1L", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W1RProperty As DependencyProperty = DependencyProperty.Register("W1R", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W2LProperty As DependencyProperty = DependencyProperty.Register("W2L", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W2RProperty As DependencyProperty = DependencyProperty.Register("W2R", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W3LProperty As DependencyProperty = DependencyProperty.Register("W3L", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W3RProperty As DependencyProperty = DependencyProperty.Register("W3R", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W4LProperty As DependencyProperty = DependencyProperty.Register("W4L", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly W4RProperty As DependencyProperty = DependencyProperty.Register("W4R", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly H1Property As DependencyProperty = DependencyProperty.Register("H1", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly H2Property As DependencyProperty = DependencyProperty.Register("H2", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly H3Property As DependencyProperty = DependencyProperty.Register("H3", GetType(Double), GetType(SinterCoolerGeometry), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))

#End Region

#Region "CLR Properties"

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W1L() As Double
        Get
            Return CDbl(MyBase.GetValue(W1LProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W1LProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
     Public Property W1R() As Double
        Get
            Return CDbl(MyBase.GetValue(W1RProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W1RProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W2L() As Double
        Get
            Return CDbl(MyBase.GetValue(W2LProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W2LProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W2R() As Double
        Get
            Return CDbl(MyBase.GetValue(W2RProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W2RProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W3L() As Double
        Get
            Return CDbl(MyBase.GetValue(W3LProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W3LProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W3R() As Double
        Get
            Return CDbl(MyBase.GetValue(W3RProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W3RProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W4L() As Double
        Get
            Return CDbl(MyBase.GetValue(W4LProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W4LProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property W4R() As Double
        Get
            Return CDbl(MyBase.GetValue(W4RProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(W4RProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property H1() As Double
        Get
            Return CDbl(MyBase.GetValue(H1Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(H1Property, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property H2() As Double
        Get
            Return CDbl(MyBase.GetValue(H2Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(H2Property, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property H3() As Double
        Get
            Return CDbl(MyBase.GetValue(H3Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(H3Property, value)
        End Set
    End Property

#End Region

#Region "Overrides"

    Protected Overrides ReadOnly Property DefiningGeometry() As System.Windows.Media.Geometry
        Get
            ' Create a StreamGeometry for describing the shape
            Dim geometry As New StreamGeometry()
            geometry.FillRule = FillRule.EvenOdd

            Using context As StreamGeometryContext = geometry.Open()
                InternalDrawSinterCoolerGeometry(context)
            End Using

            ' Freeze the geometry for performance benefits
            geometry.Freeze()

            Return geometry
        End Get
    End Property

#End Region

#Region "Privates"

    Private Sub InternalDrawSinterCoolerGeometry(ByVal context As StreamGeometryContext)

        Dim points(0 To 7) As Point
        Dim xLengthRatio As Double = 400 / (Me.W1L + Me.W1R)
        Dim yLengthRatio As Double = 400 / (Me.H1 + Me.H2 + Me.H3)

        points(0) = New Point(0, 0)
        points(1) = New Point(xLengthRatio * (Me.W1L - Me.W2L), yLengthRatio * Me.H1)
        points(2) = New Point(xLengthRatio * (Me.W1L - Me.W3L), yLengthRatio * (Me.H1 + Me.H2))
        points(3) = New Point(xLengthRatio * (Me.W1L - Me.W4L), 400)
        points(4) = New Point(xLengthRatio * (Me.W1L + Me.W4R), 400)
        points(5) = New Point(xLengthRatio * (Me.W1L + Me.W3R), yLengthRatio * (Me.H1 + Me.H2))
        points(6) = New Point(xLengthRatio * (Me.W1L + Me.W2R), yLengthRatio * Me.H1)
        points(7) = New Point(400, 0)

        'draw outline

        context.BeginFigure(points(0), True, False)
        context.LineTo(points(1), True, True)
        context.LineTo(points(2), True, True)
        context.LineTo(points(3), True, True)
        context.LineTo(points(4), True, True)
        context.LineTo(points(5), True, True)
        context.LineTo(points(6), True, True)
        context.LineTo(points(7), True, True)
        context.LineTo(points(0), True, True)
        context.LineTo(points(1), True, False)
        context.LineTo(points(6), True, True)
        context.LineTo(points(5), True, True)
        context.LineTo(points(2), True, True)

    End Sub

#End Region

End Class
