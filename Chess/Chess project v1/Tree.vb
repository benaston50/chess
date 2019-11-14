Public Class Tree
    Inherits MovePiece
    Public nodecount As Integer
    Protected Structure Node
        Dim children As List(Of Node)
        Public ReadOnly Property childs() As List(Of Node)
            Get
                If children Is Nothing Then
                    children = New List(Of Node)
                End If
                Return children
            End Get
        End Property
        Dim alpha, beta As Integer
        Dim piece As Integer
        Dim move() As Integer
        Dim value As Integer
        Dim depth As Integer

    End Structure
End Class
