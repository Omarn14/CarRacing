Public Class Form1
    Dim speed As Integer
    Dim road(7) As PictureBox
    Dim score As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        speed = 3
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8
    End Sub

    Private Sub RoadMover_Tick(sender As Object, e As EventArgs) Handles RoadMover.Tick

        For X As Integer = 0 To 7
            road(X).Top += speed

            If road(X).Top >= Me.Height Then
                road(X).Top = -road(X).Height

            End If

        Next
        If score > 5 And score < 10 Then
            speed = 2
        End If
        If score > 10 And score < 15 Then
            speed = 3
        End If
        If score > 15 And score < 20 Then
            speed = 4
        End If
        If score > 20 And score < 25 Then
            speed = 5
        End If
        If score > 25 And score < 30 Then
            speed = 6
        End If
        If score > 35 And score < 40 Then
            speed = 7
        End If
        If score > 45 And score < 50 Then
            speed = 8
        End If
        If score > 55 Then
            speed = 9
        End If
        Speed_Text.Text = "Speed" & speed
        If (Car.Bounds.IntersectsWith(EnemyCar1.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar2.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar3.Bounds)) Then
            gameOver()
        End If
    End Sub
    Private Sub gameOver()
        Replay_Button.Visible = True
        End_Text.Visible = True
        RoadMover.Stop()
        Enemy1_Mover.Stop()
        Enemy2_Mover.Stop()
        Enemy3_Mover.Stop()


    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            Right_mover.Start()
        End If
        If e.KeyCode = Keys.Left Then
            Left_mover.Start()
        End If
    End Sub
    Private Sub Right_mover_Tick(sender As Object, e As EventArgs) Handles Right_mover.Tick
        If (Car.Location.X < 330) Then
            Car.Left += 5
        End If

    End Sub
    Private Sub Left_mover_Tick(sender As Object, e As EventArgs) Handles Left_mover.Tick
        If (Car.Location.X > 0) Then
            Car.Left -= 5
        End If

    End Sub



    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Right_mover.Stop()
        Left_mover.Stop()
    End Sub

    Private Sub Enemy1_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy1_Mover.Tick

        EnemyCar1.Top += speed * 5 / 3
        If EnemyCar1.Top >= Me.Height Then
            score += 1
            Score_Text.Text = "Score" & score

            EnemyCar1.Top = -(CInt(Math.Ceiling(Rnd() * 330)) + EnemyCar1.Height)
            EnemyCar1.Left = CInt(Math.Ceiling(Rnd() * 70)) + 0
        End If
    End Sub

    Private Sub Enemy2_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy2_Mover.Tick
        EnemyCar2.Top += speed
        If EnemyCar2.Top >= Me.Height Then
            score += 1
            Score_Text.Text = "Score" & score

            EnemyCar2.Top = -(CInt(Math.Ceiling(Rnd() * 330)) + EnemyCar2.Height)
            EnemyCar2.Left = CInt(Math.Ceiling(Rnd() * 110)) + 90
        End If
    End Sub

    Private Sub Enemy3_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy3_Mover.Tick
        EnemyCar3.Top += speed * 3 / 2
        If EnemyCar3.Top >= Me.Height Then
            score += 1
            Score_Text.Text = "Score" & score
            EnemyCar3.Top = -(CInt(Math.Ceiling(Rnd() * 330)) + EnemyCar3.Height)
            EnemyCar3.Left = CInt(Math.Ceiling(Rnd() * 110)) + 220
        End If
    End Sub

    Private Sub Replay_Button_Click(sender As Object, e As EventArgs) Handles Replay_Button.Click
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
    End Sub

End Class
