using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor que inicializa el objeto formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga el formulario. Llama al metodo que limpia el formulario. Ademas,
        /// centra el formulario en la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Limpiar();            
        }

        /// <summary>
        /// Realiza la limpieza de los TextBox, ComboBox y Label
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }


        /// <summary>
        /// Llama al metodo Limpiar al hacer click en el boton btnLimpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Crea dos instancias del objeto tipo Operando que seran los operadores y convierte
        /// el operador formato string recibido a char. Llama al metodo Operar de la clase estatica 
        /// Calculadora
        /// </summary>
        /// <param name="numero1">string correspondiente al operando uno</param>
        /// <param name="numero2">string correspondiente al operando dos</param>
        /// <param name="operador">string correspondiente al operador</param>
        /// <returns>Retorna el resultado de la operacion entre ambos numeros</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operandoUno = new Operando(numero1);
            Operando operandoDos = new Operando(numero2);
            char operadorChar = operador.ToCharArray()[0];

            return Calculadora.Operar(operandoUno, operandoDos, operadorChar);
        }

        /// <summary>
        /// Al presionar el boton btnOperar realizara la operacion correspondiente (segun el operador
        /// elegido en el ComboBox) de los numeros presentes en los TextBox. Para realizar la operacion
        /// llama al metodo Operar, validando previamente que los numeros en formato string no tengan 
        /// caracteres y validando el operador. Ademas, si el string contiene comas las reemplaza por
        /// puntos. Si todo es correcto, asigno el resultado de la operacion al label lblResultado y la 
        /// operacion perse al ListBox lstOperaciones. Caso contrario, asigno "Valor inválido" al 
        /// label lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double numero;
            string numeroUno = this.txtNumero1.Text;
            string numeroDos = this.txtNumero2.Text;
            bool noTieneCharsNumeroUno = Double.TryParse(numeroUno, out double resultadoUno);
            bool noTieneCharsNumeroDos = Double.TryParse(numeroDos, out double resultadoDos);
            string operador = this.cmbOperador.Text == " " ? "+" : this.cmbOperador.Text;

            if (numeroUno != "" && numeroDos != "" && noTieneCharsNumeroUno && noTieneCharsNumeroDos)
            {
                if (numeroUno.Contains(','))
                {
                   numeroUno = numeroUno.Replace(',', '.');
                }
                if (numeroDos.Contains(','))
                {
                    numeroDos = numeroDos.Replace(',', '.');
                }

                numero = Operar(numeroUno, numeroDos, operador);
                this.lblResultado.Text = numero.ToString();

                lstOperaciones.Items.Add($"{numeroUno} {operador} {numeroDos} = {numero}");
            }
            else
            {
                this.lblResultado.Text = "Valor inválido";
            }
        }

        /// <summary>
        /// Al presionar el boton btnCerrar, muestro un modal al usuario preguntando si en verdad
        /// desea salir de la aplicacion. Si presiona "Sí" se cerrara la calculadora. Si presiona "No",
        /// se cierra el modal y continua la ejecucion del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguro de querer salir?";
            string titulo = "Salir";
            MessageBoxButtons opciones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Question;

            DialogResult opcionElegida = MessageBox.Show(mensaje, titulo, opciones, icono);

            if (opcionElegida == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Al presionar el boton btnConvertirAbinario, instancio un objeto tipo Operando con 
        /// el contenido del label lblResultado para poder llamar al metodo DecimalBinario y realizar
        /// la conversion sistema decimal-binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando(this.lblResultado.Text);
            this.lblResultado.Text = operando.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// Al presionar el boton btnConvertirADecimal, instancio un objeto tipo Operando con 
        /// el contenido del label lblResultado para poder llamar al metodo BinarioDecimal y realizar,
        /// si es posible, la conversion sistema binario-decimal        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando(this.lblResultado.Text);
            this.lblResultado.Text = operando.BinarioDecimal(this.lblResultado.Text);
        }
    }
}
