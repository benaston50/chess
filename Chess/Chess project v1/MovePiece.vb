Public Class MovePiece
    Inherits ChessPieceV2
    Public piecestats() As Piece = PieceMake()
    Public Sub pieceMove()
        Dim xP, yP, selectPiece As Integer
        Dim falseMove As Boolean = True
        While falseMove = True
            Console.WriteLine("What piece do you want to move(x)")
            xP = Console.ReadLine() - 1
            Console.WriteLine("What piece do you want to move(y)")
            yP = Console.ReadLine() - 1
            For i = 1 To 32
                If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                    selectPiece = i
                End If
            Next
            If selectPiece <> 0 Then
                falseMove = False
            Else
                Console.WriteLine("no piece found here")
            End If
        End While
        falseMove = True
        While falseMove = True
            Console.WriteLine("Where do you want to move to?")
            Console.WriteLine("Pos(x)")
            xP = Console.ReadLine() - 1
            Console.WriteLine("Pos(y)")
            yP = Console.ReadLine() - 1
            If checkValidMove(xP, yP, piecestats, selectPiece) = True Then
                Console.Clear()
                falseMove = False
                For i = 1 To 32
                    If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                        piecestats(i).xPos = -1
                        piecestats(i).yPos = -1
                        piecestats(i).alive = False
                        If piecestats(i).isWhite = True Then
                            Console.Write("White ")
                        Else
                            Console.Write("Black ")
                        End If
                        Select Case piecestats(i).type
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
                piecestats(selectPiece).xPos = xP
                piecestats(selectPiece).yPos = yP
            End If
        End While
    End Sub
    Protected Function checkValidMove(ByVal xP As Integer, yP As Integer, piecestats() As Piece, selectPiece As Integer)
        Dim enemypiece As Integer
        For i = 1 To 32
            'Friendly Fire check
            If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                enemypiece = i
                If i <> selectPiece And ((piecestats(i).isWhite = True And piecestats(selectPiece).isWhite = True) Or (piecestats(i).isWhite = False And piecestats(selectPiece).isWhite = False)) Then
                    Console.WriteLine("Invalid move - attacking teammate!")
                    Return False
                End If
            End If
        Next

        If piecestats(selectPiece).xPos = xP And piecestats(selectPiece).yPos = yP Then
            Console.WriteLine("Error - can't take self!")
            Return False
        End If

        'Pawn Rule Check
        If piecestats(selectPiece).type = 1 Then 'Pawn type
            If piecestats(selectPiece).isWhite = True Then 'Bottom up
                'Attacking move check
                If enemypiece <> 0 Then
                    If Math.Abs(piecestats(selectPiece).xPos - xP) = 1 And piecestats(selectPiece).yPos - yP = 1 Then
                        Return True
                    Else
                        Console.WriteLine("Invalid move - pawn cannot attack in that way!")
                        Return False
                    End If
                End If
                'Move forward check
                If piecestats(selectPiece).xPos - xP = 0 And piecestats(selectPiece).yPos - yP = 1 Then
                    Return True
                Else
                    Console.WriteLine("Invalid move - pawn cannot move in that way!")
                    Return False
                End If
                'Two spaces allowed on first move check
                If piecestats(selectPiece).movecount = 0 Then
                    If piecestats(selectPiece).yPos - yP = 2 And piecestats(selectPiece).xPos - xP = 0 Then
                        For i = 1 To 32
                            If piecestats(i).xPos = xP And piecestats(i).yPos = yP - 1 Then
                                Console.WriteLine("Invalid move - other piece in the way!")
                                Return False
                            End If
                        Next
                        Return True
                    End If
                End If
            Else
                'Attacking move check
                If enemypiece <> 0 Then
                    If Math.Abs(piecestats(selectPiece).xPos - xP) = 1 And piecestats(selectPiece).yPos - yP = -1 Then
                        Return True
                    Else
                        Console.WriteLine("Invalid move - pawn cannot attack in that way!")
                        Return False
                    End If
                End If
                'Move forward check
                If piecestats(selectPiece).xPos - xP = 0 And piecestats(selectPiece).yPos - yP = -1 Then
                    Return True
                Else
                    Console.WriteLine("Invalid move - pawn cannot move in that way!")
                    Return False
                End If
                'Two spaces allowed on first move check
                If piecestats(selectPiece).movecount = 0 Then
                    If piecestats(selectPiece).yPos - yP = -2 And piecestats(selectPiece).xPos - xP = 0 Then
                        For i = 1 To 32
                            If piecestats(i).xPos = xP And piecestats(i).yPos = yP + 1 Then
                                Console.WriteLine("Invalid move - other piece in the way!")
                                Return False
                            End If
                        Next
                        Return True
                    End If
                End If
            End If

        ElseIf piecestats(selectPiece).type = 2 Then
            If piecestats(selectPiece).isWhite = True Then
                'Moves in y direction
                If (piecestats(selectPiece).xPos - xP = 0 And piecestats(selectPiece).yPos - yP <> 0) Then
                    'Checks path to specified zone for other pieces
                    For i = 1 To 32
                        'First checks piece is in same column, then checks if it is between piece to move and desired location
                        If piecestats(i).xPos = piecestats(selectPiece).xPos And ((piecestats(i).yPos > piecestats(selectPiece).yPos And piecestats(i).yPos > yP) Or (piecestats(i).yPos < piecestats(selectPiece).yPos And piecestats(i).yPos < yP)) Then
                            Console.WriteLine("Error-piece in way!")
                            Return False
                        End If
                    Next
                    Console.WriteLine()
                    Return True
                    'Moves in x direction
                ElseIf (piecestats(selectPiece).xPos - xP <> 0 And piecestats(selectPiece).yPos - yP = 0) Then
                    'Checks path to specified zone for other pieces
                    For i = 1 To 32
                        'First checks piece is in same row, then checks if it is between piece to move and desired location
                        If piecestats(i).yPos = piecestats(selectPiece).yPos And ((piecestats(i).xPos > piecestats(selectPiece).xPos And piecestats(i).xPos > xP) Or (piecestats(i).xPos < piecestats(selectPiece).xPos And piecestats(i).xPos < xP)) Then
                            Console.WriteLine("Error-piece in way!")
                            Return False
                        End If
                    Next
                    Console.WriteLine()
                    Return True
                Else
                    Console.WriteLine("Error: Must move in a single direction only")
                    Return False
                End If
            End If
        End If
        Console.WriteLine("Invalid error")
        Return False
    End Function


End Class
