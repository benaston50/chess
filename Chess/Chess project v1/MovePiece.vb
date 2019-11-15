Public Class MovePiece
    Inherits ChessPieceV2
    Public pieceStats() As Piece = pieceMake()
    Protected Sub pieceMove(ByVal isWhite As Boolean, Optional ByVal xChoice As Integer = 0, Optional ByVal yChoice As Integer = 0, Optional ByVal selectPiece As Integer = 0)
        Dim choice As Integer
        Dim falseMove, falsePiece As Boolean
        falseMove = True
        falsePiece = True
        If isWhite = True Then
            Console.WriteLine("White's turn!")
            'Loops piece choice until valid piece is chosen
            While falsePiece = True
                Console.WriteLine("What piece do you want to move(x)")
                Try
                    xChoice = Console.ReadLine() - 1
                Catch
                End Try
                Console.WriteLine("What piece do you want to move(y)")
                Try
                    yChoice = Console.ReadLine() - 1
                Catch
                End Try
                'Finds piece chosen by player
                For piece = 1 To 32
                    If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice Then
                        selectPiece = piece
                    End If
                Next
                'Checks piece is a teammate piece
                If selectPiece <> 0 Then
                    If pieceStats(selectPiece).isWhite = isWhite Then
                        falsePiece = False
                    Else
                        Console.WriteLine("Not your piece! Choose a piece of your colour.")
                    End If

                Else
                    Console.WriteLine("No piece found here.")
                End If
            End While
            'Loops until valid position to move to is chosen
            While falseMove = True
                Console.WriteLine("Where do you want to move to?")
                Console.WriteLine("Pos(x)")
                Try
                    xChoice = Console.ReadLine() - 1
                Catch
                End Try
                Console.WriteLine("Pos(y)")
                Try
                    yChoice = Console.ReadLine() - 1
                Catch
                End Try
                'Calls function checkValidMove to see if the move meets all rules of chess
                If checkValidMove(xChoice, yChoice, pieceStats, selectPiece) = True Then
                    Console.Clear()
                    falseMove = False
                    'Sees if piece has been taken
                    For piece = 1 To 32
                        If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice Then
                            pieceStats(piece).xPos = -1
                            pieceStats(piece).yPos = -1
                            pieceStats(piece).alive = False
                            Console.Write("Black ")
                            Select Case pieceStats(piece).type
                                Case 1
                                    Console.WriteLine("Pawn has been taken!")
                                Case 2
                                    Console.WriteLine("Rook has been taken!")
                                Case 3
                                    Console.WriteLine("Knight has been taken!")
                                Case 4
                                    Console.WriteLine("Bishop has been taken!")
                                Case 5
                                    Console.WriteLine("Queen has been taken!")
                                Case 6
                                    Console.WriteLine("Loses! Checkmate")
                                    Console.ReadKey()
                                    Exit Sub
                            End Select

                        End If
                    Next
                    'Moves piece
                    pieceStats(selectPiece).xPos = xChoice
                        pieceStats(selectPiece).yPos = yChoice
                    pieceStats(selectPiece).movecount += 1
                    'Pawn LEVEL UP
                    If pieceStats(selectPiece).type = 1 And pieceStats(selectPiece).yPos = 0 Then
                        pieceStats(selectPiece).type = 5
                        Console.WriteLine("Pawn promoted!")
                    End If
                Else
                        Console.WriteLine("Invalid move!")
                    Console.WriteLine("Enter 1 to choose a new place to move, enter 9 to choose a new piece to move")
                    Try
                        choice = Console.ReadLine()
                        If choice = 9 Then
                            falseMove = False
                            pieceMove(isWhite)
                        End If
                    Catch
                    End Try
                End If
            End While
        Else
            If selectPiece = 0 Then
                Console.WriteLine("Black's turn!")
                'Loops piece choice until valid piece is chosen
                While falsePiece = True
                    Console.WriteLine("What piece do you want to move(x)")
                    Try
                        xChoice = Console.ReadLine() - 1
                    Catch
                    End Try
                    Console.WriteLine("What piece do you want to move(y)")
                    Try
                        yChoice = Console.ReadLine() - 1
                    Catch
                    End Try
                    'Finds piece chosen by player
                    For piece = 1 To 32
                        If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice Then
                            selectPiece = piece
                        End If
                    Next
                    'Checks piece is a teammate piece
                    If selectPiece <> 0 Then
                        If pieceStats(selectPiece).isWhite = isWhite Then
                            falsePiece = False
                        Else
                            Console.WriteLine("Not your piece! Choose a piece of your colour.")
                        End If

                    Else
                        Console.WriteLine("No piece found here.")
                    End If
                End While
                'Loops until valid position to move to is chosen
                While falseMove = True
                    Console.WriteLine("Where do you want to move to?")
                    Console.WriteLine("Pos(x)")
                    Try
                        xChoice = Console.ReadLine() - 1
                    Catch
                    End Try
                    Console.WriteLine("Pos(y)")
                    Try
                        yChoice = Console.ReadLine() - 1
                    Catch
                    End Try
                    'Calls function checkValidMove to see if the move meets all rules of chess
                    If checkValidMove(xChoice, yChoice, pieceStats, selectPiece) = True Then
                        Console.Clear()
                        falseMove = False
                        'Sees if piece has been taken
                        For piece = 1 To 32
                            If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice Then
                                pieceStats(piece).xPos = -1
                                pieceStats(piece).yPos = -1
                                pieceStats(piece).alive = False
                                Console.Write("White ")
                                Select Case pieceStats(piece).type
                                    Case 1
                                        Console.WriteLine("Pawn has been taken!")
                                    Case 2
                                        Console.WriteLine("Rook has been taken!")
                                    Case 3
                                        Console.WriteLine("Knight has been taken!")
                                    Case 4
                                        Console.WriteLine("Bishop has been taken!")
                                    Case 5
                                        Console.WriteLine("Queen has been taken!")
                                    Case 6
                                        Console.WriteLine("Loses! Checkmate")
                                        Console.ReadKey()
                                        End
                                End Select

                            End If
                        Next
                        'Moves piece
                        pieceStats(selectPiece).xPos = xChoice
                        pieceStats(selectPiece).yPos = yChoice
                        pieceStats(selectPiece).movecount += 1
                        'Pawn LEVEL UP
                        If pieceStats(selectPiece).type = 1 And pieceStats(selectPiece).yPos = 7 Then
                            pieceStats(selectPiece).type = 5
                            Console.WriteLine("Pawn promoted!")
                        End If
                    Else
                        Console.WriteLine("Invalid move!")
                        Console.WriteLine("Enter 1 to choose a new place to move, enter 9 to choose a new piece to move")
                        choice = Console.ReadLine()
                        If choice = 9 Then
                            falseMove = False
                            pieceMove(isWhite)
                        End If
                    End If
                End While
            Else
                Console.WriteLine("Black's(AI) turn!")
                For i = 1 To 32
                    'Checks if piece has been taken
                    If pieceStats(i).xPos = xChoice And pieceStats(i).yPos = yChoice Then
                        pieceStats(i).xPos = -1
                        pieceStats(i).yPos = -1
                        pieceStats(i).alive = False
                        Console.Write("White ")
                        Select Case pieceStats(i).type
                            Case 1
                                Console.WriteLine("Pawn has been taken!")
                            Case 2
                                Console.WriteLine("Rook has been taken!")
                            Case 3
                                Console.WriteLine("Knight has been taken!")
                            Case 4
                                Console.WriteLine("Bishop has been taken!")
                            Case 5
                                Console.WriteLine("Queen has been taken!")
                            Case 6
                                Console.WriteLine("Loses! Checkmate")
                                Console.ReadKey()
                                End
                        End Select

                    End If
                Next
                'Moves piece
                pieceStats(selectPiece).xPos = xChoice
                pieceStats(selectPiece).yPos = yChoice
                pieceStats(selectPiece).movecount += 1
                'Pawn LEVEL UP
                If pieceStats(selectPiece).type = 1 And pieceStats(selectPiece).yPos = 7 Then
                    pieceStats(selectPiece).type = 5
                    Console.WriteLine("Pawn promoted!")
                End If
            End If
        End If
    End Sub
    Protected Function checkValidMove(ByVal xChoice As Integer, yChoice As Integer, pieceStats() As Piece, selectPiece As Integer)
        Dim enemypiece As Integer
        Dim xPos, yPos, xDiff, yDiff As Integer

        'Current piece position
        xPos = pieceStats(selectPiece).xPos
        yPos = pieceStats(selectPiece).yPos
        'Difference between current position and desired position
        xDiff = xPos - xChoice
        yDiff = yPos - yChoice

        'On board check
        If xChoice > 7 Or yChoice > 7 Or xChoice < 0 Or yChoice < 0 Then
            Return False
        End If

        For piece = 1 To 32
            'Friendly Fire check
            If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice Then
                enemypiece = piece
                If piece <> selectPiece And ((pieceStats(piece).isWhite = True And pieceStats(selectPiece).isWhite = True) Or (pieceStats(piece).isWhite = False And pieceStats(selectPiece).isWhite = False)) Then
                    Return False
                End If
            End If
        Next

        'Desired location <> current location check
        If xPos = xChoice And yPos = yChoice Then
            Return False
        End If

        If pieceStats(selectPiece).type = 1 Then ' - Pawn
            If pieceStats(selectPiece).isWhite = True Then 'Bottom up(white)
                'Attacking move check
                If enemypiece <> 0 Then
                    If Math.Abs(xDiff) = 1 And yDiff = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
                'Two spaces allowed on first move check
                If pieceStats(selectPiece).movecount = 0 Then
                    If yDiff = 2 And xDiff = 0 Then
                        For piece = 1 To 32
                            If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice + 1 Then
                                Return False
                            End If
                        Next
                        Return True
                    End If
                End If
                'Move forward check
                If xDiff = 0 And yDiff = 1 Then
                    Return True
                Else
                    Return False
                End If

            Else 'Top down(black)
                'Attacking move check
                If enemypiece <> 0 Then
                    If Math.Abs(xDiff) = 1 And yDiff = -1 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
                'Two spaces allowed on first move check
                If pieceStats(selectPiece).movecount = 0 Then
                    If yDiff = -2 And xDiff = 0 Then
                        For piece = 1 To 32
                            If pieceStats(piece).xPos = xChoice And pieceStats(piece).yPos = yChoice - 1 Then
                                Return False
                            End If
                        Next
                        Return True
                    End If
                End If
                'Move forward check
                If xDiff = 0 And yDiff = -1 Then
                    Return True
                Else
                    Return False
                End If
            End If


        ElseIf pieceStats(selectPiece).type = 2 Then ' - Rook
            'Moves in y direction
            If (xDiff = 0 And yDiff <> 0) Then
                'Checks path to specified zone for other pieces
                For piece = 1 To 32
                    'First checks piece is in same column, then checks if it is between piece to move and desired location
                    If pieceStats(piece).xPos = xPos And ((pieceStats(piece).yPos > yPos And pieceStats(piece).yPos < yChoice) Or (pieceStats(piece).yPos < yPos And pieceStats(piece).yPos > yChoice)) Then
                        Return False
                    End If
                Next
                Return True
                'Moves in x direction
            ElseIf (xDiff <> 0 And yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For piece = 1 To 32
                    'First checks piece is in same row, then checks if it is between piece to move and desired location
                    If pieceStats(piece).yPos = yPos And ((pieceStats(piece).xPos > xPos And pieceStats(piece).xPos < xChoice) Or (pieceStats(piece).xPos < xPos And pieceStats(piece).xPos > xChoice)) Then
                        Return False
                    End If
                Next
                Return True
            Else
                Return False
            End If


        ElseIf pieceStats(selectPiece).type = 3 Then ' - Knight
            'Check moves on all axes
            If xDiff = 2 And yDiff = 1 Then
                Return True
            ElseIf xDiff = 1 And yDiff = 2 Then
                Return True
            ElseIf xDiff = -2 And yDiff = -1 Then
                Return True
            ElseIf xDiff = -1 And yDiff = -2 Then
                Return True
            ElseIf xDiff = 2 And yDiff = -1 Then
                Return True
            ElseIf xDiff = 1 And yDiff = -2 Then
                Return True
            ElseIf xDiff = -2 And yDiff = 1 Then
                Return True
            ElseIf xDiff = -1 And yDiff = 2 Then
                Return True
            Else
                Return False
            End If


        ElseIf pieceStats(selectPiece).type = 4 Then ' - Bishop
            'Diagonal Check
            If (xDiff - yDiff = 0) Or (xDiff + yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For piece = 1 To 32
                    'Checks piece is diagonal
                    If Math.Abs(pieceStats(piece).xPos - xPos) = Math.Abs(pieceStats(piece).yPos - yPos) Then
                        'Checks y=-x between piece and desired location
                        If (pieceStats(piece).xPos < xChoice And pieceStats(piece).yPos < yChoice) And (pieceStats(piece).xPos > xPos And pieceStats(piece).yPos > yPos) Then
                            Return False
                        ElseIf (pieceStats(piece).xPos > xChoice And pieceStats(piece).yPos > yChoice) And (pieceStats(piece).xPos < xPos And pieceStats(piece).yPos < yPos) Then
                            Return False
                        ElseIf (pieceStats(piece).xPos < xChoice And pieceStats(piece).yPos > yChoice) And (pieceStats(piece).xPos > xPos And pieceStats(piece).yPos < yPos) Then
                            Return False
                        ElseIf (pieceStats(piece).xPos > xChoice And pieceStats(piece).yPos < yChoice) And (pieceStats(piece).xPos < xPos And pieceStats(piece).yPos > yPos) Then
                            Return False
                        End If

                    End If
                Next
                Return True
            Else
                Return False
            End If


        ElseIf pieceStats(selectPiece).type = 5 Then ' - Queen
            'Moves in y direction
            If (xDiff = 0 And yDiff <> 0) Then
                'Checks path to specified zone for other pieces
                For piece = 1 To 32
                    'First checks piece is in same column, then checks if it is between piece to move and desired location
                    If pieceStats(piece).xPos = xPos And ((pieceStats(piece).yPos > yPos And pieceStats(piece).yPos < yChoice) Or (pieceStats(piece).yPos < yPos And pieceStats(piece).yPos > yChoice)) Then
                        Return False
                    End If
                Next
                Return True
                'Moves in x direction
            ElseIf (xDiff <> 0 And yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For piece = 1 To 32
                    'First checks piece is in same row, then checks if it is between piece to move and desired location
                    If pieceStats(piece).yPos = yPos And ((pieceStats(piece).xPos > xPos And pieceStats(piece).xPos < xChoice) Or (pieceStats(piece).xPos < xPos And pieceStats(piece).xPos > xChoice)) Then
                        Return False
                    End If
                Next
                Return True

            ElseIf (xDiff - yDiff = 0) Or (xDiff + yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For piece = 1 To 32
                    'Checks piece is diagonal
                    If Math.Abs(pieceStats(piece).xPos - xPos) = Math.Abs(pieceStats(piece).yPos - yPos) Then
                        'Checks y=-x between piece and desired location
                        If (pieceStats(piece).xPos < xChoice And pieceStats(piece).yPos < yChoice) And (pieceStats(piece).xPos > xPos And pieceStats(piece).yPos > yPos) Then
                            Return False
                        ElseIf (pieceStats(piece).xPos > xChoice And pieceStats(piece).yPos > yChoice) And (pieceStats(piece).xPos < xPos And pieceStats(piece).yPos < yPos) Then
                            Return False
                        ElseIf (pieceStats(piece).xPos < xChoice And pieceStats(piece).yPos > yChoice) And (pieceStats(piece).xPos > xPos And pieceStats(piece).yPos < yPos) Then
                            Return False
                        ElseIf (pieceStats(piece).xPos > xChoice And pieceStats(piece).yPos < yChoice) And (pieceStats(piece).xPos < xPos And pieceStats(piece).yPos > yPos) Then
                            Return False
                        End If

                    End If
                Next
                Return True
            Else
                Return False
            End If


        ElseIf pieceStats(selectPiece).type = 6 Then ' - King
            'Checks whole area around for enemy pieces
            If (Math.Abs(xDiff) = 1 Or Math.Abs(yDiff) = 1) And Math.Abs(xDiff) <= 1 And Math.Abs(yDiff) <= 1 Then
                Return True
            Else
                Return False
            End If

        End If
        Console.WriteLine("Invalid error")
        Return False
    End Function

End Class
