using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int dni;
        private double telefono;
        private string email;
        private float importe;

        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public string Apellido { get => this.apellido; set => this.apellido = value; }
        public int Dni { get => this.dni; set => this.dni = value; }
        public double Telefono { get => this.telefono; set => this.telefono = value; }
        public string Email { get => this.email; set => this.email = value; }
        public float Importe { get => this.importe; set => this.importe = value; }

        public Cliente(string nombre, string apellido, int dni, double telefono, string email)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.email = email;
            this.importe = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE: {this.Nombre}");
            sb.AppendLine($"APELLIDO: {this.Apellido}");
            sb.AppendLine($"DNI: {this.Dni}");
            sb.AppendLine($"TELEFONO: {this.Telefono}");
            sb.AppendLine($"EMAIL: {this.Email}");

            if (this.Importe > 0)
            {
                sb.AppendLine($"IMPORTE: ${this.Importe}");
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
