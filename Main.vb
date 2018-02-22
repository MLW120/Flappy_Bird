Public Class Form1
    Public B As New Bird
    Public h() As Bars
    Public bool As Boolean = True
    Public count As Integer = 0
    Public narrow As Integer = 150
    Public narrowD As Double = 150
    Public press As Boolean = True
    Public dificulty As Integer = 1
    Public Gravity As Double
    Public LastPosition() As Double
    Public Link As String = "C:\Users\marc\documents\ejecutables\Flappy.txt"

    Private Sub Form1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If press Then
            If e.KeyData = Keys.Space Then
                B.Up()
            End If
            press = False
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Space Then
            press = True
        End If
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Gravity = 0.1
        PositionUpdate(True)
    End Sub

    Private Sub Timer_Tick(sender As System.Object, e As System.EventArgs) Handles Timer.Tick
        B.Update()

        If bool Then
            ReDim Preserve h(0)
            h(0) = New Huecos
            bool = False
        End If

        For i As Integer = 0 To h.Length - 1
            h(i).Update()
            If h(i).x = 330 Then
                ReDim Preserve h(i + 1)
                h(i + 1) = New Huecos(h(i))
            End If
            If h(i).x = B.x Then
                count += 1
                narrowD -= 0.7
                narrow = narrowD
            End If
            If h(i).Touching(B) Then
                Timer.Enabled = False
                Dim msg = MsgBox("Su resultado es: " & count & vbCrLf & "Si desea empezar otra partida presione ""Aceptar"", en caso contrario presione ""Cancelar"" para salir.", MsgBoxStyle.OkCancel, "Restart")
                If msg = MsgBoxResult.Ok Then Application.Restart()
                If msg = MsgBoxResult.Cancel Then Application.Exit()
            End If
        Next

        PositionUpdate(False)
        CountUpdate()
    End Sub

    Private Sub PositionUpdate(ByVal PrimerCop As Boolean)

        If PrimerCop Then
            Dim objWriter As New System.IO.StreamWriter(Link)
            objWriter.Write(0)
            objWriter.Close()
        Else
            Dim objWriter As New System.IO.StreamWriter(Link)
            objWriter.Write(count)
            objWriter.Close()
        End If
    End Sub

    Private Sub CountUpdate()
        lb.Text = count
    End Sub

End Class
