using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class User
    {
        private string FirstName;
        private string LastName;
        private string Email;
        private int Id;
        private int Age;
        private string UserName;
        private float PhoneNumber;
        private string Description;
        private float Dni;
        private double Latitud;
        private double Longitud;
        private List<Product> Productos;
        private List<Product> Carrito;

        public User() { }
        public User(string nombre, string apellido, string E_mail, int identificationNumber, int edad, string userName, float number, string descripcion, float docNumber, double latitud, double longitud)
        {
            firstName = nombre;
            lastName = apellido;
            email = E_mail;
            id = identificationNumber;
            age = edad;
            user = userName;
            PhoneNumber = number;
            Description = descripcion;
            Dni = docNumber;
            productos = new List<Product>();
            carrito = new List<Product>();
            Longitude= longitud; 
            Latitude= latitud;
        }

        public string firstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        public int age
        {
            get { return Age; }
            set { Age = value; }
        }
        public string user
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public float phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public float dniNumber
        {
            get { return Dni; }
            set { Dni = value; }
        }
        public List<Product> productos
        {
            get { return Productos; }
            set { Productos = value; }
        }
        public List<Product> carrito
        {
            get { return Carrito; }
            set { Carrito = value; }
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
