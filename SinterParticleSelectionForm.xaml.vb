Partial Public Class SinterParticleSelectionForm

    Private particleSizes As List(Of Double)    '5 particle size options 
    Private selectedParticle As Integer         'selected particle option(1,2,3,4,5)
    Public Sub New(ByVal list As List(Of Double), ByVal radioIndex As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.particleSizes = list
        Me.selectedParticle = radioIndex
        InitGUI()
    End Sub

    Public Function GetSelectedParticle() As Integer
        Return Me.selectedParticle
    End Function

    Private Sub InitGUI()
        Me.ParticleSize_1.Content = Me.particleSizes(0).ToString()
        Me.ParticleSize_2.Content = Me.particleSizes(1).ToString()
        Me.ParticleSize_3.Content = Me.particleSizes(2).ToString()
        Me.ParticleSize_4.Content = Me.particleSizes(3).ToString()
        Me.ParticleSize_5.Content = Me.particleSizes(4).ToString()

        Select Case Me.selectedParticle
            Case 1
                Me.ParticleSize_1.IsChecked = True
                Exit Select
            Case 2
                Me.ParticleSize_2.IsChecked = True
                Exit Select
            Case 3
                Me.ParticleSize_3.IsChecked = True
                Exit Select
            Case 4
                Me.ParticleSize_4.IsChecked = True
                Exit Select
            Case 5
                Me.ParticleSize_5.IsChecked = True
                Exit Select
        End Select
    End Sub


    Private Sub ParticleSize_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim radio As RadioButton = DirectCast(e.OriginalSource, RadioButton)
        Select Case radio.Name
            Case "ParticleSize_1"
                Me.selectedParticle = 1
                Exit Select
            Case "ParticleSize_2"
                Me.selectedParticle = 2
                Exit Select
            Case "ParticleSize_3"
                Me.selectedParticle = 3
                Exit Select
            Case "ParticleSize_4"
                Me.selectedParticle = 4
                Exit Select
            Case "ParticleSize_5"
                Me.selectedParticle = 5
                Exit Select
        End Select
    End Sub
End Class
