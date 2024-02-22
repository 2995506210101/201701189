Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim elec As Integer

        Console.WriteLine("Bienvenido")
        Console.Write("Por favor, ingrese su nombre de usuario: ")
        usuario = Console.ReadLine()

        While True
            Console.Clear()
            Console.WriteLine($"¡Hola, {usuario}!")

            Console.WriteLine("Seleccione una opción:")
            Console.WriteLine("1. Ejecutar verificación de número primo")
            Console.WriteLine("2. Revisar historial")
            Console.WriteLine("3. Eliminar historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            elec = Integer.Parse(Console.ReadLine())

            Select Case elec
                Case 1
                    Dim numero As Integer
                    Console.Write("Ingrese un número: ")
                    numero = Integer.Parse(Console.ReadLine())

                    Dim esPrimo As Boolean = VerificarPrimo(numero)

                    If esPrimo Then
                        Console.WriteLine($"El número {numero} es primo.")
                    Else
                        Console.WriteLine($"El número {numero} es compuesto.")
                    End If

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}:")
                        writer.WriteLine($"Número ingresado: {numero}")
                        writer.WriteLine($"Resultado: {(If(esPrimo, "Primo", "Compuesto"))}")
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
                        Console.WriteLine("No hay historial.")
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

    Function VerificarPrimo(ByVal numero As Integer) As Boolean
        If numero <= 1 Then
            Return False
        End If

        For i As Integer = 2 To Math.Sqrt(numero)
            If numero Mod i = 0 Then
                Return False
            End If
        Next

        Return True
    End Function
End Module
