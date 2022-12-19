using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;
using EntregaF.Datos;

namespace EntregaF.Datos
{
    public class OrdenesDatos
    {
        public List<Ordenes> Listar()
        {
            var oLista = new List<Ordenes>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarORDENES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Ordenes()
                        {
                            ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]),
                            FECHA_ENTREGA = dr["FECHA_ENTREGA"].ToString(),
                            VENDEDOR = dr["VENDEDOR"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Ordenes Obtener(int ORDENES_COD)
        {
            var oOrdenes = new Ordenes();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerORDENES", connection);
                cmd.Parameters.AddWithValue("ORDENES_COD", ORDENES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oOrdenes.ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]);
                        oOrdenes.FECHA_ENTREGA = dr["FECHA_ENTREGA"].ToString();
                    }
                }
            }
            return oOrdenes;
        }

        public bool Guardar(Ordenes oOrdenes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarORDENES", connection);
                    cmd.Parameters.AddWithValue("FECHA_ENTREGA", oOrdenes.FECHA_ENTREGA);
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
        public bool Editar(Ordenes oOrdenes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarORDENES", connection);
                    cmd.Parameters.AddWithValue("ORDENES_COD", oOrdenes.ORDENES_COD);
                    cmd.Parameters.AddWithValue("FECHA_ENTREGA", oOrdenes.FECHA_ENTREGA);
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
        public bool Eliminar(int ORDENES_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarORDENES", connection);
                    cmd.Parameters.AddWithValue("ORDENES_COD", ORDENES_COD);
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
