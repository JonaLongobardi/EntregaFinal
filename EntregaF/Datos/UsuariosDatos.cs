using Microsoft.AspNetCore.Mvc;
using EntregaF.Models;
using EntregaF.Datos;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Session;
using System.Drawing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EntregaF.Datos
{
    public class UsuariosDatos
    {
        public List<Usuarios> Listar()
        {
            var oLista = new List<Usuarios>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarUSUARIOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Usuarios()
                        {
                            USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]),
                            CORREO = dr["CORREO"].ToString(),
                            CONTRASENIA = dr["CONTRASENIA"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Usuarios Obtener(int USUARIOS_CODIGO)
        {
            var oUsuarios = new Usuarios();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obetenerUSUARIOS", connection);
                cmd.Parameters.AddWithValue("USUARIOS_CODIGO", USUARIOS_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuarios.USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]);
                        oUsuarios.CORREO = dr["CORREO"].ToString();
                        oUsuarios.CONTRASENIA = dr["CONTRASENIA"].ToString();
                    }
                }
            }
            return oUsuarios;
        }

        public bool Guardar(Usuarios oUsuarios)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarUSUARIOS", connection);
                    cmd.Parameters.AddWithValue("CORREO", oUsuarios.CORREO);
                    cmd.Parameters.AddWithValue("CONTRASENIA", oUsuarios.CONTRASENIA);
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Editar(Usuarios oUsuarios)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarUSUARIOS", connection);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oUsuarios.USUARIOS_CODIGO);
                    cmd.Parameters.AddWithValue("CORREO", oUsuarios.CORREO);
                    cmd.Parameters.AddWithValue("CONTRASENIA", oUsuarios.CONTRASENIA);
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Eliminar(int USUARIOS_CODIGO)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarUSUARIOS", connection);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", USUARIOS_CODIGO);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        
    }
}