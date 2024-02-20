Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim eleccion As Integer
        Dim saldo As Double = 0.0

        While True
            Console.Clear()
            Console.WriteLine("1. Ejecutar el programa de Cajero")
            Console.WriteLine("2. Ver el historial")
            Console.WriteLine("3. Borrar el historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            eleccion = Integer.Parse(Console.ReadLine())

            Select Case eleccion
                Case 1
                    Console.Clear()
                    Console.Write("Ingrese su usuario: ")
                    usuario = Console.ReadLine()

                    Dim subChoice As Integer

                    While True
                        Console.Clear()
                        Console.WriteLine("1. Depositar dinero")
                        Console.WriteLine("2. Retirar dinero")
                        Console.WriteLine("3. Consultar saldo")
                        Console.WriteLine("4. Volver al menú principal")
                        Console.Write("Ingrese su opción: ")
                        subChoice = Integer.Parse(Console.ReadLine())

                        Select Case subChoice
                            Case 1
                                Console.Write("Ingrese la cantidad a depositar: ")
                                Dim deposito As Double = Double.Parse(Console.ReadLine())
                                saldo += deposito
                                Console.WriteLine($"Depósito exitoso. Nuevo saldo: {saldo}")
                            Case 2
                                Console.Write("Ingrese la cantidad a retirar: ")
                                Dim retiro As Double = Double.Parse(Console.ReadLine())
                                If retiro <= saldo Then
                                    saldo -= retiro
                                    Console.WriteLine($"Retiro exitoso. Nuevo saldo: {saldo}")
                                Else
                                    Console.WriteLine("Fondos insuficientes.")
                                End If
                            Case 3
                                Console.WriteLine($"Saldo actual: {saldo}")
                            Case 4
                                Exit While
                            Case Else
                                Console.WriteLine("Opción inválida. Por favor, intente de nuevo.")
                        End Select
                    End While

                    Using writer As StreamWriter = File.AppendText("salida.txt")
                        writer.WriteLine($"{usuario}: Saldo actual = {saldo}")
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
