using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Iniciar servicio");
            Console.WriteLine("2. Detener servicio");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese la opción deseada: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    IniciarServicio();
                    break;
                case 2:
                    DetenerServicio();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void IniciarServicio()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Inicio de Servicios:");
            Console.WriteLine("1. SQL Server");
            Console.WriteLine("2. SQL Express");
            Console.WriteLine("3. Full-Text");
            Console.WriteLine("4. SQLBrowser");
            Console.WriteLine("5. SQLTELEMETRY$SQLEXPRESS");
            Console.WriteLine("6. SQLWriter");
            Console.WriteLine("7. Volver al menú principal");
            Console.Write("Ingrese la opción deseada: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    EjecutarComandoComoAdmin("sc", "start MSSQL$SQLEXPRESS");
                    break;
                case 2:
                    EjecutarComandoComoAdmin("sc", "start SQLAgent$SQLEXPRESS");
                    break;
                case 3:
                    EjecutarComandoComoAdmin("sc", "start MSSQLFDLauncher$SQLEXPRESS");
                    return;
                case 4:
                    EjecutarComandoComoAdmin("sc", "start SQLBrowser");
                    break;
                case 5:
                    EjecutarComandoComoAdmin("sc", "start SQLTELEMETRY$SQLEXPRESS");
                    break;
                case 6:
                    EjecutarComandoComoAdmin("sc", "start SQLWriter");
                    break;
                case 7:
                    Console.WriteLine("Volviendo al menú principal.");
                    return;
                    break;
                default:

                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void DetenerServicio()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Detención de Servicios:");
            Console.WriteLine("1. SQL Server");
            Console.WriteLine("2. SQL Express");
            Console.WriteLine("3. Full-Text");
            Console.WriteLine("4. SQLBrowser");
            Console.WriteLine("5. SQLTELEMETRY$SQLEXPRESS");
            Console.WriteLine("6. SQLWriter");
            Console.WriteLine("7. Volver al menú principal");
            Console.Write("Ingrese la opción deseada: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

         
            switch (opcion)
            {
                case 1:
                    EjecutarComandoComoAdmin("sc", "stop MSSQL$SQLEXPRESS");
                    break;
                case 2:
                    EjecutarComandoComoAdmin("sc", "stop SQLAgent$SQLEXPRESS");
                    break;
                case 3:
                    EjecutarComandoComoAdmin("sc", "stop MSSQLFDLauncher$SQLEXPRESS");
                    return;
                case 4:
                    EjecutarComandoComoAdmin("sc", "stop SQLBrowser");
                    break;
                case 5:
                    EjecutarComandoComoAdmin("sc", "stop SQLTELEMETRY$SQLEXPRESS");
                    break;
                case 6:
                    EjecutarComandoComoAdmin("sc", "stop SQLWriter");
                    break;
                case 7:
                    Console.WriteLine("Volviendo al menú principal.");
                    return;
                    break;
                default:

                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void EjecutarComandoComoAdmin(string cmdServices, string args)
    {
        try
        {
            var processStartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = cmdServices,
                Arguments = args,
                UseShellExecute = true,
                Verb = "runas", // Solicitar elevación de privilegios
                CreateNoWindow = false
            };

            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
                Console.WriteLine("Comando ejecutado correctamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al ejecutar el comando: {ex.Message}");
        }
    }
}
