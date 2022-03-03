using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static System.Console;

/*
 * Programa que define varios tipos de colecciones para
 * aplicar LINQ como lenguaje de consulta para mostrar en pantalla:
 * 
 * 1) Numeros impares
 * 2) Calificaciones aprobatorias (de 7 a 10) ordenadas en forma ascendente
 * 3) Nombres que empiezan con una cadena leida, en orden descendiente
 * 4) Inner Join entre Compras y Productos
 * 5) Cantidad de calificaciones excelentes (9s y 10s)
 * 
 *  Autor: David Jimenez
 *  Alumno(s):
 */

namespace LINQ_Practica
{
    class Consultas
    {
        //Definicion de Colecciones
        int[] nums = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int[] calificaciones = { 5, 9, 7, 8, 6, 9, 5, 7, 7, 4, 6, 10, 8 };
        string[] nombres = { "JOEL", "CARLOS", "MARLEN", "JAVIER", "JOSE", "CARMEN", "MARCOS", "LUIS", "JORGE", "MARIA" };
        List<Producto> productos = new List<Producto>();
        List<Compra> compras = new List<Compra>();


        static void Main(string[] args)
        {
            WriteLine("\tEJEMPLOS DE CONSULTAS LINQ\n");
            Consultas app = new Consultas();
            app.Consulta1();
            WriteLine();
            app.Consulta2();
            WriteLine();
            app.Consulta3();
            WriteLine();
            app.CargaListas();
            WriteLine();
            app.Consulta4();
            WriteLine();
            app.Consulta5();
        }

        //1) Numeros impares
        public void Consulta1()
        {
            WriteLine("-- Numeros impares\n");

        }

        //2) Calificaciones aprobatorias (de 7 a 10) ordenadas en forma ascendente
        public void Consulta2()
        {
            WriteLine("-- Calificaciones aprobatorias\n");

        }

        //3) Nombre que empieza con una cadena en orden descendiente
        public void Consulta3()
        {
            WriteLine("-- Nombres que empiezan con una cadena\n");

        }
        
        //4) Inner Join entre Compras y Productos
        //   para mostrar:  IdCompra   Descripcion del producto  Cantidad
        //   ordenados por Cantidad en forma ascendente  
        public void Consulta4()
        {
            WriteLine("-- Inner Join Compra-Productos\n");

        }

        //5) Cantidad de calificaciones excelentes(9s y 10s)
        public void Consulta5()
        {
            WriteLine("-- Calificaciones Excelentes\n");
        }

        //Agrega objetos a las listas
        public void CargaListas()
        {
            productos.Add(new Producto { IdProd = 1, Descripcion = "Mouse" });
            productos.Add(new Producto { IdProd = 2, Descripcion = "Keyboard" });
            productos.Add(new Producto { IdProd = 3, Descripcion = "RAM 4G" });
            productos.Add(new Producto { IdProd = 4, Descripcion = "HD 500GB" });
            productos.Add(new Producto { IdProd = 5, Descripcion = "Cam Web" });

            compras.Add(new Compra { IdCompra = 100, IdProd = 3, Cantidad = 5 });
            compras.Add(new Compra { IdCompra = 101, IdProd = 2, Cantidad = 10 });
            compras.Add(new Compra { IdCompra = 102, IdProd = 1, Cantidad = 9 });
            compras.Add(new Compra { IdCompra = 103, IdProd = 5, Cantidad = 12 });
            compras.Add(new Compra { IdCompra = 104, IdProd = 4, Cantidad = 10 });
            compras.Add(new Compra { IdCompra = 105, IdProd = 2, Cantidad = 6 });
        }


        public class Producto
        {
            public int IdProd { get; set; }
            public string Descripcion { get; set; }
        }

        public class Compra
        {
            public int IdCompra { get; set; }
            public int IdProd { get; set; }
            public int Cantidad { get; set; }
        }
    }
}