using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;

namespace EntregaF.Datos
{
    public class PromocionProductoDatos
    {
        public List<PromocionProducto> Listar()
        {
            var oLista = new List<PromocionProducto>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarPROMOCION_PRODUCTOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PromocionProducto()
                        {
                            NUMERO_PROMOCION = Convert.ToInt32(dr["NUMERO_PROMOCION"]),
                            PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_COD"]),
                            PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]),
                            FECHA_FINAL = dr["FECHA_FINAL"].ToString(),
                            FECHA_INICIO = dr["FECHA_INICIO"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public PromocionProducto Obtener(int NUMERO_PROMOCION)
        {
            var oPromocionProducto = new PromocionProducto();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerPROMOCION_PRODUCTOS", connection);
                cmd.Parameters.AddWithValue("NUMERO_PROMOCION", NUMERO_PROMOCION);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPromocionProducto.NUMERO_PROMOCION = Convert.ToInt32(dr["NUMERO_PROMOCION"]);
                        oPromocionProducto.PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_COD"]);
                        oPromocionProducto.PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]);
                        oPromocionProducto.FECHA_FINAL = dr["FECHA_FINAL"].ToString();
                        oPromocionProducto.FECHA_INICIO = dr["FECHA_INICIO"].ToString();
                    }
                }
            }
            return oPromocionProducto;
        }

        public bool Guardar(PromocionProducto oPromocionProducto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarPROMOCION_PRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("PROMOCIONES_COD", oPromocionProducto.PROMOCIONES_COD);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", oPromocionProducto.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("FECHA_FINAL", oPromocionProducto.FECHA_FINAL);
                    cmd.Parameters.AddWithValue("FECHA_INICIO", oPromocionProducto.FECHA_INICIO);
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
        public bool Editar(PromocionProducto oPromocionProducto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarPROMOCION_PRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("NUMERO_PROMOCION", oPromocionProducto.NUMERO_PROMOCION);
                    cmd.Parameters.AddWithValue("PROMOCIONES_COD", oPromocionProducto.PROMOCIONES_COD);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", oPromocionProducto.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("FECHA_FINAL", oPromocionProducto.FECHA_FINAL);
                    cmd.Parameters.AddWithValue("FECHA_INICIO", oPromocionProducto.FECHA_INICIO);
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
        public bool Eliminar(int NUMERO_PROMOCION)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarPROMOCION_PRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("NUMERO_PROMOCION", NUMERO_PROMOCION);
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
