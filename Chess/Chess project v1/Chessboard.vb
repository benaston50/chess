Public Class Chessboard
    Inherits MovePiece
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
    Public Function interfaceUpdate()

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
                Console.Write(" " & board(x, y) & " ")
                Console.BackgroundColor = ConsoleColor.Black
                Console.Write("|")
            Next
            Console.WriteLine()
        Next
    End Function
    Public Function boardUpdate()
        For x = 0 To 7
            For y = 0 To 7
                board(x, y) = " "
            Next
        Next
        For i = 1 To 32
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
            End If
        Next
    End Function
    Public Sub Test()
        boardGenerate()
        interfaceUpdate()
        pieceMove()
        boardUpdate()
        interfaceUpdate()
    End Sub
End Class
