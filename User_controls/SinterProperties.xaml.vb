Partial Public Class SinterProperties
    Private HeatCapacity(2, 6) As Double
    Private ThermalConductivity(2, 6) As Double
    Private SinterBulkDesntiy As Double
    Private SinterParticleApparentDensity As Double
    Private RadioStatus(0 To 5) As Boolean
    Private RadioValues(0 To 11) As Double

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim fileIni As New FileIni("setup.ini")
        'Init default
        InitDefault(fileIni.GetPropertities())

        'init GUI
        InitGUI()

    End Sub

    Private Sub InitDefault(ByVal list As List(Of Double))
        Dim row As Integer = 0
        Dim column As Integer = 0

        For index As Integer = 0 To 41
            If index <= 20 Then     'init HeatCapacity
                row = index \ 7
                column = index Mod 7
                Me.HeatCapacity(row, column) = list(index)
            Else                    'init ThermalConductivity
                row = (index - 21) \ 7
                column = (index - 21) Mod 7
                Me.ThermalConductivity(row, column) = list(index)
            End If
        Next

        'init SinterBulkDensity
        Me.SinterBulkDesntiy = list(42)

        'init SinterParticleApparentDensity
        Me.SinterParticleApparentDensity = list(43)

        'init RadioStatus
        For index As Integer = 44 To 49
            'Me.RadioStatus(index - 44) = CBool(list(index))
        Next

        For index As Integer = 50 To 61
            Me.RadioValues(index - 50) = list(index)
        Next
    End Sub

    Private Sub InitGUI()
        Dim index_HeatCapacity As Integer
        Dim index_ThermalConductivity As Integer
        If Me.RadioStatus(0) Then
            index_HeatCapacity = 0
        ElseIf Me.RadioStatus(1) Then
            index_HeatCapacity = 1
        ElseIf Me.RadioStatus(2) Then
            index_HeatCapacity = 2
        End If

        If Me.RadioStatus(3) Then
            index_ThermalConductivity = 3
        ElseIf Me.RadioStatus(4) Then
            index_ThermalConductivity = 4
        ElseIf Me.RadioStatus(5) Then
            index_ThermalConductivity = 5
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

    End Sub
End Class
