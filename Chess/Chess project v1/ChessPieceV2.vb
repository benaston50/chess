Public Class ChessPieceV2
    Public Structure Piece
        'Type decides piece move laws and the value(worth) of the piece
        Dim type, value As Integer
        Dim xPos, yPos As Integer
        Dim isWhite As Boolean
        Dim alive As Boolean
        Dim movecount As Integer
    End Structure

    Protected Function pieceMake()
        Dim pieces(32) As Piece
        For piece = 1 To 14
            If piece <= 8 Then
                'Initialise pawns for both teams
                pieces(piece).type = 1
                pieces(piece + 16).type = 1

            ElseIf piece <= 10 Then
                'Initialise rooks for both teams
                pieces(piece).type = 2
                pieces(piece + 16).type = 2

            ElseIf piece <= 12 Then
                'Initialise Knight for both teams
                pieces(piece).type = 3
                pieces(piece + 16).type = 3

            Else
                'Initialises Bishop for both teams
                pieces(piece).type = 4
                pieces(piece + 16).type = 4
            End If
        Next
        'Queen
        pieces(15).type = 5
        pieces(31).type = 5
        'King
        pieces(16).type = 6
        pieces(32).type = 6
        For piece = 1 To 16
            'Sets alive state & colour
            pieces(piece).alive = True
            pieces(piece + 16).alive = True
            pieces(piece + 16).isWhite = True
            'Positions pieces
            If pieces(piece).type = 1 Then
                pieces(piece).xPos = piece - 1
                pieces(piece + 16).xPos = piece - 1
                pieces(piece).yPos = 1
                pieces(piece + 16).yPos = 6
            ElseIf pieces(piece).type = 2 Then
                If piece = 9 Then
                    pieces(piece).xPos = 0
                    pieces(piece).yPos = 0
                    pieces(piece + 16).xPos = 0
                    pieces(piece + 16).yPos = 7
                Else
                    pieces(piece).xPos = 7
                    pieces(piece).yPos = 0
                    pieces(piece + 16).xPos = 7
                    pieces(piece + 16).yPos = 7
                End If
            ElseIf pieces(piece).type = 3 Then
                If piece = 11 Then
                    pieces(piece).xPos = 1
                    pieces(piece).yPos = 0
                    pieces(piece + 16).xPos = 1
                    pieces(piece + 16).yPos = 7
                Else
                    pieces(piece).xPos = 6
                    pieces(piece).yPos = 0
                    pieces(piece + 16).xPos = 6
                    pieces(piece + 16).yPos = 7
                End If
            ElseIf pieces(piece).type = 4 Then
                If piece = 13 Then
                    pieces(piece).xPos = 2
                    pieces(piece).yPos = 0
                    pieces(piece + 16).xPos = 2
                    pieces(piece + 16).yPos = 7
                Else
                    pieces(piece).xPos = 5
                    pieces(piece).yPos = 0
                    pieces(piece + 16).xPos = 5
                    pieces(piece + 16).yPos = 7
                End If
            ElseIf pieces(piece).type = 5 Then
                pieces(piece).xPos = 3
                pieces(piece).yPos = 0
                pieces(piece + 16).xPos = 3
                pieces(piece + 16).yPos = 7
            ElseIf pieces(piece).type = 6 Then
                pieces(piece).xPos = 4
                pieces(piece).yPos = 0
                pieces(piece + 16).xPos = 4
                pieces(piece + 16).yPos = 7
            End If
        Next
        'Gives each piece a value based on its worth to the game
        For piece = 1 To 16
            If pieces(piece).type = 1 Then
                pieces(piece).value = -10
                pieces(piece + 16).value = 10
            ElseIf pieces(piece).type = 2 Then
                pieces(piece).value = -50
                pieces(piece + 16).value = 50
            ElseIf pieces(piece).type = 3 Then
                pieces(piece).value = -30
                pieces(piece + 16).value = 30
            ElseIf pieces(piece).type = 4 Then
                pieces(piece).value = -30
                pieces(piece + 16).value = 30
            ElseIf pieces(piece).type = 5 Then
                pieces(piece).value = -90
                pieces(piece + 16).value = 90
            ElseIf pieces(piece).type = 6 Then
                pieces(piece).value = -500
                pieces(piece + 16).value = 500
            End If
        Next
        Return pieces
    End Function

End Class
