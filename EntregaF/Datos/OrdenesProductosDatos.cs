using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;

namespace EntregaF.Datos
{
    public class OrdenesProductosDatos
    {
        public List<OrdenesProducto> Listar()
        {
            var oLista = new List<OrdenesProducto>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarORDENES_PRODUCTOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new OrdenesProducto()
                        {
                            ORDENESPRODUCTOSCOD = Convert.ToInt32(dr["ORDENESPRODUCTOSCOD"]),
                            ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]),
                            PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]),
                            CANTIDADPRODUCTO = Convert.ToInt32(dr["CANTIDADPRODUCTO"]),
                            PRECIOCOMPRA = Convert.ToInt32(dr["PRECIOCOMPRA"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public OrdenesProducto Obtener(int ORDENESPRODUCTOSCOD)
        {
            var oOrdenesProductos = new OrdenesProducto();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerORDENES_PRODUCTOS", connection);
                cmd.Parameters.AddWithValue("ORDENES_COD", ORDENESPRODUCTOSCOD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oOrdenesProductos.ORDENESPRODUCTOSCOD = Convert.ToInt32(dr["ORDENESPRODUCTOSCOD"]);
                        oOrdenesProductos.ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]);
                        oOrdenesProductos.PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]);
                        oOrdenesProductos.CANTIDADPRODUCTO = Convert.ToInt32(dr["CANTIDADPRODUCTO"]);
                        oOrdenesProductos.PRECIOCOMPRA = Convert.ToInt32(dr["PRECIOCOMPRA"]);
                        
                    }
                }
            }
            return oOrdenesProductos;
        }

        public bool Guardar(OrdenesProducto oOrdenesProductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarORDENES_PRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("ORDENES_COD", oOrdenesProductos.ORDENES_COD);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", oOrdenesProductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("CANTIDADPRODUCTO", oOrdenesProductos.CANTIDADPRODUCTO);
                    cmd.Parameters.AddWithValue("PRECIOCOMPRA", oOrdenesProductos.PRECIOCOMPRA);
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
        public bool Editar(OrdenesProducto oOrdenesProductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarORDENES_PRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("ORDENESPRODUCTOSCOD", oOrdenesProductos.ORDENESPRODUCTOSCOD);
                    cmd.Parameters.AddWithValue("ORDENES_COD", oOrdenesProductos.ORDENES_COD);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", oOrdenesProductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("CANTIDADPRODUCTO", oOrdenesProductos.CANTIDADPRODUCTO);
                    cmd.Parameters.AddWithValue("PRECIOCOMPRA", oOrdenesProductos.PRECIOCOMPRA);
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
        public bool Eliminar(int ORDENESPRODUCTOSCOD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarORDENES_PRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("ORDENESPRODUCTOSCOD", ORDENESPRODUCTOSCOD);
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
