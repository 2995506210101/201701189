Imports System.IO

Module Module1
    Sub Main()
        Dim userName As String = ""
        Dim choice As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Iniciar el programa")
            Console.WriteLine("2. Ver el historial")
            Console.WriteLine("3. Borrar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            choice = Integer.Parse(Console.ReadLine())

            Select Case choice
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su nombre de usuario: ")
                    userName = Console.ReadLine()

                    Console.Write("Ingrese un número: ")
                    Dim num As Integer = Integer.Parse(Console.ReadLine())

                    Dim esPrimo As Boolean = True
                    If num <= 1 Then
                        esPrimo = False
                    Else
                        For i As Integer = 2 To Math.Sqrt(num)
                            If num Mod i = 0 Then
                                esPrimo = False
                                Exit For
                            End If
                        Next
                    End If

                    Dim resultado As String = If(esPrimo, "es primo", "no es primo")
                    Console.WriteLine($"El número ingresado {resultado}.")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{userName}: El número ingresado {resultado}.")
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
                        Console.WriteLine("Historial borrado.")
                    Else
                        Console.WriteLine("No se encontró historial.")
                    End If
                Case 4
                    Exit While
                Case Else
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.")
            End Select

            Console.WriteLine("Presione Enter para continuar...")
            Console.ReadLine()
        End While
    End Sub
End Module
