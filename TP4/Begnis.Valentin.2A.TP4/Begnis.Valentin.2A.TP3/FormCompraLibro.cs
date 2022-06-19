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
    public partial class form_comprarLibro : Form
    {
        form_menuPrincipal formMenuPrincipal;
        Cliente cliente;

        public form_comprarLibro(form_menuPrincipal formMenuPrincipal, Cliente cliente)
        {
            InitializeComponent();
            this.formMenuPrincipal = formMenuPrincipal;
            this.cliente = cliente;
        }

        private void FormCompraLibros_Load(object sender, EventArgs e)
        {
            foreach (Libro item in this.formMenuPrincipal.libreria.ListaLibros)
            {
                this.lbx_listaLibros.Items.Add($"{item.Titulo}, {item.Autor} - ${item.Precio}");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_comprar_Click(object sender, EventArgs e)
        {
            int index = this.lbx_listaLibros.SelectedIndex;

            if (index >= 0)
            {
                Libro libroComprado = this.formMenuPrincipal.libreria.ListaLibros[index];

                if (libroComprado is not null)
                {
                    this.cliente.Importe += libroComprado.Precio;

                    this.formMenuPrincipal.richTextBoxClientes.Text = "";

                    foreach (Cliente item in this.formMenuPrincipal.libreria.ListaClientes)
                    {
                        this.formMenuPrincipal.richTextBoxClientes.AppendText(item.ToString());
                    }

                    // generar ticket
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("---------------FACTURA---------------");
                    sb.AppendLine($"NOMBRE: {this.cliente.Nombre} {this.cliente.Apellido}");
                    sb.AppendLine($"DNI: {this.cliente.Dni}");
                    sb.AppendLine($"PRODUCTO: {libroComprado.Titulo}, {libroComprado.Autor}");
                    sb.AppendLine($"CODIGO: {libroComprado.Codigo}");
                    sb.AppendLine($"IMPORTE: ${libroComprado.Precio}");

                    try
                    {
                        Archivo.Escribir(sb.ToString(), "Facturas");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrio un problema al guardar la factura", "Error: Escritura de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();
                    this.Owner.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un libro para proceder", "Error: Libro seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
