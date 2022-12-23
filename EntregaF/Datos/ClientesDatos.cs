using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;


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
                            TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString(), 
                            RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString(),
                            CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                            USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]),   
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
                        oClientes.TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString();
                        oClientes.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                        oClientes.CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]);
                        oClientes.NOMBRE = dr["NOMBRE"].ToString();
                        oClientes.APELLIDO = dr["APELLIDO"].ToString();
                        oClientes.USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]);

                    }
                }
            }
            return oClientes;
        }

        public bool Guardar(Clientes oClientes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarCLIENTES", connection);
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oClientes.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oClientes.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oClientes.CUIT_DNI);
                    cmd.Parameters.AddWithValue("NOMBRE", oClientes.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oClientes.APELLIDO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oClientes.USUARIOS_CODIGO);
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
        public bool Editar(Clientes oClientes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarCLIENTES", connection);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", oClientes.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oClientes.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oClientes.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oClientes.CUIT_DNI);
                    cmd.Parameters.AddWithValue("NOMBRE", oClientes.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oClientes.APELLIDO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oClientes.USUARIOS_CODIGO);
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
