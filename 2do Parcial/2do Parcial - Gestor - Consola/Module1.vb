Imports System.Data.SqlClient
Imports System.IO

Module Module1
    Sub Main()
        Dim username As String
        Console.WriteLine("Gestor de Tareas")
        Console.Write("Ingrese su nombre de usuario: ")
        username = Console.ReadLine()

        Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=GestorTareas;Integrated Security=True"
        Dim continuar As Boolean = True

        Do While continuar
            Console.Clear()
            Console.WriteLine("Menú:")
            Console.WriteLine("1. Agregar tarea pendiente")
            Console.WriteLine("2. Editar tarea pendiente")
            Console.WriteLine("3. Eliminar tarea pendiente")
            Console.WriteLine("4. Marcar como completada la tarea")
            Console.WriteLine("5. Salir")

            Dim opcion As Integer
            Console.Write("Seleccione una opción: ")
            Try
                opcion = Integer.Parse(Console.ReadLine())
                Select Case opcion
                    Case 1
                        AgregarTareaPendiente(connectionString)
                    Case 2
                        EditarTareaPendiente(connectionString)
                    Case 3
                        EliminarTareaPendiente(connectionString)
                    Case 4
                        MarcarComoCompletada(connectionString)
                    Case 5
                        continuar = False
                        Console.WriteLine("Saliendo del programa")
                    Case Else
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.")
                End Select
            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
            End Try

            If continuar Then
                Console.WriteLine(vbCrLf & "Presione cualquier tecla para volver al menú principal")
                Console.ReadKey()
            End If
        Loop
    End Sub

    Sub AgregarTareaPendiente(ByVal connectionString As String)
        Console.Clear()
        Console.WriteLine("Agregar tarea pendiente:")
        Console.Write("Nombre del curso: ")
        Dim curso As String = Console.ReadLine()
        Console.Write("Tarea pendiente: ")
        Dim tarea As String = Console.ReadLine()
        Console.Write("Fecha y hora de entrega:")
        Dim fecha As Date = Console.ReadLine()
        Dim estado As String = "Pendiente"


        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO Tareas (Curso, Tarea, FechaEntrega, Estado) VALUES (@Curso, @Tarea, @FechaEntrega, @Estado)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Curso", curso)
                command.Parameters.AddWithValue("@Tarea", tarea)
                command.Parameters.AddWithValue("@FechaEntrega", fecha)
                command.Parameters.AddWithValue("@Estado", estado)
                command.ExecuteNonQuery()
            End Using
        End Using

        Console.WriteLine("Tarea pendiente agregada")
    End Sub

    Sub EditarTareaPendiente(ByVal connectionString As String)
        Console.Clear() ' Limpiar la pantalla
        Console.WriteLine("Editar tarea pendiente:")
        Console.WriteLine("Listado de tareas pendientes:")
        MostrarTareasPendientes(connectionString)

        Console.Write("Ingrese el número de la tarea que desea editar: ")
        Dim tareaId As Integer = Integer.Parse(Console.ReadLine())

        Console.WriteLine("Seleccione qué desea editar:")
        Console.WriteLine("1. Nombre del curso")
        Console.WriteLine("2. Descripción de la tarea")
        Console.WriteLine("3. Fecha y hora de entrega")

        Dim opcion As Integer = Integer.Parse(Console.ReadLine())

        Dim nuevoValor As String
        Select Case opcion
            Case 1
                Console.Write("Nuevo nombre del curso: ")
                nuevoValor = Console.ReadLine()
                ActualizarCampo(connectionString, "Curso", nuevoValor, tareaId)
            Case 2
                Console.Write("Nueva descripción de la tarea: ")
                nuevoValor = Console.ReadLine()
                ActualizarCampo(connectionString, "Tarea", nuevoValor, tareaId)
            Case 3
                Console.Write("Nueva fecha u hora de entrega: ")
                nuevoValor = Console.ReadLine()
                ActualizarCampo(connectionString, "FechaEntrega", nuevoValor, tareaId)
            Case Else
                Console.WriteLine("Opción no válida.")
        End Select

        Console.WriteLine("Tarea editada.")
    End Sub

    Sub EliminarTareaPendiente(ByVal connectionString As String)
        Console.Clear()
        Console.WriteLine("Eliminar tarea pendiente:")
        Console.WriteLine("Listado de tareas pendientes:")
        MostrarTareasPendientes(connectionString)

        Console.Write("Ingrese el número de la tarea que desea eliminar: ")
        Dim tareaId As Integer = Integer.Parse(Console.ReadLine())

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "DELETE FROM Tareas WHERE Id = @Id"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", tareaId)
                command.ExecuteNonQuery()
            End Using
        End Using

        Console.WriteLine("Tarea eliminada.")
    End Sub

    Sub MarcarComoCompletada(ByVal connectionString As String)
        Console.Clear()
        Console.WriteLine("Marcar tarea como completada:")
        Console.WriteLine("Listado de tareas pendientes:")
        MostrarTareasPendientes(connectionString)

        Console.Write("Ingrese el número de la tarea que desea marcar como completada: ")
        Dim tareaId As Integer = Integer.Parse(Console.ReadLine())

        ActualizarCampo(connectionString, "Estado", "Completada", tareaId)

        Console.WriteLine("Tarea marcada como completada exitosamente.")
    End Sub

    Sub MostrarTareasPendientes(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT Id, Curso, Tarea, FechaEntrega FROM Tareas WHERE Estado = 'Pendiente'"
            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Console.WriteLine($"[{reader("Id")}]: {reader("Curso")} - {reader("Tarea")} - Fecha de entrega: {reader("FechaEntrega")}")
                    End While
                End Using
            End Using
        End Using
    End Sub

    Sub ActualizarCampo(ByVal connectionString As String, ByVal campo As String, ByVal nuevoValor As String, ByVal tareaId As Integer)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = $"UPDATE Tareas SET {campo} = @NuevoValor WHERE Id = @Id"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@NuevoValor", nuevoValor)
                command.Parameters.AddWithValue("@Id", tareaId)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Module
