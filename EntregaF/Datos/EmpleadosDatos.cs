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
                            EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_COD"]),
                            TIPO_EMPLEADO = Convert.ToInt32(dr["TIPO_EMPLEADO"]),
                            APELLIDO_SUPERVISOR = dr["APELLIDO_SUPERVISOR"].ToString(),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
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
                        oEmpleados.EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_COD"]);
                        oEmpleados.TIPO_EMPLEADO = Convert.ToInt32(dr["TIPO_EMPLEADO"]);
                        oEmpleados.APELLIDO_SUPERVISOR = dr["APELLIDO_SUPERVISOR"].ToString();
                        oEmpleados.NOMBRE = dr["NOMBRE"].ToString();
                        oEmpleados.APELLIDO = dr["APELLIDO"].ToString();
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
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oEmpleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("APELLIDO_SUPERVISOR", oEmpleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("NOMBRE", oEmpleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oEmpleados.APELLIDO);
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
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oEmpleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("APELLIDO_SUPERVISOR", oEmpleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("NOMBRE", oEmpleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oEmpleados.APELLIDO);
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
