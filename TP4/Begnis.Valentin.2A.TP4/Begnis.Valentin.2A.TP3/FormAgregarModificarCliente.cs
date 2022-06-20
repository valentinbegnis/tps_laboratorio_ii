using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    public partial class form_agregarModificarCliente : Form, IValidadorDeCampos
    {
        private form_menuPrincipal formMenuPrincipal;
        private Cliente cliente;

        public form_agregarModificarCliente(form_menuPrincipal formMenuPrincipal, Cliente cliente)
            : this(formMenuPrincipal)
        {
            this.cliente = cliente;
        }

        public form_agregarModificarCliente(form_menuPrincipal formMenuPrincipal)
        {
            InitializeComponent();
            this.formMenuPrincipal = formMenuPrincipal;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAgregarModificarCliente_Load(object sender, EventArgs e)
        {
            if (this.cliente is not null)
            {
                this.CargarDatosDeCliente(this.cliente);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ((IValidadorDeCampos)this).ValidarCamposVacios();

                string nombre = this.tb_nombre.Text;
                string apellido = this.tb_apellido.Text;
                int dni = int.Parse(this.tb_dni.Text);
                double telefono = double.Parse(this.tb_telefono.Text);
                string email = this.tb_email.Text;

                bool emailValido = this.EmailValido(email);

                if (((IValidadorDeCampos)this).ValidarCantidadNumeros() && emailValido)
                {
                    if (this.cliente is not null)
                    {
                        this.cliente.Nombre = nombre;
                        this.cliente.Apellido = apellido;
                        this.cliente.Dni = dni;
                        this.cliente.Telefono = telefono;
                        this.cliente.Email = email;

                        this.formMenuPrincipal.ActualizarListaEnRichTextBox(this.formMenuPrincipal.libreria.ListaClientes, this.formMenuPrincipal.richTextBoxClientes);

                        this.Close();
                        this.Owner.Close();
                    }
                    else
                    {
                        Cliente cli = new Cliente(nombre, apellido, dni, telefono, email);

                        bool agregarCliente = this.formMenuPrincipal.libreria + cli;

                        if (agregarCliente)
                        {
                            this.formMenuPrincipal.richTextBoxClientes.AppendText(cli.ToString());
                            this.Close();
                        }
                        else
                        {
                            throw new ClienteExistenteException($"Ya existe un cliente con el DNI {dni} registrado");
                        }
                    }
                }
                else
                {
                    if (emailValido)
                    {
                        MessageBox.Show("Verifique la cantidad de números para el telefono (10) y/o DNI (8)", "Error: Formato telefono y/o DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Verifique el mail ingresado", "Error: Formato mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ClienteExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error: Cliente existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema al agregar/modificar este cliente", "Error: Fallo en Alta/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDeCliente(Cliente cliente)
        {
            this.tb_nombre.Text = cliente.Nombre;
            this.tb_apellido.Text = cliente.Apellido;
            this.tb_dni.Text = cliente.Dni.ToString();
            this.tb_telefono.Text = cliente.Telefono.ToString();
            this.tb_email.Text = cliente.Email.ToString();
        }

        private bool EmailValido(string email)
        {
            try
            {
                MailAddress validadorEmail = new MailAddress(email);

                return email.LastIndexOf(".") > email.LastIndexOf("@");
            }
            catch
            {
                return false;
            }
        }

        void IValidadorDeCampos.ValidarCamposVacios()
        {
            if (this.tb_nombre.Text == String.Empty ||
                this.tb_apellido.Text == String.Empty ||
                this.tb_email.Text == String.Empty ||
                this.tb_dni.Text == String.Empty ||
                this.tb_telefono.Text == String.Empty)
            {
                throw new CampoVacioException("Debes completar todos los campos para continuar");
            }
        }

        bool IValidadorDeCampos.ValidarCantidadNumeros()
        {
            if (this.tb_dni.Text.Length == 8 && this.tb_telefono.Text.Length == 10)
            {
                return true;
            }
            return false;
        }

        private void tb_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }

        private void tb_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsNumero(e);
        }

        private void tb_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsTexto(e);
        }

        private void tb_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.formMenuPrincipal.EsTexto(e);
        }
    }
}
