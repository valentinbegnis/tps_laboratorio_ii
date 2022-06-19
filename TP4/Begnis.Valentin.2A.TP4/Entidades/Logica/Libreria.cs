using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libreria
    {
        private List<Libro> listaLibros;
        private List<Cliente> listaClientes;

        public List<Libro> ListaLibros { get => listaLibros; set => listaLibros = value; }
        public List<Cliente> ListaClientes { get => listaClientes; set => listaClientes = value; }

        public Libreria()
        {
            this.listaLibros = new List<Libro>();
            this.listaClientes = new List<Cliente>();
        }

        public static bool operator ==(Libreria libreria, Libro libro)
        {
            if (libreria is not null && libro is not null)
            {
                foreach (Libro item in libreria.listaLibros)
                {
                    if (item.Codigo == libro.Codigo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator !=(Libreria libreria, Libro libro)
        {
            return !(libreria == libro);
        }

        public static bool operator +(Libreria libreria, Libro libro)
        {
            if (libreria is not null && libro is not null)
            {
                if (libreria != libro)
                {
                    libreria.listaLibros.Add(libro);
                    return true;
                }
            }
            return false;
        }

        public static bool operator -(Libreria libreria, Libro libro)
        {
            if (libreria is not null && libro is not null)
            {
                if (libreria == libro)
                {
                    libreria.listaLibros.Remove(libro);
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Libreria libreria, Cliente cliente)
        {
            if (libreria is not null && cliente is not null)
            {
                foreach (Cliente item in libreria.listaClientes)
                {
                    if (item.Dni == cliente.Dni)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator !=(Libreria libreria, Cliente cliente)
        {
            return !(libreria == cliente);
        }

        public static bool operator +(Libreria libreria, Cliente cliente)
        {
            if (libreria is not null && cliente is not null)
            {
                if (libreria != cliente)
                {
                    libreria.listaClientes.Add(cliente);
                    return true;
                }
            }
            return false;
        }

        public static bool operator -(Libreria libreria, Cliente cliente)
        {
            if (libreria is not null && cliente is not null)
            {
                if (libreria == cliente)
                {
                    libreria.listaClientes.Remove(cliente);
                    return true;
                }
            }
            return false;
        }
    }
}
