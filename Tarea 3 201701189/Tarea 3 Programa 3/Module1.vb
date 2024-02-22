Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim elec As Integer

        Console.WriteLine("Bienvenido al programa.")
        Console.Write("Por favor, ingrese su nombre de usuario: ")
        usuario = Console.ReadLine()

        While True
            Console.Clear()
            Console.WriteLine($"¡Hola, {usuario}!")

            Console.WriteLine("Seleccione una opción:")
            Console.WriteLine("1. Calcular IVA")
            Console.WriteLine("2. Revisar historial")
            Console.WriteLine("3. Eliminar historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            elec = Integer.Parse(Console.ReadLine())

            Select Case elec
                Case 1
                    Dim precio As Double
                    Console.Write("Ingrese el precio en quetzales: ")
                    precio = Double.Parse(Console.ReadLine())

                    Dim iva As Double = precio * 0.12
                    Dim precioSinIVA As Double = precio - iva

                    Console.WriteLine($"El precio sin IVA es: {precioSinIVA} quetzales")
                    Console.WriteLine($"El IVA es: {iva} quetzales")

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}:")
                        writer.WriteLine($"Precio sin IVA: {precioSinIVA} quetzales")
                        writer.WriteLine($"IVA: {iva} quetzales")
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
                        Console.WriteLine("Sin historial.")
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
End Module
