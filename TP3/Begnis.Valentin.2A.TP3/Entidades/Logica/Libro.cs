using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        private string titulo;
        private string autor;
        private EGenero genero;
        private int cantidadPaginas;
        private int codigo;
        private float precio;

        public string Titulo { get => this.titulo; set => this.titulo = value; }
        public string Autor { get => this.autor; set => this.autor = value; }
        public EGenero Genero { get => this.genero; set => this.genero = value; }
        public int CantidadPaginas { get => this.cantidadPaginas; set => this.cantidadPaginas = value; }
        public int Codigo { get => this.codigo; set => this.codigo = value; }
        public float Precio { get => this.precio; set => this.precio = value; }

        public Libro(string titulo, string autor, EGenero genero, int cantidadPaginas, int codigo, float precio)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.genero = genero;
            this.cantidadPaginas = cantidadPaginas;
            this.codigo = codigo;
            this.precio = precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TITULO: {this.Titulo}");
            sb.AppendLine($"AUTOR: {this.Autor}");

            if (this.Genero.ToString() == "Ficcion")
            {
                sb.AppendLine("GENERO: Ficción");
            }
            else
            {
                sb.AppendLine("GENERO: No-ficción");
            }

            sb.AppendLine($"CANTIDAD DE PAGINAS: {this.CantidadPaginas}");
            sb.AppendLine($"CODIGO: {this.Codigo}");
            sb.AppendLine($"PRECIO: ${this.Precio}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
