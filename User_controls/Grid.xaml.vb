Partial Public Class Grid

    Private V1_Height As Double
    Private V2_Height As Double
    Private V3_Height As Double
    Private V4_Height As Double
    Private H1_Width As Double
    Private H2_Width As Double
    Private H3_Width As Double

    Private V1_Grid As Integer
    Private V2_Grid As Integer
    Private V3_Grid As Integer
    Private V4_Grid As Integer
    Private H1_Grid As Integer
    Private H2_Grid As Integer
    Private H3_Grid As Integer

    Private sinterCoolerGeometry As New SinterCoolerGeometry()

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        InitDefaultGeometry()
        ' Add any initialization after the InitializeComponent() call.



    End Sub

    ' Default Grid
    Private Sub InitDefaultGeometry()
        Me.V1_Height = 1.0
        Me.V2_Height = 1.0
        Me.V3_Height = 3.0
        Me.V4_Height = 1.0
        Me.H1_Width = 1.0
        Me.H2_Width = 4.0
        Me.H3_Width = 1.0
        Me.V1_Grid = 4
        Me.V2_Grid = 5
        Me.V3_Grid = 7
        Me.V4_Grid = 5
        Me.H1_Grid = 6
        Me.H2_Grid = 12
        Me.H3_Grid = 4

        'Reset values for textboxes
        Me.T_V1_Height.Text = Me.V1_Height.ToString()
        Me.T_V2_Height.Text = Me.V2_Height.ToString()
        Me.T_V3_Height.Text = Me.V3_Height.ToString()
        Me.T_V4_Height.Text = Me.V4_Height.ToString()
        Me.T_H1_Width.Text = Me.H1_Width.ToString()
        Me.T_H2_Width.Text = Me.H2_Width.ToString()
        Me.T_H3_Width.Text = Me.H3_Width.ToString()
        Me.T_V1_Grid.Text = Me.V1_Grid.ToString()
        Me.T_V2_Grid.Text = Me.V2_Grid.ToString()
        Me.T_V3_Height.Text = Me.V3_Grid.ToString()
        Me.T_V4_Height.Text = Me.V4_Grid.ToString()
        Me.T_H1_Grid.Text = Me.H1_Grid.ToString()
        Me.T_H2_Grid.Text = Me.H2_Grid.ToString()
        Me.T_H3_Grid.Text = Me.H3_Grid.ToString()
    End Sub

    Private Sub TextBox_Value_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs)

    End Sub

    Private Sub TextBox_Grid_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs)

    End Sub
End Class
