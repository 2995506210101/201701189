Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim choice As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de Tablas de Multiplicar del 1 al 10")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Eliminar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese una opción del 1 al 4: ")
            choice = Integer.Parse(Console.ReadLine())

            Select Case choice
                Case 1
                    Console.Clear()
                    Console.Write("Ingresar su usuario: ")
                    usuario = Console.ReadLine()

                    Console.Write("Ingresar un número: ")
                    Dim num As Integer = Integer.Parse(Console.ReadLine())

                    Console.WriteLine($"Tabla de multiplicar del {num}:")
                    For i As Integer = 1 To 10
                        Console.WriteLine($"{num} x {i} = {num * i}")
                    Next

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: Tabla de multiplicar del {num}")
                        For i As Integer = 1 To 10
                            writer.WriteLine($"{num} x {i} = {num * i}")
                        Next
                        writer.WriteLine()
                    End Using
                Case 2
                    If File.Exists("salida.txt") Then
                        Console.Clear()
                        Console.WriteLine("Historial:")
                        Console.WriteLine(File.ReadAllText("salida.txt"))
                    Else
                        Console.WriteLine("No se encontró historial.")
                    End If
                Case 3
                    If File.Exists("salida.txt") Then
                        File.Delete("salida.txt")
                        Console.WriteLine("Historial eliminado.")
                    Else
                        Console.WriteLine("No se encontró historial.")
                    End If
                Case 4
                    Exit While
                Case Else
                    Console.WriteLine("Opción inválida. Intentar nuevamente.")
            End Select

            Console.WriteLine("Presione Enter para continuar")
            Console.ReadLine()
        End While
    End Sub
End Module
