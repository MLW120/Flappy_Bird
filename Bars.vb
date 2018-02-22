Public Class Bars
    Public x As Integer
    Public y As Integer


    Public Sub Update()
        Dim myGraphics As Graphics = Form1.CreateGraphics
        myGraphics.FillRectangle(Brushes.Black, x, 0, 8, y)
        myGraphics.FillRectangle(Brushes.Black, x, y + Form1.narrow, 8, 600)
        If Form1.dificulty = 2 Then
            Me.x -= 2
        Else
            Me.x -= 1
        End If
        myGraphics.FillRectangle(Brushes.White, x, 0, 8, y)
        myGraphics.FillRectangle(Brushes.White, x, y + Form1.narrow, 8, 600)
    End Sub

    Public Sub New()
        Randomize()
        Me.y = CInt(Int((450 * Rnd()) + 10))
        Me.x = 450
    End Sub
    Public Sub New(ByVal h As Huecos)
        Randomize()
        Dim i As Integer = 0
        While i < 10 Or i > 450
            i = h.y + (CInt(Int((400 * Rnd()) - 200)))
        End While
        'Me.y = CInt(Int((450 * Rnd()) + 10))
        Me.y = i
        Me.x = 450
    End Sub

    Public Function Touching(ByVal b As Bird) As Boolean
        Dim ret As Boolean = False
        Dim M As Point
        M.X = b.x + 16
        M.Y = b.y + 16
        Dim p As Point
        For i As Integer = 0 To Me.y
            p.X = Me.x
            p.Y = i
            Dim dist As Integer = Math.Sqrt(((M.X - p.X) ^ 2) + ((M.Y - p.Y) ^ 2))
            If dist <= 16 Then
                ret = True
                Return ret
                Exit Function
            End If
        Next
        For i As Integer = Me.x To Me.x + 8
            p.X = i
            p.Y = Me.y
            Dim dist As Integer = Math.Sqrt(((M.X - p.X) ^ 2) + ((M.Y - p.Y) ^ 2))
            If dist <= 16 Then
                ret = True
                Return ret
                Exit Function
            End If
        Next
        For i As Integer = Me.y + Form1.narrow To 600
            p.X = Me.x
            p.Y = i
            Dim dist As Integer = Math.Sqrt(((M.X - p.X) ^ 2) + ((M.Y - p.Y) ^ 2))
            If dist <= 16 Then
                ret = True
                Return ret
                Exit Function
            End If
        Next
        For i As Integer = Me.x To Me.x + 8
            p.X = i
            p.Y = Me.y + Form1.narrow
            Dim dist As Integer = Math.Sqrt(((M.X - p.X) ^ 2) + ((M.Y - p.Y) ^ 2))
            If dist <= 16 Then
                ret = True
                Return ret
                Exit Function
            End If
        Next
        Return ret
    End Function
End Class
