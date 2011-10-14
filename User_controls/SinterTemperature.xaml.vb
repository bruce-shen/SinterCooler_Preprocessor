Partial Public Class SinterTemperature
    Private randomSize As Boolean
    Private averageTemperature As Double
    Private temperatures(0 To 4) As Double

    Private defaultDataList As List(Of Double)

    Public Sub New(ByVal List As List(Of Double))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        defaultDataList = List

        Init()

    End Sub

    Private Sub Init()
        'random size
        Me.randomSize = CBool(Me.defaultDataList(0))

        'average temperature value
        Me.averageTemperature = CDbl(Me.defaultDataList(1))

        'temperatures
        For index As Integer = 2 To 6
            Dim value As Double = Me.defaultDataList(index)
            Me.temperatures(index - 2) = value
        Next

        Update()
    End Sub

    Private Sub Update()
        If (Me.randomSize) Then
            Me.RadioButton_average.IsChecked = True
            Me.T_Average.IsEnabled = True
            Me.T_Temperature_1.IsEnabled = False
            Me.T_Temperature_2.IsEnabled = False
            Me.T_Temperature_3.IsEnabled = False
            Me.T_Temperature_4.IsEnabled = False
            Me.T_Temperature_5.IsEnabled = False
        Else
            Me.RadioButton_specify.IsChecked = True
            Me.T_Average.IsEnabled = False
            Me.T_Temperature_1.IsEnabled = True
            Me.T_Temperature_2.IsEnabled = True
            Me.T_Temperature_3.IsEnabled = True
            Me.T_Temperature_4.IsEnabled = True
            Me.T_Temperature_5.IsEnabled = True
        End If

        Me.T_Average.Text = Me.averageTemperature.ToString()
        Me.T_Temperature_1.Text = Me.temperatures(0).ToString()
        Me.T_Temperature_2.Text = Me.temperatures(1).ToString()
        Me.T_Temperature_3.Text = Me.temperatures(2).ToString()
        Me.T_Temperature_4.Text = Me.temperatures(3).ToString()
        Me.T_Temperature_5.Text = Me.temperatures(4).ToString()
    End Sub

    Private Sub RadioButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Me.RadioButton_average.IsChecked Then
            Me.randomSize = True
        Else
            Me.randomSize = False
        End If
        Update()
    End Sub
End Class
