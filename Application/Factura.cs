using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Factura
    {
        private User Comprador;
        private List<Product> ProductosComprados;
        private double Total;

        public Factura(User comprador, List<Product> productosComprados)
        {
            Comprador = comprador;
            ProductosComprados = productosComprados;
            Total = productosComprados.Sum(p => p.CostProduct);
        }

        public void MostrarFactura()
        {
            Console.WriteLine("\n----- Factura -----");
            Console.WriteLine($"Comprador: {Comprador.firstName}{""+Comprador.lastName}");
            Console.WriteLine("Productos comprados:");

            foreach (Product producto in ProductosComprados)
            {
                Console.WriteLine($"- {producto.NameProduct}, Precio: {producto.CostProduct}");
            }

            Console.WriteLine($"Total: {Total}");
            Console.WriteLine("--------------------");
        }
    }
}
