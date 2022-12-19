using System.Data.SqlClient;
using System.Data;
using EntregaF.Models;
using EntregaF.Datos;

namespace EntregaDef.Datos
{
    public class PromocionesDatos
    {
        public List<Promociones> Listar()
        {
            var oLista = new List<Promociones>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarPROMOCIONES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Promociones()
                        {
                            PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_CODIGO"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            DESCUENTO = Convert.ToInt32(dr["DESCUENTO"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public Promociones Obtener(int PROMOCIONES_CODIGO)
        {
            var oPromociones = new Promociones();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerPROMOCIONES", connection);
                cmd.Parameters.AddWithValue("PROMOCIONES_CODIGO", PROMOCIONES_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPromociones.PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_CODIGO"]);
                        oPromociones.NOMBRE = dr["NOMBRE"].ToString();
                        oPromociones.DESCUENTO = Convert.ToInt32(dr["DESCUENTO"]);
                    }
                }
            }
            return oPromociones;
        }

        public bool Guardar(Promociones oPromociones)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarPROMOCIONES", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oPromociones.NOMBRE);
                    cmd.Parameters.AddWithValue("DESCUENTO", oPromociones.DESCUENTO);
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
        public bool Editar(Promociones oPromociones)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarPROMOCIONES", connection);
                    cmd.Parameters.AddWithValue("PROMOCIONES_CODIGO", oPromociones.PROMOCIONES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oPromociones.NOMBRE);
                    cmd.Parameters.AddWithValue("DESCUENTO", oPromociones.DESCUENTO);
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
        public bool Eliminar(int PROMOCIONES_CODIGO)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarPROMOCIONES", connection);
                    cmd.Parameters.AddWithValue("PROMOCIONES_CODIGO", PROMOCIONES_CODIGO);
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
