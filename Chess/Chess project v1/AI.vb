Public Class AI
    Inherits Tree
    Dim recursioncount As Integer
    Protected Sub AIMove1()
        Dim maxcount As Integer
        Dim maxmove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        maxmove.Add(0)
        maxmove.Add(0)
        maxmove.Add(-1000)
        For piece = 1 To 16
            For x = 0 To 7
                For y = 0 To 7
                    'saves valid moves
                    If checkValidMove(x, y, pieceStats, piece) = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        'if piece is taken what is the value?
                        For enemy = 17 To 32
                            If pieceStats(enemy).xPos = x And pieceStats(enemy).yPos = y Then
                                validmove.Insert(2, pieceStats(enemy).value)
                            End If
                        Next
                        'if the current best move is worse than the current valid move, overwite validmove with maxmove
                        If maxmove(2) < validmove(2) Then
                            maxmove.Insert(0, validmove(0))
                            maxmove.Insert(1, validmove(1))
                            maxmove.Insert(2, validmove(2))
                            maxcount = piece
                        End If
                        validmove.Clear()
                    End If
                Next
            Next
        Next
        'Make the move
        pieceMove(False, maxmove(0), maxmove(1), maxcount)
    End Sub
    Protected Sub AIMove2()
        Dim treenodes() As Node = New Node(15) {}
        Dim count As Integer
        Dim move As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        Dim maxvalue, maxmove As Integer
        Dim rootStack As New Stack(Of Node)
        Dim rootvalue(15) As Integer
        Dim rootVals(3) As Integer
        maxvalue = -1000
        'For each first move
        For rootNum = 0 To 15
            treenodes(rootNum).alpha = -1000
            treenodes(rootNum).beta = 1000
            move.Add(0)
            move.Add(0)
            move.Add(-1000)
            treenodes(rootNum).children = New List(Of Node)
            treenodes(rootNum).piece = rootNum + 1
            treenodes(rootNum).depth = 0
            nodecount += 1
            For x = 0 To 7
                For y = 0 To 7
                    'Checks move is valid
                    If checkValidMove(x, y, pieceStats, rootNum + 1) = True And pieceStats(rootNum + 1).alive = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        'Finds if move results in taken piece
                        For enemy = 17 To 32
                            If pieceStats(enemy).xPos = x And pieceStats(enemy).yPos = y Then
                                validmove.Insert(2, pieceStats(enemy).value)
                            End If
                        Next
                        'If maximum move<valid move Then replace
                        If move(2) < validmove(2) Then
                            move.Insert(0, validmove(0))
                            move.Insert(1, validmove(1))
                            move.Insert(2, validmove(2))
                            count = rootNum
                        End If
                        validmove.Clear()
                    End If
                Next
            Next
            'Sets node move & value
            treenodes(rootNum).move = {move(0), move(1)}
            treenodes(rootNum).value = move(2)
            treenodes(rootNum).depth += 1
            'Finds if node has any valid move
            If move(2) = -1000 Then
            Else
                treenodes(rootNum).children = Mini(rootNum, 1, treenodes(rootNum), treenodes(rootNum).alpha, treenodes(rootNum).beta)
            End If
            move.Clear()
        Next
        'Traverses tree
        For rootNum = 0 To 15
            rootvalue(rootNum) = Traversal(treenodes(rootNum), 0, rootVals)
            'rootVal(rootNum) = Traverse(Nodes(rootNum))
            If rootvalue(rootNum) > maxvalue Then
                maxvalue = rootvalue(rootNum)
                maxmove = rootNum
            End If
            'Console.WriteLine(NodeCount)
            'Console.WriteLine(rootNum + 1 & " : " & rootvalue(rootNum))
        Next
        pieceMove(False, treenodes(maxmove).move(0), treenodes(maxmove).move(1), maxmove + 1)
        Console.Write("Black has moved piece:")
        Select Case pieceStats(maxmove + 1).type
            Case 1
                Console.Write(" Pawn ")
            Case 2
                Console.Write(" Rook ")
            Case 3
                Console.Write(" Knight ")
            Case 4
                Console.Write(" Bishop ")
            Case 5
                Console.Write(" Queen ")
            Case 6
                Console.Write(" King ")
            Case Else
                Console.Write(" Error ")
        End Select
        Console.WriteLine("to position(x,y) " & treenodes(maxmove).move(0) + 1 & "," & treenodes(maxmove).move(1) + 1)
    End Sub
    Private Function Max(ByVal rootNum As Integer, depth As Integer, noder As Node, alpha As Integer, beta As Integer)
        Dim maxcount As Integer
        Dim maxmove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        Dim childNodes() As Node = New Node(15) {}
        For childNum = 0 To 15
            noder.alpha = -1000
            noder.beta = 1000
            maxmove.Add(0)
            maxmove.Add(0)
            maxmove.Add(-1000)
            childNodes(childNum).piece = childNum + 1
            childNodes(childNum).depth = 0
            nodecount += 1
            For x = 0 To 7
                For y = 0 To 7
                    'Checks every move for isvalid
                    If checkValidMove(x, y, pieceStats, childNum + 1) = True And pieceStats(rootNum + 1).alive = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        'Checks if enemy piece is taken
                        For enemy = 17 To 32
                            If pieceStats(enemy).xPos = x And pieceStats(enemy).yPos = y Then
                                validmove.Insert(2, pieceStats(enemy).value)
                            End If
                        Next
                        'If max<valid swap
                        If maxmove(2) < validmove(2) Then
                            maxmove.Insert(0, validmove(0))
                            maxmove.Insert(1, validmove(1))
                            maxmove.Insert(2, validmove(2))
                            maxcount = childNum
                        End If
                        validmove.Clear()
                    End If
                Next
            Next
            'Makes node values
            childNodes(childNum).move = {maxmove(0), maxmove(1)}
            childNodes(childNum).value = maxmove(2)
            Console.WriteLine("Max : " & childNodes(childNum).value)
            maxmove.Clear()
            childNodes(childNum).depth += 1
            'Recursion loop :))
            If depth < 1 Then
                childNodes(childNum).children = Mini(childNum, depth + 1, noder, alpha, beta)
            End If
            noder.children.Add(childNodes(childNum))
        Next
        Return noder.children
    End Function
    Private Function Mini(ByVal rootNum As Integer, depth As Integer, noder As Node, alpha As Integer, beta As Integer)
        Dim mincount As Integer
        Dim minimove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        Dim childNodes() As Node = New Node(15) {}

        For childNum = 0 To 15
            noder.alpha = -1000
            noder.beta = 1000
            minimove.Add(0)
            minimove.Add(0)
            minimove.Add(1000)
            childNodes(childNum).piece = childNum + 17
            childNodes(childNum).depth = depth
            nodecount += 1
            For x = 0 To 7
                For y = 0 To 7
                    If checkValidMove(x, y, pieceStats, childNum + 17) = True And pieceStats(rootNum + 1).alive = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        For enemy = 1 To 16
                            If pieceStats(enemy).xPos = x And pieceStats(enemy).yPos = y Then
                                validmove.Insert(2, pieceStats(enemy).value)
                            End If
                        Next
                        If minimove(2) > validmove(2) Then
                            minimove.Insert(0, validmove(0))
                            minimove.Insert(1, validmove(1))
                            minimove.Insert(2, validmove(2))
                            mincount = childNum
                        End If
                        validmove.Clear()
                    End If
                Next
            Next
            childNodes(childNum).move = {minimove(0), minimove(1)}
            childNodes(childNum).value = minimove(2)
            childNodes(childNum).depth += 1
            If depth < 1 And Not minimove(2) = 1000 Then
                childNodes(childNum).children = Max(childNum, depth + 1, noder, alpha, beta)
            ElseIf minimove(2) = 1000 Then
                childNodes(childNum).value = -1000
            End If
            'Console.WriteLine("Piece : " & childNodes(childNum).piece & "  Min : " & childNodes(childNum).value)
            minimove.Clear()
            noder.children.Add(childNodes(childNum))
        Next
        Return noder.children
    End Function
    Private Function Traversal(ByVal noder As Node, value As Integer, values() As Integer)
        recursioncount += 1
        Dim max As Integer
        For Each child In noder.childs


            'Console.WriteLine(noder.piece & " " & noder.value)

            Traversal(child, value + noder.value, values)

        Next
        If recursioncount < 0 Then
            'Console.WriteLine("recCount<0")
            If values(recursioncount) < noder.value Then
                'Console.WriteLine("values(recCount)<noder.value")
                values(recursioncount) = noder.value
            End If
        Else

        End If
        'If max < noder.value Then
        '    max = noder.value
        'End If
        'Console.WriteLine(recCount & " ")

        recursioncount -= 1
        For i = 0 To values.Length - 1
            'Console.WriteLine(values(i))
            max += values(i)
        Next
        Return max
    End Function
    Private Function Traverse(root As Node)
        Dim stack = New Stack(Of Node)()
        stack.Push(root)
        Dim val As Integer

        While stack.Count > 0
            Dim current = stack.Pop()

            'Console.WriteLine(current.value)
            val += current.value
            ' Process the node
            For i As Integer = current.childs.Count - 1 To 0 Step -1
                stack.Push(current.childs(i))
            Next
        End While
        Return val
    End Function
End Class


