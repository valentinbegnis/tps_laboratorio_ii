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

namespace TP3
{
    public partial class form_ingresarDni : Form, IValidadorDeCampos
    {
        form_menuPrincipal formMenuPrincipal;
        EOpcionCliente opcion;

        public form_ingresarDni(form_menuPrincipal formMenuPrincipal, EOpcionCliente opcion)
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
            try
            {
                ((IValidadorDeCampos)this).ValidarCamposVacios();

                int dni = int.Parse(this.tb_dni.Text);
                Cliente clienteEncontrado = default;

                if (((IValidadorDeCampos)this).ValidarCantidadNumeros())
                {
                    foreach (Cliente item in this.formMenuPrincipal.libreria.ListaClientes)
                    {
                        if (item.Dni == dni)
                        {
                            clienteEncontrado = item;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El DNI debe ser de 8 dígitos", "Error: formato DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (clienteEncontrado is not null && this.opcion == EOpcionCliente.Modificar)
                {
                    this.tb_dni.BackColor = Color.White;

                    form_agregarModificarCliente formModificarCliente = new form_agregarModificarCliente(this.formMenuPrincipal, clienteEncontrado);

                    formModificarCliente.Owner = this;
                    formModificarCliente.ShowDialog();
                }
                else if (clienteEncontrado is not null && this.opcion == EOpcionCliente.GenerarCompra)
                {
                    form_comprarLibro formCompraLibros = new form_comprarLibro(this.formMenuPrincipal, clienteEncontrado);

                    formCompraLibros.Owner = this;
                    formCompraLibros.ShowDialog();
                }
                else
                {
                    this.tb_dni.BackColor = Color.DarkSalmon;
                }
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error: Campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema al buscar este cliente por DNI", "Error: Búsqueda cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IValidadorDeCampos.ValidarCamposVacios()
        {
            if (this.tb_dni.Text == String.Empty)
            {
                throw new CampoVacioException("Debes completar este campo para continuar");
            }
        }

        bool IValidadorDeCampos.ValidarCantidadNumeros()
        {
            return this.tb_dni.Text.Length == 8 ? true : false;
        }

        private void tb_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }
    }
}
