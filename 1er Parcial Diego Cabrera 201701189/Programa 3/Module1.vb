Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de Positivo, Negativo o Cero")
            Console.WriteLine("2. Revisar el Historial")
            Console.WriteLine("3. Limpiar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingresar una opción del 1 al 4: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese el usuario: ")
                    usuario = Console.ReadLine()
                    Console.Write("Ingrese un número: ")
                    Dim number As Double = Double.Parse(Console.ReadLine())
                    Dim resultado As String
                    If number > 0 Then
                        resultado = "Positivo"
                    ElseIf number < 0 Then
                        resultado = "Negativo"
                    Else
                        resultado = "Cero"
                    End If
                    Console.WriteLine($"El número ingresado es {resultado}.")
                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: El número ingresado es {resultado}.")
                    End Using
                    Console.WriteLine("Presiona enter para continuar.")
                    Console.ReadLine()
                Case 2
                    Console.Clear()
                    If File.Exists("salida.txt") Then
                        Console.WriteLine("Historial:")
                        For Each line As String In File.ReadAllLines("salida.txt")
                            Console.WriteLine(line)
                        Next
                    Else
                        Console.WriteLine("No se encontró el historial")
                    End If
                    Console.WriteLine("Presiona enter para continuar")
                    Console.ReadLine()
                Case 3
                    Console.Clear()
                    If File.Exists("salida.txt") Then
                        File.Delete("salida.txt")
                        Console.WriteLine("Historial eliminado")
                    Else
                        Console.WriteLine("No se encontró el historial")
                    End If
                    Console.WriteLine("Press Enter para continuar")
                    Console.ReadLine()
                Case 4
                    Exit While
                Case Else
                    Console.WriteLine("Opción invalida. Intente nuevamente.")
                    Console.WriteLine("Presiona enter para continuar")
                    Console.ReadLine()
            End Select
        End While
    End Sub
End Module
