Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa para determinar si el número es Par o Impar")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Eliminar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese la opción de 1 a 4: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su usuario: ")
                    usuario = Console.ReadLine()

                    Console.Write("Ingrese un número: ")
                    Dim numero As Integer = Integer.Parse(Console.ReadLine())

                    Dim resultado As String = ""
                    If numero Mod 2 = 0 Then
                        resultado = "par"
                    Else
                        resultado = "impar"
                    End If

                    Console.WriteLine($"El número {numero} es {resultado}.")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: Número {numero} es {resultado}.")
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
                        Console.WriteLine("No se encontró el historial.")
                    End If
                Case 4
                    Exit While
                Case Else
                    Console.WriteLine("Opción inválida. Intentarlo nuevamente.")
            End Select

            Console.WriteLine("Presione Enter para continuar")
            Console.ReadLine()
        End While
    End Sub
End Module
