Imports System.IO

Module Module1
    Sub Main()
        Dim usuario As String = ""
        Dim elec As Integer

        While True
            Console.Clear()
            Console.WriteLine("Juego del Gran 8")
            Console.Write("Por favor, ingrese su nombre de usuario: ")
            usuario = Console.ReadLine()

            Console.Clear()
            Console.WriteLine($"¡Hola, {usuario}!")

            Console.WriteLine("Seleccione una opción:")
            Console.WriteLine("1. Ejecutar el juego")
            Console.WriteLine("2. Revisar historial")
            Console.WriteLine("3. Eliminar historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese su opción: ")
            elec = Integer.Parse(Console.ReadLine())

            Select Case elec
                Case 1
                    Dim rnd As New Random()
                    Dim dado1 As Integer
                    Dim dado2 As Integer
                    Dim sum As Integer

                    Do
                        Console.WriteLine("Presione cualquier tecla para lanzar los dados...")
                        Console.ReadKey()
                        dado1 = rnd.Next(1, 7)
                        dado2 = rnd.Next(1, 7)
                        sum = dado1 + dado2
                        Console.WriteLine($"Ha lanzado los dados: {dado1} y {dado2}. La suma es: {sum}")

                        If sum = 8 Then
                            Console.WriteLine("¡Has ganado!")
                            Using writer As StreamWriter = File.AppendText("salida.txt")
                                writer.WriteLine($"{usuario}: Ganaste")
                            End Using
                            Exit Do
                        ElseIf sum = 7 Then
                            Console.WriteLine("¡Has perdido!")
                            Using writer As StreamWriter = File.AppendText("salida.txt")
                                writer.WriteLine($"{usuario}: Perdiste")
                            End Using
                            Exit Do
                        Else
                            Console.WriteLine("Sigue intentándolo...")
                        End If
                    Loop

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
                        Console.WriteLine("Sin historial para borrar.")
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
