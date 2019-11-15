Public Class Chessboard
    Inherits AI
    Protected board(7, 7) As String
    'Creates 7x7 board with pieces
    Private Sub boardGenerate()
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
    'Writes the board layout to the console with colours! :)
    Private Sub interfaceUpdate()

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
    'Updates board array
    Private Sub boardUpdate()
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
    'Hub of all things testing
    'Shared a load of variables in this one
    Public Sub testPlay()
        Dim difficulty As Integer = 1
        Dim count As Integer
        Dim choice As String = ""
        Dim menu, valid As Boolean
        Dim webAddress As String = "https://www.dummies.com/games/chess/chess-for-dummies-cheat-sheet/"



        While menu = False
            Console.Clear()
            Console.WriteLine("Welcome to Chess! By Ben Aston")
            Console.WriteLine("What would you like to do?")
            Console.WriteLine("1 - PLAY")
            Console.WriteLine("2 - Read help on chess")
            Console.WriteLine("3 - Edit Settings")
            Console.WriteLine("9 - Close")
            valid = False
            While valid = False

                Select Case choice
                    Case "1"
                        Console.WriteLine("What game?")
                        Console.WriteLine("1 - 1v1")
                        Console.WriteLine("2 - 1vAI")
                        choice = ""
                        While valid = False
                            Select Case choice
                                Case "1"
                                    valid = True
                                    boardGenerate()
                                    While True
                                        boardUpdate()
                                        interfaceUpdate()
                                        If count Mod 2 = 0 Then
                                            pieceMove(True)
                                        Else
                                            pieceMove(False)
                                        End If
                                        count += 1
                                    End While
                                Case "2"
                                    valid = True
                                    boardGenerate()
                                    While True
                                        boardUpdate()
                                        interfaceUpdate()
                                        If count Mod 2 = 0 Then
                                            pieceMove(True)
                                        Else
                                            If difficulty = 1 Then
                                                AIMove1()
                                            ElseIf difficulty = 2 Then
                                                AIMove2()
                                            End If
                                        End If
                                        count += 1
                                    End While
                                Case Else
                                    Try
                                        choice = Console.ReadLine()
                                    Catch
                                        Console.WriteLine("Incorrect input")
                                        valid = False
                                    End Try
                            End Select
                        End While

                    Case "2"
                        valid = True
                        Process.Start(webAddress)
                        Console.WriteLine("this website and these helpful text notes should help you through the program!")
                        Console.ReadKey()
                    Case "3"
                        Console.WriteLine("Change difficulty:")
                        Console.WriteLine("1-maximises based on own move")
                        Console.WriteLine("2-minimises damage from player")
                        Console.WriteLine("9-back to main menu")
                        choice = Console.ReadLine()
                        While valid = False
                            Select Case difficulty
                                Case "1"
                                    difficulty = 1
                                    valid = True
                                Case "2"
                                    difficulty = 2
                                    Console.WriteLine("Prepare for failure...")
                                    valid = True
                                Case "9"
                                    valid = True
                                Case Else
                                    Console.WriteLine("not a difficulty bucko")
                            End Select
                        End While

                    Case "9"
                        Console.WriteLine("Goodbye!")
                        Console.ReadKey()
                        End
                    Case Else
                        valid = False
                        Try
                            choice = Console.ReadLine()
                        Catch
                            Console.WriteLine("Incorrect input")
                        End Try
                End Select
            End While
            choice = ""
        End While

    End Sub
End Class
