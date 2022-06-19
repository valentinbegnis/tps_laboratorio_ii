using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConexionBD
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static ConexionBD()
        {
            ConexionBD.cadena_conexion = @"Server=.;Database=Libreria_TP4;Trusted_Connection=True;";
        }

        public ConexionBD()
        {
            this.conexion = new SqlConnection(ConexionBD.cadena_conexion);
        }

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public List<Libro> ObtenerListaLibros()
        {
            List<Libro> lista = new List<Libro>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Libros";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    string titulo = lector["titulo"].ToString();
                    string autor = lector["autor"].ToString();
                    string genero = lector["genero"].ToString();

                    EGenero generoEnumerado = default;
                    switch (genero)
                    {
                        case "Ficcion":
                            generoEnumerado = EGenero.Ficcion;
                            break;
                        case "No_Ficcion":
                            generoEnumerado = EGenero.No_Ficcion;
                            break;
                    }

                    int cantidadPaginas = Convert.ToInt32(lector["cantidad_paginas"]);
                    int codigo = Convert.ToInt32(lector["codigo"]);
                    float precio = float.Parse(lector[6].ToString());

                    lista.Add(new Libro(titulo, autor, generoEnumerado, cantidadPaginas, codigo, precio));
                }

                lector.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al cargar los libros de la base de datos");
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        public bool AgregarLibro(Libro libro)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO Libros (titulo, autor, genero, cantidad_paginas, codigo, precio) VALUES(";
                sql = sql + "'" + libro.Titulo + "','" + libro.Autor + "','" + libro.Genero + "'," + libro.CantidadPaginas + "," + libro.Codigo + "," + libro.Precio + ")";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }
       
        public bool ModificarLibro(Libro libro)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                this.comando.Parameters.AddWithValue("@autor", libro.Autor);
                this.comando.Parameters.AddWithValue("@genero", libro.Genero);
                this.comando.Parameters.AddWithValue("@cantidadPaginas", libro.CantidadPaginas);
                this.comando.Parameters.AddWithValue("@codigo", libro.Codigo);
                this.comando.Parameters.AddWithValue("@precio", libro.Precio);

                string sql = "UPDATE Libros ";
                sql += "SET titulo = @titulo, autor = @autor, genero = @genero, cantidad_paginas = @cantidadPaginas, codigo = @codigo, precio = @precio ";
                sql += "WHERE codigo = @codigo";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool EliminarLibro(int codigo)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@codigo", codigo);

                string sql = "DELETE FROM Libros ";
                sql += "WHERE codigo = @codigo";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }
    }
}

