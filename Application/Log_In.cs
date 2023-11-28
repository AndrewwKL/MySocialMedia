using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Log_In : User
    {
        private string password;
        private string alternativeEmail;

        public string e_mail
        {
            get { return email; }
            set { email = value; }
        }
        public string key
        {
            get { return password; }
            set { password = value; }
        }
        public string otherEmail
        {
            get { return alternativeEmail; }
            set { alternativeEmail = value; }
        }
        public Log_In(string nombreUsuario, string contrasena, string alternativeEmail)
        {
            email = nombreUsuario;
            password = contrasena;
            alternativeEmail = alternativeEmail;
        }

    }
}
