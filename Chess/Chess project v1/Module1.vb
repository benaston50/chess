Module Module1

    Sub Main()

        Dim board As New Chessboard
        Console.ReadKey()
        board.Test()

        Console.ReadLine()

    End Sub

End Module
'Sub eee()
'    Dim maxcount As Integer
'    Dim maxmove As New List(Of Integer)
'    Dim validmove As New List(Of Integer)
'    maxmove.Add(0)
'    maxmove.Add(0)
'    maxmove.Add(-1000)
'    For pieces = 1 To 16
'        For x = 0 To 7
'            For y = 0 To 7
'                If checkValidMove(x, y, piecestats, pieces) = True Then
'                    validmove.Add(x)
'                    validmove.Add(y)
'                    validmove.Add(0)
'                    For enemy = 17 To 32
'                        If piecestats(enemy).xPos = x And piecestats(enemy).yPos = y Then
'                            validmove.Insert(2, piecestats(enemy).value)
'                        End If
'                    Next
'                    If maxmove(2) < validmove(2) Then
'                        maxmove.Insert(0, validmove(0))
'                        maxmove.Insert(1, validmove(1))
'                        maxmove.Insert(2, validmove(2))
'                        maxcount = pieces
'                    End If
'                    validmove.Clear()
'                End If
'            Next
'        Next
'        Nodes(pieces).value = maxmove(2)
'        Nodes(pieces).
'        Next
'End Sub
