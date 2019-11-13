Public Class AI
    Inherits Tree
    Dim recCount As Double
    Private Sub AIMove1()
        Dim maxcount As Integer
        Dim maxmove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        maxmove.Add(0)
        maxmove.Add(0)
        maxmove.Add(-1000)
        For piece = 1 To 16
            For x = 0 To 7
                For y = 0 To 7
                    If checkValidMove(x, y, piecestats, piece) = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        For enemy = 17 To 32
                            If piecestats(enemy).xPos = x And piecestats(enemy).yPos = y Then
                                validmove.Insert(2, piecestats(enemy).value)
                            End If
                        Next
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
        pieceMove(False, maxmove(0), maxmove(1), maxcount)
    End Sub
    Private Sub AIMove2()
        Dim Nodes() As Node = New Node(15) {}
        Dim maxcount As Integer
        Dim maxmove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        Dim maxVal, maxMov As Integer
        Dim rootStack As New Stack(Of Node)
        Dim rootVal(15) As Integer
        maxVal = -1000
        For rootNum = 0 To 15
            maxmove.Add(0)
            maxmove.Add(0)
            maxmove.Add(-1000)
            Nodes(rootNum).Children = New List(Of Node)
            Nodes(rootNum).piece = rootNum + 1
            Nodes(rootNum).depth = 0
            NodeCount += 1
            For x = 0 To 7
                For y = 0 To 7
                    If checkValidMove(x, y, piecestats, rootNum + 1) = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        For enemy = 17 To 32
                            If piecestats(enemy).xPos = x And piecestats(enemy).yPos = y Then
                                validmove.Insert(2, piecestats(enemy).value)
                            End If
                        Next
                        If maxmove(2) < validmove(2) Then
                            maxmove.Insert(0, validmove(0))
                            maxmove.Insert(1, validmove(1))
                            maxmove.Insert(2, validmove(2))
                            maxcount = rootNum
                        End If
                        validmove.Clear()
                    End If
                Next
            Next
            Nodes(rootNum).move = {maxmove(0), maxmove(1)}
            Nodes(rootNum).value = maxmove(2)
            Nodes(rootNum).depth += 1
            If maxmove(2) = -1000 Then
            Else
                Nodes(rootNum).Children = Mini(rootNum, 1, Nodes(rootNum))
            End If
            maxmove.Clear()
        Next
        For rootNum = 0 To 15
            'rootVal(rootNum) = Traversal(Nodes(rootNum), 0)
            rootVal(rootNum) = Traverse(Nodes(rootNum))
            If rootVal(rootNum) > maxVal Then
                maxVal = rootVal(rootNum)
                maxMov = rootNum
            End If
            'Console.WriteLine(NodeCount)
            'Console.WriteLine(rootNum + 1 & " : " & rootVal(rootNum))
        Next
        pieceMove(False, Nodes(maxMov).move(0), Nodes(maxMov).move(1), maxMov + 1)
    End Sub
    Private Function Max(ByVal rootNum As Integer, depth As Integer, noder As Node)
        Dim maxcount As Integer
        Dim maxmove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        Dim childNodes() As Node = New Node(15) {}
        For childNum = 0 To 15
            maxmove.Add(0)
            maxmove.Add(0)
            maxmove.Add(-1000)
            childNodes(childNum).piece = childNum + 1
            childNodes(childNum).depth = 0
            NodeCount += 1
            For x = 0 To 7
                For y = 0 To 7
                    If checkValidMove(x, y, piecestats, childNum + 1) = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        For enemy = 17 To 32
                            If piecestats(enemy).xPos = x And piecestats(enemy).yPos = y Then
                                validmove.Insert(2, piecestats(enemy).value)
                            End If
                        Next
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

            childNodes(childNum).move = {maxmove(0), maxmove(1)}
            childNodes(childNum).value = maxmove(2)
            Console.WriteLine("Max : " & childNodes(childNum).value)
            maxmove.Clear()
            childNodes(childNum).depth += 1
            If depth < 1 Then
                childNodes(childNum).Children = Mini(childNum, depth + 1, noder)
            End If
            noder.Children.Add(childNodes(childNum))
        Next
        Return noder.Children
    End Function
    Private Function Mini(ByVal rootNum As Integer, depth As Integer, noder As Node)
        Dim mincount As Integer
        Dim minimove As New List(Of Integer)
        Dim validmove As New List(Of Integer)
        Dim childNodes() As Node = New Node(15) {}

        For childNum = 0 To 15
            minimove.Add(0)
            minimove.Add(0)
            minimove.Add(1000)
            childNodes(childNum).piece = childNum + 17
            childNodes(childNum).depth = depth
            NodeCount += 1
            For x = 0 To 7
                For y = 0 To 7
                    If checkValidMove(x, y, piecestats, childNum + 17) = True Then
                        validmove.Add(x)
                        validmove.Add(y)
                        validmove.Add(0)
                        For enemy = 1 To 16
                            If piecestats(enemy).xPos = x And piecestats(enemy).yPos = y Then
                                validmove.Insert(2, piecestats(enemy).value)
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
                childNodes(childNum).Children = Max(childNum, depth + 1, noder)
            ElseIf minimove(2) = 1000 Then
                childNodes(childNum).value = -1000
            End If
            'Console.WriteLine("Piece : " & childNodes(childNum).piece & "  Min : " & childNodes(childNum).value)
            minimove.Clear()
            noder.Children.Add(childNodes(childNum))
        Next
        Return noder.Children
    End Function
    Private Function Traversal(ByVal noder As Node, value As Integer)
        Dim max As Integer = -1000
        Dim vals() As Integer
        For Each child In noder.child


            'Console.WriteLine(noder.piece & " " & noder.value)
            Traversal(child, value + noder.value)
            'recCount += 1
        Next
        If max < noder.value Then
            max = noder.value
        End If
        'Console.WriteLine(recCount & " ")
        'recCount = 0
        Return max
    End Function
    Private Function Traverse(root As Node)
        Dim stack = New Stack(Of Node)()
        stack.Push(root)
        Dim val As Integer

        While stack.Count > 0
            Dim current = stack.Pop()

            Console.WriteLine(current.value)
            val += current.value
            ' Process the node
            For i As Integer = current.child.Count - 1 To 0 Step -1
                stack.Push(current.child(i))
            Next
        End While
        Return val
    End Function
    Public Sub AITest()

        AIMove2()

    End Sub
End Class


