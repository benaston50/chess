
Public Class AI
    Inherits MovePiece
    Private Sub AIMove1()
        Dim maxcount As Integer
        Dim maxmove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        maxmove.Add(0)
        maxmove.Add(0)
        maxmove.Add(-1000)
        For piece = 1 To 16
            For x = 0 To 7
                For y = 0 To 7
                    If checkValidMove(x, y, piecestats, piece) = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        For enemy = 17 To 32
                            If piecestats(enemy).xPos = x And piecestats(enemy).yPos = y Then
                                validmove.Insert(2, piecestats(enemy).value)
                            End If
                        Next
                        If maxmove(2) < validmove(2) Then
                            maxmove.Insert(0, validmove(0))
                            maxmove.Insert(1, validmove(1))
                            maxmove.Insert(2, validmove(2))
                            maxcount = piece
                        End If
                        validmove.Clear()
                    End If
                Next
            Next
        Next
        pieceMove(False, maxmove(0), maxmove(1), maxcount)
    End Sub
    Public Sub AITest()
        AIMove1()
    End Sub
End Class


