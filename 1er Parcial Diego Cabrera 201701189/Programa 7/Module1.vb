Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de Interés Compuesto")
            Console.WriteLine("2. Revisar el historial")
            Console.WriteLine("3. Eliminar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción del 1 al 4: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su usuario: ")
                    usuario = Console.ReadLine()

                    Console.Write("Ingresar el monto inicial: ")
                    Dim montoInicial As Double = Double.Parse(Console.ReadLine())

                    Console.Write("Ingresar el número de años: ")
                    Dim años As Integer = Integer.Parse(Console.ReadLine())

                    Dim montoFinal As Double = montoInicial * Math.Pow(1 + 0.05, años)
                    Console.WriteLine($"El monto final después de {años} años es: {montoFinal}")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: Monto inicial = {montoInicial}, Años = {años}, Monto final = {montoFinal}")
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
                    Console.WriteLine("Opción inválida. Intentar nuevamente.")
            End Select

            Console.WriteLine("Presione Enter para continuar+/8")
            Console.ReadLine()
        End While
    End Sub
End Module
