Public Class ChessPieceV2
    Public Structure Piece
        Dim type, value As Integer
        Dim xPos, yPos As Integer
        Dim isWhite As Boolean
        Dim alive As Boolean
        Dim movecount As Integer
    End Structure

    Public Function PieceMake()
        Dim pieces(32) As Piece
        For i = 1 To 14
            If i <= 8 Then
                pieces(i).type = 1
                pieces(i + 16).type = 1

            ElseIf i <= 10 Then
                pieces(i).type = 2
                pieces(i + 16).type = 2

            ElseIf i <= 12 Then
                pieces(i).type = 3
                pieces(i + 16).type = 3

            Else
                pieces(i).type = 4
                pieces(i + 16).type = 4
            End If
        Next
        pieces(15).type = 5
        pieces(31).type = 5
        pieces(16).type = 6
        pieces(32).type = 6
        For i = 1 To 16
            pieces(i).alive = True
            pieces(i + 16).alive = True
            pieces(i + 16).isWhite = True
            If pieces(i).type = 1 Then
                pieces(i).xPos = i - 1
                pieces(i + 16).xPos = i - 1
                pieces(i).yPos = 1
                pieces(i + 16).yPos = 6
            ElseIf pieces(i).type = 2 Then
                If i = 9 Then
                    pieces(i).xPos = 0
                    pieces(i).yPos = 0
                    pieces(i + 16).xPos = 0
                    pieces(i + 16).yPos = 7
                Else
                    pieces(i).xPos = 7
                    pieces(i).yPos = 0
                    pieces(i + 16).xPos = 7
                    pieces(i + 16).yPos = 7
                End If
            ElseIf pieces(i).type = 3 Then
                If i = 11 Then
                    pieces(i).xPos = 1
                    pieces(i).yPos = 0
                    pieces(i + 16).xPos = 1
                    pieces(i + 16).yPos = 7
                Else
                    pieces(i).xPos = 6
                    pieces(i).yPos = 0
                    pieces(i + 16).xPos = 6
                    pieces(i + 16).yPos = 7
                End If
            ElseIf pieces(i).type = 4 Then
                If i = 13 Then
                    pieces(i).xPos = 2
                    pieces(i).yPos = 0
                    pieces(i + 16).xPos = 2
                    pieces(i + 16).yPos = 7
                Else
                    pieces(i).xPos = 5
                    pieces(i).yPos = 0
                    pieces(i + 16).xPos = 5
                    pieces(i + 16).yPos = 7
                End If
            ElseIf pieces(i).type = 5 Then
                pieces(i).xPos = 3
                pieces(i).yPos = 0
                pieces(i + 16).xPos = 3
                pieces(i + 16).yPos = 7
            ElseIf pieces(i).type = 6 Then
                pieces(i).xPos = 4
                pieces(i).yPos = 0
                pieces(i + 16).xPos = 4
                pieces(i + 16).yPos = 7
            End If
        Next
        For i = 1 To 16
            If pieces(i).type = 1 Then
                pieces(i).value = -10
                pieces(i + 16).value = 10
            ElseIf pieces(i).type = 2 Then
                pieces(i).value = -50
                pieces(i + 16).value = 50
            ElseIf pieces(i).type = 3 Then
                pieces(i).value = -30
                pieces(i + 16).value = 30
            ElseIf pieces(i).type = 4 Then
                pieces(i).value = -30
                pieces(i + 16).value = 30
            ElseIf pieces(i).type = 5 Then
                pieces(i).value = -90
                pieces(i + 16).value = 90
            ElseIf pieces(i).type = 6 Then
                pieces(i).value = -500
                pieces(i + 16).value = 500
            End If
        Next
        Return pieces
    End Function
    Public Sub Test2()
        PieceMake()
    End Sub
End Class
