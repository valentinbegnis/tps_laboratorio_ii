using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        
        /// <summary>
        /// Propiedad que inicializa el atributo numero validando previamente
        /// </summary>
        private string Numero
        {
            set
            {
                double numero = this.ValidarOperando(value);
                this.numero = numero;
            }
        }

        /// <summary>
        /// Instancia el objeto tipo Operando con un numero double
        /// </summary>
        /// <param name="numero">Numero double</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }


        /// <summary>
        /// Sobrecarga del constructor que contempla el caso en el que no se reciben parametros.
        /// Llamo al constructor base inicializando el atributo numero en 0.
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor que contempla el caso en el que se recibe un parametro
        /// tipo string. La propiedad Numero se encargara de validar el operando
        /// </summary>
        /// <param name="strNumero">string que pasara por la propiedad para ser evaluado y asignado</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Realiza, de ser posible, el parseo del string recibido a double
        /// </summary>
        /// <param name="strNumero">string a parsear</param>
        /// <returns>Retorna el numero si se pudo parsear. Caso contrario, retorna 0</returns>
        private double ValidarOperando(string strNumero)
        {
            double numero = 0;

            if (strNumero is not null)
            {
                Double.TryParse(strNumero, out numero);
            }

            return numero;
        }

        /// <summary>
        /// Valida que el string recibido este conformado solamente de caracteres '1' y '0'.
        /// </summary>
        /// <param name="binario">string a validar</param>
        /// <returns>Retorna true si contiene solos '1' y '0' (es binario). Caso contrario,
        /// retorna false
        /// </returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Realiza, de ser posible, la conversion de binario a decimal
        /// </summary>
        /// <param name="binario">string (binario o no) a convertir a decimal</param>
        /// <returns>Retorna el numero correspondiente en sistema en decimal (formato string)
        /// o "Valor inválido" si no pasa la prueba de ser binario
        /// </returns>
        public string BinarioDecimal(string binario)
        {
            if (this.EsBinario(binario))
            {
                int j = 0;
                int numeroDecimal = 0;

                char[] digitos = binario.ToCharArray();
                for (int i = digitos.Length - 1; i >= 0; i--) 
                {

                    numeroDecimal += (int) Math.Pow(int.Parse(digitos[i].ToString()) * 2, j);
                    j++;
                }

                return numeroDecimal.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }
        
        /// <summary>
        /// Realiza la conversion de sistema decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir a binario</param>
        /// <returns>Retorna el numero binario correspondiente</returns>
        public string DecimalBinario(double numero)
        {
            string restos = "";
            numero = Math.Truncate(numero);

            while (numero >= 1)
            {
                restos += numero % 2;
                numero = (int) numero / 2;
            }

            char[] arrayDeCaracteres = restos.ToCharArray();
            string stringInvertido = "";
            int length = arrayDeCaracteres.Length - 1;

            while (length > -1)
            {
                stringInvertido += arrayDeCaracteres[length];
                length--;
            }

            return stringInvertido;
        }
        
        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que contempla el caso en el que el parametro
        /// sea tipo string
        /// </summary>
        /// <param name="numero">string que representa un numero decimal</param>
        /// <returns>Retorna el numero binario correspondiente</returns>
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(Double.Parse(numero));
        }

        /// <summary>
        /// Sobrecarga del operador + para poder realizar una suma entre los atributos numero
        /// del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Retorna la suma entre ambos campos</returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador - para poder realizar una resta entre los atributos numero
        /// del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Retorna la resta entre ambos campos</returns>
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para poder realizar una multiplicacion entre los atributos
        /// numero del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Retorna la multiplicacion entre ambos campos</returns>
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / para poder realizar una division entre los atributos
        /// numero del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Si el operando dos es distinto, retorna la division entre ambos campos.
        /// Caso contrario, retorna el menor valor posible para un Double (Double.MinValue)
        /// </returns>
        public static double operator / (Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return Double.MinValue;
            }
        }
    }
}
