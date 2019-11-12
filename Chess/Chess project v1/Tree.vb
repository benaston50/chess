Public Class Tree
    Inherits MovePiece
    Public NodeCount As Integer
    Protected Structure Node
        Dim Children As List(Of Node)
        Public ReadOnly Property child() As List(Of Node)
            Get
                If Children Is Nothing Then
                    Children = New List(Of Node)
                End If
                Return Children
            End Get
        End Property
        Dim alpha, beta As Integer
        Dim piece As Integer
        Dim move() As Integer
        Dim value As Integer
        Dim depth As Integer

    End Structure
End Class
