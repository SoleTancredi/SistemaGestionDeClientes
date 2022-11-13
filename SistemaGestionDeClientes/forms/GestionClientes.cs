using SistemaGestionDeClientes.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionDeClientes
{
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            //se va a ejecutar esta funcion load cuando se halla cargado el programa
            renderizarLista();

        }

        private void renderizarLista()
        {
            ClienteDao baseDeDatos = new ClienteDao();
            List<Cliente> listado = baseDeDatos.ObtenerlistadoDeClientes();

            //limpio el lustado visible
            listadoClientes.Items.Clear();

            for(int i = 0; i < listado.Count; i++)
            {
                Cliente cliente = listado[i];
                listadoClientes.Items.Add(cliente); 
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = txtNombre.Text;    
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;    
            cliente.Tarjeta = txtTarjetaCredito.Text;

            if(lblID.Text != "")
            {
                cliente.Id = lblID.Text;
            }

            ClienteDao baseDeDatos = new ClienteDao();
            baseDeDatos.Guardar(cliente);
            renderizarLista();
            limpiarListado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listadoClientes.SelectedItem;

            ClienteDao baseDeDatos = new ClienteDao();
            baseDeDatos.Eliminar(cliente);
            renderizarLista();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listadoClientes.SelectedItem;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            txtTarjetaCredito.Text = cliente.Tarjeta;
            lblID.Text = cliente.Id;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            limpiarListado();

        }

        private void limpiarListado()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtTarjetaCredito.Text = "";
        }
    }
}
