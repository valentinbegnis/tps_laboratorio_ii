using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    public partial class form_agregarModificarLibro : Form, IValidadorDeCampos
    {
        private form_menuPrincipal formMenuPrincipal;
        private Libro libro;

        public form_agregarModificarLibro(form_menuPrincipal formMenuPrincipal, Libro libro)
            : this(formMenuPrincipal)
        {
            this.libro = libro;
        }

        public form_agregarModificarLibro(form_menuPrincipal formMenuPrincipal)
        {
            InitializeComponent();
            this.formMenuPrincipal = formMenuPrincipal;
        }

        private void FormAgregarModificarLibro_Load(object sender, EventArgs e)
        {
            if (this.libro is not null)
            {
                this.CargarDatosDeLibro(this.libro);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();

            try
            {
                ((IValidadorDeCampos)this).ValidarCamposVacios();

                string titulo = this.tb_titulo.Text;
                string autor = this.tb_autor.Text;
                string genero = this.cb_genero.Text;
                int cantidadPaginas = int.Parse(this.tb_cantidadPaginas.Text);
                int codigo = int.Parse(this.tb_codigo.Text);
                float precio = float.Parse(this.tb_precio.Text);

                EGenero generoLibro = default;
                switch (genero)
                {
                    case "Ficcion":
                        generoLibro = EGenero.Ficcion;
                        break;
                    case "No-ficcion":
                        generoLibro = EGenero.No_Ficcion;
                        break;
                }

                if (((IValidadorDeCampos)this).ValidarCantidadNumeros())
                {
                    if (this.libro is not null)
                    {
                        this.libro.Titulo = titulo;
                        this.libro.Autor = autor;
                        this.libro.Genero = generoLibro;
                        this.libro.CantidadPaginas = cantidadPaginas;
                        this.libro.Codigo = codigo;
                        this.libro.Precio = precio;

                        this.formMenuPrincipal.ActualizarListaEnRichTextBox(this.formMenuPrincipal.libreria.ListaLibros, this.formMenuPrincipal.richTextBoxLibros);

                        try
                        {
                            conexion.ModificarLibro(this.libro); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error: Modificar en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.Close();
                        this.Owner.Close();
                    }
                    else
                    {
                        Libro lib = new Libro(titulo, autor, generoLibro, cantidadPaginas, codigo, precio);

                        bool agregarLibro = this.formMenuPrincipal.libreria + lib;

                        if (agregarLibro)
                        {
                            try
                            {
                                conexion.AgregarLibro(lib);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error: Carga en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            this.formMenuPrincipal.richTextBoxLibros.AppendText(lib.ToString());
                            this.Close();
                        }
                        else
                        {
                            throw new LibroExistenteException($"Ya existe un libro con el código {codigo} en la librería");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Verifique la cantidad de números para el código (4) y/o páginas (máximo 4 cifras)", "Error: formato código/cantidad de páginas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LibroExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error: Libro existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema al agregar/modificar este libro", "Error: Fallo en Alta/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDeLibro(Libro libro)
        {
            this.tb_titulo.Text = libro.Titulo;
            this.tb_autor.Text = libro.Autor;

            if (libro.Genero.ToString() == "Ficcion")
            {
                this.cb_genero.Text = "Ficcion";
            }
            else
            {
                this.cb_genero.Text = "No-ficcion";
            }

            this.tb_cantidadPaginas.Text = libro.CantidadPaginas.ToString();
            this.tb_codigo.Text = libro.Codigo.ToString();
            this.tb_precio.Text = libro.Precio.ToString();

            this.tb_codigo.Enabled = false;
        }

        void IValidadorDeCampos.ValidarCamposVacios()
        {
            if (this.tb_titulo.Text == String.Empty ||
                this.tb_autor.Text == String.Empty ||
                this.cb_genero.Text == String.Empty ||
                this.tb_cantidadPaginas.Text == String.Empty ||
                this.tb_codigo.Text == String.Empty ||
                this.tb_precio.Text == String.Empty)
            {
                throw new CampoVacioException("Debes completar todos los campos para continuar");
            }
        }

        bool IValidadorDeCampos.ValidarCantidadNumeros()
        {
            if (this.tb_codigo.Text.Length == 4 && this.tb_cantidadPaginas.Text.Length >= 2 && this.tb_cantidadPaginas.Text.Length <= 4)
            {
                return true;
            }
            return false;
        }

        private void tb_cantidadPaginas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }

        private void tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }

        private void tb_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }

        private void tb_autor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsTexto(e);
        }
    }
}
