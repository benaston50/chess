Public Class Tree
    Inherits MovePiece
    Protected nodecount As Integer
    Protected Structure Node
        Dim children As List(Of Node)
        'Stops any children being nothing
        Public ReadOnly Property childs() As List(Of Node)
            Get
                If children Is Nothing Then
                    children = New List(Of Node)
                End If
                Return children
            End Get
        End Property
        Dim alpha, beta As Integer
        'Piece ID
        Dim piece As Integer
        'Move position(x,y)
        Dim move() As Integer
        'Move value
        Dim value As Integer
        'Number of branches deep into the tree
        Dim depth As Integer

    End Structure
End Class
