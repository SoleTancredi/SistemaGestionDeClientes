using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDeClientes.dao
{
    internal class ClienteDao
    {
        public MySqlConnection Conectar()
        {
            string servidor ="localhost";
            string usuario = "root";
            string password = "";
            string baseDeDatos = "clientes";
            string puerto = "3307";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; User Id=" + usuario + "; Password=" + password + "; database=" + baseDeDatos + ";";

            MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);
            conexionDb.Open();

            return conexionDb;
        }

        public List<Cliente> ObtenerlistadoDeClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM `clientes`";
            MySqlCommand comando = new MySqlCommand(consulta, Conectar());
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();


            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = lectura.GetString("id");   
                cliente.Nombre = lectura.GetString("nombre");
                cliente.Apellido = lectura.GetString("apellido");
                cliente.Telefono = lectura.GetString("telefono");
                cliente.Tarjeta = lectura.GetString("tarjeta_de_credito");
                lista.Add(cliente);
            }
            comando.Connection.Close();

            return lista;
        }

        public void Guardar(Cliente cliente)
        {
            if(cliente.Id == null)
            {
                insert(cliente);
            }
            else
            {
                update(cliente);
            }

        }

        private void insert(Cliente cliente)
        {
            string consulta = "INSERT INTO `clientes` (`id`, `nombre`, `apellido`, `telefono`, `tarjeta_de_credito`) VALUES (NULL, '" + cliente.Nombre + "','" + cliente.Apellido + "', '" + cliente.Telefono + "', '" + cliente.Tarjeta + "')";
            MySqlCommand comando = new MySqlCommand(consulta, Conectar());
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close();

        }

        private void update(Cliente cliente)
        {
            string consulta = "UPDATE `clientes` SET `nombre` = '" + cliente.Nombre + "', `apellido` = '" + cliente.Apellido + "', `telefono` = '" + cliente.Telefono + "', `tarjeta_de_credito` = '" + cliente.Tarjeta + "' WHERE `clientes`.`id` = " + cliente.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta, Conectar());
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close();

        }

        public void Eliminar(Cliente cliente)
        {
            string consulta = "DELETE FROM clientes WHERE `clientes`.`id` = " + cliente.Id + " ;";
            MySqlCommand comando = new MySqlCommand(consulta, Conectar());
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close();

        }
    }
}
