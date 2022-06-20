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
    public partial class form_ingresarCodigo : Form, IValidadorDeCampos
    {
        form_menuPrincipal formMenuPrincipal;
        EOpcionLibro opcion;

        public form_ingresarCodigo(form_menuPrincipal formMenuPrincipal, EOpcionLibro opcion)
        {
            InitializeComponent();
            this.formMenuPrincipal = formMenuPrincipal;
            this.opcion = opcion;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();

            try
            {
                ((IValidadorDeCampos)this).ValidarCamposVacios();

                int codigo = int.Parse(this.tb_codigo.Text);
                Libro libroEncontrado = default;

                if (((IValidadorDeCampos)this).ValidarCantidadNumeros())
                {
                    foreach (Libro item in this.formMenuPrincipal.libreria.ListaLibros)
                    {
                        if (item.Codigo == codigo)
                        {
                            libroEncontrado = item;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El código debe ser de 4 dígitos", "Error: Formato código", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (libroEncontrado is not null && this.opcion == EOpcionLibro.Modificar)
                {
                    this.tb_codigo.BackColor = Color.White;

                    form_agregarModificarLibro formModificarLibro = new form_agregarModificarLibro(this.formMenuPrincipal, libroEncontrado);

                    formModificarLibro.Owner = this;
                    formModificarLibro.ShowDialog();
                }
                else if (libroEncontrado is not null && this.opcion == EOpcionLibro.Eliminar)
                {
                    this.formMenuPrincipal.libreria.ListaLibros.Remove(libroEncontrado);

                    this.formMenuPrincipal.ActualizarListaEnRichTextBox(this.formMenuPrincipal.libreria.ListaLibros, this.formMenuPrincipal.richTextBoxLibros);

                    try
                    {
                        if (conexion.ProbarConexion())
                        {
                            conexion.EliminarLibro(libroEncontrado.Codigo);
                        }
                        else
                        {
                            SerializadorJson<List<Libro>>.Escribir(this.formMenuPrincipal.listaDeLibros, "Serializado_Libros");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error: Eliminar en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();
                }
                else
                {
                    this.tb_codigo.BackColor = Color.DarkSalmon;
                }
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error: Campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo realizar la búsqueda del libro por su código", "Error: búsqueda cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IValidadorDeCampos.ValidarCamposVacios()
        {
            if (this.tb_codigo.Text == String.Empty)
            {
                throw new CampoVacioException("Debes completar este campo para continuar");
            }
        }

        bool IValidadorDeCampos.ValidarCantidadNumeros()
        {
            return this.tb_codigo.Text.Length == 4 ? true : false;
        }

        private void tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }
    }
}
