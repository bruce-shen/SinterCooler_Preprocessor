Partial Public Class SinterProperties
    Private HeatCapacity(2, 6) As Double
    Private ThermalConductivity(2, 6) As Double
    Private SinterBulkDesntiy As Double
    Private SinterParticleApparentDensity As Double
    Private RadioStatus(0 To 5) As Boolean
    Private RadioValues(0 To 11) As Double
    Private uniform As Boolean
    Private AverageSize As Double
    Private sizePercents(1, 4) As Double

    Private defaultDataList As List(Of Double)

    Public Sub New(ByVal list As List(Of Double))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'Init default
        defaultDataList = list
        InitDefault()

        'init GUI
        InitGUI()

    End Sub

    Private Sub InitDefault()
        Dim row As Integer = 0
        Dim column As Integer = 0

        For index As Integer = 0 To 41
            If index <= 20 Then     'init HeatCapacity
                row = index \ 7
                column = index Mod 7
                Me.HeatCapacity(row, column) = defaultDataList(index)
            Else                    'init ThermalConductivity
                row = (index - 21) \ 7
                column = (index - 21) Mod 7
                Me.ThermalConductivity(row, column) = defaultDataList(index)
            End If
        Next

        'init SinterBulkDensity
        Me.SinterBulkDesntiy = defaultDataList(42)

        'init SinterParticleApparentDensity
        Me.SinterParticleApparentDensity = defaultDataList(43)

        'init RadioStatus
        For index As Integer = 44 To 49
            Me.RadioStatus(index - 44) = CBool(defaultDataList(index))
        Next

        For index As Integer = 50 To 61
            Me.RadioValues(index - 50) = defaultDataList(index)
        Next

        Me.uniform = CBool(defaultDataList(62))

        Me.AverageSize = defaultDataList(63)

        For index As Integer = 64 To 73
            row = (index - 64) \ 5
            column = (index - 64) Mod 5
            Me.sizePercents(row, column) = defaultDataList(index)
        Next
    End Sub

    Private Sub InitGUI()

        UpdateRadioArea()

        'SinterBulkDensity
        Me.T_SinterBulkDensity.Text = Me.SinterBulkDesntiy.ToString()

        'SinterParticleApparentDensity
        Me.T_SinterParticleApparentDensity.Text = Me.SinterParticleApparentDensity.ToString()

        'Radio Values
        Me.Radio_Value_1.Text = Me.RadioValues(0).ToString()
        Me.Radio_Value_2.Text = Me.RadioValues(1).ToString()
        Me.Radio_Value_3.Text = Me.RadioValues(2).ToString()
        Me.Radio_Value_4.Text = Me.RadioValues(3).ToString()
        Me.Radio_Value_5.Text = Me.RadioValues(4).ToString()
        Me.Radio_Value_6.Text = Me.RadioValues(5).ToString()
        Me.Radio_Value_7.Text = Me.RadioValues(6).ToString()
        Me.Radio_Value_8.Text = Me.RadioValues(7).ToString()
        Me.Radio_Value_9.Text = Me.RadioValues(8).ToString()
        Me.Radio_Value_10.Text = Me.RadioValues(9).ToString()
        Me.Radio_Value_11.Text = Me.RadioValues(10).ToString()
        Me.Radio_Value_12.Text = Me.RadioValues(11).ToString()

        'Uniform RadioButton check
        If Me.uniform Then
            Me.RadioButton_Uniform.IsChecked = True
            Me.RadioButton_Nonuniform.IsChecked = False
        Else
            Me.RadioButton_Uniform.IsChecked = False
            Me.RadioButton_Nonuniform.IsChecked = True
        End If

        'Size Percent
        Me.T_Size_1.Text = Me.sizePercents(0, 0).ToString()
        Me.T_Size_2.Text = Me.sizePercents(0, 1).ToString()
        Me.T_Size_3.Text = Me.sizePercents(0, 2).ToString()
        Me.T_Size_4.Text = Me.sizePercents(0, 3).ToString()
        Me.T_Size_5.Text = Me.sizePercents(0, 4).ToString()
        Me.T_Percent_1.Text = Me.sizePercents(1, 0).ToString()
        Me.T_Percent_2.Text = Me.sizePercents(1, 1).ToString()
        Me.T_Percent_3.Text = Me.sizePercents(1, 2).ToString()
        Me.T_Percent_4.Text = Me.sizePercents(1, 3).ToString()
        Me.T_Percent_5.Text = Me.sizePercents(1, 4).ToString()

    End Sub

    Private Sub UpdateRadioArea()
        Dim index_HeatCapacity As Integer
        Dim index_ThermalConductivity As Integer
        If Me.RadioStatus(0) Then
            index_HeatCapacity = 0
            Me.R_Radio_1.IsChecked = True
        ElseIf Me.RadioStatus(1) Then
            index_HeatCapacity = 1
            Me.R_Radio_2.IsChecked = True
        ElseIf Me.RadioStatus(2) Then
            index_HeatCapacity = 2
            Me.R_Radio_3.IsChecked = True
        End If

        If Me.RadioStatus(3) Then
            index_ThermalConductivity = 0
            Me.R_Radio_4.IsChecked = True
        ElseIf Me.RadioStatus(4) Then
            index_ThermalConductivity = 1
            Me.R_Radio_5.IsChecked = True
        ElseIf Me.RadioStatus(5) Then
            index_ThermalConductivity = 2
            Me.R_Radio_6.IsChecked = True
        End If

        'HeatCapacity
        Me.T_HeatCapacity_a.Text = Me.HeatCapacity(index_HeatCapacity, 0).ToString()
        Me.T_HeatCapacity_b1.Text = Me.HeatCapacity(index_HeatCapacity, 1).ToString()
        Me.T_HeatCapacity_b2.Text = Me.HeatCapacity(index_HeatCapacity, 2).ToString()
        Me.T_HeatCapacity_b3.Text = Me.HeatCapacity(index_HeatCapacity, 3).ToString()
        Me.T_HeatCapacity_n1.Text = Me.HeatCapacity(index_HeatCapacity, 4).ToString()
        Me.T_HeatCapacity_n2.Text = Me.HeatCapacity(index_HeatCapacity, 5).ToString()
        Me.T_HeatCapacity_n3.Text = Me.HeatCapacity(index_HeatCapacity, 6).ToString()

        'ThermalConductivity
        Me.T_ThermalConductivity_a.Text = Me.HeatCapacity(index_ThermalConductivity, 0).ToString()
        Me.T_ThermalConductivity_b1.Text = Me.HeatCapacity(index_ThermalConductivity, 1).ToString()
        Me.T_ThermalConductivity_b2.Text = Me.HeatCapacity(index_ThermalConductivity, 2).ToString()
        Me.T_ThermalConductivity_b3.Text = Me.HeatCapacity(index_ThermalConductivity, 3).ToString()
        Me.T_ThermalConductivity_n1.Text = Me.HeatCapacity(index_ThermalConductivity, 4).ToString()
        Me.T_ThermalConductivity_n2.Text = Me.HeatCapacity(index_ThermalConductivity, 5).ToString()
        Me.T_ThermalConductivity_n3.Text = Me.HeatCapacity(index_ThermalConductivity, 6).ToString()
    End Sub

    Private Sub Radio_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim radio As RadioButton = DirectCast(e.OriginalSource, RadioButton)
        Select Case radio.Name
            Case "R_Radio_1"
                Me.RadioStatus(0) = True
                Me.RadioStatus(1) = False
                Me.RadioStatus(2) = False
                Exit Select
            Case "R_Radio_2"
                Me.RadioStatus(0) = False
                Me.RadioStatus(1) = True
                Me.RadioStatus(2) = False
                Exit Select
            Case "R_Radio_3"
                Me.RadioStatus(0) = False
                Me.RadioStatus(1) = False
                Me.RadioStatus(2) = True
                Exit Select
            Case "R_Radio_4"
                Me.RadioStatus(3) = True
                Me.RadioStatus(4) = False
                Me.RadioStatus(5) = False
                Exit Select
            Case "R_Radio_5"
                Me.RadioStatus(3) = False
                Me.RadioStatus(4) = True
                Me.RadioStatus(5) = False
                Exit Select
            Case "R_Radio_6"
                Me.RadioStatus(3) = False
                Me.RadioStatus(4) = False
                Me.RadioStatus(5) = True
                Exit Select
        End Select

        UpdateRadioArea()
    End Sub

    Private Function GetCheckedRadioIndex(ByVal area As Integer) As Integer
        If area = 0 Then
            If Me.RadioStatus(0) Then
                Return 0
            ElseIf Me.RadioStatus(1) Then
                Return 1
            ElseIf Me.RadioStatus(2) Then
                Return 2
            End If
        ElseIf area = 1 Then
            If Me.RadioStatus(3) Then
                Return 0
            ElseIf Me.RadioStatus(4) Then
                Return 1
            ElseIf Me.RadioStatus(5) Then
                Return 2
            End If
        End If
    End Function

    Private Sub UpdateRadioAreaValue(ByVal area As Integer, ByVal column As Integer, ByVal value As Double)
        Dim row As Integer = GetCheckedRadioIndex(area)
        If area = 0 Then
            Me.HeatCapacity(row, column) = value
        ElseIf area = 1 Then
            Me.ThermalConductivity(row, column) = value
        End If
    End Sub

    Private Sub Update(ByVal tempTextBox As TextBox)
        Dim value As Double = CDbl(tempTextBox.Text)
        Dim boxName As String = tempTextBox.Name

        Select Case boxName
            Case "T_HeatCapacity_a"
                UpdateRadioAreaValue(0, 0, value)
                Exit Select
            Case "T_HeatCapacity_b1"
                UpdateRadioAreaValue(0, 1, value)
                Exit Select
            Case "T_HeatCapacity_b2"
                UpdateRadioAreaValue(0, 2, value)
                Exit Select
            Case "T_HeatCapacity_b3"
                UpdateRadioAreaValue(0, 3, value)
                Exit Select
            Case "T_HeatCapacity_n1"
                UpdateRadioAreaValue(0, 4, value)
                Exit Select
            Case "T_HeatCapacity_n2"
                UpdateRadioAreaValue(0, 5, value)
                Exit Select
            Case "T_HeatCapacity_n3"
                UpdateRadioAreaValue(0, 6, value)
                Exit Select
            Case "T_ThermalConductivity_a"
                UpdateRadioAreaValue(1, 0, value)
                Exit Select
            Case "T_ThermalConductivity_b1"
                UpdateRadioAreaValue(1, 1, value)
                Exit Select
            Case "T_ThermalConductivity_b2"
                UpdateRadioAreaValue(1, 2, value)
                Exit Select
            Case "T_ThermalConductivity_b3"
                UpdateRadioAreaValue(1, 3, value)
                Exit Select
            Case "T_ThermalConductivity_n1"
                UpdateRadioAreaValue(1, 4, value)
                Exit Select
            Case "T_ThermalConductivity_n2"
                UpdateRadioAreaValue(1, 5, value)
                Exit Select
            Case "T_ThermalConductivity_n3"
                UpdateRadioAreaValue(1, 6, value)
                Exit Select
            Case "Radio_Value_1"
                Me.RadioValues(0) = value
                Exit Select
            Case "Radio_Value_2"
                Me.RadioValues(1) = value
                Exit Select
            Case "Radio_Value_3"
                Me.RadioValues(2) = value
                Exit Select
            Case "Radio_Value_4"
                Me.RadioValues(2) = value
                Exit Select
            Case "Radio_Value_5"
                Me.RadioValues(4) = value
                Exit Select
            Case "Radio_Value_6"
                Me.RadioValues(5) = value
                Exit Select
            Case "Radio_Value_7"
                Me.RadioValues(6) = value
                Exit Select
            Case "Radio_Value_8"
                Me.RadioValues(7) = value
                Exit Select
            Case "Radio_Value_9"
                Me.RadioValues(8) = value
                Exit Select
            Case "Radio_Value_10"
                Me.RadioValues(9) = value
                Exit Select
            Case "Radio_Value_11"
                Me.RadioValues(10) = value
                Exit Select
            Case "Radio_Value_12"
                Me.RadioValues(11) = value
                Exit Select
            Case "T_SinterBulkDensity"
                Me.SinterBulkDesntiy = value
                Exit Select
            Case "T_SinterParticleApparentDensity"
                Me.SinterParticleApparentDensity = value
                Exit Select
            Case "T_AverageSize"
                Me.AverageSize = value
                Exit Select
            Case "T_Size_1"
                Me.sizePercents(0, 0) = value
                Exit Select
            Case "T_Size_2"
                Me.sizePercents(0, 1) = value
                Exit Select
            Case "T_Size_3"
                Me.sizePercents(0, 2) = value
                Exit Select
            Case "T_Size_4"
                Me.sizePercents(0, 3) = value
                Exit Select
            Case "T_Size_5"
                Me.sizePercents(0, 4) = value
                Exit Select
            Case "T_Percent_1"
                Me.sizePercents(1, 0) = value
                Exit Select
            Case "T_Percent_2"
                Me.sizePercents(1, 1) = value
                Exit Select
            Case "T_Percent_3"
                Me.sizePercents(1, 2) = value
                Exit Select
            Case "T_Percent_4"
                Me.sizePercents(1, 3) = value
                Exit Select
            Case "T_Percent_5"
                Me.sizePercents(1, 4) = value
                Exit Select
        End Select
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs)
        Dim textBox As TextBox = DirectCast(e.OriginalSource, TextBox)
        Try
            Update(textBox)
        Catch ex As Exception
            'Nothing
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        InitDefault()
        InitGUI()
    End Sub
End Class
