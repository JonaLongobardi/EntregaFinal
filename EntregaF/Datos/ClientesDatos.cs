﻿using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;
using EntregaF.Datos;

namespace EntregaF.Datos
{
    public class ClientesDatos
    {
        public List<Clientes> Listar()
        {
            var oLista = new List<Clientes>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarCLIENTES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Clientes()
                        {
                            CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                            CORREO = dr["CORREO"].ToString(),
                            TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString(),
                            CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]),
                            RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Clientes Obtener(int CLIENTES_COD)
        {
            var oClientes = new Clientes();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerCLIENTES", connection);
                cmd.Parameters.AddWithValue("CLIENTES_COD", CLIENTES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oClientes.CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]);
                        oClientes.NOMBRE = dr["NOMBRE"].ToString();
                        oClientes.APELLIDO = dr["APELLIDO"].ToString();
                        oClientes.CORREO = dr["CORREO"].ToString();
                        oClientes.TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString();
                        oClientes.CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]);
                        oClientes.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                    }
                }
            }
            return oClientes;
        }

        public bool Guardar(Clientes oCliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarCLIENTES", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oCliente.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oCliente.APELLIDO);
                    cmd.Parameters.AddWithValue("CORREO", oCliente.CORREO);
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oCliente.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oCliente.CUIT_DNI);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oCliente.RAZON_SOCIAL);
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
        public bool Editar(Clientes oCliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarCLIENTES", connection);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", oCliente.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oCliente.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oCliente.APELLIDO);
                    cmd.Parameters.AddWithValue("CORREO", oCliente.CORREO);
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oCliente.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oCliente.CUIT_DNI);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oCliente.RAZON_SOCIAL);
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
        public bool Eliminar(int CLIENTES_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarCLIENTES", connection);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", CLIENTES_COD);
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
