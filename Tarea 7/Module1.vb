Module Module1

    Sub Main()
        Dim m, n, i, j As Integer
        Dim A(2, 2) As Integer
        Console.Write(vbLf & "Enter The Matrix Elements any two: ")
        For i = 0 To 2 - 1
            For j = 0 To 2 = 1
                A(i, j) = Convert.ToInt16(Console.ReadLine())
            Next
        Next
        Console.Clear()
        Console.WriteLine(vbLf & "Matrix A: ")
        For i = 0 To 2 - 1
            For j = 0 To 2 - 1
                Console.Write(vbLf & "{0}", A(i, j))
            Next
            Console.WriteLine(" ")
        Next
        Console.WriteLine(vbLf & "Transpose Matrix: ")
        For i = 0 To 2 - 1
            For j = 0 To 2 - 1
                Console.Write(vbLf & "{0}", A(j, i))
            Next
            Console.WriteLine("Presione enter para salir ")
            Console.ReadLine()
        Next
    End Sub

End Module
