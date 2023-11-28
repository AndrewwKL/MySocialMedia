using System.Text.RegularExpressions;

namespace Application
{
    public class Program
    {
        static List<User> usuarios = new List<User>();
        static List<Factura> facturas = new List<Factura>();
        static List<Log_In> sesion = new List<Log_In>();

        static void Main()
        {
            Console.WriteLine("Bienvenido a la Red Social Agrícola");

            while (true)
            {
                Console.WriteLine("\n1. Crear usuario");
                Console.WriteLine("2. Publicar producto");
                Console.WriteLine("3. Ver productos disponibles");
                Console.WriteLine("4. Ver carrito de compras");
                Console.WriteLine("5. Comprar productos");
                Console.WriteLine("6. Ver historial de facturas");
                Console.WriteLine("7. Ver ranking de vendedores");
                Console.WriteLine("8. Salir");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearUsuario();
                        break;
                    case 2:
                        PublicarProducto();
                        break;
                    case 3:
                        VerProductos();
                        break;
                    case 4:
                        VerCarrito();
                        break;
                    case 5:
                        ComprarProductos();
                        break;
                    case 6:
                        VerFacturas();
                        break;
                    case 7:
                        Console.WriteLine("Gracias por usar la Red Social Agrícola. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        static void CrearUsuario()
        {
            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese su apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese su correo electronico: ");
            string Email = null;
            while (Email == null)
            {
                Email = Console.ReadLine();
                if (EsCorreoElectronicoValido(Email))
                {
                    Console.WriteLine("La dirección de correo electrónico es válida.");
                }
                else
                {
                    Console.WriteLine("La dirección de correo electrónico no es válida.");
                    Email = null;
                }
                if (usuarios.Any(u => u.email == Email))
                {
                    Console.WriteLine("La dirección de correo electrónico ya esta asociado a una cuenta. Por favor, elija otro.");
                    return;
                }
            }
            string contrasena = null;
            while (contrasena == null)
            {
                Console.WriteLine("Inngrese una contraseña: ");
                Console.WriteLine("NOTA: Minimo 8 caracteres, maximo 12");
                contrasena = Console.ReadLine();
                if ((contrasena.Length <8) || (contrasena.Length > 12))
                {
                    contrasena = null;
                    Console.WriteLine("Funciona contraseña corta");
                }

            }
            Console.Write("Ingrese su latitud: ");
            double latitud = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese su longitud: ");
            double longitud = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese su correo electronico alternativo: ");
            string alternativeEmail = Console.ReadLine();
            Random random = new Random();
            int userId = random.Next(100, 100000);
            Console.Write("Ingrese su edad: ");
            int edad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese un nombre de usuario: ");
            string userName = Console.ReadLine();
            if (usuarios.Any(u => u.user == userName))
            {
                Console.WriteLine("El nombre de usuario ya existe. Por favor, elija otro.");
                return;
            }
            sesion.Add(new Log_In(userName, contrasena, alternativeEmail));
            Console.Write("Ingrese su numero de telefono: ");
            float phoneNumber = float.Parse(Console.ReadLine());
            Console.Write("Agregue una descripcion para su perfil: ");
            string descripcion = Console.ReadLine();
            Console.Write("Ingrese su numero de identificacion: ");
            float docNumber = float.Parse(Console.ReadLine());
            User nuevoUsuario = new User(nombre, apellido, Email, userId, edad, userName, phoneNumber, descripcion, docNumber, latitud, longitud);
            usuarios.Add(nuevoUsuario);
            Console.WriteLine($"Usuario {nombre} creado con éxito.");
            User user = new User();
        
            
        }
        static void PublicarProducto()
        {
            Console.Write("Ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();
            if (IniciarSesion(nombreUsuario)!)
            {
                Console.WriteLine("acceso invalido");
                return;
            }


            User usuario = usuarios.Find(u => u.user == nombreUsuario);

            if (usuario != null)
            {
                Console.Write("Nombre del producto: ");
                string nombreProducto = Console.ReadLine();
                Console.Write("Precio del producto: ");
                double precio = Convert.ToDouble(Console.ReadLine());
                Console.Write("Seleccione la categoría del producto (Lácteos, Ganadería, Verduras, etc.): ");
                string categoria = Console.ReadLine();
                Console.Write("Ingrese su latitud: ");
                double latitud = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ingrese su longitud: ");
                double longitud = Convert.ToDouble(Console.ReadLine());
                Product nuevoProducto = new Product(nombreProducto, precio, categoria,latitud,longitud );
                usuario.productos.Add(nuevoProducto);

                Console.WriteLine($"Producto {nombreProducto} publicado con éxito por {nombreUsuario}.");
            }
            else
            {
                Console.WriteLine($"Usuario {nombreUsuario} no encontrado. Por favor, cree un usuario primero.");
            }
        }
        static double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radio de la Tierra en kilómetros

            // Convierte las latitudes y longitudes de grados a radianes
            lat1 = ToRadians(lat1);
            lon1 = ToRadians(lon1);
            lat2 = ToRadians(lat2);
            lon2 = ToRadians(lon2);

            // Calcula la diferencia entre las latitudes y longitudes
            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            // Fórmula de Haversine para calcular la distancia entre dos puntos en la superficie de una esfera
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Distancia en kilómetros
            double distancia = R * c;

            return distancia;
        }

        static double ToRadians(double grados)
        {
            return grados * (Math.PI / 180);
        }

        static void VerProductos()
        {
            Console.Write("Ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            User usuario = usuarios.Find(u => u.user == nombreUsuario);

            if (usuario != null)
            {
                Console.WriteLine($"\nProductos disponibles para {nombreUsuario}:");

                var productosOrdenadosPorDistancia = usuario.productos.OrderBy(p => CalcularDistancia(usuario.Latitude, usuario.Longitude, p.Latitude, p.Longitude));

                foreach (Product producto in productosOrdenadosPorDistancia)
                {
                    Console.WriteLine($"Producto: {producto.NameProduct}, Precio: {producto.CostProduct}, Categoría: {producto.productCategory}, Distancia: {CalcularDistancia(usuario.Latitude, usuario.Longitude, producto.Latitude, producto.Longitude)} km");
                }
            }
            else
            {
                Console.WriteLine($"Usuario {nombreUsuario} no encontrado.");
            }
        }
        static void VerCarrito()
        {
            Console.Write("Ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            User usuario = usuarios.Find(u => u.user == nombreUsuario);

            if (usuario != null)
            {
                Console.WriteLine($"\nCarrito de compras de {nombreUsuario}:");

                if (usuario.carrito.Count > 0)
                {
                    foreach (Product producto in usuario.carrito)
                    {
                        Console.WriteLine($"Producto: {producto.NameProduct}, Precio: {producto.CostProduct}");
                    }
                }
                else
                {
                    Console.WriteLine("El carrito está vacío.");
                }
            }
            else
            {
                Console.WriteLine($"Usuario {nombreUsuario} no encontrado.");
            }
        }
        static void ComprarProductos()
        {
            Console.Write("Ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            User usuario = usuarios.Find(u => u.user == nombreUsuario);

            if (usuario != null)
            {
                if (usuario.carrito.Count > 0)
                {
                    Factura factura = new Factura(usuario, usuario.carrito);
                    facturas.Add(factura);

                    Console.WriteLine("Compra realizada con éxito. ¡Gracias por su compra!");
                    factura.MostrarFactura();

                    usuario.carrito.Clear(); // Limpiar el carrito después de la compra.
                }
                else
                {
                    Console.WriteLine("El carrito está vacío. Añada productos al carrito antes de comprar.");
                }
            }
            else
            {
                Console.WriteLine($"Usuario {nombreUsuario} no encontrado.");
            }
        }
        static void VerFacturas()
        {
            Console.WriteLine("\nHistorial de facturas:");

            foreach (Factura factura in facturas)
            {
                factura.MostrarFactura();
            }
        }
        static bool EsCorreoElectronicoValido(string email)
        {
            // Patrón de expresión regular para validar direcciones de correo electrónico
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Usar Regex.IsMatch para verificar si la cadena cumple con el patrón
            return Regex.IsMatch(email, patron);
        }
        static Boolean IniciarSesion(string nombreUsuario)
        {

            Console.Write("Ingrese su contraseña: ");
            string contrasena = Console.ReadLine();

            Log_In usuario = sesion.FirstOrDefault(u => u.user == nombreUsuario && u.key == contrasena);

            if (usuario != null)
            {
                Console.WriteLine($"Inicio de sesión exitoso. ¡Bienvenido, {usuario.email}!");
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}