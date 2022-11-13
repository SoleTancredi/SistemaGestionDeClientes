using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDeClientes
{
    internal class Cliente
    {
        private string id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string tarjeta;

        public string Id { get; set; }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Telefono { get; set; }

        public string Tarjeta { get; set; }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
