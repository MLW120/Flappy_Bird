Public Class Bird
    'Public height As Integer
    'Public width As Integer
    Public x As Integer = 50
    Public y As Integer = 50
    Public yspeed As Double = 0


    Public Sub Update()
        Dim myGraphics As Graphics = Form1.CreateGraphics
        myGraphics.FillEllipse(Brushes.Black, x, y, 32, 32)
        Me.yspeed += Form1.Gravity
        Me.y += yspeed
        If Me.y < 0 Then
            Me.y = 0
            Me.yspeed = 0
        End If
        If Me.y >= 550 Then
            Me.y = 550
            Me.yspeed = -Form1.Gravity
        End If
        myGraphics.FillEllipse(Brushes.White, x, y, 32, 32)


    End Sub

    Public Sub Up()
        If Form1.dificulty = 2 Then
            Me.yspeed = -4
        Else
            Me.yspeed = -3.5
        End If

    End Sub
End Class
