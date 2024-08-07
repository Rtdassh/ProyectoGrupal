using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;

namespace GrupalProyecto
{
    internal class Libro
    {
        public static int contadorID = 1;
        public static List<Libro> listadoLibros = new List<Libro>();
        public string Name { get; set; }
        public string ID { get;  set; }
        public int Stock { get; set; }

        public Libro(string name, string id, int stock)
        {
            Name = name;
            ID = id;
            Stock = stock;
        }

        public static void AgregarLibro()
        {
            Console.WriteLine("Ingrese el nombre del título:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Ingrese el stock del título:");
            int stock;
            while (!int.TryParse(Console.ReadLine(), out stock))
            {
                Console.WriteLine("Por favor, ingrese un número válido para el stock:");
            }

            Libro nuevoLibro = new Libro(name, NuevoID(), stock);
            listadoLibros.Add(nuevoLibro);
            Console.WriteLine($"Libro '{name}' agregado con ID: {nuevoLibro.ID}");
        }

        private static string NuevoID()
        {
            contadorID++;
            return "A" + contadorID;
        }

        public static bool Eliminar(string id)
        {
            Libro? libro = listadoLibros.Find(l => l.ID == id);
            if (libro != null)
            {
                listadoLibros.Remove(libro);
                Console.WriteLine($"Libro con ID: {id} eliminado.");
                return true;
            }
            Console.WriteLine($"No se encontró un libro con ID: {id}.");
            return false;
        }

        public static bool Modificar()
        {
            Console.WriteLine("Ingrese el ID del libro a modificar:");
            string id = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo stock del libro:");
            int nuevoStock = Convert.ToInt32(Console.ReadLine() ?? "");

            Libro? libro = listadoLibros.Find(l => l.ID == id);
            if (libro != null)
            {
                libro.Stock = nuevoStock;
                Console.WriteLine($"Libro con ID: {id} modificado.");
                return true;
            }
            Console.WriteLine($"No se encontró un libro con ID: {id}.");
            return false;
        }
        public static void MostrarLibros()
        {
            Console.WriteLine("Listado de libros:");
            foreach (var libro in listadoLibros)
            {
                Console.WriteLine($"ID: {libro.ID}, Nombre: {libro.Name}, Stock: {libro.Stock}");
            }
        }
        public static void OptionSwitch()
        {
            switch (Menu())
            {
                case 1:
                    Libro.AgregarLibro();
                    break;
                case 2:
                    Modificar();

                    break;
                case 3:
                    Console.WriteLine("Ingrese el ID del libro a eliminar:");
                    string idEliminar = Console.ReadLine() ?? "";
                    Libro.Eliminar(idEliminar);
                    break;
                case 4:
                    Libro.MostrarLibros();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.ReadKey();
        }

        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Biblioteca Landivar");
            Console.WriteLine("1. Ingresar un libro");
            Console.WriteLine("2. Actualizar stock de un libro");
            Console.WriteLine("3. Eliminar libro");
            Console.WriteLine("4. Mostrar todos los libros");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese una opción: ");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Opción no válida. Por favor, ingrese un número entre 1 y 5.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Ingrese una opción: ");
            }
            Console.Clear();
            return option;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            bool menu = true;
            List<Libro> listadoLibros = new List<Libro>();

            while (menu)
            {
                try
                {
                    Libro.OptionSwitch();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
            }
        }
    }
}