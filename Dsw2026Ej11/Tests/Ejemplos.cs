using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("=== EJEMPLO LISTA DE ALUMNOS ===");
        CasoList casoList = new CasoList();

        casoList.AgregarAlumno(new Alumno(1, "Tomy Alva", 8.5));
        casoList.AgregarAlumno(new Alumno(2, "Seba Zeta", 9.2));
        casoList.AgregarAlumno(new Alumno(3, "Negro Soria", 6.0));

        Console.WriteLine("Alumnos en la lista:");
        casoList.RetornarLista().ForEach(Console.WriteLine);

        Console.WriteLine("\nBuscando a 'Seba Zeta'...");
        var al1 = casoList.BuscarPorNombre("Seba Zeat");
        Console.WriteLine(al1 != null ? al1.ToString() : "No existe");

        Console.WriteLine("\nBuscando a 'Juan Diaz'...");
        var al2 = casoList.BuscarPorNombre("Juan Diaz");
        Console.WriteLine(al2 != null ? al2.ToString() : "No existe");

        Console.WriteLine("\nEliminando a 'Negro Soria'...");
        var alumnoAEliminar = casoList.BuscarPorNombre("Negro Soria");
        casoList.EliminarAlumno(alumnoAEliminar);
        casoList.RetornarLista().ForEach(Console.WriteLine);

        Console.WriteLine("\nEliminando el elemento en la posición 0...");
        casoList.EliminarEnPosicion(0);
        casoList.RetornarLista().ForEach(Console.WriteLine);
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("=== EJEMPLO DICCIONARIO DE ALUMNOS ===");
        CasoDictionary casoDict = new CasoDictionary();

        casoDict.AgregarAlumno(new Alumno(4, "Facu Baca", 7.5));
        casoDict.AgregarAlumno(new Alumno(5, "Gabi Villa", 8.0));
        casoDict.AgregarAlumno(new Alumno(6, "Cacho Uberti", 9.5));

        Console.WriteLine("Alumnos en el diccionario:");
        foreach (var kvp in casoDict.RetornarDiccionario())
        {
            Console.WriteLine($"Legajo (Clave): {kvp.Key} -> {kvp.Value}");
        }

        Console.WriteLine("\nBuscando legajo 5:");
        var al1 = casoDict.BuscarPorClave(20);
        Console.WriteLine(al1 != null ? al1.ToString() : "No existe");

        Console.WriteLine("\nBuscando legajo 7:");
        var al2 = casoDict.BuscarPorClave(7);
        Console.WriteLine(al2 != null ? al2.ToString() : "No existe");

        Console.WriteLine("\nEliminando legajo 4...");
        casoDict.EliminarPorClave(4);
        foreach (var kvp in casoDict.RetornarDiccionario())
        {
            Console.WriteLine($"Legajo (Clave): {kvp.Key} -> {kvp.Value}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("=== EJEMPLO CONSULTAS LINQ ===");
        CasoLinq casoLinq = new CasoLinq();

        Console.WriteLine($"1. Primer libro: {casoLinq.GetPrimero()?.Titulo}");
        Console.WriteLine($"2. Último libro: {casoLinq.GetUltimo()?.Titulo}");
        Console.WriteLine($"3. Suma total de precios: {casoLinq.GetTotalPrecios():C2}");
        Console.WriteLine($"4. Promedio de precios: {casoLinq.GetPromedioPrecios():C2}");

        Console.WriteLine("\n5. Libros con ID mayor a 15:");
        casoLinq.GetListById().ForEach(l => Console.WriteLine($"   ID: {l.Id} - {l.Titulo}"));

        Console.WriteLine("\n6. Lista proyectada (Título y precio formato moneda):");
        casoLinq.GetLibros().ForEach(linea => Console.WriteLine($"   {linea}"));

        Console.WriteLine($"\n7. Libro con precio más alto: {casoLinq.GetMayorPrecio()?.Titulo} ({casoLinq.GetMayorPrecio()?.Precio:C2})");
        Console.WriteLine($"8. Libro con precio más bajo: {casoLinq.GetMenorPrecio()?.Titulo} ({casoLinq.GetMenorPrecio()?.Precio:C2})");

        Console.WriteLine("\n9. Libros con precio superior al promedio:");
        casoLinq.GetMayorPromedio().ForEach(l => Console.WriteLine($"   {l.Titulo} (${l.Precio})"));

        Console.WriteLine("\n10. Libros ordenados por título descendente (Muestra de los primeros 5):");
        casoLinq.GetOrdenadosPorTituloDesc().Take(5).ToList().ForEach(l => Console.WriteLine($"   {l.Titulo}"));
    }
}


