using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP3
{
    public partial class form_menuPrincipal : Form
    {
        public RichTextBox richTextBoxLibros;
        public RichTextBox richTextBoxClientes;
        public Libreria libreria;
        public List<Libro> listaDeLibros;
        public List<Cliente> listaDeClientes;

        public form_menuPrincipal()
        {
            InitializeComponent();
            this.libreria = new Libreria();
            this.richTextBoxLibros = this.rtb_libros;
            this.richTextBoxClientes = this.rtb_clientes;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.listaDeLibros = SerializadorJson<List<Libro>>.Leer("Serializado_Libros");
                this.listaDeClientes = SerializadorJson<List<Cliente>>.Leer("Serializado_Clientes");

                if (this.listaDeLibros != null)
                {   
                    foreach (Libro item in this.listaDeLibros)
                    {
                        this.rtb_libros.AppendText(item.ToString());
                    }

                    this.libreria.ListaLibros = this.listaDeLibros;
                }

                if (this.listaDeClientes != null)
                {
                    foreach (Cliente item in this.listaDeClientes)
                    {
                        this.rtb_clientes.AppendText(item.ToString());
                    }

                    this.libreria.ListaClientes = this.listaDeClientes;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un problema al cargar el archivo", "Error: carga de archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            SerializadorJson<List<Libro>>.Escribir(this.libreria.ListaLibros, "Serializado_Libros");
            SerializadorJson<List<Cliente>>.Escribir(this.libreria.ListaClientes, "Serializado_Clientes");
            this.Close();
        }

        private void btn_agregarLibro_Click(object sender, EventArgs e)
        {
            form_agregarModificarLibro formAgregarLibro = new form_agregarModificarLibro(this);
            formAgregarLibro.ShowDialog();
        }

        private void btn_modificarLibro_Click(object sender, EventArgs e)
        {
            if (this.libreria.ListaLibros.Count > 0)
            {
                form_ingresarCodigo formCodigo = new form_ingresarCodigo(this, EOpcionLibro.Modificar);
                formCodigo.ShowDialog();
            }
            else
            {
                MessageBox.Show("No es posible modificar libros porque no hay ninguno", "No hay libros", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btn_eliminarLibro_Click(object sender, EventArgs e)
        {
            if (this.libreria.ListaLibros.Count > 0)
            {
                form_ingresarCodigo formCodigo = new form_ingresarCodigo(this, EOpcionLibro.Eliminar);
                formCodigo.ShowDialog();
            }
            else
            {
                MessageBox.Show("No es posible eliminar libros porque no hay ninguno", "No hay libros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_agregarCliente_Click(object sender, EventArgs e)
        {
            form_agregarModificarCliente formAgregarCliente = new form_agregarModificarCliente(this);
            formAgregarCliente.ShowDialog();
        }

        private void btn_modificarCliente_Click(object sender, EventArgs e)
        {
            form_ingresarDni formDni = new form_ingresarDni(this, EOpcionCliente.Modificar);
            formDni.ShowDialog();
        }

        private void btn_generarCompra_Click(object sender, EventArgs e)
        {
            form_ingresarDni formDni = new form_ingresarDni(this, EOpcionCliente.GenerarCompra);
            formDni.ShowDialog();
        }

        public bool EsTexto(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                return false;
            }
            return true;
        }

        public bool EsNumero(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                return true;
            }
            return false;
        }
    }
}
