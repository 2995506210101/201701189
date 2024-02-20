Imports System
Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Iniciar el programa de suma de enteros")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Borrar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingresar una opción del 1 al 4: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingresar el usuario: ")
                    usuario = Console.ReadLine()

                    Console.Clear()
                    Console.Write("Ingresa el primer número: ")
                    Dim num1 As Integer = Integer.Parse(Console.ReadLine())

                    Console.Clear()
                    Console.Write("Ingresa el segundo número: ")
                    Dim num2 As Integer = Integer.Parse(Console.ReadLine())

                    Console.Clear()
                    Dim resultado As Integer = num1 + num2
                    Console.WriteLine($"La suma de {num1} y {num2} es {resultado}.")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: {resultado}")
                    End Using
                Case 2
                    Console.Clear()
                    If File.Exists("salida.txt") Then
                        Console.WriteLine("Historial:")
                        For Each line As String In File.ReadAllLines("salida.txt")
                            Console.WriteLine(line)
                        Next
                    Else
                        Console.WriteLine("No se encontró el historial.")
                    End If
                Case 3
                    Console.Clear()
                    If File.Exists("salida.txt") Then
                        File.Delete("salida.txt")
                        Console.WriteLine("Historial borrado.")
                    Else
                        Console.WriteLine("No se encontró el historial.")
                    End If
                Case 4
                    Exit While
                Case Else
                    Console.Clear()
                    Console.WriteLine("Elección invalida. Intente nuevamente.")
            End Select

            Console.WriteLine("Presiona cualquier tecla para continuar")
            Console.ReadKey()
        End While
    End Sub
End Module