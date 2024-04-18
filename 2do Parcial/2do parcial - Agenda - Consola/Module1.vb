Imports System.IO
Imports System.Data.SqlClient

Module Module1
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=AgendaContactos;Integrated Security=True"
    Dim connection As New SqlConnection(connectionString)

    Sub Main()
        Console.WriteLine("Agenda de Contactos")
        Console.Write("Ingrese su nombre de usuario: ")
        Dim nombreUsuario As String = Console.ReadLine()
        Console.WriteLine("Bienvenido, " & nombreUsuario & "!")

        Dim opcion As Integer
        Do
            Console.Clear()
            Console.WriteLine(vbCrLf & "Menú:")
            Console.WriteLine("1. Agregar contacto")
            Console.WriteLine("2. Editar contacto")
            Console.WriteLine("3. Eliminar contacto")
            Console.WriteLine("4. Buscar contacto")
            Console.WriteLine("5. Salir")
            Console.Write("Ingrese su opción: ")

            Try
                opcion = Integer.Parse(Console.ReadLine())
                Select Case opcion
                    Case 1
                        AgregarContacto()
                    Case 2
                        EditarContacto()
                    Case 3
                        EliminarContacto()
                    Case 4
                        BuscarContacto()
                    Case 5
                        Exit Do
                    Case Else
                        Console.WriteLine("Opción inválida")
                End Select

                Console.Write("Presione cualquier tecla para continuar")
                Console.ReadKey()
            Catch ex As Exception
                Console.WriteLine("Ocurrió un error: " & ex.Message)
            End Try
        Loop While opcion <> 5
    End Sub

    Sub AgregarContacto()
        Console.Clear()
        Console.WriteLine("Agregar Contacto")
        Console.WriteLine("Ingrese el nombre del contacto:")
        Dim nombre As String = Console.ReadLine()
        Console.WriteLine("Ingrese el número de teléfono del contacto:")
        Dim telefono As String = Console.ReadLine()

        Try
            connection.Open()
            Dim query As String = "INSERT INTO Contactos (Nombre, Telefono) VALUES (@Nombre, @Telefono)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Nombre", nombre)
            command.Parameters.AddWithValue("@Telefono", telefono)
            command.ExecuteNonQuery()
            connection.Close()

            Console.WriteLine("Contacto agregado correctamente.")
        Catch ex As Exception
            Console.WriteLine("Error al agregar el contacto: " & ex.Message)
        End Try
    End Sub

    Sub EditarContacto()
        Console.Clear()
        Console.WriteLine("Editar Contacto")
        MostrarContactos()

        Console.WriteLine("Ingrese el número de ID del contacto a editar:")
        Dim idContacto As Integer = Integer.Parse(Console.ReadLine())

        Console.WriteLine("Ingrese el nuevo nombre del contacto:")
        Dim nuevoNombre As String = Console.ReadLine()
        Console.WriteLine("Ingrese el nuevo número de teléfono del contacto:")
        Dim nuevoTelefono As String = Console.ReadLine()

        Try
            connection.Open()
            Dim query As String = "UPDATE Contactos SET Nombre = @Nombre, Telefono = @Telefono WHERE ID = @ID"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Nombre", nuevoNombre)
            command.Parameters.AddWithValue("@Telefono", nuevoTelefono)
            command.Parameters.AddWithValue("@ID", idContacto)
            Dim affectedRows As Integer = command.ExecuteNonQuery()
            connection.Close()

            If affectedRows > 0 Then
                Console.WriteLine("Contacto editado correctamente.")
            Else
                Console.WriteLine("No se encontró ningún contacto con el ID proporcionado.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error al editar el contacto: " & ex.Message)
        End Try
    End Sub

    Sub EliminarContacto()
        Console.Clear()
        Console.WriteLine("Eliminar Contacto")
        MostrarContactos()

        Console.WriteLine("Ingrese el ID del contacto a eliminar:")
        Dim idContacto As Integer = Integer.Parse(Console.ReadLine())

        Try
            connection.Open()
            Dim query As String = "DELETE FROM Contactos WHERE ID = @ID"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ID", idContacto)
            Dim affectedRows As Integer = command.ExecuteNonQuery()
            connection.Close()

            If affectedRows > 0 Then
                Console.WriteLine("Contacto eliminado correctamente.")
            Else
                Console.WriteLine("No se encontró ningún contacto con el ID proporcionado.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error al eliminar el contacto: " & ex.Message)
        End Try
    End Sub

    Sub BuscarContacto()
        Console.Clear()
        Console.WriteLine("Buscar Contacto")
        Console.WriteLine("Ingrese parte del nombre o del número a buscar:")
        Dim buscar As String = Console.ReadLine()

        Try
            connection.Open()
            Dim query As String = "SELECT * FROM Contactos WHERE Nombre LIKE @Buscar OR Telefono LIKE @Buscar"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Buscar", "%" & buscar & "%")
            Dim reader As SqlDataReader = command.ExecuteReader()

            Console.WriteLine("Resultados de la búsqueda:")
            While reader.Read()
                Console.WriteLine("ID: " & reader("ID") & ", Nombre: " & reader("Nombre") & ", Teléfono: " & reader("Telefono"))
            End While

            connection.Close()
        Catch ex As Exception
            Console.WriteLine("Error al buscar el contacto: " & ex.Message)
        End Try
    End Sub

    Sub MostrarContactos()
        Console.WriteLine("Contactos Guardados:")
        Try
            connection.Open()
            Dim query As String = "SELECT * FROM Contactos"
            Dim command As New SqlCommand(query, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Console.WriteLine("ID | Nombre | Teléfono")
            Console.WriteLine("-----------------------")
            While reader.Read()
                Console.WriteLine(reader("ID") & " | " & reader("Nombre") & " | " & reader("Telefono"))
            End While

            connection.Close()
        Catch ex As Exception
            Console.WriteLine("Error al mostrar los contactos: " & ex.Message)
        End Try
    End Sub
End Module
