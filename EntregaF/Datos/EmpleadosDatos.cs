using System.Data.SqlClient;
using System.Data;
using EntregaF.Models;

namespace EntregaF.Datos
{
    public class EmpleadosDatos
    {
        public List<Empleados> Listar()
        {
            var oLista = new List<Empleados>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarEMPLEADOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Empleados()
                        {
                            EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_CODIGO"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                            TIPO_EMPLEADO = dr["TIPO_EMPLEADO"].ToString(),
                            USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public Empleados Obtener(int EMPLEADOS_CODIGO)
        {
            var oEmpleados = new Empleados();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerEMPLEADOS", connection);
                cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", EMPLEADOS_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmpleados.EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_CODIGO"]);
                        oEmpleados.NOMBRE = dr["NOMBRE"].ToString();
                        oEmpleados.APELLIDO = dr["APELLIDO"].ToString();
                        oEmpleados.TIPO_EMPLEADO = dr["TIPO_EMPLEADO"].ToString();
                        oEmpleados.USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]);
                    }
                }
            }
            return oEmpleados;
        }

        public bool Guardar(Empleados oEmpleados)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarEMPLEADOS", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oEmpleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oEmpleados.APELLIDO);
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oEmpleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oEmpleados.USUARIOS_CODIGO);
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
        public bool Editar(Empleados oEmpleados)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarEMPLEADOS", connection);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", oEmpleados.EMPLEADOS_CODIGO);
                    cmd.Parameters.AddWithValue("NOMBRE", oEmpleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oEmpleados.APELLIDO);
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oEmpleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oEmpleados.USUARIOS_CODIGO);
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
        public bool Eliminar (int EMPLEADOS_CODIGO)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarEMPLEADOS", connection);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", EMPLEADOS_CODIGO);
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
