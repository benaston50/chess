Public Class Chessboard
    Inherits AI
    Protected board(7, 7) As String

    Protected Sub boardGenerate()
        For x = 0 To 7

            For y = 0 To 7
                board(x, y) = " "
            Next
        Next
        Dim pieces(32) As Piece
        pieces = pieceMake()
        For piece = 1 To 32
            If pieces(piece).type = 1 Then
                board(pieces(piece).yPos, pieces(piece).xPos) = "P"
            ElseIf pieces(piece).type = 2 Then
                board(pieces(piece).yPos, pieces(piece).xPos) = "R"
            ElseIf pieces(piece).type = 3 Then
                board(pieces(piece).yPos, pieces(piece).xPos) = "n"
            ElseIf pieces(piece).type = 4 Then
                board(pieces(piece).yPos, pieces(piece).xPos) = "B"
            ElseIf pieces(piece).type = 5 Then
                board(pieces(piece).yPos, pieces(piece).xPos) = "Q"
            ElseIf pieces(piece).type = 6 Then
                board(pieces(piece).yPos, pieces(piece).xPos) = "K"
            Else
            End If
        Next
    End Sub
    Public Sub interfaceUpdate()

        Console.Write("    ")
        For x = 0 To 7

            Console.Write(x + 1 & "   ")
        Next
        Console.WriteLine()
        For x = 0 To 7
            Console.Write(x + 1 & " |")
            For y = 0 To 7
                If (x + y) Mod 2 = 0 Then
                    Console.BackgroundColor = ConsoleColor.DarkMagenta
                Else
                    Console.BackgroundColor = ConsoleColor.Magenta
                End If
                For piece = 1 To 32
                    If pieceStats(piece).yPos = x And pieceStats(piece).xPos = y Then
                        If pieceStats(piece).isWhite = True Then
                            Console.ForegroundColor = ConsoleColor.White
                        Else
                            Console.ForegroundColor = ConsoleColor.Black
                        End If
                    End If
                Next
                Console.Write(" " & board(x, y) & " ")
                Console.BackgroundColor = ConsoleColor.Black
                Console.ForegroundColor = ConsoleColor.Gray
                Console.Write("|")
            Next
            Console.WriteLine()
        Next
    End Sub
    Public Sub boardUpdate()
        For x = 0 To 7
            For y = 0 To 7
                board(x, y) = " "
            Next
        Next
        For piece = 1 To 32
            If pieceStats(piece).alive = True Then
                If pieceStats(piece).type = 1 Then
                    board(pieceStats(piece).yPos, pieceStats(piece).xPos) = "P"
                ElseIf pieceStats(piece).type = 2 Then
                    board(pieceStats(piece).yPos, pieceStats(piece).xPos) = "R"
                ElseIf pieceStats(piece).type = 3 Then
                    board(pieceStats(piece).yPos, pieceStats(piece).xPos) = "n"
                ElseIf pieceStats(piece).type = 4 Then
                    board(pieceStats(piece).yPos, pieceStats(piece).xPos) = "B"
                ElseIf pieceStats(piece).type = 5 Then
                    board(pieceStats(piece).yPos, pieceStats(piece).xPos) = "Q"
                ElseIf pieceStats(piece).type = 6 Then
                    board(pieceStats(piece).yPos, pieceStats(piece).xPos) = "K"
                Else
                    Console.WriteLine("Error - failed to update board")
                End If
            End If
        Next
    End Sub

    Public Sub Test()
        Dim count As Integer
        boardGenerate()
        While True
            boardUpdate()
            interfaceUpdate()
            If count Mod 2 = 0 Then
                pieceMove(True)
            Else
                AITest()
            End If
            count += 1
        End While
    End Sub
End Class
