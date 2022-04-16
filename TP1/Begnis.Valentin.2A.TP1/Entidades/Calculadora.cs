using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza una operacion entre dos operandos. La operacion a realizar la determina en base
        /// al operador recibido que, ademas, sera validado
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Caracter correspondiente al operador</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValidado = Calculadora.ValidarOperador(operador);
            double resultado = 0;

            switch (operadorValidado)
            {
                case '+':
                    resultado = Math.Round(num1 + num2, 2);
                    break;
                case '-':
                    resultado = Math.Round(num1 - num2, 2);
                    break;
                case '/':
                    resultado = Math.Round(num1 / num2, 2);
                    break;
                case '*':
                    resultado = Math.Round(num1 * num2, 2); 
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida el operador. El unico caso posible de no ser +, -, *, /, es ' '. 
        /// </summary>
        /// <param name="operador">caracter correspondiente al operador a validar</param>
        /// <returns>Retorna el operador en cuestion si es valido. De no serlo, o sea ' ', retorna '+'</returns>
        private static char ValidarOperador(char operador)
        {
            return operador == ' ' ? '+' : operador;
        }
    }
}
