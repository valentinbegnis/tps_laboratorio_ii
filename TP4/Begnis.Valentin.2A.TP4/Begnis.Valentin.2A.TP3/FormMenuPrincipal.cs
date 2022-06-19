using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    public partial class form_menuPrincipal : Form
    {
        public RichTextBox richTextBoxLibros;
        public RichTextBox richTextBoxClientes;
        public Libreria libreria;
        public List<Libro> listaDeLibros;
        public List<Cliente> listaDeClientes;

        public delegate int DelegadoOrdenarAlfabeticamente(string x, string y);
        public delegate int DelegadoOrdenarMenorAMayor(float x, float y);

        DelegadoOrdenarAlfabeticamente delegadoOrdenarAlfabeticamente = CriterioOrdenamiento.OrdenarAlfabeticamente;
        DelegadoOrdenarMenorAMayor delegadoOrdenarMenorAMayor = CriterioOrdenamiento.OrdenarMenorAMayor;

        public form_menuPrincipal()
        {
            InitializeComponent();
            this.libreria = new Libreria();
            this.richTextBoxLibros = this.rtb_libros;
            this.richTextBoxClientes = this.rtb_clientes;
        }

        private void form_menuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Task cargarLibrosSQL = Task.Run(TareaCargarLibros); // TODO : 1 - Creo que esto no va en el Load
                Task cargarClientesJson = Task.Run(TareaCargaClientes);

                Task.WaitAll(cargarLibrosSQL, cargarClientesJson);

                this.ActualizarListaEnRichTextBox(this.listaDeLibros, this.rtb_libros);
                this.ActualizarListaEnRichTextBox(this.listaDeClientes, this.rtb_clientes);

                this.libreria.ListaLibros = this.listaDeLibros;
                this.libreria.ListaClientes = this.listaDeClientes;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un problema al cargar el archivo", "Error: carga de archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void TareaCargarLibros()
        {
            ConexionBD conexion = new ConexionBD();
            this.listaDeLibros = conexion.ObtenerListaLibros();
        }

        public void TareaCargaClientes()
        {
            this.listaDeClientes = SerializadorJson<List<Cliente>>.Leer("Serializado_Clientes");
        }

        public void ActualizarListaEnRichTextBox<T>(List<T> lista, RichTextBox richTextBox)
        {
            if (lista != null)
            {
                richTextBox.Text = "";

                foreach (T item in lista)
                {
                    richTextBox.AppendText(item.ToString());
                }
            }
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
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

        private void porAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listaDeLibros.Sort((x, y) => delegadoOrdenarAlfabeticamente(x.Autor, y.Autor));
            this.ActualizarListaEnRichTextBox(this.listaDeLibros, this.rtb_libros);
        }

        private void porTituloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listaDeLibros.Sort((x, y) => delegadoOrdenarAlfabeticamente(x.Titulo, y.Titulo));
            this.ActualizarListaEnRichTextBox(this.listaDeLibros, this.rtb_libros);
        }

        private void porPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listaDeLibros.Sort((x, y) => delegadoOrdenarMenorAMayor(x.Precio, y.Precio));
            this.ActualizarListaEnRichTextBox(this.listaDeLibros, this.rtb_libros);
        }
    }
}
