Public Class ChessPiece
    Public Structure Piece
        Dim type As Integer
        Dim team As Integer
        Dim xPos As Integer
        Dim yPos As Integer
        Dim alive As Boolean
    End Structure
    Private Sub PiecePlace()
        Dim pieces(31) As Piece
        'Pawn Team 1
        For id = 0 To 7
            pieces(id).type = 1
            pieces(id).team = 1
            pieces(id).xPos = id
            pieces(id).yPos = 1
            pieces(id).alive = True
        Next
        'Rook Team 1
        For id = 8 To 9
            pieces(id).type = 2
            pieces(id).team = 1
            If id = 8 Then
                pieces(id).xPos = 0
            Else
                pieces(id).xPos = 7
            End If
            pieces(id).yPos = 0
            pieces(id).alive = True
        Next
        'Knight Team 1
        For id = 10 To 11
            pieces(id).type = 3
            pieces(id).team = 1
            If id = 10 Then
                pieces(id).xPos = 1
            Else
                pieces(id).xPos = 6
            End If
            pieces(id).yPos = 0
            pieces(id).alive = True
        Next
        'Bishop Team 1
        For id = 12 To 13
            pieces(id).type = 4
            pieces(id).team = 1
            If id = 12 Then
                pieces(id).xPos = 2
            Else
                pieces(id).xPos = 5
            End If
            pieces(id).yPos = 0
            pieces(id).alive = True
        Next
        'Queen Team 1
        pieces(14).type = 5
        pieces(14).team = 1
        pieces(14).xPos = 3
        pieces(14).yPos = 0
        pieces(14).alive = True
        'King Team 1
        pieces(15).type = 6
        pieces(15).team = 1
        pieces(15).xPos = 4
        pieces(15).yPos = 0
        pieces(15).alive = True
        'Pawn Team 2
        For id = 16 To 23
            pieces(id).type = 1
            pieces(id).team = 2
            pieces(id).xPos = id - 16
            pieces(id).yPos = 6
            pieces(id).alive = True
        Next
        'Rook Team 2
        For id = 24 To 25
            pieces(id).type = 2
            pieces(id).team = 2
            If id = 8 Then
                pieces(id).xPos = 0
            Else
                pieces(id).xPos = 7
            End If
            pieces(id).yPos = 0
            pieces(id).alive = True
        Next
        'Knight Team 1
        For id = 26 To 27
            pieces(id).type = 3
            pieces(id).team = 1
            If id = 10 Then
                pieces(id).xPos = 1
            Else
                pieces(id).xPos = 6
            End If
            pieces(id).yPos = 0
            pieces(id).alive = True
        Next
        'Bishop Team 1
        For id = 28 To 29
            pieces(id).type = 4
            pieces(id).team = 1
            If id = 12 Then
                pieces(id).xPos = 2
            Else
                pieces(id).xPos = 5
            End If
            pieces(id).yPos = 0
            pieces(id).alive = True
        Next
        'Queen Team 1
        pieces(30).type = 5
        pieces(30).team = 1
        pieces(30).xPos = 3
        pieces(30).yPos = 0
        pieces(30).alive = True
        'King Team 1
        pieces(31).type = 6
        pieces(31).team = 1
        pieces(31).xPos = 4
        pieces(31).yPos = 0
        pieces(31).alive = True
    End Sub
End Class