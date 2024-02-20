Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de la Serie de Fibonacci")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Eliminar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su usuario: ")
                    usuario = Console.ReadLine()

                    Console.Write("Ingrese un número para generar la serie de Fibonacci: ")
                    Dim numero As Integer = Integer.Parse(Console.ReadLine())

                    Dim serie As String = GenerarSerieFibonacci(numero)
                    Console.WriteLine($"Serie de Fibonacci para {numero}: {serie}.")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: Serie de Fibonacci para {numero}: {serie}.")
                    End Using

                Case 2
                    If File.Exists("salida.txt") Then
                        Console.Clear()
                        Console.WriteLine("Historial:")
                        Console.WriteLine(File.ReadAllText("salida.txt"))
                    Else
                        Console.WriteLine("No se encontró el historial.")
                    End If
                Case 3
                    If File.Exists("salida.txt") Then
                        File.Delete("salida.txt")
                        Console.WriteLine("Historial eliminado.")
                    Else
                        Console.WriteLine("No se encontró el historial.")
                    End If
                Case 4
                    Exit While
                Case Else
                    Console.WriteLine("Opción inválida. Intentarlo nuevamente.")
            End Select

            Console.WriteLine("Presione Enter para continuar. ")
            Console.ReadLine()
        End While
    End Sub

    Function GenerarSerieFibonacci(numero As Integer) As String
        Dim serie As String = ""
        Dim a As Integer = 0
        Dim b As Integer = 1

        For i As Integer = 0 To numero - 1
            serie += $"{a}, "
            Dim temp As Integer = a
            a = b
            b = temp + b
        Next

        Return serie
    End Function
End Module
