using System;
using System.Data.SqlClient;

namespace ADO
{
    /*
     *  Descripcion: Se Conectara a la BD Northwind y realizaremos unas consultas.
     *
     *  Autores: Alan Bocardo Garza
     *           Pedro Luis González Cernuda
     *
     */
    class AppNorthwind
    {
        /* Realiza la conexión a la BD Northwind.
         * Muestra el menú de opciones de la aplicación através del metodo OpcionMenu()
         * e invoca al método correspondiente para llevar a cabo
         * las acciones necesarias para cada opcion del menú
         */
        static void Main(string[] args)
        {
            //Conexion a base datos
            try
            {
                using (var conexion = new SqlConnection())
                {
                    conexion.ConnectionString =   //cadena de conexion
                                      @"Data Source=localhost;" +
                                      @"Initial Catalog=Northwind;Integrated Security=True";
                    ObtenOpcionMenu(conexion);  //Se llama a un metodo
                }  // automaticamente se cierra la conexion
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al abrir la base de datos: {e.Message}");
            }
            Console.ReadKey();

            //Ciclo para mostrar el menu y ejecutar las acciones de acuerdo
            //a la opcion seleccionada
        }

        /* Muestra el menú con el texto de opciones y regresa
         * la opcion seleccionada
         */
        private static void ObtenOpcionMenu(SqlConnection cn)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\tBase de datos Northwind\n\n");
                Console.WriteLine("Menu de opciones\n");

                Console.WriteLine("1. Lista de Proveedores");
                Console.WriteLine("2. Lista de Categorías");
                Console.WriteLine("3. Agrega Categoría");
                Console.WriteLine("4. Búsqueda de producto");
                Console.WriteLine("5. Salir");

                Console.WriteLine("Elige la opcion que deseeas\n\n");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        cn.Open();
                        ListaProveedores(cn);
                        Console.ReadKey();
                        cn.Close();
                        break;
                    case 2:
                        Console.Clear();
                        cn.Open();
                        ListaCategorias(cn);
                        Console.ReadKey();
                        cn.Close();
                        break;
                    case 3:
                        Console.Clear();
                        cn.Open();
                        AgregarCategoria(cn);
                        Console.ReadKey();
                        cn.Close();
                        break;
                    case 4:
                        Console.Clear();
                        cn.Open();
                        IdProducto(cn);
                        Console.ReadKey();
                        cn.Close();
                        break;
                    case 5:
                        Console.WriteLine("Presione una tecla para continuar");
                        break;
                    default:
                        Console.WriteLine($"Opción inválida, vuelva a elegir la opción correcta");
                        break;
                }
            } while (opcion != 5);
        }

        /*
         * Realiza la consulta a la base de datos para
         * mostrar a todos los proveedores, ordenándolos por pais
         */
        private static void ListaProveedores(SqlConnection cn)
        {
            var sql = new SqlCommand(  // se estrablece la consulta
                "SELECT SupplierID, ContactName, Country " +
                "FROM Suppliers " +
                "Order by Country", cn);

            SqlDataReader lector = sql.ExecuteReader();

            while (lector.Read())
            {
                //Se accede a los campos (columnas de la tabla) a través de un indexador por nombre del campo
                Console.WriteLine($"{lector["SupplierID"],5}  " +
                            $"{lector["ContactName"],-35}" +
                            $"{lector["Country"],-10}");
            }
            Console.WriteLine("\n\tConsulta terminada...\n");
        }

        /*
         * Realiza la consulta a la base de datos para mostrar
         * todas las categorias de productos
         */
        private static void ListaCategorias(SqlConnection cn)
        {
            var sql = new SqlCommand(
                "SELECT CategoryID, CategoryName, Description " +
                "FROM Categories", cn);

            SqlDataReader lector = sql.ExecuteReader();

            while (lector.Read())
            {
                //Se accede a los campos (columnas de la tabla) a través de un indexador por nombre del campo
                Console.WriteLine($"{lector["CategoryID"],5}  " +
                            $"{lector["CategoryName"],-35}" +
                            $"{lector["Description"],-10}");
            }

            Console.WriteLine("\n\tConsulta terminada...\n");
        }

        /*
         * Metodo para agregar una categoria
         */

        private static void AgregarCategoria(SqlConnection cn)
        {
            string nombreCategoria, descripcion;

            Console.WriteLine($"Inserte el nombre de la categoría nueva: ");
            nombreCategoria = Console.ReadLine();
            Console.WriteLine($"Inserte la descripción de la categoría nueva: ");
            descripcion = Console.ReadLine();
            var sql = new SqlCommand(
                "INSERT INTO Categories([CategoryName], [Description]) " +
                "VALUES(@nombreCategoria, @descripcion)", cn);
            sql.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);
            sql.Parameters.AddWithValue("@descripcion",descripcion);
            sql.ExecuteNonQuery();
            Console.WriteLine("Presione una tecla para continuar");
        }

        /*
         * Define un metodo para buscar un producto por su ID
         */
        private static void IdProducto(SqlConnection cn)
        {
            int id;
            Console.WriteLine($"Introduce el id del producto que quieres buscar: ");
            id = Convert.ToInt32(Console.ReadLine());

            var sql = new SqlCommand(  // se estrablece la consulta
                "SELECT ProductName, UnitPrice " +
                "FROM Products WHERE ProductID =" + id, cn); //En esta linea se pone el Id del producto que quiere buscar

            SqlDataReader lector = sql.ExecuteReader();

            while (lector.Read())
            {
                //Se accede a los campos (columnas de la tabla) a través de un indexador por nombre del campo
                Console.WriteLine($"{lector["ProductName"],5}  " +
                            $"{lector["UnitPrice"],-10}");
            }

            Console.WriteLine("\n\tConsulta terminada...\n");

        }

    }
}
