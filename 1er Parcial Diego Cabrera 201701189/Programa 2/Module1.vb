Imports System
Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim num1 As Double
        Dim num2 As Double
        Dim eleccion As Integer
        Dim operacion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de calculadora")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Limpiar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese una opción del 1 al 4: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su usuario: ")
                    usuario = Console.ReadLine()

                    Console.Clear()
                    Console.Write("Ingrese el primer número: ")
                    num1 = Double.Parse(Console.ReadLine())

                    Console.Clear()
                    Console.Write("Ingrese el segundo número: ")
                    num2 = Double.Parse(Console.ReadLine())

                    Console.Clear()
                    Console.WriteLine("1. Suma")
                    Console.WriteLine("2. Resta")
                    Console.WriteLine("3. Multiplicación")
                    Console.WriteLine("4. División")
                    Console.Write("Ingrese una opción: ")
                    operacion = Integer.Parse(Console.ReadLine())

                    Console.Clear()
                    Dim resultado As Double
                    Select Case operacion
                        Case 1
                            resultado = num1 + num2
                            Console.WriteLine($"La suma de {num1} y {num2} es {resultado}.")
                        Case 2
                            resultado = num1 - num2
                            Console.WriteLine($"La resta entre {num1} y {num2} es {resultado}.")
                        Case 3
                            resultado = num1 * num2
                            Console.WriteLine($"La multiplicación de {num1} y {num2} es {resultado}.")
                        Case 4
                            If num2 = 0 Then
                                Console.WriteLine("No se puede dividir dentro de 0.")
                            Else
                                resultado = num1 / num2
                                Console.WriteLine($"El cociente de {num1} y {num2} es {resultado}.")
                            End If
                        Case Else
                            Console.WriteLine("Opción invalida. Intente de nuevo, por favor.")
                            Exit Select
                    End Select

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
                        Console.WriteLine("Historial eliminado.")
                    Else
                        Console.WriteLine("No se encontró el historial.")
                    End If
                Case 4
                    Exit While
                Case Else
                    Console.Clear()
                    Console.WriteLine("Opción invalida. Intente de nuevo.")
            End Select

            Console.WriteLine("Presione cualquier tecla para continuar")
            Console.ReadKey()
        End While
    End Sub
End Module