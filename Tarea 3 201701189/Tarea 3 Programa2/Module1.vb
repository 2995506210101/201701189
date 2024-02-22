Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim elec As Integer

        While True
            Console.Clear()
            Console.WriteLine("Bienvenido")
            Console.Write("Por favor, ingrese su nombre de usuario: ")
            usuario = Console.ReadLine()

            Console.Clear()
            Console.WriteLine($"¡Hola, {usuario}!")

            Console.WriteLine("Seleccione una opción:")
            Console.WriteLine("1. Ejecutar el programa")
            Console.WriteLine("2. Revisar historial")
            Console.WriteLine("3. Eliminar historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            elec = Integer.Parse(Console.ReadLine())

            Select Case elec
                Case 1
                    Dim grades() As Integer = {85, 90, 92, 88, 95, 87, 82, 80, 75, 78}
                    Console.WriteLine("Registro de calificaciones:")
                    For i As Integer = 0 To grades.Length - 1
                        Console.WriteLine($"Calificación {i + 1}: {grades(i)}")
                    Next

                    Dim media As Double = GetMean(grades)
                    Dim mediana As Double = GetMedian(grades)
                    Dim moda As Integer = GetMode(grades)
                    Dim rango As Integer = GetRange(grades)
                    Dim est As Double = GetStandardDeviation(grades)
                    Dim var As Double = GetVariance(grades)

                    Console.WriteLine($"Media: {media}")
                    Console.WriteLine($"Mediana: {mediana}")
                    Console.WriteLine($"Moda: {moda}")
                    Console.WriteLine($"Rango: {rango}")
                    Console.WriteLine($"Desviación Estándar: {est}")
                    Console.WriteLine($"Varianza: {var}")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}:")
                        writer.WriteLine($"Media: {media}")
                        writer.WriteLine($"Mediana: {mediana}")
                        writer.WriteLine($"Moda: {moda}")
                        writer.WriteLine($"Rango: {rango}")
                        writer.WriteLine($"Desviación Estándar: {est}")
                        writer.WriteLine($"Varianza: {var}")
                        writer.WriteLine()
                    End Using

                Case 2
                    Console.Clear()
                    Console.WriteLine("Historial:")
                    If File.Exists("salida.txt") Then
                        Dim lines As String() = File.ReadAllLines("salida.txt")
                        For Each line As String In lines
                            Console.WriteLine(line)
                        Next
                    Else
                        Console.WriteLine("No hay historial.")
                    End If
                    Console.WriteLine("Presione cualquier tecla para continuar...")
                    Console.ReadKey()

                Case 3
                    Console.Clear()
                    If File.Exists("salida.txt") Then
                        File.Delete("salida.txt")
                        Console.WriteLine("Historial borrado.")
                    Else
                        Console.WriteLine("No hay historial para borrar.")
                    End If
                    Console.WriteLine("Presione cualquier tecla para continuar...")
                    Console.ReadKey()

                Case 4
                    Exit While

                Case Else
                    Console.WriteLine("Opción no válida. Por favor, intente nuevamente.")
            End Select
        End While
    End Sub

    Function GetMean(ByVal grades() As Integer) As Double
        Dim sum As Integer = 0
        For Each grade As Integer In grades
            sum += grade
        Next
        Return sum / grades.Length
    End Function

    Function GetMedian(ByVal grades() As Integer) As Double
        Array.Sort(grades)
        If grades.Length Mod 2 = 0 Then
            Return (grades(grades.Length \ 2) + grades((grades.Length \ 2) - 1)) / 2
        Else
            Return grades(grades.Length \ 2)
        End If
    End Function

    Function GetMode(ByVal grades() As Integer) As Integer
        Dim countMap As New Dictionary(Of Integer, Integer)()
        For Each grade As Integer In grades
            If countMap.ContainsKey(grade) Then
                countMap(grade) += 1
            Else
                countMap.Add(grade, 1)
            End If
        Next
        Dim maxCount As Integer = 0
        Dim mode As Integer = 0
        For Each kvp As KeyValuePair(Of Integer, Integer) In countMap
            If kvp.Value > maxCount Then
                maxCount = kvp.Value
                mode = kvp.Key
            End If
        Next
        Return mode
    End Function

    Function GetRange(ByVal grades() As Integer) As Integer
        Array.Sort(grades)
        Return grades(grades.Length - 1) - grades(0)
    End Function

    Function GetStandardDeviation(ByVal grades() As Integer) As Double
        Dim mean As Double = GetMean(grades)
        Dim sumOfSquares As Double = 0
        For Each grade As Integer In grades
            sumOfSquares += (grade - mean) ^ 2
        Next
        Return Math.Sqrt(sumOfSquares / grades.Length)
    End Function

    Function GetVariance(ByVal grades() As Integer) As Double
        Dim mean As Double = GetMean(grades)
        Dim sumOfSquares As Double = 0
        For Each grade As Integer In grades
            sumOfSquares += (grade - mean) ^ 2
        Next
        Return sumOfSquares / grades.Length
    End Function
End Module
