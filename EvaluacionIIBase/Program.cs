using LibreriaEvaluacion.DAL;
using LibreriaEvaluacion.DTO;

const string nombreAlumno = "Wachimingo";

while (Menu(nombreAlumno))
{
    Console.ReadKey(); // pausa, solicitar la entrada de una tecla
}


static bool Menu(string nombreAlumno)
{ 
    bool continuar = true;

    Console.Clear(); // Limpia la pantalla
    Console.Title = $"Evaluación II: {nombreAlumno}";

    Console.WriteLine("Menú de opciones");
    Console.WriteLine("================");
    Console.WriteLine("1) Listar préstamos");
    Console.WriteLine("2) Agregar préstamo");
    Console.WriteLine("3) Actualizar préstamo");
    Console.WriteLine("4) Eliminar préstamo");
    Console.WriteLine("");
    Console.WriteLine("0) Salir");

    string opcion = Console.ReadLine().Trim(); // " 1 " => "1"

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Listado de préstamos registrados");
            // ToDo: Lógica GUI de listado
            Listar();
            break;
        case "2":
            Console.WriteLine("Insertar un nuevo préstamo");
            // ToDo: Lógica GUI de inserción
            Agregar();
            break;
        case "3":
            Console.WriteLine("Actualizar un préstamo existente");
            // ToDo: Lógica GUI de actualización
            Actualizar();
            break;
        case "4":
            Console.WriteLine("Eliminar un préstamo existente");
            // ToDo: Lógica GUI de eliminación
            Eliminar();
            break;
        case "0":
            Console.WriteLine("Saliendo del programa ...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    return continuar;
}

// ToDo: lógica de GUI

static void Listar()
{
    PrestamoDAL prestamoDal = new PrestamoDAL();
    List<PrestamoDTO> prestamos = prestamoDal.List();

    foreach (PrestamoDTO prestamo  in prestamos)
    {
        Console.WriteLine(prestamo.ToString());
    }
}

static void Agregar()
{
    PrestamoDAL prestamoDal = new PrestamoDAL();
    try
    {
        Console.WriteLine("Ingrese ID");
        int id = int.Parse(Console.ReadLine().Trim());

        PrestamoDTO idFind = prestamoDal.BuscarPorId(id);
        if (idFind == null)
        {
            Console.WriteLine("Ingrese monto");
            int monto = int.Parse(Console.ReadLine().Trim());
            if (monto >= 50000)
            {
                PrestamoDTO prestamo = new PrestamoDTO()
                {
                    Id = id,
                    Monto = monto
                };

                bool resultado = prestamoDal.Insertar(prestamo);

                if (resultado)
                {
                    Console.WriteLine($"Se pidio la cantidad de: {prestamo.Monto}");
                }
                else
                {
                    Console.WriteLine($"NO se pidio la cantidad de: {prestamo.Monto}");
                }
            }
            else
            {
                Console.WriteLine("El monto minimo a pedir es 50000");
            }
        }
        else
        {
            Console.WriteLine("ID ya existe");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Debe ingresar un numero");
    }
}

static void Actualizar()
{
    try
    {
        PrestamoDAL prestamoDal = new PrestamoDAL();
        
        Console.WriteLine("Ingrese el ID del prestamo a modificar");
        int id = int.Parse(Console.ReadLine().Trim());

        PrestamoDTO resultado = prestamoDal.BuscarPorId(id);

        if (resultado != null)
        {
            Console.WriteLine("¿Desea cambiar el monto? (Y/N)");
            string opcion = Console.ReadLine().Trim().ToUpper();
            if (opcion == "Y")
            {
                Console.WriteLine($"Monto actual: {resultado.Monto}");
                int monto = int.Parse(Console.ReadLine().Trim());
                if (monto >= 50000)
                {
                    resultado.Monto = monto;
                    Console.WriteLine("Se cambio correctamente");
                }
                else
                {
                    Console.WriteLine("El monto minimo a pedir es 50000");
                }
            }
        }
        else
        {
            Console.WriteLine("El id no existe");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Debe ingresar un numero");
    }
}

static void Eliminar()
{
    try
    {
        PrestamoDAL prestamoDal = new PrestamoDAL();
        
        Console.WriteLine("Ingrese el ID a eliminar");
        int id = int.Parse(Console.ReadLine().Trim());

        PrestamoDTO resultado = prestamoDal.BuscarPorId(id);

        if (resultado != null)
        {
            prestamoDal.Eliminar(resultado, resultado.Id);
            Console.WriteLine($"Se elimino el prestamo: {resultado.Id}, con el monto: {resultado.Monto}");
        }
        else
        {
            Console.WriteLine("El id no existe");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Debe ingresar un numero");
    }
}