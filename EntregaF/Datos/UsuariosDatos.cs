using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;

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
                            PERFILES_CODIGO = Convert.ToInt32(dr["PERFILES_CODIGO"]),
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
                        oUsuarios.PERFILES_CODIGO = Convert.ToInt32(dr["PERFILES_CODIGO"]);
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
                    cmd.Parameters.AddWithValue("PERFILES_CODIGO", oUsuarios.PERFILES_CODIGO);
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
                    cmd.Parameters.AddWithValue("NOMBRE", oUsuarios.PERFILES_CODIGO);
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
