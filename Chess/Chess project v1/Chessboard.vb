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
        pieces = PieceMake()
        For i = 1 To 32
            If pieces(i).type = 1 Then
                board(pieces(i).yPos, pieces(i).xPos) = "P"
            ElseIf pieces(i).type = 2 Then
                board(pieces(i).yPos, pieces(i).xPos) = "R"
            ElseIf pieces(i).type = 3 Then
                board(pieces(i).yPos, pieces(i).xPos) = "n"
            ElseIf pieces(i).type = 4 Then
                board(pieces(i).yPos, pieces(i).xPos) = "B"
            ElseIf pieces(i).type = 5 Then
                board(pieces(i).yPos, pieces(i).xPos) = "Q"
            ElseIf pieces(i).type = 6 Then
                board(pieces(i).yPos, pieces(i).xPos) = "K"
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
                For i = 1 To 32
                    If piecestats(i).yPos = x And piecestats(i).xPos = y Then
                        If piecestats(i).isWhite = True Then
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
        For i = 1 To 32
            If piecestats(i).alive = True Then
                If piecestats(i).type = 1 Then
                    board(piecestats(i).yPos, piecestats(i).xPos) = "P"
                ElseIf piecestats(i).type = 2 Then
                    board(piecestats(i).yPos, piecestats(i).xPos) = "R"
                ElseIf piecestats(i).type = 3 Then
                    board(piecestats(i).yPos, piecestats(i).xPos) = "n"
                ElseIf piecestats(i).type = 4 Then
                    board(piecestats(i).yPos, piecestats(i).xPos) = "B"
                ElseIf piecestats(i).type = 5 Then
                    board(piecestats(i).yPos, piecestats(i).xPos) = "Q"
                ElseIf piecestats(i).type = 6 Then
                    board(piecestats(i).yPos, piecestats(i).xPos) = "K"
                Else
                    Console.WriteLine("Error - failed to update board")
                End If
            End If
        Next
    End Sub

    Public Sub Test()
        Dim Count As Integer
        boardGenerate()
        While True
            boardUpdate()
            interfaceUpdate()
            If Count Mod 2 = 0 Then
                pieceMove(True)
            Else
                AITest()
            End If
            Count += 1
        End While
    End Sub
End Class
