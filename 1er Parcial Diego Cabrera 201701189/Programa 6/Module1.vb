Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de Conversión de Grados Celsius a Grados Fahrenheit")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Eliminar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese una opción del 1 al 4: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su usuario: ")
                    usuario = Console.ReadLine()

                    Console.Write("Ingrese los grados Celsius: ")
                    Dim celsius As Double = Double.Parse(Console.ReadLine())
                    Dim fahrenheit As Double = (celsius * 9 / 5) + 32
                    Console.WriteLine($"Los grados Fahrenheit son: {fahrenheit}")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: {celsius} grados Celsius son {fahrenheit} grados Fahrenheit.")
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
                    Console.WriteLine("Opción inválida. Intentar neuvamente.")
            End Select

            Console.WriteLine("Presione Enter para continuar")
            Console.ReadLine()
        End While
    End Sub
End Module
