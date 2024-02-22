Imports System
Imports System.IO
Module Module1
    Dim historial As New List(Of String)

    Sub Main()
        Dim opcion As Integer
        Dim nombre As String
        Dim modelo As Integer
        Dim km As Integer
        Dim resultado As String

        Do
            Console.Clear()
            Console.WriteLine("1. Iniciar el programa")
            Console.WriteLine("2. Ver historial")
            Console.WriteLine("3. Borrar historial")
            Console.WriteLine("4. Salir")
            Console.Write("Ingrese una opción: ")
            opcion = CInt(Console.ReadLine())

            Select Case opcion
                Case 1
                    Console.Write("Ingrese su nombre de usuario: ")
                    nombre = Console.ReadLine()
                    Console.Write("Ingrese el modelo del taxi (año): ")
                    modelo = CInt(Console.ReadLine())
                    Console.Write("Ingrese el recorrido en km: ")
                    km = CInt(Console.ReadLine())

                    If modelo < 2007 AndAlso km > 20000 Then
                        resultado = "El taxi necesita renovarse"
                    ElseIf modelo >= 2007 AndAlso modelo <= 2013 AndAlso km > 20000 Then
                        resultado = "El taxi necesita mantenimiento"
                    ElseIf modelo > 2013 AndAlso km < 10000 Then
                        resultado = "El taxi está en óptimas condiciones"
                    Else
                        resultado = "Mecánico"
                    End If

                    historial.Add($"{DateTime.Now}: {nombre} - {modelo} - {km} - {resultado}")
                    Console.WriteLine("Resultado: " & resultado)
                    Console.WriteLine("Presione cualquier tecla para continuar...")
                    Console.ReadKey()
                Case 2
                    Console.WriteLine("Historial:")
                    For Each registro In historial
                        Console.WriteLine(registro)
                    Next
                    Console.WriteLine("Presione cualquier tecla para continuar...")
                    Console.ReadKey()
                Case 3
                    historial.Clear()
                    Console.WriteLine("Historial borrado")
                    Console.WriteLine("Presione cualquier tecla para continuar...")
                    Console.ReadKey()
                Case 4
                    Exit Do
                Case Else
                    Console.WriteLine("Opción no válida")
                    Console.WriteLine("Presione cualquier tecla para continuar...")
                    Console.ReadKey()
            End Select
        Loop

        File.WriteAllLines("salida.txt", historial)
    End Sub
End Module