Module Module1

    Sub Main()
        Dim notas(4) As Double
        Dim suma As Double = 0
        For i As Integer = 0 To 4
            Console.Write("Ingrese la nota " & (i + 1) & ": ")
            notas(i) = Double.Parse(Console.ReadLine())
            suma += notas(i)
        Next
        Dim promedio As Double = suma / 5
        Console.WriteLine("El promedio es: " & promedio)
        Console.WriteLine("Presione cualquier tecla para cerrar el programa")
        Console.ReadKey()

    End Sub

End Module
