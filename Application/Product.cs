using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Product
    {
        private string Name;
        private double Cost;
        private string Category;
        private double Latitud;
        private double Longitud;

        public Product(string nombre, double precio, string category, double latitud, double longitud)
        {
            NameProduct = nombre;
            CostProduct = precio;
            Category = category;
            Latitude = latitud;
            Longitude = longitud;
        }

        public string NameProduct
        {
            get { return Name; }
            set { Name = value; }
        }
        public double CostProduct
        {
            get { return Cost; }
            set { Cost = value; }
        }
        public string productCategory
        {
            get { return Category; }
            set { Category = value; }
        }
        public double Latitude
        {
            get { return Latitud; }
            set { Latitud = value; }
        }
        public double Longitude
        {
            get { return Longitud; }
            set { Longitud = value; }
        }
    }
}
