Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Windows.Controls
Imports System.Windows.Shapes


Public NotInheritable Class Arrow
    Inherits Shape
#Region "Dependency Properties"

    Public Shared ReadOnly X1Property As DependencyProperty = DependencyProperty.Register("X1", GetType(Double), GetType(Arrow), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly Y1Property As DependencyProperty = DependencyProperty.Register("Y1", GetType(Double), GetType(Arrow), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly X2Property As DependencyProperty = DependencyProperty.Register("X2", GetType(Double), GetType(Arrow), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly Y2Property As DependencyProperty = DependencyProperty.Register("Y2", GetType(Double), GetType(Arrow), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly HeadWidthProperty As DependencyProperty = DependencyProperty.Register("HeadWidth", GetType(Double), GetType(Arrow), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))
    Public Shared ReadOnly HeadHeightProperty As DependencyProperty = DependencyProperty.Register("HeadHeight", GetType(Double), GetType(Arrow), New FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender Or FrameworkPropertyMetadataOptions.AffectsMeasure))

#End Region

#Region "CLR Properties"

    <TypeConverter(GetType(LengthConverter))> _
    Public Property X1() As Double
        Get
            Return CDbl(MyBase.GetValue(X1Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(X1Property, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property Y1() As Double
        Get
            Return CDbl(MyBase.GetValue(Y1Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(Y1Property, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property X2() As Double
        Get
            Return CDbl(MyBase.GetValue(X2Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(X2Property, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property Y2() As Double
        Get
            Return CDbl(MyBase.GetValue(Y2Property))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(Y2Property, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property HeadWidth() As Double
        Get
            Return CDbl(MyBase.GetValue(HeadWidthProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(HeadWidthProperty, value)
        End Set
    End Property

    <TypeConverter(GetType(LengthConverter))> _
    Public Property HeadHeight() As Double
        Get
            Return CDbl(MyBase.GetValue(HeadHeightProperty))
        End Get
        Set(ByVal value As Double)
            MyBase.SetValue(HeadHeightProperty, value)
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
                InternalDrawArrowGeometry(context)
            End Using

            ' Freeze the geometry for performance benefits
            geometry.Freeze()

            Return geometry
        End Get
    End Property

#End Region

#Region "Privates"

    Private Sub InternalDrawArrowGeometry(ByVal context As StreamGeometryContext)
        Dim theta As Double = Math.Atan2(Y1 - Y2, X1 - X2)
        Dim sint As Double = Math.Sin(theta)
        Dim cost As Double = Math.Cos(theta)

        Dim pt1 As New Point(X1, Me.Y1)
        Dim pt2 As New Point(X2, Me.Y2)

        Dim pt3 As New Point(X2 + (HeadWidth * cost - HeadHeight * sint), Y2 + (HeadWidth * sint + HeadHeight * cost))

        Dim pt4 As New Point(X2 + (HeadWidth * cost + HeadHeight * sint), Y2 - (HeadHeight * cost - HeadWidth * sint))

        context.BeginFigure(pt1, True, False)
        context.LineTo(pt2, True, True)
        context.LineTo(pt3, True, True)
        context.LineTo(pt2, True, True)
        context.LineTo(pt4, True, True)

      
    End Sub

#End Region
End Class
