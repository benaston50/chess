Public Class MovePiece
    Inherits ChessPieceV2
    Public piecestats() As Piece = PieceMake()
    Public Sub pieceMove(ByVal isWhite As Boolean, Optional ByVal xP As Integer = 0, Optional ByVal yP As Integer = 0, Optional ByVal selectPiece As Integer = 0)
        Dim choice As Integer
        Dim falseMove, falsePiece As Boolean
        falseMove = True
        falsePiece = True
        If isWhite = True Then
            Console.WriteLine("White's turn!")
            While falsePiece = True
                Console.WriteLine("What piece do you want to move(x)")
                Try
                    xP = Console.ReadLine() - 1
                Catch
                End Try
                Console.WriteLine("What piece do you want to move(y)")
                Try
                    yP = Console.ReadLine() - 1
                Catch
                End Try
                For i = 1 To 32
                    If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                        selectPiece = i
                    End If
                Next
                If selectPiece <> 0 Then
                    If piecestats(selectPiece).isWhite = isWhite Then
                        falsePiece = False
                    Else
                        Console.WriteLine("Not your piece! Choose a piece of your colour.")
                    End If

                Else
                    Console.WriteLine("No piece found here.")
                End If
            End While
            While falseMove = True
                Console.WriteLine("Where do you want to move to?")
                Console.WriteLine("Pos(x)")
                Try
                    xP = Console.ReadLine() - 1
                Catch
                End Try
                Console.WriteLine("Pos(y)")
                Try
                    yP = Console.ReadLine() - 1
                Catch
                End Try
                If checkValidMove(xP, yP, piecestats, selectPiece) = True Then
                    Console.Clear()
                    falseMove = False
                    For i = 1 To 32
                        If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                            piecestats(i).xPos = -1
                            piecestats(i).yPos = -1
                            piecestats(i).alive = False
                            Console.Write("Black ")
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
                    piecestats(selectPiece).movecount += 1
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
                If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                    piecestats(i).xPos = -1
                    piecestats(i).yPos = -1
                    piecestats(i).alive = False
                    Console.Write("White ")
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
            piecestats(selectPiece).movecount += 1
        End If

    End Sub
    Protected Function checkValidMove(ByVal xP As Integer, yP As Integer, piecestats() As Piece, selectPiece As Integer)
        Dim enemypiece As Integer
        Dim xPos, yPos, xDiff, yDiff As Integer
        xPos = piecestats(selectPiece).xPos
        yPos = piecestats(selectPiece).yPos
        xDiff = xPos - xP
        yDiff = yPos - yP
        'On board check
        If xP > 7 Or yP > 7 Or xP < 0 Or yP < 0 Then
            Return False
        End If
        For i = 1 To 32
            'Friendly Fire check
            If piecestats(i).xPos = xP And piecestats(i).yPos = yP Then
                enemypiece = i
                If i <> selectPiece And ((piecestats(i).isWhite = True And piecestats(selectPiece).isWhite = True) Or (piecestats(i).isWhite = False And piecestats(selectPiece).isWhite = False)) Then
                    Return False
                End If
            End If
        Next

        'Desired location <> current location check
        If xPos = xP And yPos = yP Then
            Return False
        End If

        'Pawn Rule Check
        If piecestats(selectPiece).type = 1 Then ' - Pawn
            If piecestats(selectPiece).isWhite = True Then 'Bottom up(white)
                'Attacking move check
                If enemypiece <> 0 Then
                    If Math.Abs(xDiff) = 1 And yDiff = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
                'Two spaces allowed on first move check
                If piecestats(selectPiece).movecount = 0 Then
                    If yDiff = 2 And xDiff = 0 Then
                        For i = 1 To 32
                            If piecestats(i).xPos = xP And piecestats(i).yPos = yP + 1 Then
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
                If piecestats(selectPiece).movecount = 0 Then
                    If yDiff = -2 And xDiff = 0 Then
                        For i = 1 To 32
                            If piecestats(i).xPos = xP And piecestats(i).yPos = yP - 1 Then
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

        ElseIf piecestats(selectPiece).type = 2 Then ' - Rook
            'Moves in y direction
            If (xDiff = 0 And yDiff <> 0) Then
                'Checks path to specified zone for other pieces
                For i = 1 To 32
                    'First checks piece is in same column, then checks if it is between piece to move and desired location
                    If piecestats(i).xPos = xPos And ((piecestats(i).yPos > yPos And piecestats(i).yPos < yP) Or (piecestats(i).yPos < yPos And piecestats(i).yPos > yP)) Then
                        Return False
                    End If
                Next
                Return True
                'Moves in x direction
            ElseIf (xDiff <> 0 And yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For i = 1 To 32
                    'First checks piece is in same row, then checks if it is between piece to move and desired location
                    If piecestats(i).yPos = yPos And ((piecestats(i).xPos > xPos And piecestats(i).xPos < xP) Or (piecestats(i).xPos < xPos And piecestats(i).xPos > xP)) Then
                        Return False
                    End If
                Next
                Return True
            Else
                Return False
            End If

        ElseIf piecestats(selectPiece).type = 3 Then ' - Knight
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

        ElseIf piecestats(selectPiece).type = 4 Then ' - Bishop
            'Diagonal Check
            If (xDiff - yDiff = 0) Or (xDiff + yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For i = 1 To 32
                    'Checks piece is diagonal
                    If Math.Abs(piecestats(i).xPos - xPos) = Math.Abs(piecestats(i).yPos - yPos) Then
                        'Checks y=-x between piece and desired location
                        If (piecestats(i).xPos < xP And piecestats(i).yPos < yP) And (piecestats(i).xPos > xPos And piecestats(i).yPos > yPos) Then
                            Return False
                        ElseIf (piecestats(i).xPos > xP And piecestats(i).yPos > yP) And (piecestats(i).xPos < xPos And piecestats(i).yPos < yPos) Then
                            Return False
                        ElseIf (piecestats(i).xPos < xP And piecestats(i).yPos > yP) And (piecestats(i).xPos > xPos And piecestats(i).yPos < yPos) Then
                            Return False
                        ElseIf (piecestats(i).xPos > xP And piecestats(i).yPos < yP) And (piecestats(i).xPos < xPos And piecestats(i).yPos > yPos) Then
                            Return False
                        End If

                    End If
                Next
                Return True
            Else
                Return False
            End If
        ElseIf piecestats(selectPiece).type = 5 Then ' - Queen
            'Moves in y direction
            If (xDiff = 0 And yDiff <> 0) Then
                'Checks path to specified zone for other pieces
                For i = 1 To 32
                    'First checks piece is in same column, then checks if it is between piece to move and desired location
                    If piecestats(i).xPos = xPos And ((piecestats(i).yPos > yPos And piecestats(i).yPos < yP) Or (piecestats(i).yPos < yPos And piecestats(i).yPos > yP)) Then
                        Return False
                    End If
                Next
                Return True
                'Moves in x direction
            ElseIf (xDiff <> 0 And yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For i = 1 To 32
                    'First checks piece is in same row, then checks if it is between piece to move and desired location
                    If piecestats(i).yPos = yPos And ((piecestats(i).xPos > xPos And piecestats(i).xPos < xP) Or (piecestats(i).xPos < xPos And piecestats(i).xPos > xP)) Then
                        Return False
                    End If
                Next
                Return True
            ElseIf (xDiff - yDiff = 0) Or (xDiff + yDiff = 0) Then
                'Checks path to specified zone for other pieces
                For i = 1 To 32
                    'Checks piece is diagonal
                    If Math.Abs(piecestats(i).xPos - xPos) = Math.Abs(piecestats(i).yPos - yPos) Then
                        'Checks y=-x between piece and desired location
                        If (piecestats(i).xPos < xP And piecestats(i).yPos < yP) And (piecestats(i).xPos > xPos And piecestats(i).yPos > yPos) Then
                            Return False
                        ElseIf (piecestats(i).xPos > xP And piecestats(i).yPos > yP) And (piecestats(i).xPos < xPos And piecestats(i).yPos < yPos) Then
                            Return False
                        ElseIf (piecestats(i).xPos < xP And piecestats(i).yPos > yP) And (piecestats(i).xPos > xPos And piecestats(i).yPos < yPos) Then
                            Return False
                        ElseIf (piecestats(i).xPos > xP And piecestats(i).yPos < yP) And (piecestats(i).xPos < xPos And piecestats(i).yPos > yPos) Then
                            Return False
                        End If

                    End If
                Next
                Return True
            Else
                Return False
            End If

        ElseIf piecestats(selectPiece).type = 6 Then
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
